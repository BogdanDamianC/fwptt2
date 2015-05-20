namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    partial class ucRequestCounterConfiguration
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
            System.Windows.Forms.Label lblCounterInfo;
            lblCounterInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCounterInfo
            // 
            lblCounterInfo.AutoSize = true;
            lblCounterInfo.Location = new System.Drawing.Point(0, 4);
            lblCounterInfo.Name = "lblCounterInfo";
            lblCounterInfo.Size = new System.Drawing.Size(371, 13);
            lblCounterInfo.TabIndex = 0;
            lblCounterInfo.Text = "Shows You a Chart  when the test is ran with the different counters of the test";
            // 
            // ucRequestCounterConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(lblCounterInfo);
            this.Name = "ucRequestCounterConfiguration";
            this.Size = new System.Drawing.Size(396, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
