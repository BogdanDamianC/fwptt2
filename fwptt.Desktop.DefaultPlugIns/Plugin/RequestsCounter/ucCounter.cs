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
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using fwptt.TestProject.Project.Interfaces;
using Simple2DChart;
using Simple2DChart.Axes;
using fwptt.Data.DefaultPlugins.RequestsCounter;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    [ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.Plugin)]
    public class ucCounter : BaseTestRunExecutionComponent, IRequestPlayerPlugIn
	{
		private System.ComponentModel.IContainer components;

        private System.Windows.Forms.Timer mainTimer;

        private TestLoadInfoPerUnitOfTime currentInstantCount;
        private Simple2DChart.ChartRenderer chartRenderer;
        private DateAxis axaX;
        private NumberAxis axaY;
        private Simple2DChart.Graphs.LineGraph<DateTime, double> instantNoOfRequestsChart;
        private Simple2DChart.Graphs.LineGraph<DateTime, double> averageNoOfRequestsChart;
        private Simple2DChart.Graphs.LineGraph<DateTime, double> errorCountChart;
        private Label lblInstantRequestsperSecond;
        private Label lblAverageRequestsperSecond;
        private Label lblTotalNoOfRequests;
        private Label lblNoOfErrors;

        public ExtendableData TestRunResults {get; private set;}
        public DateTime TestRunStartTime;

		public ucCounter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            TestRunResults = new RequestCounterRunData();
            mainTimer.Stop();

		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            CreateChart();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            chartRenderer.Draw(e.Graphics);
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
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.lblInstantRequestsperSecond = new System.Windows.Forms.Label();
            this.lblAverageRequestsperSecond = new System.Windows.Forms.Label();
            this.lblTotalNoOfRequests = new System.Windows.Forms.Label();
            this.lblNoOfErrors = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 1);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(160, 23);
            label1.TabIndex = 1;
            label1.Text = "Instant No of requests/second";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(216, 1);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(168, 23);
            label2.TabIndex = 3;
            label2.Text = "Average No of requests/second";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(448, 1);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(120, 23);
            label3.TabIndex = 5;
            label3.Text = "Total No of Requests";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(657, 1);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 23);
            label4.TabIndex = 7;
            label4.Text = "No of Errors";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblInstantRequestsperSecond
            // 
            this.lblInstantRequestsperSecond.AutoSize = true;
            this.lblInstantRequestsperSecond.Location = new System.Drawing.Point(166, 1);
            this.lblInstantRequestsperSecond.Name = "lblInstantRequestsperSecond";
            this.lblInstantRequestsperSecond.Size = new System.Drawing.Size(13, 13);
            this.lblInstantRequestsperSecond.TabIndex = 9;
            this.lblInstantRequestsperSecond.Text = "0";
            // 
            // lblAverageRequestsperSecond
            // 
            this.lblAverageRequestsperSecond.AutoSize = true;
            this.lblAverageRequestsperSecond.Location = new System.Drawing.Point(380, 1);
            this.lblAverageRequestsperSecond.Name = "lblAverageRequestsperSecond";
            this.lblAverageRequestsperSecond.Size = new System.Drawing.Size(13, 13);
            this.lblAverageRequestsperSecond.TabIndex = 10;
            this.lblAverageRequestsperSecond.Text = "0";
            // 
            // lblTotalNoOfRequests
            // 
            this.lblTotalNoOfRequests.AutoSize = true;
            this.lblTotalNoOfRequests.Location = new System.Drawing.Point(565, 1);
            this.lblTotalNoOfRequests.Name = "lblTotalNoOfRequests";
            this.lblTotalNoOfRequests.Size = new System.Drawing.Size(13, 13);
            this.lblTotalNoOfRequests.TabIndex = 11;
            this.lblTotalNoOfRequests.Text = "0";
            // 
            // lblNoOfErrors
            // 
            this.lblNoOfErrors.AutoSize = true;
            this.lblNoOfErrors.Location = new System.Drawing.Point(727, 1);
            this.lblNoOfErrors.Name = "lblNoOfErrors";
            this.lblNoOfErrors.Size = new System.Drawing.Size(13, 13);
            this.lblNoOfErrors.TabIndex = 12;
            this.lblNoOfErrors.Text = "0";
            // 
            // ucCounter
            // 
            this.Controls.Add(this.lblNoOfErrors);
            this.Controls.Add(this.lblTotalNoOfRequests);
            this.Controls.Add(this.lblAverageRequestsperSecond);
            this.Controls.Add(this.lblInstantRequestsperSecond);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.DoubleBuffered = true;
            this.Name = "ucCounter";
            this.Size = new System.Drawing.Size(876, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        #region Chart Definition

        #region Draw Chart Points
        private void DrawPoint(Graphics g, int x, int y)
        {
            g.FillEllipse(Brushes.BlueViolet, x - 2, y - 2, 4, 4);
        }
        private void DrawPoint1(Graphics g, int x, int y)
        {
            g.FillPie(Brushes.Aquamarine, x - 2, y - 2, 4, 4, 0, 270);
        }

        #endregion

        private void CreateChart()
        {
            axaX = new DateAxis(new Rectangle(50, 160, 800, 100), new Font(FontFamily.GenericSansSerif, 8), 4, Position.Bottom);
            axaX.LabelOrientation = Simple2DChart.Orientation.Horizontal;
            axaX.Title = null;
            axaX.GetLabel = DateAxis.CurrentValueMinValueDiffLabel;

            axaY = new NumberAxis(new Rectangle(0, 30, 50, 130), new Font(FontFamily.GenericSansSerif, 8), 5, Position.Left);
            axaY.LabelOrientation = Simple2DChart.Orientation.Horizontal;
            axaY.Title = "No of Requests/Second";


            instantNoOfRequestsChart = new Simple2DChart.Graphs.LineGraph<DateTime, double>(axaX, axaY, new List<Simple2DChart.Graphs.GraphData<DateTime, double>>());
            instantNoOfRequestsChart.Font = new Font(FontFamily.GenericSansSerif, 8);
            instantNoOfRequestsChart.DrawPoint += new Simple2DChart.Graphs.DrawPointDelegate(DrawPoint);
            instantNoOfRequestsChart.Pen = Pens.Red;
            instantNoOfRequestsChart.Legend = "No Of Requests/Second";

            averageNoOfRequestsChart = new Simple2DChart.Graphs.LineGraph<DateTime, double>(axaX, axaY, new List<Simple2DChart.Graphs.GraphData<DateTime, double>>(), Simple2DChart.Graphs.LineGrapType.Curve);
            averageNoOfRequestsChart.Font = new Font(FontFamily.GenericSansSerif, 8);
            averageNoOfRequestsChart.DrawPoint += new Simple2DChart.Graphs.DrawPointDelegate(DrawPoint1);
            averageNoOfRequestsChart.Pen = Pens.Green;
            averageNoOfRequestsChart.Legend = "Average No Of Requests/Second";

            errorCountChart = new Simple2DChart.Graphs.LineGraph<DateTime, double>(axaX, axaY, new List<Simple2DChart.Graphs.GraphData<DateTime, double>>(), Simple2DChart.Graphs.LineGrapType.Curve);
            errorCountChart.Font = new Font(FontFamily.GenericSansSerif, 8);
            errorCountChart.DrawPoint += new Simple2DChart.Graphs.DrawPointDelegate(DrawPoint1);
            errorCountChart.Pen = Pens.Red;
            errorCountChart.Legend = "No Of Errors/Second";

            

            var grgrid = new ChartGrid(axaX, axaY);
            grgrid.Brush = new SolidBrush(System.Drawing.Color.CornflowerBlue);
            grgrid.Pen = new Pen(grgrid.Brush, Convert.ToSingle(0.2));

            axaX.MinValue = axaX.MaxValue = DateTime.Now;
            axaY.MinValue = 0;

            chartRenderer = new ChartRenderer(new IAxis[] { axaY, axaX, axaY }, new Simple2DChart.Graphs.IGraph[] { instantNoOfRequestsChart, averageNoOfRequestsChart }, null);
            chartRenderer.Grid = grgrid;
            chartRenderer.LegendPosition = new Rectangle(850, 0, 100, 170);
        }
        #endregion

        private void timer1_Tick(object sender, System.EventArgs e)
		{
            UpdateRecordedResultsAndCharts();
		}

        private void UpdateRecordedResultsAndCharts()
        {
            var instCount = currentInstantCount;
            currentInstantCount = new TestLoadInfoPerUnitOfTime();
            var currentResults = (RequestCounterRunData)TestRunResults;
            instCount.Time = DateTime.Now;
            currentResults.OverallCounts.NoOfRequests += instCount.NoOfRequests;
            currentResults.OverallCounts.NoOfErrors += instCount.NoOfErrors;
            currentResults.TestRunCounts.Add(instCount);

            double ElapsedSecs = ((TimeSpan)instCount.Time.Subtract(TestRunStartTime)).TotalSeconds;
            double average = 0;

            lblInstantRequestsperSecond.Text = instCount.NoOfRequests.ToString();

            lblTotalNoOfRequests.Text = currentResults.OverallCounts.NoOfRequests.ToString();
            average = ElapsedSecs > 0 ? (double)currentResults.OverallCounts.NoOfRequests / ElapsedSecs : (double)currentResults.OverallCounts.NoOfRequests;
            lblAverageRequestsperSecond.Text = Math.Round(average, 1).ToString();
            lblNoOfErrors.Text = currentResults.OverallCounts.NoOfErrors.ToString();

            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)instantNoOfRequestsChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, instCount.NoOfRequests));
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)averageNoOfRequestsChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, average));
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)errorCountChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, instCount.NoOfErrors));

            axaX.MaxValue = DateTime.Now;
            if (instCount.NoOfRequests > axaY.MaxValue)
                axaY.MaxValue = instCount.NoOfRequests;
            if (average > axaY.MaxValue)
                axaY.MaxValue = average;
            Refresh();
        }

        public void TestStarted()
        {
            TestRunResults = new RequestCounterRunData();
            currentInstantCount = new TestLoadInfoPerUnitOfTime();
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)instantNoOfRequestsChart.GraphData).Clear();
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)averageNoOfRequestsChart.GraphData).Clear();
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)errorCountChart.GraphData).Clear();
            axaX.MinValue = TestRunStartTime = DateTime.Now;
            mainTimer.Start();
        }

        public void TestStoped()
        {
            mainTimer.Stop();
            UpdateRecordedResultsAndCharts();
        }

        public void RequestStarted(TestProject.Run.Data.IRequestInfo rinfo)
        {
            
        }

        public void RequestEnded(TestProject.Run.Data.IRequestInfo rinfo)
        {
            currentInstantCount.NoOfRequests++;
            if (rinfo.Errors != null && rinfo.Errors.Count > 0)
                currentInstantCount.NoOfErrors++;
        }
    }
}
