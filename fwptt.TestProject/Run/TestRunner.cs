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
using System.Collections.Generic;
using System.Threading.Tasks;
using fwptt.TestProject.Run.Data;
using fwptt.TestProject.Project.Interfaces;


namespace fwptt.TestProject.Run
{
    /// <summary>
    /// Summary description for TestRunner.
    /// </summary>
    public class TestRunner:IDisposable
	{
		private List<IRequestPlayerPlugIn> Plugins = new List<IRequestPlayerPlugIn>();

		public event Action<TestRunner> TestRunEnded;
		public event Action<TestRunner> TestRunStarted;

		public Type RunningTestType { get; set; }
		private Action<IRequestInfo> runnerRequestStartedEventhandler;
		private Action<IRequestInfo> runnerRequestEndedEventhandler;
        private System.Collections.Concurrent.ConcurrentQueue<IBaseTest> inactiveTestInstancesPool;

		private ITimeLineController timelineCtrl;
        private Dictionary<string, string> Properties;
        private ITestDataSourceReader testDataSource;
        private List<Action<IRequestInfo>> onRequestStarted, onRequestEnded;

		public TestRunner(ITimeLineController timeline, Dictionary<string, string> Properties, ITestDataSourceReader testDataSource)
		{
			timelineCtrl = timeline;
            this.Properties = Properties;
            this.testDataSource = testDataSource;
			runnerRequestStartedEventhandler = new Action<IRequestInfo>(TestRunner_RequestStarted);
			runnerRequestEndedEventhandler = new Action<IRequestInfo>(TestRunner_RequestEnded);
		}


        private void SetThreadPoolMinThreads()
        {
            int minWorker, minIOC;
            System.Threading.ThreadPool.GetMinThreads(out minWorker, out minIOC);
            minWorker = Math.Max(minWorker, (int)timelineCtrl.MaxExecutionThreads);
            minIOC = Math.Max(minIOC, (int)timelineCtrl.MaxExecutionThreads);
            System.Threading.ThreadPool.SetMinThreads(minWorker, minIOC);
        }

		public void StartTests()
		{
            inactiveTestInstancesPool = new System.Collections.Concurrent.ConcurrentQueue<IBaseTest>();
            TestRunStarted?.Invoke(this);
            onRequestStarted = new List<Action<IRequestInfo>>();
            onRequestEnded = new List<Action<IRequestInfo>>();
            SetThreadPoolMinThreads();
            timelineCtrl.StartTimeLine();
            foreach (var plugin in Plugins)
            {
                plugin.OnTestStarted?.Invoke();
                if (plugin.OnRequestStarted != null)
                    onRequestStarted.Add(plugin.OnRequestStarted);
                if (plugin.OnRequestEnded != null)
                    onRequestEnded.Add(plugin.OnRequestEnded);
            }

            Task.Run(TriggerTests);
		}

        private async Task TriggerTests()
        {
            int delayInBetweenChecks = 20;
            do
            {
                TryStartNewExecutionThread();
                if (timelineCtrl.CurrentExecutionThreads == timelineCtrl.MaxExecutionThreads)
                    delayInBetweenChecks = 1000; //no need use the CPU too much the test ended should deal with most of the restarts
                await Task.Delay(delayInBetweenChecks).ConfigureAwait(false);
            } while (timelineCtrl.IsRunning);
        }

        private bool TryStartNewExecutionThread()
        {
            var currentIteration = timelineCtrl.TryStartNewExecutionThread();
            if (!currentIteration.HasValue)
                return false;

            timelineCtrl.StartNewIterationExecution();

            IBaseTest newInstance;
            if (!inactiveTestInstancesPool.TryDequeue(out newInstance))
            {
                newInstance = (IBaseTest)Activator.CreateInstance(RunningTestType, new object[] { });
                newInstance.RequestStarted += runnerRequestStartedEventhandler;
                newInstance.RequestEnded += runnerRequestEndedEventhandler;
            }
            object runData = testDataSource != null ? testDataSource.GetRecord(currentIteration.Value) : null;
            //newInstance.Proxy = this.Proxy;
            newInstance.StartTest(timelineCtrl, Properties, runData).ContinueWith(async (Task a) =>
            {
                await a.ConfigureAwait(false);
                timelineCtrl.IterationExecutionEnded(currentIteration.Value);
                inactiveTestInstancesPool.Enqueue(newInstance);//the test can now be reused
                TestRunner_TestEnded();
            });
            return true;
        }

		public void StopTests()
		{
			timelineCtrl.StopTimeLine(); //this will make the test instances to stop  
			TestRunner_TestEnded();
		}

		#region PlugIns
		public void AddPlugIn(IRequestPlayerPlugIn plugin)
		{
			lock (this)
			{
				Plugins.Add(plugin);
			}
		}

		public bool RemovePlugIn(IRequestPlayerPlugIn plugin)
		{
			lock(this)
			{
				return Plugins.Remove(plugin);
			}
		}

		#endregion

		public System.Net.WebProxy Proxy {get; set;}

		private void TestRunner_TestEnded()
		{
            if(timelineCtrl.IsRunning)
            {
                TryStartNewExecutionThread();
                return;
            }
			else if (timelineCtrl.CurrentExecutionThreads > 0) //trigger the end event only once all the threads are done
                return;

            inactiveTestInstancesPool = null;
            TestRunEnded?.Invoke(this);

            foreach (var plugin in Plugins)
                plugin.OnTestStopped?.Invoke();
            onRequestStarted = null;
            onRequestEnded = null;
		}

		private void TestRunner_RequestStarted(IRequestInfo currentRequest)
		{
			if (Plugins == null)
				return;
			foreach (var requestStarted in onRequestStarted)
                requestStarted(currentRequest);
		}

		private void TestRunner_RequestEnded(IRequestInfo currentRequest)
		{
			if(Plugins == null)
				return;
			foreach (var requestEnded in onRequestEnded)
                requestEnded(currentRequest);
		}

		#region IDisposable Members

		public void Dispose()
		{
			StopTests();
            onRequestStarted = null;
            onRequestEnded = null;
			Plugins = null;
		}

		#endregion
	}
}
