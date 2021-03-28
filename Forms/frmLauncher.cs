using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace cShare
{

    public partial class frmLauncher : Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 1;

        public frmLauncher()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, (int)Keys.PrintScreen);

        }


        private void FrmLauncher_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
            niProcess.Visible = true;
            niProcess.ContextMenuStrip = new ContextMenuStrip();
            niProcess.ContextMenuStrip.Items.Add("Open", null, this.MenuItem1_Click);
            niProcess.ContextMenuStrip.Items.Add("Close", null, this.MenuItem2_Click);


        }


        void MenuItem1_Click(object sender, EventArgs e)
        {
            openShare();
        }

        void MenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openShare()
        {

            frmShare cfrmShare = new frmShare();
            cfrmShare.ShowDialog();

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // My hotkey has been typed

                // Do what you want here
                // ...
                openShare();
            }
            base.WndProc(ref m);
        }

        private void niProcess_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openShare();
        }
    }
}
