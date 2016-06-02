using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public partial class BalloonForm : Form
    {
        public BalloonForm()
        {
            InitializeComponent();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SuccesfullUploadBalloon()
        {
            GrabMagicNotify.BalloonTipTitle = @"GrabMagic™";
            GrabMagicNotify.BalloonTipText = @"Screenshot has been uploaded!";
            GrabMagicNotify.ShowBalloonTip(350);
        }
    }
}
