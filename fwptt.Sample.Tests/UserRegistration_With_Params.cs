using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using fwptt.TestProject.Run;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test;
using fwptt.Web.HTTP.Test.Data;
using CsQuery;

namespace IETests
{
    /// <summary>
    /// Sample User Registration with Params for the sample project that can be created using the Visualt Studio 2013 Comunity Edition
    /// this test registers all the users defined in the usersDataSource.txt 
    /// the datasource defined inside the fwptt2.demo.tests.fwptt project
    /// Steps To Run this test 
    /// 1. Set up a site on the localhost or somewhere else 
    /// 2. Open the fwptt2.demo.tests.fwptt project using the fwptt2.Desktop.App.exe
    /// 3. Expand the Test Run Definitions click on "Users Registration" click on "New Run"
    /// 4. Click on Start
    /// </summary>
    public class UsersRegistration_With_Params : BaseHTTPTest
    {
        #region Peristor - 0 http://localhost/testSites/
        private async Task Req_0_GETlocalhost_()
        {
            if (!await InitializeCurrentRequest())
                return;
            CurrentRequest.Request.URL = Properties["Site Domain"] + Properties["Root Path"];
            CurrentRequest.Request.Port = 80;
            CurrentRequest.Request.RequestMethod = @"GET";

            var req = BuildRequest();
            await ExecuteRequest(req); //nothing to process here just loading the first page
        }
        #endregion


        string __VIEWSTATE, __VIEWSTATEGENERATOR, __EVENTVALIDATION;


        #region Peristor - 2 http://localhost/testSites/Account/Register
        private async Task Req_GETlocalhost_Account_Open_RegistrationPage()
        {
            if (!await InitializeCurrentRequest())
                return;
            CurrentRequest.Request.URL = Properties["Site Domain"] + Properties["Root Path"] + "/Account/Register";
            CurrentRequest.Request.Port = 80;
            CurrentRequest.Request.RequestMethod = @"GET";

            var req = BuildRequest();
            await ExecuteRequest(req, (resp) =>
            {
                CQ dom = CQ.Create(resp.Content);

                __VIEWSTATE = dom["#__VIEWSTATE"].Val();
                __VIEWSTATEGENERATOR = dom["#__VIEWSTATEGENERATOR"].Val();
                __EVENTVALIDATION = dom["#__EVENTVALIDATION"].Val();
                return true;
            });
        }
        #endregion


        #region Peristor - 4 http://localhost/testSites/Account/Register
        private async Task Req_POSTlocalhost_Account_Register_New_User()
        {
            if (!await InitializeCurrentRequest())
                return;
            CurrentRequest.Request.URL = Properties["Site Domain"] + Properties["Root Path"] + "/Account/Register";
            CurrentRequest.Request.Port = 80;
            CurrentRequest.Request.RequestMethod = @"POST";
            CurrentRequest.Request.PayloadContentType = @"application/x-www-form-urlencoded";
			var RequestInfo = ((string)testRunRecord).Split('|');
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTTARGET", @""));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTARGUMENT", @""));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATE", __VIEWSTATE));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATEGENERATOR", __VIEWSTATEGENERATOR));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTVALIDATION", __EVENTVALIDATION));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$Email", RequestInfo[0]));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$Password", RequestInfo[1]));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$ConfirmPassword", RequestInfo[1]));
            CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$ctl08", @"Register"));

            var req = BuildRequest();
            await ExecuteRequest(req, (resp) =>
            {
                string errorText = string.Format("Name {0} is already taken.", RequestInfo[0]);
                if (resp.Content.IndexOf(errorText) >= 0)
                {
                    CurrentRequest.Errors.Add(errorText);
                    return false;
                }
                else
                    return true;
            });
        }
        #endregion

        protected override async Task RunTest()
        {
            InitializeHttpClient(Properties["Site Domain"] , "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)"
                , "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*");
            
			await Req_0_GETlocalhost_();
            await Req_GETlocalhost_Account_Open_RegistrationPage();
            await Req_POSTlocalhost_Account_Register_New_User();
			
        }

    }
}
