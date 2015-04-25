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

namespace fwptt.TestProject.Project
{
    public class TestDefinition
    {
        public TestDefinition() {
            Assemblies = new List<string>();
            Properties = new List<TestDefinitionProperty>();
        }
        public TestDefinition(string FileName):this()
        {
            Id = Guid.NewGuid();
            TestDefinitionFile = FileName;
            Assemblies.Add("System.dll");
            Assemblies.Add("System.Data.dll");
            Assemblies.Add("System.Xml.dll");
            Assemblies.Add("System.Core.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationStartupPathIdentifier + "fwptt.TestProject.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationPluginPathIdentifier + "RestSharp.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationPluginPathIdentifier + "CsQuery.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationPluginPathIdentifier + "fwptt.Web.HTTP.Test.dll");
        }
        public Guid Id { get; set; }
        public string TestDefinitionFile { get; set; }
        public List<string> Assemblies { get; set; }
        public List<TestDefinitionProperty> Properties { get; set; }
    }


}
