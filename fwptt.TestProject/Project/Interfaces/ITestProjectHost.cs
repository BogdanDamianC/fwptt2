using System;
using fwptt.TestProject.Project.Data;

namespace fwptt.TestProject.Project.Interfaces
{
    public interface ITestProjectHost
    {
        string ProjectPath { get; }

        ExtendableData CreateExpandableTypeInstance(string dataType, string uniqueName);
        Type GetExpandableType(string dataType, string uniqueName);
        Type GetExpandableType(ExpandableDataType dataType, string uniqueName);
        string GetProjectRelatedFilePath(string fileName);
    }
}