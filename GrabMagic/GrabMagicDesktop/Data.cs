using System.Diagnostics;
using System.Windows.Forms;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;

namespace GrabMagicDesktop
{
    public class Data
    {
        public async void Upload(byte[] img)
        {
            try
            {
                var client = new ImgurClient("30b82692bb98592", "f38cecb2f5707a74e0e6a7caf0e1c43dc6ae3b58");
                var endpoint = new ImageEndpoint(client);
                var image = await endpoint.UploadImageBinaryAsync(img);
                Process.Start(image.Link);
            }
            catch (ImgurException imgurEx)
            {
                MessageBox.Show("An error occurred uploading an image to Imgur.");
                MessageBox.Show(imgurEx.Message);
            }
        }
    }
}
