namespace chat2._0.Sound
{
    partial class SoundRequest
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
            this.Receive = new System.Windows.Forms.Button();
            this.Reject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Receive
            // 
            this.Receive.Location = new System.Drawing.Point(55, 53);
            this.Receive.Name = "Receive";
            this.Receive.Size = new System.Drawing.Size(75, 23);
            this.Receive.TabIndex = 0;
            this.Receive.Text = "接受";
            this.Receive.UseVisualStyleBackColor = true;
            this.Receive.Click += new System.EventHandler(this.Receive_Click);
            // 
            // Reject
            // 
            this.Reject.Location = new System.Drawing.Point(55, 82);
            this.Reject.Name = "Reject";
            this.Reject.Size = new System.Drawing.Size(75, 23);
            this.Reject.TabIndex = 1;
            this.Reject.Text = "拒绝";
            this.Reject.UseVisualStyleBackColor = true;
            this.Reject.Click += new System.EventHandler(this.Reject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "对方向您放出语音请求";
            // 
            // SoundRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 138);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reject);
            this.Controls.Add(this.Receive);
            this.Name = "SoundRequest";
            this.Text = "语音通话";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Receive;
        private System.Windows.Forms.Button Reject;
        private System.Windows.Forms.Label label1;
    }
}