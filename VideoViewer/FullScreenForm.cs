using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat2._0.VideoViewer
{
    public partial class FullScreenForm : Form
    {
        public Control BigPanel
        {
            get { return this.panel_big; }
        }

        public Control SmallPanel
        {
            get { return this.panel_small; }
        }

        public FullScreenForm()
        {
            InitializeComponent();
            this.ComputePanelSize();
        }

        //计算显示面板的大小
        private void ComputePanelSize()
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            double panelPercent = 4.0 / 3;
            double formWidthHeightPercent = (double)this.Width / (double)this.Height;
            if (formWidthHeightPercent >= panelPercent)
            {
                this.panel_big.Height = this.Height;
                this.panel_big.Width = (int)(this.panel_big.Height * panelPercent);
                this.panel_big.Location = new Point((this.Width - this.panel_big.Width) / 2, 0);
            }
            else
            {
                this.panel_big.Width = this.Width;
                this.panel_big.Height = (int)((double)this.panel_big.Width / panelPercent);
                this.panel_big.Location = new Point(0, (this.Height - this.panel_big.Height) / 2);
            }
            this.panel_small.Height = (int)(this.panel_big.Height / 5);
            this.panel_small.Width = (int)(this.panel_small.Height * panelPercent);
            this.panel_small.Location = new Point(this.panel_big.Width - this.panel_small.Width, this.panel_big.Height - this.panel_small.Height);
        }
    }
}
