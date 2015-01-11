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

namespace fwptt.Desktop.RequestPlayerPlugIns
{
	public enum TestStatuses {NotRunning = 0, Running = 1, Stopped = 2};
    public static class Util
    {
        public const string BaseUniqueName = "fwptt.Desktop.DefaultPlugIns";
        public static string GetUniqueName(string pluginName)
        {
            return BaseUniqueName + "  -   " + pluginName;
        }
    }
}
