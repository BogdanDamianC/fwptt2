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

namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    [ExpandableSettings(ResultsViewerConfiguration.PublicName, "Request Viewer", ExpandableComponentType.PluginConfiguration)]
    public partial class ucRequestViewerConfiguration : BaseTestRunConfigurationComponent<ResultsViewerConfiguration>
    {
        public ucRequestViewerConfiguration()
        {
            InitializeComponent();
        }

        public override void SetConfiguration(ExtendableData data)
        {
            base.SetConfiguration(data);
            txtMaxNumberOfRequests.DataBindings.Add("Text", CurrentData, "MaxNumberOfRequestsRecorded");
            txtMaxResponseSize.DataBindings.Add("Text", CurrentData, "MaxResponseSizeRecorded");
            if (CurrentData.RefreshInterval < 500)
                CurrentData.RefreshInterval = 500;
            txtRefreshTime.DataBindings.Add("Value", CurrentData, "RefreshInterval");
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}