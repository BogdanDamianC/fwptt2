using System;
using fwptt.TestProject.Project.Interfaces;


namespace fwptt.TestProject.Project.TimeLine
{
	/// <summary>
	/// Summary description for DurationTimeLine.
	/// </summary>
    public class TimeBasedTimeLine : BaseTestRunTimeLine
	{
        public const string PublicName = "fwptt -> Default -> TimeBased TimeLine";
        public int Hours {get; private set;}
        public int Minutes {get; private set;}
        public int Seconds { get; private set; }
        public TimeBasedTimeLine()
        { }

		public TimeBasedTimeLine(int DurationInSeconds)
		{
            Hours = DurationInSeconds / 3600;
            DurationInSeconds -= Hours*3600;
            Minutes = DurationInSeconds / 60;
            DurationInSeconds -= Minutes * 60;
            Seconds = DurationInSeconds;
		}

		public TimeBasedTimeLine(int Hours, int Minutes, int Seconds):base()
		{
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
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
