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
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
using fwptt.TestProject.Run;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test.Data;


namespace fwptt.Web.HTTP.Test
{
    /// <summary>
    /// Summary description for BaseTemplateExecuteClass.
    /// </summary>
    public abstract class BaseRestSharpHTTPTest : BaseTest<WebRequestInfo>
    {
        private Dictionary<string, RestClient> restClients = new Dictionary<string, RestClient>();

        private string UserAgent, AcceptedContent;

        protected void InitializeHttpClient(string baseUrl, string UserAgent, string AcceptedContent)
        {
            this.UserAgent = UserAgent;
            this.AcceptedContent = AcceptedContent;
        }

        public RestClient GetRestClient(Uri uri)
        {
            string leftSide = uri.GetLeftPart(UriPartial.Authority);
            RestClient client;
            if (this.restClients.TryGetValue(leftSide, out client))
                return client;

            client = new RestClient(leftSide);
            client.UserAgent = UserAgent;
            client.CookieContainer = new System.Net.CookieContainer();
            restClients[leftSide] = client;
            return client;
        }

        public System.Net.WebProxy Proxy { get; set; }


        #region Util HTTP request/Respons processing functions
        protected RestRequest BuildRequest()
        {
            UriBuilder address = new UriBuilder(CurrentRequest.Request.URL);
            address.Port = CurrentRequest.Request.Port;

            var requestMethod = (RestSharp.Method)Enum.Parse(typeof(RestSharp.Method), CurrentRequest.Request.RequestMethod, true);
            var req = new RestRequest(address.Uri, requestMethod);
            if (timelineCtrl.MiliSecondsPauseBetweenRequests > 5000)
                req.ReadWriteTimeout = req.Timeout = timelineCtrl.MiliSecondsPauseBetweenRequests;
            else
                req.ReadWriteTimeout = req.Timeout = 5000;

            foreach (var param in CurrentRequest.Request.QueryParams)
                req.AddParameter(param.ParamName, param.ParamValue, ParameterType.QueryString);
            foreach (var param in CurrentRequest.Request.PostParams)
                req.AddParameter(param.ParamName, param.ParamValue, ParameterType.GetOrPost);

            if (requestMethod != Method.GET && !string.IsNullOrEmpty(CurrentRequest.Request.Payload)
                && (requestMethod != Method.POST || CurrentRequest.Request.PostParams.Count == 0))
            {
                req.AddParameter(CurrentRequest.Request.PayloadContentType, CurrentRequest.Request.Payload, ParameterType.RequestBody);
            }
            //                if (Proxy != null)
            //                    req.Proxy = Proxy;
            return req;
        }

        protected async Task ExecuteRequest(RestRequest req, Func<IRestResponse, bool> processResponse = null, Func<Exception, bool> onError = null)
        {
            CurrentRequest.StartTime = DateTime.Now;
            onRequestStarted();
            try
            {
                var client = this.GetRestClient(CurrentRequest.Request.URL);
                var resp = await client.ExecuteTaskAsync(req);
                CurrentRequest.EndTime = DateTime.Now;
                CurrentRequest.ResponseCode = (int)resp.StatusCode;
                CurrentRequest.Response = resp.Content;

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
                CurrentRequest.EndTime = DateTime.Now;
                SetException(ex);
                onRequestEnded();
                if (onError != null)
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
