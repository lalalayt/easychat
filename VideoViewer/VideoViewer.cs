using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMCS.Passive;
using OMCS.Passive.Video;
using OMCS.Passive.Audio;
using chat2._0.ServiceLogicPackage;

namespace chat2._0.VideoViewer
{
    public partial class VideoViewer : UserControl, IViewer
    {
        /// <summary>
        /// 手动挂断的时候触发
        /// </summary>
        public event ESBasic.CbGeneric CloseVideo;
        /// <summary>
        /// 网络原因，视频中止的时候触发
        /// </summary>
        public event ESBasic.CbGeneric OfflineCloseVideo;

        private object lockObject = new object();

        private string friendID;
        private string selfID;
        private IMultimediaManager multimediaManager;
        private FullScreenForm fullForm = new FullScreenForm();//全屏的视频窗口

        private bool? cameraConnect = null;//视频是否已经连接？
        private bool? microConnect = null; //音频是否已经连接？ 

        #region Camera
        /// <summary>
        /// 连接对方摄像头的连接器。
        /// </summary>
        public DynamicCameraConnector Camera
        {
            get { return this.dynamicCameraConnector_other; }
        }
        #endregion

        #region SelfCamera
        /// <summary>
        /// 连接自己摄像头的连接器。
        /// </summary>
        public DynamicCameraConnector SelfCamera
        {
            get { return this.dynamicCameraConnector_self; }
        }
        #endregion

        #region MicroPhone
        /// <summary>
        /// 连接对方麦克风的连接器。
        /// </summary>
        public MicrophoneConnector MicroPhone
        {
            get { return this.microphoneConnector1; }
        }
        #endregion

        #region VideoViewer
        public VideoViewer(string _selfID, string _friendID, bool showWaitingInfo, IMultimediaManager _multimediaManager)
        {
            InitializeComponent();
            this.fullForm.Visible = false;
            this.fullForm.BigPanel.MouseDoubleClick += new MouseEventHandler(BigPanel_MouseDoubleClick);
            this.fullForm.KeyDown += new KeyEventHandler(fullForm_KeyDown);
            this.label1.Visible = showWaitingInfo;

            this.multimediaManager = _multimediaManager;

            this.friendID = _friendID;
            this.selfID = _selfID;

            this.dynamicCameraConnector_other.ConnectEnded += new ESBasic.CbGeneric<OMCS.Passive.ConnectResult>(cameraConnector1_ConnectEnded);
            this.dynamicCameraConnector_other.Disconnected += new ESBasic.CbGeneric<OMCS.Passive.ConnectorDisconnectedType>(cameraConnector1_Disconnected);
            this.microphoneConnector1.ConnectEnded += new ESBasic.CbGeneric<OMCS.Passive.ConnectResult>(microphoneConnector1_ConnectEnded);
            this.microphoneConnector1.Disconnected += new ESBasic.CbGeneric<OMCS.Passive.ConnectorDisconnectedType>(microphoneConnector1_Disconnected);
            this.dynamicCameraConnector_self.ConnectEnded += new ESBasic.CbGeneric<OMCS.Passive.ConnectResult>(dynamicCameraConnector_self_ConnectEnded);

            this.dynamicCameraConnector_other.WaitOwnerOnlineSpanInSecs = 30;
            this.microphoneConnector1.WaitOwnerOnlineSpanInSecs = 30;
        }

        #endregion

        #region 设置视频图像在哪里显示
        private void SetSelfViewer()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric(this.SetSelfViewer));
            }
            else
            {
                this.dynamicCameraConnector_self.SetViewer(this.panel_smallCamera);
            }
        }
        private void SetOtherViewer()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric(this.SetOtherViewer));
            }
            else
            {
                this.dynamicCameraConnector_other.SetViewer(this.panel_bigCamera);
            }
        }
        #endregion

        #region connect start
        #region cameraConnector1_ConnectEnded
        void cameraConnector1_ConnectEnded(OMCS.Passive.ConnectResult connectResult)
        {
            this.cameraConnect = connectResult == ConnectResult.Succeed ? true : false;
            this.DealConnectResult();
        }
        #endregion
        #region microphoneConnector1_ConnectEnded
        void microphoneConnector1_ConnectEnded(OMCS.Passive.ConnectResult result)
        {
            this.microConnect = result == ConnectResult.Succeed ? true : false;
            if (this.microConnect.Value)
            {
                //音频连接成功的时候初始化 信号控件
                this.channelQualityDisplayer1.Initialize(this.friendID);
            }
            this.DealConnectResult();
        }
        #endregion
        #region DealConnectResult
        /// <summary>
        /// 当音频和视频有一个连接成功的时候，显示对方视频，去掉“正在建立连接的显示”。否则显示“建立连接失败”
        /// </summary>
        private void DealConnectResult()
        {
            lock (this.lockObject)
            {
                if (this.cameraConnect == null || this.microConnect == null)
                {
                    return;
                }
                if (!this.cameraConnect.Value && !this.microConnect.Value)
                {
                    this.ShowLableInfo("建立连接失败");
                }
                else
                {
                    this.ShowLableInfo("");

                    if (this.cameraConnect.Value)
                    {
                        this.SetOtherViewer();
                    }
                }

            }
        }
        #endregion
        #region dynamicCameraConnector_self_ConnectEnded
        void dynamicCameraConnector_self_ConnectEnded(OMCS.Passive.ConnectResult connectResult)
        {
            if (connectResult == OMCS.Passive.ConnectResult.Succeed)
            {
                this.SetSelfViewer();
            }
        }
        #endregion

        #endregion

        #region connect  stop
        void cameraConnector1_Disconnected(OMCS.Passive.ConnectorDisconnectedType disconnectedType)
        {
            this.cameraConnect = false;
            if (disconnectedType == ConnectorDisconnectedType.GuestOffline || disconnectedType == ConnectorDisconnectedType.OwnerOffline)
            {
                if (this.OfflineCloseVideo != null)
                {
                    this.OfflineCloseVideo();
                }
            }
        }

        void microphoneConnector1_Disconnected(OMCS.Passive.ConnectorDisconnectedType disconnectedType)
        {
            this.microConnect = false;
            if (disconnectedType == ConnectorDisconnectedType.GuestOffline || disconnectedType == ConnectorDisconnectedType.OwnerOffline)
            {
                if (this.OfflineCloseVideo != null)
                {
                    this.OfflineCloseVideo();
                }
            }
        }
        #endregion

        #region button_close_Click
        private void button_close_Click(object sender, EventArgs e)
        {
            try
            {
                this.button_close.Enabled = false;
                if (this.CloseVideo != null)
                {
                    this.CloseVideo.BeginInvoke(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion

        #region 双击视频，最大化视频窗口
        private void panel_bigCamera_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.fullForm.Visible = true;
                this.fullForm.Show();
                this.dynamicCameraConnector_other.SetViewer(this.fullForm.BigPanel);
                this.dynamicCameraConnector_self.SetViewer(this.fullForm.SmallPanel);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
        #endregion

        #region 全屏的时候，退出全屏
        /// <summary>
        /// 按ESC键退出全屏
        /// </summary>        
        void fullForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.ExitFullScreenForm();
            }
        }
        /// <summary>
        /// 双击鼠标左键退出全屏
        /// </summary>
        void BigPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ExitFullScreenForm();
        }
        private void ExitFullScreenForm()
        {
            this.dynamicCameraConnector_other.SetViewer(this.panel_bigCamera);
            this.dynamicCameraConnector_self.SetViewer(this.panel_smallCamera);
            this.fullForm.Visible = false;
        }
        #endregion

        #region 建立连接
        public void Connect()
        {
            this.ShowLableInfo("正在建立连接");
            this.dynamicCameraConnector_self.BeginConnect(this.selfID);
            this.dynamicCameraConnector_other.BeginConnect(this.friendID);
            this.microphoneConnector1.BeginConnect(this.friendID);
        }
        #endregion

        #region 断开连接
        private void DisConnect()
        {
            this.dynamicCameraConnector_other.Disconnect();
            this.dynamicCameraConnector_self.Disconnect();
            this.microphoneConnector1.Disconnect();
        }
        #endregion

        #region 显示状态信息
        private void ShowLableInfo(string info)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<string>(this.ShowLableInfo), info);
            }
            else
            {
                if (string.IsNullOrEmpty(info))
                {
                    this.label1.Visible = false;
                }
                else
                {
                    this.label1.Visible = true;
                    this.label1.Text = info;
                }
            }
        }
        #endregion

        #region 实现IViewer接口
        public void Close()
        {
            ESBasic.CbGeneric disConnect = new ESBasic.CbGeneric(this.DisConnect);
            disConnect.BeginInvoke(null, null);

            this.fullForm.Close();
            this.Dispose();
        }
        
        public ViewerType Type
        {
            get { return ViewerType.VideoView; }
        }
        #endregion
    }
}
