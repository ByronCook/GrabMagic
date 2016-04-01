using System;
using System.Drawing;
using System.IO;
using Pranas;

namespace GrabMagicDesktop
{
    class Screenshot
    {
        private string _fullPath;
        public Image GrabFullScreen()
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
            return image;
        }

        public void Delete()
        {
            File.Delete(_fullPath);
        }
    }
}
