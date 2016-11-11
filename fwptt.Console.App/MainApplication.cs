using System;
using System.IO;
using System.Linq;
using fwptt.TestProject;
using fwptt.TestProject.Project;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Run;

namespace fwptt.Console.App
{
    public class MainApplication
    {
        private const string samplePath = "fwptt.Console.App.exe [projectfilepath] [newrun/rerun] [testdefinitionname/testrunname]";

        static void Main(string[] args)
        {
            var tpHost = new TestProjectHost(Directory.GetCurrentDirectory(), Path.Combine(Directory.GetCurrentDirectory(), "PlugIn"));
            MainProvider.Current = tpHost;
            if (args.Length != 3)
            {
                System.Console.WriteLine("invalid parameters - " + args.Length + " parameters in command - please use it like this " + samplePath);
                return;
            }

            tpHost.LoadProject(args[0]);

            switch(args[1])
            {
                case "newrun": NewTestRun(tpHost, args[2]); break;
                case "rerun": ReRunTestRunResults(args[2]); break;
                default: System.Console.WriteLine("invalid command - " + args[1] + " only newrun or rerun are allowed - please use it like this " + samplePath);
                    return;
            }

        }

        private static void NewTestRun(TestProjectHost tpHost, string testRunDefinitionName)
        {
            var trd = tpHost.Project.TestRunDefinitions.FirstOrDefault(td => td.Name == testRunDefinitionName);
            if (trd == null)
            {
                System.Console.WriteLine(testRunDefinitionName + " is not a valid Test Run Definition");
                return;
            }
            var runResults = new TestRunResults(trd, tpHost.Project.TestDefinitions.First(td => td.Id == trd.TestDefinitionId));
            tpHost.Project.TestRunsResults.Add(runResults);

            var timeLineController = runResults.TestRunDefinition.TimeLine.GetNewController();

            try
            {
                bool testIsDone = false;

                var testRunner = tpHost.GetTestRunner(runResults, timeLineController);
                testRunner.TestRunEnded += (TestProject.Run.TestRunner obj) =>
                {
                    testIsDone = true;
                };
                LoadPlugins(tpHost, testRunner, runResults);
                testRunner.StartTests();
                while(!testIsDone)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    System.Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
            }
        }

        private static void ReRunTestRunResults(string testRunName)
        {
            System.Console.WriteLine("hmm this is not yet implemented - hope will get to it soon ... ");
        }


        private static void LoadPlugins(TestProjectHost tpHost, TestRunner testRunner,TestRunResults results)
        {
            foreach (var plugin in results.TestRunDefinition.RunPlugins)
            {
                var tmpPluginInfo = tpHost.PluginTypes.FirstOrDefault(pl => pl.ComponentType == ExpandableComponentType.Plugin
                                                && pl.UniqueName == plugin.UniqueName);
                testRunner.AddPlugIn(CreatePluginInstance(tmpPluginInfo, plugin));
            }
        }

        private static IRequestPlayerPlugIn CreatePluginInstance(ExpandableSetting setting, ExtendableData data)
        {
            var tlpl = Activator.CreateInstance(setting.PluginType) as IRequestPlayerPlugIn;
            if (tlpl == null)
                throw new ApplicationException(setting.PluginType.ToString() + " type is not supported as a desktop application plugin, the type must be a user control or some type derived from the Control class");
            ((ITestRunComponent)tlpl).CurrentData = data;
            return tlpl;
        }
    }
}
