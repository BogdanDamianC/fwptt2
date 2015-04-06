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

        public Action<TestProject.Project.TimeLine.TimeLineStatus> OnTimelineEvent
        {
            get { return null; }
        }
    }
}
