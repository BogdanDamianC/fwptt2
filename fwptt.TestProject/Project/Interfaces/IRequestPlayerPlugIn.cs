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
using fwptt.TestProject.Run.Data;
using fwptt.TestProject;

namespace fwptt.TestProject.Project.Interfaces
{
	/// <summary>
	/// Summary description for RequestPlayerPlugIn.
	/// </summary>
	public interface IRequestPlayerPlugIn:IDisposable
	{
		void Initialize(IRequestPlayer player);
		void TestStarted();
		void TestStoped();
		void RequestStarted(RequestInfo rinfo);
		void RequestEnded(RequestInfo rinfo);
		/// <summary>
		/// the nameof the plugin - it will be displayed in the UI for the users to use
		/// </summary>
		string Name{get;}
		string Description{get;}
	}

	/// <summary>
	/// Summary description for RequestPlayerPlugIn.
	/// </summary>
	public interface IRequestPlayer
	{
		object PlayerInfo { get; }
	}
}