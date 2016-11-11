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
using System.Linq;
using System.Timers;
using fwptt.Data.DefaultPlugins.RequestsCounter;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;


namespace fwptt.Console.DefaultPlugins.RequestsCounter
{
    [ExpandableSettings(RequestCounterConfiguration.PublicName, "Request Counter", ExpandableComponentType.Plugin)]
    public class ConsoleCounter : BaseTestRunExecutionComponent<RequestCounterConfiguration>, IRequestPlayerPlugIn
    {
        private Timer refreshTimer;
        private RequestCounterRunData requestCounterRunData = new RequestCounterRunData();
        private TestLoadInfoPerUnitOfTime currentInstantCount;
        private DateTime testRunStartTime;

        public ConsoleCounter()
        {
            refreshTimer = new Timer(1000);
            refreshTimer.AutoReset = true;
            refreshTimer.Elapsed += refreshTimer_Elapsed;
        }

        void refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var instCount = currentInstantCount;
            lock (this)
            {
                currentInstantCount = new TestLoadInfoPerUnitOfTime();
            }
            instCount.Time = DateTime.Now;
            requestCounterRunData.OverallCounts.NoOfRequests += instCount.NoOfRequests;
            requestCounterRunData.OverallCounts.NoOfErrors += instCount.NoOfErrors;
            requestCounterRunData.TestRunCounts.Add(instCount);

            double ElapsedSecs = ((TimeSpan)instCount.Time.Subtract(testRunStartTime)).TotalSeconds;
            double average = 1;
            if (ElapsedSecs > 0)
                average = (double)requestCounterRunData.OverallCounts.NoOfRequests / ElapsedSecs;
            SetNumbersOverview(instCount, average);
        }

        private const string overviewSpacer = "     ";
        private void SetNumbersOverview(TestLoadInfoPerUnitOfTime instCount, double average)
        {
            System.Console.Write(DateTime.Now.ToLongTimeString() + overviewSpacer);
            System.Console.Write("Total Requests: " + requestCounterRunData.OverallCounts.NoOfRequests + overviewSpacer);
            System.Console.Write("Total Errors: " + requestCounterRunData.OverallCounts.NoOfErrors + overviewSpacer);
            System.Console.Write("avg req/sec " + average.ToString("0.000") + overviewSpacer);
            System.Console.Write("err/sec " + instCount.NoOfErrors + overviewSpacer);

            foreach (var oc in instCount.OtherCounts)
                System.Console.Write(oc.Key + "/sec " + oc.Value + overviewSpacer);

            if (requestCounterRunData.OverallCounts.OtherCounts.Any())
            {
                System.Console.Write("Overall OtherCounts: " + overviewSpacer);
                foreach (var oc in requestCounterRunData.OverallCounts.OtherCounts)
                    System.Console.Write(oc.Key + " - " + oc.Value + overviewSpacer);
            }
            System.Console.WriteLine("");
        }

        public ExtendableData TestRunResults
        {
            get { return requestCounterRunData; }
            set
            {
                requestCounterRunData = (RequestCounterRunData)value;
            }
        }

        private void TestStarted()
        {
            requestCounterRunData.Reset();
            currentInstantCount = new TestLoadInfoPerUnitOfTime();
            testRunStartTime = DateTime.Now;
            refreshTimer.Start();
        }
        public Action OnTestStarted { get { return TestStarted; } }

        private void TestEnded()
        {
            refreshTimer.Stop();
        }
        public Action OnTestStopped { get { return TestEnded; } }
        public Action<TestProject.Run.Data.IRequestInfo> OnRequestStarted { get { return null; } }

        public void RequestEnded(TestProject.Run.Data.IRequestInfo rinfo)
        {
            lock (this)
            {
                currentInstantCount.NoOfRequests++;
                currentInstantCount.NoOfErrors += (ulong)rinfo.Errors.Count;
                ulong currentCountValue;
                foreach (var oc in rinfo.Counts)
                {
                    if (currentInstantCount.OtherCounts.TryGetValue(oc.Key, out currentCountValue))
                        currentInstantCount.OtherCounts[oc.Key] = currentCountValue + oc.Value;
                    else
                        currentInstantCount.OtherCounts[oc.Key] = oc.Value;
                }
            }
        }
        public Action<TestProject.Run.Data.IRequestInfo> OnRequestEnded { get { return RequestEnded; } }
    }
}
