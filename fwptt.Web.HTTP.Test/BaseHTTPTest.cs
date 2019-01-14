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
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using fwptt.TestProject.Run;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test.Data;
using System.Net.Http;
using System.Net;

namespace fwptt.Web.HTTP.Test
{
    /// <summary>
    /// Summary description for BaseTemplateExecuteClass.
    /// </summary>
    public abstract class BaseHTTPTest:BaseTest<WebRequestInfo>	{
        private Dictionary<string, Tuple<HttpClientHandler, HttpClient>> restClients = new Dictionary<string, Tuple<HttpClientHandler, HttpClient>>();

        private string UserAgent, AcceptedContent;
        protected TimeSpan requestsTimeout = new TimeSpan(0, 0, 0, 0, 120000);


        protected void InitializeHttpClient(string baseUrl, string UserAgent, string AcceptedContent)
		{
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; //disable https checking - all certificates are accepted
            restClients.Clear();
            this.UserAgent = UserAgent;
            this.AcceptedContent = AcceptedContent;
		}

        private Tuple<HttpClientHandler, HttpClient> GetRestClientAndHandler(Uri uri)
        {
            string leftSide = uri.GetLeftPart(UriPartial.Authority);
            Tuple<HttpClientHandler, HttpClient> httpClientAndHandler;
            if (restClients.TryGetValue(leftSide, out httpClientAndHandler))
                return httpClientAndHandler;

            var httpClientHandler = new HttpClientHandler();

            if (Proxy != null)
            {
                httpClientHandler.Proxy = Proxy;
                httpClientHandler.UseProxy = true;
            }

            var client = new HttpClient(httpClientHandler);
            client.Timeout = requestsTimeout;
            httpClientAndHandler = new Tuple<HttpClientHandler, HttpClient>(httpClientHandler, client);
            restClients[leftSide] = httpClientAndHandler;

            return httpClientAndHandler;
        }

        public HttpClientHandler GetRestClientHandler(Uri uri)
        {
            return GetRestClientAndHandler(uri).Item1;
        }


        public HttpClient GetRestClient(Uri uri)
        {
            return GetRestClientAndHandler(uri).Item2;
        }

		public System.Net.WebProxy Proxy {get; set;}
		
				
		#region Util HTTP request/Response processing functions
		protected HttpRequestMessage BuildRequest()
		{
			UriBuilder address = new UriBuilder(CurrentRequest.Request.URL);
			address.Port = CurrentRequest.Request.Port;
            
            var requestMethod = new HttpMethod(CurrentRequest.Request.RequestMethod);

            var sbQueryString = new StringBuilder(CurrentRequest.Request.QueryParams.Count * 20);
			foreach (var param in CurrentRequest.Request.QueryParams)
            {
                if (sbQueryString.Length > 0)
                    sbQueryString.Append('&');
                sbQueryString.Append(param.ParamName).Append('=').Append(param.ParamValue);
            }
            address.Query = sbQueryString.ToString();

            var req = new HttpRequestMessage(requestMethod, address.Uri);
            req.Headers.Add("User-Agent", UserAgent);
            
            if(requestMethod == HttpMethod.Post && CurrentRequest.Request.PostParams.Any())
            {
                req.Content = new FormUrlEncodedContent(CurrentRequest.Request.PostParams.Select(p=>new KeyValuePair<string, string>(p.ParamName, p.ParamValue)));
            }
            else if (requestMethod != HttpMethod.Get && !string.IsNullOrEmpty(CurrentRequest.Request.Payload))
            {
                req.Content = new StringContent(CurrentRequest.Request.Payload, Encoding.UTF8, CurrentRequest.Request.PayloadContentType);
            }
			return req;
		}

        protected async Task ExecuteRequest(HttpRequestMessage req, Func<HttpResponseMessage, bool> processResponse = null, Func<Exception, bool> onError = null)
		{
            CurrentRequest.StartTime = DateTime.Now;
			onRequestStarted();
			try
			{
                var client = this.GetRestClient(CurrentRequest.Request.URL);
                var resp = await client.SendAsync(req).ConfigureAwait(false);
				CurrentRequest.EndTime = DateTime.Now;
				CurrentRequest.ResponseCode = (int)resp.StatusCode;
                CurrentRequest.Response = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
				
				if (processResponse != null)
					this.CancelCurrentRunIteration |= ! processResponse(resp);
				onRequestEnded();
				return;
			}
			catch (System.Threading.ThreadAbortException) //make sure that the exception stops the current thread
			{
				throw;
			}
			catch (Exception ex)
			{
				CurrentRequest.EndTime = DateTime.Now;
				SetException(ex);
				onRequestEnded();
				if(onError != null)
					this.CancelCurrentRunIteration |= onError(ex);
				else
					this.CancelCurrentRunIteration = true;
				return;
			}
		}

		#endregion

		protected void SetException(Exception ex)
		{
			CurrentRequest.Errors.Add(ex.Message + "   -   Stack   - " + ex.StackTrace);
		}

		
		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
