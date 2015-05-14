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
            var uri = new Uri( req.URL);
            string pathToUse = uri.Host + uri.AbsolutePath;
            foreach(char c in pathToUse)
                if(char.IsLetterOrDigit(c))
                    ret.Append(c);
                else
                    ret.Append('_');
            return ret.ToString();

        }

        public string MainSiteHost{get; private set;}
        

        protected bool useSiteDomainPath(string url)
        {
            return url.ToLower().StartsWith(MainSiteHost.ToLower());
        }

        protected string getRelativePath(string url)
        {
            return url.Substring(MainSiteHost.Length);
        }

        public static string GenerateCode(RecordedTestDefinition testDefinition, string MainSiteHost)
        {
            var newGen = new TestCSharpCodeGenerator { TestDefinition = testDefinition, MainSiteHost = MainSiteHost, paramsToSave = new List<string[]>() };
            newGen.SetParamsToSave();
            return newGen.TransformText();
        }

        private void SetParamsToSave()
        {
            var paramsToLookFor = new HashSet<string>(new string[] { "__VIEWSTATE", "__VIEWSTATEGENERATOR", "__EVENTVALIDATION", "javax.faces.ViewState" });
            for (int i = 1; i < TestDefinition.Requests.Count; i++)
            {
                paramsToSave.Add((from pp in TestDefinition.Requests[i].PostParams
                                               where paramsToLookFor.Contains(pp.ParamName)
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
