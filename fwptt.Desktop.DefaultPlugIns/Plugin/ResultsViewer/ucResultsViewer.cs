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
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnExportResponses;
        private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;


		public int MaxResponseSize = 1000;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		public int MaxNrOfRequests = 10;
		private System.Timers.Timer timer1;
		List<RequestInfo> requests = new List<RequestInfo>();
		private System.Windows.Forms.Button btnSaveXmlLogFile;
        private System.Windows.Forms.Button btnViewPage;
        private int RequestsToDelete = 0;
        private int TotalRemoved = 0;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private Button btnExportData;
        private ContextMenuStrip menuExportData;
        private EventHandler ExportData_Click_handler;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
        private DataGridTextBoxColumn dataGridTextBoxColumn5;
	

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
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            timer1.Dispose();
            dataGrid1.DataSource = null;
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
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnExportResponses = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportData = new System.Windows.Forms.Button();
            this.btnViewPage = new System.Windows.Forms.Button();
            this.btnSaveXmlLogFile = new System.Windows.Forms.Button();
            this.timer1 = new System.Timers.Timer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuExportData = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "RequestAddress";
            this.dataGridTextBoxColumn1.MappingName = "RequestAddress";
            this.dataGridTextBoxColumn1.Width = 200;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "ResponseCode";
            this.dataGridTextBoxColumn2.MappingName = "ResponseCode";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Duration(sec)";
            this.dataGridTextBoxColumn3.MappingName = "Http_ActionDuration";
            this.dataGridTextBoxColumn3.Width = 110;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Page Size";
            this.dataGridTextBoxColumn4.MappingName = "Http_PageSize";
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "Http_ActionIndex";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 134);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(926, 383);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Port";
            this.dataGridTextBoxColumn7.MappingName = "RequestPort";
            this.dataGridTextBoxColumn7.Width = 50;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Method";
            this.dataGridTextBoxColumn6.MappingName = "RequestType";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // btnExportResponses
            // 
            this.btnExportResponses.Enabled = false;
            this.btnExportResponses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportResponses.Location = new System.Drawing.Point(486, 8);
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
            this.panel1.Size = new System.Drawing.Size(926, 134);
            this.panel1.TabIndex = 16;
            // 
            // btnExportData
            // 
            this.btnExportData.Enabled = false;
            this.btnExportData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportData.Location = new System.Drawing.Point(486, 33);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(224, 23);
            this.btnExportData.TabIndex = 24;
            this.btnExportData.Text = "Export Data";
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnViewPage
            // 
            this.btnViewPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPage.Location = new System.Drawing.Point(256, 32);
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
            this.btnSaveXmlLogFile.Location = new System.Drawing.Point(256, 8);
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
            // FrmResultsViewer
            // 
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmResultsViewer";
            this.Text = "Results Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolTip toolTip1;
		#endregion


        public void TestStarted()
        {
            requests.Clear();
            if(dataGrid1.DataSource != null)
                dataGrid1.BindingContext[dataGrid1.DataSource].Position = -1;
            dataGrid1.DataSource = null;
            btnExportResponses.Enabled = false;
            btnSaveXmlLogFile.Enabled = false;
            btnExportData.Enabled = false;
            dataGrid1.DataSource = SetDataTable();
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
            dataGrid1.DataSource = SetDataTable();
		}

        delegate void ThreadSafeAddRequestCallback(RequestInfo rinfo);
		public void RequestEnded(RequestInfo rinfo)
		{
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                ThreadSafeAddRequestCallback d = new ThreadSafeAddRequestCallback(RequestEnded);
                this.Invoke(d, new object[] { rinfo });
                return;
            }
			lock(requests)
			{
                var newrinfo = rinfo.Clone();
				if(newrinfo.Response.Length > MaxResponseSize)
					newrinfo.Response.Substring(0, MaxResponseSize);
				requests.Add(newrinfo);
                while (requests.Count > MaxNrOfRequests)
                {
                    requests.RemoveAt(0);
                    RequestsToDelete++;
                    TotalRemoved++;
                }
			}
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if(TestStatus == TestStatuses.NotRunning)
				return;
			else if(TestStatus == TestStatuses.Stopped)
				TestStatus = TestStatuses.NotRunning;            
            dataGrid1.DataSource = SetDataTable();
		}

        private DataTable SetDataTable()
        {
            DataTable tb = null;
            lock (requests)
            {
                try
                {
                    if (dataGrid1.DataSource != null)
                    {
                        tb = (DataTable)dataGrid1.DataSource;
                        if (tb.Rows.Count > requests.Count)
                            tb = null;
                    }

                    if (tb == null)
                    {
                        tb = new DataTable();
                        tb.TableName = "";
                        tb.Columns.Add("RequestAddress", typeof(string));
                        tb.Columns.Add("RequestPort", typeof(int));
                        tb.Columns.Add("RequestType", typeof(string));
                        tb.Columns.Add("ResponseCode", typeof(string));
                        tb.Columns.Add("StartTime", typeof(DateTime));
                        tb.Columns.Add("Http_ActionIndex", typeof(int));
                        tb.Columns.Add("Http_ActionDuration", typeof(decimal));
                        tb.Columns.Add("Http_PageSize", typeof(int));
                        tb.Columns.Add("Record_Index", typeof(int));
                    }

                    /* TODO
                    DataHolder.Containers.Property.PropertyCollection Properties = DataHolder.Containers.GenericData.TCollection.GetProperties(requests.GenericDataType);
                    int[] mapping = new int[tb.Columns.Count];
                    for (int i = 0; i < mapping.Length; i++)
                        if (Properties.Contains(tb.Columns[i].ColumnName))
                            mapping[i] = Properties.IndexOf(tb.Columns[i].ColumnName);
                        else
                            mapping[i] = -1;

                    for (int i = 0; i < RequestsToDelete && tb.Rows.Count > 0; i++)
                        tb.Rows.RemoveAt(0);
                    RequestsToDelete = 0;
                    tb.AcceptChanges();

                    for (int i = tb.Rows.Count; i < requests.Count; i++)
                    {
                        DataRow row = tb.NewRow();
                        RequestsPlayer.RequestInfo tmpge = requests[i];
                        for (int j = 0; j < mapping.Length; j++)
                            if (mapping[j] >= 0) //checks is the mapping is valid
                                row[j] = tmpge[mapping[j]];
                        row["Http_ActionDuration"] = Convert.ToDecimal(((TimeSpan)tmpge.EndTime.Subtract(tmpge.StartTime)).TotalMilliseconds) / 1000;
                        row["Http_PageSize"] = tmpge.Response.Length;
                        row["Http_ActionIndex"] = TotalRemoved + i + 1;
                        row["Record_Index"] = i;
                        tb.Rows.Add(row);
                     
                    }
*/
                    tb.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "  --   " + ex.StackTrace, "error");
                }
                return tb;
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
				XmlSerializer ser = new XmlSerializer(typeof(List<RequestInfo>));
				TextWriter twriter = new StreamWriter(LogFileName, false, Encoding.Unicode);
				ser.Serialize(twriter, requests);
				twriter.Close();
			}
		}
		
		private void btnExportResponses_Click(object sender, System.EventArgs e)
		{
			string ret = null;
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(fbd.ShowDialog(this) == DialogResult.OK)
				ret = fbd.SelectedPath;
			fbd.Dispose();
			if(ret == null)
				return;

			for(int j = 0; j < requests.Count; j++)
			{
				StreamWriter writer = new StreamWriter(ret + @"\Instance_" + j.ToString() + "_Req_" + j.ToString() + ".html");
				writer.Write(requests[j].Response);
				writer.Close();
			}
		}

        private void btnViewPage_Click(object sender, System.EventArgs e)
        {
            if (dataGrid1.DataSource == null || BindingContext[dataGrid1.DataSource].Current == null)
                return;

            int Index = (int)((DataRowView)BindingContext[dataGrid1.DataSource].Current)["Record_Index"];
            if (Index >= 0 && Index < requests.Count)
                using (PageViewer pv = new PageViewer(requests[Index].Response))
                    pv.ShowDialog(this);
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

        public void RequestStarted(RequestInfo rinfo)
        {
            
        }
    }
}

