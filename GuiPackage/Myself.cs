using System;
using System.Drawing;
using System.Windows.Forms;

namespace chat2._0
{
    public partial class Myself : Form
    {
        WindowStyle WindowStyle = new WindowStyle();//窗口样式
        private Point mousePoint = new Point();//提供窗体移动点
        private Point formLocation;//窗口位置
        public Myself()
        {
            InitializeComponent();
            La_close.Parent = Pb_myBG;
            label5.Parent = Pb_myBG;
        }
         
        private void Myself_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Region = WindowStyle.SetWindowRegion(Width, Height, 8);
            }
            else
            {
                Region = null;
            }

            Pb_myBG.ImageLocation = @"E:\image\1.jpg";

            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(Pb_myBG.ClientRectangle);
            //Region region = new Region(gp);
            //Pb_myBG.Region = region;
            //gp.Dispose();
            //region.Dispose();
        }

        private void Pb_myBG_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint = Control.MousePosition;
            this.formLocation = this.Location;
        }

        private void Pb_myBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(formLocation.X + Control.MousePosition.X - mousePoint.X, formLocation.Y + Control.MousePosition.Y - mousePoint.Y);
                this.Location = p;
            }
        }


        private void La_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void La_close_MouseDown(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }

        private void La_close_MouseEnter(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }

        private void La_close_MouseLeave(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.White;
        }

        private void La_close_MouseUp(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
    }
}
