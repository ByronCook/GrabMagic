using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GrabMagicDesktop
{
    public partial class GrabMagic : Form
    {
        private const int FullscreenHotkeyId = 1;
        private const int RegionHotkeyId = 2;

        public Screenshot Screenshot { get; set; }
        public BalloonForm BalloonForm { get; set; }
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        private readonly RegistryKey _rkApp =
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public GrabMagic()
        {
            InitializeComponent();

            Screenshot = new Screenshot();
            BalloonForm = new BalloonForm();

            RegisterHotKey(Handle, FullscreenHotkeyId, (int) KeyModifier.Shift, (int) Keys.D3);
            RegisterHotKey(Handle, RegionHotkeyId, (int) KeyModifier.Shift, (int) Keys.D2);

            CheckRun.Checked = _rkApp.GetValue("GrabMagic") != null;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == FullscreenHotkeyId)
            {
                Screenshot.CaptureFullScreen();
                BalloonForm.SuccesfullUploadBalloon();
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == RegionHotkeyId)
            {
                Hide();
                var form1 = new RegionForm(BalloonForm, this);
                form1.Show();
            }
            base.WndProc(ref m);
        }

        private void GrabMagic_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    BalloonForm.Visible = true;
                    Hide();
                    break;
                case FormWindowState.Normal:
                    BalloonForm.Visible = false;
                    break;
            }
        }
        
        private void RegionButton_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new RegionForm(BalloonForm, this);
            form1.Show();
            Thread.Sleep(100);
        }

        private void FullscreenScreenshotButton_Click(object sender, EventArgs e)
        {
            Screenshot.CaptureFullScreen();
            BalloonForm.SuccesfullUploadBalloon();
        }

        private void CheckRun_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckRun.Checked)
            {
                _rkApp.SetValue("GrabMagic", Application.ExecutablePath);
            }
            else
            {
                _rkApp.DeleteValue("GrabMagic", false);
            }
        }
    }
}