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

using System.Windows.Forms;
using System.Net;

namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    /// <summary>
    /// Summary description for frmDORequestsRecording.
    /// </summary>
    public class frmDORequestsRecording : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtProxyIP;
		private System.Windows.Forms.TextBox txtProxyPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFilters;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnStopRecording;
		private System.Windows.Forms.Button btnStartRecording;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnClearRecordedData;
		private System.Windows.Forms.DataGrid dgRequests;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Timers.Timer timer1;
		private ProxyHttpRecorder recorder;

		public frmDORequestsRecording(ProxyHttpRecorder l_recorder)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            label4.Text = "In order to record the Http requests the program will start a proxy at the IP addres and Port from below. After you can check the proxy settings in the connection settings and set the proxy . The 'Exclude from Recording' are used to determine what files should not be recorded.  Please note that this Proxy only works for http requests if you need to load https requests please use fiddler save the requests and import them.";
			recorder = l_recorder;
            txtProxyIP.Text = recorder.ProxyIP.ToString();
			txtProxyPort.Text = recorder.ProxyPort.ToString();

			if(recorder.ExcludedRequests != null && recorder.ExcludedRequests.Length > 0)
			{
				foreach(string str in recorder.ExcludedRequests)
				{
					txtFilters.Text += str+";";
				}
			}
		}



		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				timer1.Close();
				if(components != null)
				{
					components.Dispose();
				}
				recorder.StopRecording();
				recorder = null;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProxyIP = new System.Windows.Forms.TextBox();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnClearRecordedData = new System.Windows.Forms.Button();
            this.dgRequests = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.timer1 = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proxy IP address";
            // 
            // txtProxyIP
            // 
            this.txtProxyIP.Location = new System.Drawing.Point(112, 128);
            this.txtProxyIP.Name = "txtProxyIP";
            this.txtProxyIP.Size = new System.Drawing.Size(128, 20);
            this.txtProxyIP.TabIndex = 1;
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(112, 152);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(128, 20);
            this.txtProxyPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proxy Port";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(112, 176);
            this.txtFilters.Multiline = true;
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(288, 40);
            this.txtFilters.TabIndex = 5;
            this.txtFilters.Text = ".jpg;.jpeg;.mpg;.mpeg;.avi;.png;.gif;.ico;.js;.jscript;.css;";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exclude from Recording";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(392, 112);
            this.label4.TabIndex = 6;
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStopRecording.Location = new System.Drawing.Point(152, 224);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(96, 56);
            this.btnStopRecording.TabIndex = 8;
            this.btnStopRecording.Text = "Stop Recording";
            this.btnStopRecording.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartRecording.Location = new System.Drawing.Point(48, 224);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(96, 56);
            this.btnStartRecording.TabIndex = 7;
            this.btnStartRecording.Text = "Start Recording";
            this.btnStartRecording.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
            // 
            // btnClearRecordedData
            // 
            this.btnClearRecordedData.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearRecordedData.Location = new System.Drawing.Point(256, 224);
            this.btnClearRecordedData.Name = "btnClearRecordedData";
            this.btnClearRecordedData.Size = new System.Drawing.Size(96, 56);
            this.btnClearRecordedData.TabIndex = 10;
            this.btnClearRecordedData.Text = "Clear Recorded Data";
            this.btnClearRecordedData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearRecordedData.Click += new System.EventHandler(this.btnClearRecordedData_Click);
            // 
            // dgRequests
            // 
            this.dgRequests.DataMember = "";
            this.dgRequests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRequests.Location = new System.Drawing.Point(8, 288);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.ReadOnly = true;
            this.dgRequests.Size = new System.Drawing.Size(392, 200);
            this.dgRequests.TabIndex = 11;
            this.dgRequests.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgRequests;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Requests";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "URL";
            this.dataGridTextBoxColumn1.MappingName = "URL";
            this.dataGridTextBoxColumn1.Width = 250;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Request Method";
            this.dataGridTextBoxColumn2.MappingName = "RequestMethod";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // frmDORequestsRecording
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(410, 488);
            this.Controls.Add(this.dgRequests);
            this.Controls.Add(this.btnClearRecordedData);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFilters);
            this.Controls.Add(this.txtProxyPort);
            this.Controls.Add(this.txtProxyIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDORequestsRecording";
            this.ShowInTaskbar = false;
            this.Text = "Record IE requests";
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnStartRecording_Click(object sender, System.EventArgs e)
		{
			try
			{
				recorder.ProxyIP = IPAddress.Parse(txtProxyIP.Text);
			}
			catch
			{
				MessageBox.Show("Invalid IP address","Error");
				return;
			}
			try
			{
				recorder.ProxyPort = int.Parse(txtProxyPort.Text);
			}
			catch
			{
				MessageBox.Show("Invalid Port","Error");
				return;
			}
			recorder.ExcludedRequests = txtFilters.Text.Split(new char[]{';'});
			recorder.StartRecording();
		}

		private void btnStopRecording_Click(object sender, System.EventArgs e)
		{
			recorder.StopRecording();
		}

		private void btnClearRecordedData_Click(object sender, System.EventArgs e)
		{
			recorder.RequestsMade.Requests.Clear();
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            //TODO
			/*if(LastRecordsCount != recorder.RequestsMade.Requests.Count)
			{
				DataTable table = recorder.RequestsMade.Requests.ToDataTable();
				table.TableName = "Requests";
				dgRequests.DataSource = table;
				LastRecordsCount = recorder.RequestsMade.Requests.Count;
			}*/
		}

	}
}
