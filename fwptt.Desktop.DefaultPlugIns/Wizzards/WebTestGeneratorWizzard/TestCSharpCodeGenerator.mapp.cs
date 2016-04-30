using System;
using System.Linq;
using System.Text;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test.Data;
using System.Collections.Generic;

namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    public partial class TestCSharpCodeGenerator
    {
        public RecordedTestDefinition TestDefinition {get; private set;}
        protected List<string[]> paramsToSave;
        protected string[] usedParams;

        public string GetMethodName(int index)
        {
            return string.Format("Req_{0}_{1}", index, GetCodeNamBasedOnRequest(TestDefinition.Requests[index]));
        }
        public string GetCodeNamBasedOnRequest(WebRequest req)
        {
            var ret = new StringBuilder();
            ret.Append(req.RequestMethod);
            
            ret.Append(TransformNameToCode(req.URL.Host)).Append(TransformNameToCode(req.URL.AbsolutePath));
            return ret.ToString();
        }

        public static string TransformNameToCode(string name)
        {
            var ret = new StringBuilder();
            foreach (char c in name)
                if (char.IsLetterOrDigit(c))
                    ret.Append(c);
                else
                    ret.Append('_');
            return ret.ToString();
        }

        public string MainSiteHost{get; private set;}
        

        protected bool useSiteDomainPath(Uri url)
        {
            return url.GetLeftPart(UriPartial.Path).ToString().ToLower().StartsWith(MainSiteHost.ToLower());
        }

        protected string getRelativePath(Uri url)
        {
            return url.GetLeftPart(UriPartial.Path).Substring(MainSiteHost.Length);
        }

        public static string GenerateCode(RecordedTestDefinition testDefinition, string MainSiteHost, IEnumerable<string> paramsToLookFor)
        {
            var newGen = new TestCSharpCodeGenerator { TestDefinition = testDefinition, MainSiteHost = MainSiteHost, paramsToSave = new List<string[]>() };
            newGen.SetParamsToSave(paramsToLookFor);
            return newGen.TransformText();
        }

        private void SetParamsToSave(IEnumerable<string> paramsToLookFor)
        {
            var hashParamsToLookFor = new HashSet<string>(paramsToLookFor.Distinct());
            for (int i = 1; i < TestDefinition.Requests.Count; i++)
            {
                paramsToSave.Add((from pp in TestDefinition.Requests[i].PostParams
                                               where hashParamsToLookFor.Contains(pp.ParamName)
                                               select pp.ParamName).ToArray());
            }
            paramsToSave.Add(new string[0]); //last hash is empty no need to save anything
            usedParams = (from pn in
                         ((from p in paramsToSave from pstr in p select pstr).Distinct())
                          select GetCodeNameForParam(pn)).ToArray();
        }

        protected string GetQuotedValue(string Value)
        {
            return "@\"" + (Value ?? string.Empty).Replace("\"", "\"\"") + "\"";
        }

        protected string GetPostParamValue(int requestIndex, RequestParam pp)
        {
            if (requestIndex == 0 || !paramsToSave[requestIndex - 1].Contains(pp.ParamName))
                return GetQuotedValue(pp.ParamValue);
            else
                return GetCodeNameForParam(pp.ParamName);

        }

        public string GetCodeNameForParam(string param)
        {
            var ret = new StringBuilder();
            ret.Append("sp_");
            foreach (char c in param)
                if (char.IsLetterOrDigit(c))
                    ret.Append(c);
                else
                    ret.Append('_');
            return ret.ToString();
        }

    }
}
