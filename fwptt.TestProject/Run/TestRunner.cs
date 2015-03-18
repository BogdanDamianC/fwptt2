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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Text;
using System.Reflection;
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

		private Type runningTestType;
		private Action<IRequestInfo> runnerRequestStartedEventhandler;
		private Action<IRequestInfo> runnerRequestEndedEventhandler;

		private ITimeLineController timelineCtrl;

		public TestRunner(ITimeLineController timeline, Type runningTestType)
		{
			timelineCtrl = timeline;
			this.runningTestType = runningTestType;
			runnerRequestStartedEventhandler = new Action<IRequestInfo>(TestRunner_RequestStarted);
			runnerRequestEndedEventhandler = new Action<IRequestInfo>(TestRunner_RequestEnded);
		}

		public void StartTests()
		{
			if (TestRunStarted != null)
				TestRunStarted(this);
			timelineCtrl.StartTimeLine();
			foreach (var plugin in Plugins)
				plugin.TestStarted();

			new Task(() =>
			{
				int delayInBetweenChecks = 20;
				do
				{
                    TryStartNewExecutionThread();
                    if (timelineCtrl.CurrentExecutionThreads == timelineCtrl.MaxExecutionThreads)
                        delayInBetweenChecks = 2000; //no need use the CPU too much the test ended should deal with most of the restarts
					Task.Delay(delayInBetweenChecks);
				} while (timelineCtrl.IsRunning);
			}).Start();
		}

        private bool TryStartNewExecutionThread()
        {
            if (!timelineCtrl.TryStartNewExecutionThread())
                return false;

            timelineCtrl.OnStepStarted();
            var newInstance = (IBaseTest)Activator.CreateInstance(runningTestType, new object[] { });
            newInstance.RequestStarted += runnerRequestStartedEventhandler;
            newInstance.RequestEnded += runnerRequestEndedEventhandler;
            //newInstance.Proxy = this.Proxy;
            newInstance.StartTest(timelineCtrl).ContinueWith(async (Task a) =>
            {
                await a;
                timelineCtrl.OnStepFinished();
                timelineCtrl.ExecutionThreadEnded();
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
			if (timelineCtrl.CurrentExecutionThreads > 0 || timelineCtrl.IsRunning)
            {
                TryStartNewExecutionThread();
                return;
            }
				
			if (TestRunEnded != null)
				TestRunEnded(this);

			foreach (var plugin in Plugins)
				plugin.TestStoped();
		}

		private void TestRunner_RequestStarted(IRequestInfo currentRequest)
		{
			if (Plugins == null)
				return;
			foreach (var plugin in Plugins)
				plugin.RequestStarted(currentRequest);
		}

		private void TestRunner_RequestEnded(IRequestInfo currentRequest)
		{
			if (Plugins == null)
				return;
			foreach (var plugin in Plugins)
				plugin.RequestEnded(currentRequest);
		}

		#region IDisposable Members

		public void Dispose()
		{
			StopTests();
			Plugins = null;
		}

		#endregion
	}
}
