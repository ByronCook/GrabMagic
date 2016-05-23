using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;

namespace GrabMagicDesktop
{
    public class Data
    {
        //public void UploadImage(string filename, byte[] img, DateTime currentDate, int userId)
        //{
        //    const string saveImage =
        //        "INSERT into [IMAGE] (Imagename,Image,Date,UserId_FK) VALUES (@Imagename,@Image,@Date,@UserId)";
        //    try
        //    {
        //        var openCon =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["SmarterAsp"].ConnectionString);
        //        openCon.Open();

        //        using (var imageSave = new SqlCommand(saveImage))
        //        {
        //            imageSave.Connection = openCon;
        //            imageSave.Parameters.Add("@Imagename", filename);
        //            imageSave.Parameters.Add("@Image", img);
        //            imageSave.Parameters.Add("@Date", currentDate);
        //            imageSave.Parameters.Add("@UserId", userId);
        //            // openCon.Open();
        //            imageSave.ExecuteNonQuery();
        //            openCon.Close();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

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
