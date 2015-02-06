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

		public event EventHandler TestsHaveFinished;
		public event EventHandler RequestStarted;

		private Type runningTestType;
        private EventHandler runnerRequestStartedEventhandler;
        private EventHandler runnerRequestEndedEventhandler;

		private ITimeLineController timelineCtrl;

		private System.Net.WebProxy l_Proxy = null;

        public TestRunner(ITimeLineController timeline, Type runningTestType)
		{
            timelineCtrl = timeline;
            this.runningTestType = runningTestType;
			runnerRequestStartedEventhandler = new EventHandler(TestRunner_RequestStarted);
			runnerRequestEndedEventhandler = new EventHandler(TestRunner_RequestEnded);
		}

        private int totalNoOfRunningTests = 0;

        public void StartTests()
        {
            timelineCtrl.StartTimeLine();
            foreach (var plugin in Plugins)
                plugin.TestStarted();

            totalNoOfRunningTests = 0;
            new Task(() =>
            {
                int delayInBetweenChecks = timelineCtrl.MiliSecondsPauseBetweenRequests > 0 ? timelineCtrl.MiliSecondsPauseBetweenRequests : 50;
                do
                {
                    if (timelineCtrl.TryStartNewExecutionThread())
                    {
                        totalNoOfRunningTests++;
                        timelineCtrl.OnStepStarted();
                        var newInstance = (IBaseTest)Activator.CreateInstance(runningTestType, new object[] { });
                        newInstance.RequestStarted += runnerRequestStartedEventhandler;
                        newInstance.RequestEnded += runnerRequestEndedEventhandler;
                        //newInstance.Proxy = this.Proxy;
                        newInstance.StartTest(timelineCtrl).ContinueWith(async (Task a)=>{
                            await a;
                            timelineCtrl.OnStepFinished();
                            TestRunner_TestEnded();
                        });
                    }
                    Task.Delay(delayInBetweenChecks);
                } while (timelineCtrl.IsRunning);
            }).Start();
        }

        public void StopTests()
        {
            timelineCtrl.StopTimeLine(); //this will make the test instances to stop  
            timelineCtrl = null;
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

		public System.Net.WebProxy Proxy
		{
			get{return l_Proxy;}
			set{l_Proxy = value;}
		}

		private void TestRunner_TestEnded()
		{
            totalNoOfRunningTests--;
            if (totalNoOfRunningTests > 0)
                return;
			if (TestsHaveFinished != null)
				TestsHaveFinished(this, System.EventArgs.Empty);

			foreach (var plugin in Plugins)
				plugin.TestStoped();
		}

        private void TestRunner_RequestStarted(object sender, EventArgs e)
        {
            if (RequestStarted != null)
                RequestStarted(sender, System.EventArgs.Empty);
            if (Plugins == null)
                return;
            var rinfo = ((IBaseTest)sender).GetCurrentRequest();
            foreach (var plugin in Plugins)
                plugin.RequestStarted(rinfo);
        }

        private void TestRunner_RequestEnded(object sender, EventArgs e)
        {
            if (Plugins == null)
                return;
            var rinfo = ((IBaseTest)sender).GetCurrentRequest();
            foreach (var plugin in Plugins)
                plugin.RequestEnded(rinfo);
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
