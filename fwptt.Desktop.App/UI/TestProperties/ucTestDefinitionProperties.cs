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
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project;

namespace fwptt.Desktop.App.UI
{
    public partial class ucTestDefinitionProperties : UserControl
    {
        public ucTestDefinitionProperties()
        {
            InitializeComponent();
            lblDescription.Text = "General Properties that can be used inside the C# code using the TestProperties[\"PropertyName\"] index. These properties can be overidded for each Test Run Definition in case you have to do something different for a specific test.";
        }

        private List<TestDefinitionProperty> properties;
        private BindingList<TestDefinitionProperty> bindingList;
        public void SetProperties(List<TestDefinitionProperty> properties)
        {
            this.properties = properties;
            bindingList = new BindingList<TestDefinitionProperty>(this.properties);
            lstBoxProperties.DataSource = bindingList;
            txtPropertyName.DataBindings.Add("Text", bindingList, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPropertyDefaultValue.DataBindings.Add("Text", bindingList, "DefaultValue", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bindingList.Add(new TestDefinitionProperty(Guid.NewGuid()));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBoxProperties.SelectedIndex >= 0)
                bindingList.RemoveAt(lstBoxProperties.SelectedIndex);
            if (lstBoxProperties.Items.Count < 0)
                txtPropertyName.Text = txtPropertyDefaultValue.Text = string.Empty;
        }
    }
}
