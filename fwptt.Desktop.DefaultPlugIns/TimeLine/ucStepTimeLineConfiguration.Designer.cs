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
            this.txtNumberOfThreads = new System.Windows.Forms.TextBox();
            lblNumberOfThreads = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumberOfThreads
            // 
            lblNumberOfThreads.Location = new System.Drawing.Point(4, 5);
            lblNumberOfThreads.Name = "lblNumberOfThreads";
            lblNumberOfThreads.Size = new System.Drawing.Size(162, 14);
            lblNumberOfThreads.TabIndex = 10;
            lblNumberOfThreads.Text = "Number of Steps";
            // 
            // txtNumberOfThreads
            // 
            this.txtNumberOfThreads.Location = new System.Drawing.Point(172, 2);
            this.txtNumberOfThreads.Name = "txtNumberOfThreads";
            this.txtNumberOfThreads.Size = new System.Drawing.Size(68, 20);
            this.txtNumberOfThreads.TabIndex = 9;
            this.txtNumberOfThreads.Text = "10";
            // 
            // ucStepTimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNumberOfThreads);
            this.Controls.Add(lblNumberOfThreads);
            this.Name = "ucStepTimeLine";
            this.Size = new System.Drawing.Size(418, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberOfThreads;
    }
}
