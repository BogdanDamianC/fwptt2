using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Desktop.Util;
using fwptt.TestProject;
using System.IO;


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
        public override void SetConfiguration(ExtendableData data)
        {
            base.SetConfiguration(data);
            tfDataSource = (fwptt.Data.DefaultPlugins.DataSources.TextFileDataSource)CurrentData;
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

            var folder = new Uri(new FileInfo(TestProjectHost.Current.ProjectPath).Directory.FullName + Path.DirectorySeparatorChar);
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
