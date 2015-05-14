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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Text;
using System.Reflection;
using fwptt.TestProject.Run.Data;
using fwptt.Desktop.Util;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Web.HTTP.Test.Data;
using fwptt.TestProject.Project;



namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
	/// <summary>
	/// Summary description for RecordIERequests.
	/// </summary>
    [Description("Web Test Wizzard")]
    public class frmTestDefinitionGenerator : System.Windows.Forms.Form, ITestDefinitionGeneratorWizzard
	{
		private System.Windows.Forms.Button btnStartRecording;
		private System.Windows.Forms.Button btnSaveRecordingData;
		private System.Windows.Forms.Button btnGenerateTestProgramCode;
		private System.Windows.Forms.Button btnClearRecordedData;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnLoadAllreadyRecordedData;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Button btnViewModifyRequests;
		private ProxyHttpRecorder recorder = new ProxyHttpRecorder();
		private System.Windows.Forms.Button btnLoadFiddlerData;

		public frmTestDefinitionGenerator()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			recorder.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnViewModifyRequests = new System.Windows.Forms.Button();
            this.btnLoadAllreadyRecordedData = new System.Windows.Forms.Button();
            this.btnClearRecordedData = new System.Windows.Forms.Button();
            this.btnGenerateTestProgramCode = new System.Windows.Forms.Button();
            this.btnSaveRecordingData = new System.Windows.Forms.Button();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnLoadFiddlerData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(159, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Test Name (use only alphanumeric chars)";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(162, 219);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(198, 20);
            this.txtClassName.TabIndex = 7;
            this.txtClassName.Text = "tmp_test";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 56);
            this.label2.TabIndex = 9;
            this.label2.Text = "It will open the recording window where you can record the http requests made fro" +
    "m any browser.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(368, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 56);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clears any requests data that you have recorded or loaded.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(368, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 56);
            this.label4.TabIndex = 11;
            this.label4.Text = "Loads the requests that you have previously saved in an json file with \'Save Reco" +
    "rded Data\'.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(8, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 56);
            this.label5.TabIndex = 12;
            this.label5.Text = "Saves all the http requests that you have recorded in an Json file.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(8, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 54);
            this.label6.TabIndex = 13;
            this.label6.Text = "Imports the requests recorded using Fiddler";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(368, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 54);
            this.label7.TabIndex = 14;
            this.label7.Text = "View/Modify the Data";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewModifyRequests
            // 
            this.btnViewModifyRequests.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnViewModifyRequests.Location = new System.Drawing.Point(264, 8);
            this.btnViewModifyRequests.Name = "btnViewModifyRequests";
            this.btnViewModifyRequests.Size = new System.Drawing.Size(96, 56);
            this.btnViewModifyRequests.TabIndex = 16;
            this.btnViewModifyRequests.Text = "View / Modify Recorded Data";
            this.btnViewModifyRequests.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewModifyRequests.Click += new System.EventHandler(this.btnViewModifyRequests_Click);
            // 
            // btnLoadAllreadyRecordedData
            // 
            this.btnLoadAllreadyRecordedData.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadAllreadyRecordedData.Location = new System.Drawing.Point(264, 136);
            this.btnLoadAllreadyRecordedData.Name = "btnLoadAllreadyRecordedData";
            this.btnLoadAllreadyRecordedData.Size = new System.Drawing.Size(96, 56);
            this.btnLoadAllreadyRecordedData.TabIndex = 5;
            this.btnLoadAllreadyRecordedData.Text = "Load Allready Recorded Data";
            this.btnLoadAllreadyRecordedData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadAllreadyRecordedData.Click += new System.EventHandler(this.btnLoadAllreadyRecordedData_Click);
            // 
            // btnClearRecordedData
            // 
            this.btnClearRecordedData.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearRecordedData.Location = new System.Drawing.Point(264, 72);
            this.btnClearRecordedData.Name = "btnClearRecordedData";
            this.btnClearRecordedData.Size = new System.Drawing.Size(96, 56);
            this.btnClearRecordedData.TabIndex = 4;
            this.btnClearRecordedData.Text = "Clear Recorded Data";
            this.btnClearRecordedData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearRecordedData.Click += new System.EventHandler(this.btnClearRecordedData_Click);
            // 
            // btnGenerateTestProgramCode
            // 
            this.btnGenerateTestProgramCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateTestProgramCode.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerateTestProgramCode.Location = new System.Drawing.Point(8, 251);
            this.btnGenerateTestProgramCode.Name = "btnGenerateTestProgramCode";
            this.btnGenerateTestProgramCode.Size = new System.Drawing.Size(504, 56);
            this.btnGenerateTestProgramCode.TabIndex = 3;
            this.btnGenerateTestProgramCode.Text = "Generate Test Definition (C# class)";
            this.btnGenerateTestProgramCode.Click += new System.EventHandler(this.btnGenerateTestProgramCode_Click);
            // 
            // btnSaveRecordingData
            // 
            this.btnSaveRecordingData.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveRecordingData.Location = new System.Drawing.Point(162, 136);
            this.btnSaveRecordingData.Name = "btnSaveRecordingData";
            this.btnSaveRecordingData.Size = new System.Drawing.Size(96, 56);
            this.btnSaveRecordingData.TabIndex = 2;
            this.btnSaveRecordingData.Text = "Save Recorded Data";
            this.btnSaveRecordingData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveRecordingData.Click += new System.EventHandler(this.btnSaveRecordingData_Click);
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartRecording.Location = new System.Drawing.Point(162, 72);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(96, 56);
            this.btnStartRecording.TabIndex = 0;
            this.btnStartRecording.Text = "Start Recording (http only - no https support)";
            this.btnStartRecording.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
            // 
            // btnLoadFiddlerData
            // 
            this.btnLoadFiddlerData.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadFiddlerData.Location = new System.Drawing.Point(162, 8);
            this.btnLoadFiddlerData.Name = "btnLoadFiddlerData";
            this.btnLoadFiddlerData.Size = new System.Drawing.Size(96, 56);
            this.btnLoadFiddlerData.TabIndex = 17;
            this.btnLoadFiddlerData.Text = "Import Fiddler Data (recomended)";
            this.btnLoadFiddlerData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadFiddlerData.Click += new System.EventHandler(this.BtnLoadFiddlerDataClick);
            // 
            // frmTestDefinitionGenerator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(520, 315);
            this.Controls.Add(this.btnLoadFiddlerData);
            this.Controls.Add(this.btnViewModifyRequests);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadAllreadyRecordedData);
            this.Controls.Add(this.btnClearRecordedData);
            this.Controls.Add(this.btnGenerateTestProgramCode);
            this.Controls.Add(this.btnSaveRecordingData);
            this.Controls.Add(this.btnStartRecording);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestDefinitionGenerator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Record/Import/Requests & Generate C# Test class";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnStartRecording_Click(object sender, System.EventArgs e)
		{
			frmDORequestsRecording tmp = new frmDORequestsRecording(recorder);
			tmp.ShowDialog(this);
			tmp.Dispose();
		}
		
		private void btnLoadAllreadyRecordedData_Click(object sender, System.EventArgs e)
		{
            var fileName = UI_Util.PickOpenFile(this, "JSON files (*.json)|*.json|All files (*.*)|*.*");
            if(string.IsNullOrWhiteSpace(fileName))
                return;
			try
			{
                using (StreamReader file = File.OpenText(fileName))
                {
                    recorder.RequestsMade = JsonConvert.DeserializeObject<RecordedTestDefinition>(file.ReadToEnd());
                }
                txtClassName.Text = recorder.RequestsMade.ClassName;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.StackTrace);
			}
			
		}

		private void btnClearRecordedData_Click(object sender, System.EventArgs e)
		{
			recorder.RequestsMade.Requests.Clear();
		}

        private void btnSaveRecordingData_Click(object sender, System.EventArgs e)
        {
            recorder.RequestsMade.ClassName = txtClassName.Text;
            var destination = UI_Util.PickSaveFile(this, "JSON files (*.json)|*.json|All files (*.*)|*.*", "json");
            if (string.IsNullOrWhiteSpace(destination))
                return;
            try
            {
                File.WriteAllText(destination, JsonConvert.SerializeObject(recorder.RequestsMade, Newtonsoft.Json.Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewModifyRequests_Click(object sender, EventArgs e)
        {
            using (var frm = new frmModifyRequests(recorder))
                frm.ShowDialog(this);
        }

        public string GeneratedTestDefinitionClassName { get; set; }
        public string GeneratedTestDefinitionClassCode { get; set; }
        public List<TestDefinitionProperty> Properties { get; set; }

        private void btnGenerateTestProgramCode_Click(object sender, System.EventArgs e)
        {
            try
            {
                recorder.RequestsMade.ClassName = txtClassName.Text.Trim();
                string mainSiteHost = getMainSiteHost();
                Properties = new List<TestDefinitionProperty>();
                Properties.Add(new TestDefinitionProperty() { Name = "Site Domain", DefaultValue = mainSiteHost });
                GeneratedTestDefinitionClassCode = TestCSharpCodeGenerator.GenerateCode(recorder.RequestsMade, mainSiteHost);
                GeneratedTestDefinitionClassName = recorder.RequestsMade.ClassName;
                this.Close();
            }
            catch (Exception ex)
            {
                GeneratedTestDefinitionClassCode = null;
                MessageBox.Show(ex.Message);
            }
        }

        private string getMainSiteHost()
        {
            var urls = (from uri in
                            (from req in recorder.RequestsMade.Requests
                             select new Uri(req.URL.ToString()))
                        select uri).ToArray();
            if (urls.Length == 0)
                throw new ApplicationException("No Base url can be found");

            return (from d in urls
                    group d by d.Scheme + "://" + d.Host into ug
                    select new { ug.Key, cnt = ug.Count() }).OrderByDescending(ug => ug.cnt).First().Key;
        }

        private string GetZipRequestFileContent(ZipEntry ze)
        {
            using (var ms = new MemoryStream())
            {
                ze.Extract(ms);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

		void BtnLoadFiddlerDataClick(object sender, EventArgs e)
		{
            string fileToOpen = UI_Util.PickOpenFile(this, "Fiddler files (*.saz)|*.saz|All files (*.*)|*.*");
            if (string.IsNullOrWhiteSpace(fileToOpen))
                return;
			try
			{
                var importedRecords = new List<Tuple<int, fwptt.Web.HTTP.Test.Data.WebRequest>>();
                var unImportedRequests = new List<string>();
                using (ZipFile zipFile = ZipFile.Read(fileToOpen))
				{
					foreach (ZipEntry ze in zipFile)
					{
						int requestIndex;
						if(!ze.FileName.StartsWith("raw/") || !ze.FileName.EndsWith("_c.txt")
							   || !int.TryParse(ze.FileName.Replace("raw/","").Replace("_c.txt",""), out requestIndex))
							continue;
                        string RequestMessage = string.Empty;
                        try
                        {
                            RequestMessage = GetZipRequestFileContent(ze);
                            var newRequest = fwptt.Web.HTTP.Test.Data.WebRequest.FromFiddlerLog(RequestMessage);
                            if (newRequest != null && newRequest.RequestMethod.ToUpper() != "CONNECT")
                                importedRecords.Add(new Tuple<int, fwptt.Web.HTTP.Test.Data.WebRequest>(requestIndex, newRequest));

                        }
                        catch (Exception ex)
                        {
                            unImportedRequests.Add(RequestMessage + ex.Message + ex.StackTrace);
                        }
					}
				}
				recorder.RequestsMade.Requests.AddRange(from ir in importedRecords orderby ir.Item1 select ir.Item2);
                if(unImportedRequests.Any())
                    throw new ApplicationException(string.Format("Errors ocurred while importing {0} records {1} Details: {1} {2}", 
                        unImportedRequests.Count, Environment.NewLine, string.Join(Environment.NewLine, unImportedRequests)));
			}
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error ocurred during import");
            }
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + ex.StackTrace);
			}
		}
	}
}
