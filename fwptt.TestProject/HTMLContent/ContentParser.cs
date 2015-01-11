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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Majestic12;

namespace fwptt.TestProject.HTMLContent
{
	/// <summary>
	/// Summary description for ContentParser.
	/// </summary>
	public class ContentParser
	{
        List<HTMLForm> forms = new List<HTMLForm>();
		HTMLparser parser = null;
		public ContentParser()
		{
			parser = new Majestic12.HTMLparser();
			parser.SetChunkHashMode(false);
			parser.bKeepRawHTML=false;
			parser.bDecodeEntities=true;
			parser.bAutoExtractBetweenTagsOnly=true;
			parser.bAutoKeepComments=true;
			parser.bAutoKeepScripts=true;
			parser.bCompressWhiteSpaceBeforeTag=true;
			parser.bAutoMarkClosedTagsWithParamsAsOpen=false;
		}

		private void FillFormData(HTMLForm frm, HTMLchunk oChunk, string RequestURL)
		{
			string tmpstr = oChunk.GetParamValue("action");
			if(tmpstr != null)
			{
				frm.action = tmpstr;
				if(!frm.action.StartsWith("http")) //url is relative
				{
					if(!frm.action.StartsWith("/"))
					{
						int i = RequestURL.LastIndexOf("/");
						if(i >= 0)
							frm.action = RequestURL.Substring(0, i+1) + tmpstr;
					}
					else 
					{
						int i = RequestURL.LastIndexOf("/");
						if(i >= 0)
							frm.action = RequestURL.Substring(0, i) + "/" + tmpstr;
					}
				}
			}
		
			tmpstr = oChunk.GetParamValue("id");
			if(tmpstr != null)
				frm.Form_id = tmpstr;

			tmpstr = oChunk.GetParamValue("name");
			if(tmpstr != null)
				frm.name = tmpstr;
			tmpstr = oChunk.GetParamValue("method");
			if(tmpstr != null)
				frm.method = tmpstr.ToUpper();
		}

		private void FillInputControlData(HTMLControl ctrl, HTMLchunk oChunk)
		{
			string tmpstr = oChunk.GetParamValue("id");
			if(tmpstr != null)
				ctrl.Control_id = tmpstr;

			tmpstr = oChunk.GetParamValue("name");
			if(tmpstr != null)
				ctrl.name = tmpstr;
			tmpstr = oChunk.GetParamValue("value");
			if(tmpstr != null)
				ctrl.value = tmpstr;
		}

		public void ParseHTML(string htmlContent, string RequestURL)
		{
			forms.Clear();
			parser.CleanUp();
			parser.Init(htmlContent);
			HTMLchunk oChunk=null;
			HTMLForm frm = null;

			while((oChunk=parser.ParseNext())!=null)
			{
				string tagname = oChunk.sTag.ToLower();
				switch(oChunk.oType)
				{
					case HTMLchunkType.OpenTag:
						if(tagname == "form")
						{
							frm = new HTMLForm();
                            forms.Add(frm);
							FillFormData(frm, oChunk, RequestURL);
						}
						else if(tagname == "input")
						{
							string tmpstr = oChunk.GetParamValue("type");
							if(tmpstr != null)
							{
								tmpstr = tmpstr.ToUpper();
                                if (tmpstr != "SUBMIT" && tmpstr != "RESET" && tmpstr != "FILE" && tmpstr != "BUTTON")
                                {
                                    FillInputControlData(GetNewControl(frm), oChunk);
                                }
							}
						}
						break;
					case HTMLchunkType.CloseTag:
						if(tagname == "input")
						{
							string tmpstr = oChunk.GetParamValue("type");
							if(tmpstr != null)
							{
								tmpstr = tmpstr.ToUpper();
								if(tmpstr != "SUBMIT" && tmpstr != "RESET" && tmpstr != "FILE" && tmpstr != "BUTTON")									
									FillInputControlData(GetNewControl(frm), oChunk);
							}
						}
						break;
				}
			}
		}

        private static HTMLControl GetNewControl(HTMLForm frm)
        {
            var newcontrol = new HTMLControl();
            frm.Controls.Add(newcontrol);
            return newcontrol;
        }

		public Dictionary<string, string> GetLastControlsData(string Method, Uri Url)
		{
            var htret = new Dictionary<string, string>();
			Method = Method.ToUpper();
			foreach(HTMLForm frm in forms)
			{
				if(frm.action.Length <= 0)
					continue;
				if(frm.method.Length > 0 && frm.method != Method)
					continue;
				
				Uri action = new Uri(frm.action);
				if(action.Host.ToLower() == Url.Host.ToLower()
					&& action.AbsolutePath.ToLower() == Url.AbsolutePath.ToLower())
				{
					foreach(HTMLControl ctrl in frm.Controls)
					{
						if(ctrl.Control_id.Length > 0)
							htret[ctrl.Control_id] = ctrl.value;
						else if(ctrl.name.Length > 0)
							htret[ctrl.name] = ctrl.value;
					}
					break;
				}
			}
			return htret;
		}

	}
}
