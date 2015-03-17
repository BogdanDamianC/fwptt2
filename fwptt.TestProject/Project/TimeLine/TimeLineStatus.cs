using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Project.TimeLine
{
    public class TimeLineStatus
    {
        public int MaxExecutionThreads { get; set; }
        public int MiliSecondsPauseBetweenRequests { get; set; }
        public int CurrentExecutionThreads { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual bool IsRunning { get; set; }
        public int CurrentIteration { get; set; }
    }
}
