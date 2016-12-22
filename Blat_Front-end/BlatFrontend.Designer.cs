namespace Blat_Front_end
{
    partial class BlatFrontend
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
            this.bodyLabel = new System.Windows.Forms.Label();
            this.attachLabel = new System.Windows.Forms.Label();
            this.recipientListLabel = new System.Windows.Forms.Label();
            this.fileListLabel = new System.Windows.Forms.Label();
            this.recipientAutoCompTextBox = new System.Windows.Forms.TextBox();
            this.recipientList = new System.Windows.Forms.ListBox();
            this.recipientNoteLabel = new System.Windows.Forms.Label();
            this.recipientAutoCompLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.bodyTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.FormattingEnabled = true;
            this.fileList.HorizontalScrollbar = true;
            this.fileList.ItemHeight = 16;
            this.fileList.Location = new System.Drawing.Point(691, 71);
            this.fileList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(765, 324);
            this.fileList.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.Red;
            this.sendButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.sendButton.Location = new System.Drawing.Point(941, 463);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(240, 90);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send Email";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.bodyLabel.Location = new System.Drawing.Point(11, 256);
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
            this.attachLabel.Location = new System.Drawing.Point(686, 38);
            this.attachLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.attachLabel.Name = "attachLabel";
            this.attachLabel.Size = new System.Drawing.Size(173, 29);
            this.attachLabel.TabIndex = 4;
            this.attachLabel.Text = "Attachment(s)";
            // 
            // recipientListLabel
            // 
            this.recipientListLabel.AutoSize = true;
            this.recipientListLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.recipientListLabel.Location = new System.Drawing.Point(11, 102);
            this.recipientListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recipientListLabel.Name = "recipientListLabel";
            this.recipientListLabel.Size = new System.Drawing.Size(41, 29);
            this.recipientListLabel.TabIndex = 6;
            this.recipientListLabel.Text = "To";
            // 
            // fileListLabel
            // 
            this.fileListLabel.AutoSize = true;
            this.fileListLabel.Location = new System.Drawing.Point(866, 47);
            this.fileListLabel.Name = "fileListLabel";
            this.fileListLabel.Size = new System.Drawing.Size(307, 17);
            this.fileListLabel.TabIndex = 12;
            this.fileListLabel.Text = "Use the delete key to remove items from the list";
            // 
            // recipientAutoCompTextBox
            // 
            this.recipientAutoCompTextBox.Location = new System.Drawing.Point(16, 71);
            this.recipientAutoCompTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recipientAutoCompTextBox.Name = "recipientAutoCompTextBox";
            this.recipientAutoCompTextBox.Size = new System.Drawing.Size(617, 22);
            this.recipientAutoCompTextBox.TabIndex = 13;
            this.recipientAutoCompTextBox.Text = "Enter an email address here...";
            this.recipientAutoCompTextBox.Enter += new System.EventHandler(this.recipientAutoCompTextBox_Enter);
            this.recipientAutoCompTextBox.Leave += new System.EventHandler(this.recipientAutoCompTextBox_Leave);
            // 
            // recipientList
            // 
            this.recipientList.FormattingEnabled = true;
            this.recipientList.ItemHeight = 16;
            this.recipientList.Location = new System.Drawing.Point(16, 133);
            this.recipientList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recipientList.Name = "recipientList";
            this.recipientList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.recipientList.Size = new System.Drawing.Size(617, 52);
            this.recipientList.TabIndex = 14;
            // 
            // recipientNoteLabel
            // 
            this.recipientNoteLabel.AutoSize = true;
            this.recipientNoteLabel.Location = new System.Drawing.Point(63, 111);
            this.recipientNoteLabel.Name = "recipientNoteLabel";
            this.recipientNoteLabel.Size = new System.Drawing.Size(307, 17);
            this.recipientNoteLabel.TabIndex = 15;
            this.recipientNoteLabel.Text = "Use the delete key to remove items from the list";
            // 
            // recipientAutoCompLabel
            // 
            this.recipientAutoCompLabel.AutoSize = true;
            this.recipientAutoCompLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientAutoCompLabel.Location = new System.Drawing.Point(11, 41);
            this.recipientAutoCompLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recipientAutoCompLabel.Name = "recipientAutoCompLabel";
            this.recipientAutoCompLabel.Size = new System.Drawing.Size(121, 29);
            this.recipientAutoCompLabel.TabIndex = 16;
            this.recipientAutoCompLabel.Text = "Recipient";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.subjectLabel.Location = new System.Drawing.Point(11, 193);
            this.subjectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(100, 29);
            this.subjectLabel.TabIndex = 9;
            this.subjectLabel.Text = "Subject";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(16, 224);
            this.subjectTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(617, 22);
            this.subjectTextBox.TabIndex = 10;
            this.subjectTextBox.Text = "Requested File(s)";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(16, 287);
            this.bodyTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(617, 324);
            this.bodyTextBox.TabIndex = 17;
            this.bodyTextBox.Text = "See attached file(s).";
            // 
            // BlatFrontend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 841);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.recipientAutoCompLabel);
            this.Controls.Add(this.recipientNoteLabel);
            this.Controls.Add(this.recipientList);
            this.Controls.Add(this.recipientAutoCompTextBox);
            this.Controls.Add(this.fileListLabel);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.recipientListLabel);
            this.Controls.Add(this.attachLabel);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fileList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BlatFrontend";
            this.Text = "Blat Frontend v1.2.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlatFrontend_Closing);
            this.Load += new System.EventHandler(this.BlatFrontend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Label attachLabel;
        private System.Windows.Forms.Label recipientListLabel;
        private System.Windows.Forms.Label fileListLabel;
        private System.Windows.Forms.TextBox recipientAutoCompTextBox;
        private System.Windows.Forms.ListBox recipientList;
        private System.Windows.Forms.Label recipientNoteLabel;
        private System.Windows.Forms.Label recipientAutoCompLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.RichTextBox bodyTextBox;
    }
}

