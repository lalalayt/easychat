namespace chat2._0.Sound
{
    partial class SoundConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.microphoneConnector1 = new OMCS.Passive.Audio.MicrophoneConnector(this.components);
            this.channelQualityDisplayer1 = new OMCS.Boost.Controls.ChannelQualityDisplayer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "等待对方接受语音";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(59, 107);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "挂断";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // microphoneConnector1
            // 
            this.microphoneConnector1.Mute = false;
            this.microphoneConnector1.SpringReceivedEventWhenMute = false;
            this.microphoneConnector1.WaitOwnerOnlineSpanInSecs = 0;
            // 
            // channelQualityDisplayer1
            // 
            this.channelQualityDisplayer1.BackColor = System.Drawing.Color.Transparent;
            this.channelQualityDisplayer1.ColorBadSignal = System.Drawing.Color.Red;
            this.channelQualityDisplayer1.ColorNoSignal = System.Drawing.Color.Gray;
            this.channelQualityDisplayer1.ColorSignal = System.Drawing.Color.Green;
            this.channelQualityDisplayer1.Location = new System.Drawing.Point(78, 69);
            this.channelQualityDisplayer1.Margin = new System.Windows.Forms.Padding(4);
            this.channelQualityDisplayer1.MaximumSize = new System.Drawing.Size(35, 22);
            this.channelQualityDisplayer1.MinimumSize = new System.Drawing.Size(35, 22);
            this.channelQualityDisplayer1.Name = "channelQualityDisplayer1";
            this.channelQualityDisplayer1.Size = new System.Drawing.Size(35, 22);
            this.channelQualityDisplayer1.TabIndex = 8;
            // 
            // SoundConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 142);
            this.ControlBox = false;
            this.Controls.Add(this.channelQualityDisplayer1);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label1);
            this.Name = "SoundConnection";
            this.Text = "语音窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_close;
        private OMCS.Passive.Audio.MicrophoneConnector microphoneConnector1;
        private OMCS.Boost.Controls.ChannelQualityDisplayer channelQualityDisplayer1;
    }
}