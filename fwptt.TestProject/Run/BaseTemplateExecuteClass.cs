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
using System.Net;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using RestSharp.Contrib;
using fwptt.TestProject.Run.Data;
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject.Run
{
	/// <summary>
	/// Summary description for BaseTemplateExecuteClass.
	/// </summary>
	public abstract class BaseTemplateExecuteClass : IDisposable
	{
		protected ITimeLineController timelineCtrl = null;
		private int StartDelay;
		
		protected RestClient client {get; private set;}

		public string AcceptedContent = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
		

		public event EventHandler RequestStarted;
		public event EventHandler RequestEnded;
		public event EventHandler TestEnded;

		
		protected BaseTemplateExecuteClass(string UserAgent = null)
		{
			client = new RestClient();
			client.UserAgent = UserAgent??"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";            
		}

		#region Requests props and functions
		
		public RequestInfo CurrentRequest {get; protected set;}

		public async Task InitializeCurrentRequest()
		{
			CurrentRequest = new RequestInfo();
			await DoSleep();
		}

		public System.Net.WebProxy Proxy {get; set;}
		#endregion

		private async Task DoSleep()
		{
			int tmp = timelineCtrl.MiliSecondsPauseBetweenRequests / 50;
			if (tmp <= 0)
				tmp = 1;
			for(int i = 0; IsRunning && i < tmp; i++)
				await Task.Delay(50);
		}
				
		#region Util HTTP request/Respons processing functions
		protected RestRequest GetRequest(Uri address, Method method)
		{
				var req = new RestRequest(address, method);
				if (timelineCtrl.MiliSecondsPauseBetweenRequests > 1000)
					req.ReadWriteTimeout = req.Timeout = timelineCtrl.MiliSecondsPauseBetweenRequests;
				else
					req.ReadWriteTimeout = req.Timeout = 1000;
				
//                if (Proxy != null)
//                    req.Proxy = Proxy;
				return req;
		}

		protected async Task<IRestResponse> GetResponse(RestRequest req)
		{
			if (!IsRunning)
				return null;
			try
			{	

				if(RequestStarted != null)
					RequestStarted(this, EventArgs.Empty);
				CurrentRequest.StartTime = DateTime.Now;
				var resp = await client.ExecuteTaskAsync(req);
				CurrentRequest.ResponseCode = (int)resp.StatusCode;
				CurrentRequest.EndTime = DateTime.Now;                
				CurrentRequest.Response = resp.Content;
				return resp;
								  }
			catch (System.Threading.ThreadAbortException) //make sure that the exception stops the current thread
			{
				throw;
			}
			catch (Exception ex)
			{
				CurrentRequest.EndTime = DateTime.Now;
				SetException(ex);                
				return null;
			}

		}
		
		protected void ParseCurrentHtmlContent(Uri responseUri)
		{
			parser.ParseHTML(CurrentRequest.Response.Replace("\r\n", "").Replace("\t", ""), responseUri.ToString());
		}

		fwptt.TestProject.HTMLContent.ContentParser parser = null;
//		protected void SetRequestData(HttpWebRequest req)
//		{
//			try
//			{	
//                req.Accept = AcceptedContent;
//
//				/*var ctrls = parser.GetLastControlsData(req.Method, req.Address);
//                foreach (RequestParam rp in currentRequest.PostParams)
//                    if (rp.ParamName != "__VIEWSTATE" || rp.ParamName != "__VSTATE")
//						ctrls[rp.ParamName] = rp.ParamValue;*/
//
//				StringBuilder postData = new StringBuilder();
//				foreach(string paramname in ctrls.Keys)
//				{
//					if(postData.Length > 0)
//						postData.Append("&");
//					//postData.Append(paramname + "="+System.Web.HttpUtility.HtmlEncode(ctrls[paramname]));
//                    postData.Append(paramname + "=" + ctrls[paramname]);
//				}
//				UTF8Encoding encod = new UTF8Encoding();
//				byte[] postDataBytes = encod.GetBytes(postData.ToString());
//				if(postDataBytes.Length > 0)
//				{
//                    req.ContentType = currentRequest.RequestType;
//					req.ContentLength = postDataBytes.Length;
//					Stream postDataStream = req.GetRequestStream();
//					postDataStream.Write(postDataBytes, 0, postDataBytes.Length);
//					postDataStream.Close();
//				}
//			}
//            catch (System.Threading.ThreadAbortException ex) //make sure that the exception stops the current thread
//            {
//                throw ex;
//            }
//			catch(Exception ex)
//			{
//				SetException(ex);
//			}
//		}

		#endregion

		protected void SetException(Exception ex)
		{
			CurrentRequest.Exception = ex.Message + "   -   Stack   - " + ex.StackTrace;
		}

		#region Params
		/// <summary>
		/// Parse the string params and returns a collection wit all the params
		/// </summary>
		/// <param name="PostData">params in string format</param>
		/// <returns>collection of params</returns>
		public static List<RequestParam> ParseRequestData(string PostData)
		{
			if(string.IsNullOrWhiteSpace(PostData))
				return new List<RequestParam>();
			
			return PostData.Split('&').Select((qp)=>{
													var v = qp.Split('=');
													return new RequestParam(){ 
														ParamName = RestSharp.Contrib.HttpUtility.UrlDecode(v[0]),
														ParamValue= v.Length > 0?RestSharp.Contrib.HttpUtility.UrlDecode(v[1]):string.Empty
													};
										   }).ToList();
		}

		/// <summary>
		/// Creates a string from a param collection
		/// </summary>
		/// <param name="queryParams">collecton of the params</param>
		/// <returns>string that contains all params</returns>
		public static string GetRequestQuery(List<RequestParam> queryParams)
		{
			if(queryParams.Count == 0)
				return string.Empty;
			StringBuilder sb = new StringBuilder(queryParams.Count * 40);
			sb.Append(queryParams[0].ParamName);
			sb.Append("=");
			sb.Append(queryParams[0].ParamValue);
			for(int i = 1; i < queryParams.Count; i++)
			{
				sb.Append("&");
				sb.Append(queryParams[i].ParamName);
				sb.Append("=");
				sb.Append(queryParams[i].ParamValue);
			}
			return sb.ToString();
		}
		#endregion

		#region Test Run Functinos
		protected abstract Task RunTest();

		public bool IsRunning
		{
			get{return timelineCtrl != null && !timelineCtrl.TimeLineRunning;}
		}

		public async Task StartTest(ITimeLineController ptimeline, int pStartDelay)
		{
			StartDelay = pStartDelay;
			StopTest();
			this.timelineCtrl = ptimeline;
			parser = new HTMLContent.ContentParser();
			await RunTest();
		}

		public void StopTest()
		{
			timelineCtrl.StopTimeLine();
			parser = null;
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			parser = null;
			timelineCtrl = null;
			this.RequestStarted = null;
			this.RequestEnded = null;

		}

		#endregion
	}
}
