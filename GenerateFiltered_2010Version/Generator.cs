using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using McTools.Xrm.Connection;

/// <summary>
/// Op2 test
/// King Ohad Perets 
/// </summary>

/// <summary>
/// I just added this comment to see if fork working well (Eli Shmaya)
/// King Ohad Perets 
/// </summary>
namespace GenerateFiltered_2010Version
{
    /// <summary>
    /// Working on a branch
    /// </summary>
    public partial class Generator : Form
    {
        /// <summary>
        /// Connection control
        /// </summary>
        CrmConnectionStatusBar ccsb;

        /// <summary>
        /// Connection manager
        /// </summary>
        McTools.Xrm.Connection.ConnectionManager cManager;

        public IOrganizationService _service;

        string[] filenames = { };
        string organizationUrl = string.Empty, ns = string.Empty;
        const string filterFile = "filter.xml",
                     batchFile = "CrmSvcUtil15_Specific.bat", tempPath = "generated.cs";

        /// <summary>
        /// Stores the organization service proxy.
        /// </summary>
        public Generator()
        {
            InitializeComponent();

            this.cManager = new McTools.Xrm.Connection.ConnectionManager(this);
            this.cManager.ConnectionFailed += CManager_ConnectionFailed;
            this.cManager.ConnectionSucceed += CManager_ConnectionSucceed;
            this.cManager.StepChanged += CManager_StepChanged;
            // Instantiate and add the connection control to the form
            ccsb = new CrmConnectionStatusBar(this.cManager);
            this.Controls.Add(ccsb);
        }
        private void CManager_StepChanged(object sender, StepChangedEventArgs e)
        {
            this.ccsb.SetMessage(e.CurrentStep);
        }

        private void CManager_ConnectionSucceed(object sender, ConnectionSucceedEventArgs e)
        {
            organizationUrl = e.ConnectionDetail.OrganizationServiceUrl;
            ns = e.ConnectionDetail.OrganizationFriendlyName;
            // Store connection Organization Service
            this._service = e.OrganizationService;

            // Displays connection status
            this.ccsb.SetConnectionStatus(true, e.ConnectionDetail);

            // Clear the current action message
            this.ccsb.SetMessage(string.Empty);

            ((Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy)this._service).Timeout = TimeSpan.FromMinutes(15);
            //If success show the groups
            ShowConnectionDetails();
        }

        private void ShowConnectionDetails()
        {
            grpConnectionDetails.Visible = true;
            grpBoxLogs.Visible = true;
        }

        private void CManager_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            MessageBox.Show(string.Format("Connection Failed: {0}", e.FailureReason));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                filenames = ofd.FileNames;
                if (filenames.Length > 1)
                {
                    MessageBox.Show("Please select only one file.");
                    return;
                }
                else if (filenames.Length == 1)
                {
                    txtFileLocation.Text = filenames[0];
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerate.Enabled = false;
                btnGenerate.BackColor = Color.Yellow;
                if (string.IsNullOrEmpty(txtFileLocation.Text))
                {
                    MessageBox.Show("Please inset valid File location");
                    btnGenerate.BackColor = Color.Red;
                    return;
                }
                string path = batchFile;
                CreateXmlFilter();
                CreateBatchFile(path);
                //Run the batch
                ExecuteCommand(path);

                //Returns ok
                btnGenerate.Enabled = true;
                btnGenerate.BackColor = Color.Lime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                btnGenerate.Enabled = true;
                btnGenerate.BackColor = SystemColors.Control;
            }
        }

        private void ExecuteCommand(string path)
        {
            toolStripStatusLabel.Text = "Please wait while generating the entities...";
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(path);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.Verb = "runas";
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();
            //Copy to the txtFileLocation.Text
            //first check if the file exist if not create

            using (StreamWriter sw = File.AppendText(tempPath))
            {
                //write my text 
                File.Copy(tempPath, txtFileLocation.Text, true);
            }


            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            rtbLogs.Text = output;
            exitCode = process.ExitCode;
            process.Close();
            if (!string.IsNullOrEmpty(error))
            {
                rtbLogs.Text = error;
                rtbLogs.Visible = true;
            }

            else
            {
                rtbLogs.Text = output;
                rtbLogs.Text = "Good To Go...Generate was succefull";
                toolStripStatusLabel.Text = "Good To Go...Generate was succefull";
                toolStripStatusLabel.ForeColor = Color.Black;
            }
        }

        private void CreateBatchFile(string path)
        {
            //Create the Batch file
            using (StreamWriter sw = new StreamWriter(path))
            {
                string batchCommand = string.Format("CrmSvcUtil.exe /url:{0} /out:{1} /servicecontextname:{2}ServiceContext /namespace:{2}DataModel /codewriterfilter:SvcUtilFilterVer2.CodeWriterFilter,SvcUtilFilterVer2", organizationUrl, tempPath, ns);
                sw.WriteLine(batchCommand);
            }
        }

        private void CreateXmlFilter()
        {
            XDocument xdoc = null;
            XElement xEntities = new XElement("entities");
            bool isAnyChecked = false;
            foreach (var item in cbxListEntities.CheckedItems)
            {
                isAnyChecked = true;
                //Build the Xml
                xEntities.Add(new XElement("entity", item.ToString()));
            }
            if (isAnyChecked)
            {
                XElement xFilter = new XElement("filter", xEntities);
                xdoc = new XDocument(xFilter);
                xdoc.Save(filterFile);
            }
        }

        private void btnGetEntities_Click(object sender, EventArgs e)
        {
            try
            {
                cbxListEntities.Items.Clear();
                cbxListEntities.Visible = true;
                cbxSelectAll.Visible = true;
                lblSelectAll.Visible = true;
                ConnectToCrmAndGetEntities();
                toolStripStatusLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ConnectToCrmAndGetEntities()
        {
            string textFile = string.Empty;
            using (StreamReader textReader = new StreamReader(txtFileLocation.Text))
            {
                textFile = textReader.ReadToEnd();
            }
            string pattern = @"\b(?=(public partial class\s+\w+)\b)";
            string[] classes = Regex.Matches(textFile, pattern)
                                   .Cast<Match>()
                                   .Select(match => match.Groups[1].Value.Replace("public partial class ", string.Empty))
                                   .ToArray();
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true,
            };
            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)_service.Execute(request);
            List<EntityMetadata> listEntityMetaData = response.EntityMetadata.OrderBy(s => s.SchemaName).ToList();
            foreach (var item in listEntityMetaData)
            {
                cbxListEntities.Items.Add(item.SchemaName);
                //Check if exist in the class
                if (classes.Contains(item.SchemaName))
                {
                    cbxListEntities.SetItemCheckState(cbxListEntities.Items.Count - 1, CheckState.Indeterminate);
                }
            }
        }

        private void cbxListEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerate.Visible = true;
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxListEntities.Items.Count; i++)
                cbxListEntities.SetItemCheckState(i, (cbxSelectAll.Checked ? CheckState.Checked : CheckState.Unchecked));
            btnGenerate.Visible = true;
        }

        private void txtFileLocation_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFileLocation.Text))
            {
                btnGetEntities.Enabled = true;
                btnGetEntities.BackColor = Color.Lime;
            }
            else
            {
                btnGetEntities.Enabled = false;
                btnGetEntities.BackColor = Color.Yellow;
            }
        }
    }
}
