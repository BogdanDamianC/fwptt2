using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.Data.DefaultPlugins.DataSources
{
    public class TextFileDataSourceReader : ITestDataSourceReader
    {
        List<string> data = new List<string>(); 
        public TextFileDataSourceReader(string FilePath, string DataRowSeparator)
        {
            string content;
            var filePath = Path.Combine(new FileInfo(TestProjectHost.Current.ProjectPath).Directory.FullName, FilePath);
            using (var sr = new StreamReader(filePath))
            {
                content = sr.ReadToEnd();
            }

            int currentIndex = 0, nextIndex;
            while ((nextIndex = content.IndexOf(DataRowSeparator, currentIndex)) >= 0)
            {
                data.Add(content.Substring(currentIndex, nextIndex - currentIndex));
                currentIndex = nextIndex+1;
            }
            if (content.Length > currentIndex)
                data.Add(content.Substring(currentIndex));
            if (!data.Any())
                throw new ApplicationException("There is no content in the file:" + filePath);
        }

        public object GetRecord(ulong iteration)
        {
            return data[Convert.ToInt32(iteration % (uint)data.Count)];
        }

        public void Dispose()
        {
            data = null;
        }
    }
}
