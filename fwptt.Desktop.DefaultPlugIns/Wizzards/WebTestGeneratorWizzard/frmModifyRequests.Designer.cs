namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    partial class frmModifyRequests
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	this.dgRequests = new System.Windows.Forms.DataGrid();
        	this.requestBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
        	this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.grpBoxReqList = new System.Windows.Forms.GroupBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnDeleteRequest = new System.Windows.Forms.Button();
        	this.grpBoxPostParams = new System.Windows.Forms.GroupBox();
        	this.dgPostParams = new System.Windows.Forms.DataGrid();
        	this.requestPostParamBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
        	this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.panel3 = new System.Windows.Forms.Panel();
        	this.btnDeletePostParam = new System.Windows.Forms.Button();
        	this.grpBoxQuerryParams = new System.Windows.Forms.GroupBox();
        	this.dgQuerryParams = new System.Windows.Forms.DataGrid();
        	this.requestQuerryParamBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
        	this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.btnDeleteQuerryParam = new System.Windows.Forms.Button();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).BeginInit();
        	this.grpBoxReqList.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.grpBoxPostParams.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgPostParams)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestPostParamBindingSource)).BeginInit();
        	this.panel3.SuspendLayout();
        	this.grpBoxQuerryParams.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgQuerryParams)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestQuerryParamBindingSource)).BeginInit();
        	this.panel2.SuspendLayout();
        	this.tableLayoutPanel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// dgRequests
        	// 
        	this.dgRequests.AllowNavigation = false;
        	this.dgRequests.DataMember = "";
        	this.dgRequests.DataSource = this.requestBindingSource;
        	this.dgRequests.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgRequests.FlatMode = true;
        	this.dgRequests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	this.dgRequests.Location = new System.Drawing.Point(3, 49);
        	this.dgRequests.Name = "dgRequests";
        	this.dgRequests.Size = new System.Drawing.Size(1192, 261);
        	this.dgRequests.TabIndex = 12;
        	this.dgRequests.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
			this.dataGridTableStyle1});
        	// 
        	// requestBindingSource
        	// 
        	this.requestBindingSource.DataSource = typeof(fwptt.TestProject.Run.Data.Request);
        	// 
        	// dataGridTableStyle1
        	// 
        	this.dataGridTableStyle1.DataGrid = this.dgRequests;
        	this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
			this.dataGridTextBoxColumn1,
			this.dataGridTextBoxColumn3,
			this.dataGridTextBoxColumn2,
			this.dataGridTextBoxColumn8});
        	this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	// 
        	// dataGridTextBoxColumn1
        	// 
        	this.dataGridTextBoxColumn1.Format = "";
        	this.dataGridTextBoxColumn1.FormatInfo = null;
        	this.dataGridTextBoxColumn1.HeaderText = "URL";
        	this.dataGridTextBoxColumn1.MappingName = "URL";
        	this.dataGridTextBoxColumn1.Width = 400;
        	// 
        	// dataGridTextBoxColumn3
        	// 
        	this.dataGridTextBoxColumn3.Format = "";
        	this.dataGridTextBoxColumn3.FormatInfo = null;
        	this.dataGridTextBoxColumn3.MappingName = "Port";
        	this.dataGridTextBoxColumn3.Width = 80;
        	// 
        	// dataGridTextBoxColumn2
        	// 
        	this.dataGridTextBoxColumn2.Format = "";
        	this.dataGridTextBoxColumn2.FormatInfo = null;
        	this.dataGridTextBoxColumn2.HeaderText = "Method";
        	this.dataGridTextBoxColumn2.MappingName = "RequestMethod";
        	this.dataGridTextBoxColumn2.Width = 50;
        	// 
        	// dataGridTextBoxColumn8
        	// 
        	this.dataGridTextBoxColumn8.Format = "";
        	this.dataGridTextBoxColumn8.FormatInfo = null;
        	this.dataGridTextBoxColumn8.HeaderText = "Payload";
        	this.dataGridTextBoxColumn8.MappingName = "Payload";
        	this.dataGridTextBoxColumn8.Width = 75;
        	// 
        	// grpBoxReqList
        	// 
        	this.tableLayoutPanel1.SetColumnSpan(this.grpBoxReqList, 2);
        	this.grpBoxReqList.Controls.Add(this.dgRequests);
        	this.grpBoxReqList.Controls.Add(this.panel1);
        	this.grpBoxReqList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.grpBoxReqList.Location = new System.Drawing.Point(3, 3);
        	this.grpBoxReqList.Name = "grpBoxReqList";
        	this.grpBoxReqList.Size = new System.Drawing.Size(1198, 313);
        	this.grpBoxReqList.TabIndex = 13;
        	this.grpBoxReqList.TabStop = false;
        	this.grpBoxReqList.Text = "List of Requests";
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.btnDeleteRequest);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(3, 16);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(1192, 33);
        	this.panel1.TabIndex = 13;
        	// 
        	// btnDeleteRequest
        	// 
        	this.btnDeleteRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnDeleteRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnDeleteRequest.Location = new System.Drawing.Point(1093, 3);
        	this.btnDeleteRequest.Name = "btnDeleteRequest";
        	this.btnDeleteRequest.Size = new System.Drawing.Size(96, 28);
        	this.btnDeleteRequest.TabIndex = 0;
        	this.btnDeleteRequest.Text = "Delete";
        	this.btnDeleteRequest.UseVisualStyleBackColor = true;
        	this.btnDeleteRequest.Click += new System.EventHandler(this.btnDeleteRequest_Click);
        	// 
        	// grpBoxPostParams
        	// 
        	this.grpBoxPostParams.Controls.Add(this.dgPostParams);
        	this.grpBoxPostParams.Controls.Add(this.panel3);
        	this.grpBoxPostParams.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.grpBoxPostParams.Location = new System.Drawing.Point(608, 322);
        	this.grpBoxPostParams.Name = "grpBoxPostParams";
        	this.grpBoxPostParams.Size = new System.Drawing.Size(593, 314);
        	this.grpBoxPostParams.TabIndex = 1;
        	this.grpBoxPostParams.TabStop = false;
        	this.grpBoxPostParams.Text = "Post Params";
        	// 
        	// dgPostParams
        	// 
        	this.dgPostParams.DataMember = "";
        	this.dgPostParams.DataSource = this.requestPostParamBindingSource;
        	this.dgPostParams.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgPostParams.FlatMode = true;
        	this.dgPostParams.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	this.dgPostParams.Location = new System.Drawing.Point(3, 48);
        	this.dgPostParams.Name = "dgPostParams";
        	this.dgPostParams.Size = new System.Drawing.Size(587, 263);
        	this.dgPostParams.TabIndex = 14;
        	this.dgPostParams.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
			this.dataGridTableStyle3});
        	// 
        	// requestPostParamBindingSource
        	// 
        	this.requestPostParamBindingSource.DataMember = "PostParams";
        	this.requestPostParamBindingSource.DataSource = typeof(fwptt.TestProject.Run.Data.Request);
        	// 
        	// dataGridTableStyle3
        	// 
        	this.dataGridTableStyle3.DataGrid = this.dgPostParams;
        	this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
			this.dataGridTextBoxColumn6,
			this.dataGridTextBoxColumn7});
        	this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	// 
        	// dataGridTextBoxColumn6
        	// 
        	this.dataGridTextBoxColumn6.Format = "";
        	this.dataGridTextBoxColumn6.FormatInfo = null;
        	this.dataGridTextBoxColumn6.HeaderText = "Name";
        	this.dataGridTextBoxColumn6.MappingName = "ParamName";
        	this.dataGridTextBoxColumn6.Width = 150;
        	// 
        	// dataGridTextBoxColumn7
        	// 
        	this.dataGridTextBoxColumn7.Format = "";
        	this.dataGridTextBoxColumn7.FormatInfo = null;
        	this.dataGridTextBoxColumn7.HeaderText = "Value";
        	this.dataGridTextBoxColumn7.MappingName = "ParamValue";
        	this.dataGridTextBoxColumn7.Width = 75;
        	// 
        	// panel3
        	// 
        	this.panel3.Controls.Add(this.btnDeletePostParam);
        	this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel3.Location = new System.Drawing.Point(3, 16);
        	this.panel3.Name = "panel3";
        	this.panel3.Size = new System.Drawing.Size(587, 32);
        	this.panel3.TabIndex = 15;
        	// 
        	// btnDeletePostParam
        	// 
        	this.btnDeletePostParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnDeletePostParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnDeletePostParam.Location = new System.Drawing.Point(487, 4);
        	this.btnDeletePostParam.Name = "btnDeletePostParam";
        	this.btnDeletePostParam.Size = new System.Drawing.Size(96, 28);
        	this.btnDeletePostParam.TabIndex = 0;
        	this.btnDeletePostParam.Text = "Delete";
        	this.btnDeletePostParam.UseVisualStyleBackColor = true;
        	this.btnDeletePostParam.Click += new System.EventHandler(this.btnDeletePostParam_Click);
        	// 
        	// grpBoxQuerryParams
        	// 
        	this.grpBoxQuerryParams.Controls.Add(this.dgQuerryParams);
        	this.grpBoxQuerryParams.Controls.Add(this.panel2);
        	this.grpBoxQuerryParams.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.grpBoxQuerryParams.Location = new System.Drawing.Point(3, 322);
        	this.grpBoxQuerryParams.Name = "grpBoxQuerryParams";
        	this.grpBoxQuerryParams.Size = new System.Drawing.Size(599, 314);
        	this.grpBoxQuerryParams.TabIndex = 0;
        	this.grpBoxQuerryParams.TabStop = false;
        	this.grpBoxQuerryParams.Text = "Querry Params";
        	// 
        	// dgQuerryParams
        	// 
        	this.dgQuerryParams.DataMember = "";
        	this.dgQuerryParams.DataSource = this.requestQuerryParamBindingSource;
        	this.dgQuerryParams.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgQuerryParams.FlatMode = true;
        	this.dgQuerryParams.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	this.dgQuerryParams.Location = new System.Drawing.Point(3, 48);
        	this.dgQuerryParams.Name = "dgQuerryParams";
        	this.dgQuerryParams.Size = new System.Drawing.Size(593, 263);
        	this.dgQuerryParams.TabIndex = 13;
        	this.dgQuerryParams.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
			this.dataGridTableStyle2});
        	// 
        	// requestQuerryParamBindingSource
        	// 
        	this.requestQuerryParamBindingSource.DataMember = "QueryParams";
        	this.requestQuerryParamBindingSource.DataSource = typeof(fwptt.TestProject.Run.Data.Request);
        	// 
        	// dataGridTableStyle2
        	// 
        	this.dataGridTableStyle2.DataGrid = this.dgQuerryParams;
        	this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
			this.dataGridTextBoxColumn4,
			this.dataGridTextBoxColumn5});
        	this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	// 
        	// dataGridTextBoxColumn4
        	// 
        	this.dataGridTextBoxColumn4.Format = "";
        	this.dataGridTextBoxColumn4.FormatInfo = null;
        	this.dataGridTextBoxColumn4.HeaderText = "Name";
        	this.dataGridTextBoxColumn4.MappingName = "ParamName";
        	this.dataGridTextBoxColumn4.Width = 150;
        	// 
        	// dataGridTextBoxColumn5
        	// 
        	this.dataGridTextBoxColumn5.Format = "";
        	this.dataGridTextBoxColumn5.FormatInfo = null;
        	this.dataGridTextBoxColumn5.HeaderText = "Value";
        	this.dataGridTextBoxColumn5.MappingName = "ParamValue";
        	this.dataGridTextBoxColumn5.Width = 150;
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.btnDeleteQuerryParam);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel2.Location = new System.Drawing.Point(3, 16);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(593, 32);
        	this.panel2.TabIndex = 14;
        	// 
        	// btnDeleteQuerryParam
        	// 
        	this.btnDeleteQuerryParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.btnDeleteQuerryParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.btnDeleteQuerryParam.Location = new System.Drawing.Point(495, 4);
        	this.btnDeleteQuerryParam.Name = "btnDeleteQuerryParam";
        	this.btnDeleteQuerryParam.Size = new System.Drawing.Size(96, 28);
        	this.btnDeleteQuerryParam.TabIndex = 0;
        	this.btnDeleteQuerryParam.Text = "Delete";
        	this.btnDeleteQuerryParam.UseVisualStyleBackColor = true;
        	this.btnDeleteQuerryParam.Click += new System.EventHandler(this.btnDeleteQuerryParam_Click);
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.ColumnCount = 2;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.25747F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.74253F));
        	this.tableLayoutPanel1.Controls.Add(this.grpBoxReqList, 0, 0);
        	this.tableLayoutPanel1.Controls.Add(this.grpBoxPostParams, 1, 1);
        	this.tableLayoutPanel1.Controls.Add(this.grpBoxQuerryParams, 0, 1);
        	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 2;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(1204, 639);
        	this.tableLayoutPanel1.TabIndex = 14;
        	// 
        	// frmModifyRequests
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1204, 639);
        	this.Controls.Add(this.tableLayoutPanel1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "frmModifyRequests";
        	this.Text = "View/Modify Requests";
        	((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).EndInit();
        	this.grpBoxReqList.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	this.grpBoxPostParams.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgPostParams)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestPostParamBindingSource)).EndInit();
        	this.panel3.ResumeLayout(false);
        	this.grpBoxQuerryParams.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgQuerryParams)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.requestQuerryParamBindingSource)).EndInit();
        	this.panel2.ResumeLayout(false);
        	this.tableLayoutPanel1.ResumeLayout(false);
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgRequests;
        private System.Windows.Forms.GroupBox grpBoxReqList;
        private System.Windows.Forms.GroupBox grpBoxQuerryParams;
        private System.Windows.Forms.GroupBox grpBoxPostParams;
        private System.Windows.Forms.DataGrid dgQuerryParams;
        private System.Windows.Forms.DataGrid dgPostParams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeletePostParam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteQuerryParam;
        private System.Windows.Forms.BindingSource requestBindingSource;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.BindingSource requestPostParamBindingSource;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.BindingSource requestQuerryParamBindingSource;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
    }
}