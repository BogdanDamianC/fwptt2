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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Run.Data;
using System.Threading;

namespace fwptt.TestProject.Run
{
    public interface IBaseTest: IDisposable
    {
        event Action<IRequestInfo> RequestStarted;
        event Action<IRequestInfo> RequestEnded;
        Task StartTest(ITimeLineController ptimeline, Dictionary<string, string> Properties, object testRunRecord);
        IRequestInfo GetCurrentRequest();
    }

    public abstract class BaseTest<RI> : IBaseTest where RI : IRequestInfo, new()
    {
        protected ITimeLineController timelineCtrl = null;
        protected object testRunRecord;
        protected Dictionary<string, string> Properties = null;
        protected bool CancelCurrentRunIteration = false;


        public event Action<IRequestInfo> RequestStarted;
        public event Action<IRequestInfo> RequestEnded;

        public RI CurrentRequest { get; protected set; }
        public IRequestInfo GetCurrentRequest()
        {
            return CurrentRequest;
        }

        protected async Task<bool> InitializeCurrentRequest()
        {
            CurrentRequest = new RI();
            await Task.Delay(timelineCtrl.MiliSecondsPauseBetweenRequests);
            return !CancelCurrentRunIteration;
        }

        protected void onRequestStarted()
        {
            if (RequestStarted != null && timelineCtrl.IsRunning)
                RequestStarted(CurrentRequest);
        }

        protected void onRequestEnded()
        {
            if (RequestEnded != null && timelineCtrl.IsRunning)
                RequestEnded(CurrentRequest);
        }

		protected abstract Task RunTest();


        public async Task StartTest(ITimeLineController ptimeline, Dictionary<string, string> Properties, object testRunRecord)
		{
			this.timelineCtrl = ptimeline;
            this.testRunRecord = testRunRecord;
            this.Properties = Properties;
            this.CancelCurrentRunIteration = false;
			await RunTest();
		}

        public virtual void Dispose()
        {
            this.timelineCtrl = null;
            this.RequestStarted = null;
            this.RequestEnded = null;
        }
    }
}
