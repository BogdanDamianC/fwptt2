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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject;


namespace fwptt.Desktop.App.UI
{
    public partial class frmTestRunDefinition : Form, UI.IItemEditor<TestRunDefinition>
    {
        public frmTestRunDefinition()
        {
            InitializeComponent();
        }

        public event EventHandler<TestRunDefinition> onNameChanged;

        Dictionary<string, ITestRunConfigurationComponent> timeLinePlugins = new Dictionary<string,ITestRunConfigurationComponent>();
        public frmTestRunDefinition(TestRunDefinition  trd):this()
        {
            SetUpTimeLinePlugins(trd);
            SetUpRunPlugins(trd);
            txtTestRunName.Text = trd.Name;
            txtTestRunName.TextChanged += txtTestRunName_TextChanged;
            if (trd.TestDefinitionId == Guid.Empty)
                trd.TestDefinitionId = TestProjectHost.Current.Project.TestDefinitions[0].Id;
            cboTestDefinition.ValueMember = "Id";
            cboTestDefinition.DisplayMember = "TestDefinitionFile";
            cboTestDefinition.DataSource = TestProjectHost.Current.Project.TestDefinitions;
            cboTestDefinition.DataBindings.Add("SelectedValue", trd, "TestDefinitionId");
            CurrentItem = trd;
            SetTitle();
        }

        private void SetUpTimeLinePlugins(TestRunDefinition trd)
        {
            var timeLineConfigurationPlugins = (from pl in TestProjectHost.Current.PluginTypes
                                                   where pl.ComponentType == ExpandableComponentType.TimeLineConfiguration
                                                   orderby pl.DisplayName
                                                   select pl).ToList();
            
            
            foreach(var confPL in timeLineConfigurationPlugins)
            {
                var tlpl = Activator.CreateInstance(confPL.PluginType) as Control;
                if (tlpl == null)
                    throw new ApplicationException(confPL.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");

                timeLinePlugins[confPL.UniqueName] = (ITestRunConfigurationComponent)tlpl;
                tlpl.Dock = DockStyle.Top;
                pluginsPanel.Controls.Add(tlpl, 0, 0);

                if (trd.TimeLine != null && trd.TimeLine.UniqueName == confPL.UniqueName)
                    ((ITestRunConfigurationComponent)tlpl).SetConfiguration(trd.TimeLine);
            }
            cboTimeLines.DisplayMember = "DisplayName";
            cboTimeLines.ValueMember = "UniqueName";
            cboTimeLines.DataSource = timeLineConfigurationPlugins;
            if (trd.TimeLine != null)
                cboTimeLines.SelectedValue = trd.TimeLine.UniqueName;
        }

        private void SetUpRunPlugins(TestRunDefinition trd)
        {
            if(trd.RunPlugins == null)
                trd.RunPlugins = new List<ExtendableData>();
            var dataSource = (from pl in TestProjectHost.Current.PluginTypes
                              where pl.ComponentType == ExpandableComponentType.PluginConfiguration
                              orderby pl.DisplayName
                              select new { pl.UniqueName, pl.DisplayName, isChecked = trd.RunPlugins.Any(pg => pg.UniqueName == pl.UniqueName), pl.PluginType }).ToList();
            ((ListBox)ckListPlugins).DataSource = dataSource;
            ((ListBox)ckListPlugins).DisplayMember = "DisplayName";
            ((ListBox)ckListPlugins).ValueMember = "isChecked";
            ckListPlugins.ItemCheck += (object sender, ItemCheckEventArgs e) =>
            {
                var selectedType = dataSource[e.Index].UniqueName;
                //if (e.NewValue == CheckState.Checked && !CurrentItem.RunPlugins.Any(pl => pl.UniqueName == selectedType))
                //    CurrentItem.RunPlugins.Add(selectedType);
                if (e.NewValue != CheckState.Checked)
                    CurrentItem.RunPlugins.RemoveAll(pl=> pl.UniqueName == selectedType);
            };
        }

        private void SetTitle()
        {
            this.Text = "Test Run Definition => " + (string.IsNullOrWhiteSpace(CurrentItem.Name) ? "[NEW]" : CurrentItem.Name);
        }

        void txtTestRunName_TextChanged(object sender, EventArgs e)
        {
            CurrentItem.Name = txtTestRunName.Text;
            SetTitle();
            if (onNameChanged != null)
                onNameChanged(this, CurrentItem);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetDisplaySettings();
        }

        public TestRunDefinition CurrentItem { get; private set; }

        private void SetDisplaySettings()
        {
            foreach (Control control in pluginsPanel.Controls)
                control.Visible = false;
            var selectedTimeline = (Control)timeLinePlugins[(string)cboTimeLines.SelectedValue];
            selectedTimeline.Visible =true;
            selectedTimeline.BringToFront();
        }

        private void cboTimeLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentItem == null)
                return;

            var selectedTimeLine = timeLinePlugins[(string)cboTimeLines.SelectedValue];
            selectedTimeLine.SetConfiguration(CurrentItem.TimeLine);
            CurrentItem.TimeLine = (BaseTestRunTimeLine)selectedTimeLine.GetConfiguration();
            SetDisplaySettings();
        }        
    }
}
