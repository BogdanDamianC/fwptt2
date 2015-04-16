using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project;

namespace fwptt.Data.DefaultPlugins.DataSources
{
    public class JSONDataSourceConfiguration : BaseTestDataSource
    {
        public const string PublicName = "fwptt -> Default -> Datasources -> JSON DataSource";
        public override string UniqueName
        {
            get { return PublicName; }
        }

        public string FilePath { get; set; }

        public override ITestDataSourceReader GetDataSourceReader()
        {
            throw new NotImplementedException();
        }
    }
}
