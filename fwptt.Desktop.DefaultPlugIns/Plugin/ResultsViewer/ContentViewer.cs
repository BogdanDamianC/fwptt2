using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fwptt.Desktop.DefaultPlugIns.Plugin.ResultsViewer
{
    public partial class ContentViewer : Form
    {
        public ContentViewer()
        {
            InitializeComponent();
        }

        public ContentViewer(string content):this()
        {
            txtContent.Text = content ?? string.Empty;
        }
    }
}
