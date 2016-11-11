using System;
using System.IO;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Desktop.Util;
using fwptt.TestProject;


namespace fwptt.Desktop.DefaultPlugIns.DataSources
{
    [ExpandableSettings(fwptt.Data.DefaultPlugins.DataSources.TextFileDataSource.PublicName, "Text File Data Source", ExpandableComponentType.DataSourceConfiguration)]
    public partial class ucTextFileDataSourceConfiguration : BaseTestRunConfigurationComponent
    {
        public ucTextFileDataSourceConfiguration()
        {
            InitializeComponent();
        }

        fwptt.Data.DefaultPlugins.DataSources.TextFileDataSource tfDataSource;
        private const string NewLineSeparator = "{{NEWLINE}}";
        private const string TabSeparator = "{{TAB}}";
        protected override void SetCurrentData(ExtendableData data)
        {
            base.SetCurrentData(data);
            tfDataSource = (fwptt.Data.DefaultPlugins.DataSources.TextFileDataSource)data;
            txtFilePath.Text = tfDataSource.FilePath;
            cboDataSeparator.Items.Add(NewLineSeparator);
            cboDataSeparator.Items.Add(TabSeparator);
            switch(tfDataSource.DataRowSeparator)
            {
                case "\r\n":
                case "\n": cboDataSeparator.Text = NewLineSeparator;
                    break;
                case "\t": cboDataSeparator.Text = TabSeparator;
                    break;
                default: cboDataSeparator.Text = tfDataSource.DataRowSeparator;
                    break;
            }
        }

        private void btnSelectFilePath_Click(object sender, EventArgs e)
        {
            var newPath = UI_Util.PickOpenFile(this, "All files (*.*)|*.*");
            if (string.IsNullOrWhiteSpace(newPath))
                return;

            var folder = new Uri(new FileInfo(MainProvider.Current.ProjectPath).Directory.FullName + Path.DirectorySeparatorChar);
            txtFilePath.Text = Uri.UnescapeDataString(folder.MakeRelativeUri(new Uri(newPath))
                    .ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            tfDataSource.FilePath = txtFilePath.Text;
        }

        private void cboDataSeparator_TextChanged(object sender, EventArgs e)
        {
            switch (cboDataSeparator.Text)
            {
                case NewLineSeparator: tfDataSource.DataRowSeparator = "\n";
                    break;
                case TabSeparator: tfDataSource.DataRowSeparator = "\t";
                    break;
                default: tfDataSource.DataRowSeparator = cboDataSeparator.Text;
                    break;
            }
        }
    }
}
