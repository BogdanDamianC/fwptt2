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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using fwptt.TestProject.Run;
using fwptt.Web.HTTP.Test.Data;

namespace fwptt.Web.HTTP.Test
{
    /// <summary>
    /// Summary description for BaseTemplateExecuteClass.
    /// </summary>
    public abstract class BaseHTTPTest:BaseTest<WebRequestInfo>	{
        private Dictionary<string, Tuple<HttpClientHandler, HttpClient>> restClients = new Dictionary<string, Tuple<HttpClientHandler, HttpClient>>();

        private string UserAgent, AcceptedContent;
        protected TimeSpan requestsTimeout = new TimeSpan(0, 0, 0, 0, 120000);
        protected string MultipartBoundary = "__fwptt__mpb__load-test____" + Guid.NewGuid().ToString();

        protected void InitializeHttpClient(string baseUrl, string UserAgent, string AcceptedContent)
		{
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
            httpClientHandler.CheckCertificateRevocationList = false;
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;  //disable https checking - all certificates are accepted
            httpClientHandler.MaxRequestContentBufferSize = 10000000;

            if (Proxy != null)
            {
                httpClientHandler.Proxy = Proxy;
                httpClientHandler.UseProxy = true;                
            }

            var client = new HttpClient(httpClientHandler);

            client.DefaultRequestHeaders.ExpectContinue = false;
            client.Timeout = requestsTimeout;
            httpClientAndHandler = new Tuple<HttpClientHandler, HttpClient>(httpClientHandler, client);
            restClients[leftSide] = httpClientAndHandler;
            client.MaxResponseContentBufferSize = 10000000;

            return httpClientAndHandler;
        }

        public HttpClientHandler GetRestClientHandler(Uri uri) => GetRestClientAndHandler(uri).Item1;


        public HttpClient GetRestClient(Uri uri) => GetRestClientAndHandler(uri).Item2;

		public System.Net.WebProxy Proxy {get; set;}


        #region Util HTTP request/Response processing functions
        protected HttpRequestMessage BuildRequest()
        {
            try
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

                if (requestMethod == HttpMethod.Post && CurrentRequest.Request.PostParams.Any())
                {
                    if (CurrentRequest.Request.PayloadContentType == "application/x-www-form-urlencoded")
                        req.Content = new FormUrlEncodedContent(CurrentRequest.Request.PostParams.Select(p => new KeyValuePair<string, string>(p.ParamName, p.ParamValue)));
                    else
                    {
                        var content = new MultipartFormDataContent(MultipartBoundary);
                        foreach (var postParam in CurrentRequest.Request.PostParams)
                            if(postParam.ParamName != null)
                                content.Add(new StringContent(postParam.ParamValue ?? string.Empty), postParam.ParamName);
                        req.Content = content;                        
                    }
                }
                else if (requestMethod != HttpMethod.Get && !string.IsNullOrEmpty(CurrentRequest.Request.Payload))
                {
                    req.Content = new StringContent(CurrentRequest.Request.Payload, Encoding.UTF8, CurrentRequest.Request.PayloadContentType);
                }
                return req;
            }
            catch (System.Threading.ThreadAbortException) //make sure that the exception stops the current thread
            {
                throw;
            }
            catch (Exception ex)
            {
                handleRequestError(ex, null);
                return null;
            }
        }

        protected async Task ExecuteRequest(HttpRequestMessage req, Func<HttpResponseMessage, bool> processResponse = null, Func<Exception, bool> onError = null)
        {
            if (req == null)
                return;
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
                    this.CancelCurrentRunIteration |= !processResponse(resp);
                onRequestEnded();
                return;
            }
            catch (System.Threading.ThreadAbortException) //make sure that the exception stops the current thread
            {
                throw;
            }
            catch (Exception ex)
            {
                handleRequestError(ex, onError);
                return;
            }
        }

        #endregion
    }
}
