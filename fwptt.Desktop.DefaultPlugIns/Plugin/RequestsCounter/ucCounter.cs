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
using System.Threading;
using fwptt.TestProject.Project.Data;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
	[ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.Plugin)]
	public class ucCounter : BaseTestRunExecutionComponent, IRequestPlayerPlugIn
	{
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.Timer mainTimer;

		private TestLoadInfoPerUnitOfTime currentInstantCount;
		private Simple2DChart.ChartRenderer chartRenderer;
		private DateAxis xAxis;
		private NumberAxis yAxis;
		private Simple2DChart.Graphs.LineGraph<DateTime, double> instantNoOfRequestsChart;
		private Simple2DChart.Graphs.LineGraph<DateTime, double> averageNoOfRequestsChart;
		private Simple2DChart.Graphs.LineGraph<DateTime, double> errorCountChart;
		private Label lblNumbersOverview;

		private RequestCounterRunData requestCounterRunData = new RequestCounterRunData();
		public ExtendableData TestRunResults
		{
			get { return requestCounterRunData; }
			set
			{
				requestCounterRunData = (RequestCounterRunData)value;
				CreateChart();
				SetNumbersOverview();
			}
		}
		public DateTime TestRunStartTime;

		public ucCounter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			mainTimer.Stop();

		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (DesignMode)
				return;
			if (chartRenderer == null)
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
			this.mainTimer = new System.Windows.Forms.Timer(this.components);
			this.lblNumbersOverview = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainTimer
			// 
			this.mainTimer.Enabled = true;
			this.mainTimer.Interval = 1000;
			this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
			// 
			// lblNumbersOverview
			// 
			this.lblNumbersOverview.AutoSize = true;
			this.lblNumbersOverview.Location = new System.Drawing.Point(5, 1);
			this.lblNumbersOverview.Name = "lblNumbersOverview";
			this.lblNumbersOverview.Size = new System.Drawing.Size(13, 13);
			this.lblNumbersOverview.TabIndex = 9;
			this.lblNumbersOverview.Text = "0";
			// 
			// ucCounter
			// 
			this.Controls.Add(this.lblNumbersOverview);
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

		private Pen[] availableDynamicPens = new Pen[] { Pens.Blue, Pens.Green, Pens.Red, Pens.DarkOrange, Pens.Lavender, Pens.Pink, Pens.Magenta, Pens.LightGreen, Pens.LightBlue, Pens.YellowGreen, Pens.Yellow, Pens.Crimson, Pens.DarkGray };
		private Simple2DChart.Graphs.LineGraph<DateTime, double> NewGraph(string legend, Action<Graphics,int,int> drawPoint = null)
		{
			var newGraph = new Simple2DChart.Graphs.LineGraph<DateTime, double>(xAxis, yAxis, new List<Simple2DChart.Graphs.GraphData<DateTime, double>>());
			newGraph.Font = new Font(FontFamily.GenericSansSerif, 8);
			newGraph.DrawPoint += new Simple2DChart.Graphs.DrawPointDelegate(drawPoint ?? this.DrawPoint);
			newGraph.Pen = availableDynamicPens[chartRenderer.Graphs.Count % availableDynamicPens.Length];
			newGraph.Legend = legend;
			chartRenderer.Graphs.Add(newGraph);
			return newGraph;
		}

		private static string getChartDateTimeLabel(BaseAxis<DateTime> axis, int index, DateTime value) { 
			return value.Minute + ":" + value.Second; 
		}
		private void CreateChart()
		{
			otherCountsCharts = new Dictionary<string, Simple2DChart.Graphs.LineGraph<DateTime, double>>();
			xAxis = new DateAxis(new Rectangle(50, 160, this.Width - 150, 100), new Font(FontFamily.GenericSansSerif, 8), 4, Position.Bottom);
			xAxis.LabelOrientation = Simple2DChart.Orientation.Horizontal;
			xAxis.Title = null;
			xAxis.GetLabel = getChartDateTimeLabel;

			yAxis = new NumberAxis(new Rectangle(0, 30, 50, 130), new Font(FontFamily.GenericSansSerif, 8), 5, Position.Left);
			yAxis.LabelOrientation = Simple2DChart.Orientation.Horizontal;
			yAxis.Title = "Requests/Second";

			var grgrid = new ChartGrid(xAxis, yAxis);
			grgrid.Brush = new SolidBrush(System.Drawing.Color.CornflowerBlue);
			grgrid.Pen = new Pen(grgrid.Brush, Convert.ToSingle(0.2));

			
			chartRenderer = new ChartRenderer(new IAxis[] { yAxis, xAxis, yAxis }, new List< Simple2DChart.Graphs.IGraph>(), null);
			chartRenderer.Grid = grgrid;
			chartRenderer.LegendPosition = new Rectangle(this.Width - 100, 0, 100, 170);

			instantNoOfRequestsChart = NewGraph("req/sec");
			averageNoOfRequestsChart = NewGraph("avg req/sec", DrawPoint1);
			errorCountChart = NewGraph("err/sec", DrawPoint1);
			
			yAxis.MinValue = 0;

			if (requestCounterRunData.TestRunCounts.Any())
			{
				xAxis.MinValue = xAxis.MaxValue = requestCounterRunData.TestRunCounts[0].Time;
				ulong tmpTotalRequests = 0;
				TestRunStartTime = requestCounterRunData.TestRunCounts[0].Time.AddSeconds(-1);
				requestCounterRunData.TestRunCounts.ForEach(trc =>
				{
					tmpTotalRequests += trc.NoOfRequests;
					double ElapsedSecs = ((TimeSpan)trc.Time.Subtract(TestRunStartTime)).TotalSeconds;
					double average = 1;
					if (ElapsedSecs > 0)
						average = (double)tmpTotalRequests / ElapsedSecs;

					AddCountToGraph(trc, average);
				});
			}
			else
			{
				xAxis.MinValue = xAxis.MaxValue = DateTime.Now;
			}
			Refresh();
		}
		#endregion

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (xAxis != null && chartRenderer != null)
			{
				xAxis.Bounds = new Rectangle(50, 160, this.Width - 150, 100);
				chartRenderer.LegendPosition = new Rectangle(this.Width - 100, 0, 100, 170);
				Refresh();
			}
		}

		private void mainTimer_Tick(object sender, System.EventArgs e)
		{
			UpdateRecordedResultsAndCharts();
		}

		private Dictionary<string, Simple2DChart.Graphs.LineGraph<DateTime, double>> otherCountsCharts;
		private void UpdateRecordedResultsAndCharts()
		{
			var instCount = currentInstantCount;
			lock (this)
			{
				currentInstantCount = new TestLoadInfoPerUnitOfTime();
			}
			mainTimer.Interval = Math.Max(Convert.ToInt32(currentInstantCount.NoOfRequests), 1000);
			instCount.Time = DateTime.Now;
			requestCounterRunData.OverallCounts.NoOfRequests += instCount.NoOfRequests;
			requestCounterRunData.OverallCounts.NoOfErrors += instCount.NoOfErrors;
			requestCounterRunData.TestRunCounts.Add(instCount);

			double ElapsedSecs = ((TimeSpan)instCount.Time.Subtract(TestRunStartTime)).TotalSeconds;
			double average = 1;
			if (ElapsedSecs > 0)
				average = (double)requestCounterRunData.OverallCounts.NoOfRequests / ElapsedSecs;
			AddCountToGraph(instCount, average);
			SetNumbersOverview();
			Refresh();
		}

		private const string overviewSpacer = "         ";
		private void SetNumbersOverview()
		{
			lblNumbersOverview.Text = "Total Requests: " + requestCounterRunData.OverallCounts.NoOfRequests + overviewSpacer;
			foreach (Simple2DChart.Graphs.LineGraph<DateTime, double> chart in chartRenderer.Graphs)
				lblNumbersOverview.Text += chart.Legend + ": " + Math.Round(chart.GraphData[chart.GraphData.Count - 1].Y, 2) + overviewSpacer;
		}

		private const int MaximuNumberOfRecordedPoints = 600;
		private void AddCountToGraph(TestLoadInfoPerUnitOfTime instCount, double average)
		{
			instantNoOfRequestsChart.GraphData.Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(instCount.Time, instCount.NoOfRequests));
			averageNoOfRequestsChart.GraphData.Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(instCount.Time, average));
			errorCountChart.GraphData.Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(instCount.Time, instCount.NoOfErrors));

			foreach(var oc in instCount.OtherCounts)
			{
				Simple2DChart.Graphs.LineGraph<DateTime, double> tmpChart;
				if(!otherCountsCharts.TryGetValue(oc.Key, out tmpChart))
				{
					tmpChart = NewGraph(oc.Key + "/sec");
					otherCountsCharts.Add(oc.Key, tmpChart);
				}
				tmpChart.GraphData.Add(new Simple2DChart.Graphs.GraphData<DateTime, double>(instCount.Time, oc.Value));
				if (oc.Value > yAxis.MaxValue)
					yAxis.MaxValue = oc.Value;
			}

			foreach(Simple2DChart.Graphs.LineGraph<DateTime, double> graph in chartRenderer.Graphs)
			{
				while (graph.GraphData.Count > MaximuNumberOfRecordedPoints)
					graph.GraphData.RemoveAt(0);
			}
			xAxis.MinValue = instantNoOfRequestsChart.GraphData[0].X;
			xAxis.MaxValue = instCount.Time;
			if (instCount.NoOfRequests > yAxis.MaxValue)
				yAxis.MaxValue = instCount.NoOfRequests;
			if (average > yAxis.MaxValue)
				yAxis.MaxValue = average;
		}

		private void TestStarted()
		{
			requestCounterRunData.Reset();
			currentInstantCount = new TestLoadInfoPerUnitOfTime();
			CreateChart();
			xAxis.MinValue = TestRunStartTime = DateTime.Now;
			mainTimer.Start();
		}
		public Action OnTestStarted { get{return TestStarted;} }

		private void TestEnded()
		{
			mainTimer.Stop();
		}
		public Action OnTestStopped { get { return TestEnded; } }
		public Action<TestProject.Run.Data.IRequestInfo> OnRequestStarted { get { return null; } }

		public void RequestEnded(TestProject.Run.Data.IRequestInfo rinfo)
		{
			lock (this)
			{
				currentInstantCount.NoOfRequests++;
				currentInstantCount.NoOfErrors += (ulong)rinfo.Errors.Count;
				ulong currentCountValue;
				foreach(var oc in rinfo.Counts)
				{
					if (currentInstantCount.OtherCounts.TryGetValue(oc.Key, out currentCountValue))
						currentInstantCount.OtherCounts[oc.Key] = currentCountValue + oc.Value;
					else
						currentInstantCount.OtherCounts[oc.Key]  = oc.Value;
				}
			}
		}
		public Action<TestProject.Run.Data.IRequestInfo> OnRequestEnded { get { return RequestEnded; } }
	}
}
