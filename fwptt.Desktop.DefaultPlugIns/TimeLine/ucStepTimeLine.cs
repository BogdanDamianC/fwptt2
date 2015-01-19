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

namespace fwptt.Desktop.DefaultPlugIns.TimeLine
{
    [ExpandableSettings(SteppingTimeLine.PublicName, "Finite Number of Runs (runs all the requests a specific number of times)", ExpandableComponentType.TimeLineConfiguration)]
    public partial class ucStepTimeLine : BaseTestRunConfigurationComponent<SteppingTimeLine>
    {
        public ucStepTimeLine()
        {
            InitializeComponent();
        }

        public override void SetConfiguration(ExtendableData data)
        {
            base.SetConfiguration(data);
            txtNumberOfThreads.DataBindings.Add("Text", CurrentData, "MaxSteps");
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
