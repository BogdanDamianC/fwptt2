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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;

namespace fwptt.Console.DefaultPlugins
{
    /// <summary>
    /// helper class that implements the basic implementation for the setter
    /// </summary>
    public class BaseTestRunExecutionComponent<T> : ITestRunComponent where T : ExtendableData
    {
        private Type configurationDataType = null;
        public BaseTestRunExecutionComponent(): base()
        {
            var attributes = this.GetType().GetCustomAttributes(typeof(ExpandableSettingsAttribute), true);
            configurationDataType = TestProjectHost.GetExpandableType(ExpandableDataType.Configuration, ((ExpandableSettingsAttribute)attributes[0]).UniqueName);
        }

        private T lCurrentData;
        public ExtendableData CurrentData
        {
            get { return lCurrentData; }
            set
            {
                SetCurrentData((T)value);
            }
        }

        protected virtual void SetCurrentData(T data)
        {
            if (data == null)
                throw new ApplicationException("The "+ this.GetType() + " viewer was started with no data!");
            else if(data.GetType() != configurationDataType)
                throw new ApplicationException("The " + this.GetType() + " viewer was started with the wrong data!");
            lCurrentData = data;
        }
    }
}
