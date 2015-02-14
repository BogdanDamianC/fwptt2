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
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    [ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.Plugin)]
    public class ucCounterViewer : BaseTestRunExecutionComponent, IRequestPlayerPlugIn
	{
		private System.ComponentModel.IContainer components;

        private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox txtInstantRequestsperSecond;
        private System.Windows.Forms.TextBox txtAverageRequestsperSecond;
        private System.Windows.Forms.TextBox txtTotalNoOfRequests;

		private TestStatuses TestStatus = TestStatuses.NotRunning;

		private int InstantCount = 0;
		private int TotalCount = 0;
        private int TotalNoOfErrors = 0;
		private DateTime StartTime;
        private TextBox txtNoOfErrors;
		private DateTime EndTime;

		public ucCounterViewer()
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtInstantRequestsperSecond = new System.Windows.Forms.TextBox();
            this.txtAverageRequestsperSecond = new System.Windows.Forms.TextBox();
            this.txtTotalNoOfRequests = new System.Windows.Forms.TextBox();
            this.txtNoOfErrors = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
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
            label1.Location = new System.Drawing.Point(0, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(160, 23);
            label1.TabIndex = 1;
            label1.Text = "Instant No of requests/second";
            // 
            // txtInstantRequestsperSecond
            // 
            this.txtInstantRequestsperSecond.Location = new System.Drawing.Point(168, 3);
            this.txtInstantRequestsperSecond.Name = "txtInstantRequestsperSecond";
            this.txtInstantRequestsperSecond.ReadOnly = true;
            this.txtInstantRequestsperSecond.Size = new System.Drawing.Size(64, 20);
            this.txtInstantRequestsperSecond.TabIndex = 2;
            // 
            // txtAverageRequestsperSecond
            // 
            this.txtAverageRequestsperSecond.Location = new System.Drawing.Point(168, 27);
            this.txtAverageRequestsperSecond.Name = "txtAverageRequestsperSecond";
            this.txtAverageRequestsperSecond.ReadOnly = true;
            this.txtAverageRequestsperSecond.Size = new System.Drawing.Size(64, 20);
            this.txtAverageRequestsperSecond.TabIndex = 4;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(0, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(168, 23);
            label2.TabIndex = 3;
            label2.Text = "Average No of requests/second";
            // 
            // txtTotalNoOfRequests
            // 
            this.txtTotalNoOfRequests.Location = new System.Drawing.Point(168, 51);
            this.txtTotalNoOfRequests.Name = "txtTotalNoOfRequests";
            this.txtTotalNoOfRequests.ReadOnly = true;
            this.txtTotalNoOfRequests.Size = new System.Drawing.Size(64, 20);
            this.txtTotalNoOfRequests.TabIndex = 6;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(0, 51);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(168, 23);
            label3.TabIndex = 5;
            label3.Text = "Total No of Requests";
            // 
            // txtNoOfErrors
            // 
            this.txtNoOfErrors.Location = new System.Drawing.Point(168, 74);
            this.txtNoOfErrors.Name = "txtNoOfErrors";
            this.txtNoOfErrors.ReadOnly = true;
            this.txtNoOfErrors.Size = new System.Drawing.Size(64, 20);
            this.txtNoOfErrors.TabIndex = 8;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(0, 74);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(168, 23);
            label4.TabIndex = 7;
            label4.Text = "No of Errors";
            // 
            // ucCounterViewer
            // 
            this.Controls.Add(this.txtNoOfErrors);
            this.Controls.Add(label4);
            this.Controls.Add(this.txtTotalNoOfRequests);
            this.Controls.Add(label3);
            this.Controls.Add(this.txtAverageRequestsperSecond);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtInstantRequestsperSecond);
            this.Controls.Add(label1);
            this.Name = "ucCounterViewer";
            this.Size = new System.Drawing.Size(534, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


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

        public void TestStarted()
        {
            TestStatus = TestStatuses.Running;
            StartTime = DateTime.Now;
            InstantCount = 0;
            TotalCount = 0;
            TotalNoOfErrors = 0;
        }

        public void TestEnded()
        {
            TestStatus = TestStatuses.Stopped;
        }


        public void TestStoped()
        {
            
        }

        public void RequestStarted(TestProject.Run.Data.IRequestInfo rinfo)
        {
            
        }

        public void RequestEnded(TestProject.Run.Data.IRequestInfo rinfo)
        {
            InstantCount++;
            TotalCount++;
            if (rinfo.Errors != null && rinfo.Errors.Count > 0)
                TotalNoOfErrors++;
            EndTime = DateTime.Now;
        }
    }
}
