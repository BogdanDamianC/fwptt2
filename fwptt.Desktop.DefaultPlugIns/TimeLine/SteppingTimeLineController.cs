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
        public int CurrentStep { get; private set; }

        public override void StartTimeLine()
        {
            CurrentStep = 0;
            base.StartTimeLine();
        }

        public override void OnStepStarted()
        {
            lock (this)
            {
                CurrentStep++;
            }
        }

        public override void OnStepFinished()
        {
            lock (this)
            {
                IsRunning &= CurrentStep <= timeline. MaxSteps;
            }
        }
    }
}
