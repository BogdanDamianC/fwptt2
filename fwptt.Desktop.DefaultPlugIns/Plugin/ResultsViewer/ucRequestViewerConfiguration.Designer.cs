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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblNumberOfThreads;
            this.txtRefreshTime = new System.Windows.Forms.NumericUpDown();
            this.txtMaxNumberOfRequests = new System.Windows.Forms.TextBox();
            this.txtMaxResponseSize = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblNumberOfThreads = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(5, 28);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(168, 16);
            label2.TabIndex = 28;
            label2.Text = "Refresh Interval in seconds";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(280, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(184, 16);
            label1.TabIndex = 27;
            label1.Text = "Max Number of recorded requests";
            // 
            // lblNumberOfThreads
            // 
            lblNumberOfThreads.Location = new System.Drawing.Point(5, 3);
            lblNumberOfThreads.Name = "lblNumberOfThreads";
            lblNumberOfThreads.Size = new System.Drawing.Size(144, 16);
            lblNumberOfThreads.TabIndex = 25;
            lblNumberOfThreads.Text = "Max response Size";
            // 
            // txtRefreshTime
            // 
            this.txtRefreshTime.Location = new System.Drawing.Point(174, 26);
            this.txtRefreshTime.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtRefreshTime.Minimum = new decimal(new int[] {
            1,
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
            // txtMaxNumberOfRequests
            // 
            this.txtMaxNumberOfRequests.Location = new System.Drawing.Point(464, 1);
            this.txtMaxNumberOfRequests.Name = "txtMaxNumberOfRequests";
            this.txtMaxNumberOfRequests.Size = new System.Drawing.Size(100, 20);
            this.txtMaxNumberOfRequests.TabIndex = 26;
            this.txtMaxNumberOfRequests.Text = "100";
            // 
            // txtMaxResponseSize
            // 
            this.txtMaxResponseSize.Location = new System.Drawing.Point(174, 1);
            this.txtMaxResponseSize.Name = "txtMaxResponseSize";
            this.txtMaxResponseSize.Size = new System.Drawing.Size(100, 20);
            this.txtMaxResponseSize.TabIndex = 24;
            this.txtMaxResponseSize.Text = "1000";
            // 
            // ucRequestViewerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRefreshTime);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtMaxNumberOfRequests);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtMaxResponseSize);
            this.Controls.Add(lblNumberOfThreads);
            this.Name = "ucRequestViewerConfiguration";
            this.Size = new System.Drawing.Size(611, 50);
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtRefreshTime;
        private System.Windows.Forms.TextBox txtMaxNumberOfRequests;
        private System.Windows.Forms.TextBox txtMaxResponseSize;
    }
}
