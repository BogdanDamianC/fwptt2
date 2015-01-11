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

namespace fwptt.Desktop.RequestPlayerPlugIns.RequestsCounter
{
	/// <summary>
	/// Summary description for ReqCounterPlugIn.
	/// </summary>
	public class ReqCounterPlugIn : IRequestPlayerPlugIn
	{
		private FrmCounterViewer frmrcv = null;
		public ReqCounterPlugIn()
		{

		}

		#region IRequestPlayerPlugIn Members

		public void Initialize(IRequestPlayer player)
		{
			frmrcv = new FrmCounterViewer();
            frmrcv.MdiParent = (System.Windows.Forms.Form)player.PlayerInfo;
			frmrcv.Show();
		}

		public void RequestStarted(RequestInfo rinfo)
		{
			// TODO:  Add ReqCounterPlugIn.RequestStarted implementation
		}

		public void TestStoped()
		{
			frmrcv.TestEnded();
		}

		public void TestStarted()
		{
			frmrcv.TestStarted();
		}

		public string Description
		{
			get
			{
				return "Tells the number of executed requests/second ";
			}
		}

        public string UniqueName
        {
            get { return Util.GetUniqueName("Requests Counter"); }
        }

		public string Name
		{
			get
			{
				return "Default - Requests Counter";
			}
		}

		public void RequestEnded(RequestInfo rinfo)
		{
			frmrcv.RequestEnded();
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			if(frmrcv != null)
				frmrcv.Dispose();
			frmrcv = null;
		}

		#endregion

    }
}
