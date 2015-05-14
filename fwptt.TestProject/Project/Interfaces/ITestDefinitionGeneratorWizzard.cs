using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Project.Interfaces
{
    public interface ITestDefinitionGeneratorWizzard
    {
        string GeneratedTestDefinitionClassCode { get; }
        string GeneratedTestDefinitionClassName { get; }
        List<TestDefinitionProperty> Properties { get; }

    }
}
