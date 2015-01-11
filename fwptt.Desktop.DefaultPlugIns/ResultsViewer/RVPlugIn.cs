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
using fwptt.TestProject.Project.Interfaces;

namespace fwptt.Desktop.RequestPlayerPlugIns.ResultsViewer
{
	/// <summary>
	/// Summary description for ResultsViewer.
	/// </summary>
	public class RVPlugIn:IRequestPlayerPlugIn
	{
		private FrmResultsViewer frmrv = null;
		public RVPlugIn()
		{

		}
		#region IRequestPlayerPlugIn Members

        public void Initialize(IRequestPlayer player)
		{
			frmrv = new FrmResultsViewer();
            frmrv.MdiParent = (System.Windows.Forms.Form)player.PlayerInfo;
			frmrv.Show();
		}

		public void TestStarted()
		{
			frmrv.TestStarted();
		}

		public void TestStoped()
		{
			frmrv.TestEnded();
		}

		public void RequestStarted(RequestInfo rinfo)
		{
			//TODO
		}

		public void RequestEnded(RequestInfo rinfo)
		{
			frmrv.AddRequest(rinfo);
		}

		public string Name{get {return "Default - Results Viewer";}}


        public string UniqueName { get { return Util.GetUniqueName("Results Viewer"); } }
		public string Description{get {return "Provides recording/vizualization and html content view";}}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if(frmrv != null)
				frmrv.Dispose();
			frmrv = null;
		}

		#endregion

    }
}
