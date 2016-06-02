using System;
using System.Drawing;
using System.IO;
using Pranas;

namespace GrabMagicDesktop
{
    public class Screenshot
    {
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string Filename = "//" + "Screenshot" + ".png";
        public string FullPath = Path + Filename;

        public Screenshot()
        {
            Data = new Data();
        }

        public Data Data { get; set; }

        public void CaptureFullScreen()
        {
            var image = ScreenshotCapture.TakeScreenshot();

            image.Save(FullPath);
            var img = File.ReadAllBytes(FullPath);

            Data.Upload(img);
            Delete();
        }

        public void CaptureImage(Size curSize, Point curPos, Point sourcePoint, Point destinationPoint,
            Rectangle selectionRectangle)
        {
            using (var bitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(sourcePoint, destinationPoint, selectionRectangle.Size);

                    bitmap.Save(FullPath);

                    var img = File.ReadAllBytes(FullPath);

                    Data.Upload(img);
                    Delete();
                }
            }
        }

        public void Delete()
        {
            File.Delete(FullPath);
        }
    }
}