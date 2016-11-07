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
            //this.DragEnter += new DragEventHandler(Form1_DragEnter);
            //this.DragDrop += new DragEventHandler(Form1_DragDrop);
            fileList.DragDrop += new DragEventHandler(fileList_DragDrop);
            fileList.DragEnter += new DragEventHandler(fileList_DragEnter);
            fileList.KeyDown += new KeyEventHandler(fileList_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /*
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                label.Text += file + "\n";
                Console.WriteLine(label);
            }
        }
        */

        /*private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }*/

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
                case ".txt": case ".trc": case ".log": case ".csv": case ".tsv": case ".xls": case ".ini": case ".dct": case ".pdf":
                    result = "text";
                    break;
                // .zip
                case ".z1p":
                    result = "binary";
                    break;
                default:
                    result = "not a valid file type";
                    break;
            }

            return result;
        }

        private void buildBlatString()
        {
            string args, attachArg, blatCmd;
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
            //Console.WriteLine(attachmentText + " " + attachmentBinary);

            args = "-from " + computername + "@domain.com -to " + recipientTextBox.Text + " -subject " + subjectTextBox.Text;
            if (attachmentText.Length > 9)
                args += " " + attachmentText;
            if (attachmentBinary.Length > 8)
                args += " " + attachmentBinary;
            Console.WriteLine("Args: " + args);
            //runBlat(args);

            /*if (fileList.Items.Count <= 0)
            {
                Console.WriteLine("file list is empty");
            }
            else
            {
                Console.Write(fileList.Items.Count);
            }*/
        }

        private void runBlat(string args)
        {
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            string path = @"filepath";
            p.StartInfo.FileName = path + "blat.exe";
            p.StartInfo.Arguments = args;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            Console.WriteLine(output);
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

        private void button1_Click(object sender, EventArgs e)
        {
            buildBlatString();
            //Console.Write(recipientTextBox.Text);
            //ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(fileList);
            //selectedItems = fileList.SelectedItems;

            //Console.Write(selectedItems[0].ToString());
        }

        private void testEmail()
        {
            string emailFrom = "email";
            string emailTo = "email";
            string subject = "subject goes here";
            string body = "body in here...";
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("email");
            //emailMessage.Attachments = new Attachment(@"filepath", "text/plain");
            //emailMessage.Attachments.Add(att)
            SmtpClient smtpClient = new SmtpClient("smtp.example.com", 111);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("username", "pass");

            smtpClient.Send(emailFrom, emailTo, subject, body);
        }
    }
}
