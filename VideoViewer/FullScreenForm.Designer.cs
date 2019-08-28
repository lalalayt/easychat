namespace chat2._0.VideoViewer
{
    partial class FullScreenForm
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
            this.panel_big = new chat2._0.VideoPanel();
            this.panel_small = new chat2._0.VideoPanel();
            this.SuspendLayout();
            // 
            // panel_big
            // 
            this.panel_big.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.panel_big.BackColor = System.Drawing.Color.Black;
            this.panel_big.Location = new System.Drawing.Point(12, 12);
            this.panel_big.Margin = new System.Windows.Forms.Padding(2);
            this.panel_big.Name = "panel_big";
            this.panel_big.Size = new System.Drawing.Size(572, 440);
            this.panel_big.TabIndex = 0;
            // 
            // panel_small
            // 
            this.panel_small.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_small.BackColor = System.Drawing.Color.Black;
            this.panel_small.Location = new System.Drawing.Point(464, 336);
            this.panel_small.Margin = new System.Windows.Forms.Padding(2);
            this.panel_small.Name = "panel_small";
            this.panel_small.Size = new System.Drawing.Size(120, 96);
            this.panel_small.TabIndex = 0;
            // 
            // FullScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.panel_small);
            this.Controls.Add(this.panel_big);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private VideoPanel panel_big;
        private VideoPanel panel_small;
    }
}