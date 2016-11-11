/*
 * 
 * Namespace Summary
 * Copyright (C) 2007+ Bogdan Damian Constantin
 * WEB: http://fwptt.sourceforge.net/
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */


using System;
using System.Timers;
using fwptt.Data.DefaultPlugins.ResultsViewer;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;
using fwptt.TestProject.Run.Data;


namespace fwptt.Console.DefaultPlugins.ResultsViewer
{
    [ExpandableSettings(ResultsViewerConfiguration.PublicName, "Results Viewer", ExpandableComponentType.Plugin)]
    public class ConsoleResultsViewer : BaseTestRunExecutionComponent<ResultsViewerConfiguration>, IRequestPlayerPlugIn
    {
        private Timer refreshTimer;

        public ConsoleResultsViewer()
        {
            refreshTimer = new Timer(1000);
        }
        private RequestResultsRunData requestResultsRunData = new RequestResultsRunData();
        public ExtendableData TestRunResults
        {
            get { return requestResultsRunData; }
            set
            {
                requestResultsRunData = (RequestResultsRunData)value;
            }
        }

        //TODO implement the missing functionality


        private void TestStarted()
        {
            //queuedRequests = new List<IRequestInfo>();
            //refreshTimer.Interval = Configuration.RefreshInterval * 1000;
            //refreshTimer.Start();
        }

        public Action OnTestStarted { get{return TestStarted;} }

        delegate void ThreadSafeCallback();
		private void TestEnded()
		{
            refreshTimer.Stop();
		}

        public Action OnTestStopped { get { return TestEnded; } }

        public Action<IRequestInfo> OnRequestStarted { get{return null;} }
        delegate void ThreadSafeAddRequestCallback(IRequestInfo rinfo);
        public void RequestEnded(IRequestInfo rinfo)
        {
            lock (this)
            {
                //queuedRequests.Add(rinfo);
            }
        }
        public Action<IRequestInfo> OnRequestEnded { get{return RequestEnded;} }


    }
}
