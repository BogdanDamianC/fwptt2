namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    partial class ucRequestViewerConfiguration
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
            this.txtRefreshTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxNumberOfRequests = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxResponseSize = new System.Windows.Forms.TextBox();
            this.lblNumberOfThreads = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRefreshTime
            // 
            this.txtRefreshTime.Location = new System.Drawing.Point(140, 42);
            this.txtRefreshTime.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtRefreshTime.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtRefreshTime.Name = "txtRefreshTime";
            this.txtRefreshTime.Size = new System.Drawing.Size(100, 20);
            this.txtRefreshTime.TabIndex = 29;
            this.txtRefreshTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Refresh Interval in miliseconds";
            // 
            // txtMaxNumberOfRequests
            // 
            this.txtMaxNumberOfRequests.Location = new System.Drawing.Point(445, 12);
            this.txtMaxNumberOfRequests.Name = "txtMaxNumberOfRequests";
            this.txtMaxNumberOfRequests.Size = new System.Drawing.Size(100, 20);
            this.txtMaxNumberOfRequests.TabIndex = 26;
            this.txtMaxNumberOfRequests.Text = "100";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(266, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Max Number of recorded requests";
            // 
            // txtMaxResponseSize
            // 
            this.txtMaxResponseSize.Location = new System.Drawing.Point(140, 12);
            this.txtMaxResponseSize.Name = "txtMaxResponseSize";
            this.txtMaxResponseSize.Size = new System.Drawing.Size(100, 20);
            this.txtMaxResponseSize.TabIndex = 24;
            this.txtMaxResponseSize.Text = "1000";
            // 
            // lblNumberOfThreads
            // 
            this.lblNumberOfThreads.Location = new System.Drawing.Point(12, 12);
            this.lblNumberOfThreads.Name = "lblNumberOfThreads";
            this.lblNumberOfThreads.Size = new System.Drawing.Size(120, 23);
            this.lblNumberOfThreads.TabIndex = 25;
            this.lblNumberOfThreads.Text = "Max response Size";
            // 
            // ucRequestViewerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRefreshTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaxNumberOfRequests);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxResponseSize);
            this.Controls.Add(this.lblNumberOfThreads);
            this.Name = "ucRequestViewerConfiguration";
            this.Size = new System.Drawing.Size(568, 74);
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtRefreshTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxNumberOfRequests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxResponseSize;
        private System.Windows.Forms.Label lblNumberOfThreads;
    }
}
