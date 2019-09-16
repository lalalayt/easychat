using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using chat2._0.GuiPackage;
using System.Data;
using System.IO;

//处理传输的数据(包括发送与接收)
namespace chat2._0
{
    static class dataProcessing
    {
        //连接服务器套接字
        private static Socket server;
        //服务器地址
        private static IPAddress IP = IPAddress.Parse("192.168.3.25");//服务器地址
        private static int port = 8081;//服务器端口号
        private static Remind remind = null;//提供一些公共方法
        private static AddFriends myFriend = null;//提供一些公共方法
        private static chat myChat = null;//提供一些公共方法
        private static login myLogin = null;
        public static string loginName;//记录登录用户Name
        //窗口初始化时初始化该静态成员
        public static void setRemind(Remind r)
        { remind = r; }
        public static void setFriend(AddFriends f)
        { myFriend = f; }
        public static void setChat(chat s)
        {myChat = s;}
        public static void setlogin(login l)
        {myLogin = l;}
        //修改服务器地址及端口号
        public static void address(string ip,int por)
        {
            IP = IPAddress.Parse(ip);
            port = por;
        }
        //发送数据（不同于服务端的sendData）
        public static bool sendData(int num, List<string> data)//对发送数据进行处理,num:数据类型;data:发送的数据
        {
            if (server == null) return false;
            string sendData = "";

            switch (num)
            {
                //登录时验证账号密码:
                //data[0]:账号    data[1]:密码
                case 0://格式:数据类型0$用户名$密码$
                    sendData = num.ToString() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //发送公共消息
                //data[0]:消息内容
                case 1://格式:数据类型1$sender$消息长度$消息内容$
                    sendData = num.ToString() + "$" + myChat.getUserName() +"$" + data[0] + "$";
                    break;
                //私聊
                //data[0]:receiver    data[1]:消息内容
                case 2://格式:数据类型2$sender$receiver$消息长度$消息内容$
                    sendData = num.ToString() + "$" + myChat.getUserName() +
                        "$" + data[0] + "$" + data[1] + "$";
                    break;
                //获取在线用户列表
                //data[0]:代码
                case 3://格式:数据类型3$代码("GETONLINE":获取在线用户列表)	
                    sendData = num.ToString() + "$";
                    break;
                case 4:
                    sendData = num.ToString() + "$" + data[0] + "$" + data[1] + "$" + data[2] + "$" + data[3] + "$";
                    break;
                case 5:
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                case 6:
                    myChat.addText("公共聊天室", data[1]+"已登录", null);
                    myChat.addListBox(data[1]);
                    break;
                case 7:
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                case 8:
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                case 10:
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                case 9:
                    sendData = num.ToString() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                case 13:
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                case 14:
                    sendData = num.ToString() + "$" + data[1] + "$";
                    break;
                case 15://格式:数据类型21$代码:获取在线用户列表	
                    sendData = num.ToString() + "$" + data[0] + "$";
                    break;
                //发送视频聊天请求
                case 16:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //接受视频
                case 17:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //拒绝视频
                case 18:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //挂断视频
                case 19:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //发送给自己的挂断视频消息
                case 20:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$";
                    break;
                //请求语音通话
                case 21:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //接受语音
                case 22:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //拒绝语音
                case 23:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$";
                    break;
                //发送给自己的挂断语音信息
                case 24:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$" + data[2] + "$";
                    break;
                //发送给别人的挂断语音信息
                case 25:
                    sendData = num.ToString() + "$" + myChat.getUserName() + "$" + data[0] + "$" + data[1] + "$" + data[2] + "$";
                    break;
                case 26:
                    sendData = num.ToString() + "$";
                    break;
                //发送文件
                case 27:
                    using (FileStream fsRead = new FileStream(data[1], FileMode.Open))
                    {
                        //在发送文件前先给好友发送文件的名字+扩展名，方便后面的保存操作
                        string fileName = Path.GetFileName(data[1]);
                        string fileExtension = Path.GetExtension(data[1]);
                        //将文件中的数据读到arrFile数据
                        byte[] arrFile = new byte[1024 * 1024 * 10];
                        int length = fsRead.Read(arrFile, 0, arrFile.Length);
                        sendData = "27$" + myChat.getUserName() + "$" + data[0] + "$" + fileExtension + "$" + myChat.getUserName() + "给你发送的文件为：" + fileName + "$";
                        byte[] sendMessage = Encoding.Default.GetBytes(sendData);
                        int size = sendMessage.Length;
                        byte[] arrFileSend = new byte[length + size];
                        Buffer.BlockCopy(sendMessage, 0, arrFileSend, 0, size);
                        //表示发送的是文件数据
                        Buffer.BlockCopy(arrFile, 0, arrFileSend, size, length);
                        server.Send(arrFileSend);
                    }
                    return true;
                case 404:
                    sendData = "404$";
                    break;
                default:
                    return false;
            }
            try
            {
                server.Send(Encoding.Default.GetBytes(sendData));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //对接收的数据进行处理
        public static string[] receiveData()
        {
            string[] data = null;
            if (server == null) return data;
            
            byte[] receiveByte = new byte[1024 * 1024 * 10];
            try
            {
                server.Receive(receiveByte);
            }
            catch (Exception)
            {
                data = null;
                return data;
            }
            string receiveString = Encoding.Default.GetString(receiveByte);
            //拆分消息
            data = receiveString.Split('$');
            //选择对应消息种类进行处理
            switch (data[0])
            {
                    //消息类型0:是否允许登录账号
                case "0":
                    //直接返回已分段的消息
                    break;
                case "1"://1$sender$textLength$text$
                    //string sender = data[1];
                    //int textLength = int.Parse(data[2]);
                    //string text = receiveString.Substring(receiveString.IndexOf('$', data[0].Length + data[1].Length + 2) + 1, textLength);
                    //string result = sender+"["+DateTime.Now.ToString()+"]\n"+text;
                    myChat.addText("公共聊天室", data[1], data[2]);
                    break;
                    //私聊
                case "2"://数据类型2$sender$receiver$消息长度$消息内容$
                    myChat.addText(data[1], data[1], data[3]);
                    break;
                case "3":
                    for (int i = 1; i < data.Length-1; i++)
                    {
                        myChat.addListBox(data[i]);
                    }
                    break;
                case "5":
                    myChat.addListBox(data[1]);
                    break;
                case "6":
                    myChat.delListBox(data[1]);
                    break;
                case "7":
                    myFriend.getUser(data[1]);
                    break;
                case "8":
                    myFriend.getUser2(data[1]);
                    break;
                case "9":
                    myFriend.row(data[1]);
                    break;
                case "11":
                    myChat.row(data[1], data[2]);
                    break;
                case "12":
                    remind.row(data[1]);
                    break;
                //视频聊天请求
                case "16":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //接受视频
                case "17":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //拒绝视频
                case "18":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //发送给别人的挂断视频消息
                case "19":
                    myChat.HandleInformation(null, data[3], null);
                    break;
                //发送给自己的挂断视频消息
                case "20":
                    myChat.videoClose(null, data[2]);
                    break;
                //请求语音通话
                case "21":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //接受语音
                case "22":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //拒绝语音
                case "23":
                    myChat.HandleInformation(data[1], data[3], null);
                    break;
                //发送给自己的挂断语音信息
                case "24":
                    myChat.HandleInformation(data[1], data[3], data[4]);
                    break;
                //挂断语音
                case "25":
                    myChat.HandleInformation(data[1], data[3], data[4]);
                    break;
                case "26":
                    myChat.soundButton();
                    break;
                //发送文件消息
                //case "27":
                //    myChat.addFileText(data[1], data[2]);
                //    break;
                //发送文件
                case "27":
                    myChat.receiveFile(data[1], data[3], data[4], receiveByte);
                    break;
                case "404":
                    sendData(404, null);
                    myChat.showMessageBox("您已被强制下线");
                    data = null;
                    break;
                default:
                    break;
            }
            return data;
        }
        //开始工作
        //login:新建后台线程连接服务端并修改界面状态 
        //chat:新建后台线程与服务端传输数据
        public static bool beginWork(string choice)
        {
            if (myChat == null && myLogin == null) return false;
            Thread thread = null;
            switch (choice)
            {
                case "login"://login
                    thread = new Thread(connectServer);
                    break;
                case "chat"://chat
                    thread = new Thread(Receive);
                    break;
                default:
                    return false;
            }
            thread.IsBackground = true;
            thread.Start();
            return true;
        }
        //连接服务端并修改界面状态
        private static void connectServer()
        {
            if (myLogin == null) return;
            try
            {
                server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                server.Connect(IP, port);
            }
            catch (SocketException)
            {
                myLogin.setConnect(false);
                myLogin.setFooterSituation("无法连接到服务器.");
                return;
            }
            myLogin.setConnect(true);
            myLogin.setFooterSituation("已连接到服务器,请进行操作.");
        }
        //与服务端传输数据，当receiveData返回值为null时，则跳出循环，停止接收数据
        private static void Receive()
        {
            if (myChat == null) return;
            while (true)
            {
                string[] data = dataProcessing.receiveData();
                if (data == null)
                {
                    myChat.setBreakSituation();
                    return;//404
                }
            }
        }

        /// <summary>
        /// String转DataSet
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataSet StringToDataSet(string str)
        {
            StringReader sr = new StringReader(str);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds;
        }
    }
}
