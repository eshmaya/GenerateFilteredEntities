using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GenerateFiltered_2010Version
{
    public partial class Form1 : Form
    {
        string[] filenames = { };
        string organizationUrl = string.Empty;
        const string configFile = "Configurations.xml", filterFile = "filter.xml",
                     batchFile = "CrmSvcUtil15_Specific.bat", tempPath = "generated.cs";

        /// <summary>
        /// Stores the organization service proxy.
        /// </summary>
        IOrganizationService _serviceProxy;
        public Form1()
        {
            InitializeComponent();
            ReadConfigurations();
        }

        private void ReadConfigurations()
        {
            if (File.Exists(configFile))
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                XmlNodeList elemList = xdoc.GetElementsByTagName("configuration");
                foreach (XmlNode item in elemList)
                {
                    cmbConnections.Items.Add(item.SelectSingleNode("Name").InnerText);
                }
            }
        }

        private void lblNote_Click(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpConnectionDetails.Visible = true;
            grpBoxLogs.Visible = true;
            if (cmbConnections.SelectedItem.ToString() == "New...")
            {
                btnClear_Click(sender, e);
                btnSave.Text = "Save Connection";
            }
            else if (!string.IsNullOrEmpty(cmbConnections.SelectedItem.ToString()))
            {
                btnSave.Text = "Update Connection";
                //Get by Name
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                XmlNodeList elemList = xdoc.GetElementsByTagName("configuration");
                foreach (XmlNode item in elemList)
                {
                    if (item.SelectSingleNode("Name").InnerText == cmbConnections.SelectedItem.ToString())
                    {
                        txtConnectionName.Text = item.SelectSingleNode("Name").InnerText;
                        txtServer.Text = item.SelectSingleNode("Server").InnerText;
                        txtFileLocation.Text = item.SelectSingleNode("FileLocation").InnerText;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConnectionName.Text) &&
                !string.IsNullOrEmpty(txtServer.Text) &&
                !string.IsNullOrEmpty(txtFileLocation.Text))
            {
                //save to fileconfig
                XmlDocument xd = new XmlDocument();
                if (!File.Exists(configFile))
                {
                    XmlNode rootNode = xd.CreateElement("configurations");
                    xd.AppendChild(rootNode);
                    xd.Save(configFile);
                }
                xd.Load(configFile);
                XmlNodeList elemList = xd.GetElementsByTagName("configuration");
                foreach (XmlNode item in elemList)
                {
                    //Check if connection name is already exist
                    if (item.SelectSingleNode("Name").InnerText == txtConnectionName.Text)
                    {
                        item.SelectSingleNode("Server").InnerText = txtServer.Text;
                        item.SelectSingleNode("FileLocation").InnerText = txtFileLocation.Text;
                        xd.Save(configFile);
                        rtbLogs.Text = "Connection updated";
                        return;
                    }
                }
                cmbConnections.Items.Add(txtConnectionName.Text);
                cmbConnections.SelectedItem = txtConnectionName.Text;
                //New Element
                XmlNode nl = xd.SelectSingleNode("//configurations");
                XmlDocument xd2 = new XmlDocument();
                xd2.LoadXml(string.Format("<configuration><Name>{0}</Name><Server>{1}</Server><FileLocation>{2}</FileLocation></configuration>"
                    , txtConnectionName.Text, txtServer.Text, txtFileLocation.Text));
                XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                nl.AppendChild(n);
                xd.Save(configFile);
                rtbLogs.Text = "Connection created";
            }
            else
                MessageBox.Show("You need to complete all fields");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConnectionName.Text = string.Empty;
            txtServer.Text = string.Empty;
            txtFileLocation.Text = string.Empty;
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
                btnGenerate.BackColor = Color.Green;
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
                toolStripStatusLabel.ForeColor = Color.Green;
            }
        }

        private void CreateBatchFile(string path)
        {
            //Create the Batch file
            using (StreamWriter sw = new StreamWriter(path))
            {
                string ns = txtServer.Text.Split('/').Last();
                string batchCommand = string.Format("CrmSvcUtil.exe /url:{0}/XRMServices/2011/Organization.svc /out:{1} /servicecontextname:{2}ServiceContext /namespace:{2}DataModel /codewriterfilter:SvcUtilFilterVer2.CodeWriterFilter,SvcUtilFilterVer2", txtServer.Text, tempPath, ns);
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
                //Check valid inputs
                if (string.IsNullOrEmpty(txtServer.Text) || (!string.IsNullOrEmpty(txtServer.Text) && txtServer.Text.Contains("http") == false))
                {
                    MessageBox.Show("Please inset valid server url, Example: http://trnt773d:5555");
                    return;
                }
                ConnectToCrmAndGetEntities(txtServer.Text);
                toolStripStatusLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ConnectToCrmAndGetEntities(string organizationUrl)
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
            _serviceProxy = ConnectionManager.GetOrganizationProxy(organizationUrl);
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true,
            };
            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)_serviceProxy.Execute(request);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(configFile);
            XmlNodeList elemList = xd.GetElementsByTagName("configuration");
            foreach (XmlNode item in elemList)
            {
                //Check if connection name is already exist
                if (item.SelectSingleNode("Name").InnerText == txtConnectionName.Text)
                {
                    item.ParentNode.RemoveChild(item);
                    xd.Save(configFile);
                    rtbLogs.Text = "Connection deleted";
                    cmbConnections.Items.Remove(txtConnectionName.Text);
                    cmbConnections.SelectedItem = "New...";
                    return;
                }
            }
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxListEntities.Items.Count; i++)
                cbxListEntities.SetItemCheckState(i, (cbxSelectAll.Checked ? CheckState.Checked : CheckState.Unchecked));
            btnGenerate.Visible = true;
        }
    }
}
