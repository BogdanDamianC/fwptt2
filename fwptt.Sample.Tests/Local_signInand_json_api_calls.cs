using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using fwptt.TestProject.Run;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test;
using fwptt.Web.HTTP.Test.Data;
using CsQuery;

namespace IETests
{
	public class Local_signInand_json_api_calls:BaseHTTPTest
	{
		private const string SiteDomainPropName = "Site Domain";
				string sp___VIEWSTATE,sp___VIEWSTATEGENERATOR,sp___EVENTVALIDATION;
		
			
		#region Request - 0 /testSites/Account/Login
		private async Task Req_0_GETlocalhost_testSites_Account_Login()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/Account/Login";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								CQ requestDOM = CQ.Create(resp.Content);
								sp___VIEWSTATE = requestDOM["#__VIEWSTATE"].Val();
								sp___VIEWSTATEGENERATOR = requestDOM["#__VIEWSTATEGENERATOR"].Val();
								sp___EVENTVALIDATION = requestDOM["#__EVENTVALIDATION"].Val();
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 1 /testSites/Account/Login
		private async Task Req_1_POSTlocalhost_testSites_Account_Login()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/Account/Login";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"POST";
						CurrentRequest.Request.PayloadContentType = @"application/x-www-form-urlencoded";
			CurrentRequest.Request.Payload = @"__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=74K1yr9qHr7G3q7ruprwFzT5zgTNfgsiA0WO%2BOolEb%2FCPwiTXxQ4QdbY2UGZEQ56Ztr3jUpKfZaRIFvb0oopL0ExW5rNXya1jkXUSdOqQHqJGbX8jj0%2B9pV%2BSUY1k9%2BdLTlUvUgWH2%2Fw%2F5DliWQ3fU%2BkAIqXsYpZOELR1Z96jdoyVmucWjw5KCJInXINNLBja%2BhTG79qZvcP9HhHPZrolqjrugL9CG7s9NPhJXGXxOvyf%2FlZ21%2BmLVKPatE3vvgi4F1IDj6ij0OeT3BtK6RfJJsX9U5piFUsLPS%2B3OnLExgrxvrNsFXXLMa26nzTpKfxo9S%2FiUQIRdiEUTL5E6EW79xcSZyAh3kySog6h%2F0kMmW4OFW4nBY684rH3tAmeiOE&__VIEWSTATEGENERATOR=096DA286&__EVENTVALIDATION=vr0saVbrCK9k22Aj1syJ9ZiBYO%2B2mYxM33jlSjhxv9SlekXLe2BbnSiacJjkEJp8tijF7LvSlfvErVnF%2BwVf7wmvNhFAub%2FD0FMFIzAiiwkE6Wra%2BwYeGJHWgRiuKmUL2PbFzaz6osrCD0hzrRZAsemIe5Wyse5UhYZLvJwgYGUWSVfKoO48Ju26hBVxFZ1O&ctl00%24MainContent%24Email=test%40test.com&ctl00%24MainContent%24Password=1&ctl00%24MainContent%24ctl05=Log+in";
									
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTTARGET",@""));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTARGUMENT",@""));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATE",sp___VIEWSTATE));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATEGENERATOR",sp___VIEWSTATEGENERATOR));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTVALIDATION",sp___EVENTVALIDATION));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$Email",@"test@test.com"));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$Password",@"1"));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"ctl00$MainContent$ctl05",@"Log in"));
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 2 /testSites/
		private async Task Req_2_GETlocalhost_testSites_()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 3 /testSites/testwebapicalls
		private async Task Req_3_GETlocalhost_testSites_testwebapicalls()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/testwebapicalls";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 4 /testSites/api/me
		private async Task Req_4_GETlocalhost_testSites_api_me()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 5 /testSites/api/me/1144
		private async Task Req_5_GETlocalhost_testSites_api_me_1144()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/1144";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 6 /testSites/api/me/1144
		private async Task Req_6_POSTlocalhost_testSites_api_me_1144()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/1144";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"POST";
						CurrentRequest.Request.PayloadContentType = @"application/x-www-form-urlencoded";
			CurrentRequest.Request.Payload = @"=testing%20with%20a%20sample%20value";
									
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"",@"testing with a sample value"));
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 7 /testSites/api/me/1144
		private async Task Req_7_PUTlocalhost_testSites_api_me_1144()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/1144";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"PUT";
						CurrentRequest.Request.PayloadContentType = @"application/x-www-form-urlencoded";
			CurrentRequest.Request.Payload = @"=testing%20with%20a%20sample%20value";
									
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"",@"testing with a sample value"));
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 8 /testSites/api/me/1144
		private async Task Req_8_DELETElocalhost_testSites_api_me_1144()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/1144";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"DELETE";
									
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"",@"testing with a sample value"));
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 9 /testSites/api/me/
		private async Task Req_9_POSTlocalhost_testSites_api_me_()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"POST";
						CurrentRequest.Request.PayloadContentType = @"application/json";
			CurrentRequest.Request.Payload = @"{""cc"":{""cVal1"":""1144"",""cVal2"":""testing with a sample value"",""cVal3"":"" Test JSON POST""}}";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 10 /testSites/api/me/
		private async Task Req_10_PUTlocalhost_testSites_api_me_()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"PUT";
						CurrentRequest.Request.PayloadContentType = @"application/json";
			CurrentRequest.Request.Payload = @"{""cc"":{""cVal1"":""1144"",""cVal2"":""testing with a sample value"",""cVal3"":"" Test JSON PUT""}}";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 11 /testSites/api/me/
		private async Task Req_11_DELETElocalhost_testSites_api_me_()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/api/me/";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"DELETE";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								CQ requestDOM = CQ.Create(resp.Content);
								sp___VIEWSTATE = requestDOM["#__VIEWSTATE"].Val();
								sp___VIEWSTATEGENERATOR = requestDOM["#__VIEWSTATEGENERATOR"].Val();
								sp___EVENTVALIDATION = requestDOM["#__EVENTVALIDATION"].Val();
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 12 /testSites/testwebapicalls
		private async Task Req_12_POSTlocalhost_testSites_testwebapicalls()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/testwebapicalls";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"POST";
						CurrentRequest.Request.PayloadContentType = @"application/x-www-form-urlencoded";
			CurrentRequest.Request.Payload = @"__EVENTTARGET=ctl00%24ctl13%24ctl02%24ctl00&__EVENTARGUMENT=&__VIEWSTATE=e7B2f3cYhwRu7MZ7cFL0wRUbj3lrVnwESMMmKiQ%2F68Eb8RC4YHBQsWi9RiNrs1TrSeThJ71t4B5uUItQDlcnCqJx3wTnX6vyeU0oBMyeoN3mzqNWE5QDerN4gX9a%2FMiuB8m%2Bj7aM1w2LkeE67AH7kpPo7F81fyWpyBpG23wp8pjaJbgF2R24Ww4QTmtzCKidGA6yeXdbcjVCFXH%2B3QypQqMwSHEeKKg7r9yXwlyZ3ohMxHH%2FiQlNWQZwU0Cbf8KXi7kgRM1P1i7fqXgaH9H2EJCm2PNEETSzWUFsgVtJY%2BkbgIx7VDU0iWJ79DCKIIFHPQ12xbKK0PfNkmd%2BtYelXSiu4EMGmRiIWZc1l1ey6X8%3D&__VIEWSTATEGENERATOR=5F1A406F&__EVENTVALIDATION=SE6HlNJ1mYkC7RHPKGQJYjlY72uT3%2F21pARn07BsLekOkV1umAuQbwY%2BNWrUPHQefyvH15f4U1bvETpQ%2FqbPxtPT8kdiV4dYdurLHylZoR%2FI95h5aF7zBSYvLUAcKsvV";
									
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTTARGET",@"ctl00$ctl13$ctl02$ctl00"));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTARGUMENT",@""));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATE",sp___VIEWSTATE));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__VIEWSTATEGENERATOR",sp___VIEWSTATEGENERATOR));
			CurrentRequest.Request.PostParams.Add(new RequestParam(@"__EVENTVALIDATION",sp___EVENTVALIDATION));
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
			
		#region Request - 13 /testSites/
		private async Task Req_13_GETlocalhost_testSites_()
		{
            if (!await InitializeCurrentRequest())
                return;
						CurrentRequest.Request.URL = Properties[SiteDomainPropName] + @"/testSites/";
						
			CurrentRequest.Request.Port = 80;
			CurrentRequest.Request.RequestMethod = @"GET";
									
			
			var req = BuildRequest();		
			await ExecuteRequest(req,(resp)=>{
								return true;//Add response handling stuff here if needed - return true for the current run to continue or false to cancel it
			});
		}
		#endregion
				
		protected override async Task RunTest()
		{		
			InitializeHttpClient(Properties[SiteDomainPropName],
			"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)"
			,"image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*");
			await Req_0_GETlocalhost_testSites_Account_Login();
			await Req_1_POSTlocalhost_testSites_Account_Login();
			await Req_2_GETlocalhost_testSites_();
			await Req_3_GETlocalhost_testSites_testwebapicalls();
			await Req_4_GETlocalhost_testSites_api_me();
			await Req_5_GETlocalhost_testSites_api_me_1144();
			await Req_6_POSTlocalhost_testSites_api_me_1144();
			await Req_7_PUTlocalhost_testSites_api_me_1144();
			await Req_8_DELETElocalhost_testSites_api_me_1144();
			await Req_9_POSTlocalhost_testSites_api_me_();
			await Req_10_PUTlocalhost_testSites_api_me_();
			await Req_11_DELETElocalhost_testSites_api_me_();
			await Req_12_POSTlocalhost_testSites_testwebapicalls();
			await Req_13_GETlocalhost_testSites_();
					
		}
	}
}