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
    [ExpandableSettings(SteppingTimeLine.PublicName, "Step Time Line Info", ExpandableComponentType.TimeLineViewer)]
    public partial class ucSetppingTimeLineViewer : BaseTestRunExecutionComponent
    {
        public ucSetppingTimeLineViewer()
        {
            InitializeComponent();
        }
    }
}
