﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Data.DefaultPlugins.TimeLine
{
    public class TimeBasedTimeLineController : BaseTimeLineController, IDisposable
    {
        private TimeBasedTimeLine timeline;
        private double RampUpTimeSlice;
        private Timer timeCheckTimer;
        public TimeBasedTimeLineController(TimeBasedTimeLine timeline)
        {
            MaxExecutionThreads = timeline.NoOfThreads;
            MiliSecondsPauseBetweenRequests = timeline.PauseBetweenRequests;
            this.timeline = timeline;
            RampUpTimeSlice = (double)(timeline.RampUpMinutes * 60 + timeline.RampUpSeconds) / (double)MaxExecutionThreads;
        }

        public override void StartTimeLine()
        {
            base.StartTimeLine();
            timeCheckTimer = new Timer();
            timeCheckTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
 	            this.StopTimeLine();
            };
            EndTime = StartTime.AddHours(timeline.Hours);
            EndTime = EndTime.AddMinutes(timeline.Minutes);
            timeCheckTimer.Interval = (EndTime- DateTime.Now).TotalMilliseconds;
            timeCheckTimer.Start();
        }

        public override void StopTimeLine()
        {
            base.StopTimeLine();
            this.Dispose();
        }


        public override ulong? TryStartNewExecutionThread()
        {
            if(RampUpTimeSlice > 0 && CurrentExecutionThreads > 0)
            {
                if (CurrentExecutionThreads == MaxExecutionThreads)
                    RampUpTimeSlice = 0; //rampup is finished
                else if ((DateTime.Now - StartTime).TotalSeconds < RampUpTimeSlice * (double)CurrentExecutionThreads)
                    return null;
            }
            return base.TryStartNewExecutionThread();
        }



        public void Dispose()
        {
            if(timeCheckTimer != null)
            {
                timeCheckTimer.Dispose();
                timeCheckTimer = null;
            }
        }
    }
}
