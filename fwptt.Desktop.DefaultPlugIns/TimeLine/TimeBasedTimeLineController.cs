﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.RequestPlayerPlugIns.TimeLine
{
    public class TimeBasedTimeLineController : BaseTimeLineController
    {
        private TimeBasedTimeLine timeline;
        public TimeBasedTimeLineController(TimeBasedTimeLine timeline)
        {
            this.timeline = timeline;
        }

        public override void StartTimeLine()
        {
            base.StartTimeLine();
            EndTime = StartTime.AddHours(timeline.Hours);
            EndTime = EndTime.AddMinutes(timeline.Minutes);
        }

        public override void OnStepExecuted()
        {
            TimeLineRunning &= DateTime.Now < EndTime;
        }

    }
}