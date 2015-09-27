namespace CheckoutSVN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fetchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkoutFolderTextBox = new System.Windows.Forms.TextBox();
            this.repoAddressTextBox = new System.Windows.Forms.TextBox();
            this.tagList = new System.Windows.Forms.ListView();
            this.TagColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RevisionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkoutLogRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(454, 252);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(72, 23);
            this.checkoutButton.TabIndex = 4;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fetchButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkoutFolderTextBox);
            this.groupBox1.Controls.Add(this.repoAddressTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(430, 43);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Checkout Folder";
            // 
            // fetchButton
            // 
            this.fetchButton.Location = new System.Drawing.Point(430, 17);
            this.fetchButton.Name = "fetchButton";
            this.fetchButton.Size = new System.Drawing.Size(75, 23);
            this.fetchButton.TabIndex = 4;
            this.fetchButton.Text = "Fetch";
            this.fetchButton.UseVisualStyleBackColor = true;
            this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repository Address";
            // 
            // checkoutFolderTextBox
            // 
            this.checkoutFolderTextBox.Location = new System.Drawing.Point(110, 45);
            this.checkoutFolderTextBox.Name = "checkoutFolderTextBox";
            this.checkoutFolderTextBox.Size = new System.Drawing.Size(314, 20);
            this.checkoutFolderTextBox.TabIndex = 0;
            this.checkoutFolderTextBox.Text = global::CheckoutSVN.Properties.Settings.Default.targetFolder;
            this.checkoutFolderTextBox.TextChanged += new System.EventHandler(this.checkoutFolderTextBox_TextChanged);
            // 
            // repoAddressTextBox
            // 
            this.repoAddressTextBox.Location = new System.Drawing.Point(110, 19);
            this.repoAddressTextBox.Name = "repoAddressTextBox";
            this.repoAddressTextBox.Size = new System.Drawing.Size(314, 20);
            this.repoAddressTextBox.TabIndex = 0;
            this.repoAddressTextBox.Text = global::CheckoutSVN.Properties.Settings.Default.repositoryAddress;
            this.repoAddressTextBox.TextChanged += new System.EventHandler(this.repoAddressTextBox_TextChanged);
            // 
            // tagList
            // 
            this.tagList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TagColumn,
            this.DateColumn,
            this.RevisionColumn});
            this.tagList.Location = new System.Drawing.Point(12, 97);
            this.tagList.MultiSelect = false;
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(514, 149);
            this.tagList.TabIndex = 6;
            this.tagList.UseCompatibleStateImageBehavior = false;
            this.tagList.View = System.Windows.Forms.View.Details;
            // 
            // TagColumn
            // 
            this.TagColumn.Text = "Tag";
            this.TagColumn.Width = 251;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Date";
            this.DateColumn.Width = 141;
            // 
            // RevisionColumn
            // 
            this.RevisionColumn.Text = "Revision";
            this.RevisionColumn.Width = 119;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(376, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(72, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkoutLogRTB
            // 
            this.checkoutLogRTB.DetectUrls = false;
            this.checkoutLogRTB.Location = new System.Drawing.Point(12, 281);
            this.checkoutLogRTB.Name = "checkoutLogRTB";
            this.checkoutLogRTB.ReadOnly = true;
            this.checkoutLogRTB.ShortcutsEnabled = false;
            this.checkoutLogRTB.Size = new System.Drawing.Size(514, 209);
            this.checkoutLogRTB.TabIndex = 7;
            this.checkoutLogRTB.Text = "";
            this.checkoutLogRTB.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 502);
            this.Controls.Add(this.checkoutLogRTB);
            this.Controls.Add(this.tagList);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Checkout SVN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox checkoutFolderTextBox;
        private System.Windows.Forms.TextBox repoAddressTextBox;
        private System.Windows.Forms.ListView tagList;
        private System.Windows.Forms.ColumnHeader TagColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.Button fetchButton;
        private System.Windows.Forms.ColumnHeader RevisionColumn;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox checkoutLogRTB;
    }
}

