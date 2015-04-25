namespace fwptt.Desktop.App.UI
{
    partial class ucEditTestDefinitionValues
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblDefaultValue;
            this.lstBoxProperties = new System.Windows.Forms.ListBox();
            this.txtPropertyDefaultValue = new System.Windows.Forms.TextBox();
            lblDefaultValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.AutoSize = true;
            lblDefaultValue.Location = new System.Drawing.Point(321, 6);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new System.Drawing.Size(76, 13);
            lblDefaultValue.TabIndex = 13;
            lblDefaultValue.Text = "Property Value";
            // 
            // lstBoxProperties
            // 
            this.lstBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoxProperties.FormattingEnabled = true;
            this.lstBoxProperties.Location = new System.Drawing.Point(0, 6);
            this.lstBoxProperties.Name = "lstBoxProperties";
            this.lstBoxProperties.Size = new System.Drawing.Size(299, 147);
            this.lstBoxProperties.TabIndex = 10;
            this.lstBoxProperties.SelectedIndexChanged += new System.EventHandler(this.lstBoxProperties_SelectedIndexChanged);
            // 
            // txtPropertyDefaultValue
            // 
            this.txtPropertyDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyDefaultValue.Location = new System.Drawing.Point(324, 22);
            this.txtPropertyDefaultValue.Multiline = true;
            this.txtPropertyDefaultValue.Name = "txtPropertyDefaultValue";
            this.txtPropertyDefaultValue.Size = new System.Drawing.Size(362, 115);
            this.txtPropertyDefaultValue.TabIndex = 11;
            this.txtPropertyDefaultValue.TextChanged += new System.EventHandler(this.txtPropertyDefaultValue_TextChanged);
            // 
            // ucEditTestDefinitionValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(lblDefaultValue);
            this.Controls.Add(this.txtPropertyDefaultValue);
            this.Controls.Add(this.lstBoxProperties);
            this.Name = "ucEditTestDefinitionValues";
            this.Size = new System.Drawing.Size(689, 151);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxProperties;
        private System.Windows.Forms.TextBox txtPropertyDefaultValue;
    }
}
