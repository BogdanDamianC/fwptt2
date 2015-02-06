using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    public class TimeBasedTimeLineController : BaseTimeLineController
    {
        private TimeBasedTimeLine timeline;
        public TimeBasedTimeLineController(TimeBasedTimeLine timeline)
        {
            MaxExecutionThreads = timeline.NoOfThreads;
            this.timeline = timeline;
        }

        public override void StartTimeLine()
        {
            base.StartTimeLine();
            EndTime = StartTime.AddHours(timeline.Hours);
            EndTime = EndTime.AddMinutes(timeline.Minutes);
        }

        public override bool IsRunning
        {
            get
            {
                return base.IsRunning && DateTime.Now < EndTime;
            }
            protected set
            {
                base.IsRunning = value;
            }
        }
    }
}
