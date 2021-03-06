﻿using fwptt.TestProject.Project.Interfaces;
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
