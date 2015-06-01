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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project.TimeLine;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProject.Project.Data;
using fwptt.Data.DefaultPlugins.TimeLine;

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(TimeBasedTimeLine.PublicName, "Time Based (runs all the requests for a specific time with a specific number of parallel users)", ExpandableComponentType.TimeLineConfiguration)]
    public partial class ucTimeBasedTimeLineConfiguration : BaseTestRunConfigurationComponent
    {
        public ucTimeBasedTimeLineConfiguration()
        {
            InitializeComponent();
            lblInfo.Text = "When using this time line the test will be ran a specific duration (hours + minutes). The test can be run using one or multiple threads - this simlates multiple users hitting the site in the same time. The pause betwen request helps get the run closer to a real timescenario where you have multiple users doing different actions on the page every 1-10 seconds. The Ramp up time allows for a gradual increase of the number of concurent threads(users) running this test";
        }

        protected override ExtendableData GetNewCurrentData()
        {
            var newData = (TimeBasedTimeLine)base.GetNewCurrentData();
            newData.Minutes = 5;
            newData.NoOfThreads = 2;
            newData.PauseBetweenRequests = 100;
            newData.RampUpSeconds = 30;
            return newData;
        }

        protected override void SetCurrentData(ExtendableData data)
        {
            base.SetCurrentData(data);
 
            txtDurationHour.DataBindings.Add("Text", CurrentData, "Hours");
            txtDurationMinute.DataBindings.Add("Text", CurrentData, "Minutes");

            txtNumberOfThreads.DataBindings.Add("Text", CurrentData, "NoOfThreads");
            txtTimeBetweenRequests.DataBindings.Add("Text", CurrentData, "PauseBetweenRequests");

            txtRampUpMinutes.DataBindings.Add("Text", CurrentData, "RampUpMinutes");
            txtRampUpSeconds.DataBindings.Add("Text", CurrentData, "RampUpSeconds");
        }

        private void ucTimeBasedTimeLine_Load(object sender, EventArgs e)
        {

        }
    }
}
