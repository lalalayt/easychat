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
        public Remind()
        {
            InitializeComponent();
            dataProcessing.setRemind(this);
            //初始化工作区大小
            Rectangle rect = Screen.GetWorkingArea(this);//创建一个当前窗口的对象
            this.Rect = new Rectangle(rect.Right - this.Width - 1, rect.Bottom - this.Height - 1, this.Width, this.Height);//为创建的对象创建工作区域
        }

        #region 定义标识窗体移动状态的枚举值
        protected enum FormState
        {
            Hide = 0,//隐藏窗体
            Display = 1,//显示窗体
            Displaying = 2,//显示窗体中
            Hiding = 3 //隐藏窗体中
        }
        #endregion

        #region 用属性标识当前状态
        protected FormState FormNowState
        {
            get { return this.InfoStyle; }   //返回窗体的当前状态
            set { this.InfoStyle = value; }  //设定窗体当前状态的值
        }
        #endregion

        private int num;//受影响行数
        private Rectangle Rect;//定义一个存储矩形框的数组
        private FormState InfoStyle = FormState.Hide;//定义变量为隐藏
        static private Remind dropDownForm = new Remind();//实例化当前窗体

        private void Remind_Load(object sender, EventArgs e)
        {
            //dataProcessing.beginWork3("remind");
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

        //关闭窗体
        public void pboxClose_Click(object sender, EventArgs e)
        {
            this.FormNowState = FormState.Hide;//设定当前窗体的状态为隐藏
        }

        //拖动窗体
        private void Remind_MouseDown(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
    }
}
