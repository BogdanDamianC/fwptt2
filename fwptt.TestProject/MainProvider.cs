using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject
{
    public class MainProvider
    {
        public static MainProvider Current { get; set; }

        private TestProjectHost host;
        
        public MainProvider(TestProjectHost host)
        {
            this.host = host;
        }

         public Type GetExpandableType(string dataType, string uniqueName)
        {
            return host.GetExpandableType(dataType, uniqueName);
        }

         public Type GetExpandableType(ExpandableDataType dataType, string uniqueName)
         {
             return host.GetExpandableType(dataType, uniqueName);
         }

        public ExtendableData CreateExpandableTypeInstance(string dataType, string uniqueName)
        {
            return (ExtendableData)Activator.CreateInstance(GetExpandableType(dataType, uniqueName));
        }

        public string ProjectPath { get { return host.ProjectPath; } }
    }
}
