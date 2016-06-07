namespace GenerateFiltered_2010Version
{
    partial class Form1
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.grpConnectionDetails = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGetEntities = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.lblLocationFile = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbxListEntities = new System.Windows.Forms.CheckedListBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.grpBoxLogs = new System.Windows.Forms.GroupBox();
            this.strip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.lblSelectAll = new System.Windows.Forms.Label();
            this.grpConnectionDetails.SuspendLayout();
            this.grpBoxLogs.SuspendLayout();
            this.strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblConnection.Location = new System.Drawing.Point(16, 9);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(81, 13);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Connections:";
            // 
            // cmbConnections
            // 
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.Items.AddRange(new object[] {
            "New..."});
            this.cmbConnections.Location = new System.Drawing.Point(19, 27);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(121, 21);
            this.cmbConnections.TabIndex = 1;
            this.cmbConnections.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // grpConnectionDetails
            // 
            this.grpConnectionDetails.Controls.Add(this.btnDelete);
            this.grpConnectionDetails.Controls.Add(this.btnGetEntities);
            this.grpConnectionDetails.Controls.Add(this.btnSave);
            this.grpConnectionDetails.Controls.Add(this.btnClear);
            this.grpConnectionDetails.Controls.Add(this.btnBrowse);
            this.grpConnectionDetails.Controls.Add(this.lblNote);
            this.grpConnectionDetails.Controls.Add(this.txtFileLocation);
            this.grpConnectionDetails.Controls.Add(this.lblLocationFile);
            this.grpConnectionDetails.Controls.Add(this.txtServer);
            this.grpConnectionDetails.Controls.Add(this.lblServer);
            this.grpConnectionDetails.Controls.Add(this.txtConnectionName);
            this.grpConnectionDetails.Controls.Add(this.lblName);
            this.grpConnectionDetails.Location = new System.Drawing.Point(19, 54);
            this.grpConnectionDetails.Name = "grpConnectionDetails";
            this.grpConnectionDetails.Size = new System.Drawing.Size(492, 346);
            this.grpConnectionDetails.TabIndex = 2;
            this.grpConnectionDetails.TabStop = false;
            this.grpConnectionDetails.Text = "Connection details";
            this.grpConnectionDetails.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(138, 148);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 83);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete Connection";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGetEntities
            // 
            this.btnGetEntities.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetEntities.Location = new System.Drawing.Point(371, 148);
            this.btnGetEntities.Name = "btnGetEntities";
            this.btnGetEntities.Size = new System.Drawing.Size(110, 83);
            this.btnGetEntities.TabIndex = 16;
            this.btnGetEntities.Text = "Get Entities";
            this.btnGetEntities.UseVisualStyleBackColor = false;
            this.btnGetEntities.Click += new System.EventHandler(this.btnGetEntities_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 83);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save connection";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(254, 148);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 83);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(406, 92);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 20);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNote.ForeColor = System.Drawing.Color.Coral;
            this.lblNote.Location = new System.Drawing.Point(19, 271);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(410, 52);
            this.lblNote.TabIndex = 8;
            this.lblNote.Text = "***Note:\r\nThe servicecontextname and the class namespace will reflect from the \r\n" +
    "Organization Name, For example: Organization: Operational \r\n----> OperationalSer" +
    "viceContext  ,OperationalDataModel";
            this.lblNote.Click += new System.EventHandler(this.lblNote_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(137, 92);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(263, 20);
            this.txtFileLocation.TabIndex = 7;
            // 
            // lblLocationFile
            // 
            this.lblLocationFile.AutoSize = true;
            this.lblLocationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLocationFile.Location = new System.Drawing.Point(19, 95);
            this.lblLocationFile.Name = "lblLocationFile";
            this.lblLocationFile.Size = new System.Drawing.Size(84, 13);
            this.lblLocationFile.TabIndex = 6;
            this.lblLocationFile.Text = "File Location:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(137, 60);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(344, 20);
            this.txtServer.TabIndex = 3;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblServer.Location = new System.Drawing.Point(19, 63);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(68, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server Url:";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(137, 34);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(344, 20);
            this.txtConnectionName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblName.Location = new System.Drawing.Point(19, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(527, 425);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(188, 118);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Cs";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbxListEntities
            // 
            this.cbxListEntities.CheckOnClick = true;
            this.cbxListEntities.FormattingEnabled = true;
            this.cbxListEntities.Location = new System.Drawing.Point(527, 88);
            this.cbxListEntities.Name = "cbxListEntities";
            this.cbxListEntities.Size = new System.Drawing.Size(188, 304);
            this.cbxListEntities.TabIndex = 5;
            this.cbxListEntities.Visible = false;
            this.cbxListEntities.SelectedIndexChanged += new System.EventHandler(this.cbxListEntities_SelectedIndexChanged);
            // 
            // rtbLogs
            // 
            this.rtbLogs.Location = new System.Drawing.Point(6, 19);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(438, 118);
            this.rtbLogs.TabIndex = 6;
            this.rtbLogs.Text = "";
            // 
            // grpBoxLogs
            // 
            this.grpBoxLogs.Controls.Add(this.rtbLogs);
            this.grpBoxLogs.Location = new System.Drawing.Point(19, 406);
            this.grpBoxLogs.Name = "grpBoxLogs";
            this.grpBoxLogs.Size = new System.Drawing.Size(465, 154);
            this.grpBoxLogs.TabIndex = 18;
            this.grpBoxLogs.TabStop = false;
            this.grpBoxLogs.Text = "Logs:";
            this.grpBoxLogs.Visible = false;
            // 
            // strip
            // 
            this.strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.strip.Location = new System.Drawing.Point(0, 571);
            this.strip.Name = "strip";
            this.strip.Size = new System.Drawing.Size(787, 22);
            this.strip.TabIndex = 19;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.Location = new System.Drawing.Point(530, 64);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(15, 14);
            this.cbxSelectAll.TabIndex = 6;
            this.cbxSelectAll.UseVisualStyleBackColor = true;
            this.cbxSelectAll.Visible = false;
            this.cbxSelectAll.CheckedChanged += new System.EventHandler(this.cbxSelectAll_CheckedChanged);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AutoSize = true;
            this.lblSelectAll.Location = new System.Drawing.Point(552, 64);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(50, 13);
            this.lblSelectAll.TabIndex = 20;
            this.lblSelectAll.Text = "Select all";
            this.lblSelectAll.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 593);
            this.Controls.Add(this.lblSelectAll);
            this.Controls.Add(this.cbxSelectAll);
            this.Controls.Add(this.cbxListEntities);
            this.Controls.Add(this.strip);
            this.Controls.Add(this.grpBoxLogs);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpConnectionDetails);
            this.Controls.Add(this.cmbConnections);
            this.Controls.Add(this.lblConnection);
            this.Name = "Form1";
            this.Text = "Crm Generator";
            this.grpConnectionDetails.ResumeLayout(false);
            this.grpConnectionDetails.PerformLayout();
            this.grpBoxLogs.ResumeLayout(false);
            this.strip.ResumeLayout(false);
            this.strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.GroupBox grpConnectionDetails;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label lblLocationFile;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtConnectionName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnGetEntities;
        private System.Windows.Forms.CheckedListBox cbxListEntities;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.GroupBox grpBoxLogs;
        private System.Windows.Forms.StatusStrip strip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.Label lblSelectAll;
    }
}

