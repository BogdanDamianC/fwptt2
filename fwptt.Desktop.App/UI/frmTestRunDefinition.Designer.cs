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
            this.grpCommonProperties = new System.Windows.Forms.GroupBox();
            this.lblTestDefinition = new System.Windows.Forms.Label();
            this.cboTestDefinition = new System.Windows.Forms.ComboBox();
            this.txtTestRunName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTimeLineType = new System.Windows.Forms.Label();
            this.cboTimeLines = new System.Windows.Forms.ComboBox();
            this.pluginsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ckListPlugins = new System.Windows.Forms.CheckedListBox();
            this.grpCommonProperties.SuspendLayout();
            this.pluginsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCommonProperties
            // 
            this.grpCommonProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCommonProperties.Controls.Add(this.lblTestDefinition);
            this.grpCommonProperties.Controls.Add(this.cboTestDefinition);
            this.grpCommonProperties.Controls.Add(this.txtTestRunName);
            this.grpCommonProperties.Controls.Add(this.lblName);
            this.grpCommonProperties.Controls.Add(this.lblTimeLineType);
            this.grpCommonProperties.Controls.Add(this.cboTimeLines);
            this.grpCommonProperties.Location = new System.Drawing.Point(12, 12);
            this.grpCommonProperties.Name = "grpCommonProperties";
            this.grpCommonProperties.Size = new System.Drawing.Size(831, 115);
            this.grpCommonProperties.TabIndex = 0;
            this.grpCommonProperties.TabStop = false;
            this.grpCommonProperties.Text = "Common Properties";
            // 
            // lblTestDefinition
            // 
            this.lblTestDefinition.AutoSize = true;
            this.lblTestDefinition.Location = new System.Drawing.Point(2, 57);
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
            this.cboTestDefinition.Location = new System.Drawing.Point(114, 54);
            this.cboTestDefinition.Name = "cboTestDefinition";
            this.cboTestDefinition.Size = new System.Drawing.Size(701, 21);
            this.cboTestDefinition.TabIndex = 11;
            // 
            // txtTestRunName
            // 
            this.txtTestRunName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestRunName.Location = new System.Drawing.Point(114, 27);
            this.txtTestRunName.Name = "txtTestRunName";
            this.txtTestRunName.Size = new System.Drawing.Size(701, 20);
            this.txtTestRunName.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Test Run Name";
            // 
            // lblTimeLineType
            // 
            this.lblTimeLineType.AutoSize = true;
            this.lblTimeLineType.Location = new System.Drawing.Point(4, 84);
            this.lblTimeLineType.Name = "lblTimeLineType";
            this.lblTimeLineType.Size = new System.Drawing.Size(53, 13);
            this.lblTimeLineType.TabIndex = 8;
            this.lblTimeLineType.Text = "Time Line";
            // 
            // cboTimeLines
            // 
            this.cboTimeLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeLines.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTimeLines.FormattingEnabled = true;
            this.cboTimeLines.Location = new System.Drawing.Point(114, 81);
            this.cboTimeLines.Name = "cboTimeLines";
            this.cboTimeLines.Size = new System.Drawing.Size(701, 21);
            this.cboTimeLines.TabIndex = 7;
            this.cboTimeLines.SelectedIndexChanged += new System.EventHandler(this.cboTimeLines_SelectedIndexChanged);
            // 
            // pluginsPanel
            // 
            this.pluginsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginsPanel.ColumnCount = 1;
            this.pluginsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pluginsPanel.Controls.Add(this.ckListPlugins, 0, 1);
            this.pluginsPanel.Location = new System.Drawing.Point(17, 133);
            this.pluginsPanel.Name = "pluginsPanel";
            this.pluginsPanel.RowCount = 2;
            this.pluginsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pluginsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pluginsPanel.Size = new System.Drawing.Size(826, 283);
            this.pluginsPanel.TabIndex = 1;
            // 
            // ckListPlugins
            // 
            this.ckListPlugins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ckListPlugins.CheckOnClick = true;
            this.ckListPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckListPlugins.FormattingEnabled = true;
            this.ckListPlugins.Location = new System.Drawing.Point(3, 3);
            this.ckListPlugins.Name = "ckListPlugins";
            this.ckListPlugins.Size = new System.Drawing.Size(820, 277);
            this.ckListPlugins.TabIndex = 0;
            // 
            // frmTestRunDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 428);
            this.Controls.Add(this.pluginsPanel);
            this.Controls.Add(this.grpCommonProperties);
            this.Name = "frmTestRunDefinition";
            this.ShowInTaskbar = false;
            this.Text = "frmTestRunDefinition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpCommonProperties.ResumeLayout(false);
            this.grpCommonProperties.PerformLayout();
            this.pluginsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCommonProperties;
        private System.Windows.Forms.Label lblTestDefinition;
        private System.Windows.Forms.ComboBox cboTestDefinition;
        private System.Windows.Forms.TextBox txtTestRunName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTimeLineType;
        private System.Windows.Forms.ComboBox cboTimeLines;
        private System.Windows.Forms.TableLayoutPanel pluginsPanel;
        private System.Windows.Forms.CheckedListBox ckListPlugins;


    }
}