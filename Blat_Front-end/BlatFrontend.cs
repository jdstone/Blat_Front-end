using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FileHelpers;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   Blat Front-end Version 1.1.0.0
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
            InitializeComponent();
            this.AllowDrop = true;
            fileList.DragDrop += new DragEventHandler(fileList_DragDrop);
            fileList.DragEnter += new DragEventHandler(fileList_DragEnter);
            fileList.KeyDown += new KeyEventHandler(fileList_KeyDown);
        }

        private void BlatFrontend_Load(object sender, EventArgs e)
        {
            var engine = new FileHelperAsyncEngine<Contact>();
            var source = new AutoCompleteStringCollection();

            if (File.Exists("contacts.csv"))
            {
                using (engine.BeginReadFile("contacts.csv"))
                {
                    foreach (Contact contact in engine)
                    {
                        source.Add(contact.emailAddress);
                    }
                }

                recipientTextBox.AutoCompleteCustomSource = source;
                recipientTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                recipientTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
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

        #region Helper Functions
        private string determineFileType(string filePath)
        {
            string result;
            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".txt": case ".trc": case ".log": case ".tsv": case ".ini": case ".dct":
                    result = "text";
                    break;
                case ".z1p": /* .zip */ case ".xls": case ".pdf": case ".csv":
                    result = "binary";
                    break;
                default:
                    result = "not a valid file type";
                    break;
            }

            return result;
        }

        private bool isFileListEmpty()
        {
            if (fileList.SelectedIndex == -1)
            {
                return true;
            }

            return false;
        }

        private void SetSelectedAllItems(ListBox listbox)
        {
            listbox.BeginUpdate();

            for (int i = 0; i < listbox.Items.Count; i++)
            {
                listbox.SetSelected(i, true);
            }

            listbox.EndUpdate();
        }
        #endregion

        private string buildBlatString()
        {
            string args;
            string attachment = "";
            string computername = Environment.GetEnvironmentVariable("computername");
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(fileList);
            selectedItems = fileList.SelectedItems;

            if (fileList.SelectedIndex != -1)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    if (Path.GetExtension(selectedItems[i].ToString()) == ".zip")
                    {
                        MessageBox.Show(Path.GetExtension(selectedItems[i].ToString()) + " is not a valid file type.\n\n" +
                            "Please delete the attachment from the list, rename the attachment to .z1p (that's the number " +
                            "one), and re-attach.");
                        return "invalid";
                    }
                }
            }

            args = "-body \"" + bodyTextBox.Text + "\" -from " + computername + "@domain.com -to \"" + recipientTextBox.Text +
                "\" -subject \"" + subjectTextBox.Text + "\"";

            if (fileList.SelectedIndex != -1)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    attachment += selectedItems[i].ToString();
                    // if there are multiple attached files
                    if (i < selectedItems.Count - 1)
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
                    MessageBox.Show("Please select an item");
                }

                e.Handled = true;
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
                mbmessage = "WARNING: You did not attach any file(s).\n\nDo you want to continue?";
                mbcaption = "Errors detected";
                mbbuttons = MessageBoxButtons.YesNo;
                result = MessageBox.Show(mbmessage, mbcaption, mbbuttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

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
            string args;
            SetSelectedAllItems(fileList);
            args = buildBlatString();

            if (checkFileList())
            {
                if (recipientTextBox.Text != "")
                {
                    if (args != "invalid")
                    {
                        if (runBlat(args))
                        {
                            MessageBox.Show("Message sent successfully");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred and the message could not be sent." +
                                            "\nPlease make sure Blat.exe is installed in the System32 folder.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a recipient");
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
