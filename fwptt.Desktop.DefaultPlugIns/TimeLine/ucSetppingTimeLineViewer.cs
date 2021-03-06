﻿using System;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;
using fwptt.Data.DefaultPlugins.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(SteppingTimeLine.PublicName, "Step Time Line Info", ExpandableComponentType.TimeLineViewer)]
    public partial class ucSetppingTimeLineViewer : BaseTestRunExecutionComponent, ITimeLinePlugIn
    {
        public ucSetppingTimeLineViewer()
        {
            InitializeComponent();
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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if(lastStatus != null)
                lblTimeLineInfo.Text = "Iteration " + lastStatus.CurrentIteration;
        }
    }
}
