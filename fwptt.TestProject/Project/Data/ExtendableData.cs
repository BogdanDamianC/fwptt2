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
    /// <summary>
    /// this abstract class is used for identifying all the data classes used by the plugins
    /// </summary>
    [JsonConverter(typeof(ExtendableDataJSONConverter))]
    public abstract class ExtendableData
    {
        public abstract string UniqueName { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract ExpandableDataType DataType { get; }
    }
}
