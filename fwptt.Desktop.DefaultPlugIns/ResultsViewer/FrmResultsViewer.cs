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


namespace fwptt.Desktop.RequestPlayerPlugIns.ResultsViewer
{
	/// <summary>
	/// Summary description for FrmResultsViewer.
	/// </summary>
	public class FrmResultsViewer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnExportResponses;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtMaxResponseSize;
		private System.Windows.Forms.Label lblNumberOfThreads;
		private System.Windows.Forms.TextBox txtMaxNumberOfRequests;
		private System.Windows.Forms.Label label1;
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
        private NumericUpDown txtRefreshTime;
        private Label label2;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private Button btnExportData;
        private ContextMenuStrip menuExportData;
        private EventHandler ExportData_Click_handler;
	

		private TestStatuses TestStatus = TestStatuses.NotRunning;

		public FrmResultsViewer()
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
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnExportResponses = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRefreshTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewPage = new System.Windows.Forms.Button();
            this.btnSaveXmlLogFile = new System.Windows.Forms.Button();
            this.txtMaxNumberOfRequests = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxResponseSize = new System.Windows.Forms.TextBox();
            this.lblNumberOfThreads = new System.Windows.Forms.Label();
            this.timer1 = new System.Timers.Timer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExportData = new System.Windows.Forms.Button();
            this.menuExportData = new System.Windows.Forms.ContextMenuStrip(this.components);
            dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn1
            // 
            dataGridTextBoxColumn1.Format = "";
            dataGridTextBoxColumn1.FormatInfo = null;
            dataGridTextBoxColumn1.HeaderText = "RequestAddress";
            dataGridTextBoxColumn1.MappingName = "RequestAddress";
            dataGridTextBoxColumn1.Width = 200;
            // 
            // dataGridTextBoxColumn2
            // 
            dataGridTextBoxColumn2.Format = "";
            dataGridTextBoxColumn2.FormatInfo = null;
            dataGridTextBoxColumn2.HeaderText = "ResponseCode";
            dataGridTextBoxColumn2.MappingName = "ResponseCode";
            dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            dataGridTextBoxColumn3.Format = "";
            dataGridTextBoxColumn3.FormatInfo = null;
            dataGridTextBoxColumn3.HeaderText = "Duration(sec)";
            dataGridTextBoxColumn3.MappingName = "Http_ActionDuration";
            dataGridTextBoxColumn3.Width = 110;
            // 
            // dataGridTextBoxColumn4
            // 
            dataGridTextBoxColumn4.Format = "";
            dataGridTextBoxColumn4.FormatInfo = null;
            dataGridTextBoxColumn4.HeaderText = "Page Size";
            dataGridTextBoxColumn4.MappingName = "Http_PageSize";
            dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn5
            // 
            dataGridTextBoxColumn5.Format = "";
            dataGridTextBoxColumn5.FormatInfo = null;
            dataGridTextBoxColumn5.MappingName = "Http_ActionIndex";
            dataGridTextBoxColumn5.ReadOnly = true;
            dataGridTextBoxColumn5.Width = 75;
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
            dataGridTextBoxColumn5,
            dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn7,
            dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn6,
            dataGridTextBoxColumn3,
            dataGridTextBoxColumn4});
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
            this.panel1.Controls.Add(this.txtRefreshTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnViewPage);
            this.panel1.Controls.Add(this.btnSaveXmlLogFile);
            this.panel1.Controls.Add(this.txtMaxNumberOfRequests);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaxResponseSize);
            this.panel1.Controls.Add(this.lblNumberOfThreads);
            this.panel1.Controls.Add(this.btnExportResponses);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 134);
            this.panel1.TabIndex = 16;
            // 
            // txtRefreshTime
            // 
            this.txtRefreshTime.Location = new System.Drawing.Point(136, 58);
            this.txtRefreshTime.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtRefreshTime.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtRefreshTime.Name = "txtRefreshTime";
            this.txtRefreshTime.Size = new System.Drawing.Size(100, 20);
            this.txtRefreshTime.TabIndex = 23;
            this.toolTip1.SetToolTip(this.txtRefreshTime, "Refresh Interval in miliseconds");
            this.txtRefreshTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtRefreshTime.ValueChanged += new System.EventHandler(this.txtRefreshTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Refresh Interval in miliseconds";
            this.toolTip1.SetToolTip(this.label2, "Sets how often ");
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
            // txtMaxNumberOfRequests
            // 
            this.txtMaxNumberOfRequests.Location = new System.Drawing.Point(136, 32);
            this.txtMaxNumberOfRequests.Name = "txtMaxNumberOfRequests";
            this.txtMaxNumberOfRequests.Size = new System.Drawing.Size(100, 20);
            this.txtMaxNumberOfRequests.TabIndex = 18;
            this.txtMaxNumberOfRequests.Text = "100";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Max Number of recorded requests";
            this.toolTip1.SetToolTip(this.label1, "Tells the program the maximum nummber of requests \r\nto record. After the number i" +
                    "s passed the older requests\r\nwill be removed to make space for the new ones.");
            // 
            // txtMaxResponseSize
            // 
            this.txtMaxResponseSize.Location = new System.Drawing.Point(136, 8);
            this.txtMaxResponseSize.Name = "txtMaxResponseSize";
            this.txtMaxResponseSize.Size = new System.Drawing.Size(100, 20);
            this.txtMaxResponseSize.TabIndex = 16;
            this.txtMaxResponseSize.Text = "1000";
            this.toolTip1.SetToolTip(this.txtMaxResponseSize, "txtMaxResponseSize.ToolTip");
            // 
            // lblNumberOfThreads
            // 
            this.lblNumberOfThreads.Location = new System.Drawing.Point(8, 8);
            this.lblNumberOfThreads.Name = "lblNumberOfThreads";
            this.lblNumberOfThreads.Size = new System.Drawing.Size(120, 23);
            this.lblNumberOfThreads.TabIndex = 17;
            this.lblNumberOfThreads.Text = "Max response Size";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
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
            // menuExportData
            // 
            this.menuExportData.Name = "menuExportData";
            this.menuExportData.Size = new System.Drawing.Size(153, 26);
            // 
            // FrmResultsViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(926, 517);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmResultsViewer";
            this.Text = "Results Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefreshTime)).EndInit();
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
            txtMaxNumberOfRequests.ReadOnly = true;
            txtMaxResponseSize.ReadOnly = true;
            txtRefreshTime.Enabled = false;
            if(!int.TryParse(txtMaxNumberOfRequests.Text, out MaxNrOfRequests))
                txtMaxNumberOfRequests.Text = MaxNrOfRequests.ToString();
            if(!int.TryParse(txtMaxResponseSize.Text, out MaxResponseSize))
                txtMaxResponseSize.Text = MaxResponseSize.ToString();

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
			txtMaxNumberOfRequests.ReadOnly = false;
			txtMaxResponseSize.ReadOnly = false;
            txtRefreshTime.Enabled = true;
			TestStatus = TestStatuses.Stopped;
            timer1.Stop();
            dataGrid1.DataSource = SetDataTable();
		}

        delegate void ThreadSafeAddRequestCallback(RequestInfo rinfo);
		public void AddRequest(RequestInfo rinfo)
		{
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                ThreadSafeAddRequestCallback d = new ThreadSafeAddRequestCallback(AddRequest);
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
			if(dataGrid1.DataSource == null || BindingContext[dataGrid1.DataSource].Current == null)
				return;

            int Index = (int)((DataRowView)BindingContext[dataGrid1.DataSource].Current)["Record_Index"];
            if (Index >= 0 && Index < requests.Count)
            {
                PageViewer pv = new PageViewer(requests[Index].Response);
                pv.ShowDialog(this.MdiParent);
                pv.Dispose();
            }
		}

        private void txtRefreshTime_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToDouble(txtRefreshTime.Value);
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
	}
}

