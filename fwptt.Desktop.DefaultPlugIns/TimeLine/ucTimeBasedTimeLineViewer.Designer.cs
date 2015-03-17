namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    partial class ucTimeBasedTimeLineViewer
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblCurrentExecutionThreads = new System.Windows.Forms.Label();
            this.lblMaxThreads = new System.Windows.Forms.Label();
            this.lblCurrentIteration = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 5);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 13);
            label1.TabIndex = 0;
            label1.Text = "Start";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(174, 5);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(26, 13);
            label3.TabIndex = 2;
            label3.Text = "End";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(426, 5);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(46, 13);
            label4.TabIndex = 4;
            label4.Text = "Threads";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(543, 5);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 13);
            label5.TabIndex = 6;
            label5.Text = "Max Threads";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(40, 5);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(103, 13);
            this.lblStartTime.TabIndex = 1;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(214, 5);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(103, 13);
            this.lblEndTime.TabIndex = 3;
            // 
            // lblCurrentExecutionThreads
            // 
            this.lblCurrentExecutionThreads.Location = new System.Drawing.Point(472, 5);
            this.lblCurrentExecutionThreads.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentExecutionThreads.Name = "lblCurrentExecutionThreads";
            this.lblCurrentExecutionThreads.Size = new System.Drawing.Size(51, 13);
            this.lblCurrentExecutionThreads.TabIndex = 5;
            // 
            // lblMaxThreads
            // 
            this.lblMaxThreads.Location = new System.Drawing.Point(617, 5);
            this.lblMaxThreads.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxThreads.Name = "lblMaxThreads";
            this.lblMaxThreads.Size = new System.Drawing.Size(51, 13);
            this.lblMaxThreads.TabIndex = 7;
            // 
            // lblCurrentIteration
            // 
            this.lblCurrentIteration.Location = new System.Drawing.Point(367, 5);
            this.lblCurrentIteration.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentIteration.Name = "lblCurrentIteration";
            this.lblCurrentIteration.Size = new System.Drawing.Size(51, 13);
            this.lblCurrentIteration.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(321, 5);
            label6.Margin = new System.Windows.Forms.Padding(0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 13);
            label6.TabIndex = 8;
            label6.Text = "Iteration";
            // 
            // ucTimeBasedTimeLineViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentIteration);
            this.Controls.Add(label6);
            this.Controls.Add(this.lblMaxThreads);
            this.Controls.Add(label5);
            this.Controls.Add(this.lblCurrentExecutionThreads);
            this.Controls.Add(label4);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(label3);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(label1);
            this.Name = "ucTimeBasedTimeLineViewer";
            this.Size = new System.Drawing.Size(660, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblCurrentExecutionThreads;
        private System.Windows.Forms.Label lblMaxThreads;
        private System.Windows.Forms.Label lblCurrentIteration;
    }
}
