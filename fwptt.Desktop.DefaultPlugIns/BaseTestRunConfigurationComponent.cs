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
    public class BaseTestRunConfigurationComponent : UserControl, ITestRunComponent
    {
        private Type configurationDataType = null;
        public BaseTestRunConfigurationComponent():base()
        {
            if(DesignMode)
                return;
            var attributes = this.GetType().GetCustomAttributes(typeof(ExpandableSettingsAttribute), true);
            if (attributes.Length == 0)
                return;//still in design mode

            configurationDataType = TestProjectHost.GetExpandableType(ExpandableDataType.Configuration, ((ExpandableSettingsAttribute)attributes[0]).UniqueName);
        }

        private ExtendableData lCurrentData;

        public ExtendableData CurrentData
        {
            get { return lCurrentData; }
            set
            {
                SetCurrentData(value);
            }
        }

        protected virtual void SetCurrentData(ExtendableData data)
        {
            if (data != null && data.GetType() == configurationDataType)
                lCurrentData = data;
            else
                lCurrentData = GetNewCurrentData();
        }

        protected virtual ExtendableData GetNewCurrentData()
        {
            return (ExtendableData)Activator.CreateInstance(configurationDataType);
        }
    }
}
