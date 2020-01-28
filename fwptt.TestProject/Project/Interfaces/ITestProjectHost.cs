using System;
using System.Collections.Generic;
using System.IO;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Run;

namespace fwptt.TestProject.Project.Interfaces
{
    public interface ITestProjectHost
    {
        string ProjectPath { get; set; }

        ExtendableData CreateExpandableTypeInstance(string dataType, string uniqueName);
        Type GetExpandableType(string dataType, string uniqueName);
        Type GetExpandableType(ExpandableDataType dataType, string uniqueName);
        string GetProjectRelatedFilePath(string fileName);

        IEnumerable<ExpandableSetting> PluginTypes { get; }

        void NewProject();
        TestProjectDefinition Project { get; }
        void LoadProject(string projectPath);

        void SaveProject();

        Type[] TestDefinitionGeneratorWizzardTypes { get; }

        TestRunDefinition NewTestProjectDefinitionTestRun();
        TestDefinition AddTestProjectDefinitionCSharpCode(string fileName, string CSharpCode);

        Type GetRunningTestType(TestRunResults testRunResults);
        Type GetRunningTestType(TestDefinition testDef);
        TestRunner GetTestRunner(TestRunResults testRunResults, ITimeLineController timeLineController);

        MemoryStream CreateMemoryAssembly(TestDefinition td);
        MemoryStream CreateMemoryAssembly(string sourceCode, IEnumerable<string> Assemblies);

        string GetTestProjectDefinitionCSharpCode(TestDefinition testDef);
    }
}