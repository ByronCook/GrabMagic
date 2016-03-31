using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public partial class GrabMagicForm : Form
    {
        public GrabMagicForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = Pranas.ScreenshotCapture.TakeScreenshot();
            image.Save("C:\\Users\\Byron\\file.png");
            upload(image);
        }

        public void upload(Image image)
        {
            try
            {
            String sourcefilepath = "C:\\Users\\Byron\\file.png";
            String ftpurl = "ftp://smarterasp.net/site1/"; // e.g. ftp://serverip/foldername/foldername
            String ftpusername = "byron010-001"; // e.g. username
            String ftppassword = "00melby11"; // e.g. password
            string filename = Path.GetFileName(sourcefilepath);
            string ftpfullpath = ftpurl + "file.png";
            FtpWebRequest ftp = (FtpWebRequest) FtpWebRequest.Create(ftpfullpath);
            ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
                ftp.EnableSsl = true;

            FileStream fs = File.OpenRead(sourcefilepath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public static Stream ToStream(Image image, ImageFormat formaw)
        {
            var stream = new MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
    }
}
