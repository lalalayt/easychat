namespace chat2._0
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pb_loginBG = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.La_setting = new System.Windows.Forms.Label();
            this.La_minimize = new System.Windows.Forms.Label();
            this.Bt_login = new System.Windows.Forms.Button();
            this.La_close = new System.Windows.Forms.Label();
            this.La_return = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Cms_setting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_loginBG)).BeginInit();
            this.panel2.SuspendLayout();
            this.Cms_setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 183);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(156, 180);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(190, 25);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(156, 205);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(190, 25);
            this.textBox2.TabIndex = 5;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码:";
            // 
            // Pb_loginBG
            // 
            this.Pb_loginBG.Image = ((System.Drawing.Image)(resources.GetObject("Pb_loginBG.Image")));
            this.Pb_loginBG.Location = new System.Drawing.Point(0, 0);
            this.Pb_loginBG.Margin = new System.Windows.Forms.Padding(2);
            this.Pb_loginBG.Name = "Pb_loginBG";
            this.Pb_loginBG.Size = new System.Drawing.Size(450, 152);
            this.Pb_loginBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pb_loginBG.TabIndex = 7;
            this.Pb_loginBG.TabStop = false;
            this.Pb_loginBG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pb_loginBG_MouseDown);
            this.Pb_loginBG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pb_loginBG_MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(350, 185);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "注册账号";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label6_MouseDown);
            this.label6.MouseEnter += new System.EventHandler(this.label6_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            this.label6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label6_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(249)))));
            this.panel2.Controls.Add(this.La_setting);
            this.panel2.Controls.Add(this.La_minimize);
            this.panel2.Controls.Add(this.Bt_login);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.La_close);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Pb_loginBG);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.La_return);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 328);
            this.panel2.TabIndex = 12;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // La_setting
            // 
            this.La_setting.AutoSize = true;
            this.La_setting.BackColor = System.Drawing.Color.Transparent;
            this.La_setting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_setting.ForeColor = System.Drawing.Color.White;
            this.La_setting.Location = new System.Drawing.Point(371, 4);
            this.La_setting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_setting.Name = "La_setting";
            this.La_setting.Size = new System.Drawing.Size(26, 21);
            this.La_setting.TabIndex = 18;
            this.La_setting.Text = "▼";
            this.La_setting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.La_setting_MouseClick);
            this.La_setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.La_setting_MouseDown);
            this.La_setting.MouseEnter += new System.EventHandler(this.La_setting_MouseEnter);
            this.La_setting.MouseLeave += new System.EventHandler(this.La_setting_MouseLeave);
            this.La_setting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.La_setting_MouseUp);
            // 
            // La_minimize
            // 
            this.La_minimize.AutoSize = true;
            this.La_minimize.BackColor = System.Drawing.Color.Transparent;
            this.La_minimize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_minimize.ForeColor = System.Drawing.Color.White;
            this.La_minimize.Location = new System.Drawing.Point(401, 4);
            this.La_minimize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_minimize.Name = "La_minimize";
            this.La_minimize.Size = new System.Drawing.Size(20, 21);
            this.La_minimize.TabIndex = 17;
            this.La_minimize.Text = "━";
            this.La_minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.La_minimize_MouseClick);
            this.La_minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.La_minimize_MouseDown);
            this.La_minimize.MouseEnter += new System.EventHandler(this.La_minimize_MouseEnter);
            this.La_minimize.MouseLeave += new System.EventHandler(this.La_minimize_MouseLeave);
            this.La_minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.La_minimize_MouseUp);
            // 
            // Bt_login
            // 
            this.Bt_login.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Bt_login.FlatAppearance.BorderSize = 0;
            this.Bt_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_login.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_login.ForeColor = System.Drawing.Color.White;
            this.Bt_login.Location = new System.Drawing.Point(107, 249);
            this.Bt_login.Name = "Bt_login";
            this.Bt_login.Size = new System.Drawing.Size(239, 30);
            this.Bt_login.TabIndex = 16;
            this.Bt_login.Text = "登录";
            this.Bt_login.UseVisualStyleBackColor = false;
            this.Bt_login.Click += new System.EventHandler(this.Bt_login_Click);
            // 
            // La_close
            // 
            this.La_close.AutoSize = true;
            this.La_close.BackColor = System.Drawing.Color.Transparent;
            this.La_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_close.ForeColor = System.Drawing.Color.White;
            this.La_close.Location = new System.Drawing.Point(425, 4);
            this.La_close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_close.Name = "La_close";
            this.La_close.Size = new System.Drawing.Size(23, 21);
            this.La_close.TabIndex = 11;
            this.La_close.Text = "✖";
            this.La_close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label4_MouseClick);
            this.La_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            this.La_close.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
            this.La_close.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
            this.La_close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label4_MouseUp);
            // 
            // La_return
            // 
            this.La_return.AutoSize = true;
            this.La_return.BackColor = System.Drawing.Color.Transparent;
            this.La_return.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_return.ForeColor = System.Drawing.Color.White;
            this.La_return.Location = new System.Drawing.Point(20, 297);
            this.La_return.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_return.Name = "La_return";
            this.La_return.Size = new System.Drawing.Size(32, 17);
            this.La_return.TabIndex = 12;
            this.La_return.Text = "返回";
            this.La_return.Visible = false;
            this.La_return.Click += new System.EventHandler(this.La_return_Click);
            this.La_return.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown);
            this.La_return.MouseEnter += new System.EventHandler(this.label5_MouseEnter);
            this.La_return.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            this.La_return.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label5_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(177, 226);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(168, 298);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "正在连接服务器......";
            // 
            // Cms_setting
            // 
            this.Cms_setting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Cms_setting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改服务器ToolStripMenuItem,
            this.版本信息ToolStripMenuItem});
            this.Cms_setting.Name = "Cms_setting";
            this.Cms_setting.Size = new System.Drawing.Size(137, 48);
            // 
            // 修改服务器ToolStripMenuItem
            // 
            this.修改服务器ToolStripMenuItem.Name = "修改服务器ToolStripMenuItem";
            this.修改服务器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.修改服务器ToolStripMenuItem.Text = "修改服务器";
            this.修改服务器ToolStripMenuItem.Click += new System.EventHandler(this.修改服务器ToolStripMenuItem_Click);
            // 
            // 版本信息ToolStripMenuItem
            // 
            this.版本信息ToolStripMenuItem.Name = "版本信息ToolStripMenuItem";
            this.版本信息ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.版本信息ToolStripMenuItem.Text = "版本信息";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(450, 328);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Pb_loginBG)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Cms_setting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Pb_loginBG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label La_close;
        private System.Windows.Forms.Button Bt_login;
        private System.Windows.Forms.ContextMenuStrip Cms_setting;
        private System.Windows.Forms.ToolStripMenuItem 修改服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本信息ToolStripMenuItem;
        private System.Windows.Forms.Label La_minimize;
        private System.Windows.Forms.Label La_setting;
        private System.Windows.Forms.Label La_return;
    }
}