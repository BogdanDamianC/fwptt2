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
using fwptt.TestProject;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Run;
using fwptt.TestProject.Project.Data;

namespace fwptt.Desktop.App.UI
{
    public partial class frmTestRun : Form, IItemEditor<TestRunResults>
    {
        private TestRunner testRunner;
        private ITimeLineController timeLineController;
        private Button btnAction;
        private Label lblTestRunName;
        private TextBox txtTestRunName;
        private Util.AccordionControl mainAccordion;

        public frmTestRun()
        {
            this.btnAction = new Button(){Text="Start", Top=5, Left = 10, Width = 100};
            this.btnAction.Click += btnAction_Click;
            this.Controls.Add(this.btnAction);
            this.lblTestRunName = new Label { Text = "Test Run Name", Top = 10, Left = 120 };
            this.Controls.Add(lblTestRunName);
            txtTestRunName = new TextBox { Top = 8, Left = lblTestRunName.Right + 10, Width = GetNameWidth() };
            this.Controls.Add(txtTestRunName);
            mainAccordion = new Util.AccordionControl { Top= txtTestRunName.Bottom + 10,  Width = this.ClientSize.Width, KeepOnlyOneItemExpanded=false };
            this.Controls.Add(mainAccordion);
            this.MinimumSize = new Size(500, 500);
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
            if (DesignMode)
                return;
            txtTestRunName.Width = GetNameWidth();
            mainAccordion.Width = this.ClientSize.Width;
            if(SetupTestRunner())
                SetupPlugins();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (timeLineController != null && timeLineController.IsRunning)
                testRunner.StopTests();
            base.OnClosed(e);
        }

        private ITestDataSourceReader GetDataSourceReader()
        {
            if (!CurrentItem.TestRunDefinition.TestDataSourceId.HasValue)
                return null;

            var dataSource = TestProject.TestProjectHost.Current.Project.TestDataSources.
                    SingleOrDefault(ds=>ds.Id == CurrentItem.TestRunDefinition.TestDataSourceId.Value);
            return dataSource != null ? dataSource.GetDataSourceReader() : null;
        }

        private bool SetupTestRunner()
        {
            var testDef = TestProjectHost.Current.Project.TestDefinitions.FirstOrDefault(td => td.Id == CurrentItem.TestRunDefinition.TestDefinitionId);
            if (testDef == null)
            {
                MessageBox.Show("The test definition C# code linked this test run def no longer exists, please update the test run definition before trying to run this test", "Error");
                return false;
            }
            try
            {

                var testAsmb = TestProjectHost.Current.CreateMemoryAssembly(testDef);
                var testExecuteClass = testAsmb.GetTypes().FirstOrDefault(t=>t.IsSubclassOf(typeof(BaseWebTest)));
                if(testExecuteClass == null){
                    MessageBox.Show("There is no class derived from BaseTemplateExecuteClass in the test C# code, please review the Test C# code","Error");
                    return false;
                }

                timeLineController = CurrentItem.TestRunDefinition.TimeLine.GetNewController();
                this.testRunner = new TestRunner(timeLineController, testExecuteClass, GetDataSourceReader());
                this.testRunner.TestRunEnded += testRunner_TestsHaveFinished;
                return true;
            }
            catch (Exception ex)
            {
                btnAction.Enabled = false;
                MessageBox.Show("Error occured while compiling the test, this test can't be run, these are the error details: \r\n" + ex.Message, "Error");
                return false;
            }
        }

        void btnAction_Click(object sender, EventArgs e)
        {
            if (timeLineController == null || !timeLineController.IsRunning)
            {
                btnAction.Text = "Stop";
                testRunner.StartTests();
            }
            else
            {
                btnAction.Enabled = false;
                btnAction.Text = "Stoping";
                testRunner.StopTests();
            }
        }


        void testRunner_TestsHaveFinished(TestRunner runner)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler((object a, EventArgs b)=>{
                    btnAction.Text = "Start";
                    btnAction.Enabled = true;
                }), new object[] { this, EventArgs.Empty });
                return;
            }
        }

        private Control CreateNewControlAndData(ExpandableSetting setting, ExtendableData data)
        {
            var tlpl = Activator.CreateInstance(setting.PluginType) as Control;
            if (tlpl == null)
                throw new ApplicationException(setting.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");
            ((ITestRunExecutionComponent)tlpl).SetConfiguration(data);
            return tlpl;
        }

        private Control CreateAndAddPlugin(ExpandableSetting setting, ExtendableData data)
        {
            var newPluginControl = new ExpanderControl();
            newPluginControl.BorderStyle = BorderStyle.FixedSingle;
            newPluginControl.Width = mainAccordion.ClientSize.Width;
            ExpanderControl.CreateLabelHeader(newPluginControl, setting.DisplayName, SystemColors.ActiveBorder);
            newPluginControl.Content = CreateNewControlAndData(setting, data);
            mainAccordion.Add(newPluginControl);
            newPluginControl.Expand();
            return newPluginControl.Content;
        }
        private void AddPlugin(ExpandableSetting setting, ExtendableData data)
        {
            var reqPlayerPlugin = CreateAndAddPlugin(setting, data) as IRequestPlayerPlugIn;
            if (reqPlayerPlugin != null)
            {
                testRunner.AddPlugIn(reqPlayerPlugin);
                if (reqPlayerPlugin.TestRunResults != null)
                    CurrentItem.PluginsResults.Add(reqPlayerPlugin.TestRunResults);
            }
            else
                MessageBox.Show(string.Format("{0} ({1}) is not a request player plugin", setting.DisplayName, setting.UniqueName), "Error");
        }


        private void SetupPlugins()
        {
            var tmpPluginInfo = TestProjectHost.Current.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.TimeLineViewer
                                                && pl.UniqueName == CurrentItem.TestRunDefinition.TimeLine.UniqueName);
            var timeLine = (ITimeLinePlugIn)CreateAndAddPlugin(tmpPluginInfo, CurrentItem.TestRunDefinition.TimeLine);
            if (timeLine.OnTimelineEvent != null)
                timeLineController.TimelineEvent += timeLine.OnTimelineEvent;
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
