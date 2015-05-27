namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    partial class ucTimeBasedTimeLineConfiguration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label lblNumberOfThreads;
            this.lblInfo = new System.Windows.Forms.Label();
            this.grpRampUpTime = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRampUpSeconds = new System.Windows.Forms.TextBox();
            this.txtRampUpMinutes = new System.Windows.Forms.TextBox();
            this.txtTimeBetweenRequests = new System.Windows.Forms.TextBox();
            this.txtNumberOfThreads = new System.Windows.Forms.TextBox();
            this.grpTimeBasedTimelineDuration = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDurationMinute = new System.Windows.Forms.TextBox();
            this.txtDurationHour = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            lblNumberOfThreads = new System.Windows.Forms.Label();
            this.grpRampUpTime.SuspendLayout();
            this.grpTimeBasedTimelineDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(13, 176);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(207, 13);
            label3.TabIndex = 20;
            label3.Text = "Pause between requests(milisec)";
            // 
            // lblNumberOfThreads
            // 
            lblNumberOfThreads.Location = new System.Drawing.Point(13, 153);
            lblNumberOfThreads.Name = "lblNumberOfThreads";
            lblNumberOfThreads.Size = new System.Drawing.Size(207, 13);
            lblNumberOfThreads.TabIndex = 19;
            lblNumberOfThreads.Text = "Number Of Threads(concurrent users)";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(0, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(411, 99);
            this.lblInfo.TabIndex = 23;
            this.lblInfo.Text = "lblInfo";
            // 
            // grpRampUpTime
            // 
            this.grpRampUpTime.Controls.Add(this.label1);
            this.grpRampUpTime.Controls.Add(this.txtRampUpSeconds);
            this.grpRampUpTime.Controls.Add(this.txtRampUpMinutes);
            this.grpRampUpTime.Location = new System.Drawing.Point(3, 195);
            this.grpRampUpTime.Name = "grpRampUpTime";
            this.grpRampUpTime.Size = new System.Drawing.Size(394, 45);
            this.grpRampUpTime.TabIndex = 22;
            this.grpRampUpTime.TabStop = false;
            this.grpRampUpTime.Text = "Ramp up Time (the time the test will take to get from 0 to No of Threads)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minutes and Seconds";
            // 
            // txtRampUpSeconds
            // 
            this.txtRampUpSeconds.Location = new System.Drawing.Point(223, 19);
            this.txtRampUpSeconds.Name = "txtRampUpSeconds";
            this.txtRampUpSeconds.Size = new System.Drawing.Size(68, 20);
            this.txtRampUpSeconds.TabIndex = 4;
            // 
            // txtRampUpMinutes
            // 
            this.txtRampUpMinutes.Location = new System.Drawing.Point(141, 19);
            this.txtRampUpMinutes.Name = "txtRampUpMinutes";
            this.txtRampUpMinutes.Size = new System.Drawing.Size(76, 20);
            this.txtRampUpMinutes.TabIndex = 3;
            // 
            // txtTimeBetweenRequests
            // 
            this.txtTimeBetweenRequests.Location = new System.Drawing.Point(226, 172);
            this.txtTimeBetweenRequests.Name = "txtTimeBetweenRequests";
            this.txtTimeBetweenRequests.Size = new System.Drawing.Size(68, 20);
            this.txtTimeBetweenRequests.TabIndex = 21;
            this.txtTimeBetweenRequests.Text = "250";
            // 
            // txtNumberOfThreads
            // 
            this.txtNumberOfThreads.Location = new System.Drawing.Point(226, 149);
            this.txtNumberOfThreads.Name = "txtNumberOfThreads";
            this.txtNumberOfThreads.Size = new System.Drawing.Size(68, 20);
            this.txtNumberOfThreads.TabIndex = 18;
            this.txtNumberOfThreads.Text = "10";
            // 
            // grpTimeBasedTimelineDuration
            // 
            this.grpTimeBasedTimelineDuration.Controls.Add(this.label2);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.txtDurationMinute);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.txtDurationHour);
            this.grpTimeBasedTimelineDuration.Location = new System.Drawing.Point(3, 108);
            this.grpTimeBasedTimelineDuration.Name = "grpTimeBasedTimelineDuration";
            this.grpTimeBasedTimelineDuration.Size = new System.Drawing.Size(394, 41);
            this.grpTimeBasedTimelineDuration.TabIndex = 17;
            this.grpTimeBasedTimelineDuration.TabStop = false;
            this.grpTimeBasedTimelineDuration.Text = "Test Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hours and Minutes";
            // 
            // txtDurationMinute
            // 
            this.txtDurationMinute.Location = new System.Drawing.Point(223, 15);
            this.txtDurationMinute.Name = "txtDurationMinute";
            this.txtDurationMinute.Size = new System.Drawing.Size(68, 20);
            this.txtDurationMinute.TabIndex = 4;
            // 
            // txtDurationHour
            // 
            this.txtDurationHour.Location = new System.Drawing.Point(141, 15);
            this.txtDurationHour.Name = "txtDurationHour";
            this.txtDurationHour.Size = new System.Drawing.Size(76, 20);
            this.txtDurationHour.TabIndex = 3;
            // 
            // ucTimeBasedTimeLineConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grpRampUpTime);
            this.Controls.Add(this.txtTimeBetweenRequests);
            this.Controls.Add(label3);
            this.Controls.Add(this.txtNumberOfThreads);
            this.Controls.Add(lblNumberOfThreads);
            this.Controls.Add(this.grpTimeBasedTimelineDuration);
            this.Name = "ucTimeBasedTimeLineConfiguration";
            this.Size = new System.Drawing.Size(414, 247);
            this.Load += new System.EventHandler(this.ucTimeBasedTimeLine_Load);
            this.grpRampUpTime.ResumeLayout(false);
            this.grpRampUpTime.PerformLayout();
            this.grpTimeBasedTimelineDuration.ResumeLayout(false);
            this.grpTimeBasedTimelineDuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRampUpTime;
        private System.Windows.Forms.TextBox txtRampUpSeconds;
        private System.Windows.Forms.TextBox txtRampUpMinutes;
        private System.Windows.Forms.TextBox txtTimeBetweenRequests;
        private System.Windows.Forms.TextBox txtNumberOfThreads;
        private System.Windows.Forms.GroupBox grpTimeBasedTimelineDuration;
        private System.Windows.Forms.TextBox txtDurationMinute;
        private System.Windows.Forms.TextBox txtDurationHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo;
    }
}
