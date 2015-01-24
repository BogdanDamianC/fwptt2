using System;

namespace fwptt.TestProject.Project
{
    public class TestRunResults
    {
        public string Name { get; set; }
        /// <summary>
        /// this is a copy down of the test run definition that was used initially
        /// the purpose of the copy down is to preserve the test definition detais unchanged after the run is donw the first time 
        /// </summary>
        public TestRunDefinition TestRunDefinition { get; set; }
        public string TestDefinitionFileUsed { get; set; }
        public string TestDefinitionCodeUsed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }    
}
