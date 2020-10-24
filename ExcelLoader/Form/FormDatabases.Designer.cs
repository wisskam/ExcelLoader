namespace ExcelLoader
{
    partial class FormDatabases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabases));
            this.databasesListView = new System.Windows.Forms.ListView();
            this.databaseTypeBox = new System.Windows.Forms.ComboBox();
            this.databaseTypeLabel = new System.Windows.Forms.Label();
            this.databaseDetailsBox = new System.Windows.Forms.GroupBox();
            this.databaseTestButton = new System.Windows.Forms.Button();
            this.databaseDeleteButton = new System.Windows.Forms.Button();
            this.databaseSaveButton = new System.Windows.Forms.Button();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.databaseNameText = new System.Windows.Forms.TextBox();
            this.databasePasswordText = new System.Windows.Forms.TextBox();
            this.databasePasswordLabel = new System.Windows.Forms.Label();
            this.databaseUsernameText = new System.Windows.Forms.TextBox();
            this.databaseUsernameLabel = new System.Windows.Forms.Label();
            this.databaseServerLabel = new System.Windows.Forms.Label();
            this.databaseServerText = new System.Windows.Forms.TextBox();
            this.databasesNewButton = new System.Windows.Forms.Button();
            this.databaseDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // databasesListView
            // 
            this.databasesListView.FullRowSelect = true;
            this.databasesListView.GridLines = true;
            this.databasesListView.HideSelection = false;
            this.databasesListView.Location = new System.Drawing.Point(12, 12);
            this.databasesListView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.databasesListView.MultiSelect = false;
            this.databasesListView.Name = "databasesListView";
            this.databasesListView.Size = new System.Drawing.Size(209, 395);
            this.databasesListView.TabIndex = 0;
            this.databasesListView.UseCompatibleStateImageBehavior = false;
            this.databasesListView.View = System.Windows.Forms.View.List;
            this.databasesListView.SelectedIndexChanged += new System.EventHandler(this.databasesListView_SelectedIndexChanged);
            // 
            // databaseTypeBox
            // 
            this.databaseTypeBox.FormattingEnabled = true;
            this.databaseTypeBox.Location = new System.Drawing.Point(8, 42);
            this.databaseTypeBox.Name = "databaseTypeBox";
            this.databaseTypeBox.Size = new System.Drawing.Size(121, 21);
            this.databaseTypeBox.TabIndex = 0;
            // 
            // databaseTypeLabel
            // 
            this.databaseTypeLabel.AutoSize = true;
            this.databaseTypeLabel.Location = new System.Drawing.Point(5, 26);
            this.databaseTypeLabel.Name = "databaseTypeLabel";
            this.databaseTypeLabel.Size = new System.Drawing.Size(80, 13);
            this.databaseTypeLabel.TabIndex = 2;
            this.databaseTypeLabel.Text = "Database Type";
            this.databaseTypeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // databaseDetailsBox
            // 
            this.databaseDetailsBox.Controls.Add(this.databaseTestButton);
            this.databaseDetailsBox.Controls.Add(this.databaseDeleteButton);
            this.databaseDetailsBox.Controls.Add(this.databaseTypeLabel);
            this.databaseDetailsBox.Controls.Add(this.databaseSaveButton);
            this.databaseDetailsBox.Controls.Add(this.databaseTypeBox);
            this.databaseDetailsBox.Controls.Add(this.databaseNameLabel);
            this.databaseDetailsBox.Controls.Add(this.databaseNameText);
            this.databaseDetailsBox.Controls.Add(this.databasePasswordText);
            this.databaseDetailsBox.Controls.Add(this.databasePasswordLabel);
            this.databaseDetailsBox.Controls.Add(this.databaseUsernameText);
            this.databaseDetailsBox.Controls.Add(this.databaseUsernameLabel);
            this.databaseDetailsBox.Controls.Add(this.databaseServerLabel);
            this.databaseDetailsBox.Controls.Add(this.databaseServerText);
            this.databaseDetailsBox.Enabled = false;
            this.databaseDetailsBox.Location = new System.Drawing.Point(230, 12);
            this.databaseDetailsBox.Name = "databaseDetailsBox";
            this.databaseDetailsBox.Size = new System.Drawing.Size(558, 240);
            this.databaseDetailsBox.TabIndex = 3;
            this.databaseDetailsBox.TabStop = false;
            this.databaseDetailsBox.Text = "Database details";
            // 
            // databaseTestButton
            // 
            this.databaseTestButton.Location = new System.Drawing.Point(350, 205);
            this.databaseTestButton.Name = "databaseTestButton";
            this.databaseTestButton.Size = new System.Drawing.Size(121, 23);
            this.databaseTestButton.TabIndex = 10;
            this.databaseTestButton.Text = "Test connection";
            this.databaseTestButton.UseVisualStyleBackColor = true;
            this.databaseTestButton.Click += new System.EventHandler(this.databaseTestButton_Click);
            // 
            // databaseDeleteButton
            // 
            this.databaseDeleteButton.Location = new System.Drawing.Point(10, 205);
            this.databaseDeleteButton.Name = "databaseDeleteButton";
            this.databaseDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.databaseDeleteButton.TabIndex = 9;
            this.databaseDeleteButton.Text = "Delete";
            this.databaseDeleteButton.UseVisualStyleBackColor = true;
            this.databaseDeleteButton.Click += new System.EventHandler(this.databaseDeleteButton_Click);
            // 
            // databaseSaveButton
            // 
            this.databaseSaveButton.Location = new System.Drawing.Point(477, 205);
            this.databaseSaveButton.Name = "databaseSaveButton";
            this.databaseSaveButton.Size = new System.Drawing.Size(75, 23);
            this.databaseSaveButton.TabIndex = 8;
            this.databaseSaveButton.Text = "Save";
            this.databaseSaveButton.UseVisualStyleBackColor = true;
            this.databaseSaveButton.Click += new System.EventHandler(this.databaseSaveButton_Click);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Location = new System.Drawing.Point(292, 90);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(53, 13);
            this.databaseNameLabel.TabIndex = 7;
            this.databaseNameLabel.Text = "Database";
            // 
            // databaseNameText
            // 
            this.databaseNameText.Location = new System.Drawing.Point(295, 106);
            this.databaseNameText.Name = "databaseNameText";
            this.databaseNameText.Size = new System.Drawing.Size(258, 20);
            this.databaseNameText.TabIndex = 3;
            // 
            // databasePasswordText
            // 
            this.databasePasswordText.Location = new System.Drawing.Point(295, 150);
            this.databasePasswordText.Name = "databasePasswordText";
            this.databasePasswordText.PasswordChar = '*';
            this.databasePasswordText.Size = new System.Drawing.Size(258, 20);
            this.databasePasswordText.TabIndex = 6;
            // 
            // databasePasswordLabel
            // 
            this.databasePasswordLabel.AutoSize = true;
            this.databasePasswordLabel.Location = new System.Drawing.Point(292, 133);
            this.databasePasswordLabel.Name = "databasePasswordLabel";
            this.databasePasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.databasePasswordLabel.TabIndex = 4;
            this.databasePasswordLabel.Text = "Password";
            // 
            // databaseUsernameText
            // 
            this.databaseUsernameText.Location = new System.Drawing.Point(8, 150);
            this.databaseUsernameText.Name = "databaseUsernameText";
            this.databaseUsernameText.Size = new System.Drawing.Size(218, 20);
            this.databaseUsernameText.TabIndex = 5;
            // 
            // databaseUsernameLabel
            // 
            this.databaseUsernameLabel.AutoSize = true;
            this.databaseUsernameLabel.Location = new System.Drawing.Point(5, 133);
            this.databaseUsernameLabel.Name = "databaseUsernameLabel";
            this.databaseUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.databaseUsernameLabel.TabIndex = 2;
            this.databaseUsernameLabel.Text = "Username";
            // 
            // databaseServerLabel
            // 
            this.databaseServerLabel.AutoSize = true;
            this.databaseServerLabel.Location = new System.Drawing.Point(5, 90);
            this.databaseServerLabel.Name = "databaseServerLabel";
            this.databaseServerLabel.Size = new System.Drawing.Size(38, 13);
            this.databaseServerLabel.TabIndex = 1;
            this.databaseServerLabel.Text = "Server";
            // 
            // databaseServerText
            // 
            this.databaseServerText.Location = new System.Drawing.Point(8, 106);
            this.databaseServerText.Name = "databaseServerText";
            this.databaseServerText.Size = new System.Drawing.Size(219, 20);
            this.databaseServerText.TabIndex = 1;
            // 
            // databasesNewButton
            // 
            this.databasesNewButton.Location = new System.Drawing.Point(12, 415);
            this.databasesNewButton.Name = "databasesNewButton";
            this.databasesNewButton.Size = new System.Drawing.Size(75, 23);
            this.databasesNewButton.TabIndex = 4;
            this.databasesNewButton.Text = "New";
            this.databasesNewButton.UseVisualStyleBackColor = true;
            this.databasesNewButton.Click += new System.EventHandler(this.databasesNewButton_Click);
            // 
            // FormDatabases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.databasesNewButton);
            this.Controls.Add(this.databaseDetailsBox);
            this.Controls.Add(this.databasesListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDatabases";
            this.Text = "Settings - Databases";
            this.Load += new System.EventHandler(this.FormDatabases_Load);
            this.Disposed += new System.EventHandler(this.FormDatabases_Dispose);
            this.databaseDetailsBox.ResumeLayout(false);
            this.databaseDetailsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView databasesListView;
        private System.Windows.Forms.ComboBox databaseTypeBox;
        private System.Windows.Forms.Label databaseTypeLabel;
        private System.Windows.Forms.GroupBox databaseDetailsBox;
        private System.Windows.Forms.Button databaseDeleteButton;
        private System.Windows.Forms.Button databaseSaveButton;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.TextBox databaseNameText;
        private System.Windows.Forms.TextBox databasePasswordText;
        private System.Windows.Forms.Label databasePasswordLabel;
        private System.Windows.Forms.TextBox databaseUsernameText;
        private System.Windows.Forms.Label databaseUsernameLabel;
        private System.Windows.Forms.Label databaseServerLabel;
        private System.Windows.Forms.TextBox databaseServerText;
        private System.Windows.Forms.Button databasesNewButton;
        private System.Windows.Forms.Button databaseTestButton;
    }
}