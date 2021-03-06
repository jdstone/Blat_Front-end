﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FileHelpers;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   Blat Front-end Version 1.3.0.0
//   Provides a visual (GUI) frontend to the Blat email utility (www.blat.net)
//
//   Copyright © 2016
//   J.D. Stone
//   Email: jdstone@jdstone1.com
//   Created: 06NOV2016
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************

namespace Blat_Front_end
{
    public partial class BlatFrontend : Form
    {
        public BlatFrontend()
        {
            string computername = Environment.GetEnvironmentVariable("computername");

            InitializeComponent();
            AllowDrop = true;
            fileList.DragDrop += new DragEventHandler(fileList_DragDrop);
            fileList.DragEnter += new DragEventHandler(fileList_DragEnter);
            fileList.KeyDown += new KeyEventHandler(fileList_KeyDown);
            recipientList.KeyDown += new KeyEventHandler(recipientList_KeyDown);
            recipientAutoCompTextBox.KeyDown += new KeyEventHandler(recipientAutoCompTextBox_KeyDown);

            if (ReadSetting("DisableFromEmailAddressField") == "true")
            {
                fromTextBox.Enabled = false;
                if (ReadSetting("UseDefaultFromEmailAddress") == "false")
                {
                    fromTextBox.Text = computername;
                }
                else
                {
                    fromTextBox.Text = (ReadSetting("DefaultFromEmailAddress") == "@computername") ?
                        fromTextBox.Text = computername : fromTextBox.Text = ReadSetting("DefaultFromEmailAddress");
                }
            }
        }

        private void BlatFrontend_Load(object sender, EventArgs e)
        {
            var engine = new FileHelperAsyncEngine<Contact>();
            var source = new AutoCompleteStringCollection();

            if (File.Exists("contacts.lst"))
            {
                using (engine.BeginReadFile("contacts.lst"))
                {
                    foreach (Contact contact in engine)
                    {
                        source.Add(contact.emailAddress);
                    }
                }

                recipientAutoCompTextBox.AutoCompleteCustomSource = source;
                recipientAutoCompTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                recipientAutoCompTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void BlatFrontend_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cleanUp();
        }

        static string ReadSetting(string key)
        {
            string result;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                result = "Error reading app settings";
            }

            return result;
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            string[] str = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < str.Length; i++)
                fileList.Items.Add(str[i]);
        }

        private void recipientAutoCompTextBox_Enter(object sender, EventArgs e)
        {
            recipientAutoCompTextBox.Text = "";
        }

        private void recipientAutoCompTextBox_Leave(object sender, EventArgs e)
        {
            recipientAutoCompTextBox.Text = "Enter an email address here...";
        }

        private void fromTextBox_Enter(object sender, EventArgs e)
        {
            if (fromTextBox.Text == "" || fromTextBox.Text == "Enter an email address here...")
                fromTextBox.Text = "";
        }

        private void fromTextBox_Leave(object sender, EventArgs e)
        {
            string mbmessage, mbcaption;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            if (fromTextBox.Text == "")
                fromTextBox.Text = "Enter an email address here...";

            try
            {
                if (fromTextBox.Text != "Enter an email address here...")
                {
                    new System.Net.Mail.MailAddress(fromTextBox.Text);
                }
            }
            catch (Exception)
            {
                mbmessage = "Please enter a valid email address";
                mbcaption = "Error detected";
                mbbuttons = MessageBoxButtons.OK;
                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                fromTextBox.Text = "Enter an email address here...";
            }
        }

        #region Helper Functions
        private bool isFileListEmpty()
        {
            if (fileList.Items.Count == 0)
            {
                return true;
            }

            return false;
        }

        private bool renameToAltZipExtAndReattach(string path)
        {
            string oldFileName, newFileName;

            oldFileName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileName(path));
            newFileName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path)) + "." + ReadSetting("RenameZipExt");

            try
            {
                fileList.Items.Remove(oldFileName);
                File.Move(oldFileName, newFileName);
                fileList.Items.Add(newFileName);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool renameToZip(string path)
        {
            string oldFileName, newFileName;

            oldFileName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileName(path));
            newFileName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path)) + ".zip";

            fileList.Items.Remove(oldFileName);
            File.Move(oldFileName, newFileName);
            fileList.Items.Add(newFileName);

            try
            {
                fileList.Items.Remove(oldFileName);
                File.Move(oldFileName, newFileName);
                fileList.Items.Add(newFileName);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void cleanUp()
        {
            for (int i = fileList.Items.Count-1; i >= 0; i--)
            {
                if (Path.GetExtension(fileList.Items[i].ToString()) == "." + ReadSetting("RenameZipExt"))
                    renameToZip(fileList.Items[i].ToString());

                fileList.Items.RemoveAt(i);
            }

            recipientList.Items.Clear();
        }
        #endregion

        private string buildBlatString()
        {
            string mbmessage, mbcaption, fromAddress, args;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            string attachment = "";
            string recipientListString = "";
            string computername = Environment.GetEnvironmentVariable("computername");

            if (!isFileListEmpty())
            {
                for (int i = fileList.Items.Count - 1; i >= 0; i--)
                {
                    if (Path.GetExtension(fileList.Items[i].ToString()) == ".zip")
                    {
                        if (ReadSetting("UseRenameZip") == "true")
                        {
                            if (!renameToAltZipExtAndReattach(fileList.Items[i].ToString()))
                            {
                                mbmessage = "The file could not be attached. It may be open in another program.";
                                mbcaption = "Error";
                                mbbuttons = MessageBoxButtons.OK;
                                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                return null;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < recipientList.Items.Count; i++)
            {
                recipientListString += recipientList.Items[i].ToString();
                // if there are multiple attached files
                if (i < recipientList.Items.Count - 1)
                    recipientListString += ", ";
            }

            if (ReadSetting("UseDefaultFromEmailAddress") == "true")
            {
                if (ReadSetting("DefaultFromEmailAddress") == "@computername")
                {
                    fromAddress = computername;
                }
                else
                {
                    fromAddress = ReadSetting("DefaultFromEmailAddress");
                }
            }
            else
            {
                if (fromTextBox.Text == "Enter an email address here...")
                {
                    fromAddress = computername;
                }
                else
                {
                    fromAddress = fromTextBox.Text;
                }
            }

            args = "-body \"" + bodyTextBox.Text + "\" -from \"" + fromAddress + "\" -to \"" +
                recipientListString + "\" -subject \"" + subjectTextBox.Text + "\"";

            if (fileList.Items.Count > 0)
            {
                for (int i = 0; i < fileList.Items.Count; i++)
                {
                    attachment += fileList.Items[i].ToString();
                    // if there are multiple attached files
                    if (i < fileList.Items.Count - 1)
                        attachment += ", ";
                }
                args += " -attach \"" + attachment + "\"";
            }

            return args;
        }

        private bool runBlat(string args)
        {
            Process p = new Process();
            string output = null;

            try
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = 
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "sysnative", "blat.exe");
                p.StartInfo.Arguments = args;
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                using (StreamWriter w = File.AppendText("blat_front-end_log.txt"))
                {
                    if (output != null)
                    {
                        w.WriteLine("Command Run: blat.exe " + args);
                        w.WriteLine();
                        w.WriteLine(output);
                    }
                }

                return true;
            }
            catch
            {
                using (StreamWriter w = File.AppendText("blat_front-end_log.txt"))
                {
                    if (output != null)
                    {
                        w.WriteLine("Command Run: blat.exe " + args);
                        w.WriteLine();
                        w.WriteLine(output);
                    }
                }
            }

            return false;
        }

        #region Delete Attachment(s)
        private void fileList_KeyDown(object sender, KeyEventArgs e)
        {
            string mbmessage, mbcaption;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            // If delete key is pressed, either delete
            // selected item(s) or show message box
            if (e.KeyCode == Keys.Delete)
            {
                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(fileList);
                selectedItems = fileList.SelectedItems;

                if (fileList.SelectedIndex != -1)
                {
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                        fileList.Items.Remove(selectedItems[i]);
                } else {
                    mbmessage = "Please select an item";
                    mbcaption = "Information";
                    mbbuttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                e.Handled = true;
            }
        }
        #endregion

        #region Delete Recipient(s)
        private void recipientList_KeyDown(object sender, KeyEventArgs e)
        {
            string mbmessage, mbcaption;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            // If delete key is pressed, either delete
            // selected item(s) or show message box
            if (e.KeyCode == Keys.Delete)
            {
                ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(recipientList);
                selectedItems = recipientList.SelectedItems;

                if (recipientList.SelectedIndex != -1)
                {
                    for (int i = selectedItems.Count - 1; i >= 0; i--)
                        recipientList.Items.Remove(selectedItems[i]);
                }
                else
                {
                    mbmessage = "Please select an item";
                    mbcaption = "Information";
                    mbbuttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                e.Handled = true;
            }
        }
        #endregion

        #region Add Recipient
        private void recipientAutoCompTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string mbmessage, mbcaption;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            // Add to recipientList and remove/clear
            // from recipientAutoCompTextBox
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    new System.Net.Mail.MailAddress(recipientAutoCompTextBox.Text);
                    if (recipientAutoCompTextBox.Text != "")
                    {
                        if (ListBox.NoMatches == recipientList.FindStringExact(recipientAutoCompTextBox.Text))
                        {
                            // Add to recipientList
                            recipientList.Items.Add(recipientAutoCompTextBox.Text);
                            // delete or clear from recipientAutoCompTextBox
                            recipientAutoCompTextBox.Clear();
                        }
                        else
                        {
                            mbmessage = "\"" + recipientAutoCompTextBox.Text +
                                "\"\nhas already been added to the list of recipients";
                            mbcaption = "Error detected";
                            mbbuttons = MessageBoxButtons.OK;
                            result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }

                        e.Handled = true;
                    }
                }
                catch (Exception)
                {
                    mbmessage = "Please enter a valid email address";
                    mbcaption = "Error detected";
                    mbbuttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
        }
        #endregion

        private bool checkFileList()
        {
            string mbmessage, mbcaption;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            if (isFileListEmpty())
            {
                mbmessage = "WARNING: You did not attach any file(s).\n\nDo you wish to continue?";
                mbcaption = "Errors detected";
                mbbuttons = MessageBoxButtons.YesNo;
                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        // Send Email
        private void sendButton_Click(object sender, EventArgs e)
        {
            string mbmessage, mbcaption, args;
            MessageBoxButtons mbbuttons;
            DialogResult result;

            args = buildBlatString();

            if (args != null)
            {
                if (checkFileList())
                {
                    if (recipientList.Items.Count > 0)
                    {
                        if (args != "invalid")
                        {
                            if (runBlat(args))
                            {
                                mbmessage = "Email message sent successfully!";
                                mbcaption = "Information";
                                mbbuttons = MessageBoxButtons.OK;
                                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                cleanUp();
                            }
                            else
                            {
                                mbmessage = "An error occurred and the message could not be sent." +
                                            "\nPlease make sure Blat.exe is installed in the System32 folder.";
                                mbcaption = "Information";
                                mbbuttons = MessageBoxButtons.OK;
                                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else
                    {
                        mbmessage = "Please enter a recipient";
                        mbcaption = "Information";
                        mbbuttons = MessageBoxButtons.OK;
                        result = MessageBox.Show(mbmessage, mbcaption, mbbuttons,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    using (StreamWriter w = File.AppendText("blat_front-end_log.txt"))
                    {
                        w.WriteLine("The send button did not do anything");
                    }
                }
            }
        }
    }
}
