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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject.Project.Data
{
    public class ExpandableSettingsAttribute : Attribute
    {
        public ExpandableSettingsAttribute(string uniqueName, string DisplayName, ExpandableComponentType type)
        {
            this.UniqueName = uniqueName;
            this.DisplayName = DisplayName;
            this.ComponentType = type;
        }
        public string UniqueName { get; set; }
        public string DisplayName { get; set; }
        public ExpandableComponentType ComponentType { get; set; }

        public ExpandableSetting GetSetting(Type PluginType)
        {
            return new ExpandableSetting
            {
                UniqueName = this.UniqueName,
                DisplayName = this.DisplayName,
                ComponentType = this.ComponentType,
                PluginType = PluginType
            };
        }
    }

    public class ExpandableSetting
    {
        public string UniqueName { get; internal set; }
        public string DisplayName { get; internal set; }
        public ExpandableComponentType ComponentType { get; internal set; }
        public Type PluginType { get; internal set; }
    }
}
