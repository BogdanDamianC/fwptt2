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

using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using System;
using System.Collections.Generic;

namespace fwptt.TestProject.Project
{
    public class TestRunResults
    {
        public TestRunResults()
        {
            PluginsResults = new List<ExtendableData>();
        }
        public string Name { get; set; }
        /// <summary>
        /// this is a copy down of the test run definition that was used initially
        /// the purpose of the copy down is to preserve the test definition detais unchanged after the run is donw the first time 
        /// </summary>
        public TestRunDefinition TestRunDefinition { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ExtendableData> PluginsResults { get; set; }
    }    
}
