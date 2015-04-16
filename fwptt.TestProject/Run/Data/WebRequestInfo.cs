using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Run.Data
{
    public class WebRequestInfo:RequestInfo<WebRequest, string>
    {
        public WebRequestInfo()
        {
            this.Request = new WebRequest();
        }
        public Int32 ResponseCode { get; set; }
        public override string ResponseToString()
        {
            return Response;
        }

        private const string infoSeparator = "  -|-  ";
        public override string ToString()
        {
            string ret = Errors.Any() ? "Error" : "OK";
            ret += infoSeparator;
            ret = Request.RequestMethod + infoSeparator + Request.URL + infoSeparator;
            if (Errors.Any())
                ret += " Error Details:" + string.Join("| ", Errors);
            return ret;
        }
    }
}
