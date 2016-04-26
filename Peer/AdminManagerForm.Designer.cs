namespace Peer
{
    partial class AdminManagerForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grpAssessments = new System.Windows.Forms.GroupBox();
            this.lstAssessments = new System.Windows.Forms.ListBox();
            this.lstTemplate = new System.Windows.Forms.GroupBox();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.grpResults.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.grpAssessments.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(363, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.btnEditUser);
            this.grpResults.Controls.Add(this.lstResults);
            this.grpResults.Controls.Add(this.btnCreateUser);
            this.grpResults.Location = new System.Drawing.Point(12, 38);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(426, 130);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.AllowDrop = true;
            this.lstResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(0, 14);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(414, 78);
            this.lstResults.TabIndex = 0;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(6, 107);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(75, 23);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "New User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(345, 472);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.lblEmail);
            this.grpUser.Controls.Add(this.lblName);
            this.grpUser.Controls.Add(this.btnDeleteUser);
            this.grpUser.Location = new System.Drawing.Point(12, 190);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(449, 277);
            this.grpUser.TabIndex = 6;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "Selected User Information";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 36);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "label1";
            this.lblEmail.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "nameLabel";
            this.lblName.Visible = false;
            // 
            // grpAssessments
            // 
            this.grpAssessments.Controls.Add(this.lstAssessments);
            this.grpAssessments.Location = new System.Drawing.Point(876, 38);
            this.grpAssessments.Name = "grpAssessments";
            this.grpAssessments.Size = new System.Drawing.Size(338, 501);
            this.grpAssessments.TabIndex = 5;
            this.grpAssessments.TabStop = false;
            this.grpAssessments.Text = "User Assessments";
            // 
            // lstAssessments
            // 
            this.lstAssessments.FormattingEnabled = true;
            this.lstAssessments.Location = new System.Drawing.Point(6, 19);
            this.lstAssessments.Name = "lstAssessments";
            this.lstAssessments.Size = new System.Drawing.Size(326, 446);
            this.lstAssessments.TabIndex = 0;
            // 
            // lstTemplate
            // 
            this.lstTemplate.Location = new System.Drawing.Point(12, 546);
            this.lstTemplate.Name = "lstTemplate";
            this.lstTemplate.Size = new System.Drawing.Size(1196, 239);
            this.lstTemplate.TabIndex = 7;
            this.lstTemplate.TabStop = false;
            this.lstTemplate.Text = "Template Management";
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(87, 107);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(75, 23);
            this.btnEditUser.TabIndex = 4;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(529, 52);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 8;
            this.lblTest.Text = "label2";
            // 
            // AdminManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 797);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstTemplate);
            this.Controls.Add(this.grpAssessments);
            this.Name = "AdminManagerForm";
            this.Text = "Admin Manager Wow So Cool OMG";
            this.grpResults.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.grpAssessments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.GroupBox grpAssessments;
        private System.Windows.Forms.ListBox lstAssessments;
        private System.Windows.Forms.GroupBox lstTemplate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblTest;
    }
}