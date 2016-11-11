using System;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject.Project.TimeLine
{
    /// <summary>
    /// Summary description for NormalTimeLine.
    /// </summary>
    public abstract class BaseTimeLineController : ITimeLineController
	{
        public uint MaxExecutionThreads { get; protected set; }
        public uint CurrentExecutionThreads{get; protected set;}
		public DateTime StartTime {get; protected set;}
        public DateTime EndTime { get; protected set; }
        public int MiliSecondsPauseBetweenRequests { get; set; }

        public event Action<TimeLineStatus> TimelineEvent;

        public ulong CurrentIteration { get; private set; }
        public bool IsRunning { get; protected set; }
        private void OnTimelineEvent()
        {
            var handler = TimelineEvent;
            if (handler != null)
                handler(new TimeLineStatus
                {
                    StartTime = StartTime,
                    EndTime = EndTime,
                    IsRunning = IsRunning,
                    CurrentExecutionThreads = CurrentExecutionThreads,
                    MaxExecutionThreads = MaxExecutionThreads,
                    MiliSecondsPauseBetweenRequests = MiliSecondsPauseBetweenRequests,
                    CurrentIteration = CurrentIteration
                });
        }
        public virtual void StartTimeLine()
        {

            CurrentExecutionThreads = 0;
            CurrentIteration = 0;
            StartTime = DateTime.Now;
            IsRunning = true;
            OnTimelineEvent();
        }

		public virtual void StopTimeLine()
		{
            EndTime = DateTime.Now;
            IsRunning = false;
            OnTimelineEvent();
		}

        public virtual void StartNewIterationExecution() 
        {
            OnTimelineEvent();
        }

        public object threadCountLock = new object();
        public virtual void IterationExecutionEnded(ulong iteration)
        {
            lock (threadCountLock)
                if (CurrentExecutionThreads > 0)
                    CurrentExecutionThreads--;
            OnTimelineEvent();
        }

        public virtual ulong? TryStartNewExecutionThread()
        {
            lock (threadCountLock)
            {
                if (CurrentExecutionThreads >= MaxExecutionThreads)
                    return null;
                CurrentExecutionThreads++;
                return CurrentIteration++;
            }
        }
	}
}
