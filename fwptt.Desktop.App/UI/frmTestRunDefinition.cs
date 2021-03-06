﻿/*
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Desktop.Util;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.TimeLine;


namespace fwptt.Desktop.App.UI
{
    public partial class frmTestRunDefinition : Form, IItemEditor<TestRunDefinition>
    {
        public frmTestRunDefinition()
        {
            InitializeComponent();
        }

        public event EventHandler<TestRunDefinition> onNameChanged;
        public event Action<TestRunDefinition> onNewRun;

        public frmTestRunDefinition(TestRunDefinition  testRunDefinition):this()
        {
            SetUpTimeLinePlugins(testRunDefinition);
            SetUpRunPlugins(testRunDefinition);
            txtTestRunName.Text = testRunDefinition.Name;
            txtTestRunName.TextChanged += txtTestRunName_TextChanged;
            if (testRunDefinition.TestDefinitionId == Guid.Empty)
                testRunDefinition.TestDefinitionId = MainApplication.CurrentTestProjectHost.Project.TestDefinitions[0].Id;

            cboTestDefinition.ValueMember = "Id";
            cboTestDefinition.DisplayMember = "TestDefinitionFile";
            cboTestDefinition.DataSource = MainApplication.CurrentTestProjectHost.Project.TestDefinitions;
            cboTestDefinition.SelectedValue = testRunDefinition.TestDefinitionId;
            cboTestDefinition.SelectedValueChanged += (object sender, EventArgs e) =>
            {
                CurrentItem.TestDefinitionId = (Guid)cboTestDefinition.SelectedValue;
                CurrentItem.TestDefinitionOverridedPropertyValues.Clear();
                if (CurrentItem.TestDefinitionId != Guid.Empty)
                {
                    ucEditTestDefinitionValues.SetProperties(MainApplication.CurrentTestProjectHost.Project.TestDefinitions.First(td => td.Id == CurrentItem.TestDefinitionId).Properties, CurrentItem.TestDefinitionOverridedPropertyValues);
                }
                else
                {
                    this.CurrentItem.TestDataSourceId = null;
                    ucEditTestDefinitionValues.SetProperties(null, CurrentItem.TestDefinitionOverridedPropertyValues);
                }
            };
            CurrentItem = testRunDefinition;
            SetTitle();
            SetUpDataSources();
            if (MainApplication.CurrentTestProjectHost.Project.TestDefinitions.Any())
                ucEditTestDefinitionValues.SetProperties(MainApplication.CurrentTestProjectHost.Project.TestDefinitions.First(td => td.Id == testRunDefinition.TestDefinitionId).Properties, testRunDefinition.TestDefinitionOverridedPropertyValues);
        }

        private static Control CreateNewControlAndData(ExpandableSetting setting, ExtendableData data)
        {
            var tlpl = Activator.CreateInstance(setting.PluginType) as Control;
            if (tlpl == null)
                throw new ApplicationException(setting.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");
            ((ITestRunComponent)tlpl).CurrentData = data;
            return tlpl;
        }

        private Control CreateAndPositionNewControl(ExpandableSetting setting, ExtendableData data, Control parent, Point topLeft, int width)
        {
            var tlpl = CreateNewControlAndData(setting, data)  as Control;

            tlpl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            tlpl.Left = topLeft.X;
            tlpl.Top = topLeft.Y;
            tlpl.Width = width;
            tlpl.Visible = true;
            parent.Controls.Add(tlpl);
            parent.Height = tlpl.Bottom + 5;
            return tlpl;
        }

        #region Data Sources
        private void SetUpDataSources()
        {
            var tmpds = MainApplication.CurrentTestProjectHost.Project.TestDataSources.Select(ds => new { Id = ds.Id, Name = ds.Name }).ToList();
            tmpds.Insert(0, new { Id = Guid.Empty, Name = "No Data Source" });
            cboDataSource.ValueMember = "Id";
            cboDataSource.DisplayMember = "Name";
            cboDataSource.DataSource = tmpds;
            cboDataSource.SelectedValue = this.CurrentItem.TestDataSourceId.GetValueOrDefault(Guid.Empty);
            cboDataSource.SelectedValueChanged += (object sender, EventArgs e) =>
            {
                var sel = (Guid)cboDataSource.SelectedValue;
                CurrentItem.TestDataSourceId = sel!=Guid.Empty? (Guid?)sel:null;
            };
        }

        #endregion

        #region TimeLine
        private void SetUpTimeLineConfigurationControl()
        {
            var selectedTimelineConfiguration = MainApplication.CurrentTestProjectHost.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.TimeLineConfiguration
                                                && pl.UniqueName == (string)cboTimeLines.SelectedValue);
            foreach(var ctrl in grpTimeLine.Controls.Cast<Control>().Where(c => c != cboTimeLines))
            {
                grpTimeLine.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            var newTimelineConfigControl = (ITestRunComponent)CreateAndPositionNewControl(selectedTimelineConfiguration, CurrentItem.TimeLine, grpTimeLine, new Point(cboTimeLines.Left, cboTimeLines.Bottom + 10), cboTimeLines.Width);
            grpProperties.Height = Math.Max(grpTimeLine.Height, 120);
            CurrentItem.TimeLine = (BaseTestRunTimeLine)newTimelineConfigControl.CurrentData;
        }

        private void SetUpTimeLinePlugins(TestRunDefinition trd)
        {
            var timeLineConfigurationPlugins = (from pl in MainApplication.CurrentTestProjectHost.PluginTypes
                                                   where pl.ComponentType == ExpandableComponentType.TimeLineConfiguration
                                                   orderby pl.DisplayName
                                                   select pl).ToList();
            cboTimeLines.DisplayMember = "DisplayName";
            cboTimeLines.ValueMember = "UniqueName";
            cboTimeLines.DataSource = timeLineConfigurationPlugins;
            if (trd.TimeLine != null)
                cboTimeLines.SelectedValue = trd.TimeLine.UniqueName;
        }
        private void cboTimeLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentItem == null)
                return;
            SetDisplaySettings();
        }  
        #endregion

        private void SetDisplaySettings()
        {
            SetUpTimeLineConfigurationControl();
            grpPlugins.Top = grpProperties.Bottom + 5;
        }

        #region Plugins
        private ExpanderControl AddPlugin(ExpandableSetting setting, ExtendableData data)
        {
            var newPluginControl = new ExpanderControl();            
            newPluginControl.BorderStyle = BorderStyle.FixedSingle;
            newPluginControl.Width = accordionPlugins.Width = ckListPlugins.Width;
            ExpanderControl.CreateLabelHeader(newPluginControl, setting.DisplayName, SystemColors.ActiveBorder);
            newPluginControl.Content = CreateNewControlAndData(setting, data);
            accordionPlugins.Add(newPluginControl);            
            newPluginControl.Expand();
            return newPluginControl;
        }

        private void SetUpRunPlugins(TestRunDefinition trd)
        {
            if(trd.RunPlugins == null)
                trd.RunPlugins = new List<ExtendableData>();
            var dataSource = (from pl in MainApplication.CurrentTestProjectHost.PluginTypes
                              where pl.ComponentType == ExpandableComponentType.PluginConfiguration
                              orderby pl.DisplayName
                              select new { pl.DisplayName, isChecked = trd.RunPlugins.Any(pg => pg.UniqueName == pl.UniqueName), Data = pl}).ToList();
            ((ListBox)ckListPlugins).DataSource = dataSource;
            ((ListBox)ckListPlugins).DisplayMember = "DisplayName";
            ((ListBox)ckListPlugins).ValueMember = "isChecked";

            for (int i = 0; i < ckListPlugins.Items.Count; i++)
            {
                if (!dataSource[i].isChecked)
                    continue;
                var plugin = dataSource[i];
                ckListPlugins.SetItemChecked(i, plugin.isChecked);
                AddPlugin(dataSource[i].Data, trd.RunPlugins.First(pg => pg.UniqueName == plugin.Data.UniqueName));
            }

            ckListPlugins.ItemCheck += (object sender, ItemCheckEventArgs e) =>
            {
                var selectedType = dataSource[e.Index].Data.UniqueName;
                if (e.NewValue == CheckState.Checked && !CurrentItem.RunPlugins.Any(pl => pl.UniqueName == selectedType))
                    CurrentItem.RunPlugins.Add(((ITestRunComponent)AddPlugin(dataSource[e.Index].Data, null).Content).CurrentData);
                if (e.NewValue != CheckState.Checked)
                {
                    CurrentItem.RunPlugins.RemoveAll(pl => pl.UniqueName == selectedType);
                    foreach (var exp in accordionPlugins.Controls.Cast<ExpanderControl>().ToArray())
                        if (exp.Content.GetType() == dataSource[e.Index].Data.PluginType)
                        {
                            accordionPlugins.Controls.Remove(exp);
                            exp.Dispose();
                        }
                }
            };
        }

        private void accordionPlugins_Resize(object sender, EventArgs e)
        {
            grpPlugins.Height = accordionPlugins.Bottom + 5;
        }
        #endregion

        private void SetTitle()
        {
            this.Text = "Test Run Definition => " + (string.IsNullOrWhiteSpace(CurrentItem.Name) ? "[NEW]" : CurrentItem.Name);
        }

        void txtTestRunName_TextChanged(object sender, EventArgs e)
        {
            CurrentItem.Name = txtTestRunName.Text;
            SetTitle();
            onNameChanged?.Invoke(this, CurrentItem);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetDisplaySettings();
        }

        public TestRunDefinition CurrentItem { get; private set; }

        public void OnBeforeTestProjectSave()
        {
            //TODO
        }

        private void btnNewRun_Click(object sender, EventArgs e)
        {
            onNewRun?.Invoke(CurrentItem);
        }
    }
}
