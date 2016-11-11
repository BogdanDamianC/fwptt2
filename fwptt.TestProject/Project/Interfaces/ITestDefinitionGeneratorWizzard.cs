using System.Collections.Generic;

namespace fwptt.TestProject.Project.Interfaces
{
    public interface ITestDefinitionGeneratorWizzard
    {
        string GeneratedTestDefinitionClassCode { get; }
        string GeneratedTestDefinitionClassName { get; }
        List<TestDefinitionProperty> Properties { get; }
    }
}
