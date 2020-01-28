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
using System.Windows.Forms;
using System.IO;
using fwptt.TestProject;
using fwptt.TestProject.Project.Interfaces;
using fwptt.TestProjectHost;

namespace fwptt.Desktop.App.UI
{
    public class MainApplication
    {
        internal static CurrentUserContextData CurrentUserContextData;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CurrentUserContextData = new CurrentUserContextData();
            CurrentUserContextData.Load();
           MainProvider.Current = new DefaultHost(Application.StartupPath, Path.Combine(Application.StartupPath, "PlugIn"));
            if (args.Length > 0)
               MainProvider.Current.LoadProject(args[0]);
            Application.Run(new frmTestProjectDefinition());
            CurrentUserContextData.Save();
        }
	}
}