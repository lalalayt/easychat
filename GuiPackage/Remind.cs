using chat2._0.ServiceLogicPackage;
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

namespace chat2._0.GuiPackage
{
    public partial class Remind : Form
    {
        private int num;//受影响行数

        public Remind()
        {
            InitializeComponent();
            dataProcessing.setRemind(this);
        }

        private void Remind_Load(object sender, EventArgs e)
        {
            label2.Text = chat.sendName + "请求添加您为好友";//显示文本提示信息
            button1.Visible = true;//显示同意按钮                   
        }

        //同意
        private void btnAllow_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            string sql; 
            sql = "insert into tb_Friend (HostName, FriendName) values('" + chat.sendName + "','" + dataProcessing.loginName + "')";
            list.Add(sql);
            dataProcessing.sendData(13, list);
            Thread.Sleep(500);
            sql = "insert into tb_Friend (HostName, FriendName) values('" + dataProcessing.loginName + "','" + chat.sendName + "')";
            list.Add(sql);
            dataProcessing.sendData(14, list);
            //获得在线用户列表
            dataProcessing.sendData(3, null);
            Thread.Sleep(500);
            List<string> list2 = new List<string>();
            list2.Add(chat.sendName);
            dataProcessing.sendData(15, list2);
            this.Close();//关闭窗体
        }

        //执行查询SQL语句之后受影响的行数
        public void row(string s)
        {
            num = int.Parse(s);
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        //拖动窗体
        private void Remind_MouseDown(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
    }
}
