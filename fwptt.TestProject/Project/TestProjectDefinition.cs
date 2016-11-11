﻿/*
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

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace fwptt.TestProject.Project
{
    public class TestProjectDefinition
    {
        public const string FileDialogFilter = "fwptt Test Project files (*.fwptt)|*.fwptt|All files (*.*)|*.*";
        public const string DefaultExtension = "fwptt";
        public const string ApplicationStartupPathIdentifier = "[fwptt_application_startuppath]";
        public const string ApplicationPluginPathIdentifier = "[fwptt_application_pluginpath]";
        public const string ProjectPathIdentifier = "[fwptt_project_path]";

        public TestProjectDefinition()
        {
            TestDefinitions = new List<TestDefinition>();
            TestDataSources = new List<BaseTestDataSource>();
            TestRunDefinitions = new List<TestRunDefinition>();
            TestRunsResults = new List<TestRunResults>();
        }

        public List<TestDefinition> TestDefinitions { get; set; }
        public List<BaseTestDataSource> TestDataSources { get; set; }
        public List<TestRunDefinition> TestRunDefinitions { get; set; }
        public List<TestRunResults> TestRunsResults { get; set; }


        public static TestProjectDefinition FromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                return JsonConvert.DeserializeObject<TestProjectDefinition>(file.ReadToEnd());
            }
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
