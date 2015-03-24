using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;

namespace fwptt.Desktop.DefaultPlugIns
{
    /// <summary>
    /// helper class that implements the basic implementation for the setter and getter actions
    /// </summary>
    public class BaseTestRunConfigurationComponent : UserControl, ITestRunConfigurationComponent
    {
        private Type configurationDataType = null;
        public BaseTestRunConfigurationComponent():base()
        {
            if(DesignMode)
                return;
            var attributes = this.GetType().GetCustomAttributes(typeof(ExpandableSettingsAttribute), true);
            if (attributes.Length == 0)
                return;//still in design mode

            configurationDataType = TestProjectHost.Current.GetExpandableType(ExpandableDataType.Configuration, ((ExpandableSettingsAttribute)attributes[0]).UniqueName);
        }

        protected ExtendableData CurrentData;

        public virtual void SetConfiguration(ExtendableData data)
        {
            CurrentData = data != null && data.GetType() == configurationDataType ? data : (ExtendableData)Activator.CreateInstance(configurationDataType);
        }

        public ExtendableData GetConfiguration()
        {
            return CurrentData;
        }
    }
}
