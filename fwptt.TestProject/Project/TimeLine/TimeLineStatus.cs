using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Project.TimeLine
{
    public class TimeLineStatus
    {
        public uint MaxExecutionThreads { get; set; }
        public int MiliSecondsPauseBetweenRequests { get; set; }
        public uint CurrentExecutionThreads { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual bool IsRunning { get; set; }
        public ulong CurrentIteration { get; set; }
    }
}
