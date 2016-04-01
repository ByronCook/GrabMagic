using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace GrabMagicDesktop
{
    class Ftp
    {
        public void UploadFile(Image image)
        {

            //User details might need to be replaced by users login? not sure
            var ftpusername = "byron010-001"; // e.g. username
            var ftppassword = "0ByronBailey1"; // e.g. password

            try
            {
                var day = Convert.ToString(DateTime.Now.Day).Replace(":", "-");
                var hour = Convert.ToString(DateTime.Now.Hour).Replace(":", "-"); ;
                var minute = Convert.ToString(DateTime.Now.Minute).Replace(":", "-"); ;
                var date = day + hour + minute;

                const string ftpurl = @"ftp://208.118.63.59:21/site1/"; // e.g. ftp://serverip/foldername/foldername
                var ftpfullpath = ftpurl + @"Screenshot" + date + ".png";
                var ftp = (FtpWebRequest)WebRequest.Create(ftpfullpath);

                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                var fs = File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + "Screenshot" + date + ".png");
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                var ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Not used atm, might be usefull for ignoring saving/deleting the file and uploading it immediately
        private static Stream ToStream(Image image, ImageFormat formaw)
        {
            var stream = new MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
    }
}
