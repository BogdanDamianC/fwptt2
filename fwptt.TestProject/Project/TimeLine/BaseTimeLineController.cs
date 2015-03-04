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
        protected int MaxExecutionThreads;
        public int CurrentExecutionThreads{get; protected set;}
		public DateTime StartTime {get; protected set;}
        public DateTime EndTime { get; protected set; }

        public virtual bool IsRunning { get; protected set; }
        public virtual void StartTimeLine()
        {
            CurrentExecutionThreads = 0;
            StartTime = DateTime.Now;
            IsRunning = true;
        }

		public virtual void StopTimeLine()
		{
            EndTime = DateTime.Now;
            IsRunning = false;
		}
        public int MiliSecondsPauseBetweenRequests {get; set;}
        public virtual void OnStepStarted() { }
        public virtual void OnStepFinished() { }
        public virtual void ExecutionThreadEnded()
        {
            if (CurrentExecutionThreads > 0)
                CurrentExecutionThreads--;
        }

        public bool TryStartNewExecutionThread()
        {
            if (CurrentExecutionThreads >= MaxExecutionThreads)
                return false;
            CurrentExecutionThreads++;
            return true;
        }
	}
}
