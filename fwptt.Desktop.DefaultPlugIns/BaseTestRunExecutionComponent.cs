using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.DefaultPlugIns
{
    /// <summary>
    /// helper class that implements the basic implementation for the setter
    /// </summary>
    public class BaseTestRunExecutionComponent: UserControl, ITestRunViewerComponent
    {
        private Type configurationDataType = null;
        public BaseTestRunExecutionComponent()
            : base()
        {
            if(DesignMode)
                return;
            var attributes = this.GetType().GetCustomAttributes(typeof(ExpandableSettingsAttribute), true);
            if (attributes.Length == 0)
                return;//still in design mode
            configurationDataType = TestProjectHost.Current.GetExpandableDataType(((ExpandableSettingsAttribute)attributes[0]).UniqueName);
        }

        protected ExtendableData CurrentData;

        public virtual void SetConfiguration(ExtendableData data)
        {
            if (data == null)
                throw new ApplicationException("The "+ this.GetType() + " viewer was started with no data!");
            else if(data.GetType() != configurationDataType)
                throw new ApplicationException("The " + this.GetType() + " viewer was started with the wrong data!");
            CurrentData = data;
        }
    }
}
