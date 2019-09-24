namespace chat2._0.VideoViewer
{
    partial class VideoRequestViewer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_reject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "对方向您发出视频请求";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(24, 82);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(105, 23);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "接  受";
            this.button_ok.UseVisualStyleBackColor = false;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_reject
            // 
            this.button_reject.FlatAppearance.BorderSize = 0;
            this.button_reject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_reject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_reject.Location = new System.Drawing.Point(24, 120);
            this.button_reject.Name = "button_reject";
            this.button_reject.Size = new System.Drawing.Size(105, 23);
            this.button_reject.TabIndex = 7;
            this.button_reject.Text = "拒  绝";
            this.button_reject.UseVisualStyleBackColor = false;
            this.button_reject.Click += new System.EventHandler(this.button_reject_Click);
            // 
            // VideoRequestViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_reject);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label1);
            this.Name = "VideoRequestViewer";
            this.Size = new System.Drawing.Size(156, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_reject;
    }
}
