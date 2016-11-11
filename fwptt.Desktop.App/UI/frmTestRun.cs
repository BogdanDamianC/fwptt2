/*
 * 
 * Namespace Summary
 * Copyright (C) 2007+ Bogdan Damian Constantin
 * WEB: http://fwptt.sourceforge.net/
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using fwptt.Desktop.Util;
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

        private bool SetupTestRunner()
        {
            timeLineController = CurrentItem.TestRunDefinition.TimeLine.GetNewController();

            try
            {
                this.testRunner = MainApplication.CurrentTestProjectHost.GetTestRunner(CurrentItem, timeLineController);
                this.testRunner.TestRunEnded += testRunner_TestsHaveFinished;
                return true;
            }
            catch (Exception ex)
            {
                btnAction.Enabled = false;
                string errorMessage = string.Empty;
                while (ex != null)
                {
                    errorMessage += ex.Message + "\r\n";
                    ex = ex.InnerException;
                }
                MessageBox.Show(errorMessage, "Error");
                return false;
            }
        }

        void btnAction_Click(object sender, EventArgs e)
        {
            if (timeLineController == null || !timeLineController.IsRunning)
            {
                btnAction.Text = "Stop";
                testRunner.StartTests();
                this.CurrentItem.StartTime = DateTime.Now;
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
            this.CurrentItem.EndTime = DateTime.Now;
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

        private static Control CreateNewControlAndData(ExpandableSetting setting, ExtendableData data)
        {
            var tlpl = Activator.CreateInstance(setting.PluginType) as Control;
            if (tlpl == null)
                throw new ApplicationException(setting.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");
            ((ITestRunComponent)tlpl).CurrentData = data;
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
                var savedTestResults = CurrentItem.PluginsResults.FirstOrDefault(pr => pr.UniqueName == setting.UniqueName);
                if (savedTestResults != null)
                    reqPlayerPlugin.TestRunResults = savedTestResults;
                else if (reqPlayerPlugin.TestRunResults != null)
                    CurrentItem.PluginsResults.Add(reqPlayerPlugin.TestRunResults);
            }
            else
                MessageBox.Show(string.Format("{0} ({1}) is not a request player plugin", setting.DisplayName, setting.UniqueName), "Error");
        }


        private void SetupPlugins()
        {
            var tmpPluginInfo = MainApplication.CurrentTestProjectHost.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.TimeLineViewer
                                                && pl.UniqueName == CurrentItem.TestRunDefinition.TimeLine.UniqueName);
            var timeLine = (ITimeLinePlugIn)CreateAndAddPlugin(tmpPluginInfo, CurrentItem.TestRunDefinition.TimeLine);
            if (timeLine.OnTimelineEvent != null)
                timeLineController.TimelineEvent += timeLine.OnTimelineEvent;
            foreach(var plugin in CurrentItem.TestRunDefinition.RunPlugins)
            {
                tmpPluginInfo = MainApplication.CurrentTestProjectHost.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.Plugin
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
