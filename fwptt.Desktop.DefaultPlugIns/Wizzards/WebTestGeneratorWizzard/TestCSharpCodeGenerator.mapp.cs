using System.Text;
using fwptt.TestProject.Run.Data;
using System;

namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    public partial class TestCSharpCodeGenerator
    {
        public RecordedTestDefinition TestDefinition { get; set; }

        public string GetMethodName(int index)
        {
            return string.Format("Req_{0}_{1}", index, GetCodeNamBasedOnRequest(TestDefinition.Requests[index]));
        }
        public string GetCodeNamBasedOnRequest(WebRequest req)
        {
            var ret = new StringBuilder();
            ret.Append(req.RequestMethod);
            var uri = new Uri( req.URL);
            string pathToUse = uri.Host + uri.AbsolutePath;
            foreach(char c in pathToUse)
                if(char.IsLetterOrDigit(c))
                    ret.Append(c);
                else
                    ret.Append('_');
            return ret.ToString();

        }

        public static string GenerateCode(RecordedTestDefinition testDefinition)
        {
            var newGen = new TestCSharpCodeGenerator { TestDefinition = testDefinition };
            return newGen.TransformText();
        }
    }
}
