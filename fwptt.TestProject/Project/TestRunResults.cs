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
