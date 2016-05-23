using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ShowPicture : Form
    {
        public ShowPicture()
        {
            InitializeComponent();
        }

        private void ShowPicture_Load(object sender, EventArgs e)
        {
            const string retrieveImage = "SELECT * FROM [Image] WHERE @ImageId=ImageId";
            try
            {
                var openCon =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SmarterAsp"].ConnectionString);
                openCon.Open();

                using (var cmd = new SqlCommand(retrieveImage))
                {
                    cmd.Connection = openCon;
                    cmd.Parameters.Add("@ImageId", 3);
                    //imageSave.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] picData = reader["Image"] as byte[] ?? null;

                            if (picData != null)
                            {
                                using (MemoryStream ms = new MemoryStream(picData))
                                {
                                    // Load the image from the memory stream. How you do it depends
                                    // on whether you're using Windows Forms or WPF.
                                    // For Windows Forms you could write:
                                    //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                    openCon.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
