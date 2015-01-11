using System;

namespace fwptt.TestProject.Project
{
    public class TestRunResults
    {
        public Guid TestRunDefinitionId { get; set; }
        public string TestRunDefinitionName { get; set; }
        public string TestDefinitionFileUsed { get; set; }
        public string TestDefinitionCodeUsed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }    
}
