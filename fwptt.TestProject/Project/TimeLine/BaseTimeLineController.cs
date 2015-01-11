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
		public DateTime StartTime {get; protected set;}
        public DateTime EndTime { get; protected set; }

        public virtual bool TimeLineRunning { get; protected set; }
        public virtual void StartTimeLine()
        {
            StartTime = DateTime.Now;
            TimeLineRunning = true;
        }

		public virtual void StopTimeLine()
		{
            EndTime = DateTime.Now;
            TimeLineRunning = false;
		}
        public abstract void OnStepExecuted();
        public int MiliSecondsPauseBetweenRequests {get; set;}
	}
}
