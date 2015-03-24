using System;
using fwptt.TestProject;
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

        public uint CurrentIteration { get; private set; }
        public virtual bool IsRunning { get; protected set; }
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
        
        public virtual void OnStepStarted() 
        {
            lock (this)
            {
                CurrentIteration++;
            }
            OnTimelineEvent();
        }

        public virtual void OnStepFinished() 
        {
            OnTimelineEvent();
        }
        public virtual void ExecutionThreadEnded()
        {
            if (CurrentExecutionThreads > 0)
                CurrentExecutionThreads--;
            OnTimelineEvent();
        }

        public virtual bool TryStartNewExecutionThread()
        {
            if (CurrentExecutionThreads >= MaxExecutionThreads)
                return false;
            CurrentExecutionThreads++;
            return true;
        }
	}
}
