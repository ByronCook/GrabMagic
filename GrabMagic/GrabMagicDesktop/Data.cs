using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public class Data
    {
        public void UploadImage(string filename, byte[] img, DateTime currentDate, int userId)
        {
            const string saveImage = "INSERT into [IMAGE] (Imagename,Image,Date,UserId_FK) VALUES (@Imagename,@Image,@Date,@UserId)";
            try
            {
                var openCon =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SmarterAsp"].ConnectionString);
                openCon.Open();

                using (var imageSave = new SqlCommand(saveImage))
                {
                    imageSave.Connection = openCon;
                    imageSave.Parameters.Add("@Imagename", filename);
                    imageSave.Parameters.Add("@Image", img);
                    imageSave.Parameters.Add("@Date", currentDate);
                    imageSave.Parameters.Add("@UserId", userId);
                    // openCon.Open();
                    imageSave.ExecuteNonQuery();
                    openCon.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
