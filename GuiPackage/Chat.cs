﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Drawing2D;
using chat2._0.GuiPackage;

namespace chat2._0
{
    public partial class chat : Form
    {
        WindowStyle WindowStyle = new WindowStyle();
        public Dictionary<string, string> chatBuffer;//切换聊天对象时聊天记录缓存
        private string UIfile = "Gray";//指定主题颜色
        private Point mousePoint = new Point();//提供窗体移动点
        private Point formLocation;//窗口位置
        private string userName;//自己的用户名
        ImageList sendButton = null;//发送按钮的图片样式
        private int receiveRemind = 1;//查询是否是好友的受影响行数
        public static string sendName;//获取发给当前用户
        private int messageImageIndex = 0; //工具栏中的消息图标的索引
        //构造函数
        public chat(string userName)
        {
            InitializeComponent();
            dataProcessing.setChat(this);
            this.userName = userName;
        }
        private void chat_Load(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Normal)
            {
                Region = WindowStyle.SetWindowRegion(Width,Height,8);
            }
            else
            {
                this.Region = null;
            }

            sendButton = GrayButton;
            chatBuffer = new Dictionary<string, string>();
            chatBuffer.Add("公共聊天室","");
            //加载字体
            //路径             
            string path = ".\\myFont.ttf";
            Font f = null;
            Font chatFont = null;
            if (File.Exists(path))
            {
                //读取字体文件             
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(path);
                //实例化字体             
                f = new Font(pfc.Families[0], 15);
                chatFont = new Font(pfc.Families[0], 13);
            }
            else
            {
                f = new Font("黑体", 15);
                chatFont = new Font("黑体", 13);
            }
            //设置字体            
            label10.Font = f;
            label6.Font = f;
            label1.Font = f;
            label3.Font = f;
            label3.ForeColor = Color.Red;
            label7.Font = f;
            listBox1.Font = f;
            label7.Text = "当前用户 : "+userName;
            //调整各个控件位置
            label10.Parent = pictureBox2;
            label6.Parent = panel2;
            label10.Location = new Point(pictureBox2.Width/2 - label10.Width/2,pictureBox2.Height/2 - label10.Height/2);
            label6.Location = new Point(panel2.Width / 2 - label6.Width / 2, panel2.Height / 2 - label6.Height / 2);
            listBox1.SelectedIndex = 0;
            //开始监听端口进行通信
            if (!dataProcessing.beginWork("chat")) MessageBox.Show("与服务器通信失败");
            //获得在线用户列表
            dataProcessing.sendData(3, null);
        }

       

        public string getUserName()
        {
            return this.userName;
        }
        public void showMessageBox(string s)
        { MessageBox.Show(s); }
        //添加聊天内容
        public void addText(string location,string s)//location:对应窗口
        {
            listBox1.BeginInvoke(new Action(() =>
                {
                    if (listBox1.SelectedItem.ToString() == location)
                    {
                        richTextBox1.BeginInvoke(new Action(() =>
                        {
                            richTextBox1.AppendText(s);
                            richTextBox1.AppendText("\n");
                        }));
                    }
                    else
                    {
                        chatBuffer[location] += s;
                        chatBuffer[location] += "\n";
                    }
                }));
        }
        //添加在线列表（登录）
        public void addListBox(string s)
        {
            //拿出第一项单独判断
            if (listBox1.Items.Count == 0)
            {
                listBox1.BeginInvoke(new Action(() =>
                {
                    if (s == this.userName)
                    {
                        return;
                    }
                    listBox1.Items.Add(s);
                    chatBuffer.Add(s, "");
                }));
            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (s == listBox1.Items[i].ToString())
                    {
                        break;
                    }
                    else if (i == listBox1.Items.Count - 1)
                    {
                        listBox1.BeginInvoke(new Action(() =>
                        {
                            if (s == this.userName)
                            {
                                return;
                            }
                            listBox1.Items.Add(s);
                            chatBuffer.Add(s, "");
                        }));
                        break;
                    }
                }
            }
        }
        //删除在线列表（登出）
        public void delListBox(string s)
        {
            try
            {
                listBox1.BeginInvoke(new Action(() =>
                {
                    if (listBox1.SelectedItem.ToString() == s)
                    {
                        listBox1.SelectedIndex = 0;
                    }
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.Items[i].ToString() == s)
                        {
                            listBox1.Items.RemoveAt(i);
                            break;
                        }
                    }

                }));
                chatBuffer.Remove(s);
            }
            catch (Exception)
            {
                return;
            }
        }
        //设置连接中断情况
        public void setBreakSituation()
        {
            label3.BeginInvoke(new Action(() =>
            {
                label3.Text = "与服务器连接中断,请检查网络并重新启动该程序";
            }));
        }
        //刷新按钮样式
        private void refreshButton()
        {
            switch (UIfile)
            {
                case "Gray":
                    sendButton = GrayButton;
                    break;
                case "Blue":
                    sendButton = BlueButton;
                    break;
                case "Pink":
                    sendButton = PinkButton;
                    break;
                default:
                    sendButton = GrayButton;
                    break;
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
        //发送按钮点击
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(richTextBox2.Text.Trim() == "")
            {
                MessageBox.Show("发送内容不能为空");
                return;
            }
            List<string> data = new List<string>();
            data.Add(richTextBox2.Text);
            if (listBox1.SelectedItem.ToString() == "公共聊天室")
            {
                if (!dataProcessing.sendData(1, data))//消息类型1:发送到聊天室的消息
                {
                    MessageBox.Show("发送消息失败");
                    return;
                }
            }
            else
            {
                data = new List<string>(); 
                data.Add(listBox1.SelectedItem.ToString());//receiver
                data.Add(richTextBox2.Text);
                if (!dataProcessing.sendData(2, data))//消息类型2:私聊
                {
                    MessageBox.Show("发送消息失败");
                    return;
                }
            }
            richTextBox2.Text = "";
        }
        private void label10_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender,e);
        }
        //==========按钮UI事件==========
        //发送按钮
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = sendButton.Images[1];
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = sendButton.Images[0];
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = sendButton.Images[2];
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = sendButton.Images[1];
        }
        //发送标签（直接调用发送按钮事件）
        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2_MouseDown(sender, e);
        }
        private void label10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2_MouseEnter(sender, e);
        }
        private void label10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2_MouseLeave(sender, e);
        }
        private void label10_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2_MouseUp(sender, e);
        }
        //取消输入回车换行
        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
        //输入回车响应：发送消息
        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                pictureBox2_Click(sender,e);
            }
        }
        //设置消息框的消息一直处于文本尾
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //设置光标的位置到文本尾
            richTextBox1.Select(richTextBox1.TextLength, 0);
            //滚动到控件光标处
            richTextBox1.ScrollToCaret();
        }
        //设置主题颜色
        public void SetUI(string s)
        {
            switch (s)
            {
                case "灰色":
                    UIfile = "Gray";
                    this.BackColor = Color.FromArgb(255, 238, 238, 238);
                    panel1.BackColor = Color.FromArgb(255, 150, 150, 150);
                    panel2.BackColor = Color.FromArgb(255, 210, 210, 210);
                    panel3.BackColor = Color.FromArgb(255, 228, 228, 228);
                    richTextBox1.BackColor = Color.FromArgb(255, 217, 217, 217);
                    richTextBox2.BackColor = Color.FromArgb(255, 217, 217, 217);
                    listBox1.BackColor = Color.FromArgb(255, 150, 150, 150);
                    pictureBox2.Image = GrayButton.Images[0];
                    break;
                case "蓝色":
                    UIfile = "Blue";
                    this.BackColor = Color.FromArgb(255, 231, 238, 253);
                    panel1.BackColor = Color.FromArgb(255, 102, 147, 252);
                    panel2.BackColor = Color.FromArgb(255, 191, 209, 251);
                    panel3.BackColor = Color.FromArgb(255, 215, 227, 255);
                    richTextBox1.BackColor = Color.FromArgb(255, 201, 216, 253);
                    richTextBox2.BackColor = Color.FromArgb(255, 201, 216, 253);
                    listBox1.BackColor = Color.FromArgb(255, 102, 147, 252);
                    pictureBox2.Image = BlueButton.Images[0];
                    break;
                case "粉色":
                    UIfile = "Pink";
                    this.BackColor = Color.FromArgb(255, 253, 231, 231);
                    panel1.BackColor = Color.FromArgb(255, 253, 102, 102);
                    panel2.BackColor = Color.FromArgb(255, 251, 191, 191);
                    panel3.BackColor = Color.FromArgb(255, 255, 215, 215);
                    richTextBox1.BackColor = Color.FromArgb(255, 253, 201, 201);
                    richTextBox2.BackColor = Color.FromArgb(255, 253, 201, 201);
                    listBox1.BackColor = Color.FromArgb(255, 253, 102, 102);
                    pictureBox2.Image = PinkButton.Images[0];
                    break;
                default:
                    break; 
            }
            refreshButton();//刷新按钮样式
        }//设置颜色
        //右上角关闭按钮事件
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }
        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }
        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            dataProcessing.sendData(404,null);
            Application.Exit();
        }

        #region  设置

        #region  设置按钮鼠标样式
        //鼠标进入控件
        private void La_setting_MouseEnter(object sender, EventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        //鼠标离开控件
        private void La_setting_MouseLeave(object sender, EventArgs e)
        {
            La_setting.ForeColor = Color.White;
        }
        //鼠标按下控件
        private void La_setting_MouseDown(object sender, MouseEventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }
        //鼠标在控件释放
        private void La_setting_MouseUp(object sender, MouseEventArgs e)
        {
            La_setting.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        #endregion
          
        //设置点击时事件
        private void La_setting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cms_setting.Show(getLocation().X + getSize().X, getLocation().Y+panel1.Bottom);
            }
        }
        //设置下拉菜单功能

        private void 账号设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Myself myself = new Myself();
            myself.ShowDialog();
        }

        private void 灰色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIfile = "Gray";
            this.BackColor = Color.FromArgb(255, 238, 238, 238);
            panel1.BackColor = Color.FromArgb(255, 150, 150, 150);
            panel2.BackColor = Color.FromArgb(255, 210, 210, 210);
            panel3.BackColor = Color.FromArgb(255, 228, 228, 228);
            richTextBox1.BackColor = Color.FromArgb(255, 217, 217, 217);
            richTextBox2.BackColor = Color.FromArgb(255, 217, 217, 217);
            listBox1.BackColor = Color.FromArgb(255, 150, 150, 150);
            pictureBox2.Image = GrayButton.Images[0];
        }

        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIfile = "Blue";
            this.BackColor = Color.FromArgb(255, 231, 238, 253);
            panel1.BackColor = Color.FromArgb(255, 102, 147, 252);
            panel2.BackColor = Color.FromArgb(255, 191, 209, 251);
            panel3.BackColor = Color.FromArgb(255, 215, 227, 255);
            richTextBox1.BackColor = Color.FromArgb(255, 201, 216, 253);
            richTextBox2.BackColor = Color.FromArgb(255, 201, 216, 253);
            listBox1.BackColor = Color.FromArgb(255, 102, 147, 252);
            pictureBox2.Image = BlueButton.Images[0];
        }

        private void 粉色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIfile = "Pink";
            this.BackColor = Color.FromArgb(255, 253, 231, 231);
            panel1.BackColor = Color.FromArgb(255, 253, 102, 102);
            panel2.BackColor = Color.FromArgb(255, 251, 191, 191);
            panel3.BackColor = Color.FromArgb(255, 255, 215, 215);
            richTextBox1.BackColor = Color.FromArgb(255, 253, 201, 201);
            richTextBox2.BackColor = Color.FromArgb(255, 253, 201, 201);
            listBox1.BackColor = Color.FromArgb(255, 253, 102, 102);
            pictureBox2.Image = PinkButton.Images[0];
        }
        #endregion

        #region  窗口最小化

        #region  最小化按钮鼠标样式
        //鼠标进入控件
        private void La_minimize_MouseEnter(object sender, EventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        //鼠标离开控件
        private void La_minimize_MouseLeave(object sender, EventArgs e)
        {
            La_minimize.ForeColor = Color.White;
        }
        //鼠标按下控件
        private void La_minimize_MouseDown(object sender, MouseEventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 60, 60, 60);
        }
        //鼠标在控件释放
        private void La_minimize_MouseUp(object sender, MouseEventArgs e)
        {
            La_minimize.ForeColor = Color.FromArgb(100, 100, 100, 100);
        }
        #endregion

        //最小化点击时事件
        private void La_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataProcessing.sendData(404, null);
        }
        //选择聊天对象改变时
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string history = "\n--------------------------历史消息--------------------------\n";
            if (label6.Text == listBox1.SelectedItem.ToString())
            {
                return;
            }
            if (richTextBox1.Text.Contains(history))
            {
                richTextBox1.Text = richTextBox1.Text.Replace(history, "");
            }

            chatBuffer[label6.Text] = richTextBox1.Text + history;
            
            label6.Text = listBox1.SelectedItem.ToString();
            richTextBox1.Text = chatBuffer[label6.Text];
            chatBuffer[label6.Text] = "";
        }
        //顶部移动
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint = Control.MousePosition;
            this.formLocation = this.Location;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(formLocation.X + Control.MousePosition.X - mousePoint.X, formLocation.Y + Control.MousePosition.Y - mousePoint.Y);
                this.Location = p;
            }
        }
        //重置位置
        private void label6_TextChanged(object sender, EventArgs e)
        {
            label6.Location = new Point(panel2.Width / 2 - label6.Width / 2, panel2.Height / 2 - label6.Height / 2);
        }


        //显示查找好友窗体
        private void add_Friend_Click(object sender, EventArgs e)
        {
            AddFriends af = new AddFriends();//创建查找好友窗体对象
            af.Show();//显示查找好友窗体
        }

        //查询是否是好友的受影响行数s1,发送者账号s2
        public void row(string s1, string s2)
        {
            receiveRemind = int.Parse(s1);
            sendName = s2;
        }

        //添加好友消息，启动消息提醒定时器
        private void tmAddFriend_Tick(object sender, EventArgs e)
        {
            if (receiveRemind != 1)
            {
                messageImageIndex = messageImageIndex == 0 ? 1 : 0;//实时获取系统消息图像索引
                button1.Image = imageList1.Images[messageImageIndex];//工具栏中显示消息读取状态图像
                button1.Enabled = true;
            }
        }

        //显示请求好友消息窗体
        private void button1_Click(object sender, EventArgs e)
        {
            //tmAddFriend.Stop();//停止消息提醒定时器
            receiveRemind = 1;
            messageImageIndex = 0;//头像恢复正常
            //显示正常的系统消息提醒图标
            button1.Image = imageList1.Images[messageImageIndex];
            button1.Enabled = false;
            Remind frmRemind = new Remind();//创建系统消息窗体对象
            frmRemind.Show();//显示系统消息窗体
        }
    }
}
