using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    public class ResultsViewerConfiguration : ExtendableData
    {
        public const string PublicName = "fwptt -> Default -> Plugins -> ResultsViewer";
        public override string UniqueName
        {
            get { return PublicName; }
        }

        public int MaxResponseSizeRecorded { get; set; }
        public int MaxNumberOfRequestsRecorded { get; set; }
        public int RefreshInterval { get; set; }
    }
}
