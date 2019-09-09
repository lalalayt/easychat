using chat2._0.ServiceLogicPackage;
using OMCS.Passive;
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
    public partial class SoundRequest : Form
    {
        private IMultimediaManager multimediaManager = null;
        private string userName;//自己的用户名
        private string friendName;//朋友的用户名
        SoundConnection sound;
        public SoundRequest(string userName, string friendName, IMultimediaManager _multimediaManager)
        {
            InitializeComponent();
            this.userName = userName;
            this.friendName = friendName;
            this.multimediaManager = _multimediaManager;
        }

        //接受语音
        private void Receive_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(friendName);
            list.Add(InformationTypes.SoundReceive.ToString());
            dataProcessing.sendData(22, list);
            this.Close();
            sound = new SoundConnection(userName, friendName, multimediaManager, false);
            sound.Show();
            sound.ConnectSound();
        }

        //拒绝语音
        private void Reject_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(friendName);
            list.Add(InformationTypes.SoundReject.ToString());
            dataProcessing.sendData(23, list);
            //直接关闭语音窗，无需通知对方，无需断开语音连接等
            this.Close();
        }

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
                if (sound != null)
                {
                    sound.Close();
                }
                else
                {
                    this.Close();
                }
                //出动断开 对方到自己的连接
                this.multimediaManager.DisconnectGuest(friendName, OMCS.MultimediaDeviceType.Camera, false);
                if (!string.IsNullOrEmpty(showMessage))
                {
                    List<string> list = new List<string>();
                    list.Add(showMessage);
                    dataProcessing.sendData(25, list);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
