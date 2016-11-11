using System;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.TestProject.Project.Interfaces
{

    public interface ITimeLineController
    {
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        void StartTimeLine();
        void StopTimeLine();
        bool IsRunning { get; }
        uint MaxExecutionThreads { get; }
        uint CurrentExecutionThreads { get; }
        void StartNewIterationExecution();
        void IterationExecutionEnded(ulong iteration);
        int MiliSecondsPauseBetweenRequests { get; set; }
        ulong? TryStartNewExecutionThread();
        event Action<TimeLineStatus> TimelineEvent;
    }
}
