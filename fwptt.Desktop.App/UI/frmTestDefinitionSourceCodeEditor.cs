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
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Linq;
using System.ComponentModel;
using Microsoft.CSharp;
using fwptt.Desktop.Util;
using fwptt.TestProject.Project;
using fwptt.TestProject;

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
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			

		}

        public frmTestDefinitionSourceCodeEditor(TestDefinition testDefinition ):this()
        {
            CurrentItem = testDefinition;
        }

        public event EventHandler<TestDefinition> onNameChanged;

        public void OnBeforeTestProjectSave()
        {
            btnSaveSourceCode_Click(this, EventArgs.Empty);
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
            txtSourceCode.Text = MainApplication.Current.GetTestProjectDefinitionCSharpCode(CurrentItem);
            this.ucTestDefinitionProperties.SetProperties(CurrentItem.Properties);
        }

        #region Source Code Events
        private void ShowEditorCursorPosition()
        {
            int CurrentLineStartCharindex = txtSourceCode.GetFirstCharIndexOfCurrentLine();
            int CurrentLine = txtSourceCode.GetLineFromCharIndex(CurrentLineStartCharindex);
            Statuslabel.Text = string.Format("Line : {0}    Column : {1}", new object[] { CurrentLine, txtSourceCode.SelectionStart - CurrentLineStartCharindex });
        }

        private void txtSourceCode_SelectionChanged(object sender, EventArgs e)
        {
            ShowEditorCursorPosition();
        }


        private void btnSaveSourceCode_Click(object sender, EventArgs e)
        {
            try
            {
                MainApplication.Current.SaveTestProjectDefinitionCSharpCode(CurrentItem, txtSourceCode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
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

        void BtnCompileCodeClick(object sender, EventArgs e)
        {
            try
            {
                MainApplication.Current.CreateMemoryAssembly(txtSourceCode.Text, CurrentItem.Assemblies);
                txtCompileResults.Text = "Compilation succeeded!";
            }
            catch (Exception ex)
            {
                txtCompileResults.Text = ex.Message;
            }
        }
        #endregion


	}
}
