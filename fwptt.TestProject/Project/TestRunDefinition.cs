﻿/*
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
using fwptt.TestProject.Project.TimeLine;
using fwptt.TestProject.Project.Data;

namespace fwptt.TestProject.Project
{
    public class TestRunDefinition: ICloneable
    {
        public TestRunDefinition()
        {
            Id = Guid.NewGuid();
            TestDefinitionOverridedPropertyValues = new List<TestDefinitionPropertyValue>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TestDefinitionId { get; set; }
        public List<TestDefinitionPropertyValue> TestDefinitionOverridedPropertyValues { get; set; }
        public Guid? TestDataSourceId { get; set; }
        public BaseTestRunTimeLine TimeLine { get; set; }
        public List<ExtendableData> RunPlugins { get; set; }

        public object Clone()
        {
            var ret = (TestRunDefinition)this.MemberwiseClone();
            ret.TestDefinitionOverridedPropertyValues = this.TestDefinitionOverridedPropertyValues.Select(tdpl => (TestDefinitionPropertyValue)tdpl.Clone()).ToList();
            ret.TimeLine = (BaseTestRunTimeLine)this.TimeLine.Clone();
            ret.RunPlugins = this.RunPlugins.Select(rp => (ExtendableData)rp.Clone()).ToList();
            return ret;
        }
    }
}
