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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace fwptt.Desktop.Util
{
    public class ExpanderControl : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ExpanderControl()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Expanded = true;
        }

        #region Events

        public event EventHandler StateChanged;
        public event CancelEventHandler StateChanging;

        #endregion

        #region Properties

        public bool Expanded { get; private set; }

        public Control Header
        {
            get { return this.header; }

            set
            {
                if (this.header != null)
                    this.Controls.Remove(this.header);

                this.header = value;
                this.header.Cursor = Cursors.Hand;
                this.header.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                this.header.Width = this.Width;
                this.Controls.Add(this.header);
                this.Controls.SetChildIndex(this.header, this.Controls.Count > 1 ? 1 : 0);
            }
        }

        public Control Content
        {
            get { return this.content; }

            set
            {
                if (this.content != null)
                    this.Controls.Remove(this.content);

                this.content = value;
                this.Content.Anchor = AnchorStyles.Left | AnchorStyles.Top;                
                this.content.Top = this.header.Height;
                this.Height = this.header.Height + this.content.Height;

                this.Controls.Add(this.content);
                this.Controls.SetChildIndex(this.content, 0);
            }
        }

        #endregion

        #region Public methods

        public void Expand()
        {
            if (this.Expanded)
                return;

            if (StateChanging != null)
            {
                CancelEventArgs args = new CancelEventArgs();
                StateChanging(this, args);
                if (args.Cancel)
                    return;
            }

            this.Expanded = true;
            ArrangeLayout();

            if (StateChanged != null)
                StateChanged(this, null);
        }

        public void Collapse()
        {
            if (!this.Expanded)
                return;

            if (StateChanging != null)
            {
                CancelEventArgs args = new CancelEventArgs();
                StateChanging(this, args);
                if (args.Cancel)
                    return;
            }
            this.Expanded = false;
            ArrangeLayout();

            if (StateChanged != null)
                StateChanged(this, null);
        }

        public void Toggle()
        {
            if (this.Expanded)
                Collapse();
            else
                Expand();
        }

        #endregion

        #region Private methods
        
        private void ArrangeLayout()
        {
            int h = 0;
            if (this.header != null)
                h += this.header.Height;
            if (this.Expanded && this.content != null)
                h += this.content.Height;
            this.Height = h;
        }

        #endregion
        
        #region Private fields

        private Control header;
        private Control content;

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.Header != null && this.Content != null)
                this.Header.Width = this.Content.Width = this.ClientSize.Width;
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                this.header = null;
                this.content = null;
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public static Label CreateLabelHeader(ExpanderControl expander, string text, Color backColor, Image collapsedImage = null, Image expandedImage = null, int height = 25, Font font = null)
        {
            Label headerLabel = new Label();
            headerLabel.Text = text;
            headerLabel.AutoSize = false;
            headerLabel.Height = height;
            if (font != null)
                headerLabel.Font = font;
            headerLabel.TextAlign = ContentAlignment.MiddleLeft;
            if (collapsedImage != null && expandedImage != null)
            {
                headerLabel.Image = collapsedImage;
                headerLabel.ImageAlign = ContentAlignment.MiddleRight;
            }
            headerLabel.BackColor = backColor;

            if (collapsedImage != null && expandedImage != null)
            {
                expander.StateChanged += delegate { headerLabel.Image = expander.Expanded ? collapsedImage : expandedImage; };
            }

            headerLabel.Click += delegate { expander.Toggle(); };
            expander.Header = headerLabel;
            return headerLabel;
        }
    }
}
