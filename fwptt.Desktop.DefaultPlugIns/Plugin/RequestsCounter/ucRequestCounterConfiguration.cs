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

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    [ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.PluginConfiguration)]
    public partial class ucRequestCounterConfiguration : UserControl, ITestRunConfigurationComponent
    {
        public ucRequestCounterConfiguration()
        {
            InitializeComponent();
        }

        public ExtendableData NewConfiguration()
        {
            return new RequestCounterConfiguration();
        }

        public void SetConfiguration(ExtendableData timeLine)
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public ExtendableData GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
