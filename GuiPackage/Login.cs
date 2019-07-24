using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using chat2._0.GuiPackage;

namespace chat2._0
{
    public partial class login : Form
    {
        WindowStyle WindowStyle = new WindowStyle();
        private Point mousePoint = new Point();//用于鼠标移动窗口
        private Point formLocation;//窗口位置
        bool isConnect = false;//判断是否连接上服务器
        public chat beginChat;//主界面窗口
        public login()
        {
            InitializeComponent();
            dataProcessing.setlogin(this);//提供后续数据接收与发送操作反馈结果的操作
            La_close.Parent = Pb_loginBG;
            La_minimize.Parent = Pb_loginBG;
            La_setting.Parent = Pb_loginBG;
        }

        //窗体初始化，并尝试连接服务器
        private void login_Load(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Region = WindowStyle.SetWindowRegion(Width, Height, 8);
            }
            else
            {
                this.Region = null;
            }

            if (!dataProcessing.beginWork("login"))
            {
                label7.Text = "连接服务器失败......";
            }
        }

        //设置连接状态
        public void setConnect(bool situation)
        {
            isConnect = situation;
        }

        //设置窗体底部label状态显示
        public void setFooterSituation(string s)
        {
            label7.BeginInvoke(new Action(() =>
            {
                label7.Text = s;
            }));
        }
        //显示消息框
        public void showMessagebox(string s)
        {
            MessageBox.Show(s);
        }

        //==========按钮点击事件==========
        //注册、登录或修改按钮
        private void Bt_login_Click(object sender, EventArgs e)
        {
            //修改服务器信息，并调用函数重新连接服务器
            if (Bt_login.Text == "修改")
            {
                dataProcessing.address(textBox1.Text.Trim(), int.Parse(textBox2.Text.Trim()));
                label7.Text = "正在重新连接服务器......";
                isConnect = false;
                dataProcessing.beginWork("login");
                La_return_Click(sender, e);
                MessageBox.Show("修改成功，请登录");
                return;
            }
            //判断是否连接上服务器，如果没有，则取消后面操作
            if (!isConnect)
            {
                MessageBox.Show("未连接到服务器,无法进行操作");
                return;
            }
            //用户名及密码不能为空
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                label8.Text = "请输入用户名及密码!";
                return;
            }
            //用户名及密码不能包含“$”，方便解析数据时的操作
            if (textBox1.Text.Contains('$') || textBox1.Text.Contains('$'))
            {
                MessageBox.Show("用户名或密码不能包含'$'");
                return;
            }
            //data[0]:用户名  data[1]:已加密的密码
            List<string> data = new List<string>();
            data.Add(textBox1.Text);//用户名
            //==============调用系统自带MD5函数进行加密====================
            byte[] result = Encoding.Default.GetBytes(textBox2.Text);    //textBox2为输入的密码
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            data.Add(BitConverter.ToString(output).Replace("-",""));//输出加密文本赋给data[1]

            //登录账号时发送的消息
            if (!dataProcessing.sendData(0, data))//登录情况
            {
                MessageBox.Show("发送数据时出现错误,发送失败.");
                return;
            }
            //==========接收服务器反馈信息==========
            string[] receiveData = dataProcessing.receiveData();
            if (receiveData == null)
            {
                MessageBox.Show("接收数据时出现错误.");
                return;
            }
            //登录时接收到的代码
            if (receiveData[1] == "WRONGPASSWORD")
            {
                MessageBox.Show("密码错误,请重新输入");
                dataProcessing.beginWork("login");
                return;
            }
            else if (receiveData[1] == "NAMEONLINE")
            {
                MessageBox.Show("该账号已登录，登录失败");
                return;
            }
            //登录成功
            else if (receiveData[1] == "SUCCESS")
            {
                dataProcessing.loginName = textBox1.Text.Trim();//设置登录的用户名字
                this.Visible = false;
                beginChat = new chat(textBox1.Text.Trim());
                beginChat.Visible = true;
            }
        }

        //右下角注册按钮
        private void label6_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.ShowDialog();
        }

        //点击修改服务的返回
        private void La_return_Click(object sender, EventArgs e)
        {
            La_return.Visible = false;
            Bt_login.Text = "登录";
            label1.Text = "账号:";
            label2.Text = "密码：";
            textBox1.Text = "";
            textBox2.Text = "";
            label6.Visible = true;
        }

        //退出程序
        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            System.Environment.Exit(0);//强制关闭所有窗口及线程
        }

        //最小化
        private void La_minimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //====================按钮样式(UI)=========================
        //退出程序按钮UI
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, Color.Black);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, Color.White);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 50, 90, 220);
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        //最小化UI
        private void La_minimize_MouseDown(object sender, MouseEventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }
        private void La_minimize_MouseEnter(object sender, EventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        private void La_minimize_MouseUp(object sender, MouseEventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        private void La_minimize_MouseLeave(object sender, EventArgs e)
        {
            La_minimize.ForeColor = Color.White;
        }

        //设置按钮
        private void La_setting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cms_setting.Show(getLocation().X + getSize().X, getLocation().Y);
            }
        }

        //获取当前窗体位置
        public Point getLocation()
        {
            return new Point(this.Location.X, this.Location.Y);
        }

        //获取当前窗体大小
        public Point getSize()//x:Width  y:Height
        {
            return new Point(this.Width, this.Height);
        }

        private void 修改服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            La_return.Visible = true;
            Bt_login.Text = "修改";
            label1.Text = "地址：";
            label2.Text = "端口：";
            textBox1.Text = "127.0.0.1";
            textBox2.Text = "8081";
            label6.Visible = false;
        }

        private void La_setting_MouseDown(object sender, MouseEventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }

        private void La_setting_MouseEnter(object sender, EventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }

        private void La_setting_MouseLeave(object sender, EventArgs e)
        {
            La_setting.ForeColor = Color.White;
        }

        private void La_setting_MouseUp(object sender, MouseEventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }

        //背面移动窗体事件
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }
        //右下角注册按钮事件
        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.FromArgb(100, 50, 90, 220);
        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(100, Color.White);
        }

        //忘记密码按钮事件
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            La_return.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            La_return.ForeColor = Color.FromArgb(100, Color.White);
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            La_return.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            La_return.ForeColor = Color.FromArgb(100, 50, 90, 220);
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Bt_login_Click(sender,e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Bt_login_Click(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
            }
        }

        private void Pb_loginBG_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint = Control.MousePosition;
            this.formLocation = this.Location;
        }

        private void Pb_loginBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(formLocation.X + Control.MousePosition.X - mousePoint.X, formLocation.Y + Control.MousePosition.Y - mousePoint.Y);
                this.Location = p;
            }
        }
    }
}
