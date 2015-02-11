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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Text;
using fwptt.TestProject.Run.Data;
using fwptt.TestProject.Project.Interfaces;


namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    [ExpandableSettings(ResultsViewerConfiguration.PublicName, "Request Viewer - Provides recording/vizualization and html content view", ExpandableComponentType.Plugin)]
    public class ucResultsViewer : BaseTestRunExecutionComponent, IRequestPlayerPlugIn
	{
		private System.Windows.Forms.DataGrid dgResults;
		private System.Windows.Forms.Button btnExportResponses;
        private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components;
		
		private System.Timers.Timer timer1;
		
		private System.Windows.Forms.Button btnSaveXmlLogFile;
        private System.Windows.Forms.Button btnViewPage;
        private Button btnExportData;
        private ContextMenuStrip menuExportData;
        private EventHandler ExportData_Click_handler;


        private List<IRequestInfo> queuedRequests = new List<IRequestInfo>();
        private List<Tuple<string, double>> requests = new List<Tuple<string, double>>();
		private TestStatuses TestStatus = TestStatuses.NotRunning;

		public ucResultsViewer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            ExportData_Click_handler = new EventHandler(ExportData_Click);
            dgResults.DataSource = requests;
		}

        protected ResultsViewerConfiguration Configuration
        {
            get
            {
                return (ResultsViewerConfiguration)CurrentData;
            }
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            timer1.Dispose();
            dgResults.DataSource = null;
            requests = null;
            if (disposing && components != null)
            {
                components.Dispose();
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
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
            System.Windows.Forms.DataGridTableStyle mainGridStyle;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
            this.dgResults = new System.Windows.Forms.DataGrid();
            this.btnExportResponses = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportData = new System.Windows.Forms.Button();
            this.btnViewPage = new System.Windows.Forms.Button();
            this.btnSaveXmlLogFile = new System.Windows.Forms.Button();
            this.timer1 = new System.Timers.Timer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuExportData = new System.Windows.Forms.ContextMenuStrip(this.components);
            dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            mainGridStyle = new System.Windows.Forms.DataGridTableStyle();
            dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn1
            // 
            dataGridTextBoxColumn1.Format = "";
            dataGridTextBoxColumn1.FormatInfo = null;
            dataGridTextBoxColumn1.HeaderText = "RequestDetails";
            dataGridTextBoxColumn1.MappingName = "Item1";
            dataGridTextBoxColumn1.Width = 300;
            // 
            // dataGridTextBoxColumn2
            // 
            dataGridTextBoxColumn2.Format = "";
            dataGridTextBoxColumn2.FormatInfo = null;
            dataGridTextBoxColumn2.HeaderText = "Duration(sec)";
            dataGridTextBoxColumn2.MappingName = "Item2";
            dataGridTextBoxColumn2.Width = 75;
            
            this.dgResults.DataMember = "";
            this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgResults.Location = new System.Drawing.Point(0, 32);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.Size = new System.Drawing.Size(934, 430);
            this.dgResults.TabIndex = 0;
            this.dgResults.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            mainGridStyle});
            // 
            // mainGridStyle
            // 
            mainGridStyle.DataGrid = this.dgResults;
            mainGridStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            dataGridTextBoxColumn1,
            dataGridTextBoxColumn2});
            mainGridStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            mainGridStyle.ReadOnly = true;
            // 
            // btnExportResponses
            // 
            this.btnExportResponses.Enabled = false;
            this.btnExportResponses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportResponses.Location = new System.Drawing.Point(230, 1);
            this.btnExportResponses.Name = "btnExportResponses";
            this.btnExportResponses.Size = new System.Drawing.Size(224, 23);
            this.btnExportResponses.TabIndex = 15;
            this.btnExportResponses.Text = "Export Responses To HTML Files";
            this.btnExportResponses.Click += new System.EventHandler(this.btnExportResponses_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportData);
            this.panel1.Controls.Add(this.btnViewPage);
            this.panel1.Controls.Add(this.btnSaveXmlLogFile);
            this.panel1.Controls.Add(this.btnExportResponses);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 32);
            this.panel1.TabIndex = 16;
            // 
            // btnExportData
            // 
            this.btnExportData.Enabled = false;
            this.btnExportData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportData.Location = new System.Drawing.Point(690, 1);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(224, 23);
            this.btnExportData.TabIndex = 24;
            this.btnExportData.Text = "Export Data";
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnViewPage
            // 
            this.btnViewPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPage.Location = new System.Drawing.Point(460, 1);
            this.btnViewPage.Name = "btnViewPage";
            this.btnViewPage.Size = new System.Drawing.Size(224, 24);
            this.btnViewPage.TabIndex = 21;
            this.btnViewPage.Text = "View Page";
            this.btnViewPage.Click += new System.EventHandler(this.btnViewPage_Click);
            // 
            // btnSaveXmlLogFile
            // 
            this.btnSaveXmlLogFile.Enabled = false;
            this.btnSaveXmlLogFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveXmlLogFile.Location = new System.Drawing.Point(0, 1);
            this.btnSaveXmlLogFile.Name = "btnSaveXmlLogFile";
            this.btnSaveXmlLogFile.Size = new System.Drawing.Size(224, 23);
            this.btnSaveXmlLogFile.TabIndex = 20;
            this.btnSaveXmlLogFile.Text = "Save XML Log File";
            this.btnSaveXmlLogFile.Click += new System.EventHandler(this.btnSaveXmlLogFile_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // menuExportData
            // 
            this.menuExportData.Name = "menuExportData";
            this.menuExportData.Size = new System.Drawing.Size(61, 4);
            // 
            // ucResultsViewer
            // 
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.panel1);
            this.Name = "ucResultsViewer";
            this.Size = new System.Drawing.Size(934, 462);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolTip toolTip1;
		#endregion


        public void TestStarted()
        {
            requests.Clear();
            if(dgResults.DataSource != null)
                dgResults.BindingContext[dgResults.DataSource].Position = -1;
            dgResults.DataSource = null;
            btnExportResponses.Enabled = false;
            btnSaveXmlLogFile.Enabled = false;
            btnExportData.Enabled = false;
            Application.DoEvents();
            TestStatus = TestStatuses.Running;
            timer1.Start();
        }

        delegate void ThreadSafeCallback();
		public void TestEnded()
		{
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                ThreadSafeCallback d = new ThreadSafeCallback(TestEnded);
                this.Invoke(d);
                return;
            }

			btnExportResponses.Enabled = true;
			btnSaveXmlLogFile.Enabled = true;
            btnExportData.Enabled = true;
			TestStatus = TestStatuses.Stopped;
            timer1.Stop();
            //dgResults.DataSource = SetDataTable();
		}

        delegate void ThreadSafeAddRequestCallback(IRequestInfo rinfo);
		public void RequestEnded(IRequestInfo rinfo)
		{
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                ThreadSafeAddRequestCallback d = new ThreadSafeAddRequestCallback(RequestEnded);
                this.Invoke(d, new object[] { rinfo.Clone() });
                return;
            }
            lock (queuedRequests)
			{
                queuedRequests.Add(rinfo);
                //TODO var newrinfo = (WebRequestInfo)rinfo;
                //if(newrinfo.Response.Length > Configuration.MaxResponseSizeRecorded)
                //    newrinfo.Response = newrinfo.Response.Substring(0, Configuration.MaxResponseSizeRecorded);
				
			}
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(TestStatus == TestStatuses.NotRunning)
				return;
			else if(TestStatus == TestStatuses.Stopped)
				TestStatus = TestStatuses.NotRunning;            
            SetDataTable();
		}

        private void SetDataTable()
        {
            lock (queuedRequests)
            {
                foreach (var newrinfo in queuedRequests)
                    requests.Add(new Tuple<string, double>(newrinfo.ToString(), newrinfo.Duration / 1000));
                requests.Clear();
                while (requests.Count > Configuration.MaxNumberOfRequestsRecorded)
                {
                    requests.RemoveAt(0);
                }
            }
        }

		private void btnSaveXmlLogFile_Click(object sender, System.EventArgs e)
		{
			string LogFileName = null;
			SaveFileDialog sf = new SaveFileDialog();
			sf.Filter="XML files (*.xml)|*.xml|All files (*.*)|*.*";
			if(sf.ShowDialog(this) == DialogResult.OK)
				LogFileName = sf.FileName;
			sf.Dispose();

			if(LogFileName != null)
			{
				XmlSerializer ser = new XmlSerializer(typeof(List<WebRequestInfo>));
				TextWriter twriter = new StreamWriter(LogFileName, false, Encoding.Unicode);
				ser.Serialize(twriter, requests);
				twriter.Close();
			}
		}
		
		private void btnExportResponses_Click(object sender, System.EventArgs e)
		{
            //TODO
            //string ret = null;
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if(fbd.ShowDialog(this) == DialogResult.OK)
            //    ret = fbd.SelectedPath;
            //fbd.Dispose();
            //if(ret == null)
            //    return;

            //for(int j = 0; j < requests.Count; j++)
            //{
            //    StreamWriter writer = new StreamWriter(ret + @"\Instance_" + j.ToString() + "_Req_" + j.ToString() + ".html");
            //    writer.Write(((WebRequestInfo)requests[j]).Response);
            //    writer.Close();
            //}
		}

        private void btnViewPage_Click(object sender, System.EventArgs e)
        {
            //TODO
            //if (dgResults.DataSource == null || BindingContext[dgResults.DataSource].Current == null)
            //    return;

            //int Index = (int)((DataRowView)BindingContext[dgResults.DataSource].Current)["Record_Index"];
            //if (Index >= 0 && Index < requests.Count)
            //    using (PageViewer pv = new PageViewer(((WebRequestInfo)requests[Index]).Response))
            //        pv.ShowDialog(this);
        }

        private void txtRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            //timer1.Interval = Convert.ToDouble(txtRefreshTime.Value);
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            menuExportData.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\ResultReportsTemplates");
            if (!dir.Exists)
            {
                MessageBox.Show(string.Format("There is no ResultReportsTemplates folder in {0}. Please put your xsl templates in the '{0}\\ResultReportsTemplates' folder!", Application.StartupPath),
                    "Error");
                return;
            }
            FileInfo [] files = dir.GetFiles("*.xsl");
            foreach (FileInfo fi in files)
            {
                ToolStripMenuItem i = new ToolStripMenuItem(fi.Name);
                i.Click += ExportData_Click_handler;
                i.Tag = fi;
                menuExportData.Items.Add(i);
            }

            menuExportData.Show(btnExportData.Parent.PointToScreen(new Point(btnExportData.Left, btnExportData.Bottom)));
        }

        void ExportData_Click(object sender, EventArgs e)
        {
            string ret = null;
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog(this) == DialogResult.OK)
                ret = sf.FileName;
            sf.Dispose();
            if (ret == null)
                return;

            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            FileInfo fi = (FileInfo)mnu.Tag;

            try
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(fi.FullName);

                XmlSerializer ser = new XmlSerializer(requests.GetType());

                StringBuilder sb = new StringBuilder(1000);
                StringWriter strwriter = new StringWriter(sb);
                ser.Serialize(strwriter, requests);
                strwriter.Close();

                XmlDocument xmld = new XmlDocument();
                xmld.LoadXml(sb.ToString());

                XPathNavigator navigator1 = xmld.CreateNavigator();

                XmlTextWriter writer = new XmlTextWriter(ret, System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                xslt.Transform(navigator1, writer);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        public void TestStoped()
        {
            
        }

        public void RequestStarted(IRequestInfo rinfo)
        {
            
        }
    }
}

