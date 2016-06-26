namespace GenerateFiltered_2010Version
{
    partial class Generator
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
            this.grpConnectionDetails = new System.Windows.Forms.GroupBox();
            this.btnGetEntities = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.lblLocationFile = new System.Windows.Forms.Label();
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
            // grpConnectionDetails
            // 
            this.grpConnectionDetails.Controls.Add(this.btnGetEntities);
            this.grpConnectionDetails.Controls.Add(this.btnBrowse);
            this.grpConnectionDetails.Controls.Add(this.txtFileLocation);
            this.grpConnectionDetails.Controls.Add(this.lblLocationFile);
            this.grpConnectionDetails.Controls.Add(this.btnGenerate);
            this.grpConnectionDetails.Location = new System.Drawing.Point(19, 12);
            this.grpConnectionDetails.Name = "grpConnectionDetails";
            this.grpConnectionDetails.Size = new System.Drawing.Size(492, 201);
            this.grpConnectionDetails.TabIndex = 2;
            this.grpConnectionDetails.TabStop = false;
            this.grpConnectionDetails.Text = "Connection details";
            this.grpConnectionDetails.Visible = false;
            // 
            // btnGetEntities
            // 
            this.btnGetEntities.BackColor = System.Drawing.Color.Yellow;
            this.btnGetEntities.Enabled = false;
            this.btnGetEntities.Location = new System.Drawing.Point(93, 73);
            this.btnGetEntities.Name = "btnGetEntities";
            this.btnGetEntities.Size = new System.Drawing.Size(110, 83);
            this.btnGetEntities.TabIndex = 16;
            this.btnGetEntities.Text = "Get Entities";
            this.btnGetEntities.UseVisualStyleBackColor = false;
            this.btnGetEntities.Click += new System.EventHandler(this.btnGetEntities_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(399, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 20);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(130, 19);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(263, 20);
            this.txtFileLocation.TabIndex = 7;
            this.txtFileLocation.TextChanged += new System.EventHandler(this.txtFileLocation_TextChanged);
            // 
            // lblLocationFile
            // 
            this.lblLocationFile.AutoSize = true;
            this.lblLocationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLocationFile.Location = new System.Drawing.Point(12, 22);
            this.lblLocationFile.Name = "lblLocationFile";
            this.lblLocationFile.Size = new System.Drawing.Size(84, 13);
            this.lblLocationFile.TabIndex = 6;
            this.lblLocationFile.Text = "File Location:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(283, 73);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 83);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Class";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbxListEntities
            // 
            this.cbxListEntities.CheckOnClick = true;
            this.cbxListEntities.FormattingEnabled = true;
            this.cbxListEntities.Location = new System.Drawing.Point(527, 43);
            this.cbxListEntities.Name = "cbxListEntities";
            this.cbxListEntities.Size = new System.Drawing.Size(188, 379);
            this.cbxListEntities.TabIndex = 5;
            this.cbxListEntities.Visible = false;
            this.cbxListEntities.SelectedIndexChanged += new System.EventHandler(this.cbxListEntities_SelectedIndexChanged);
            // 
            // rtbLogs
            // 
            this.rtbLogs.Location = new System.Drawing.Point(6, 19);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(438, 167);
            this.rtbLogs.TabIndex = 6;
            this.rtbLogs.Text = "";
            // 
            // grpBoxLogs
            // 
            this.grpBoxLogs.Controls.Add(this.rtbLogs);
            this.grpBoxLogs.Location = new System.Drawing.Point(19, 219);
            this.grpBoxLogs.Name = "grpBoxLogs";
            this.grpBoxLogs.Size = new System.Drawing.Size(465, 201);
            this.grpBoxLogs.TabIndex = 18;
            this.grpBoxLogs.TabStop = false;
            this.grpBoxLogs.Text = "Logs:";
            this.grpBoxLogs.Visible = false;
            // 
            // strip
            // 
            this.strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.strip.Location = new System.Drawing.Point(0, 464);
            this.strip.Name = "strip";
            this.strip.Size = new System.Drawing.Size(779, 22);
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
            this.cbxSelectAll.Location = new System.Drawing.Point(529, 20);
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
            this.lblSelectAll.Location = new System.Drawing.Point(551, 20);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(50, 13);
            this.lblSelectAll.TabIndex = 20;
            this.lblSelectAll.Text = "Select all";
            this.lblSelectAll.Visible = false;
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 486);
            this.Controls.Add(this.lblSelectAll);
            this.Controls.Add(this.cbxSelectAll);
            this.Controls.Add(this.cbxListEntities);
            this.Controls.Add(this.strip);
            this.Controls.Add(this.grpBoxLogs);
            this.Controls.Add(this.grpConnectionDetails);
            this.Name = "Generator";
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

        private System.Windows.Forms.GroupBox grpConnectionDetails;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label lblLocationFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnGetEntities;
        private System.Windows.Forms.CheckedListBox cbxListEntities;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.GroupBox grpBoxLogs;
        private System.Windows.Forms.StatusStrip strip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.Label lblSelectAll;
    }
}

