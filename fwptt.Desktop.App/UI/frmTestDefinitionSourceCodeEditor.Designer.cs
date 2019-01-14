/*
 * Created by SharpDevelop.
 * User: bogdanc
 * Date: 4/18/2008
 * Time: 10:43 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace fwptt.Desktop.App.UI
{
	partial class frmTestDefinitionSourceCodeEditor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCode = new System.Windows.Forms.TabPage();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFullFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompileCode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompileResults = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageCompile = new System.Windows.Forms.TabPage();
            this.grpAssemblies = new System.Windows.Forms.GroupBox();
            this.lstBoxAssemplies = new System.Windows.Forms.ListBox();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.btnDeleteAssembly = new System.Windows.Forms.Button();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.timerRecompilationTrigger = new System.Windows.Forms.Timer(this.components);
            this.ucTestDefinitionProperties = new fwptt.Desktop.App.UI.ucTestDefinitionProperties();
            this.tabControl.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPageCompile.SuspendLayout();
            this.grpAssemblies.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCode);
            this.tabControl.Controls.Add(this.tabPageCompile);
            this.tabControl.Controls.Add(this.tabPageProperties);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(635, 459);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageCode
            // 
            this.tabPageCode.Controls.Add(this.btnOpenFile);
            this.tabPageCode.Controls.Add(this.txtFullFilePath);
            this.tabPageCode.Controls.Add(this.label1);
            this.tabPageCode.Controls.Add(this.btnCompileCode);
            this.tabPageCode.Controls.Add(this.label2);
            this.tabPageCode.Controls.Add(this.txtCompileResults);
            this.tabPageCode.Controls.Add(this.statusStrip1);
            this.tabPageCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageCode.Name = "tabPageCode";
            this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCode.Size = new System.Drawing.Size(627, 433);
            this.tabPageCode.TabIndex = 1;
            this.tabPageCode.Text = "Source Code";
            this.tabPageCode.UseVisualStyleBackColor = true;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(3, 54);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(616, 23);
            this.btnOpenFile.TabIndex = 13;
            this.btnOpenFile.Text = "Open  Code File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFullFilePath
            // 
            this.txtFullFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullFilePath.Location = new System.Drawing.Point(116, 28);
            this.txtFullFilePath.Name = "txtFullFilePath";
            this.txtFullFilePath.ReadOnly = true;
            this.txtFullFilePath.Size = new System.Drawing.Size(503, 20);
            this.txtFullFilePath.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Code File Path";
            // 
            // btnCompileCode
            // 
            this.btnCompileCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompileCode.Location = new System.Drawing.Point(116, 3);
            this.btnCompileCode.Name = "btnCompileCode";
            this.btnCompileCode.Size = new System.Drawing.Size(503, 23);
            this.btnCompileCode.TabIndex = 6;
            this.btnCompileCode.Text = "Compile Code";
            this.btnCompileCode.UseVisualStyleBackColor = true;
            this.btnCompileCode.Click += new System.EventHandler(this.btnCompileCode_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Compile Results";
            // 
            // txtCompileResults
            // 
            this.txtCompileResults.AcceptsTab = true;
            this.txtCompileResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompileResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompileResults.HideSelection = false;
            this.txtCompileResults.Location = new System.Drawing.Point(0, 83);
            this.txtCompileResults.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtCompileResults.Name = "txtCompileResults";
            this.txtCompileResults.ReadOnly = true;
            this.txtCompileResults.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtCompileResults.ShowSelectionMargin = true;
            this.txtCompileResults.Size = new System.Drawing.Size(624, 322);
            this.txtCompileResults.TabIndex = 1;
            this.txtCompileResults.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Statuslabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(621, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Statuslabel
            // 
            this.Statuslabel.Name = "Statuslabel";
            this.Statuslabel.Size = new System.Drawing.Size(87, 17);
            this.Statuslabel.Text = "The Statuslabel";
            // 
            // tabPageCompile
            // 
            this.tabPageCompile.Controls.Add(this.grpAssemblies);
            this.tabPageCompile.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompile.Name = "tabPageCompile";
            this.tabPageCompile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompile.Size = new System.Drawing.Size(627, 433);
            this.tabPageCompile.TabIndex = 0;
            this.tabPageCompile.Text = "Compile Configuration";
            this.tabPageCompile.UseVisualStyleBackColor = true;
            // 
            // grpAssemblies
            // 
            this.grpAssemblies.Controls.Add(this.lstBoxAssemplies);
            this.grpAssemblies.Controls.Add(this.txtAssembly);
            this.grpAssemblies.Controls.Add(this.tableLayoutPanel1);
            this.grpAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAssemblies.Location = new System.Drawing.Point(3, 3);
            this.grpAssemblies.Name = "grpAssemblies";
            this.grpAssemblies.Size = new System.Drawing.Size(621, 427);
            this.grpAssemblies.TabIndex = 5;
            this.grpAssemblies.TabStop = false;
            this.grpAssemblies.Text = "Assemblies";
            // 
            // lstBoxAssemplies
            // 
            this.lstBoxAssemplies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxAssemplies.FormattingEnabled = true;
            this.lstBoxAssemplies.Location = new System.Drawing.Point(3, 65);
            this.lstBoxAssemplies.Name = "lstBoxAssemplies";
            this.lstBoxAssemplies.Size = new System.Drawing.Size(615, 359);
            this.lstBoxAssemplies.TabIndex = 0;
            // 
            // txtAssembly
            // 
            this.txtAssembly.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAssembly.Location = new System.Drawing.Point(3, 45);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.Size = new System.Drawing.Size(615, 20);
            this.txtAssembly.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnAddAssembly, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAssembly, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Location = new System.Drawing.Point(3, 3);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(123, 23);
            this.btnAddAssembly.TabIndex = 2;
            this.btnAddAssembly.Text = "Add";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            this.btnAddAssembly.Click += new System.EventHandler(this.BtnAddAssemblyClick);
            // 
            // btnDeleteAssembly
            // 
            this.btnDeleteAssembly.Location = new System.Drawing.Point(132, 3);
            this.btnDeleteAssembly.Name = "btnDeleteAssembly";
            this.btnDeleteAssembly.Size = new System.Drawing.Size(123, 23);
            this.btnDeleteAssembly.TabIndex = 3;
            this.btnDeleteAssembly.Text = "Delete";
            this.btnDeleteAssembly.UseVisualStyleBackColor = true;
            this.btnDeleteAssembly.Click += new System.EventHandler(this.BtnDeleteAssemblyClick);
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.ucTestDefinitionProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Size = new System.Drawing.Size(627, 433);
            this.tabPageProperties.TabIndex = 2;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // timerRecompilationTrigger
            // 
            this.timerRecompilationTrigger.Interval = 500;
            this.timerRecompilationTrigger.Tick += new System.EventHandler(this.timerRecompilationTrigger_Tick);
            // 
            // ucTestDefinitionProperties
            // 
            this.ucTestDefinitionProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTestDefinitionProperties.Location = new System.Drawing.Point(0, 0);
            this.ucTestDefinitionProperties.Margin = new System.Windows.Forms.Padding(4);
            this.ucTestDefinitionProperties.Name = "ucTestDefinitionProperties";
            this.ucTestDefinitionProperties.Size = new System.Drawing.Size(627, 433);
            this.ucTestDefinitionProperties.TabIndex = 0;
            // 
            // frmTestDefinitionSourceCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 459);
            this.Controls.Add(this.tabControl);
            this.Name = "frmTestDefinitionSourceCodeEditor";
            this.Text = "Compile Assembly";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabPageCode.ResumeLayout(false);
            this.tabPageCode.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageCompile.ResumeLayout(false);
            this.grpAssemblies.ResumeLayout(false);
            this.grpAssemblies.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Button btnDeleteAssembly;
		private System.Windows.Forms.Button btnAddAssembly;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtAssembly;
		private System.Windows.Forms.ListBox lstBoxAssemplies;
        private System.Windows.Forms.GroupBox grpAssemblies;
		private System.Windows.Forms.TabPage tabPageCode;
		private System.Windows.Forms.TabPage tabPageCompile;
		private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.RichTextBox txtCompileResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Statuslabel;
        private System.Windows.Forms.TabPage tabPageProperties;
        private ucTestDefinitionProperties ucTestDefinitionProperties;
        private System.Windows.Forms.Button btnCompileCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerRecompilationTrigger;
        private System.Windows.Forms.Button btnOpenFile;
    }
}
