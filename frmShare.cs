using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cShare
{
    public partial class frmShare : Form
    {
        frmSelect frmArea;
        string curSaveLoc;

        public frmShare()
        {
            InitializeComponent();
            frmArea = new frmSelect();
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!frmArea.Visible)
            {
                frmArea.Show();
            }
            else
            {
                frmArea.Close();
                frmArea = new frmSelect();
            }
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            frmArea.Hide();
            Rectangle shotArea;
            Bitmap capture;
            Graphics Graph;
            shotArea = frmArea.Bounds;

            capture = new Bitmap(shotArea.Width, shotArea.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graph = Graphics.FromImage(capture);
            Graph.CopyFromScreen(shotArea.X, shotArea.Y, 0, 0, shotArea.Size, CopyPixelOperation.SourceCopy);

            imgCapBox.Image = capture;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(imgCapBox.Image != null)
            {
                //Has Image
                curSaveLoc = saveLocation();
                imgCapBox.Image.Save("C:\\Clippr\\Saves\\" + curSaveLoc + ".png", System.Drawing.Imaging.ImageFormat.Png);
                CleanUp();

            } else
            {
                //Is Empty
                String txtError = "Image Box is Empty!";
                MessageBox.Show(txtError);

            }
        }

        public String saveLocation()
        {
            String SaveLoc = Path.GetRandomFileName();
            return SaveLoc;
        }

        private void imgCapBox_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetImage(imgCapBox.Image);
        }

        public void CleanUp()
        {
            imgCapBox.Image = null;
            curSaveLoc = saveLocation();
            

        }

    }
}
