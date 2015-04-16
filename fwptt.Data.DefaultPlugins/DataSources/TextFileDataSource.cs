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
    public class TextFileDataSource : BaseTestDataSource
    {
        public const string PublicName = "fwptt -> Default -> Datasources -> Text DataSource";
        public override string UniqueName
        {
            get { return PublicName; }
        }

        public string FilePath { get; set; }
        public string DataRowSeparator { get; set; }

        public override ITestDataSourceReader GetDataSourceReader()
        {
            return new TextFileDataSourceReader(FilePath, DataRowSeparator);
        }
    }
}
