using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    public class SteppingTimeLineController : BaseTimeLineController
    {
        private SteppingTimeLine timeline;
        
        public SteppingTimeLineController(SteppingTimeLine timeline)
        {
            MaxExecutionThreads = 1;
            this.timeline = timeline;
        }

        public override void IterationExecutionEnded(ulong iteration)
        {
            lock (this)
            {
                IsRunning &= CurrentIteration <= timeline. MaxSteps;
            }
            base.IterationExecutionEnded(iteration);
        }
    }
}
