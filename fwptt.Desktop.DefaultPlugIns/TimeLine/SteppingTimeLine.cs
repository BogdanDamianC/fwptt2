using System;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.RequestPlayerPlugIns.TimeLine
{
	/// <summary>
	/// Summary description for SteppingTimeLine.
	/// </summary>
    public class SteppingTimeLine : BaseTestRunTimeLine
	{
        public const string PublicName = "fwptt -> Default -> Stepping TimeLine";	
		public int MaxSteps {get; set;}

        public SteppingTimeLine()
        { }

		public SteppingTimeLine(int MaxNumberOfSteps)
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
