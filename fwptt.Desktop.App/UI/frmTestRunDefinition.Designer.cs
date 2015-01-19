using fwptt.Desktop.Util;
namespace fwptt.Desktop.App.UI
{
    partial class frmTestRunDefinition
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTestDefinition = new System.Windows.Forms.Label();
            this.cboTestDefinition = new System.Windows.Forms.ComboBox();
            this.txtTestRunName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cboTimeLines = new System.Windows.Forms.ComboBox();
            this.ckListPlugins = new System.Windows.Forms.CheckedListBox();
            this.grpTimeLine = new System.Windows.Forms.GroupBox();
            this.grpPlugins = new System.Windows.Forms.GroupBox();
            this.accordionPlugins = new AccordionControl();
            this.grpTimeLine.SuspendLayout();
            this.grpPlugins.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestDefinition
            // 
            this.lblTestDefinition.AutoSize = true;
            this.lblTestDefinition.Location = new System.Drawing.Point(4, 7);
            this.lblTestDefinition.Name = "lblTestDefinition";
            this.lblTestDefinition.Size = new System.Drawing.Size(75, 13);
            this.lblTestDefinition.TabIndex = 12;
            this.lblTestDefinition.Text = "Test Definition";
            // 
            // cboTestDefinition
            // 
            this.cboTestDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTestDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestDefinition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTestDefinition.FormattingEnabled = true;
            this.cboTestDefinition.Location = new System.Drawing.Point(116, 4);
            this.cboTestDefinition.Name = "cboTestDefinition";
            this.cboTestDefinition.Size = new System.Drawing.Size(397, 21);
            this.cboTestDefinition.TabIndex = 11;
            // 
            // txtTestRunName
            // 
            this.txtTestRunName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestRunName.Location = new System.Drawing.Point(116, 34);
            this.txtTestRunName.Name = "txtTestRunName";
            this.txtTestRunName.Size = new System.Drawing.Size(397, 20);
            this.txtTestRunName.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Test Run Name";
            // 
            // cboTimeLines
            // 
            this.cboTimeLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeLines.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTimeLines.FormattingEnabled = true;
            this.cboTimeLines.Location = new System.Drawing.Point(6, 19);
            this.cboTimeLines.Name = "cboTimeLines";
            this.cboTimeLines.Size = new System.Drawing.Size(500, 21);
            this.cboTimeLines.TabIndex = 7;
            this.cboTimeLines.SelectedIndexChanged += new System.EventHandler(this.cboTimeLines_SelectedIndexChanged);
            // 
            // ckListPlugins
            // 
            this.ckListPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckListPlugins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ckListPlugins.CheckOnClick = true;
            this.ckListPlugins.FormattingEnabled = true;
            this.ckListPlugins.Location = new System.Drawing.Point(6, 19);
            this.ckListPlugins.Name = "ckListPlugins";
            this.ckListPlugins.Size = new System.Drawing.Size(493, 62);
            this.ckListPlugins.TabIndex = 0;
            // 
            // grpTimeLine
            // 
            this.grpTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimeLine.Controls.Add(this.cboTimeLines);
            this.grpTimeLine.Location = new System.Drawing.Point(7, 60);
            this.grpTimeLine.Name = "grpTimeLine";
            this.grpTimeLine.Size = new System.Drawing.Size(512, 56);
            this.grpTimeLine.TabIndex = 1;
            this.grpTimeLine.TabStop = false;
            this.grpTimeLine.Text = "Time Line";
            // 
            // grpPlugins
            // 
            this.grpPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPlugins.Controls.Add(this.accordionPlugins);
            this.grpPlugins.Controls.Add(this.ckListPlugins);
            this.grpPlugins.Location = new System.Drawing.Point(7, 122);
            this.grpPlugins.Name = "grpPlugins";
            this.grpPlugins.Size = new System.Drawing.Size(512, 120);
            this.grpPlugins.TabIndex = 13;
            this.grpPlugins.TabStop = false;
            this.grpPlugins.Text = "Plugins";
            // 
            // accordionPlugins
            // 
            this.accordionPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accordionPlugins.Location = new System.Drawing.Point(7, 88);
            this.accordionPlugins.Name = "accordionPlugins";
            this.accordionPlugins.Size = new System.Drawing.Size(492, 22);
            this.accordionPlugins.TabIndex = 1;
            this.accordionPlugins.Resize += new System.EventHandler(this.accordionPlugins_Resize);
            // 
            // frmTestRunDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(15, 0);
            this.ClientSize = new System.Drawing.Size(534, 329);
            this.Controls.Add(this.grpPlugins);
            this.Controls.Add(this.lblTestDefinition);
            this.Controls.Add(this.grpTimeLine);
            this.Controls.Add(this.cboTestDefinition);
            this.Controls.Add(this.txtTestRunName);
            this.Controls.Add(this.lblName);
            this.Name = "frmTestRunDefinition";
            this.ShowInTaskbar = false;
            this.Text = "frmTestRunDefinition";
            this.grpTimeLine.ResumeLayout(false);
            this.grpPlugins.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestDefinition;
        private System.Windows.Forms.ComboBox cboTestDefinition;
        private System.Windows.Forms.TextBox txtTestRunName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboTimeLines;
        private System.Windows.Forms.CheckedListBox ckListPlugins;
        private System.Windows.Forms.GroupBox grpTimeLine;
        private System.Windows.Forms.GroupBox grpPlugins;
        private Util.AccordionControl accordionPlugins;


    }
}