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
        Task StartTest(ITimeLineController ptimeline, object testRunRecord);
        IRequestInfo GetCurrentRequest();
    }

    public abstract class BaseTest<RI> : IBaseTest where RI : IRequestInfo, new()
    {
        protected ITimeLineController timelineCtrl = null;
        protected object testRunRecord;
        public event Action<IRequestInfo> RequestStarted;
        public event Action<IRequestInfo> RequestEnded;

        public RI CurrentRequest { get; protected set; }
        public IRequestInfo GetCurrentRequest()
        {
            return CurrentRequest;
        }

        protected async Task InitializeCurrentRequest()
        {
            CurrentRequest = new RI();
            await Task.Delay(timelineCtrl.MiliSecondsPauseBetweenRequests);
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

		public virtual async Task StartTest(ITimeLineController ptimeline, object testRunRecord)
		{
			this.timelineCtrl = ptimeline;
            this.testRunRecord = testRunRecord;
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
