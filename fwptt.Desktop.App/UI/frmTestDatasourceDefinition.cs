using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.Desktop.Util;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject;

namespace fwptt.Desktop.App.UI
{
    public partial class frmTestDatasourceDefinition : Form, IItemEditor<BaseTestDataSource>
    {
        private ITestRunConfigurationComponent configControl;

        public frmTestDatasourceDefinition()
        {
            InitializeComponent();
        }

        public frmTestDatasourceDefinition(ExpandableSetting setting)
            : this()
        {
            setUpEditControl(setting);
            configControl.SetConfiguration(CurrentItem);//force data init
            CurrentItem = (BaseTestDataSource)configControl.GetConfiguration();
        }

        public frmTestDatasourceDefinition(BaseTestDataSource datasource)
            : this()
        {
            CurrentItem = datasource;
            setUpEditControl(TestProjectHost.Current.PluginTypes.
                Single(pl => pl.ComponentType == ExpandableComponentType.DataSourceConfiguration
                && pl.UniqueName == datasource.UniqueName));
            configControl.SetConfiguration(CurrentItem);
        }

        private void setUpEditControl(ExpandableSetting setting)
        {
            var editControl = Activator.CreateInstance(setting.PluginType) as Control;
            editControl.Top = txtName.Bottom + 5;
            this.Controls.Add(editControl);
            this.configControl = (ITestRunConfigurationComponent)editControl;
            SetUpPluginSize();
        }

        public BaseTestDataSource CurrentItem
        {
            get;
            private set;
        }

        public event EventHandler<BaseTestDataSource> onNameChanged;

        public void OnBeforeTestProjectSave()
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            txtName.Text = CurrentItem.Name ?? string.Empty;
        }

        private void SetUpPluginSize()
        {
            var editControl = (UserControl)configControl;
            editControl.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - editControl.Top);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (configControl != null)
                SetUpPluginSize();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CurrentItem.Name = txtName.Text;
            this.Text = CurrentItem.Name;
            var eventToCall = onNameChanged;
            if (eventToCall != null)
                eventToCall(this, CurrentItem);
        }
    }
}
