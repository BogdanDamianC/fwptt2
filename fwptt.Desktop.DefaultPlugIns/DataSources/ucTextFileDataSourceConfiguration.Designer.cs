﻿namespace fwptt.Desktop.DefaultPlugIns.DataSources
{
    partial class ucTextFileDataSourceConfiguration
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
            System.Windows.Forms.Label lblFilePath;
            System.Windows.Forms.Label lblDataSeparator;
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFilePath = new System.Windows.Forms.Button();
            this.cboDataSeparator = new System.Windows.Forms.ComboBox();
            lblFilePath = new System.Windows.Forms.Label();
            lblDataSeparator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(114, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(571, 20);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new System.Drawing.Point(3, 36);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new System.Drawing.Size(48, 13);
            lblFilePath.TabIndex = 1;
            lblFilePath.Text = "File Path";
            // 
            // btnSelectFilePath
            // 
            this.btnSelectFilePath.Location = new System.Drawing.Point(75, 33);
            this.btnSelectFilePath.Name = "btnSelectFilePath";
            this.btnSelectFilePath.Size = new System.Drawing.Size(33, 19);
            this.btnSelectFilePath.TabIndex = 2;
            this.btnSelectFilePath.Text = "...";
            this.btnSelectFilePath.UseVisualStyleBackColor = true;
            this.btnSelectFilePath.Click += new System.EventHandler(this.btnSelectFilePath_Click);
            // 
            // cboDataSeparator
            // 
            this.cboDataSeparator.FormattingEnabled = true;
            this.cboDataSeparator.Location = new System.Drawing.Point(114, 4);
            this.cboDataSeparator.Name = "cboDataSeparator";
            this.cboDataSeparator.Size = new System.Drawing.Size(327, 21);
            this.cboDataSeparator.TabIndex = 3;
            this.cboDataSeparator.TextChanged += new System.EventHandler(this.cboDataSeparator_TextChanged);
            // 
            // lblDataSeparator
            // 
            lblDataSeparator.AutoSize = true;
            lblDataSeparator.Location = new System.Drawing.Point(1, 11);
            lblDataSeparator.Name = "lblDataSeparator";
            lblDataSeparator.Size = new System.Drawing.Size(79, 13);
            lblDataSeparator.TabIndex = 4;
            lblDataSeparator.Text = "Data Separator";
            // 
            // ucTextFileDataSourceConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(lblDataSeparator);
            this.Controls.Add(this.cboDataSeparator);
            this.Controls.Add(this.btnSelectFilePath);
            this.Controls.Add(lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Name = "ucTextFileDataSourceConfiguration";
            this.Size = new System.Drawing.Size(700, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFilePath;
        private System.Windows.Forms.ComboBox cboDataSeparator;
    }
}
