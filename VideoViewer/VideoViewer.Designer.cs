namespace chat2._0.VideoViewer
{
    partial class VideoViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoViewer));
            this.microphoneConnector1 = new OMCS.Passive.Audio.MicrophoneConnector(this.components);
            this.panel_bigCamera = new chat2._0.VideoPanel();
            this.panel_smallCamera = new chat2._0.VideoPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dynamicCameraConnector_other = new OMCS.Passive.Video.DynamicCameraConnector(this.components);
            this.dynamicCameraConnector_self = new OMCS.Passive.Video.DynamicCameraConnector(this.components);
            this.channelQualityDisplayer1 = new OMCS.Boost.Controls.ChannelQualityDisplayer();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // microphoneConnector1
            // 
            this.microphoneConnector1.Mute = false;
            this.microphoneConnector1.SpringReceivedEventWhenMute = false;
            this.microphoneConnector1.WaitOwnerOnlineSpanInSecs = 0;
            // 
            // panel_bigCamera
            // 
            this.panel_bigCamera.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panel_bigCamera, "panel_bigCamera");
            this.panel_bigCamera.Name = "panel_bigCamera";
            // 
            // panel_smallCamera
            // 
            resources.ApplyResources(this.panel_smallCamera, "panel_smallCamera");
            this.panel_smallCamera.BackColor = System.Drawing.Color.Black;
            this.panel_smallCamera.Name = "panel_smallCamera";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // dynamicCameraConnector_other
            // 
            this.dynamicCameraConnector_other.AutoSynchronizeVideoToAudio = true;
            this.dynamicCameraConnector_other.DisplayVideoParameters = false;
            this.dynamicCameraConnector_other.RotateAngle = OMCS.RotateAngle.R0;
            this.dynamicCameraConnector_other.VideoDrawMode = OMCS.Passive.VideoDrawMode.Fill;
            this.dynamicCameraConnector_other.WaitOwnerOnlineSpanInSecs = 0;
            // 
            // dynamicCameraConnector_self
            // 
            this.dynamicCameraConnector_self.AutoSynchronizeVideoToAudio = true;
            this.dynamicCameraConnector_self.DisplayVideoParameters = false;
            this.dynamicCameraConnector_self.RotateAngle = OMCS.RotateAngle.R0;
            this.dynamicCameraConnector_self.VideoDrawMode = OMCS.Passive.VideoDrawMode.Fill;
            this.dynamicCameraConnector_self.WaitOwnerOnlineSpanInSecs = 0;
            // 
            // channelQualityDisplayer1
            // 
            this.channelQualityDisplayer1.BackColor = System.Drawing.Color.Transparent;
            this.channelQualityDisplayer1.ColorBadSignal = System.Drawing.Color.Red;
            this.channelQualityDisplayer1.ColorNoSignal = System.Drawing.Color.Gray;
            this.channelQualityDisplayer1.ColorSignal = System.Drawing.Color.Green;
            resources.ApplyResources(this.channelQualityDisplayer1, "channelQualityDisplayer1");
            this.channelQualityDisplayer1.Name = "channelQualityDisplayer1";
            // 
            // button_close
            // 
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.button_close, "button_close");
            this.button_close.Name = "button_close";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // VideoViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_smallCamera);
            this.Controls.Add(this.panel_bigCamera);
            this.Controls.Add(this.channelQualityDisplayer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_close);
            this.Name = "VideoViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label1;
        private VideoPanel panel_bigCamera;
        private VideoPanel panel_smallCamera;
        private OMCS.Passive.Video.DynamicCameraConnector dynamicCameraConnector_other;
        private OMCS.Passive.Video.DynamicCameraConnector dynamicCameraConnector_self;
        private OMCS.Boost.Controls.ChannelQualityDisplayer channelQualityDisplayer1;
        private OMCS.Passive.Audio.MicrophoneConnector microphoneConnector1;
    }
}
