namespace fwptt.Desktop.App.UI
{
    partial class frmTestProjectDefinition
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTestProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTestProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTestProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showExploreTestProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreTestProject = new fwptt.Desktop.App.UI.ucExploreTestProject();
            this.splitterExplorer = new System.Windows.Forms.Splitter();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(909, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTestProjectToolStripMenuItem,
            this.openTestProjectToolStripMenuItem,
            this.saveTestProjectToolStripMenuItem,
            this.saveTestProjectAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTestProjectToolStripMenuItem
            // 
            this.newTestProjectToolStripMenuItem.Name = "newTestProjectToolStripMenuItem";
            this.newTestProjectToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.newTestProjectToolStripMenuItem.Text = "&New Test Project";
            this.newTestProjectToolStripMenuItem.Click += new System.EventHandler(this.newTestProjectToolStripMenuItem_Click);
            // 
            // openTestProjectToolStripMenuItem
            // 
            this.openTestProjectToolStripMenuItem.Name = "openTestProjectToolStripMenuItem";
            this.openTestProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openTestProjectToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.openTestProjectToolStripMenuItem.Text = "&Open Test Project";
            this.openTestProjectToolStripMenuItem.Click += new System.EventHandler(this.openTestProjectToolStripMenuItem_Click);
            // 
            // saveTestProjectToolStripMenuItem
            // 
            this.saveTestProjectToolStripMenuItem.Name = "saveTestProjectToolStripMenuItem";
            this.saveTestProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveTestProjectToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.saveTestProjectToolStripMenuItem.Text = "&Save Test Project";
            this.saveTestProjectToolStripMenuItem.Click += new System.EventHandler(this.saveTestProjectToolStripMenuItem_Click);
            // 
            // saveTestProjectAsToolStripMenuItem
            // 
            this.saveTestProjectAsToolStripMenuItem.Name = "saveTestProjectAsToolStripMenuItem";
            this.saveTestProjectAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveTestProjectAsToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.saveTestProjectAsToolStripMenuItem.Text = "Save Test Project &As";
            this.saveTestProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveTestProjectAsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showExploreTestProjectToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // showExploreTestProjectToolStripMenuItem
            // 
            this.showExploreTestProjectToolStripMenuItem.Name = "showExploreTestProjectToolStripMenuItem";
            this.showExploreTestProjectToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showExploreTestProjectToolStripMenuItem.Text = "Show &Explore Test Project";
            this.showExploreTestProjectToolStripMenuItem.Click += new System.EventHandler(this.showExploreTestProjectToolStripMenuItem_Click);
            // 
            // exploreTestProject
            // 
            this.exploreTestProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exploreTestProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.exploreTestProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exploreTestProject.ForeColor = System.Drawing.Color.White;
            this.exploreTestProject.Location = new System.Drawing.Point(0, 24);
            this.exploreTestProject.Margin = new System.Windows.Forms.Padding(8);
            this.exploreTestProject.Name = "exploreTestProject";
            this.exploreTestProject.Size = new System.Drawing.Size(221, 610);
            this.exploreTestProject.TabIndex = 3;
            // 
            // splitterExplorer
            // 
            this.splitterExplorer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitterExplorer.Location = new System.Drawing.Point(221, 24);
            this.splitterExplorer.Name = "splitterExplorer";
            this.splitterExplorer.Size = new System.Drawing.Size(10, 610);
            this.splitterExplorer.TabIndex = 4;
            this.splitterExplorer.TabStop = false;
            // 
            // frmTestProjectDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 634);
            this.Controls.Add(this.splitterExplorer);
            this.Controls.Add(this.exploreTestProject);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmTestProjectDefinition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTestProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTestProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTestProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showExploreTestProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTestProjectAsToolStripMenuItem;
        private ucExploreTestProject exploreTestProject;
        private System.Windows.Forms.Splitter splitterExplorer;
    }
}