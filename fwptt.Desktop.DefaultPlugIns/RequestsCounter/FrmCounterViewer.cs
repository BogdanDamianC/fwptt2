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

namespace fwptt.Desktop.RequestPlayerPlugIns.RequestsCounter
{
	/// <summary>
	/// Summary description for FrmCounterViewer.
	/// </summary>
	public class FrmCounterViewer : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtInstantRequestsperSecond;
		private System.Windows.Forms.TextBox txtAverageRequestsperSecond;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTotalNoOfRequests;
		private System.Windows.Forms.Label label3;

		private TestStatuses TestStatus = TestStatuses.NotRunning;

		private int InstantCount = 0;
		private int TotalCount = 0;
		private DateTime StartTime;
		private DateTime EndTime;

		public FrmCounterViewer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.txtInstantRequestsperSecond = new System.Windows.Forms.TextBox();
			this.txtAverageRequestsperSecond = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTotalNoOfRequests = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Instant No of requests/second";
			// 
			// txtInstantRequestsperSecond
			// 
			this.txtInstantRequestsperSecond.Location = new System.Drawing.Point(176, 8);
			this.txtInstantRequestsperSecond.Name = "txtInstantRequestsperSecond";
			this.txtInstantRequestsperSecond.ReadOnly = true;
			this.txtInstantRequestsperSecond.Size = new System.Drawing.Size(64, 20);
			this.txtInstantRequestsperSecond.TabIndex = 2;
			this.txtInstantRequestsperSecond.Text = "";
			// 
			// txtAverageRequestsperSecond
			// 
			this.txtAverageRequestsperSecond.Location = new System.Drawing.Point(176, 32);
			this.txtAverageRequestsperSecond.Name = "txtAverageRequestsperSecond";
			this.txtAverageRequestsperSecond.ReadOnly = true;
			this.txtAverageRequestsperSecond.Size = new System.Drawing.Size(64, 20);
			this.txtAverageRequestsperSecond.TabIndex = 4;
			this.txtAverageRequestsperSecond.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Average No of requests/second";
			// 
			// txtTotalNoOfRequests
			// 
			this.txtTotalNoOfRequests.Location = new System.Drawing.Point(176, 56);
			this.txtTotalNoOfRequests.Name = "txtTotalNoOfRequests";
			this.txtTotalNoOfRequests.ReadOnly = true;
			this.txtTotalNoOfRequests.Size = new System.Drawing.Size(64, 20);
			this.txtTotalNoOfRequests.TabIndex = 6;
			this.txtTotalNoOfRequests.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Total No of Requests";
			// 
			// FrmCounterViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 80);
			this.Controls.Add(this.txtTotalNoOfRequests);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtAverageRequestsperSecond);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtInstantRequestsperSecond);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmCounterViewer";
			this.Text = "Counters";
			this.ResumeLayout(false);

		}
		#endregion

		public void TestStarted()
		{
			TestStatus = TestStatuses.Running;
			StartTime = DateTime.Now;
			InstantCount = 0;
			TotalCount = 0;
		}

		public void RequestEnded()
		{
			InstantCount ++;
			TotalCount ++;
			EndTime = DateTime.Now;
		}

		public void TestEnded()
		{
			TestStatus = TestStatuses.Stopped;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(TestStatus == TestStatuses.NotRunning)
				return;
			else if(TestStatus == TestStatuses.Stopped)
				TestStatus = TestStatuses.NotRunning;
			lock(this)
			{
				txtInstantRequestsperSecond.Text = InstantCount.ToString();
				InstantCount = 0;

				txtTotalNoOfRequests.Text = TotalCount.ToString();
				decimal ElapsedSecs = Convert.ToDecimal(((TimeSpan)EndTime.Subtract(StartTime)).TotalSeconds);
				decimal average = ElapsedSecs > 0?TotalCount/ElapsedSecs:TotalCount;
				txtAverageRequestsperSecond.Text = average.ToString();
				
			}
		}
	}
}
