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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using fwptt.Desktop.Util;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.App.UI
{
    public partial class ucExploreTestProject : UserControl
    {
        private TreeNode testDefinitions, testDataSources, testRunDefinitions, testRunResults;
        public ucExploreTestProject()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            LoadTestDefinitionGenerationWizzards();
            LoadSupportedDataSourceTypes();
        }

        /// <summary>
        /// Loads all the Wizzards for generating C# test code
        /// </summary>
        private void LoadTestDefinitionGenerationWizzards()
        {
            foreach (var wizzType in MainApplication.CurrentTestProjectHost.TestDefinitionGeneratorWizzardTypes)
            {
                var descriptionAttr = wizzType.GetCustomAttributes(typeof(DescriptionAttribute), true);
                string description = descriptionAttr.Length > 0 ? ((DescriptionAttribute)descriptionAttr[0]).Description : wizzType.ToString();
                var menuItem = new ToolStripMenuItem(description) { Tag = wizzType };
                menuItem.Click += tstripNewTestDefinition_Click;
                tstripNewTestDefinition.DropDownItems.Add(menuItem);
            }
        }

        private void LoadSupportedDataSourceTypes()
        {
            foreach (var dst in MainApplication.CurrentTestProjectHost.PluginTypes.Where(pl => pl.ComponentType == ExpandableComponentType.DataSourceConfiguration))
            {
                var menuItem = new ToolStripMenuItem(dst.DisplayName) { Tag = dst };
                menuItem.Click += tStripMenuItemNewTestDataSource_Click;
                tStripMenuItemNewTestDataSource.DropDownItems.Add(menuItem);
            }
        }


        private TreeNode AddTestDefinition(TestDefinition testDefinition)
        {
            var td = new TreeNode(testDefinition.TestDefinitionFile);
            td.Tag = testDefinition;
            td.ContextMenuStrip = ctxTestDefinitionItem;
            testDefinitions.Nodes.Add(td);
            return td;
        }

        private TreeNode AddTestDataSource(BaseTestDataSource testDataSource)
        {
            var td = new TreeNode(testDataSource.Name);
            td.Tag = testDataSource;
            td.ContextMenuStrip = ctxTestDataSourceItem;
            testDataSources.Nodes.Add(td);
            return td;
        }

        private TreeNode AddTestRunDefinition(TestRunDefinition testRunDefinition)
        {
            var td = new TreeNode(testRunDefinition.Name);
            td.Tag = testRunDefinition;
            td.ContextMenuStrip = ctxTestRunDefinitionItem;
            testRunDefinitions.Nodes.Add(td);
            return td;
        }

        private TreeNode AddTestRunResult(TestRunResults testRunResult)
        {
            var td = new TreeNode(testRunResult.Name);
            td.Tag = testRunResult;
            td.ContextMenuStrip = ctxTestResultsItem;
            testRunResults.Nodes.Add(td);
            return td;
        }

        public void RefreshProjectDetails()
        {
            tvProject.Nodes.Clear();
            testDefinitions = new TreeNode("Test Definitions");
            testDefinitions.ContextMenuStrip = ctxTestDefinition;
            foreach (var testDefinition in MainApplication.CurrentTestProjectHost.Project.TestDefinitions)
                AddTestDefinition(testDefinition);

            testDataSources = new TreeNode("Test Data Sources");
            testDataSources.ContextMenuStrip = ctxTestDataSource;
            foreach (var testDataSource in MainApplication.CurrentTestProjectHost.Project.TestDataSources)
                AddTestDataSource(testDataSource);

            testRunDefinitions = new TreeNode("Test Run Definitions");
            testRunDefinitions.ContextMenuStrip = ctxTestRunDefinition;
            foreach (var testRunDefinition in MainApplication.CurrentTestProjectHost.Project.TestRunDefinitions)
                AddTestRunDefinition(testRunDefinition);

            testRunResults = new TreeNode("Test Run Results");
            foreach (var testRunResult in MainApplication.CurrentTestProjectHost.Project.TestRunsResults)
                AddTestRunResult(testRunResult);

            tvProject.Nodes.Add(testDefinitions);
            tvProject.Nodes.Add(testDataSources);
            tvProject.Nodes.Add(testRunDefinitions);
            tvProject.Nodes.Add(testRunResults);
        }

        private T GetEditor<T, I>(I item)
            where T : Form, IItemEditor<I>
            where I : class
        {
            T editor = null;
            foreach (var frm in this.ParentForm.MdiChildren)
            {
                if ((editor = frm as T) == null)
                    continue;
                else if (editor.CurrentItem == item)
                    return editor;
            }
            return null;
        }

        private void TryOpenCreateItem<T, I>(I item, Func<I, T> createFunction, EventHandler<I> onNameChanged = null)
            where T : Form, IItemEditor<I>
            where I : class
        {
            if (item == null)
                return;

            T editor = GetEditor<T, I>(item);
            if (editor != null)
                editor.Activate();
            else
            {
                editor = createFunction(item);
                SetupAndDisplayForm<T, I>(editor, onNameChanged);
            }
        }

        private void SetupAndDisplayForm<T, I>(T editor, EventHandler<I> onNameChanged = null)
            where T : Form, IItemEditor<I>
            where I : class
        {
            editor.MdiParent = this.ParentForm;
            editor.Show();
            editor.Activate();
            if (onNameChanged != null)
                editor.onNameChanged += onNameChanged;
        }

        /// <summary>
        /// removes the item from the tree node and the collection + it closes the edit window if it is open 
        /// </summary>
        /// <typeparam name="T">Form Type</typeparam>
        /// <typeparam name="I">typeof the entity that the form is working with</typeparam>
        /// <param name="sender">the sender object from the tree view event</param>
        /// <param name="topTreeNode">top node from which the item should be removed</param>
        /// <param name="collection">the collection of items from which the item should be removed</param>
        /// <param name="nodeNotFoundError">error message for the case when for some reason the</param>
        /// <param name="checkBeforeDelete">a function that can be used to do various checks before the item is deleted if it returns false the item will not e deleted</param>
        private void RemoveItem<T, I>(object sender, TreeNode topTreeNode, List<I> collection, string nodeNotFoundError,
            Func<I, bool> checkBeforeDelete = null)
            where T : Form, IItemEditor<I>
            where I : class
        {

            var dts = GetMenuClickTargetNodeValue<I>(sender, nodeNotFoundError);
            if (dts == null)
                return;
            if (checkBeforeDelete != null && !checkBeforeDelete(dts.Item1))
                return;
                
            var editor = GetEditor<T, I>(dts.Item1);
            if (editor != null)
            {
                editor.Close();
                editor.Dispose();
            }
            collection.Remove(dts.Item1);
            topTreeNode.Nodes.Remove(dts.Item2);
        }

        private static bool CanCreateNewItem()
        {
            var canCreateNewItem = !string.IsNullOrWhiteSpace(MainApplication.CurrentTestProjectHost.ProjectPath);
            if (!canCreateNewItem)
                MessageBox.Show("Please save the Test Project first!", "Can't create a Test Definition");
            return canCreateNewItem;
        }


        private void tvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(e.Node.Tag as TestDefinition, (td) => new frmTestDefinitionSourceCodeEditor(td));
            tryOpenCreateItemTestRunDefinition(e.Node.Tag as TestRunDefinition);
            TryOpenTestDataSource(e.Node.Tag as BaseTestDataSource, e.Node);   
        }

        private Tuple<T,TreeNode> GetMenuClickTargetNodeValue<T>(object sender, string errorMessageWhenEmpty) where T : class
        {
            var menu = sender as ToolStripMenuItem;
            if (menu == null)
                return null;
            var hitTest = tvProject.HitTest(tvProject.PointToClient(new Point(menu.GetCurrentParent().Left, menu.GetCurrentParent().Top)));
            var node = hitTest.Node ?? tvProject.SelectedNode;
            var ret = node != null ? node.Tag as T : (T)null;
            if (ret == null && !string.IsNullOrWhiteSpace(errorMessageWhenEmpty))
            {
                MessageBox.Show(errorMessageWhenEmpty, "Error");
                return null;
            }
            return new Tuple<T,TreeNode>(ret, node);
        }

        #region Test Definition
        private const string TestDefininitionTreeviewSelectError = "Something went wrong the current selected node is not a test definition.";
        private void tstripNewTestDefinition_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewItem())
                return;
            TestDefinition newTD = null;
            using (var generator = (Form)Activator.CreateInstance((Type)((ToolStripMenuItem)sender).Tag))
            {
                generator.ShowDialog(this);
                var ret = (ITestDefinitionGeneratorWizzard)generator;
                if (string.IsNullOrWhiteSpace(ret.GeneratedTestDefinitionClassCode)
                    || string.IsNullOrWhiteSpace(ret.GeneratedTestDefinitionClassName))
                    return;
                string codeFileName = ret.GeneratedTestDefinitionClassName + ".cs";
                newTD = MainApplication.CurrentTestProjectHost.AddTestProjectDefinitionCSharpCode(codeFileName, ret.GeneratedTestDefinitionClassCode);
                if (ret.Properties != null && ret.Properties.Any())
                    newTD.Properties.AddRange(ret.Properties);
            }
            AddTestDefinition(newTD);
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(newTD, (td) => new frmTestDefinitionSourceCodeEditor(td));
        }

        private void tsiNewBlankCSFile_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewItem())
                return;
            string className = string.Empty;
            if (UI_Util.InputBox("New Test Definition", "Please enter the class name (.cs extension will be addded at the end)", ref className) != DialogResult.OK
                || string.IsNullOrWhiteSpace(className))
                return;
            var newTD = MainApplication.CurrentTestProjectHost.AddTestProjectDefinitionCSharpCode(className + ".cs", string.Empty);
            AddTestDefinition(newTD);
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(newTD, (td) => new frmTestDefinitionSourceCodeEditor(td));
        }

        private void deleteTestDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(sender, testRunDefinitions,
                MainApplication.CurrentTestProjectHost.Project.TestDefinitions, TestDefininitionTreeviewSelectError,
                (TestDefinition td) =>
                {
                    if (MainApplication.CurrentTestProjectHost.Project.TestRunDefinitions.Any(tr => tr.TestDefinitionId == td.Id))
                    {
                        MessageBox.Show("Can't delete the current test definition it is being used by some test runs. Please connect the existing test runs to other test definitions or delete them before trying to delete this test definition.", "Alert");
                        return false;
                    }
                    //TODO delete the file
                    return true;
                });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var seltd = GetMenuClickTargetNodeValue<TestDefinition>(sender, TestDefininitionTreeviewSelectError);
            if (seltd == null)
                return;
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(seltd.Item1, (td) => new frmTestDefinitionSourceCodeEditor(td));
        }
        #endregion

        #region DataSource Events
        private void tStripMenuItemNewTestDataSource_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewItem())
                return;
            var dst = (ExpandableSetting)((ToolStripMenuItem)sender).Tag;
            var newForm = new frmTestDatasourceDefinition(dst);
            var tnDS = this.AddTestDataSource(newForm.CurrentItem);
            MainApplication.CurrentTestProjectHost.Project.TestDataSources.Add(newForm.CurrentItem);
            SetupAndDisplayForm<frmTestDatasourceDefinition, BaseTestDataSource>(newForm, (object tmpSnd, BaseTestDataSource eds) =>
            {
                tnDS.Text = newForm.CurrentItem.Name;
            });

        }

        private void TryOpenTestDataSource(BaseTestDataSource ds, TreeNode node)
        {
            if (ds == null)
                return;
            TryOpenCreateItem<frmTestDatasourceDefinition, BaseTestDataSource>(ds,
                (td) => { return new frmTestDatasourceDefinition(td); }, (object tmpSnd, BaseTestDataSource eds) =>
                {
                    node.Text = eds.Name;
                });
        }

        private void tStripMenuItemOpenTestDataSource_Click(object sender, EventArgs e)
        {
            var dts = GetMenuClickTargetNodeValue<BaseTestDataSource>(sender, TestRunDefininitionTreeviewSelectError);
            if (dts == null)
                return;
            TryOpenTestDataSource(dts.Item1, dts.Item2);
        }

        private void tStripMenuItemDeleteTestDataSource_Click(object sender, EventArgs e)
        {
            RemoveItem<frmTestDatasourceDefinition, BaseTestDataSource>(sender, testDataSources,
                MainApplication.CurrentTestProjectHost.Project.TestDataSources, "Ooops something went wrong, could notfind the datasource anymore",
                (BaseTestDataSource ds) =>
                {
                    bool isInUse = MainApplication.CurrentTestProjectHost.Project.TestRunDefinitions.Any(trd => trd.TestDataSourceId.HasValue && trd.TestDataSourceId.Value == ds.Id);
                    if (isInUse)
                        MessageBox.Show("Datasource is in use, please update the test Run definitions first before deleting it");
                    return !isInUse;
                });
        }
        #endregion

        #region TestRunDefinitions
        private const string TestRunDefininitionTreeviewSelectError = "Something went wrong the current selected node is not a test run definition.";

        private void tryOpenCreateItemTestRunDefinition(TestRunDefinition testRunDefinition)
        {
            TryOpenCreateItem(testRunDefinition, (td) =>
            {
                var ftrd = new frmTestRunDefinition(td);
                ftrd.onNewRun +=  newTestRun;
                return ftrd;
            }, testRunDefinitionEditor_onNameChanged);
        }

        private void testRunDefinitionEditor_onNameChanged(object sender, TestRunDefinition e)
        {
            foreach (TreeNode node in this.testRunDefinitions.Nodes)
                if (node.Tag == e)
                    node.Text = e.Name;
        }

        private void newTestRunDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewItem())
                return;
            if (!MainApplication.CurrentTestProjectHost.Project.TestDefinitions.Any())
            {
                MessageBox.Show(this, "Please create a Test Definition before creating a Test Run - the Test Run will be linked to a Test Definition", "Can't create a new Test Run");
                return;
            }
            var newTR = MainApplication.CurrentTestProjectHost.NewTestProjectDefinitionTestRun();
            AddTestRunDefinition(newTR);
            tryOpenCreateItemTestRunDefinition(newTR);
        }

        private void openTestRunDefinitionStripMenuItem_Click(object sender, EventArgs e)
        {
            var trd = GetMenuClickTargetNodeValue<TestRunDefinition>(sender, TestRunDefininitionTreeviewSelectError);
            if (trd == null)
                return;
            tryOpenCreateItemTestRunDefinition(trd.Item1);
        }

        private void deleteTestRunDefinitionStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItem<frmTestRunDefinition, TestRunDefinition>(sender, testRunDefinitions, 
                MainApplication.CurrentTestProjectHost.Project.TestRunDefinitions, TestRunDefininitionTreeviewSelectError);
        }

        private void newTestRun(TestRunDefinition trd)
        {
            var runResults = new TestRunResults(trd, MainApplication.CurrentTestProjectHost.Project.TestDefinitions.First(td=>td.Id == trd.TestDefinitionId));
            MainApplication.CurrentTestProjectHost.Project.TestRunsResults.Add(runResults);
            var treeNode = AddTestRunResult(runResults);
            TryOpenCreateItem<frmTestRun, TestRunResults>(runResults, (td) => new frmTestRun(td),
                (object sender, TestRunResults trr) => { treeNode.Text = trr.Name; });
            treeNode.Parent.Expand();
            this.tvProject.SelectedNode = treeNode;
        }

        private void newRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewItem())
                return;
            var trd = GetMenuClickTargetNodeValue<TestRunDefinition>(sender, TestRunDefininitionTreeviewSelectError);
            if (trd == null)
                return;
            newTestRun(trd.Item1);
        }
        #endregion

        private void tStripMenuItemOpenTestResults_Click(object sender, EventArgs e)
        {
            var runResults = GetMenuClickTargetNodeValue<TestRunResults>(sender, TestRunDefininitionTreeviewSelectError);
            TryOpenCreateItem(runResults.Item1, (td) => new frmTestRun(td),
                (object tmpsender, TestRunResults trr) => { runResults.Item2.Text = trr.Name; });
        }

        private void tStripMenuItemDeleteTestResults_Click(object sender, EventArgs e)
        {
            RemoveItem<frmTestRun, TestRunResults>(sender, testRunResults,
                MainApplication.CurrentTestProjectHost.Project.TestRunsResults, TestRunDefininitionTreeviewSelectError);
        }
    }
}
