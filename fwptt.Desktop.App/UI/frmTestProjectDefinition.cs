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
using System.Windows.Forms;
using fwptt.TestProject.Project;
using fwptt.Desktop.Util;
using fwptt.TestProject;

namespace fwptt.Desktop.App.UI
{
    public partial class frmTestProjectDefinition : Form
    {
        public frmTestProjectDefinition()
        {
            InitializeComponent();
        }

        private void SetTitle()
        {
            if (string.IsNullOrWhiteSpace( MainProvider.Current.ProjectPath))
                this.Text = "[New Test Project]";
            else 
                this.Text = MainProvider.Current.ProjectPath;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Icon = Icon.ExtractAssociatedIcon(this.GetType().Assembly.Location);
            SetTitle();
            this.exploreTestProject.RefreshProjectDetails();
            showExploreTestProjectToolStripMenuItem.Checked = true;
            if ( MainProvider.Current.ProjectPath != null)
            {
                SetTitle();
                this.exploreTestProject.RefreshProjectDetails();
            }
            else if(!string.IsNullOrWhiteSpace(MainApplication.CurrentUserContextData.LastAcessedProjectPath))
                LoadProject(MainApplication.CurrentUserContextData.LastAcessedProjectPath);
        }

        private void showExploreTestProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showExploreTestProjectToolStripMenuItem.Checked = !showExploreTestProjectToolStripMenuItem.Checked;
            exploreTestProject.Visible = splitterExplorer.Visible = showExploreTestProjectToolStripMenuItem.Checked;
        }

        private void newTestProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProvider.Current.NewProject();
            SetTitle();
            this.exploreTestProject.RefreshProjectDetails();
        }


        private bool LoadProject(string projectPath)
        {
            try
            {
                MainProvider.Current.LoadProject(projectPath);
                SetTitle();
                this.exploreTestProject.RefreshProjectDetails();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading the Project => " + ex.Message, "Error");
                return false;
            }
        }
        private void openTestProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projectFileName = UI_Util.PickOpenFile(this, TestProjectDefinition.FileDialogFilter);
            if (string.IsNullOrWhiteSpace(projectFileName))
                return;

            foreach (var c in this.MdiChildren)
                c.Close();
            if (LoadProject(projectFileName))
            {
                MainApplication.CurrentUserContextData.LastAcessedProjectPath = projectFileName;
                MainApplication.CurrentUserContextData.Save();
            }

        }

        private void saveTestProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (IItemEditor c in this.MdiChildren)
                c.OnBeforeTestProjectSave();

            SaveTestProject(string.IsNullOrWhiteSpace( MainProvider.Current.ProjectPath));
        }

        private void saveTestProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTestProject(true);
        }

        private void SaveTestProject(bool PickFileLocation)
        {
            if(PickFileLocation)
            {
                string newProjectPath = UI_Util.PickSaveFile(this, TestProjectDefinition.FileDialogFilter, TestProjectDefinition.DefaultExtension);
                if (string.IsNullOrWhiteSpace(newProjectPath))
                    return;
                MainProvider.Current.ProjectPath = newProjectPath;
            }
            try
            {
                MainProvider.Current.SaveProject();
                SetTitle();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Saving the project => " + ex.Message);
            }
        }
    }
}
