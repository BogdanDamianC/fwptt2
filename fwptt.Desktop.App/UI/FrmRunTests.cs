/*
 * 
 * Namespace Summary
 * Copyright (C) 2007+ Bogdan Damian Constantin
 * WEB: http://fwptt.sourceforge.net/
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Run;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.App.UI
{
	/// <summary>
	/// Summary description for FrmRunTests.
	/// </summary>
    public class FrmRunTests : System.Windows.Forms.Form, IRequestPlayer
	{
		private System.Windows.Forms.TextBox txtNumberOfThreads;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		private TestRunner runner;
		private System.Windows.Forms.Label lblNumberOfThreads;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblLogFileName;
		private System.Windows.Forms.TextBox txtSourceFilePath;
		private System.Windows.Forms.Button btnOpenSourceFile;

		private string SourceCode;		

		
		private Hashtable AllPlugins = new Hashtable();
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemWindows;
		private System.Windows.Forms.MenuItem menuItemPlugins;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.GroupBox grpTimeLine;
		private System.Windows.Forms.RadioButton rbbySeconds;
		private System.Windows.Forms.RadioButton rbHourAndMinutes;
		private System.Windows.Forms.RadioButton rbNumberOfSteps;
		private System.Windows.Forms.TextBox txtNoOfSeconds;
		private System.Windows.Forms.TextBox txtHour;
		private System.Windows.Forms.TextBox txtMinute;
		private System.Windows.Forms.TextBox txtNoOfSteps;
		private System.Windows.Forms.GroupBox grpProxy;
		private System.Windows.Forms.CheckBox ckUseProxy;
		private System.Windows.Forms.TextBox txtProxyPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtProxyIP;
		private System.Windows.Forms.Label label1;
		private EventHandler cbPluginCheckedChanged;
		private bool TestsAreRunning = false;
		
		
		private System.Reflection.Assembly l_CompiledAssembly;
        private TextBox txtTimeBetweenRequests;
        private Label label3;
        private string SourceFilePath = string.Empty;


		#region Constructors
		public FrmRunTests()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			runner = new TestRunner();
			runner.TestsHaveFinished +=new EventHandler(runner_TestsHaveFinished);
			cbPluginCheckedChanged = new EventHandler(cbPlugin_CheckedChanged);
			SetPlugIns();
		}

		public FrmRunTests(string windowTitle, string pSourceCode):this()
		{
			SourceCode = pSourceCode;
			this.Text = windowTitle;			
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(runner != null)
				runner.Dispose();
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtNumberOfThreads = new System.Windows.Forms.TextBox();
            this.lblNumberOfThreads = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimeBetweenRequests = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpProxy = new System.Windows.Forms.GroupBox();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxyIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckUseProxy = new System.Windows.Forms.CheckBox();
            this.grpTimeLine = new System.Windows.Forms.GroupBox();
            this.txtNoOfSteps = new System.Windows.Forms.TextBox();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtNoOfSeconds = new System.Windows.Forms.TextBox();
            this.rbNumberOfSteps = new System.Windows.Forms.RadioButton();
            this.rbHourAndMinutes = new System.Windows.Forms.RadioButton();
            this.rbbySeconds = new System.Windows.Forms.RadioButton();
            this.btnOpenSourceFile = new System.Windows.Forms.Button();
            this.txtSourceFilePath = new System.Windows.Forms.TextBox();
            this.lblLogFileName = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemPlugins = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemWindows = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.grpProxy.SuspendLayout();
            this.grpTimeLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumberOfThreads
            // 
            this.txtNumberOfThreads.Location = new System.Drawing.Point(118, 8);
            this.txtNumberOfThreads.Name = "txtNumberOfThreads";
            this.txtNumberOfThreads.Size = new System.Drawing.Size(29, 20);
            this.txtNumberOfThreads.TabIndex = 0;
            this.txtNumberOfThreads.Text = "1";
            // 
            // lblNumberOfThreads
            // 
            this.lblNumberOfThreads.Location = new System.Drawing.Point(8, 8);
            this.lblNumberOfThreads.Name = "lblNumberOfThreads";
            this.lblNumberOfThreads.Size = new System.Drawing.Size(104, 23);
            this.lblNumberOfThreads.TabIndex = 1;
            this.lblNumberOfThreads.Text = "Number Of Threads";
            // 
            // btnStart
            // 
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(8, 64);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(126, 64);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimeBetweenRequests);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.grpProxy);
            this.panel1.Controls.Add(this.grpTimeLine);
            this.panel1.Controls.Add(this.btnOpenSourceFile);
            this.panel1.Controls.Add(this.txtSourceFilePath);
            this.panel1.Controls.Add(this.lblLogFileName);
            this.panel1.Controls.Add(this.txtNumberOfThreads);
            this.panel1.Controls.Add(this.lblNumberOfThreads);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 102);
            this.panel1.TabIndex = 9;
            // 
            // txtTimeBetweenRequests
            // 
            this.txtTimeBetweenRequests.Location = new System.Drawing.Point(324, 6);
            this.txtTimeBetweenRequests.Name = "txtTimeBetweenRequests";
            this.txtTimeBetweenRequests.Size = new System.Drawing.Size(41, 20);
            this.txtTimeBetweenRequests.TabIndex = 13;
            this.txtTimeBetweenRequests.Text = "250";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(148, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pause between requests(milisec)";
            // 
            // grpProxy
            // 
            this.grpProxy.Controls.Add(this.txtProxyPort);
            this.grpProxy.Controls.Add(this.label2);
            this.grpProxy.Controls.Add(this.txtProxyIP);
            this.grpProxy.Controls.Add(this.label1);
            this.grpProxy.Controls.Add(this.ckUseProxy);
            this.grpProxy.Enabled = false;
            this.grpProxy.Location = new System.Drawing.Point(665, 0);
            this.grpProxy.Name = "grpProxy";
            this.grpProxy.Size = new System.Drawing.Size(184, 96);
            this.grpProxy.TabIndex = 11;
            this.grpProxy.TabStop = false;
            this.grpProxy.Text = "Proxy (Not Done)";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(72, 64);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.ReadOnly = true;
            this.txtProxyPort.Size = new System.Drawing.Size(104, 20);
            this.txtProxyPort.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // txtProxyIP
            // 
            this.txtProxyIP.Location = new System.Drawing.Point(72, 40);
            this.txtProxyIP.Name = "txtProxyIP";
            this.txtProxyIP.ReadOnly = true;
            this.txtProxyIP.Size = new System.Drawing.Size(104, 20);
            this.txtProxyIP.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP address";
            // 
            // ckUseProxy
            // 
            this.ckUseProxy.Location = new System.Drawing.Point(8, 16);
            this.ckUseProxy.Name = "ckUseProxy";
            this.ckUseProxy.Size = new System.Drawing.Size(104, 24);
            this.ckUseProxy.TabIndex = 0;
            this.ckUseProxy.Text = "Use Proxy";
            this.ckUseProxy.CheckedChanged += new System.EventHandler(this.ckUseProxy_CheckedChanged);
            // 
            // grpTimeLine
            // 
            this.grpTimeLine.Controls.Add(this.txtNoOfSteps);
            this.grpTimeLine.Controls.Add(this.txtMinute);
            this.grpTimeLine.Controls.Add(this.txtHour);
            this.grpTimeLine.Controls.Add(this.txtNoOfSeconds);
            this.grpTimeLine.Controls.Add(this.rbNumberOfSteps);
            this.grpTimeLine.Controls.Add(this.rbHourAndMinutes);
            this.grpTimeLine.Controls.Add(this.rbbySeconds);
            this.grpTimeLine.Location = new System.Drawing.Point(371, 3);
            this.grpTimeLine.Name = "grpTimeLine";
            this.grpTimeLine.Size = new System.Drawing.Size(286, 93);
            this.grpTimeLine.TabIndex = 5;
            this.grpTimeLine.TabStop = false;
            this.grpTimeLine.Text = "Time Line";
            // 
            // txtNoOfSteps
            // 
            this.txtNoOfSteps.Location = new System.Drawing.Point(144, 16);
            this.txtNoOfSteps.Name = "txtNoOfSteps";
            this.txtNoOfSteps.Size = new System.Drawing.Size(136, 20);
            this.txtNoOfSteps.TabIndex = 6;
            this.txtNoOfSteps.Text = "1";
            // 
            // txtMinute
            // 
            this.txtMinute.Location = new System.Drawing.Point(184, 40);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.ReadOnly = true;
            this.txtMinute.Size = new System.Drawing.Size(40, 20);
            this.txtMinute.TabIndex = 4;
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(144, 40);
            this.txtHour.Name = "txtHour";
            this.txtHour.ReadOnly = true;
            this.txtHour.Size = new System.Drawing.Size(40, 20);
            this.txtHour.TabIndex = 3;
            // 
            // txtNoOfSeconds
            // 
            this.txtNoOfSeconds.Location = new System.Drawing.Point(144, 64);
            this.txtNoOfSeconds.Name = "txtNoOfSeconds";
            this.txtNoOfSeconds.ReadOnly = true;
            this.txtNoOfSeconds.Size = new System.Drawing.Size(136, 20);
            this.txtNoOfSeconds.TabIndex = 1;
            // 
            // rbNumberOfSteps
            // 
            this.rbNumberOfSteps.Checked = true;
            this.rbNumberOfSteps.Location = new System.Drawing.Point(16, 16);
            this.rbNumberOfSteps.Name = "rbNumberOfSteps";
            this.rbNumberOfSteps.Size = new System.Drawing.Size(112, 24);
            this.rbNumberOfSteps.TabIndex = 5;
            this.rbNumberOfSteps.TabStop = true;
            this.rbNumberOfSteps.Text = "Number Of Steps";
            this.rbNumberOfSteps.CheckedChanged += new System.EventHandler(this.rbTimeLine_CheckedChanged);
            // 
            // rbHourAndMinutes
            // 
            this.rbHourAndMinutes.Location = new System.Drawing.Point(16, 40);
            this.rbHourAndMinutes.Name = "rbHourAndMinutes";
            this.rbHourAndMinutes.Size = new System.Drawing.Size(120, 24);
            this.rbHourAndMinutes.TabIndex = 2;
            this.rbHourAndMinutes.Text = "Hour and Minutes";
            this.rbHourAndMinutes.CheckedChanged += new System.EventHandler(this.rbTimeLine_CheckedChanged);
            // 
            // rbbySeconds
            // 
            this.rbbySeconds.Location = new System.Drawing.Point(16, 64);
            this.rbbySeconds.Name = "rbbySeconds";
            this.rbbySeconds.Size = new System.Drawing.Size(128, 24);
            this.rbbySeconds.TabIndex = 0;
            this.rbbySeconds.Text = "Number Of Seconds";
            this.rbbySeconds.CheckedChanged += new System.EventHandler(this.rbTimeLine_CheckedChanged);
            // 
            // btnOpenSourceFile
            // 
            this.btnOpenSourceFile.Location = new System.Drawing.Point(8, 32);
            this.btnOpenSourceFile.Name = "btnOpenSourceFile";
            this.btnOpenSourceFile.Size = new System.Drawing.Size(112, 23);
            this.btnOpenSourceFile.TabIndex = 1;
            this.btnOpenSourceFile.Text = "Source File";
            this.btnOpenSourceFile.Click += new System.EventHandler(this.btnOpenSourceFile_Click);
            // 
            // txtSourceFilePath
            // 
            this.txtSourceFilePath.Location = new System.Drawing.Point(120, 32);
            this.txtSourceFilePath.Name = "txtSourceFilePath";
            this.txtSourceFilePath.ReadOnly = true;
            this.txtSourceFilePath.Size = new System.Drawing.Size(245, 20);
            this.txtSourceFilePath.TabIndex = 2;
            // 
            // lblLogFileName
            // 
            this.lblLogFileName.Location = new System.Drawing.Point(248, 32);
            this.lblLogFileName.Name = "lblLogFileName";
            this.lblLogFileName.Size = new System.Drawing.Size(100, 23);
            this.lblLogFileName.TabIndex = 10;
            this.lblLogFileName.Text = "LogFileName";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItemWindows});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemPlugins,
            this.menuItem5,
            this.menuItemExit});
            this.menuItem1.Text = "&Options";
            // 
            // menuItemPlugins
            // 
            this.menuItemPlugins.Index = 0;
            this.menuItemPlugins.Text = "&Plugins";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 2;
            this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuItemExit.Text = "E&xit";
            // 
            // menuItemWindows
            // 
            this.menuItemWindows.Index = 1;
            this.menuItemWindows.MdiList = true;
            this.menuItemWindows.Text = "Windows";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // FrmRunTests
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 422);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "FrmRunTests";
            this.Text = "Run Test";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpProxy.ResumeLayout(false);
            this.grpProxy.PerformLayout();
            this.grpTimeLine.ResumeLayout(false);
            this.grpTimeLine.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Timer timer1;
		#endregion

		
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed (e);
			if(runner != null)
				runner.Dispose();
		}

        private void OpenAndCompileSourceFile()
        {

        }

		#region Events
		private void btnOpenSourceFile_Click(object sender, System.EventArgs e)
		{
            OpenAndCompileSourceFile();
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			if(l_CompiledAssembly == null)
			{
                OpenAndCompileSourceFile();
			}
			
			if(ckUseProxy.Checked)
			{
				try
				{
					runner.Proxy = new System.Net.WebProxy(txtProxyIP.Text, int.Parse(txtProxyPort.Text));
				}
				catch
				{
					MessageBox.Show("Invalid Proxy Settings","Error");
					return;
				}
			}

			if(l_CompiledAssembly == null)
				return;

			System.Type [] types = l_CompiledAssembly.GetTypes();
			int i = 0;
			while(i < types.Length)
			{
				if(types[i].IsSubclassOf(typeof(BaseTemplateExecuteClass)))
					break;
				i++;
			}

			if(i >= types.Length)
				return;

            BaseTestRunTimeLine tl = null;
			if(rbbySeconds.Checked)
			{
				try
				{
                    tl = null;// new TimeBasedTimeLine(int.Parse(txtNoOfSeconds.Text.Trim()));
				}
				catch
				{
					MessageBox.Show("No Of Seconds is incorect!", "Error");
					return;
				}
			}
			else if(rbHourAndMinutes.Checked)
			{
				try
				{
					int Hour = txtHour.Text.Trim().Length > 0?int.Parse(txtHour.Text.Trim()):0;
					int Minute = txtMinute.Text.Trim().Length > 0?int.Parse(txtMinute.Text.Trim()):0;
                    tl = null;// new TimeBasedTimeLine(Hour, Minute, 0);
				}
				catch
				{
					MessageBox.Show("Hour or minute are incorect!", "Error");
					return;
				}
			}
			else
			{
				try
				{
                    tl = null;// new SteppingTimeLine(int.Parse(txtNoOfSteps.Text.Trim()));
				}
				catch
				{
					MessageBox.Show("Number of steps is incorect!", "Error");
					return;
				}
			}

            try
            {
                //tl.MiliSecondsPauseBetweenRequests = int.Parse(txtTimeBetweenRequests.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Pause between requests format is incorect!", "Error");
                return;
            }
			
			TestsAreRunning = true;

			runner.RunnedType = types[i];
			runner.StartTests(int.Parse(txtNumberOfThreads.Text), tl);
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			StopTests();			
		}

		private void StopTests()
		{
			if(runner != null)
				runner.StopTests();
		}

		private void runner_TestsHaveFinished(object sender, EventArgs e)
		{
			TestsAreRunning = false;
		}
        
		private void SetPlugIns()
		{
            /*
			var dirinfo = new DirectoryInfo(Application.StartupPath + "\\PlugIn\\");
			var dlls = dirinfo.GetFiles("*.dll");
			Assembly asmb = null;
			RequestsPlayer.IRequestPlayerPlugIn plugin = null;

			for(int i =0; i < dlls.Length; i++)
			{
				try
				{
					asmb = Assembly.LoadFile(dlls[i].FullName);
				}
				catch
				{
					continue;
				}
				Type [] types = asmb.GetTypes();
				for(int ti = 0; ti < types.Length; ti++)
					if(runner.AddPlugIn(types[ti], this))
					{
						plugin = runner.GetPlugIn(types[ti]);
						if(plugin != null)
						{
							MenuItem cb = new MenuItem();
							cb.Text = plugin.PlugInName;
							cb.Checked = true;
							cb.Click += cbPluginCheckedChanged;
							menuItemPlugins.MenuItems.Add(cb);
							AllPlugins[cb] = types[ti];
						}
					}
			}
             */
		}
        
		private void cbPlugin_CheckedChanged(object sender, EventArgs e)
		{
            //MenuItem cb = (MenuItem)sender;
            //cb.Checked = !cb.Checked;
            //if(cb.Checked)
            //    runner.AddPlugIn((Type)AllPlugins[cb], this);
            //else
            //    runner.RemovePlugIn((Type)AllPlugins[cb]);
		}

		private void rbTimeLine_CheckedChanged(object sender, System.EventArgs e)
		{
			txtNoOfSeconds.ReadOnly = !rbbySeconds.Checked;
			txtHour.ReadOnly = txtMinute.ReadOnly = !rbHourAndMinutes.Checked;
			txtNoOfSteps.ReadOnly = !rbNumberOfSteps.Checked;
		}

		private void ckUseProxy_CheckedChanged(object sender, System.EventArgs e)
		{
			txtProxyIP.ReadOnly = txtProxyPort.ReadOnly = !ckUseProxy.Checked;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			lock(this)
			{
				if(TestsAreRunning != btnStart.Enabled) //only change the button when it is needed
					return;
				if(TestsAreRunning)
				{
					btnStart.Enabled = false;
					btnStop.Enabled = true;
					txtNumberOfThreads.Enabled = false;
					btnOpenSourceFile.Enabled = false;
					menuItemPlugins.Enabled = false;
				}
				else
				{
					btnStart.Enabled = true;
					btnStop.Enabled = false;
					txtNumberOfThreads.Enabled = true;
					btnOpenSourceFile.Enabled = true;
					menuItemPlugins.Enabled = true;
					btnStart.Focus();
				}
			}
		}
		
		#endregion

        #region IRequestPlayer Members

        public object PlayerInfo
        {
            get { return this; }
        }

        #endregion

    }
}
