﻿namespace fwptt.Desktop.App.UI
{
    partial class ucExploreTestProject
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
            this.lblTItle = new System.Windows.Forms.Label();
            this.tvProject = new System.Windows.Forms.TreeView();
            this.ctxTestDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tstripNewTestDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiNewBlankCSFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestDefinitionItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTestDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestRunDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newTestRunDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestRunDefinitionItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestRunDefinitionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTestRunDefinitionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestDataSource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tStripMenuItemNewTestDataSource = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestResultsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tStripMenuItemOpenTestResults = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenuItemDeleteTestResults = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestDataSourceItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tStripMenuItemOpenTestDataSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tStripMenuItemDeleteTestDataSource = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTestDefinition.SuspendLayout();
            this.ctxTestDefinitionItem.SuspendLayout();
            this.ctxTestRunDefinition.SuspendLayout();
            this.ctxTestRunDefinitionItem.SuspendLayout();
            this.ctxTestDataSource.SuspendLayout();
            this.ctxTestResultsItem.SuspendLayout();
            this.ctxTestDataSourceItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTItle
            // 
            this.lblTItle.AutoSize = true;
            this.lblTItle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTItle.Location = new System.Drawing.Point(0, 0);
            this.lblTItle.Name = "lblTItle";
            this.lblTItle.Size = new System.Drawing.Size(126, 13);
            this.lblTItle.TabIndex = 0;
            this.lblTItle.Text = "Test Project Explorer";
            // 
            // tvProject
            // 
            this.tvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProject.Location = new System.Drawing.Point(0, 13);
            this.tvProject.Name = "tvProject";
            this.tvProject.Size = new System.Drawing.Size(255, 391);
            this.tvProject.TabIndex = 1;
            this.tvProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProject_AfterSelect);
            // 
            // ctxTestDefinition
            // 
            this.ctxTestDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripNewTestDefinition,
            this.tsiNewBlankCSFile});
            this.ctxTestDefinition.Name = "ctxTestDefinition";
            this.ctxTestDefinition.Size = new System.Drawing.Size(179, 48);
            // 
            // tstripNewTestDefinition
            // 
            this.tstripNewTestDefinition.Name = "tstripNewTestDefinition";
            this.tstripNewTestDefinition.Size = new System.Drawing.Size(178, 22);
            this.tstripNewTestDefinition.Text = "New Test Definition";
            // 
            // tsiNewBlankCSFile
            // 
            this.tsiNewBlankCSFile.Name = "tsiNewBlankCSFile";
            this.tsiNewBlankCSFile.Size = new System.Drawing.Size(178, 22);
            this.tsiNewBlankCSFile.Text = "New Blank C# File";
            this.tsiNewBlankCSFile.Click += new System.EventHandler(this.tsiNewBlankCSFile_Click);
            // 
            // ctxTestDefinitionItem
            // 
            this.ctxTestDefinitionItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteTestDefinitionToolStripMenuItem});
            this.ctxTestDefinitionItem.Name = "ctxTestDefinitionItem";
            this.ctxTestDefinitionItem.Size = new System.Drawing.Size(108, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // deleteTestDefinitionToolStripMenuItem
            // 
            this.deleteTestDefinitionToolStripMenuItem.Name = "deleteTestDefinitionToolStripMenuItem";
            this.deleteTestDefinitionToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteTestDefinitionToolStripMenuItem.Text = "Delete";
            this.deleteTestDefinitionToolStripMenuItem.Click += new System.EventHandler(this.deleteTestDefinitionToolStripMenuItem_Click);
            // 
            // ctxTestRunDefinition
            // 
            this.ctxTestRunDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTestRunDefinitionToolStripMenuItem});
            this.ctxTestRunDefinition.Name = "ctxTestRunDefinition";
            this.ctxTestRunDefinition.Size = new System.Drawing.Size(203, 26);
            // 
            // newTestRunDefinitionToolStripMenuItem
            // 
            this.newTestRunDefinitionToolStripMenuItem.Name = "newTestRunDefinitionToolStripMenuItem";
            this.newTestRunDefinitionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.newTestRunDefinitionToolStripMenuItem.Text = "New Test Run Definition";
            this.newTestRunDefinitionToolStripMenuItem.Click += new System.EventHandler(this.newTestRunDefinitionToolStripMenuItem_Click);
            // 
            // ctxTestRunDefinitionItem
            // 
            this.ctxTestRunDefinitionItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRunToolStripMenuItem,
            this.openTestRunDefinitionStripMenuItem,
            this.deleteTestRunDefinitionStripMenuItem});
            this.ctxTestRunDefinitionItem.Name = "ctxTestRunDefinitionItem";
            this.ctxTestRunDefinitionItem.Size = new System.Drawing.Size(108, 70);
            // 
            // newRunToolStripMenuItem
            // 
            this.newRunToolStripMenuItem.Name = "newRunToolStripMenuItem";
            this.newRunToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newRunToolStripMenuItem.Text = "Run";
            this.newRunToolStripMenuItem.Click += new System.EventHandler(this.newRunToolStripMenuItem_Click);
            // 
            // openTestRunDefinitionStripMenuItem
            // 
            this.openTestRunDefinitionStripMenuItem.Name = "openTestRunDefinitionStripMenuItem";
            this.openTestRunDefinitionStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openTestRunDefinitionStripMenuItem.Text = "Open";
            this.openTestRunDefinitionStripMenuItem.Click += new System.EventHandler(this.openTestRunDefinitionStripMenuItem_Click);
            // 
            // deleteTestRunDefinitionStripMenuItem
            // 
            this.deleteTestRunDefinitionStripMenuItem.Name = "deleteTestRunDefinitionStripMenuItem";
            this.deleteTestRunDefinitionStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteTestRunDefinitionStripMenuItem.Text = "Delete";
            this.deleteTestRunDefinitionStripMenuItem.Click += new System.EventHandler(this.deleteTestRunDefinitionStripMenuItem_Click);
            // 
            // ctxTestDataSource
            // 
            this.ctxTestDataSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripMenuItemNewTestDataSource});
            this.ctxTestDataSource.Name = "ctxTestDefinition";
            this.ctxTestDataSource.Size = new System.Drawing.Size(190, 26);
            // 
            // tStripMenuItemNewTestDataSource
            // 
            this.tStripMenuItemNewTestDataSource.Name = "tStripMenuItemNewTestDataSource";
            this.tStripMenuItemNewTestDataSource.Size = new System.Drawing.Size(189, 22);
            this.tStripMenuItemNewTestDataSource.Text = "New Test Data Source";
            // 
            // ctxTestResultsItem
            // 
            this.ctxTestResultsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripMenuItemOpenTestResults,
            this.tStripMenuItemDeleteTestResults});
            this.ctxTestResultsItem.Name = "ctxTestDefinitionItem";
            this.ctxTestResultsItem.Size = new System.Drawing.Size(108, 48);
            // 
            // tStripMenuItemOpenTestResults
            // 
            this.tStripMenuItemOpenTestResults.Name = "tStripMenuItemOpenTestResults";
            this.tStripMenuItemOpenTestResults.Size = new System.Drawing.Size(107, 22);
            this.tStripMenuItemOpenTestResults.Text = "Open";
            this.tStripMenuItemOpenTestResults.Click += new System.EventHandler(this.tStripMenuItemOpenTestResults_Click);
            // 
            // tStripMenuItemDeleteTestResults
            // 
            this.tStripMenuItemDeleteTestResults.Name = "tStripMenuItemDeleteTestResults";
            this.tStripMenuItemDeleteTestResults.Size = new System.Drawing.Size(107, 22);
            this.tStripMenuItemDeleteTestResults.Text = "Delete";
            this.tStripMenuItemDeleteTestResults.Click += new System.EventHandler(this.tStripMenuItemDeleteTestResults_Click);
            // 
            // ctxTestDataSourceItem
            // 
            this.ctxTestDataSourceItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripMenuItemOpenTestDataSource,
            this.tStripMenuItemDeleteTestDataSource});
            this.ctxTestDataSourceItem.Name = "ctxTestDefinitionItem";
            this.ctxTestDataSourceItem.Size = new System.Drawing.Size(108, 48);
            // 
            // tStripMenuItemOpenTestDataSource
            // 
            this.tStripMenuItemOpenTestDataSource.Name = "tStripMenuItemOpenTestDataSource";
            this.tStripMenuItemOpenTestDataSource.Size = new System.Drawing.Size(107, 22);
            this.tStripMenuItemOpenTestDataSource.Text = "Open";
            this.tStripMenuItemOpenTestDataSource.Click += new System.EventHandler(this.tStripMenuItemOpenTestDataSource_Click);
            // 
            // tStripMenuItemDeleteTestDataSource
            // 
            this.tStripMenuItemDeleteTestDataSource.Name = "tStripMenuItemDeleteTestDataSource";
            this.tStripMenuItemDeleteTestDataSource.Size = new System.Drawing.Size(107, 22);
            this.tStripMenuItemDeleteTestDataSource.Text = "Delete";
            this.tStripMenuItemDeleteTestDataSource.Click += new System.EventHandler(this.tStripMenuItemDeleteTestDataSource_Click);
            // 
            // ucExploreTestProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tvProject);
            this.Controls.Add(this.lblTItle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucExploreTestProject";
            this.Size = new System.Drawing.Size(255, 404);
            this.ctxTestDefinition.ResumeLayout(false);
            this.ctxTestDefinitionItem.ResumeLayout(false);
            this.ctxTestRunDefinition.ResumeLayout(false);
            this.ctxTestRunDefinitionItem.ResumeLayout(false);
            this.ctxTestDataSource.ResumeLayout(false);
            this.ctxTestResultsItem.ResumeLayout(false);
            this.ctxTestDataSourceItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTItle;
        private System.Windows.Forms.TreeView tvProject;
        private System.Windows.Forms.ContextMenuStrip ctxTestDefinition;
        private System.Windows.Forms.ToolStripMenuItem tstripNewTestDefinition;
        private System.Windows.Forms.ContextMenuStrip ctxTestDefinitionItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTestDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiNewBlankCSFile;
        private System.Windows.Forms.ContextMenuStrip ctxTestRunDefinition;
        private System.Windows.Forms.ToolStripMenuItem newTestRunDefinitionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxTestRunDefinitionItem;
        private System.Windows.Forms.ToolStripMenuItem openTestRunDefinitionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTestRunDefinitionStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxTestDataSource;
        private System.Windows.Forms.ToolStripMenuItem tStripMenuItemNewTestDataSource;
        private System.Windows.Forms.ContextMenuStrip ctxTestResultsItem;
        private System.Windows.Forms.ToolStripMenuItem tStripMenuItemOpenTestResults;
        private System.Windows.Forms.ToolStripMenuItem tStripMenuItemDeleteTestResults;
        private System.Windows.Forms.ContextMenuStrip ctxTestDataSourceItem;
        private System.Windows.Forms.ToolStripMenuItem tStripMenuItemOpenTestDataSource;
        private System.Windows.Forms.ToolStripMenuItem tStripMenuItemDeleteTestDataSource;
    }
}
