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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlatFrontend));
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
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.FormattingEnabled = true;
            this.fileList.HorizontalScrollbar = true;
            this.fileList.Location = new System.Drawing.Point(518, 58);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(575, 264);
            this.fileList.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.Red;
            this.sendButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.sendButton.Location = new System.Drawing.Point(706, 376);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(180, 73);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send Email";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.bodyLabel.Location = new System.Drawing.Point(8, 256);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(115, 22);
            this.bodyLabel.TabIndex = 7;
            this.bodyLabel.Text = "Email Body";
            // 
            // attachLabel
            // 
            this.attachLabel.AutoSize = true;
            this.attachLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.attachLabel.Location = new System.Drawing.Point(514, 31);
            this.attachLabel.Name = "attachLabel";
            this.attachLabel.Size = new System.Drawing.Size(138, 22);
            this.attachLabel.TabIndex = 8;
            this.attachLabel.Text = "Attachment(s)";
            // 
            // recipientListLabel
            // 
            this.recipientListLabel.AutoSize = true;
            this.recipientListLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.recipientListLabel.Location = new System.Drawing.Point(8, 133);
            this.recipientListLabel.Name = "recipientListLabel";
            this.recipientListLabel.Size = new System.Drawing.Size(34, 22);
            this.recipientListLabel.TabIndex = 9;
            this.recipientListLabel.Text = "To";
            // 
            // fileListLabel
            // 
            this.fileListLabel.AutoSize = true;
            this.fileListLabel.Location = new System.Drawing.Point(650, 38);
            this.fileListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileListLabel.Name = "fileListLabel";
            this.fileListLabel.Size = new System.Drawing.Size(229, 13);
            this.fileListLabel.TabIndex = 10;
            this.fileListLabel.Text = "Use the delete key to remove items from the list";
            // 
            // recipientAutoCompTextBox
            // 
            this.recipientAutoCompTextBox.Location = new System.Drawing.Point(12, 108);
            this.recipientAutoCompTextBox.Name = "recipientAutoCompTextBox";
            this.recipientAutoCompTextBox.Size = new System.Drawing.Size(464, 20);
            this.recipientAutoCompTextBox.TabIndex = 1;
            this.recipientAutoCompTextBox.Text = "Enter an email address here...";
            this.recipientAutoCompTextBox.Enter += new System.EventHandler(this.recipientAutoCompTextBox_Enter);
            this.recipientAutoCompTextBox.Leave += new System.EventHandler(this.recipientAutoCompTextBox_Leave);
            // 
            // recipientList
            // 
            this.recipientList.FormattingEnabled = true;
            this.recipientList.Location = new System.Drawing.Point(12, 158);
            this.recipientList.Name = "recipientList";
            this.recipientList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.recipientList.Size = new System.Drawing.Size(464, 43);
            this.recipientList.TabIndex = 2;
            // 
            // recipientNoteLabel
            // 
            this.recipientNoteLabel.AutoSize = true;
            this.recipientNoteLabel.Location = new System.Drawing.Point(47, 140);
            this.recipientNoteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recipientNoteLabel.Name = "recipientNoteLabel";
            this.recipientNoteLabel.Size = new System.Drawing.Size(229, 13);
            this.recipientNoteLabel.TabIndex = 11;
            this.recipientNoteLabel.Text = "Use the delete key to remove items from the list";
            // 
            // recipientAutoCompLabel
            // 
            this.recipientAutoCompLabel.AutoSize = true;
            this.recipientAutoCompLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientAutoCompLabel.Location = new System.Drawing.Point(8, 83);
            this.recipientAutoCompLabel.Name = "recipientAutoCompLabel";
            this.recipientAutoCompLabel.Size = new System.Drawing.Size(96, 22);
            this.recipientAutoCompLabel.TabIndex = 12;
            this.recipientAutoCompLabel.Text = "Recipient";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.subjectLabel.Location = new System.Drawing.Point(8, 206);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(80, 22);
            this.subjectLabel.TabIndex = 13;
            this.subjectLabel.Text = "Subject";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(12, 231);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(464, 20);
            this.subjectTextBox.TabIndex = 3;
            this.subjectTextBox.Text = "Requested File(s)";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(12, 281);
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(464, 264);
            this.bodyTextBox.TabIndex = 4;
            this.bodyTextBox.Text = "See attached file(s).";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(12, 58);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(464, 20);
            this.fromTextBox.TabIndex = 0;
            this.fromTextBox.Text = "Enter an email address here...";
            this.fromTextBox.Enter += new System.EventHandler(this.fromTextBox_Enter);
            this.fromTextBox.Leave += new System.EventHandler(this.fromTextBox_Leave);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.fromLabel.Location = new System.Drawing.Point(8, 33);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(59, 22);
            this.fromLabel.TabIndex = 14;
            this.fromLabel.Text = "From";
            // 
            // BlatFrontend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1125, 683);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.fromTextBox);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BlatFrontend";
            this.Text = "Blat Frontend v1.3.0.0";
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
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label fromLabel;
    }
}

