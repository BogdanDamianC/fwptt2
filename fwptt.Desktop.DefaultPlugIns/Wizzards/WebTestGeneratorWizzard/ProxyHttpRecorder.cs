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
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Net;
using fwptt.TestProject.Run.Data;
using fwptt.TestProject.Run;
using fwptt.Web.HTTP.Test.Data;
using fwptt.Web.HTTP.Test;


namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
	/// <summary>
	/// Summary description for ProxyHttpRecorder.
	/// </summary>
	public class ProxyHttpRecorder :IDisposable
	{		
		Org.Mentalis.Proxy.Http.HttpListener httpListener;

		public ProxyHttpRecorder()
		{
			RequestsMade = new RecordedTestDefinition();
			ProxyPort = 10123;
			StartIEAutomatically = false;
			ExcludedRequests = new string []{"javascript"};
			ProxyIP = GetLocalIPAddress();
		}

		public void StartRecording() 
		{
			StartProxy();
		}

		public void StopRecording()
		{
			StopProxy();
		}

		private void ProcessRequest(string tmpURL, string Method, string PostData)
		{
			if(string.IsNullOrWhiteSpace(Method) || Method.ToUpper() == "CONNECT")
				return;
			UriBuilder tmpuri = null;
			try
			{
				tmpuri = new UriBuilder(tmpURL);
			}
			catch //don't record invaild uris
			{
				return;
			}
			
			for(int i = 0; i < ExcludedRequests.Length; i++)
				if(ExcludedRequests[i].Length > 0
					&& tmpuri.Path.Length >  ExcludedRequests[i].Length 
					&& tmpuri.Path.Substring(tmpuri.Path.Length - ExcludedRequests[i].Length, ExcludedRequests[i].Length).ToLower().Equals(ExcludedRequests[i].ToLower()))
				{
					return;
				}

            var newr = new fwptt.Web.HTTP.Test.Data.WebRequest
            {
                URL = tmpuri.Scheme + "://" + tmpuri.Host + tmpuri.Path,
                Port = tmpuri.Port
            };
            

			string qery = tmpuri.Query.Trim();
			if(qery.Length > 0)
			{				
				if(qery[0] == '?')
                    newr.QueryParams = BaseHTTPTest.ParseRequestData(qery.Substring(1));
				else
                    newr.QueryParams = BaseHTTPTest.ParseRequestData(qery);
			}
			
			newr.RequestMethod = Method.ToUpper();

			if(newr.RequestMethod == "POST")
                newr.PostParams = BaseHTTPTest.ParseRequestData(System.Web.HttpUtility.UrlDecode(PostData));

            RequestsMade.Requests.Add(newr);
		}


		#region Public Properties
		public RecordedTestDefinition RequestsMade {get; set;}
		public IPAddress ProxyIP {get; set;}
		public int ProxyPort {get; set;}
		public bool StartIEAutomatically {get; set;}
		public string [] ExcludedRequests {get; set;}
		#endregion

		#region Proxy runner
		private void StartProxy()
		{
			lock(this)
			{
				if(httpListener == null)
				{
                    IPAddress localIP = null;
                    if (this.ProxyIP != null)
                        localIP = this.ProxyIP;
                    else
                        localIP = GetLocalIPAddress();

					httpListener = new Org.Mentalis.Proxy.Http.HttpListener(localIP, ProxyPort);
					httpListener.RequestResource +=new Org.Mentalis.Proxy.Http.ResourceRequested(httpListener_RequestResource);
					httpListener.Start();
				}
			}
		}

		private void StopProxy()
		{
			lock(this)
			{
				if(httpListener != null)
					httpListener.Dispose();
				httpListener = null;
			}
		}
		#endregion

		private IPAddress GetLocalIPAddress()
		{
			string strHostName = string.Empty;
			strHostName = Dns.GetHostName ();
			IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
			
			return ipEntry.AddressList[0];
		}

		private void httpListener_RequestResource(Org.Mentalis.Proxy.Http.HttpRequestInfo info)
		{
			ProcessRequest(info.RequestedPath, info.HttpRequestType, info.HttpPost);
		}

		#region IDisposable Members

		public void Dispose()
		{
			StopRecording();
		}

		#endregion

	}
}
