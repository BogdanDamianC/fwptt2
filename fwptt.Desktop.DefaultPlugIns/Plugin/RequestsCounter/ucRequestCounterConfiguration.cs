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
using fwptt.Data.DefaultPlugins.RequestsCounter;
using fwptt.TestProject.Project.Data;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    [ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.PluginConfiguration)]
    public partial class ucRequestCounterConfiguration : BaseTestRunConfigurationComponent
    {
        public ucRequestCounterConfiguration()
        {
            InitializeComponent();
        }
    }
}
