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

namespace fwptt.Desktop.RequestPlayerPlugIns.TimeLine
{
    [ExpandableSettings(TimeBasedTimeLine.PublicName, "Time Based (runs all the requests for a specific time with a specific number of parallel users)", ExpandableComponentType.TimeLineConfiguration)]
    public partial class ucTimeBasedTimeLine : UserControl, ITestRunConfigurationComponent
    {
        private TimeBasedTimeLine CurrentTimeLine;
        public ucTimeBasedTimeLine()
        {
            InitializeComponent();
        }

        private void SetDisplayProperties()
        {
            txtDurationHour.Enabled = txtDurationMinute.Enabled = rbDurationHourAndMinutes.Checked;
            txtDurationNoOfSeconds.Enabled = rbDurationSeconds.Checked;
            txtRampUpMinutes.Enabled = txtRampUpSeconds.Enabled = rbRampUpTimeMinutesAndSeconds.Checked;
        }

        private void rbDurationHourAndMinutes_CheckedChanged(object sender, EventArgs e)
        {
            SetDisplayProperties();
        }

        private void rbDurationSeconds_CheckedChanged(object sender, EventArgs e)
        {
            SetDisplayProperties();
        }

        private void rbRampUpTimeMinutesAndSeconds_CheckedChanged(object sender, EventArgs e)
        {
            SetDisplayProperties();
        }

        private void rdRampUpTimeNoRampUpTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDisplayProperties();
        }


        public ExtendableData NewConfiguration()
        {
            return new TimeBasedTimeLine(100);
        }

        public void SetConfiguration(ExtendableData timeLine)
        {
            var stepTL = timeLine as TimeBasedTimeLine;
            CurrentTimeLine = stepTL != null ? stepTL : (TimeBasedTimeLine)NewConfiguration();
        }

        public bool IsValid()
        {
            return true;
        }

        public ExtendableData GetConfiguration()
        {
            return CurrentTimeLine;
        }
        
    }
}
