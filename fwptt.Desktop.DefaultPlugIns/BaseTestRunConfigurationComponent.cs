using fwptt.TestProject.Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fwptt.Desktop.DefaultPlugIns
{
    public abstract class BaseTestRunConfigurationComponent<T> : UserControl, ITestRunConfigurationComponent where T : ExtendableData, new()
    {
        protected T CurrentData;
        public ExtendableData NewConfiguration()
        {
            return new T();
        }

        public virtual void SetConfiguration(ExtendableData data)
        {
            var tmpData = data as T;
            CurrentData = tmpData != null ? tmpData : (T)NewConfiguration(); ;
        }

        public abstract bool IsValid();

        public ExtendableData GetConfiguration()
        {
            return CurrentData;
        }
    }
}
