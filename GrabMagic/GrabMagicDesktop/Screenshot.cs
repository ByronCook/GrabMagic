using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Pranas;

namespace GrabMagicDesktop
{
    public class Screenshot
    {
        private string _fullPath;
        public Data Data { get; set; }
        public Screenshot()
        {
            Data = new Data();
        }
        public void CaptureFullScreen(int userId)
        {
            var image = ScreenshotCapture.TakeScreenshot();

            var day = Convert.ToString(DateTime.Now.Day).Replace(":", "-");
            var hour = Convert.ToString(DateTime.Now.Hour).Replace(":", "-"); ;
            var minute = Convert.ToString(DateTime.Now.Minute).Replace(":", "-"); ;
            var date = day + hour + minute;
            var currentDate = DateTime.Now;

            var filename = "Screenshot" + date + ".png";
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename1 = "//" + "Screenshot" + date + ".png";
            _fullPath = path + filename1;

            image.Save(path + filename1);
            var img = File.ReadAllBytes(_fullPath);

            Data.UploadImage(filename, img, currentDate, userId);
            Delete();
        }
        public void Delete()
        {
            File.Delete(_fullPath);
        }
    }
}
