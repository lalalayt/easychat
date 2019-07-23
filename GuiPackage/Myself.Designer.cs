namespace chat2._0
{
    partial class Myself
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
            this.Pb_myBG = new System.Windows.Forms.PictureBox();
            this.La_close = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_myBG)).BeginInit();
            this.SuspendLayout();
            // 
            // Pb_myBG
            // 
            this.Pb_myBG.Location = new System.Drawing.Point(0, 0);
            this.Pb_myBG.Name = "Pb_myBG";
            this.Pb_myBG.Size = new System.Drawing.Size(330, 200);
            this.Pb_myBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_myBG.TabIndex = 1;
            this.Pb_myBG.TabStop = false;
            this.Pb_myBG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pb_myBG_MouseDown);
            this.Pb_myBG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pb_myBG_MouseMove);
            // 
            // La_close
            // 
            this.La_close.AutoSize = true;
            this.La_close.BackColor = System.Drawing.Color.Transparent;
            this.La_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.La_close.ForeColor = System.Drawing.Color.White;
            this.La_close.Location = new System.Drawing.Point(295, 9);
            this.La_close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.La_close.Name = "La_close";
            this.La_close.Size = new System.Drawing.Size(24, 24);
            this.La_close.TabIndex = 12;
            this.La_close.Text = "X";
            this.La_close.Click += new System.EventHandler(this.La_close_Click);
            this.La_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.La_close_MouseDown);
            this.La_close.MouseEnter += new System.EventHandler(this.La_close_MouseEnter);
            this.La_close.MouseLeave += new System.EventHandler(this.La_close_MouseLeave);
            this.La_close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.La_close_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(235, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "CHAT";
            // 
            // Myself
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 450);
            this.Controls.Add(this.La_close);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Pb_myBG);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Myself";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Myself";
            this.Load += new System.EventHandler(this.Myself_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pb_myBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pb_myBG;
        private System.Windows.Forms.Label La_close;
        private System.Windows.Forms.Label label5;
    }
}