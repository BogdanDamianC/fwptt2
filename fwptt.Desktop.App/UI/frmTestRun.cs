using fwptt.Desktop.Util;
using fwptt.TestProject;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fwptt.Desktop.App.UI
{
    public partial class frmTestRun : Form, IItemEditor<TestRunResults>
    {
        private Label lblTestRunName;
        private TextBox txtTestRunName;
        private Util.AccordionControl mainAccordion;

        public frmTestRun()
        {
            this.MinimumSize = new Size(200, 200);
            this.lblTestRunName = new Label { Text = "Test Run Name", Top = 10, Left = 10 };
            this.Controls.Add(lblTestRunName);
            txtTestRunName = new TextBox { Top = 8, Left = this.Controls[0].Right + 10, Width = GetNameWidth() };
            this.Controls.Add(txtTestRunName);
            mainAccordion = new Util.AccordionControl { Top= txtTestRunName.Bottom + 10,  Width = this.ClientSize.Width, KeepOnlyOneItemExpanded=false };
            this.Controls.Add(mainAccordion);
            this.AutoScroll = true;
        }

        public frmTestRun(TestRunResults runResults):this()
        {
            CurrentItem = runResults;
            txtTestRunName.Text = CurrentItem.Name;
            txtTestRunName.TextChanged += txtTextRunName_TextChanged;
            SetTitle();
        }

        void txtTextRunName_TextChanged(object sender, EventArgs e)
        {
            CurrentItem.Name = txtTestRunName.Text;
            SetTitle();
            if (onNameChanged != null)
                onNameChanged(this, CurrentItem);
        }

        private void SetTitle()
        {
            this.Text = "Test Run => " + CurrentItem.Name;
        }

        private int GetNameWidth()
        {
            return this.ClientSize.Width - lblTestRunName.Right - 10;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            txtTestRunName.Width = GetNameWidth();
            mainAccordion.Width = this.ClientSize.Width;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupPlugins();
        }

        private Control CreateNewControlAndData(ExpandableSetting setting, ExtendableData data)
        {
            var tlpl = Activator.CreateInstance(setting.PluginType) as Control;
            if (tlpl == null)
                throw new ApplicationException(setting.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");
            ((ITestRunExecutionComponent)tlpl).SetConfiguration(data);
            return tlpl;
        }

        private void AddPlugin(ExpandableSetting setting, ExtendableData data)
        {
            var newPluginControl = new ExpanderControl();
            newPluginControl.BorderStyle = BorderStyle.FixedSingle;
            newPluginControl.Width = mainAccordion.Width;
            ExpanderHelper.CreateLabelHeader(newPluginControl, setting.DisplayName, SystemColors.ActiveBorder);
            newPluginControl.Content = CreateNewControlAndData(setting, data);
            mainAccordion.Add(newPluginControl);
            newPluginControl.Expand();
        }


        private void SetupPlugins()
        {
            var tmpPluginInfo = TestProjectHost.Current.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.TimeLineViewer
                                                && pl.UniqueName == CurrentItem.TestRunDefinition.TimeLine.UniqueName);
            AddPlugin(tmpPluginInfo, CurrentItem.TestRunDefinition.TimeLine);
            foreach(var plugin in CurrentItem.TestRunDefinition.RunPlugins)
            {
                tmpPluginInfo = TestProjectHost.Current.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.Plugin
                                                && pl.UniqueName == plugin.UniqueName);
                AddPlugin(tmpPluginInfo, plugin);
            }

        }

        public TestRunResults CurrentItem
        {
            get;
            private set;
        }

        public event EventHandler<TestRunResults> onNameChanged;

        public void OnBeforeTestProjectSave()
        {
            //TODO
        }
    }
}
