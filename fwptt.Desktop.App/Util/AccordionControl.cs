/*
 * Ported from https://jfblier.wordpress.com/2011/02/16/window-form-expander/
 * Anonymous
March 8, 2012 at 1:52 pm
You don’t mention a license for this code – is it open license?
jfblier
March 8, 2012 at 2:37 pm
Yes, it’s a open license. You can use it.
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fwptt.Desktop.App.Util
{
    public class AccordionControl : Panel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AccordionControl()
        {
            components = new System.ComponentModel.Container();
            this.AutoScroll = this.AutoSize = false;
        }

        public void Add(ExpanderControl expander)
        {
            if (this.Controls.Count > 0)
                expander.Collapse();
            expander.Width = this.Width;
            expander.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.Controls.Add(expander);
            expander.StateChanged += new EventHandler(expander_StateChanged);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            SetHeights();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            SetHeights();
        }

        private bool disableLayoutUpdate = false;
        void expander_StateChanged(object sender, EventArgs e)
        {
            if (this.disableLayoutUpdate)
                return;
            disableLayoutUpdate = true;
            try
            {
                ExpanderControl expander = sender as ExpanderControl;
                foreach (ExpanderControl ex in Controls)
                {
                    if (ex == expander)
                        continue;

                    if (ex.Expanded)
                        ex.Collapse();
                }
                SetHeights();
            }
            finally
            {
                disableLayoutUpdate = false;
            }
        }

        private void SetHeights()
        {
            int h = 0;
            foreach (ExpanderControl ex in this.Controls)
            {
                ex.Top = h;
                h += ex.Height;
            }
            this.Height = h;
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
