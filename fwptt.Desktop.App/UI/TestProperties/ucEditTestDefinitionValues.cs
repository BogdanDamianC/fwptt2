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
using fwptt.Desktop.App.UI.TestProperties;

namespace fwptt.Desktop.App.UI
{
    public partial class ucEditTestDefinitionValues : UserControl
    {
        public ucEditTestDefinitionValues()
        {
            InitializeComponent();
        }

        private List<TestDefinitionProperty> properties;
        private List<TestDefinitionPropertyValue> overridedValues;

        private BindingList<TestDefinitionPropertyUIRecord> bindingList;
        public void SetProperties(List<TestDefinitionProperty> properties, List<TestDefinitionPropertyValue> overridedValues)
        {
            this.properties = properties;
            this.overridedValues = overridedValues;
            if (properties != null)
            {
                txtPropertyDefaultValue.Enabled = true;
                bindingList = new BindingList<TestDefinitionPropertyUIRecord>(
                    this.properties.Select(p => new TestDefinitionPropertyUIRecord(
                    p, this.overridedValues.FirstOrDefault(ov => ov.TestDefinitionPropertyId == p.Id))).ToList());
                lstBoxProperties.DataSource = bindingList;                
            }
            else
            {
                txtPropertyDefaultValue.Enabled = false;
                bindingList = new BindingList<TestDefinitionPropertyUIRecord>(new TestDefinitionPropertyUIRecord[0]);
                txtPropertyDefaultValue.Text = string.Empty;
            }

        }

        private void lstBoxProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = bindingList[lstBoxProperties.SelectedIndex];
            txtPropertyDefaultValue.Text = sel.OverridedValue != null ? sel.OverridedValue.Value : sel.Prop.DefaultValue;
        }

        private void txtPropertyDefaultValue_TextChanged(object sender, EventArgs e)
        {

            if (!txtPropertyDefaultValue.Enabled)
                return;
            var sel = bindingList[lstBoxProperties.SelectedIndex];
            if (txtPropertyDefaultValue.Text == sel.Prop.DefaultValue)
            {
                if (sel.OverridedValue != null)
                {
                    overridedValues.Remove(sel.OverridedValue);
                    sel.OverridedValue = null;
                }
            }
            else
            {
                if (sel.OverridedValue == null)
                {
                    sel.OverridedValue = new TestDefinitionPropertyValue
                    {
                        TestDefinitionPropertyId = sel.Prop.Id
                    };
                    overridedValues.Add(sel.OverridedValue);
                }
                sel.OverridedValue.Value = txtPropertyDefaultValue.Text;
            }
        }

    }
}
