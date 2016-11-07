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
            this.button1 = new System.Windows.Forms.Button();
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
            this.fileList.Location = new System.Drawing.Point(703, 58);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(390, 264);
            this.fileList.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sendButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.sendButton.Location = new System.Drawing.Point(855, 564);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(180, 73);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send Email";
            this.sendButton.UseVisualStyleBackColor = false;
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(12, 49);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(532, 372);
            this.bodyTextBox.TabIndex = 2;
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.bodyLabel.Location = new System.Drawing.Point(8, 24);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(207, 22);
            this.bodyLabel.TabIndex = 3;
            this.bodyLabel.Text = "Email Body (optional)";
            // 
            // attachLabel
            // 
            this.attachLabel.AutoSize = true;
            this.attachLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.attachLabel.Location = new System.Drawing.Point(699, 33);
            this.attachLabel.Name = "attachLabel";
            this.attachLabel.Size = new System.Drawing.Size(138, 22);
            this.attachLabel.TabIndex = 4;
            this.attachLabel.Text = "Attachment(s)";
            // 
            // recipientTextBox
            // 
            this.recipientTextBox.Location = new System.Drawing.Point(703, 352);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Size = new System.Drawing.Size(390, 20);
            this.recipientTextBox.TabIndex = 5;
            // 
            // recipientLabel
            // 
            this.recipientLabel.AutoSize = true;
            this.recipientLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.recipientLabel.Location = new System.Drawing.Point(699, 327);
            this.recipientLabel.Name = "recipientLabel";
            this.recipientLabel.Size = new System.Drawing.Size(34, 22);
            this.recipientLabel.TabIndex = 6;
            this.recipientLabel.Text = "To";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toNoteLabel
            // 
            this.toNoteLabel.AutoSize = true;
            this.toNoteLabel.Location = new System.Drawing.Point(727, 334);
            this.toNoteLabel.Name = "toNoteLabel";
            this.toNoteLabel.Size = new System.Drawing.Size(352, 13);
            this.toNoteLabel.TabIndex = 8;
            this.toNoteLabel.Text = "(separate recipients using commas: ex. mark@abc.com, james@xyz.com)";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.subjectLabel.Location = new System.Drawing.Point(699, 376);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(80, 22);
            this.subjectLabel.TabIndex = 9;
            this.subjectLabel.Text = "Subject";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(703, 401);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(390, 20);
            this.subjectTextBox.TabIndex = 10;
            this.subjectTextBox.Text = "File(s) Attached";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 683);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.toNoteLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.recipientLabel);
            this.Controls.Add(this.recipientTextBox);
            this.Controls.Add(this.attachLabel);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.fileList);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label toNoteLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subjectTextBox;
    }
}

