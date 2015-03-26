using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace fwptt.TestProject.Project
{
    public class TestProjectDefinition
    {
        public const string FileDialogFilter = "fwptt Test Project files (*.fwptt)|*.fwptt|All files (*.*)|*.*";
        public const string DefaultExtension = "fwptt";
        public const string ApplicationStartupPathIdentifier = "[fwptt_application_startuppath]";
        public const string ProjectPathIdentifier = "[fwptt_project_path]";

        public TestProjectDefinition()
        {
            TestDefinitions = new List<TestDefinition>();
            TestRunDefinitions = new List<TestRunDefinition>();
            TestRunsResults = new List<TestRunResults>();
        }

        public List<TestDefinition> TestDefinitions { get; set; }
        public List<BaseTestDataSource> TestDataSources { get; set; }
        public List<TestRunDefinition> TestRunDefinitions { get; set; }
        public List<TestRunResults> TestRunsResults { get; set; }


        public static TestProjectDefinition FromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                return JsonConvert.DeserializeObject<TestProjectDefinition>(file.ReadToEnd());
            }
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
