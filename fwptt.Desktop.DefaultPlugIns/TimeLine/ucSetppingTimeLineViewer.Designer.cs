namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    partial class ucSetppingTimeLineViewer
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
            this.components = new System.ComponentModel.Container();
            this.lblTimeLineInfo = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTimeLineInfo
            // 
            this.lblTimeLineInfo.AutoSize = true;
            this.lblTimeLineInfo.Location = new System.Drawing.Point(0, 0);
            this.lblTimeLineInfo.Name = "lblTimeLineInfo";
            this.lblTimeLineInfo.Size = new System.Drawing.Size(78, 13);
            this.lblTimeLineInfo.TabIndex = 0;
            this.lblTimeLineInfo.Text = "lblTimeLineInfo";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ucSetppingTimeLineViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTimeLineInfo);
            this.Name = "ucSetppingTimeLineViewer";
            this.Size = new System.Drawing.Size(413, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimeLineInfo;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
