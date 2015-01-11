namespace fwptt.Desktop.RequestPlayerPlugIns.TimeLine
{
    partial class ucTimeBasedTimeLine
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
            this.grpRampUpTime = new System.Windows.Forms.GroupBox();
            this.rdRampUpTimeNoRampUpTime = new System.Windows.Forms.RadioButton();
            this.txtRampUpSeconds = new System.Windows.Forms.TextBox();
            this.txtRampUpMinutes = new System.Windows.Forms.TextBox();
            this.rbRampUpTimeMinutesAndSeconds = new System.Windows.Forms.RadioButton();
            this.txtTimeBetweenRequests = new System.Windows.Forms.TextBox();
            this.txtNumberOfThreads = new System.Windows.Forms.TextBox();
            this.grpTimeBasedTimelineDuration = new System.Windows.Forms.GroupBox();
            this.txtDurationMinute = new System.Windows.Forms.TextBox();
            this.txtDurationHour = new System.Windows.Forms.TextBox();
            this.txtDurationNoOfSeconds = new System.Windows.Forms.TextBox();
            this.rbDurationHourAndMinutes = new System.Windows.Forms.RadioButton();
            this.rbDurationSeconds = new System.Windows.Forms.RadioButton();
            label3 = new System.Windows.Forms.Label();
            lblNumberOfThreads = new System.Windows.Forms.Label();
            this.grpRampUpTime.SuspendLayout();
            this.grpTimeBasedTimelineDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRampUpTime
            // 
            this.grpRampUpTime.Controls.Add(this.rdRampUpTimeNoRampUpTime);
            this.grpRampUpTime.Controls.Add(this.txtRampUpSeconds);
            this.grpRampUpTime.Controls.Add(this.txtRampUpMinutes);
            this.grpRampUpTime.Controls.Add(this.rbRampUpTimeMinutesAndSeconds);
            this.grpRampUpTime.Location = new System.Drawing.Point(3, 140);
            this.grpRampUpTime.Name = "grpRampUpTime";
            this.grpRampUpTime.Size = new System.Drawing.Size(479, 72);
            this.grpRampUpTime.TabIndex = 22;
            this.grpRampUpTime.TabStop = false;
            this.grpRampUpTime.Text = "Ramp up Time (the time the test will take to get from 0 to No of Threads)";
            // 
            // rdRampUpTimeNoRampUpTime
            // 
            this.rdRampUpTimeNoRampUpTime.Location = new System.Drawing.Point(13, 45);
            this.rdRampUpTimeNoRampUpTime.Name = "rdRampUpTimeNoRampUpTime";
            this.rdRampUpTimeNoRampUpTime.Size = new System.Drawing.Size(446, 24);
            this.rdRampUpTimeNoRampUpTime.TabIndex = 5;
            this.rdRampUpTimeNoRampUpTime.Text = "No Ramp Up Time (0 the test will start will all the users running in the same tim" +
    "e)";
            this.rdRampUpTimeNoRampUpTime.CheckedChanged += new System.EventHandler(this.rdRampUpTimeNoRampUpTime_CheckedChanged);
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
            // rbRampUpTimeMinutesAndSeconds
            // 
            this.rbRampUpTimeMinutesAndSeconds.Checked = true;
            this.rbRampUpTimeMinutesAndSeconds.Location = new System.Drawing.Point(13, 19);
            this.rbRampUpTimeMinutesAndSeconds.Name = "rbRampUpTimeMinutesAndSeconds";
            this.rbRampUpTimeMinutesAndSeconds.Size = new System.Drawing.Size(128, 24);
            this.rbRampUpTimeMinutesAndSeconds.TabIndex = 2;
            this.rbRampUpTimeMinutesAndSeconds.TabStop = true;
            this.rbRampUpTimeMinutesAndSeconds.Text = "Minutes and Seconds";
            this.rbRampUpTimeMinutesAndSeconds.CheckedChanged += new System.EventHandler(this.rbRampUpTimeMinutesAndSeconds_CheckedChanged);
            // 
            // txtTimeBetweenRequests
            // 
            this.txtTimeBetweenRequests.Location = new System.Drawing.Point(198, 109);
            this.txtTimeBetweenRequests.Name = "txtTimeBetweenRequests";
            this.txtTimeBetweenRequests.Size = new System.Drawing.Size(68, 20);
            this.txtTimeBetweenRequests.TabIndex = 21;
            this.txtTimeBetweenRequests.Text = "250";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(13, 109);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(177, 23);
            label3.TabIndex = 20;
            label3.Text = "Pause between requests(milisec)";
            // 
            // txtNumberOfThreads
            // 
            this.txtNumberOfThreads.Location = new System.Drawing.Point(198, 80);
            this.txtNumberOfThreads.Name = "txtNumberOfThreads";
            this.txtNumberOfThreads.Size = new System.Drawing.Size(68, 20);
            this.txtNumberOfThreads.TabIndex = 18;
            this.txtNumberOfThreads.Text = "10";
            // 
            // lblNumberOfThreads
            // 
            lblNumberOfThreads.Location = new System.Drawing.Point(13, 83);
            lblNumberOfThreads.Name = "lblNumberOfThreads";
            lblNumberOfThreads.Size = new System.Drawing.Size(187, 23);
            lblNumberOfThreads.TabIndex = 19;
            lblNumberOfThreads.Text = "Number Of Threads(concurrent users)";
            // 
            // grpTimeBasedTimelineDuration
            // 
            this.grpTimeBasedTimelineDuration.Controls.Add(this.txtDurationMinute);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.txtDurationHour);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.txtDurationNoOfSeconds);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.rbDurationHourAndMinutes);
            this.grpTimeBasedTimelineDuration.Controls.Add(this.rbDurationSeconds);
            this.grpTimeBasedTimelineDuration.Location = new System.Drawing.Point(3, 1);
            this.grpTimeBasedTimelineDuration.Name = "grpTimeBasedTimelineDuration";
            this.grpTimeBasedTimelineDuration.Size = new System.Drawing.Size(479, 69);
            this.grpTimeBasedTimelineDuration.TabIndex = 17;
            this.grpTimeBasedTimelineDuration.TabStop = false;
            this.grpTimeBasedTimelineDuration.Text = "Test Duration";
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
            // txtDurationNoOfSeconds
            // 
            this.txtDurationNoOfSeconds.Location = new System.Drawing.Point(141, 39);
            this.txtDurationNoOfSeconds.Name = "txtDurationNoOfSeconds";
            this.txtDurationNoOfSeconds.ReadOnly = true;
            this.txtDurationNoOfSeconds.Size = new System.Drawing.Size(150, 20);
            this.txtDurationNoOfSeconds.TabIndex = 1;
            // 
            // rbDurationHourAndMinutes
            // 
            this.rbDurationHourAndMinutes.Checked = true;
            this.rbDurationHourAndMinutes.Location = new System.Drawing.Point(13, 15);
            this.rbDurationHourAndMinutes.Name = "rbDurationHourAndMinutes";
            this.rbDurationHourAndMinutes.Size = new System.Drawing.Size(120, 24);
            this.rbDurationHourAndMinutes.TabIndex = 2;
            this.rbDurationHourAndMinutes.TabStop = true;
            this.rbDurationHourAndMinutes.Text = "Hours and Minutes";
            this.rbDurationHourAndMinutes.CheckedChanged += new System.EventHandler(this.rbDurationHourAndMinutes_CheckedChanged);
            // 
            // rbDurationSeconds
            // 
            this.rbDurationSeconds.Location = new System.Drawing.Point(13, 39);
            this.rbDurationSeconds.Name = "rbDurationSeconds";
            this.rbDurationSeconds.Size = new System.Drawing.Size(128, 24);
            this.rbDurationSeconds.TabIndex = 0;
            this.rbDurationSeconds.Text = "Number Of Seconds";
            this.rbDurationSeconds.CheckedChanged += new System.EventHandler(this.rbDurationSeconds_CheckedChanged);
            // 
            // ucTimeBasedTimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRampUpTime);
            this.Controls.Add(this.txtTimeBetweenRequests);
            this.Controls.Add(label3);
            this.Controls.Add(this.txtNumberOfThreads);
            this.Controls.Add(lblNumberOfThreads);
            this.Controls.Add(this.grpTimeBasedTimelineDuration);
            this.Name = "ucTimeBasedTimeLine";
            this.Size = new System.Drawing.Size(509, 220);
            this.grpRampUpTime.ResumeLayout(false);
            this.grpRampUpTime.PerformLayout();
            this.grpTimeBasedTimelineDuration.ResumeLayout(false);
            this.grpTimeBasedTimelineDuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRampUpTime;
        private System.Windows.Forms.RadioButton rdRampUpTimeNoRampUpTime;
        private System.Windows.Forms.TextBox txtRampUpSeconds;
        private System.Windows.Forms.TextBox txtRampUpMinutes;
        private System.Windows.Forms.RadioButton rbRampUpTimeMinutesAndSeconds;
        private System.Windows.Forms.TextBox txtTimeBetweenRequests;
        private System.Windows.Forms.TextBox txtNumberOfThreads;
        private System.Windows.Forms.GroupBox grpTimeBasedTimelineDuration;
        private System.Windows.Forms.TextBox txtDurationMinute;
        private System.Windows.Forms.TextBox txtDurationHour;
        private System.Windows.Forms.TextBox txtDurationNoOfSeconds;
        private System.Windows.Forms.RadioButton rbDurationHourAndMinutes;
        private System.Windows.Forms.RadioButton rbDurationSeconds;
    }
}
