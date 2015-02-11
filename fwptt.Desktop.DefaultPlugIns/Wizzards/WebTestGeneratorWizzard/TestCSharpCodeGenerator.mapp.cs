using System;
using System.Linq;
using System.Text;
using fwptt.TestProject.Run.Data;

namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    public partial class TestCSharpCodeGenerator
    {
        private RecordedTestDefinition internalTestDefinition;
        public RecordedTestDefinition TestDefinition
        {
            get { return internalTestDefinition; }
            set
            {
                internalTestDefinition = value;
                PrepExtraData();
            }
        }

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

        public string BaseUrl { get; private set; }
        private void PrepExtraData()
        {
            var url = (from uri in
                           (from req in internalTestDefinition.Requests
                            select new Uri(req.URL.ToString()))
                       select uri.AbsoluteUri).FirstOrDefault();
            if (url == null)
                throw new ApplicationException("No Base url can be found");
            BaseUrl = url;
        }


        public static string GenerateCode(RecordedTestDefinition testDefinition)
        {
            var newGen = new TestCSharpCodeGenerator { TestDefinition = testDefinition };
            return newGen.TransformText();
        }
    }
}
