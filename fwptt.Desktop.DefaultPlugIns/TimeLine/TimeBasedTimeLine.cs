using System;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.TimeLine;

namespace fwptt.Desktop.RequestPlayerPlugIns.TimeLine
{
	/// <summary>
	/// Summary description for DurationTimeLine.
	/// </summary>
    public class TimeBasedTimeLine : BaseTestRunTimeLine
	{
        public const string PublicName = "fwptt -> Default -> TimeBased TimeLine";
        public int Hours {get; set;}
        public int Minutes {get; set;}
        public int NoOfThreads { get; set; }
        public int PauseBetweenRequests { get; set; }
        public int RampUpMinutes { get; set; }
        public int RampUpSeconds { get; set; }
        
        public TimeBasedTimeLine()
        { }

		public TimeBasedTimeLine(int DurationInSeconds)
		{
            Hours = DurationInSeconds / 3600;
            DurationInSeconds -= Hours*3600;
            Minutes = DurationInSeconds / 60;
            DurationInSeconds -= Minutes * 60;
		}

        public override string UniqueName
        {
            get { return PublicName; }
        }

        public override ITimeLineController GetNewController()
        {
            return new TimeBasedTimeLineController(this);
        }
    }
}
