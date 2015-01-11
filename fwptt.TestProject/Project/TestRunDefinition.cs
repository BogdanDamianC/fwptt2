using System;
using System.Collections.Generic;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject.Project
{
    public class TestRunDefinition
    {
        public TestRunDefinition()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestDefinitionId { get; set; }
        public BaseTestRunTimeLine TimeLine { get; set; }
        public List<ExtendableData> RunPlugins { get; set; }
    }
}
