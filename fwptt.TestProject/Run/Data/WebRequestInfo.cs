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
    }
}
