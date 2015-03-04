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

        private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox txtInstantRequestsperSecond;
        private System.Windows.Forms.TextBox txtAverageRequestsperSecond;
        private System.Windows.Forms.TextBox txtTotalNoOfRequests;

		private int InstantCount = 0;
		private int TotalCount = 0;
        private int instantNoOfErrors = 0;
        private int TotalNoOfErrors = 0;
		private DateTime StartTime;
        private TextBox txtNoOfErrors;
		private DateTime EndTime;

        Simple2DChart.ChartRenderer chartRenderer;
        DateAxis axaX;
        NumberAxis axaY;

        Simple2DChart.Graphs.LineGraph<DateTime, double> instantNoOfRequestsChart;
        Simple2DChart.Graphs.LineGraph<DateTime, double> averageNoOfRequestsChart;
        Simple2DChart.Graphs.LineGraph<DateTime, double> errorCountChart;


		public ucCounter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtInstantRequestsperSecond
            // 
            this.txtInstantRequestsperSecond.Location = new System.Drawing.Point(168, 1);
            this.txtInstantRequestsperSecond.Name = "txtInstantRequestsperSecond";
            this.txtInstantRequestsperSecond.ReadOnly = true;
            this.txtInstantRequestsperSecond.Size = new System.Drawing.Size(42, 20);
            this.txtInstantRequestsperSecond.TabIndex = 2;
            // 
            // txtAverageRequestsperSecond
            // 
            this.txtAverageRequestsperSecond.Location = new System.Drawing.Point(379, 1);
            this.txtAverageRequestsperSecond.Name = "txtAverageRequestsperSecond";
            this.txtAverageRequestsperSecond.ReadOnly = true;
            this.txtAverageRequestsperSecond.Size = new System.Drawing.Size(63, 20);
            this.txtAverageRequestsperSecond.TabIndex = 4;
            // 
            // txtTotalNoOfRequests
            // 
            this.txtTotalNoOfRequests.Location = new System.Drawing.Point(561, 1);
            this.txtTotalNoOfRequests.Name = "txtTotalNoOfRequests";
            this.txtTotalNoOfRequests.ReadOnly = true;
            this.txtTotalNoOfRequests.Size = new System.Drawing.Size(64, 20);
            this.txtTotalNoOfRequests.TabIndex = 6;
            // 
            // txtNoOfErrors
            // 
            this.txtNoOfErrors.Location = new System.Drawing.Point(736, 1);
            this.txtNoOfErrors.Name = "txtNoOfErrors";
            this.txtNoOfErrors.ReadOnly = true;
            this.txtNoOfErrors.Size = new System.Drawing.Size(63, 20);
            this.txtNoOfErrors.TabIndex = 8;
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
            this.DoubleBuffered = true;
            this.Name = "ucCounterViewer";
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
            if (!instantNoOfRequestsChart.GraphData.Any())
                axaX.MinValue = DateTime.Now;

            double newInstant = InstantCount, average = 0;
            double ElapsedSecs = Convert.ToDouble(((TimeSpan)EndTime.Subtract(StartTime)).TotalSeconds);
			lock(this)
			{
				txtInstantRequestsperSecond.Text = InstantCount.ToString();

				txtTotalNoOfRequests.Text = TotalCount.ToString();
                average = ElapsedSecs > 0 ? TotalCount / ElapsedSecs : TotalCount;
				txtAverageRequestsperSecond.Text = average.ToString();
                txtNoOfErrors.Text = TotalNoOfErrors.ToString();

                ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)instantNoOfRequestsChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, InstantCount));
                ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)averageNoOfRequestsChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, average));
                ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)errorCountChart.GraphData).Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(DateTime.Now, instantNoOfErrors));


                InstantCount = 0;
                instantNoOfErrors = 0;
			}
            
            axaX.MaxValue = DateTime.Now;
            if (newInstant > axaY.MaxValue)
                axaY.MaxValue = newInstant;
            if (average > axaY.MaxValue)
                axaY.MaxValue = average;
            Refresh();
		}

        public void TestStarted()
        {
            StartTime = DateTime.Now;
            InstantCount = 0;
            TotalCount = 0;
            instantNoOfErrors = 0;
            TotalNoOfErrors = 0;
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)instantNoOfRequestsChart.GraphData).Clear();
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)averageNoOfRequestsChart.GraphData).Clear();
            ((List<Simple2DChart.Graphs.GraphData<DateTime, double>>)errorCountChart.GraphData).Clear();
            timer1.Start();
        }

        public void TestStoped()
        {
            timer1.Stop();
        }

        public void RequestStarted(TestProject.Run.Data.IRequestInfo rinfo)
        {
            
        }

        public void RequestEnded(TestProject.Run.Data.IRequestInfo rinfo)
        {
            InstantCount++;
            TotalCount++;
            if (rinfo.Errors != null && rinfo.Errors.Count > 0)
            {
                TotalNoOfErrors++;
                instantNoOfErrors++;
            }

            EndTime = DateTime.Now;
        }
    }
}
