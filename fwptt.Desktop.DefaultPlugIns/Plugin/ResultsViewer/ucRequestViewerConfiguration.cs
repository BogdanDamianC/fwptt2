﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fwptt.TestProject.Project.Interfaces;
using fwptt.Data.DefaultPlugins.ResultsViewer;
using fwptt.TestProject.Project.Data;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    [ExpandableSettings(ResultsViewerConfiguration.PublicName, "Request Viewer - Provides recording/vizualization and html content view", ExpandableComponentType.PluginConfiguration)]
    public partial class ucRequestViewerConfiguration : BaseTestRunConfigurationComponent
    {
        public ucRequestViewerConfiguration()
        {
            InitializeComponent();
        }

        protected override ExtendableData GetNewCurrentData()
        {
            var newData = (ResultsViewerConfiguration)base.GetNewCurrentData();
            newData.MaxNumberOfRequestsRecorded = 100;
            newData.MaxResponseSizeRecorded = 2000;
            newData.RefreshInterval = 5;
            return newData;
        }

        public override void SetConfiguration(ExtendableData data)
        {
            base.SetConfiguration(data);
            txtMaxNumberOfRequests.DataBindings.Add("Text", CurrentData, "MaxNumberOfRequestsRecorded");
            txtMaxResponseSize.DataBindings.Add("Text", CurrentData, "MaxResponseSizeRecorded");
            if (((ResultsViewerConfiguration)CurrentData).RefreshInterval < 1)
                ((ResultsViewerConfiguration)CurrentData).RefreshInterval = 1;
            txtRefreshTime.DataBindings.Add("Value", CurrentData, "RefreshInterval");
        }
    }
}
