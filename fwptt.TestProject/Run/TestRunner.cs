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
		private BaseTemplateExecuteClass [] Instances = null;
		private List<IRequestPlayerPlugIn> Plugins = new List<IRequestPlayerPlugIn>();

		public event EventHandler TestsHaveFinished;
		public event EventHandler RequestStarted;

		private Type lRunnedType;
		EventHandler TestRunner_TestEndedEventHandler;
		EventHandler TestRunner_RequestStartedEventhandler;
		EventHandler TestRunner_RequestEndedEventhandler;

        ITimeLineController timelineCtrl;

		private System.Net.WebProxy l_Proxy = null;

		public TestRunner()
		{
			TestRunner_TestEndedEventHandler = new EventHandler(TestRunner_TestEnded);
			TestRunner_RequestStartedEventhandler = new EventHandler(TestRunner_RequestStarted);
			TestRunner_RequestEndedEventhandler = new EventHandler(TestRunner_RequestEnded);
		}

        public void StartTests(int ConcurentThreads, BaseTestRunTimeLine p_timeline)
        {
            timelineCtrl = p_timeline.GetNewController();
            foreach (var plugin in Plugins)
                plugin.TestStarted();

            Instances = new BaseTemplateExecuteClass[ConcurentThreads];
            var tasks = new Task[ConcurentThreads];
            lock (Instances)
            {
                for (int i = 0; i < ConcurentThreads; i++)
                {
                    Instances[i] = (BaseTemplateExecuteClass)Activator.CreateInstance(lRunnedType, new object[] { });
                    Instances[i].RequestStarted += TestRunner_RequestStartedEventhandler;
                    Instances[i].RequestEnded += TestRunner_RequestEndedEventhandler;
                    Instances[i].TestEnded += TestRunner_TestEndedEventHandler;
                    Instances[i].Proxy = this.Proxy;
                    tasks[i] = Instances[i].StartTest(timelineCtrl, i * timelineCtrl.MiliSecondsPauseBetweenRequests);
                }
            }
            Task.WaitAll(tasks);
        }

		public async Task StopTests()
		{
			if(Instances != null)
			{
                timelineCtrl.StopTimeLine(); //this will make the test instances to stop
                await Task.Delay(timelineCtrl.MiliSecondsPauseBetweenRequests > 1000 ? 1000 : timelineCtrl.MiliSecondsPauseBetweenRequests);//wait for all the instances to stop
                lock (Instances)
                {
                    for (int i = 0; i < Instances.Length; i++)
                    {
                        Instances[i].StopTest();
                        Instances[i] = null;
                    }
                }
				Instances = null;
			}
            timelineCtrl = null;
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

		public Type RunnedType
		{
			get{ return lRunnedType;}
			set{ lRunnedType = value;}
		}

		public BaseTemplateExecuteClass this[int index]
		{
			get{return Instances[index];}
		}

		public int Count
		{
			get
			{
				if(Instances != null)
					return Instances.Length;
				else
					return 0;
			}
		}

		public System.Net.WebProxy Proxy
		{
			get{return l_Proxy;}
			set{l_Proxy = value;}
		}

        private void TestRunner_TestEnded(object sender, EventArgs e)
        {
            if (Instances != null)
                lock (Instances)
                {
                    if (Instances != null)
                    {
                        for (int i = 0; i < Instances.Length; i++)
                        {
                            BaseTemplateExecuteClass tmp = Instances[i];
                            if (tmp != null && tmp.IsRunning)
                                return;
                        }
                    }
                }

            if (TestsHaveFinished != null)
                TestsHaveFinished(this, System.EventArgs.Empty);

            foreach (var plugin in Plugins)
                plugin.TestStoped();

        }

        private void TestRunner_RequestStarted(object sender, EventArgs e)
        {
            if (RequestStarted != null)
                RequestStarted(sender, System.EventArgs.Empty);
            if (Plugins != null)
            {
                RequestInfo rinfo = ((BaseTemplateExecuteClass)sender).CurrentRequest;
                foreach (var plugin in Plugins)
                    plugin.RequestStarted(rinfo);
            }
        }

		private void TestRunner_RequestEnded(object sender, EventArgs e)
		{
            if (Plugins != null)
            {
                RequestInfo rinfo = ((BaseTemplateExecuteClass)sender).CurrentRequest;
                foreach (var plugin in Plugins)
                    plugin.RequestEnded(rinfo);
            }
		}

		#region IDisposable Members

		public void Dispose()
		{
			Task.WaitAll(StopTests());
			Instances = null;
            Plugins.Clear();
		}

		#endregion
	}
}
