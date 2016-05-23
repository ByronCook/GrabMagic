using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GrabMagicDesktop
{
    public partial class GrabMagic : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int FULLSCREEN_HOTKEY_ID = 1;

        public Screenshot Screenshot { get; set; }

        public GrabMagic()
        {
            InitializeComponent();
            Screenshot = new Screenshot();
            RegisterHotKey(Handle, FULLSCREEN_HOTKEY_ID, 0, (int)Keys.F5);
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == FULLSCREEN_HOTKEY_ID)
            {
                Screenshot.CaptureFullScreen();
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screenshot.CaptureFullScreen();
            GrabMagicNotify.BalloonTipTitle = "GrabMagic™";
            GrabMagicNotify.BalloonTipText = "Screenshot has been uploaded!";
            GrabMagicNotify.ShowBalloonTip(500);

        }

        private void GrabMagic_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                GrabMagicNotify.Visible = true;
                Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                GrabMagicNotify.Visible = false;

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
