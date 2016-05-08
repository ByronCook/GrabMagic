using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                //var con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=Login;Integrated Security=True;Pooling=False");
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["GrabMagicDatabase"].ConnectionString);
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT * FROM [User] WHERE Username=@username AND Password=@password";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                con.Open();

                var adapt = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapt.Fill(ds);

                con.Close();

                var count = ds.Tables[0].Rows.Count;
                var userId = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successfull!");
                    Hide();
                    
                    new GrabMagic(userId).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
