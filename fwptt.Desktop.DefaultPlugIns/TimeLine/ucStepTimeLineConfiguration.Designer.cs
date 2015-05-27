namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    partial class ucStepTimeLineConfiguration
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
            System.Windows.Forms.Label lblNumberOfThreads;
            System.Windows.Forms.Label lblInfo;
            this.txtNumberOfThreads = new System.Windows.Forms.TextBox();
            lblNumberOfThreads = new System.Windows.Forms.Label();
            lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumberOfThreads
            // 
            lblNumberOfThreads.Location = new System.Drawing.Point(-3, 40);
            lblNumberOfThreads.Name = "lblNumberOfThreads";
            lblNumberOfThreads.Size = new System.Drawing.Size(162, 14);
            lblNumberOfThreads.TabIndex = 10;
            lblNumberOfThreads.Text = "Number of Steps";
            // 
            // txtNumberOfThreads
            // 
            this.txtNumberOfThreads.Location = new System.Drawing.Point(165, 37);
            this.txtNumberOfThreads.Name = "txtNumberOfThreads";
            this.txtNumberOfThreads.Size = new System.Drawing.Size(68, 20);
            this.txtNumberOfThreads.TabIndex = 9;
            this.txtNumberOfThreads.Text = "10";
            // 
            // lblInfo
            // 
            lblInfo.Location = new System.Drawing.Point(-1, 4);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new System.Drawing.Size(411, 30);
            lblInfo.TabIndex = 11;
            lblInfo.Text = "When using this time line the test will be ran a specific number of times and eac" +
    "h test will start after the previous test finished running or errored out";
            // 
            // ucStepTimeLineConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(lblInfo);
            this.Controls.Add(this.txtNumberOfThreads);
            this.Controls.Add(lblNumberOfThreads);
            this.Name = "ucStepTimeLineConfiguration";
            this.Size = new System.Drawing.Size(418, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberOfThreads;
    }
}
