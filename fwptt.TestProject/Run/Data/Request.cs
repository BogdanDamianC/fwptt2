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
using System.Linq;
using System.Runtime.Serialization;

namespace fwptt.TestProject.Run.Data
{
	[Serializable]	
	public class Request
	{
        public Request()
        {
            QueryParams = new List<RequestParam>();
            PostParams = new List<RequestParam>();
        }
		public string URL {get; set;}
        public int Port {get; set;}
		public string RequestMethod {get; set;}
        public string PayloadContentType { get; set; }
		public List<RequestParam> QueryParams {get; set;}
        public List<RequestParam> PostParams { get; set; }
        public string Payload { get; set; }
        
        
        private static readonly string [] httpMethods = new string[]{"GET","POST","PUT","DELETE","HEAD", "CONNECT"};
        
        public static Request FromFiddlerLog(string LogContent)
		{
			var retVal = new Request();
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
					retVal.URL = address.Scheme + "://" + address.Host + address.AbsolutePath;
                    retVal.Port = address.Port;
					if(!string.IsNullOrWhiteSpace(address.Query))
						retVal.QueryParams.AddRange(BaseTemplateExecuteClass.ParseRequestData(address.Query.Substring(1)));
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
						retVal.PostParams.AddRange(BaseTemplateExecuteClass.ParseRequestData(retVal.Payload));
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
        
	}
}

