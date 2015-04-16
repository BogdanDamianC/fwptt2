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
using fwptt.TestProject.Project.Data;
using fwptt.Data.DefaultPlugins.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(SteppingTimeLine.PublicName, "Step Time Line Info", ExpandableComponentType.TimeLineViewer)]
    public partial class ucSetppingTimeLineViewer : BaseTestRunExecutionComponent, ITimeLinePlugIn
    {
        public ucSetppingTimeLineViewer()
        {
            InitializeComponent();
        }

        private void HandlexxxxxTimelineEvent(TestProject.Project.TimeLine.TimeLineStatus status)
        {
            //this timeline is designed for a reduced number of executions as such the status label can be updated without an extra timer
            lblTimeLineInfo.Text = "Iteration " + status.CurrentIteration;
        }

        TestProject.Project.TimeLine.TimeLineStatus lastStatus = null;

        private void HandleTimelineEvent(TestProject.Project.TimeLine.TimeLineStatus status)
        {
            lastStatus = status;
        }

        public Action<TestProject.Project.TimeLine.TimeLineStatus> OnTimelineEvent
        {
            get { return HandleTimelineEvent; }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if(lastStatus != null)
                lblTimeLineInfo.Text = "Iteration " + lastStatus.CurrentIteration;
        }
    }
}
