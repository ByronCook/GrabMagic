using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GrabMagicDesktop
{
    public partial class GrabMagic : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int FullscreenHotkeyId = 1;
        private const int RegionHotkeyId = 2;

        public Screenshot Screenshot { get; set; }

        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public GrabMagic()
        {
            InitializeComponent();
            Screenshot = new Screenshot();
            RegisterHotKey(Handle, FullscreenHotkeyId, (int) KeyModifier.Shift, (int)Keys.D3);
            RegisterHotKey(Handle, RegionHotkeyId, (int)KeyModifier.Shift, (int)Keys.D2);
            rkApp.SetValue("GrabMagic", Application.ExecutablePath);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == FullscreenHotkeyId)
            {
                Screenshot.CaptureFullScreen();
                SuccesfullUploadBalloon();
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == RegionHotkeyId)
            {
                Screenshot.CaptureFullScreen();
                SuccesfullUploadBalloon();
            }
            base.WndProc(ref m);
        }

        private void SuccesfullUploadBalloon()
        {
            GrabMagicNotify.BalloonTipTitle = @"GrabMagic™";
            GrabMagicNotify.BalloonTipText = @"Screenshot has been uploaded!";
            GrabMagicNotify.ShowBalloonTip(350);
        }

        private void GrabMagic_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    GrabMagicNotify.Visible = true;
                    Hide();
                    break;
                case FormWindowState.Normal:
                    GrabMagicNotify.Visible = false;
                    break;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void RegionButton_Click(object sender, EventArgs e)
        {
            //Screenshot.CaptureFullScreen();
            //SuccesfullUploadBalloon();
        }

        private void FullscreenScreenshotButton_Click(object sender, EventArgs e)
        {
            Screenshot.CaptureFullScreen();
            SuccesfullUploadBalloon();
        }
    }
}
