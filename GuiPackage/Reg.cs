using chat2._0.ServiceLogicPackage;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace chat2._0.GuiPackage
{
    public partial class Reg : Form
    {
        WindowStyle WindowStyle = new WindowStyle();//窗口样式
        SendMessage sendMessage = new SendMessage();//消息发送

        private Point mousePoint = new Point();//提供窗体移动点
        private Point formLocation;//窗口位置
        
        public Reg()
        {
            InitializeComponent();
            Pb_head.Image = Image.FromFile(Application.StartupPath +"/../../Image\\head.jpg");
        }

        private void reg_Load(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Region = WindowStyle.SetWindowRegion(Width, Height, 8);
            }
            else
            {
                Region = null;
            }
        }

        //注册
        private void Bt_reg_Click(object sender, EventArgs e)
        {
            if (!getfrom()) return;
            string name = Tb_name.Text;
            string pass = Tb_password.Text;
            string repass = Tb_confirmpassword.Text;
            string mail = Tb_mail.Text;
            Image photo = Pb_head.Image;
            if (!sendMessage.RegUser(name, pass, mail, photo))
            {
                MessageBox.Show("发送数据时出现错误,发送失败.");
                return;
            }
            string[] receiveData = dataProcessing.receiveData();
            //注册时接收到的消息
            if (receiveData == null)
            {
                MessageBox.Show("接收数据时出现错误.");
                return;
            }
            else if (receiveData[1] == "REGISTERSUCCESS")
            {
                MessageBox.Show("账号注册成功,请登录");
                dataProcessing.beginWork("login");
                Close(); 
                return;
            }
        }

        //获取照片
        private void Pb_head_MouseClick(object sender, MouseEventArgs e)
        {
            string pathname = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "所有文件(*.*)|*.*";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    pathname = file.FileName;   //获得文件的绝对路径
                    Pb_head.Load(pathname);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool getfrom()
        {
            bool bo = true;

            string name = Tb_name.Text;
            string pass = Tb_password.Text;
            string repass = Tb_confirmpassword.Text;
            string mail = Tb_mail.Text;

            FromValidation fromValidation = new FromValidation();
            string str = fromValidation.val_name(name);
            if (!str.Equals("pass"))
            {
                La_errorname.Text = str;
                bo = false;
            }
            else La_errorname.Text = "";

            str = fromValidation.val_password(pass, repass);
            if (!str.Equals("pass"))
            {
                La_errorpass.Text = str;
                bo = false;
            }
            else La_errorpass.Text = "";

            str = fromValidation.val_mail(mail);
            if (!str.Equals("pass"))
            {
                La_errormail.Text = str;
                bo = false;
            }
            else La_errormail.Text = "";

            return bo;
        }

        //关闭页面
        private void La_close_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void La_close_MouseDown(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 50, 90, 220);
        }

        private void La_close_MouseEnter(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, Color.Red);
        }

        private void La_close_MouseLeave(object sender, EventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, Color.White);
        }

        private void La_close_MouseUp(object sender, MouseEventArgs e)
        {
            La_close.ForeColor = Color.FromArgb(100, 100, 180, 241);
        }

        //导航栏移动
        private void Pa_reg_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint = Control.MousePosition;
            this.formLocation = this.Location;
        }

        private void Pa_reg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(formLocation.X + Control.MousePosition.X - mousePoint.X, formLocation.Y + Control.MousePosition.Y - mousePoint.Y);
                this.Location = p;
            }
        }
    }
}
