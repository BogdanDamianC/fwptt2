using System.Reflection;
using System.Runtime.Loader;

namespace fwptt.TestProject.NET_Plumbing
{
    internal class LoadRunnerAssemblyLoadContext : AssemblyLoadContext
    {
        public LoadRunnerAssemblyLoadContext() : base(true)
        { 
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }        
    }
}
