﻿using System;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;
using fwptt.Data.DefaultPlugins.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(TimeBasedTimeLine.PublicName, "Time Line Info", ExpandableComponentType.TimeLineViewer)]
    public partial class ucTimeBasedTimeLineViewer : BaseTestRunExecutionComponent, ITimeLinePlugIn
    {
        public ucTimeBasedTimeLineViewer()
        {
            InitializeComponent();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (lastStatus == null)
                return;
            lblStartTime.Text = lastStatus.StartTime.ToLongTimeString();
            lblEndTime.Text = lastStatus.EndTime.ToLongTimeString();
            lblCurrentExecutionThreads.Text = lastStatus.CurrentExecutionThreads.ToString();
            lblMaxThreads.Text = lastStatus.MaxExecutionThreads.ToString();
            lblCurrentIteration.Text = lastStatus.CurrentIteration.ToString();
        }

        TestProject.Project.TimeLine.TimeLineStatus lastStatus = null; 

        private void HandleTimelineEvent(TestProject.Project.TimeLine.TimeLineStatus status)
        {
            lastStatus = status;
        }

        public Action<TestProject.Project.TimeLine.TimeLineStatus> OnTimelineEvent
        {
            get { return HandleTimelineEvent; }
        }
    }
}
