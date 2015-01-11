using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace fwptt.TestProject.Project.Interfaces
{
    public abstract class BaseTestRunTimeLine:ExtendableData
    {
        public abstract ITimeLineController GetNewController();
    }

    public interface ITimeLineController
    {
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        void StartTimeLine();
        void StopTimeLine();
        bool TimeLineRunning { get; }
        void OnStepExecuted();
        int MiliSecondsPauseBetweenRequests { get; set; }
    }
}
