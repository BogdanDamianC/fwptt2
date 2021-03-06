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
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using fwptt.TestProject.Run.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Data.DefaultPlugins.ResultsViewer;
using fwptt.TestProject.Project.Data;


namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    [ExpandableSettings(ResultsViewerConfiguration.PublicName, "Request Viewer - Provides recording/vizualization and html content view", ExpandableComponentType.Plugin)]
    public class ucResultsViewer : BaseTestRunExecutionComponent, IRequestPlayerPlugIn
    {
        private System.Windows.Forms.Button btnExportResponses;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components;

        private System.Timers.Timer mainTimer;
        private System.Windows.Forms.Button btnViewPage;


        private volatile LinkedList<IRequestInfo> queuedRequests = new LinkedList<IRequestInfo>();
        private DataGridView dgViewRequests;
        private DataGridViewTextBoxColumn Column1;
        private Button btnViewContent;
        private DataGridViewTextBoxColumn Column2;

        private RequestResultsRunData requestResultsRunData = new RequestResultsRunData();
        public ExtendableData TestRunResults
        {
            get { return requestResultsRunData; }
            set {
                requestResultsRunData = (RequestResultsRunData)value;
                dgViewRequests.Rows.Clear();
                requestResultsRunData.Requests.ForEach(r => AddRequest(r));
                dgViewRequests.Refresh();
                dgViewRequests.Update();
            }
        }

		public ucResultsViewer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            mainTimer.Dispose();
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
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
            this.btnExportResponses = new System.Windows.Forms.Button();
            this.btnViewPage = new System.Windows.Forms.Button();
            this.mainTimer = new System.Timers.Timer();
            this.dgViewRequests = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewContent = new System.Windows.Forms.Button();
            dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn3
            // 
            dataGridTextBoxColumn3.Format = "";
            dataGridTextBoxColumn3.FormatInfo = null;
            dataGridTextBoxColumn3.Width = -1;
            // 
            // dataGridTextBoxColumn4
            // 
            dataGridTextBoxColumn4.Format = "";
            dataGridTextBoxColumn4.FormatInfo = null;
            dataGridTextBoxColumn4.Width = -1;
            // 
            // dataGridTextBoxColumn7
            // 
            dataGridTextBoxColumn7.Format = "";
            dataGridTextBoxColumn7.FormatInfo = null;
            dataGridTextBoxColumn7.Width = -1;
            // 
            // dataGridTextBoxColumn6
            // 
            dataGridTextBoxColumn6.Format = "";
            dataGridTextBoxColumn6.FormatInfo = null;
            dataGridTextBoxColumn6.Width = -1;
            // 
            // btnExportResponses
            // 
            this.btnExportResponses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportResponses.Location = new System.Drawing.Point(0, 3);
            this.btnExportResponses.Name = "btnExportResponses";
            this.btnExportResponses.Size = new System.Drawing.Size(224, 23);
            this.btnExportResponses.TabIndex = 15;
            this.btnExportResponses.Text = "Export Responses To HTML Files";
            this.btnExportResponses.Click += new System.EventHandler(this.btnExportResponses_Click);
            // 
            // btnViewPage
            // 
            this.btnViewPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPage.Location = new System.Drawing.Point(460, 3);
            this.btnViewPage.Name = "btnViewPage";
            this.btnViewPage.Size = new System.Drawing.Size(224, 24);
            this.btnViewPage.TabIndex = 21;
            this.btnViewPage.Text = "View Page";
            this.btnViewPage.Click += new System.EventHandler(this.btnViewPage_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000D;
            this.mainTimer.SynchronizingObject = this;
            this.mainTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // dgViewRequests
            // 
            this.dgViewRequests.AllowUserToAddRows = false;
            this.dgViewRequests.AllowUserToDeleteRows = false;
            this.dgViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgViewRequests.Location = new System.Drawing.Point(0, 32);
            this.dgViewRequests.Name = "dgViewRequests";
            this.dgViewRequests.ReadOnly = true;
            this.dgViewRequests.Size = new System.Drawing.Size(931, 430);
            this.dgViewRequests.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Info";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Duration (sec)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnViewContent
            // 
            this.btnViewContent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewContent.Location = new System.Drawing.Point(230, 3);
            this.btnViewContent.Name = "btnViewContent";
            this.btnViewContent.Size = new System.Drawing.Size(224, 24);
            this.btnViewContent.TabIndex = 22;
            this.btnViewContent.Text = "View Content";
            this.btnViewContent.Click += new System.EventHandler(this.btnViewContent_Click);
            // 
            // ucResultsViewer
            // 
            this.Controls.Add(this.btnViewContent);
            this.Controls.Add(this.btnViewPage);
            this.Controls.Add(this.dgViewRequests);
            this.Controls.Add(this.btnExportResponses);
            this.DoubleBuffered = true;
            this.Name = "ucResultsViewer";
            this.Size = new System.Drawing.Size(934, 462);
            ((System.ComponentModel.ISupportInitialize)(this.mainTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewRequests)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        private void TestStarted()
        {
            queuedRequests = new LinkedList<IRequestInfo>();
            dgViewRequests.Rows.Clear();
            btnExportResponses.Enabled = false;
            mainTimer.Interval = Configuration.RefreshInterval * 1000;
            mainTimer.Start();
        }

        public Action OnTestStarted { get{return TestStarted;} }

        delegate void ThreadSafeCallback();
		private void TestEnded()
		{
            mainTimer.Stop();
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
            RefreshData();
		}

        public Action OnTestStopped { get { return TestEnded; } }

        public Action<IRequestInfo> OnRequestStarted { get{return null;} }
        delegate void ThreadSafeAddRequestCallback(IRequestInfo rinfo);
        public void RequestEnded(IRequestInfo rinfo)
        {
            lock (this)
            {
                queuedRequests.AddFirst(rinfo);    
            }
        }
        public Action<IRequestInfo> OnRequestEnded { get{return RequestEnded;} }

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            RefreshData();
		}

        private void RefreshData()
        {
            LinkedList<IRequestInfo> currentQueuedRequests = queuedRequests;
            lock (this)
            {
                queuedRequests = new LinkedList<IRequestInfo>();
            }

            if (Configuration.RecordErrorsOnly) {
                var x = currentQueuedRequests.First;
                while (x != null)
                {
                    var next = x.Next;
                    if (x.Value.Errors == null || !x.Value.Errors.Any())
                        currentQueuedRequests.Remove(x);
                    x = next;
                }
            }
            UpdateDisplayedRequestData(currentQueuedRequests);
        }

        private void UpdateDisplayedRequestData(LinkedList<IRequestInfo> currentQueuedRequests)
        {
            lock (dgViewRequests)
            {
                int rowsToKeep = Configuration.MaxNumberOfRequestsRecorded - currentQueuedRequests.Count;
                if (rowsToKeep <= 0)
                {
                    dgViewRequests.Rows.Clear();
                    requestResultsRunData.Requests.Clear();
                    for (int i = 0; i > rowsToKeep; i--)
                        currentQueuedRequests.RemoveLast();
                }
                else
                {
                    if(requestResultsRunData.Requests.Count >= rowsToKeep)
                        requestResultsRunData.Requests.RemoveRange(rowsToKeep, requestResultsRunData.Requests.Count - rowsToKeep);
                    while (dgViewRequests.Rows.Count > rowsToKeep)
                        dgViewRequests.Rows.RemoveAt(dgViewRequests.Rows.Count - 1);
                }
                foreach (var node in currentQueuedRequests)
                {
                    var item = new RequestInfoRunData(node); ;
                    requestResultsRunData.Requests.Insert(0, item);
                    AddRequest(item);
                }

                dgViewRequests.Refresh();
                dgViewRequests.Update();
            }
        }

        private void AddRequest(RequestInfoRunData item)
        {
            dgViewRequests.Rows.Insert(0, item.Info, item.Duration);
            dgViewRequests.Rows[0].Tag = item.RecordedResponse;
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

            for (int j = 0; j < dgViewRequests.Rows.Count; j++)
            {
                StreamWriter writer = new StreamWriter(ret + @"\Instance_" + j.ToString() + "_Req_" + j.ToString() + ".html");
                writer.Write(dgViewRequests.Rows[j].Tag);
                writer.Close();
            }
		}

        private void btnViewContent_Click(object sender, EventArgs e)
        {
            if (dgViewRequests.CurrentRow == null)
                return;

            using (var cv = new ContentViewer((string)dgViewRequests.CurrentRow.Tag))
                cv.ShowDialog(this);
        }

        private void btnViewPage_Click(object sender, System.EventArgs e)
        {
            if (dgViewRequests.CurrentRow == null)
                return;

            using (var pv = new PageViewer((string)dgViewRequests.CurrentRow.Tag))
                pv.ShowDialog(this);
        }
    }
}

