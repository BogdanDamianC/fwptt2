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
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fwptt.TestProject.Run.Data;

namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    public partial class frmModifyRequests : Form
    {
        private ProxyHttpRecorder recorder;

        public frmModifyRequests(ProxyHttpRecorder recorder)
        {
            InitializeComponent();
            this.recorder = recorder;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            requestBindingSource.PositionChanged += new EventHandler(SelectedRequest_Changed);
            requestBindingSource.DataSource = recorder.RequestsMade.Requests;
        }

        private void SelectedRequest_Changed(object sender, EventArgs e)
        {
            var req = requestBindingSource.Current as Request;
            if (req == null)
                return;
            requestQuerryParamBindingSource.DataSource = req.QueryParams;
            requestPostParamBindingSource.DataSource = req.PostParams;
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            if(requestBindingSource.Current != null)
                requestBindingSource.RemoveCurrent();
        }

        private void btnDeleteQuerryParam_Click(object sender, EventArgs e)
        {
            if (requestQuerryParamBindingSource.Current != null)
                requestQuerryParamBindingSource.RemoveCurrent();
        }


        private void btnDeletePostParam_Click(object sender, EventArgs e)
        {
            if (requestPostParamBindingSource.Current != null)
                requestPostParamBindingSource.RemoveCurrent();
        }
    }
}