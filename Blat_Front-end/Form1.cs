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
using System.Net.Mail;

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
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                fileList.Items.Add(s[i]);
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
                        Console.WriteLine(determineFileType(selectedItems[i].ToString()));
                    }
                }
            }

            args = "-from " + computername + "@domain.com -to " + recipientTextBox.Text + " -subject " + subjectTextBox.Text;
            if (attachmentText.Length > 9)
                args += " " + attachmentText;
            if (attachmentBinary.Length > 8)
                args += " " + attachmentBinary;

            return args;
        }

        private void runBlat(string args)
        {
            Process p = new Process();
            string output;

            try
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                string path = @"filepath";
                p.StartInfo.FileName = path + "blat.exe";
                p.StartInfo.Arguments = args;
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
                Console.WriteLine(output);
            }
            catch
            {
                Console.WriteLine("Fail");
            }
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
            args = buildBlatString();
            runBlat(args);
        }
    }
}
