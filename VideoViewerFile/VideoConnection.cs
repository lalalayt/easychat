﻿using chat2._0.ServiceLogicPackage;
using ESBasic;
using OMCS.Passive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat2._0.VideoViewer
{
    public partial class VideoConnection : Form
    {
        private object lockObject = new object();
        private bool haveCloseVedio = false;
        private string userName;//自己的用户名
        private string friendName;//朋友的用户名
        private IMultimediaManager multimediaManager = null;
        private VideoViewer videoViewer;

        #region CurrentViewerType
        private IViewer currentViewer = null;
        public ViewerType CurrentViewerType
        {
            get
            {
                if (this.currentViewer != null)
                {
                    return this.currentViewer.Type;
                }
                return ViewerType.None;
            }
        }
        #endregion

        #region HaveVideo
        private bool haveVideo = false;
        public bool HaveVideo
        {
            get { return haveVideo; }
        }
        #endregion

        public VideoConnection() { }

        public VideoConnection(string userName, string friendName, IMultimediaManager _multimediaManager)
        {

            InitializeComponent();
            this.userName = userName;
            this.friendName = friendName;
            this.multimediaManager = _multimediaManager;
        }

        public void OpenVideoViewer(ViewerType viewerType, bool showWaitingInfo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<ViewerType, bool>(this.OpenVideoViewer), viewerType, showWaitingInfo);
            }
            else
            {
                this.haveCloseVedio = false;
                TabPage page;
                if (this.tabControl1.TabPages.Count == 0)
                {
                    page = new TabPage("视频");
                    this.tabControl1.TabPages.Add(page);
                }
                else
                {
                    page = this.tabControl1.TabPages[0];
                    (page.Controls[0] as IViewer).Close();
                    page.Controls.Clear();
                    this.Width = this.Width - this.panel_plus.Width;

                }
                switch (viewerType)
                {
                    case ViewerType.VideoRequest:
                        {
                            VideoRequestViewer videoRequestViewer = new VideoRequestViewer();
                            videoRequestViewer.Dock = System.Windows.Forms.DockStyle.Fill;
                            videoRequestViewer.ReceiveVideo += new CbGeneric(videoRequestViewer_ReceiveVideo);
                            videoRequestViewer.RejectVideo += new CbGeneric(videoRequestViewer_RejectVideo);
                            page.Controls.Add(videoRequestViewer);
                            this.currentViewer = videoRequestViewer;
                            this.panel_plus.Visible = true;
                            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                            this.Width = this.Width + 224 > screenWidth ? screenWidth : this.Width + 224;
                            this.panel_plus.Width = 224;
                            break;
                        }
                    case ViewerType.VideoView:
                        {
                            videoViewer = new VideoViewer(userName, friendName, showWaitingInfo, this.multimediaManager);
                            videoViewer.CloseVideo += new CbGeneric(videoViewer_CloseVideo);
                            videoViewer.OfflineCloseVideo += new CbGeneric(videoViewer_OfflineCloseVideo);

                            page.Controls.Add(videoViewer);
                            this.panel_plus.Visible = true;
                            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                            this.Width = this.Width + 346 > screenWidth ? screenWidth : this.Width + 346;
                            this.panel_plus.Width = 346;
                            this.currentViewer = videoViewer;
                            break;
                        }

                }
                this.haveVideo = true;
            }
        }

        //拒绝视频
        void videoRequestViewer_RejectVideo()
        {
            List<string> list = new List<string>();
            list.Add(friendName);
            list.Add(InformationTypes.VideoReject.ToString());
            dataProcessing.sendData(18, list);
            dataProcessing.sendData(28, null);
            //直接 关闭视频窗，无需通知对方，无需断开 视频连接 等
            this.CloseVideoViewer();
        }

        //接受视频
        void videoRequestViewer_ReceiveVideo()
        {
            List<string> list = new List<string>();
            list.Add(friendName);
            list.Add(InformationTypes.VideoReceive.ToString());
            dataProcessing.sendData(17, list);
            dataProcessing.sendData(28, null);
            this.OpenVideoViewer(ViewerType.VideoView, false);
            this.ConnectVideo();
        }

        /// <summary>
        /// 连接视频，音频，连接 后 创建 ConsumerRecords
        /// </summary>
        public void ConnectVideo()
        {
            if (this.currentViewer != null)
            {
                if (this.multimediaManager.Available)
                {
                    (this.currentViewer as VideoViewer).Connect();
                }
            }
        }

        /// <summary>
        /// 手动挂断的时候触发，断开连接，关闭视频窗
        /// </summary>      
        void videoViewer_CloseVideo()
        {
            this.CloseVideoFunction(InformationTypes.CloseVideo, "自己挂断了视频");
        }

        /// <summary>
        /// 网络断开，视频被动断开时候触发
        /// </summary>
        void videoViewer_OfflineCloseVideo()
        {
            this.CloseVideoFunction(InformationTypes.NetReasonCloseVideo, "网络原因，视频中断");
        }

        /// <summary>
        /// 断开视频连接，关闭视频窗口
        /// </summary>
        ///<param name="informationType">通知对方关闭视频的类型，如果不需要通知对方，informationType 为-1</param>
        ///<param name="showMessage">显示的系统消息内容 ，如果不显示系统消息showMessage为""</param>        
        public void CloseVideoFunction(int informationType, string showMessage)
        {
            lock (this.lockObject)
            {
                if (this.haveCloseVedio) return;
                this.haveCloseVedio = true;
            }
            try
            {
                if (informationType > 0)
                {
                    //发送给对方
                    List<string> list = new List<string>();
                    list.Add(friendName);
                    list.Add(informationType.ToString());
                    dataProcessing.sendData(19, list);
                    dataProcessing.sendData(28, null);
                }
                this.CloseVideoViewer();
                //出动断开 对方到自己的连接
                this.multimediaManager.DisconnectGuest(friendName, OMCS.MultimediaDeviceType.Camera, false);
                if (!string.IsNullOrEmpty(showMessage))
                {
                    List<string> list = new List<string>();
                    list.Add(showMessage);
                    dataProcessing.sendData(20, list);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 关闭视频窗口
        /// </summary>
        public void CloseVideoViewer()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new CbGeneric(this.CloseVideoViewer));
                }
                else
                {
                    if (this.currentViewer != null)
                    {
                        this.currentViewer.Close();
                        this.currentViewer = null;
                        this.tabControl1.TabPages.RemoveAt(0);
                    }
                    this.haveVideo = false;
                    this.panel_plus.Visible = false;
                    this.Width = this.Width - this.panel_plus.Width >= 400 ? this.Width - this.panel_plus.Width : 400;
                    this.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
