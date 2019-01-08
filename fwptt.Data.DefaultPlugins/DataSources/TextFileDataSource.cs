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
