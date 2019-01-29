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
using System.Text;
using fwptt.TestProject.Run.Data;

namespace fwptt.Web.HTTP.Test.Data
{
    public class WebRequestInfo:RequestInfo<WebRequest, string>
    {
        public WebRequestInfo()
        {
            this.Request = new WebRequest();
        }
        public int ResponseCode { get; set; }
        public override string ResponseToString() => Response;

        public override void RecordException(Exception ex, string testRunRecordInfo)
        {
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.Append('[').Append(Request.RequestMethod).Append("] - ").Append(Request.URL);
            errorMessage.Append("[testRunRecordInfo: ").Append(testRunRecordInfo ?? "nothing").Append(']');
            RecordRequestParams(errorMessage, nameof(Request.QueryParams), Request.QueryParams);
            RecordRequestParams(errorMessage, nameof(Request.PostParams), Request.PostParams);
            errorMessage.Append(Environment.NewLine).Append(" Error Message: ").Append(ex.Message);
            errorMessage.Append(Environment.NewLine).Append(" Error Stack Trace: ").Append(ex.StackTrace);
            Errors.Add(errorMessage.ToString());
        }
        
        private void RecordRequestParams(StringBuilder sb, string ParamsType, IEnumerable<RequestParam> rParams)
        {
            if (rParams == null || !rParams.Any())
                return;
            sb.Append("[BEGIN - ").Append(ParamsType).Append("----------------").Append(Environment.NewLine);
            foreach (var param in rParams)
                sb.Append(param.ParamName).Append("    -   ").Append(param.ParamValue).Append(';').Append(Environment.NewLine);
            sb.Append(ParamsType).Append("----END]").Append(Environment.NewLine);
        }

        public override string ToString()
        {
            string ret = Errors.Any() ? "Error" : "OK";
            ret = "[" + Request.RequestMethod + "] [" + (Errors.Any() ? "Error" : "OK") + "] [" + Request.URL + "]";
            if (Errors.Any())
                ret += " Error Details:" + string.Join("| ", Errors);
            return ret;
        }
    }
}
