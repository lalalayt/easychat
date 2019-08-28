using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chat2._0.ServiceLogicPackage;

namespace chat2._0.VideoViewer
{
    public partial class VideoRequestViewer : UserControl,IViewer
    {
        /// <summary>
        /// 同意视频请求的时候触发
        /// </summary>
        public event ESBasic.CbGeneric ReceiveVideo;

        /// <summary>
        /// 拒绝视频请求的时候触发
        /// </summary>
        public event ESBasic.CbGeneric RejectVideo;

        public VideoRequestViewer()
        {
            InitializeComponent();
        }

        private void button_reject_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RejectVideo != null)
                {
                    this.RejectVideo();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ReceiveVideo != null)
                {
                    this.ReceiveVideo();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void Close()
        {
            this.Dispose();
        }

        public ViewerType Type
        {
            get { return ViewerType.VideoRequest; }
        }
    }
}
