namespace chat2._0.GuiPackage
{
    partial class AddFriends
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFriends));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.La_close = new System.Windows.Forms.Label();
            this.La_minimize = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabControl();
            this.tpBaseSearch = new System.Windows.Forms.TabPage();
            this.pnlBaseCondition = new System.Windows.Forms.Panel();
            this.pnlBaseResult = new System.Windows.Forms.Panel();
            this.picBaseResult = new System.Windows.Forms.PictureBox();
            this.dgvBasicResult = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.us_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.us_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBaseResult = new System.Windows.Forms.Label();
            this.pnlSearchType = new System.Windows.Forms.Panel();
            this.rbtnDetailSearch = new System.Windows.Forms.RadioButton();
            this.gBaseCondition = new System.Windows.Forms.GroupBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.picBaseCondition = new System.Windows.Forms.PictureBox();
            this.lblBaseCondition = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tpBaseSearch.SuspendLayout();
            this.pnlBaseCondition.SuspendLayout();
            this.pnlBaseResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicResult)).BeginInit();
            this.pnlSearchType.SuspendLayout();
            this.gBaseCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.La_close);
            this.panel1.Controls.Add(this.La_minimize);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 26);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_AddFriend_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "查找联系人";
            // 
            // La_close
            // 
            this.La_close.AutoSize = true;
            this.La_close.BackColor = System.Drawing.Color.Transparent;
            this.La_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_close.ForeColor = System.Drawing.Color.White;
            this.La_close.Location = new System.Drawing.Point(440, 0);
            this.La_close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_close.Name = "La_close";
            this.La_close.Size = new System.Drawing.Size(23, 21);
            this.La_close.TabIndex = 20;
            this.La_close.Text = "✖";
            this.La_close.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // La_minimize
            // 
            this.La_minimize.AutoSize = true;
            this.La_minimize.BackColor = System.Drawing.Color.Transparent;
            this.La_minimize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_minimize.ForeColor = System.Drawing.Color.White;
            this.La_minimize.Location = new System.Drawing.Point(416, 0);
            this.La_minimize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_minimize.Name = "La_minimize";
            this.La_minimize.Size = new System.Drawing.Size(20, 21);
            this.La_minimize.TabIndex = 18;
            this.La_minimize.Text = "━";
            this.La_minimize.Click += new System.EventHandler(this.La_minimize_Click);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.tpBaseSearch);
            this.tabSearch.Location = new System.Drawing.Point(0, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.SelectedIndex = 0;
            this.tabSearch.Size = new System.Drawing.Size(463, 266);
            this.tabSearch.TabIndex = 22;
            // 
            // tpBaseSearch
            // 
            this.tpBaseSearch.BackColor = System.Drawing.Color.White;
            this.tpBaseSearch.Controls.Add(this.pnlBaseCondition);
            this.tpBaseSearch.ForeColor = System.Drawing.Color.Black;
            this.tpBaseSearch.Location = new System.Drawing.Point(4, 22);
            this.tpBaseSearch.Name = "tpBaseSearch";
            this.tpBaseSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpBaseSearch.Size = new System.Drawing.Size(455, 240);
            this.tpBaseSearch.TabIndex = 0;
            this.tpBaseSearch.Text = "基本查找";
            // 
            // pnlBaseCondition
            // 
            this.pnlBaseCondition.Controls.Add(this.pnlBaseResult);
            this.pnlBaseCondition.Controls.Add(this.pnlSearchType);
            this.pnlBaseCondition.Controls.Add(this.gBaseCondition);
            this.pnlBaseCondition.Controls.Add(this.picBaseCondition);
            this.pnlBaseCondition.Controls.Add(this.lblBaseCondition);
            this.pnlBaseCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlBaseCondition.Name = "pnlBaseCondition";
            this.pnlBaseCondition.Size = new System.Drawing.Size(452, 240);
            this.pnlBaseCondition.TabIndex = 4;
            // 
            // pnlBaseResult
            // 
            this.pnlBaseResult.Controls.Add(this.picBaseResult);
            this.pnlBaseResult.Controls.Add(this.dgvBasicResult);
            this.pnlBaseResult.Controls.Add(this.lblBaseResult);
            this.pnlBaseResult.Location = new System.Drawing.Point(17, 14);
            this.pnlBaseResult.Name = "pnlBaseResult";
            this.pnlBaseResult.Size = new System.Drawing.Size(432, 220);
            this.pnlBaseResult.TabIndex = 4;
            this.pnlBaseResult.Visible = false;
            // 
            // picBaseResult
            // 
            this.picBaseResult.Image = global::chat2._0.Properties.Resources.search;
            this.picBaseResult.Location = new System.Drawing.Point(36, 6);
            this.picBaseResult.Name = "picBaseResult";
            this.picBaseResult.Size = new System.Drawing.Size(17, 18);
            this.picBaseResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBaseResult.TabIndex = 4;
            this.picBaseResult.TabStop = false;
            // 
            // dgvBasicResult
            // 
            this.dgvBasicResult.AllowUserToAddRows = false;
            this.dgvBasicResult.AllowUserToDeleteRows = false;
            this.dgvBasicResult.AllowUserToResizeColumns = false;
            this.dgvBasicResult.AllowUserToResizeRows = false;
            this.dgvBasicResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasicResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvBasicResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBasicResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasicResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.us_name,
            this.us_email});
            this.dgvBasicResult.GridColor = System.Drawing.Color.White;
            this.dgvBasicResult.Location = new System.Drawing.Point(0, 37);
            this.dgvBasicResult.MultiSelect = false;
            this.dgvBasicResult.Name = "dgvBasicResult";
            this.dgvBasicResult.ReadOnly = true;
            this.dgvBasicResult.RowHeadersVisible = false;
            this.dgvBasicResult.RowTemplate.Height = 23;
            this.dgvBasicResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasicResult.Size = new System.Drawing.Size(429, 180);
            this.dgvBasicResult.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "us_id";
            this.id.HeaderText = "账号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // us_name
            // 
            this.us_name.DataPropertyName = "us_name";
            this.us_name.HeaderText = "昵称";
            this.us_name.Name = "us_name";
            this.us_name.ReadOnly = true;
            // 
            // us_email
            // 
            this.us_email.DataPropertyName = "us_email";
            this.us_email.HeaderText = "邮箱";
            this.us_email.Name = "us_email";
            this.us_email.ReadOnly = true;
            // 
            // lblBaseResult
            // 
            this.lblBaseResult.AutoSize = true;
            this.lblBaseResult.Location = new System.Drawing.Point(68, 12);
            this.lblBaseResult.Name = "lblBaseResult";
            this.lblBaseResult.Size = new System.Drawing.Size(137, 12);
            this.lblBaseResult.TabIndex = 3;
            this.lblBaseResult.Text = "以下是为您找到的结果：";
            // 
            // pnlSearchType
            // 
            this.pnlSearchType.Controls.Add(this.rbtnDetailSearch);
            this.pnlSearchType.Location = new System.Drawing.Point(70, 29);
            this.pnlSearchType.Name = "pnlSearchType";
            this.pnlSearchType.Size = new System.Drawing.Size(200, 23);
            this.pnlSearchType.TabIndex = 2;
            // 
            // rbtnDetailSearch
            // 
            this.rbtnDetailSearch.AutoSize = true;
            this.rbtnDetailSearch.Location = new System.Drawing.Point(3, 3);
            this.rbtnDetailSearch.Name = "rbtnDetailSearch";
            this.rbtnDetailSearch.Size = new System.Drawing.Size(71, 16);
            this.rbtnDetailSearch.TabIndex = 1;
            this.rbtnDetailSearch.Text = "精确查找";
            this.rbtnDetailSearch.UseVisualStyleBackColor = true;
            this.rbtnDetailSearch.CheckedChanged += new System.EventHandler(this.rbtnDetailSearch_CheckedChanged);
            // 
            // gBaseCondition
            // 
            this.gBaseCondition.Controls.Add(this.txtNickName);
            this.gBaseCondition.Controls.Add(this.lblNickName);
            this.gBaseCondition.Location = new System.Drawing.Point(17, 95);
            this.gBaseCondition.Name = "gBaseCondition";
            this.gBaseCondition.Size = new System.Drawing.Size(294, 82);
            this.gBaseCondition.TabIndex = 3;
            this.gBaseCondition.TabStop = false;
            this.gBaseCondition.Text = "精确查找条件";
            this.gBaseCondition.Visible = false;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(86, 36);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(159, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(11, 39);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(65, 12);
            this.lblNickName.TabIndex = 1;
            this.lblNickName.Text = "对方昵称：";
            // 
            // picBaseCondition
            // 
            this.picBaseCondition.Image = global::chat2._0.Properties.Resources.search;
            this.picBaseCondition.Location = new System.Drawing.Point(30, 8);
            this.picBaseCondition.Name = "picBaseCondition";
            this.picBaseCondition.Size = new System.Drawing.Size(17, 18);
            this.picBaseCondition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBaseCondition.TabIndex = 0;
            this.picBaseCondition.TabStop = false;
            // 
            // lblBaseCondition
            // 
            this.lblBaseCondition.AutoSize = true;
            this.lblBaseCondition.Location = new System.Drawing.Point(68, 14);
            this.lblBaseCondition.Name = "lblBaseCondition";
            this.lblBaseCondition.Size = new System.Drawing.Size(173, 12);
            this.lblBaseCondition.TabIndex = 1;
            this.lblBaseCondition.Text = "可以设置精确查询条件查找好友";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(203, 296);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 23);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "上一步";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.Location = new System.Drawing.Point(295, 296);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 23);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(388, 296);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(295, 296);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "加为好友";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 322);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabSearch);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFriends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFriends";
            this.Load += new System.EventHandler(this.AddFriends_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.tpBaseSearch.ResumeLayout(false);
            this.pnlBaseCondition.ResumeLayout(false);
            this.pnlBaseCondition.PerformLayout();
            this.pnlBaseResult.ResumeLayout(false);
            this.pnlBaseResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicResult)).EndInit();
            this.pnlSearchType.ResumeLayout(false);
            this.pnlSearchType.PerformLayout();
            this.gBaseCondition.ResumeLayout(false);
            this.gBaseCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseCondition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label La_close;
        private System.Windows.Forms.Label La_minimize;
        private System.Windows.Forms.TabControl tabSearch;
        private System.Windows.Forms.TabPage tpBaseSearch;
        private System.Windows.Forms.Panel pnlBaseCondition;
        private System.Windows.Forms.Panel pnlBaseResult;
        private System.Windows.Forms.PictureBox picBaseResult;
        private System.Windows.Forms.DataGridView dgvBasicResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn us_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn us_email;
        private System.Windows.Forms.Label lblBaseResult;
        private System.Windows.Forms.Panel pnlSearchType;
        private System.Windows.Forms.RadioButton rbtnDetailSearch;
        private System.Windows.Forms.GroupBox gBaseCondition;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.PictureBox picBaseCondition;
        private System.Windows.Forms.Label lblBaseCondition;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
    }
}