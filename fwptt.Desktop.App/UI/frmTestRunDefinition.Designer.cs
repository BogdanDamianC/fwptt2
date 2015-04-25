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
            System.Windows.Forms.Label lblTestDefinition;
            System.Windows.Forms.Label lblName;
            System.Windows.Forms.Label label1;
            this.cboTestDefinition = new System.Windows.Forms.ComboBox();
            this.txtTestRunName = new System.Windows.Forms.TextBox();
            this.cboTimeLines = new System.Windows.Forms.ComboBox();
            this.ckListPlugins = new System.Windows.Forms.CheckedListBox();
            this.grpTimeLine = new System.Windows.Forms.GroupBox();
            this.grpPlugins = new System.Windows.Forms.GroupBox();
            this.btnNewRun = new System.Windows.Forms.Button();
            this.cboDataSource = new System.Windows.Forms.ComboBox();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.accordionPlugins = new fwptt.Desktop.Util.AccordionControl();
            this.ucEditTestDefinitionValues = new fwptt.Desktop.App.UI.ucEditTestDefinitionValues();
            lblTestDefinition = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.grpTimeLine.SuspendLayout();
            this.grpPlugins.SuspendLayout();
            this.grpProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTestDefinition
            // 
            lblTestDefinition.AutoSize = true;
            lblTestDefinition.Location = new System.Drawing.Point(150, 7);
            lblTestDefinition.Name = "lblTestDefinition";
            lblTestDefinition.Size = new System.Drawing.Size(75, 13);
            lblTestDefinition.TabIndex = 12;
            lblTestDefinition.Text = "Test Definition";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(150, 34);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(82, 13);
            lblName.TabIndex = 9;
            lblName.Text = "Test Run Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(150, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 13);
            label1.TabIndex = 16;
            label1.Text = "Test Datasource";
            // 
            // cboTestDefinition
            // 
            this.cboTestDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTestDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestDefinition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTestDefinition.FormattingEnabled = true;
            this.cboTestDefinition.Location = new System.Drawing.Point(239, 4);
            this.cboTestDefinition.Name = "cboTestDefinition";
            this.cboTestDefinition.Size = new System.Drawing.Size(940, 21);
            this.cboTestDefinition.TabIndex = 11;
            // 
            // txtTestRunName
            // 
            this.txtTestRunName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestRunName.Location = new System.Drawing.Point(239, 34);
            this.txtTestRunName.Name = "txtTestRunName";
            this.txtTestRunName.Size = new System.Drawing.Size(940, 20);
            this.txtTestRunName.TabIndex = 10;
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
            this.cboTimeLines.Size = new System.Drawing.Size(586, 21);
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
            this.ckListPlugins.Size = new System.Drawing.Size(1153, 62);
            this.ckListPlugins.TabIndex = 0;
            // 
            // grpTimeLine
            // 
            this.grpTimeLine.Controls.Add(this.cboTimeLines);
            this.grpTimeLine.Location = new System.Drawing.Point(7, 88);
            this.grpTimeLine.Name = "grpTimeLine";
            this.grpTimeLine.Size = new System.Drawing.Size(598, 56);
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
            this.grpPlugins.Location = new System.Drawing.Point(7, 211);
            this.grpPlugins.Name = "grpPlugins";
            this.grpPlugins.Size = new System.Drawing.Size(1172, 120);
            this.grpPlugins.TabIndex = 13;
            this.grpPlugins.TabStop = false;
            this.grpPlugins.Text = "Plugins";
            // 
            // btnNewRun
            // 
            this.btnNewRun.Location = new System.Drawing.Point(14, 4);
            this.btnNewRun.Name = "btnNewRun";
            this.btnNewRun.Size = new System.Drawing.Size(109, 77);
            this.btnNewRun.TabIndex = 14;
            this.btnNewRun.Text = "New Run";
            this.btnNewRun.UseVisualStyleBackColor = true;
            this.btnNewRun.Click += new System.EventHandler(this.btnNewRun_Click);
            // 
            // cboDataSource
            // 
            this.cboDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDataSource.FormattingEnabled = true;
            this.cboDataSource.Location = new System.Drawing.Point(239, 60);
            this.cboDataSource.Name = "cboDataSource";
            this.cboDataSource.Size = new System.Drawing.Size(940, 21);
            this.cboDataSource.TabIndex = 15;
            // 
            // grpProperties
            // 
            this.grpProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProperties.Controls.Add(this.ucEditTestDefinitionValues);
            this.grpProperties.Location = new System.Drawing.Point(611, 88);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(568, 117);
            this.grpProperties.TabIndex = 17;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // accordionPlugins
            // 
            this.accordionPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accordionPlugins.KeepOnlyOneItemExpanded = true;
            this.accordionPlugins.Location = new System.Drawing.Point(7, 88);
            this.accordionPlugins.Name = "accordionPlugins";
            this.accordionPlugins.Size = new System.Drawing.Size(1152, 22);
            this.accordionPlugins.TabIndex = 1;
            this.accordionPlugins.Resize += new System.EventHandler(this.accordionPlugins_Resize);
            // 
            // ucEditTestDefinitionValues
            // 
            this.ucEditTestDefinitionValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditTestDefinitionValues.Location = new System.Drawing.Point(3, 16);
            this.ucEditTestDefinitionValues.Name = "ucEditTestDefinitionValues";
            this.ucEditTestDefinitionValues.Size = new System.Drawing.Size(562, 98);
            this.ucEditTestDefinitionValues.TabIndex = 0;
            // 
            // frmTestRunDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(15, 0);
            this.ClientSize = new System.Drawing.Size(1194, 444);
            this.Controls.Add(this.grpProperties);
            this.Controls.Add(label1);
            this.Controls.Add(this.cboDataSource);
            this.Controls.Add(this.btnNewRun);
            this.Controls.Add(this.grpPlugins);
            this.Controls.Add(lblTestDefinition);
            this.Controls.Add(this.grpTimeLine);
            this.Controls.Add(this.cboTestDefinition);
            this.Controls.Add(this.txtTestRunName);
            this.Controls.Add(lblName);
            this.Name = "frmTestRunDefinition";
            this.ShowInTaskbar = false;
            this.Text = "frmTestRunDefinition";
            this.grpTimeLine.ResumeLayout(false);
            this.grpPlugins.ResumeLayout(false);
            this.grpProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTestDefinition;
        private System.Windows.Forms.TextBox txtTestRunName;
        private System.Windows.Forms.ComboBox cboTimeLines;
        private System.Windows.Forms.CheckedListBox ckListPlugins;
        private System.Windows.Forms.GroupBox grpTimeLine;
        private System.Windows.Forms.GroupBox grpPlugins;
        private Util.AccordionControl accordionPlugins;
        private System.Windows.Forms.Button btnNewRun;
        private System.Windows.Forms.ComboBox cboDataSource;
        private System.Windows.Forms.GroupBox grpProperties;
        private ucEditTestDefinitionValues ucEditTestDefinitionValues;


    }
}