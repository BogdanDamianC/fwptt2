using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(TimeBasedTimeLine.PublicName, "Time Line Info", ExpandableComponentType.TimeLineViewer)]
    public partial class ucTimeBasedTimeLineViewer : BaseTestRunExecutionComponent, ITimeLinePlugIn
    {
        public ucTimeBasedTimeLineViewer()
        {
            InitializeComponent();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {

        }

        private void HandleTimelineEvent(TestProject.Project.TimeLine.TimeLineStatus status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler((object a, EventArgs b) =>
                {
                    lblStartTime.Text = status.StartTime.ToLongTimeString();
                    lblEndTime.Text = status.EndTime.ToLongTimeString();
                    lblCurrentExecutionThreads.Text = status.CurrentExecutionThreads.ToString();
                    lblMaxThreads.Text = status.MaxExecutionThreads.ToString();
                    lblCurrentIteration.Text = status.CurrentIteration.ToString();
                }), new object[] { this, EventArgs.Empty });
                return;
            }
        }

        public Action<TestProject.Project.TimeLine.TimeLineStatus> OnTimelineEvent
        {
            get { return HandleTimelineEvent; }
        }
    }
}
