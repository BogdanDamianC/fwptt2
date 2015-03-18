using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.TestProject.Project.Interfaces
{
    public abstract class BaseTestRunTimeLine:ExtendableData
    {
        public abstract ITimeLineController GetNewController();
        public override ExpandableDataType DataType
        {
            get { return ExpandableDataType.Configuration; }
        }
    }

    public interface ITimeLineController
    {
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        void StartTimeLine();
        void StopTimeLine();
        bool IsRunning { get; }
        int MaxExecutionThreads { get; }
        int CurrentExecutionThreads { get; }
        void OnStepStarted();
        void OnStepFinished();
        int MiliSecondsPauseBetweenRequests { get; set; }
        bool TryStartNewExecutionThread();
        void ExecutionThreadEnded();
        event Action<TimeLineStatus> TimelineEvent;
    }
}
