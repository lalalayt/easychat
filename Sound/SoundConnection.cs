using chat2._0.ServiceLogicPackage;
using OMCS.Passive;
using OMCS.Passive.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat2._0.Sound
{
    public partial class SoundConnection : Form
    {
        private string userName;//自己的用户名
        private string friendName;//朋友的用户名
        private IMultimediaManager multimediaManager = null;
        private bool? microConnect = null; //音频是否已经连接？ 

        #region MicroPhone
        /// <summary>
        /// 连接对方麦克风的连接器。
        /// </summary>
        public MicrophoneConnector MicroPhone
        {
            get { return this.microphoneConnector1; }
        }
        #endregion

        public SoundConnection() { }

        public SoundConnection(string userName, string friendName, IMultimediaManager _multimediaManager, bool showWaitingInfo)
        {
            InitializeComponent();
            this.label1.Visible = showWaitingInfo;
            this.userName = userName;
            this.friendName = friendName;
            this.multimediaManager = _multimediaManager;
            this.microphoneConnector1.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(microphoneConnector1_ConnectEnded);
            this.microphoneConnector1.Disconnected += new ESBasic.CbGeneric<ConnectorDisconnectedType>(microphoneConnector1_Disconnected);
            this.microphoneConnector1.WaitOwnerOnlineSpanInSecs = 20;
        }

        #region microphoneConnector1_ConnectEnded
        void microphoneConnector1_ConnectEnded(ConnectResult result)
        {
            this.microConnect = result == ConnectResult.Succeed ? true : false;
            if (microConnect.Value)
            {
                //音频连接成功的时候初始化 信号控件
                this.channelQualityDisplayer1.Initialize(this.friendName);
            }
            this.DealConnectResult();
        }
        #endregion

        #region DealConnectResult
        /// <summary>
        /// 当音频连接成功的时候，去掉“正在建立连接的显示”。否则显示“建立连接失败”
        /// </summary>
        private void DealConnectResult()
        {
            if (this.microConnect == null)
            {
                return;
            }
            if (!this.microConnect.Value)
            {
                this.ShowLableInfo("建立连接失败");
            }
            else
            {
                this.ShowLableInfo("");
            }
        }
        #endregion

        /// <summary>
        /// 网络断开，语音被动断开时候触发
        /// </summary>
        void microphoneConnector1_Disconnected(ConnectorDisconnectedType disconnectedType)
        {
            this.microConnect = false;
            if (disconnectedType == ConnectorDisconnectedType.GuestOffline || disconnectedType == ConnectorDisconnectedType.OwnerOffline)
            {
                try
                {
                    this.button_close.Enabled = false;
                    List<string> list = new List<string>();
                    list.Add(friendName);
                    list.Add(InformationTypes.CloseSound.ToString());
                    list.Add("网络原因，视频中断\n");
                    dataProcessing.sendData(24, list);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        /// <summary>
        /// 手动挂断的时候触发，断开连接，关闭语音窗
        /// </summary>    
        private void button_close_Click(object sender, EventArgs e)
        {
            try
            {
                this.button_close.Enabled = false;
                List<string> list = new List<string>();
                list.Add(friendName);
                list.Add(InformationTypes.CloseSound.ToString());
                list.Add("自己挂断了语音\n");
                dataProcessing.sendData(24, list);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 连接音频，连接 后 创建 ConsumerRecords
        /// </summary>
        public void ConnectSound()
        {

            if (this.multimediaManager.Available)
            {
                this.Connect();
            }
        }

        #region 建立连接
        public void Connect()
        {
            this.ShowLableInfo("正在建立连接");
            this.microphoneConnector1.BeginConnect(this.friendName);
        }
        #endregion

        #region 断开连接
        private void DisConnect()
        {
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

        /// <summary>
        /// 断开语音连接，关闭语音窗口
        /// </summary>
        ///<param name="informationType">通知对方关闭视频的类型，如果不需要通知对方，informationType 为-1</param>
        ///<param name="showMessage">显示的系统消息内容 ，如果不显示系统消息showMessage为""</param>        
        public void CloseVideoFunction(int informationType, string showMessage)
        {
            try
            {
                if (informationType > 0)
                {
                    //发送给对方
                    List<string> list = new List<string>();
                    list.Add(friendName);
                    list.Add(informationType.ToString());
                    list.Add("对方挂断了语音\n");
                    dataProcessing.sendData(25, list);
                }
                this.Close();
                //出动断开 对方到自己的连接
                this.multimediaManager.DisconnectGuest(friendName, OMCS.MultimediaDeviceType.Camera, false);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
