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
using System.Threading.Tasks;
using fwptt.TestProject.Run.Data;

namespace fwptt.Web.HTTP.Test.Data
{
    public class WebRequestInfo:RequestInfo<WebRequest, string>
    {
        public WebRequestInfo()
        {
            this.Request = new WebRequest();
        }
        public Int32 ResponseCode { get; set; }
        public override string ResponseToString()
        {
            return Response;
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
