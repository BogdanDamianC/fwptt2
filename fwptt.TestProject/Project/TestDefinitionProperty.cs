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

namespace fwptt.TestProject.Project
{
    public class TestDefinitionProperty
    {
        public TestDefinitionProperty() { }
        public TestDefinitionProperty(Guid Id) 
        { 
            this.Id = Id;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public override string ToString()
        {
            return (!string.IsNullOrWhiteSpace(Name)?Name:"(Name...)") + " ===>> " + DefaultValue;
        }
    }

    public class TestDefinitionPropertyValue : ICloneable
    {
        public TestDefinitionPropertyValue() { }
        public TestDefinitionPropertyValue(Guid id, string value) 
        {
            TestDefinitionPropertyId = id;
            Value = value;
        }
        public Guid TestDefinitionPropertyId { get; set; }
        public string Value {get; set;}

        public object Clone() => MemberwiseClone();
    }

    public class TestDefinitionRunPropertyValue : TestDefinitionPropertyValue
    {
        public TestDefinitionRunPropertyValue():base() { }
        public TestDefinitionRunPropertyValue(Guid id, string value):base(id, value){}
        public TestDefinitionRunPropertyValue(Guid id, string value, string name) : this(id, value) {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
