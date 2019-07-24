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
    public partial class AddFriends : Form
    {
        private int num;//受影响行数
        private DataSet ds;
        private DataSet ds2;
        public AddFriends()
        {
            InitializeComponent();
            dataProcessing.setFriend(this);
        }

        //窗体加载事件
        private void AddFriends_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //获取并显示所有用户(除掉自己)
            string sql = "select us_id, us_name, us_email from account where us_name <>'" + dataProcessing.loginName + "'";
            list.Add(sql);
            dataProcessing.sendData(7, list);
            //指定DataGridView的数据源
            dgvBasicResult.DataSource = ds.Tables[0];
        }

        //获取并显示所有用户(除掉自己)
        public void getUser(string s)
        {
            ds = dataProcessing.StringToDataSet(s);
        }

        ///<summary>
        ///基本查找
        ///</summary>
        private void BasicSearch()
        {
            List<string> list = new List<string>();
            //查询语句的前半部分
            string sql = "select us_id,us_name,us_email from account";
            //精确查找
            if (rbtnDetailSearch.Checked == true)
            {
                if (txtNickName.Text.Trim() == "")
                {
                    MessageBox.Show("请输入查询条件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //按账号查找
                else
                {
                    sql += string.Format(" where us_name like '{0}'", txtNickName.Text.Trim());
                }
            }
            list.Add(sql);
            dataProcessing.sendData(10,list);
            Thread.Sleep(500);
            if (num > 0)
            {
                dataProcessing.sendData(8, list);
                Thread.Sleep(500);
                dgvBasicResult.DataSource = ds2.Tables[0];//填充DataSet
            }
            else
            {
                dataProcessing.sendData(8, list);
                Thread.Sleep(500);
                dgvBasicResult.DataSource = ds2.Tables;//填充DataSet
            }
            //设置控件可见的属性
            //调整显示结果的Panel的位置，让其和显示条件的Panel的位置相同
            pnlBaseResult.Location = pnlBaseCondition.Location;
            pnlBaseResult.Visible = true;//使显示结果的Panel可见
            btnSearch.Visible = false;//“查找”按钮不可见
            btnAdd.Visible = true;　　//“加为好友”按钮可见
            btnBack.Visible = true;   //“上一步”按钮可见
        }

        //获取并显示所有用户(除掉自己)
        public void getUser2(string s)
        {
            ds2 = dataProcessing.StringToDataSet(s);
        }

        //查找按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BasicSearch();
        }

        ///<summary>
        ///获得选中好友的name
        ///</summary>        
        private string GetSelectedFriendName()
        {
            string friendName = "";  //记录好友的账号
            if (dgvBasicResult.SelectedRows.Count == 0)//没有选中任何一行
            {
                MessageBox.Show("请选择一个好友！", "操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvBasicResult.SelectedRows[0].Cells[1] != null)//确保第二个单元格有值
            {
                //获得DataGridView中选中的行的第二个单元格的值
                friendName = dgvBasicResult.SelectedRows[0].Cells[1].Value.ToString();
            }
            return friendName;//返回选中的好友ID
        }

        //执行SQL语句之后受影响的行数
        public void row(string s)
        {
            num = int.Parse(s);
        }

        ///<summary>
        ///查找好友是否已被添加
        ///</summary>        
        private bool HasAdded(string FriendName)
        {
            List<string> list = new List<string>();
            //定义SQL语句
            string sql = "select count(*) from tb_Friend where HostName='" + dataProcessing.loginName + "' and FriendName='" + FriendName + "'";
            list.Add(sql);
            list.Add(dgvBasicResult.SelectedRows[0].Cells[1].Value.ToString());
            dataProcessing.sendData(9, list);
            Thread.Sleep(500);
            bool returnValue = num > 0 ? true : false;//判断好友是否已添加
            return returnValue;
        }



        //添加好友
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string friendName = GetSelectedFriendName();//获得选中的好友的name
            if (friendName == "")//是否有可添加的好友
            {
                MessageBox.Show("请选择一个好友！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dataProcessing.loginName == friendName)
            {
                MessageBox.Show("自己不能添加自己！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (HasAdded(friendName))  //判断好友是否已经被添加
            {
                MessageBox.Show("对方已经是您的好友，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("对方需要身份验证才可以被加为好友，已发出请求！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //隐藏与查找结果相关的控件
        private void tabSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;//隐藏基本查找容器
            btnAdd.Visible = false;//隐藏加为好友按钮
            btnBack.Visible = false;//隐藏上一步按钮
        }

        //精确查找单选按钮事件
        private void rbtnDetailSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDetailSearch.Checked == true)//如果精确查找单选按钮选中
            {
                gBaseCondition.Visible = true;//显示精确查找条件的容器
            }
            else
            {
                gBaseCondition.Visible = false;//隐藏精确查找条件的容器
            }
        }

        //上一步
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;//隐藏基本查找结果容器
            pnlBaseCondition.Visible = true;//显示基本查找条件容器
            btnBack.Visible = false;//隐藏上一步按钮
            btnSearch.Visible = true;
            btnAdd.Visible = false;//隐藏加为好友按钮
        }

        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        //最小化窗体
        private void La_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//最小化窗体
        }

        //拖动窗体
        private void Frm_AddFriend_MouseDown(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }
    }
}
