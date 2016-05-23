using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsFormsApplication1;

namespace GrabMagicDesktop
{
    public partial class GrabMagic : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int FULLSCREEN_HOTKEY_ID = 1;

        public int ActiveUserId { get; set; }
        public Screenshot Screenshot { get; set; }
        public GrabMagic(int userId)
        {
            ActiveUserId = userId;
            InitializeComponent();
            Screenshot = new Screenshot();
            RegisterHotKey(Handle, FULLSCREEN_HOTKEY_ID, 0, (int)Keys.F5);
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == FULLSCREEN_HOTKEY_ID)
            {
                Screenshot.CaptureFullScreen(ActiveUserId);
                MessageBox.Show("Success");
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screenshot.CaptureFullScreen(ActiveUserId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new ShowPicture().Show();
        }
    }
}
