using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Project.TimeLine
{
    public class SteppingTimeLineController : BaseTimeLineController
    {
        private SteppingTimeLine timeline;
        public SteppingTimeLineController(SteppingTimeLine timeline)
        {
            this.timeline = timeline;
        }
        public int CurrentStep { get; private set; }

        public override void StartTimeLine()
        {
            CurrentStep = 0;
            base.StartTimeLine();
        }

        public override void OnStepExecuted()
        {
            lock (this)
            {
                CurrentStep++;
                TimeLineRunning &= CurrentStep <= timeline. MaxSteps;
            }
        }
    }
}
