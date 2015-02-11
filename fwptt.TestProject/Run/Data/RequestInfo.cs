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
using System.Runtime.Serialization;


namespace fwptt.TestProject.Run.Data
{
    public interface IRequestInfo
    {
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        List<string> Errors { get; }
        /// <summary>
        /// Request Duration in Seconds
        /// </summary>
        double Duration { get; }
        IRequestInfo Clone();
    }
	[Serializable]	
	public abstract class RequestInfo<TIn, TOut>:IRequestInfo
	{
        public RequestInfo() {
            Errors = new List<string>();
        }
		public TIn Request  { get; set; }
        public TOut Response { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> Errors { get; private set; }
        public double Duration { get { return EndTime.Subtract(StartTime).TotalMilliseconds; } }

        public IRequestInfo Clone()
        {
            return (IRequestInfo)this.MemberwiseClone();
        }
	}
}

