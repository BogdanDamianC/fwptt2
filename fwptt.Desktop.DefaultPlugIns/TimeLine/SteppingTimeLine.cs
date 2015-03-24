using System;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
	/// <summary>
	/// Summary description for SteppingTimeLine.
	/// </summary>
    public class SteppingTimeLine : BaseTestRunTimeLine
	{
        public const string PublicName = "fwptt -> Default -> Stepping TimeLine";	
		public uint MaxSteps {get; set;}

        public SteppingTimeLine()
        { }

		public SteppingTimeLine(uint MaxNumberOfSteps)
		{
			MaxSteps = MaxNumberOfSteps;
		}

        public override string UniqueName
        {
            get { return PublicName; }
        }

        public override ITimeLineController GetNewController()
        {
            return new SteppingTimeLineController(this);
        }
	}
}
