using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fwptt.TestProject.Project.Interfaces
{
    public interface ITestRunDataSource
    {
        object GetRecord(ulong iteration);
    }

}
