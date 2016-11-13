using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blat_Front_end
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            fileList.DragDrop += new DragEventHandler(fileList_DragDrop);
            fileList.DragEnter += new DragEventHandler(fileList_DragEnter);
            fileList.KeyDown += new KeyEventHandler(fileList_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void fileList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] str = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < str.Length; i++)
                fileList.Items.Add(str[i]);
        }

        private string determineFileType(string filePath)
        {
            string result;
            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".txt": case ".trc": case ".log": case ".csv": case ".tsv": case ".xls": case ".ini": case ".dct":
                    result = "text";
                    break;
                case ".z1p": // .zip
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
                Console.WriteLine("You didn't attach any files!");
                return false;
            }

            return true;
        }

        public void SetSelectedAllItems(ListBox listbox)
        {
            listbox.BeginUpdate();

            for (int i = 0; i < listbox.Items.Count; i++)
            {
                listbox.SetSelected(i, true);
            }

            listbox.EndUpdate();
        }

        private string buildBlatString()
        {
            string args;
            string attachmentText = "-attacht ";
            string attachmentBinary = "-attach ";
            string computername = Environment.GetEnvironmentVariable("computername");
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(fileList);
            selectedItems = fileList.SelectedItems;

            if (fileList.SelectedIndex != -1)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    if (determineFileType(selectedItems[i].ToString()) == "text")
                    {
                        attachmentText += selectedItems[i].ToString();
                        if (i < selectedItems.Count - 1)
                            attachmentText += ", ";
                    }
                    else if (determineFileType(selectedItems[i].ToString()) == "binary")
                    {
                        attachmentBinary += selectedItems[i].ToString();
                    }
                    else
                    {
                        MessageBox.Show(Path.GetExtension(selectedItems[i].ToString()) + " is not a valid file type.");
                        return "invalid";
                    }
                }
            }

            args = "-body \"" + bodyTextBox.Text + "\" -from " + computername + "@domain.com -to " + recipientTextBox.Text +
                " -subject \"" + subjectTextBox.Text + "\"";
            if (attachmentText.Length > 9)
                args += " \"" + attachmentText + "\"";
            if (attachmentBinary.Length > 8)
                args += " \"" + attachmentBinary + "\"";


            return args;
        }

        private bool runBlat(string args)
        {
            Process p = new Process();
            string output;

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
                Console.WriteLine(output);

                return true;
            }
            catch
            {
                Console.WriteLine("Could not find file.");
            }

            return false;
        }

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

        private void sendButton_Click(object sender, EventArgs e)
        {
            string args;
            SetSelectedAllItems(fileList);
            args = buildBlatString();

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
    }
}
