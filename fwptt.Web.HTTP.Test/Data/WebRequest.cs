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
using fwptt.TestProject.Run.Data;

namespace fwptt.Web.HTTP.Test.Data
{
    [Serializable]	
	public class WebRequest
	{
		public Uri URL {get; set;}
        public int Port {get; set;}
		public string RequestMethod {get; set;}
        public string PayloadContentType { get; set; }
		public List<RequestParam> QueryParams {get; set;} = new List<RequestParam>();
        public List<RequestParam> PostParams { get; set; } = new List<RequestParam>();
        public string Payload { get; set; }

        #region Fiddler Log Parsing
        private static readonly string [] httpMethods = new string[]{"GET","POST","PUT", "PATCH", "DELETE","HEAD", "CONNECT", "OPTIONS"};
        
        public static WebRequest FromFiddlerLog(string LogContent)
		{
			var retVal = new WebRequest();
			bool PayloadNext = false;
			for(int start = 0, end = LogContent.IndexOf(Environment.NewLine); 0<=start && start < LogContent.Length;start = end+Environment.NewLine.Length, end = LogContent.IndexOf(Environment.NewLine, start))
			{
				string lineText= string.Empty;
					
				if(end == start)
				{
					PayloadNext = true;
					continue;
				}
				else if(end > start)
					lineText = LogContent.Substring(start, end-start);
				else
					lineText = LogContent.Substring(start);
				
				var httpmethod = httpMethods.FirstOrDefault(lineText.StartsWith);
				if(httpmethod != null)
				{
					retVal.RequestMethod = httpmethod;					
					var address = new Uri(lineText.Split(' ')[1]);
					retVal.URL = new Uri(address.GetLeftPart(UriPartial.Path));
                    retVal.Port = address.Port;
					if(!string.IsNullOrWhiteSpace(address.Query))
                        retVal.QueryParams.AddRange(ParseRequestData(address.Query.Substring(1)));
					continue;
				}
				var httpproperty = GetHttpProperty(lineText);
				if(httpproperty != null && httpproperty.Item1 == httpProperties[0])
		        {
		        	retVal.PayloadContentType = httpproperty.Item2;
		        	continue;
		        }
				
				if(PayloadNext)
				{
					retVal.Payload = lineText;
					if(retVal.PayloadContentType == "application/x-www-form-urlencoded")
					{
                        retVal.PostParams.AddRange(ParseRequestData(retVal.Payload));
					}
					break;
				}
				else
					PayloadNext |= lineText.Trim().Length == 0;					
			}
			
			return retVal;
		}
        
        private static readonly string [] httpProperties = new string[]{"Content-Type"};
        private static Tuple<string, string> GetHttpProperty(string lineText)
        {
        	var httpproperty = httpProperties.FirstOrDefault(lineText.StartsWith);
        	if(httpproperty == null)
        		return null;
        	var endmarker = lineText.IndexOf(';', httpproperty.Length + 1);
        	if(endmarker < 0)
                return new Tuple<string, string>(httpproperty, lineText.Substring(httpproperty.Length + 1).Trim());
        	else 
        		return new Tuple<string, string>(httpproperty, lineText.Substring(httpproperty.Length + 1, endmarker - httpproperty.Length - 1).Trim());
        }
        #endregion

        private static List<RequestParam> ParseRequestData(string PostData)
        {
            if (string.IsNullOrWhiteSpace(PostData))
                return new List<RequestParam>();

            return PostData.Split('&').Select((qp) => {
                var v = qp.Split('=');
                return new RequestParam()
                {
                    ParamName = System.Web.HttpUtility.UrlDecode(v[0]),
                    ParamValue = v.Length > 0 ? System.Web.HttpUtility.UrlDecode(v[1]) : string.Empty
                };
            }).ToList();
        }

    }
}

