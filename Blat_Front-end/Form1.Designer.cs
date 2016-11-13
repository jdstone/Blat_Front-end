namespace Blat_Front_end
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
            this.fileList = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.attachLabel = new System.Windows.Forms.Label();
            this.recipientTextBox = new System.Windows.Forms.TextBox();
            this.recipientLabel = new System.Windows.Forms.Label();
            this.toNoteLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.FormattingEnabled = true;
            this.fileList.HorizontalScrollbar = true;
            this.fileList.ItemHeight = 16;
            this.fileList.Location = new System.Drawing.Point(937, 71);
            this.fileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(519, 324);
            this.fileList.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.Red;
            this.sendButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.sendButton.Location = new System.Drawing.Point(1087, 657);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(240, 90);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send Email";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(16, 60);
            this.bodyTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(708, 457);
            this.bodyTextBox.TabIndex = 2;
            this.bodyTextBox.Text = "See attached file(s).";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.bodyLabel.Location = new System.Drawing.Point(11, 30);
            this.bodyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(144, 29);
            this.bodyLabel.TabIndex = 3;
            this.bodyLabel.Text = "Email Body";
            // 
            // attachLabel
            // 
            this.attachLabel.AutoSize = true;
            this.attachLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.attachLabel.Location = new System.Drawing.Point(932, 41);
            this.attachLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.attachLabel.Name = "attachLabel";
            this.attachLabel.Size = new System.Drawing.Size(173, 29);
            this.attachLabel.TabIndex = 4;
            this.attachLabel.Text = "Attachment(s)";
            // 
            // recipientTextBox
            // 
            this.recipientTextBox.Location = new System.Drawing.Point(937, 433);
            this.recipientTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Size = new System.Drawing.Size(519, 22);
            this.recipientTextBox.TabIndex = 5;
            // 
            // recipientLabel
            // 
            this.recipientLabel.AutoSize = true;
            this.recipientLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.recipientLabel.Location = new System.Drawing.Point(932, 402);
            this.recipientLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recipientLabel.Name = "recipientLabel";
            this.recipientLabel.Size = new System.Drawing.Size(41, 29);
            this.recipientLabel.TabIndex = 6;
            this.recipientLabel.Text = "To";
            // 
            // toNoteLabel
            // 
            this.toNoteLabel.AutoSize = true;
            this.toNoteLabel.Location = new System.Drawing.Point(969, 411);
            this.toNoteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toNoteLabel.Name = "toNoteLabel";
            this.toNoteLabel.Size = new System.Drawing.Size(470, 17);
            this.toNoteLabel.TabIndex = 8;
            this.toNoteLabel.Text = "(separate recipients using commas: ex. mark@abc.com, james@xyz.com)";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.subjectLabel.Location = new System.Drawing.Point(932, 463);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(100, 29);
            this.subjectLabel.TabIndex = 9;
            this.subjectLabel.Text = "Subject";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(937, 494);
            this.subjectTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(519, 22);
            this.subjectTextBox.TabIndex = 10;
            this.subjectTextBox.Text = "Requested File(s)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 841);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.toNoteLabel);
            this.Controls.Add(this.recipientLabel);
            this.Controls.Add(this.recipientTextBox);
            this.Controls.Add(this.attachLabel);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fileList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Blat Frontend";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Label attachLabel;
        private System.Windows.Forms.TextBox recipientTextBox;
        private System.Windows.Forms.Label recipientLabel;
        private System.Windows.Forms.Label toNoteLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
    }
}

