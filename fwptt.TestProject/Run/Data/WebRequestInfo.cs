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

        public override string ToString()
        {
            string ret = Request.RequestMethod + "  -|-  " + Request.URL + "  -|-  ";
            if (Errors.Any())
                ret += " Errors:" + string.Join("| ", Errors);
            else
                ret += "OK";
            return ret;
        }
    }
}
