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
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using fwptt.Desktop.Util;
using fwptt.TestProject.Project;
using System.IO;

namespace fwptt.Desktop.App.UI
{
    /// <summary>
    /// Description of frmCompileAssembly.
    /// </summary>
    public partial class frmTestDefinitionSourceCodeEditor : Form, IItemEditor<TestDefinition>
	{
        private BindingList<string> assembliesBindingList;
		public frmTestDefinitionSourceCodeEditor()
		{
			InitializeComponent();
            txtCompileResults.Text = @"=======================================================================
Open the C# File and edit it in your favorite editor or IDE.
While this window is open it will watch and compile the file every
time you save it.
=======================================================================";
        }

        public frmTestDefinitionSourceCodeEditor(TestDefinition testDefinition ):this()
        {
            CurrentItem = testDefinition;
        }

        public event EventHandler<TestDefinition> onNameChanged;

        public void OnBeforeTestProjectSave()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            SetDataBindings();
            ShowEditorCursorPosition();
        }

        public TestDefinition CurrentItem { get; private set; }
        private void SetDataBindings()
        {
            Text = CurrentItem.TestDefinitionFile;
            assembliesBindingList = new BindingList<string>(CurrentItem.Assemblies);
            lstBoxAssemplies.DataSource = assembliesBindingList;
            txtAssembly.DataBindings.Add("Text", assembliesBindingList, null);
            txtFullFilePath.Text = MainApplication.CurrentTestProjectHost.GetProjectRelatedFilePath(CurrentItem.TestDefinitionFile);
            this.ucTestDefinitionProperties.SetProperties(CurrentItem.Properties);
            timerRecompilationTrigger.Enabled = true;
        }

        #region Source Code Events
        private void ShowEditorCursorPosition()
        {
            int CurrentLineStartCharindex = txtCompileResults.GetFirstCharIndexOfCurrentLine();
            int CurrentLine = txtCompileResults.GetLineFromCharIndex(CurrentLineStartCharindex);
            Statuslabel.Text = string.Format("Line : {0}    Column : {1}", new object[] { CurrentLine, txtCompileResults.SelectionStart - CurrentLineStartCharindex });
        }
        #endregion

        #region Assemblies & Code build
        void BtnAddAssemblyClick(object sender, EventArgs e)
		{
            if (assembliesBindingList.Any())
                assembliesBindingList.Add("");
            else
                assembliesBindingList.Add(txtAssembly.Text);
            this.BindingContext[assembliesBindingList].Position = assembliesBindingList.Count - 1;
		}
		
		void BtnDeleteAssemblyClick(object sender, EventArgs e)
		{                    
			if(lstBoxAssemplies.SelectedIndex >= 0)
                assembliesBindingList.RemoveAt(lstBoxAssemplies.SelectedIndex);
			if(lstBoxAssemplies.Items.Count < 0)
				txtAssembly.Text = string.Empty;
        }

        #endregion


        private void btnCompileCode_Click(object sender, EventArgs e)
        {
            CompileCode();
        }

        private void CompileCode()
        {
            string newMsg = "=======================================================================\r\n";
            newMsg += $"Compilation Start Time {DateTime.Now} \r\n";
            try
            {
                string sourceCode = MainApplication.CurrentTestProjectHost.GetTestProjectDefinitionCSharpCode(CurrentItem);
                MainApplication.CurrentTestProjectHost.CreateMemoryAssembly(sourceCode, CurrentItem.Assemblies);
                newMsg += "Succeeded! \r\n";
            }
            catch (Exception ex)
            {
                newMsg += "Failed ! \r\n" + ex.Message;
            }
            txtCompileResults.Text = newMsg + txtCompileResults.Text;
        }

        private DateTime lastModifiedFileTime = DateTime.MinValue;
        private void timerRecompilationTrigger_Tick(object sender, EventArgs e)
        {
            var fInfo = new FileInfo(txtFullFilePath.Text);
            if(fInfo.LastWriteTimeUtc != lastModifiedFileTime)
            {
                lastModifiedFileTime = fInfo.LastWriteTimeUtc;
                CompileCode();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtFullFilePath.Text);
        }
    }
}
