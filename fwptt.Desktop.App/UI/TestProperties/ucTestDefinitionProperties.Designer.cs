namespace fwptt.Desktop.App.UI
{
    partial class ucTestDefinitionProperties
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
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.lblDefaultValue = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.lstBoxProperties = new System.Windows.Forms.ListBox();
            this.txtPropertyDefaultValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Location = new System.Drawing.Point(463, 68);
            this.lblPropertyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(103, 17);
            this.lblPropertyName.TabIndex = 11;
            this.lblPropertyName.Text = "Property Name";
            // 
            // lblDefaultValue
            // 
            this.lblDefaultValue.AutoSize = true;
            this.lblDefaultValue.Location = new System.Drawing.Point(463, 139);
            this.lblDefaultValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultValue.Name = "lblDefaultValue";
            this.lblDefaultValue.Size = new System.Drawing.Size(449, 17);
            this.lblDefaultValue.TabIndex = 12;
            this.lblDefaultValue.Text = "Property Default Value (this Value can be overidded for each test run)";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(21, 5);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(972, 39);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "lblDescription";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 48);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(191, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 48);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(191, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyName.Location = new System.Drawing.Point(463, 91);
            this.txtPropertyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(517, 22);
            this.txtPropertyName.TabIndex = 8;
            this.txtPropertyName.TextChanged += new System.EventHandler(this.txtPropertyName_TextChanged);
            // 
            // lstBoxProperties
            // 
            this.lstBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoxProperties.FormattingEnabled = true;
            this.lstBoxProperties.ItemHeight = 16;
            this.lstBoxProperties.Location = new System.Drawing.Point(16, 91);
            this.lstBoxProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBoxProperties.Name = "lstBoxProperties";
            this.lstBoxProperties.Size = new System.Drawing.Size(397, 260);
            this.lstBoxProperties.TabIndex = 9;
            this.lstBoxProperties.SelectedIndexChanged += new System.EventHandler(this.lstBoxProperties_SelectedIndexChanged);
            // 
            // txtPropertyDefaultValue
            // 
            this.txtPropertyDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyDefaultValue.Location = new System.Drawing.Point(463, 159);
            this.txtPropertyDefaultValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPropertyDefaultValue.Multiline = true;
            this.txtPropertyDefaultValue.Name = "txtPropertyDefaultValue";
            this.txtPropertyDefaultValue.Size = new System.Drawing.Size(517, 192);
            this.txtPropertyDefaultValue.TabIndex = 10;
            this.txtPropertyDefaultValue.TextChanged += new System.EventHandler(this.txtPropertyDefaultValue_TextChanged);
            // 
            // ucTestDefinitionProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDefaultValue);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.txtPropertyDefaultValue);
            this.Controls.Add(this.lstBoxProperties);
            this.Controls.Add(this.txtPropertyName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucTestDefinitionProperties";
            this.Size = new System.Drawing.Size(1000, 379);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.ListBox lstBoxProperties;
        private System.Windows.Forms.TextBox txtPropertyDefaultValue;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.Label lblDefaultValue;
    }
}
