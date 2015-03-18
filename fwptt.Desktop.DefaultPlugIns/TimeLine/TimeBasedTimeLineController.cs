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
        private double RampUpTimeSlice;
        public TimeBasedTimeLineController(TimeBasedTimeLine timeline)
        {
            MaxExecutionThreads = timeline.NoOfThreads;
            this.timeline = timeline;
            RampUpTimeSlice = (double)(timeline.RampUpMinutes * 60 + timeline.RampUpSeconds) / (double)MaxExecutionThreads;
        }

        public override void StartTimeLine()
        {
            base.StartTimeLine();
            EndTime = StartTime.AddHours(timeline.Hours);
            EndTime = EndTime.AddMinutes(timeline.Minutes);
        }

        public override bool TryStartNewExecutionThread()
        {
            if(RampUpTimeSlice > 0 && CurrentExecutionThreads > 0)
            {
                if (CurrentExecutionThreads == MaxExecutionThreads)
                    RampUpTimeSlice = 0; //rampup is finished
                else if ((DateTime.Now - StartTime).TotalSeconds < RampUpTimeSlice * (double)CurrentExecutionThreads)
                    return false;
            }
            return base.TryStartNewExecutionThread();
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
