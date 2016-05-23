using System;
using System.IO;
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
        public void CaptureFullScreen()
        {
            var image = ScreenshotCapture.TakeScreenshot();

            var day = Convert.ToString(DateTime.Now.Day).Replace(":", "-");
            var hour = Convert.ToString(DateTime.Now.Hour).Replace(":", "-"); ;
            var minute = Convert.ToString(DateTime.Now.Minute).Replace(":", "-"); ;
            var date = day + hour + minute;

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = "//" + "Screenshot" + date + ".png";
            _fullPath = path + filename;

            image.Save(path + filename);
            var img = File.ReadAllBytes(_fullPath);

            Data.Upload(img);
            Delete();
        }
        public void Delete()
        {
            File.Delete(_fullPath);
        }
    }
}
