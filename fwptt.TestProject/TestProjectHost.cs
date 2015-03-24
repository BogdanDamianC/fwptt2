﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using fwptt.TestProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;

namespace fwptt.TestProject
{
    public class TestProjectHost:IDisposable
    {
        public static TestProjectHost Current { get; private set; }

        public static void Initialize(string ApplicationStartupPath, string PluginsPath)
        {
            Current = new TestProjectHost(ApplicationStartupPath, PluginsPath);
        }

        private string ApplicationStartupPath;
        private string PluginsPath;

        public Type[] TestDefinitionGeneratorWizzardTypes { get; private set; }
        public ExpandableSetting[] PluginTypes { get; private set; }
        private Dictionary<string, Type> expandableData = new Dictionary<string, Type>();

        public TestProjectHost(string ApplicationStartupPath, string PluginsPath)
        {
            this.ApplicationStartupPath = ApplicationStartupPath;
            this.PluginsPath = PluginsPath;
            SearchForPlugInTypes();
            NewProject();
        }

        public TestProjectDefinition Project { get; set; }
        public string ProjectPath { get; set; }

        public void NewProject()
        {
            ProjectPath = null;
            Project = new TestProjectDefinition();
        }

        public void LoadProject(string projectPath)
        {
            Project = TestProjectDefinition.FromFile(projectPath);
            ProjectPath = projectPath;
        }

        public void SaveProject()
        {
            Project.Save(ProjectPath);
        }

        public KeyValuePair<string, string>[] GetReferencePaths()
        {
            return new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string,string>(TestProjectDefinition.ApplicationStartupPathIdentifier,ApplicationStartupPath + Path.DirectorySeparatorChar),
                new KeyValuePair<string,string>(TestProjectDefinition.ProjectPathIdentifier,GetProjectRelatedFilePath(string.Empty))
            };
        }

        private string GetProjectRelatedFilePath(string fileName)
        {
            var projectFileInfo = new FileInfo(ProjectPath);
            return projectFileInfo.DirectoryName + Path.DirectorySeparatorChar + fileName;
        }

        public TestDefinition AddTestProjectDefinitionCSharpCode(string fileName, string GeneratedTestDefinitionClassCode)
        {
            SaveTestProjectDefinitionCSharpCode(fileName, GeneratedTestDefinitionClassCode);
            var newTD = new TestDefinition(fileName);
            Project.TestDefinitions.Add(newTD);
            return newTD;
        }

        public void SaveTestProjectDefinitionCSharpCode(string fileName, string GeneratedTestDefinitionClassCode)
        {
            File.WriteAllText(GetProjectRelatedFilePath(fileName), GeneratedTestDefinitionClassCode);
        }

        public void SaveTestProjectDefinitionCSharpCode(TestDefinition testDef, string GeneratedTestDefinitionClassCode)
        {
            SaveTestProjectDefinitionCSharpCode(testDef.TestDefinitionFile, GeneratedTestDefinitionClassCode);
        }

        public string GetTestProjectDefinitionCSharpCode(TestDefinition testDef)
        {
            return File.ReadAllText(GetProjectRelatedFilePath(testDef.TestDefinitionFile));
        }

        public TestRunDefinition NewTestProjectDefinitionTestRun()
        {
            var newTR = new TestRunDefinition
            {
                TestDefinitionId = Project.TestDefinitions[0].Id
            };
            Project.TestRunDefinitions.Add(newTR);
            return newTR;
        }

        public System.Reflection.Assembly CreateMemoryAssembly(TestDefinition td)
        {
            return CreateMemoryAssembly(GetTestProjectDefinitionCSharpCode(td), td.Assemblies);
        }

        public System.Reflection.Assembly CreateMemoryAssembly(string sourceCode, List<string> Assemblies)
        {
            if (sourceCode.Trim().Length == 0)
                throw new ApplicationException("There is no C# code for this test!");

            KeyValuePair<string, string>[] referencePaths = GetReferencePaths();
            string[] referenceAssemblies = new string[Assemblies.Count];
            for (int i = 0; i < referenceAssemblies.Length; i++)
            {
                referenceAssemblies[i] = Assemblies[i];
                foreach (var refPath in referencePaths)
                    referenceAssemblies[i] = referenceAssemblies[i].Replace(refPath.Key, refPath.Value);
            }

            // disable once SuggestUseVarKeywordEvident
            var myCompilerParameters = new CompilerParameters(referenceAssemblies);
            myCompilerParameters.GenerateExecutable = false;
            myCompilerParameters.GenerateInMemory = true;

            var myCodeProvider = new CSharpCodeProvider();
            CompilerResults cr = myCodeProvider.CompileAssemblyFromSource(myCompilerParameters, new string[] { sourceCode });
            if (cr.Errors.Count > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (CompilerError err in cr.Errors)
                {
                    sb.Append(err);
                    sb.Append(Environment.NewLine);
                }
                throw new ApplicationException("CompilationError => " + Environment.NewLine + sb.ToString());
            }
            else
            {
                return cr.CompiledAssembly;
            }
        }

        Dictionary<string, Assembly> loadedAssemblies;
        ResolveEventHandler CurrentDomain_AssemblyResolve;

        private void SearchForPlugInTypes()
        {
            loadedAssemblies = new Dictionary<string, Assembly>();
            CurrentDomain_AssemblyResolve = (object sender, ResolveEventArgs args) =>
                {
                    Assembly assembly = null;
                    loadedAssemblies.TryGetValue(args.Name, out assembly);
                    return assembly;
                };
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var pluginTypes = new List<ExpandableSetting>();
            var testDefinitionGeneratorWizzardTypes = new List<Type>();

            var dirinfo = new DirectoryInfo(PluginsPath);
            if (!dirinfo.Exists)
                throw new ApplicationException("The Plugins folder is missing => " + PluginsPath);

            var pluginAssemblies = dirinfo.GetFiles("*.dll");
            if(!pluginAssemblies.Any())
                throw new ApplicationException("There are no plugin assemblies in the plugin folder => " + PluginsPath);

            var plugins = pluginAssemblies.Select(dll=>Assembly.LoadFile(dll.FullName)).ToList();

            foreach (var asmb in plugins)
            {
                loadedAssemblies[asmb.FullName] = asmb;
                foreach (var type in asmb.GetTypes())
                    SearchAndAddPlugIns(type, pluginTypes, testDefinitionGeneratorWizzardTypes);
            }
            this.TestDefinitionGeneratorWizzardTypes = testDefinitionGeneratorWizzardTypes.ToArray();
            this.PluginTypes = pluginTypes.ToArray();
        }

        private const string hashKeySeparator = "|=-JC~=|";
        private static string getExpandableDataKey(string dataType, string uniqueName)
        {
            return dataType + hashKeySeparator + uniqueName;
        }
        private static string getExpandableDataKey(ExpandableDataType dataType, string uniqueName)
        {
            return getExpandableDataKey(Enum.GetName(typeof(ExpandableDataType), dataType), uniqueName);
        }

        public Type GetExpandableType(string dataType, string uniqueName)
        {
            Type dataTypeFound;
            if (!TestProjectHost.Current.expandableData.TryGetValue(getExpandableDataKey(dataType, uniqueName), out dataTypeFound))
                throw new ApplicationException(uniqueName + " - " + dataType + " is not defined inside the application or it's plugins - you probably need to add the extra plugins");
            return dataTypeFound;
        }

        public Type GetExpandableType(ExpandableDataType dataType, string uniqueName)
        {
            return GetExpandableType(Enum.GetName(typeof(ExpandableDataType), dataType), uniqueName);
        }

        private void SearchAndAddPlugIns(Type possiblePluginType, List<ExpandableSetting> pluginTypes, List<Type> testDefinitionGeneratorWizzardTypes)
        {
            if (possiblePluginType.IsSubclassOf(typeof(ExtendableData)))
            {
                var tempData = (ExtendableData)Activator.CreateInstance(possiblePluginType);
                expandableData.Add(getExpandableDataKey(tempData.DataType, tempData.UniqueName), possiblePluginType);
                return;
            }
            var expandableattrib = possiblePluginType.GetCustomAttribute<ExpandableSettingsAttribute>(true);
            if (expandableattrib != null)
                pluginTypes.Add(expandableattrib.GetSetting(possiblePluginType));
            else if (possiblePluginType.GetInterfaces().Any(i => i == typeof(ITestDefinitionGeneratorWizzard)))
                testDefinitionGeneratorWizzardTypes.Add(possiblePluginType);
        }

        public void Dispose()
        {
            loadedAssemblies = null;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
    }
   
}
