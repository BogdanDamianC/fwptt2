using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.RequestsCounter
{
    public class RequestCounterConfiguration : ExtendableData
    {
        public const string PublicName = "fwptt -> Default -> Plugins -> RequestCounter";
        public override string UniqueName
        {
            get { return PublicName; }
        }
    }
}
