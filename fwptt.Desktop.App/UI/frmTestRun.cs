using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fwptt.Desktop.App.UI
{
    public partial class frmTestRun : Form
    {
        private Label lblTestRunName;
        private TextBox txtTextRunName;
        public frmTestRun()
        {
            this.MinimumSize = new Size(200, 200);
            this.Controls.Add(new Label { Text = "Test Run Name", Top = 10, Left = 10 });
            txtTextRunName = new TextBox { Top = 8, Left = this.Controls[0].Right + 10, Width = this.Width - 1 };
            this.Controls.Add(txtTextRunName);

        }

        private int GetNameWidth()
        {
            return 1;
        }
    }
}
