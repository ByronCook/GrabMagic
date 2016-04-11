using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ClientServices.Providers;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Web.ClientServices;
using System.Web.ClientServices.Providers;
using System.Web.Security;

namespace GrabMagicDesktop
{
    public partial class LoginForm : Form//, IClientFormsAuthenticationCredentialsProvider
    {
        public LoginForm()
        {
            InitializeComponent();
           // GetCredentials();
        }
        //public ClientFormsAuthenticationCredentials GetCredentials()
        //{
        //    if (this.ShowDialog() == DialogResult.OK)
        //    {
        //        return new ClientFormsAuthenticationCredentials(
        //            UsernameText.Text, PasswordText.Text,
        //            true);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=SQL5017.Smarterasp.net;Initial Catalog=DB_9FA624_byron010;User ID=DB_9FA624_byron010_admin;Password=simple123";
            //SqlConnection sqlCon = new SqlConnection(connectionString);
            //sqlCon.Open();
            if (!System.Web.Security.Membership.ValidateUser(
                UsernameText.Text, PasswordText.Text))
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                Hide();
                new GrabMagicForm().Show();
            }
            //sqlCon.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!Membership.ValidateUser("Bailey", "Bailey"))
            {
                MessageBox.Show("Unable to authenticate.", "Not logged in",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
