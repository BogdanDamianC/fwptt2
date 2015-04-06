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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.Desktop.Util;
using fwptt.TestProject;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.App.UI
{
    public partial class ucExploreTestProject : UserControl
    {
        private TreeNode testDefinitions, testRunDefinitions;
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
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadTestDefinitionGenerationWizzards()
        {
            foreach (var wizzType in TestProjectHost.Current.TestDefinitionGeneratorWizzardTypes)
            {
                var descriptionAttr = wizzType.GetCustomAttributes(typeof(DescriptionAttribute), true);
                string description = descriptionAttr.Length > 0 ? ((DescriptionAttribute)descriptionAttr[0]).Description : wizzType.ToString();
                var menuItem = new ToolStripMenuItem(description) { Tag = wizzType };
                menuItem.Click += tstripNewTestDefinition_Click;
                tstripNewTestDefinition.DropDownItems.Add(menuItem);
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

        private TreeNode AddTestRunDefinition(TestRunDefinition testRunDefinition)
        {
            var td = new TreeNode(testRunDefinition.Name);
            td.Tag = testRunDefinition;
            td.ContextMenuStrip = ctxTestRunDefinitionItem;
            testRunDefinitions.Nodes.Add(td);
            return td;
        }

        public void RefreshProjectDetails()
        {
            tvProject.Nodes.Clear();
            testDefinitions = new TreeNode("Test Definitions");
            testDefinitions.ContextMenuStrip = ctxTestDefinition;
            foreach (var testDefinition in TestProjectHost.Current.Project.TestDefinitions)
                AddTestDefinition(testDefinition);
            testRunDefinitions = new TreeNode("Test Run Definitions");
            testRunDefinitions.ContextMenuStrip = ctxTestRunDefinition;
            foreach (var testRunDefinition in TestProjectHost.Current.Project.TestRunDefinitions)
                AddTestRunDefinition(testRunDefinition);
            tvProject.Nodes.Add(testDefinitions);
            tvProject.Nodes.Add(testRunDefinitions);
        }

        private void TryOpenCreateItem<T, I>(I item, Func<I, T> createFunction, EventHandler<I> onNameChanged = null)
            where T : Form, IItemEditor<I>
            where I : class
        {
            if (item == null)
                return;

            T editor = null;
            foreach (var frm in this.ParentForm.MdiChildren)
            {
                if ((editor = frm as T) == null)
                    continue;
                else if (editor.CurrentItem == item)
                {
                    editor.Activate();
                    return;
                }
            }
            editor = createFunction(item);
            editor.MdiParent = this.ParentForm;
            editor.Show();
            editor.Activate();
            if (onNameChanged != null)
                editor.onNameChanged += onNameChanged;
        }

        private static bool CanCreateNewItem()
        {
            var canCreateNewItem = !string.IsNullOrWhiteSpace(TestProjectHost.Current.ProjectPath);
            if (!canCreateNewItem)
                MessageBox.Show("Please save the Test Project first!", "Can't create a Test Definition");
            return canCreateNewItem;
        }


        private void tvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(e.Node.Tag as TestDefinition, (td) => new frmTestDefinitionSourceCodeEditor(td));
            tryOpenCreateItemTestRunDefinition(e.Node.Tag as TestRunDefinition);
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
                newTD = TestProjectHost.Current.AddTestProjectDefinitionCSharpCode(codeFileName, ret.GeneratedTestDefinitionClassCode);
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
            var newTD = TestProjectHost.Current.AddTestProjectDefinitionCSharpCode(className+".cs", string.Empty);
            AddTestDefinition(newTD);
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(newTD, (td) => new frmTestDefinitionSourceCodeEditor(td));
        }

        private void deleteTestDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var td = GetMenuClickTargetNodeValue<TestDefinition>(sender, TestDefininitionTreeviewSelectError);
            if (td == null || td.Item1 == null)
                return;
            if (TestProjectHost.Current.Project.TestRunDefinitions.Any(tr=>tr.TestDefinitionId == td.Item1.Id))
            {
                MessageBox.Show("Can't delete the current test definition it is being used by some test runs. Please connect the existing test runs to other test definitions or delete them before trying to delete this test definition.", "Alert");
                return;
            }
            TestProjectHost.Current.Project.TestDefinitions.Remove(td.Item1);
            testRunDefinitions.Nodes.Remove(td.Item2);
            //TODO delete the file
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var seltd = GetMenuClickTargetNodeValue<TestDefinition>(sender, TestDefininitionTreeviewSelectError);
            if (seltd == null)
                return;
            TryOpenCreateItem<frmTestDefinitionSourceCodeEditor, TestDefinition>(seltd.Item1, (td) => new frmTestDefinitionSourceCodeEditor(td));
        }
        #endregion

        #region TestRunDefinitions
        private const string TestRunDefininitionTreeviewSelectError = "Something went wrong the current selected node is not a test run definition.";


        private void tryOpenCreateItemTestRunDefinition(TestRunDefinition testRunDefinition)
        {
            TryOpenCreateItem<frmTestRunDefinition, TestRunDefinition>(testRunDefinition, (td) =>
            {
                var ftrd = new frmTestRunDefinition(td);
                ftrd.onNewRun +=  newTestRun;
                return ftrd;
            },
                testRunDefinitionEditor_onNameChanged);
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
            if (!TestProjectHost.Current.Project.TestDefinitions.Any())
            {
                MessageBox.Show(this, "Please create a Test Definition before creating a Test Run - the Test Run will be linked to a Test Definition", "Can't create a new Test Run");
                return;
            }
            var newTR = TestProjectHost.Current.NewTestProjectDefinitionTestRun();
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
            var trd = GetMenuClickTargetNodeValue<TestRunDefinition>(sender, TestRunDefininitionTreeviewSelectError);
            if (trd == null)
                return;
            TestProjectHost.Current.Project.TestRunDefinitions.Remove(trd.Item1);
            testRunDefinitions.Nodes.Remove(trd.Item2);
        }

        private void newTestRun(TestRunDefinition trd)
        {
            var runResults = new TestRunResults
            {
                Name = trd.Name + DateTime.Now.ToString(),
                TestRunDefinition = trd,
            }; //TODO the test run definition must be cloned
            TestProjectHost.Current.Project.TestRunsResults.Add(runResults);
            TryOpenCreateItem<frmTestRun, TestRunResults>(runResults, (td) => new frmTestRun(td));
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
    }
}
