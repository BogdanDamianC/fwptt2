using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Run.Data
{
    public class TestLoadInfo
    {
        public int NoOfRequests { get; set; }
        public int NoOfErrors { get; set; }
    }

    public class TestLoadInfoPerUnitOfTime :TestLoadInfo
    {
        public DateTime Time { get; set; }
    }
}
