namespace chat2._0.VideoViewer
{
    partial class VideoConnection
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
            this.panel_plus = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel_plus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_plus
            // 
            this.panel_plus.Controls.Add(this.tabControl1);
            this.panel_plus.Location = new System.Drawing.Point(0, 0);
            this.panel_plus.Name = "panel_plus";
            this.panel_plus.Size = new System.Drawing.Size(222, 385);
            this.panel_plus.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(222, 385);
            this.tabControl1.TabIndex = 1;
            // 
            // VideoConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 385);
            this.ControlBox = false;
            this.Controls.Add(this.panel_plus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VideoConnection";
            this.Text = "视频窗口";
            this.panel_plus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_plus;
        private System.Windows.Forms.TabControl tabControl1;
    }
}