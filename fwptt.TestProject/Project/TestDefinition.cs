using System;
using System.Collections.Generic;

namespace fwptt.TestProject.Project
{
    public class TestDefinition
    {
        public TestDefinition() {
            Assemblies = new List<string>();
        }
        public TestDefinition(string FileName):this()
        {
            Id = Guid.NewGuid();
            TestDefinitionFile = FileName;
            Assemblies.Add("System.dll");
            Assemblies.Add("System.Data.dll");
            Assemblies.Add("System.XML.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationStartupPathIdentifier + "RestSharp.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationStartupPathIdentifier + "fwptt.RequestsPlayer.dll");
            Assemblies.Add(TestProjectDefinition.ApplicationStartupPathIdentifier + "HTMLparserDotNet11.dll");
        }
        public Guid Id { get; set; }
        public string TestDefinitionFile { get; set; }
        public List<string> Assemblies { get; set; }
    }
}
