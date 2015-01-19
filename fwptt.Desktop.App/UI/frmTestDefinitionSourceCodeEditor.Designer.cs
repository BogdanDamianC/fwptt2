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
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCode = new System.Windows.Forms.TabPage();
            this.txtSourceCode = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSourceCodePath = new System.Windows.Forms.Panel();
            this.btnSaveSourceCode = new System.Windows.Forms.Button();
            this.tabPageCompile = new System.Windows.Forms.TabPage();
            this.txtCompileResults = new System.Windows.Forms.TextBox();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnCompileCode = new System.Windows.Forms.Button();
            this.grpAssemblies = new System.Windows.Forms.GroupBox();
            this.lstBoxAssemplies = new System.Windows.Forms.ListBox();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.btnDeleteAssembly = new System.Windows.Forms.Button();
            this.btnSaveSourceCode2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlSourceCodePath.SuspendLayout();
            this.tabPageCompile.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            this.grpAssemblies.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(621, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Compile Results";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCode);
            this.tabControl1.Controls.Add(this.tabPageCompile);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCode
            // 
            this.tabPageCode.Controls.Add(this.txtSourceCode);
            this.tabPageCode.Controls.Add(this.statusStrip1);
            this.tabPageCode.Controls.Add(this.pnlSourceCodePath);
            this.tabPageCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageCode.Name = "tabPageCode";
            this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCode.Size = new System.Drawing.Size(627, 433);
            this.tabPageCode.TabIndex = 1;
            this.tabPageCode.Text = "Source Code";
            this.tabPageCode.UseVisualStyleBackColor = true;
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.AcceptsTab = true;
            this.txtSourceCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCode.HideSelection = false;
            this.txtSourceCode.Location = new System.Drawing.Point(3, 28);
            this.txtSourceCode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtSourceCode.ShowSelectionMargin = true;
            this.txtSourceCode.Size = new System.Drawing.Size(621, 380);
            this.txtSourceCode.TabIndex = 1;
            this.txtSourceCode.Text = "";
            this.txtSourceCode.SelectionChanged += new System.EventHandler(this.txtSourceCode_SelectionChanged);
            // 
            // statusStrip1
            // 
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
            // pnlSourceCodePath
            // 
            this.pnlSourceCodePath.BackColor = System.Drawing.Color.Transparent;
            this.pnlSourceCodePath.Controls.Add(this.btnSaveSourceCode);
            this.pnlSourceCodePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSourceCodePath.Location = new System.Drawing.Point(3, 3);
            this.pnlSourceCodePath.Name = "pnlSourceCodePath";
            this.pnlSourceCodePath.Size = new System.Drawing.Size(621, 25);
            this.pnlSourceCodePath.TabIndex = 0;
            // 
            // btnSaveSourceCode
            // 
            this.btnSaveSourceCode.Location = new System.Drawing.Point(3, 1);
            this.btnSaveSourceCode.Name = "btnSaveSourceCode";
            this.btnSaveSourceCode.Size = new System.Drawing.Size(209, 23);
            this.btnSaveSourceCode.TabIndex = 2;
            this.btnSaveSourceCode.Text = "Save C# Source Code ";
            this.btnSaveSourceCode.UseVisualStyleBackColor = true;
            this.btnSaveSourceCode.Click += new System.EventHandler(this.btnSaveSourceCode_Click);
            // 
            // tabPageCompile
            // 
            this.tabPageCompile.Controls.Add(this.txtCompileResults);
            this.tabPageCompile.Controls.Add(this.label2);
            this.tabPageCompile.Controls.Add(this.pnlActionButtons);
            this.tabPageCompile.Controls.Add(this.grpAssemblies);
            this.tabPageCompile.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompile.Name = "tabPageCompile";
            this.tabPageCompile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompile.Size = new System.Drawing.Size(627, 433);
            this.tabPageCompile.TabIndex = 0;
            this.tabPageCompile.Text = "Compile";
            this.tabPageCompile.UseVisualStyleBackColor = true;
            // 
            // txtCompileResults
            // 
            this.txtCompileResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompileResults.Location = new System.Drawing.Point(3, 307);
            this.txtCompileResults.Multiline = true;
            this.txtCompileResults.Name = "txtCompileResults";
            this.txtCompileResults.Size = new System.Drawing.Size(621, 123);
            this.txtCompileResults.TabIndex = 7;
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.btnSaveSourceCode2);
            this.pnlActionButtons.Controls.Add(this.btnCompileCode);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionButtons.Location = new System.Drawing.Point(3, 255);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(621, 29);
            this.pnlActionButtons.TabIndex = 8;
            // 
            // btnCompileCode
            // 
            this.btnCompileCode.Location = new System.Drawing.Point(3, 3);
            this.btnCompileCode.Name = "btnCompileCode";
            this.btnCompileCode.Size = new System.Drawing.Size(122, 23);
            this.btnCompileCode.TabIndex = 6;
            this.btnCompileCode.Text = "Compile Code";
            this.btnCompileCode.UseVisualStyleBackColor = true;
            this.btnCompileCode.Click += new System.EventHandler(this.BtnCompileCodeClick);
            // 
            // grpAssemblies
            // 
            this.grpAssemblies.Controls.Add(this.lstBoxAssemplies);
            this.grpAssemblies.Controls.Add(this.txtAssembly);
            this.grpAssemblies.Controls.Add(this.tableLayoutPanel1);
            this.grpAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAssemblies.Location = new System.Drawing.Point(3, 3);
            this.grpAssemblies.Name = "grpAssemblies";
            this.grpAssemblies.Size = new System.Drawing.Size(621, 252);
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
            this.lstBoxAssemplies.Size = new System.Drawing.Size(615, 184);
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
            // btnSaveSourceCode2
            // 
            this.btnSaveSourceCode2.Location = new System.Drawing.Point(135, 3);
            this.btnSaveSourceCode2.Name = "btnSaveSourceCode2";
            this.btnSaveSourceCode2.Size = new System.Drawing.Size(209, 23);
            this.btnSaveSourceCode2.TabIndex = 7;
            this.btnSaveSourceCode2.Text = "Save C# Source Code ";
            this.btnSaveSourceCode2.UseVisualStyleBackColor = true;
            this.btnSaveSourceCode2.Click += new System.EventHandler(this.btnSaveSourceCode_Click);
            // 
            // frmTestDefinitionSourceCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 459);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTestDefinitionSourceCodeEditor";
            this.Text = "Compile Assembly";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageCode.ResumeLayout(false);
            this.tabPageCode.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlSourceCodePath.ResumeLayout(false);
            this.tabPageCompile.ResumeLayout(false);
            this.tabPageCompile.PerformLayout();
            this.pnlActionButtons.ResumeLayout(false);
            this.grpAssemblies.ResumeLayout(false);
            this.grpAssemblies.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Button btnCompileCode;
		private System.Windows.Forms.Panel pnlActionButtons;
		private System.Windows.Forms.TextBox txtCompileResults;
		private System.Windows.Forms.Button btnDeleteAssembly;
		private System.Windows.Forms.Button btnAddAssembly;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtAssembly;
		private System.Windows.Forms.ListBox lstBoxAssemplies;
        private System.Windows.Forms.GroupBox grpAssemblies;
		private System.Windows.Forms.Panel pnlSourceCodePath;
		private System.Windows.Forms.TabPage tabPageCode;
		private System.Windows.Forms.TabPage tabPageCompile;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RichTextBox txtSourceCode;
        private System.Windows.Forms.Button btnSaveSourceCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Statuslabel;
        private System.Windows.Forms.Button btnSaveSourceCode2;
	}
}
