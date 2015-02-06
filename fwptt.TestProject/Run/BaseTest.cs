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
        event EventHandler RequestStarted;
        event EventHandler RequestEnded;
        Task StartTest(ITimeLineController ptimeline);
        IRequestInfo GetCurrentRequest();
    }

    public abstract class BaseTest<RI> : IBaseTest where RI : IRequestInfo, new()
    {
        protected ITimeLineController timelineCtrl = null;
        public event EventHandler RequestStarted;
        public event EventHandler RequestEnded;

        public RI CurrentRequest { get; protected set; }
        public IRequestInfo GetCurrentRequest()
        {
            return CurrentRequest;
        }

        protected async Task InitializeCurrentRequest()
        {
            CurrentRequest = new RI();
            await DoSleep();
        }

        protected void onRequestStarted()
        {
            if (!timelineCtrl.IsRunning)
                throw new ApplicationException("Run has Stopped"); 
            if (RequestStarted != null)
                RequestStarted(this, EventArgs.Empty);
        }

        private async Task DoSleep()
        {
            int tmp = timelineCtrl.MiliSecondsPauseBetweenRequests / 100;
            if (tmp <= 0)
                tmp = 1;
            for (int i = 0; timelineCtrl.IsRunning && i < tmp; i++)
                await Task.Delay(100);
        }

		protected abstract Task RunTest();

		public virtual async Task StartTest(ITimeLineController ptimeline)
		{
			this.timelineCtrl = ptimeline;
			await RunTest();
		}

        public virtual void Dispose()
        {
            timelineCtrl = null;
            this.RequestStarted = null;
            this.RequestEnded = null;
        }
    }
}
