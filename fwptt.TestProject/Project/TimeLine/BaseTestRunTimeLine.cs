using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using fwptt.TestProject.Project.TimeLine;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;

namespace fwptt.TestProject.Project.TimeLine
{
    public abstract class BaseTestRunTimeLine : ExtendableData
    {
        public abstract ITimeLineController GetNewController();
        public override ExpandableDataType DataType
        {
            get { return ExpandableDataType.Configuration; }
        }
    }
}
