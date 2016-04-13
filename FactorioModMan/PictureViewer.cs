using System;
using System.Drawing;
using System.Windows.Forms;

namespace FactorioModMan
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        public Image ShownImage
        {
            private get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        private void PictureViewer_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}