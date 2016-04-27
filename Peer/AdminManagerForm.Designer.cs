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
            this.btnGetUserInfo = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.grpAssessments = new System.Windows.Forms.GroupBox();
            this.lstAssessments = new System.Windows.Forms.ListBox();
            this.grpTemplate = new System.Windows.Forms.GroupBox();
            this.lstTemplates = new System.Windows.Forms.ListBox();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnModifyRole = new System.Windows.Forms.Button();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.grpTeam = new System.Windows.Forms.GroupBox();
            this.btnModifyTeam = new System.Windows.Forms.Button();
            this.lstTeam = new System.Windows.Forms.ListBox();
            this.btnCreateTemplate = new System.Windows.Forms.Button();
            this.lblGrader = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.grpResults.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.grpAssessments.SuspendLayout();
            this.grpTemplate.SuspendLayout();
            this.grpRoles.SuspendLayout();
            this.grpTeam.SuspendLayout();
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
            this.grpResults.Controls.Add(this.btnGetUserInfo);
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
            // btnGetUserInfo
            // 
            this.btnGetUserInfo.Location = new System.Drawing.Point(6, 107);
            this.btnGetUserInfo.Name = "btnGetUserInfo";
            this.btnGetUserInfo.Size = new System.Drawing.Size(105, 23);
            this.btnGetUserInfo.TabIndex = 5;
            this.btnGetUserInfo.Text = "Get User Info";
            this.btnGetUserInfo.UseVisualStyleBackColor = true;
            this.btnGetUserInfo.Click += new System.EventHandler(this.btnGetUserInfo_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(198, 107);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(75, 23);
            this.btnEditUser.TabIndex = 4;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
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
            this.btnCreateUser.Location = new System.Drawing.Point(117, 107);
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
            this.grpUser.Controls.Add(this.lblUser);
            this.grpUser.Controls.Add(this.lblGrader);
            this.grpUser.Controls.Add(this.lblEmail);
            this.grpUser.Controls.Add(this.lblName);
            this.grpUser.Controls.Add(this.btnDeleteUser);
            this.grpUser.Location = new System.Drawing.Point(12, 190);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(426, 277);
            this.grpUser.TabIndex = 6;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "Selected User Information";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 62);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "emailLabel";
            this.lblEmail.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 40);
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
            // grpTemplate
            // 
            this.grpTemplate.Controls.Add(this.lstTemplates);
            this.grpTemplate.Location = new System.Drawing.Point(12, 546);
            this.grpTemplate.Name = "grpTemplate";
            this.grpTemplate.Size = new System.Drawing.Size(1196, 239);
            this.grpTemplate.TabIndex = 7;
            this.grpTemplate.TabStop = false;
            this.grpTemplate.Text = "Template Management";
            // 
            // lstTemplates
            // 
            this.lstTemplates.FormattingEnabled = true;
            this.lstTemplates.Location = new System.Drawing.Point(9, 19);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.Size = new System.Drawing.Size(1181, 199);
            this.lstTemplates.TabIndex = 0;
            // 
            // lstRoles
            // 
            this.lstRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(6, 14);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(414, 78);
            this.lstRoles.TabIndex = 8;
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.btnDeleteRole);
            this.grpRoles.Controls.Add(this.btnModifyRole);
            this.grpRoles.Controls.Add(this.btnCreateRole);
            this.grpRoles.Controls.Add(this.lstRoles);
            this.grpRoles.Location = new System.Drawing.Point(444, 38);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(437, 130);
            this.grpRoles.TabIndex = 9;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Roles";
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Location = new System.Drawing.Point(210, 107);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteRole.TabIndex = 11;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnModifyRole
            // 
            this.btnModifyRole.Location = new System.Drawing.Point(108, 107);
            this.btnModifyRole.Name = "btnModifyRole";
            this.btnModifyRole.Size = new System.Drawing.Size(96, 23);
            this.btnModifyRole.TabIndex = 10;
            this.btnModifyRole.Text = "Modify Role";
            this.btnModifyRole.UseVisualStyleBackColor = true;
            this.btnModifyRole.Click += new System.EventHandler(this.btnModifyRole_Click);
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(6, 107);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(96, 23);
            this.btnCreateRole.TabIndex = 9;
            this.btnCreateRole.Text = "Create Role";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // grpTeam
            // 
            this.grpTeam.Controls.Add(this.btnModifyTeam);
            this.grpTeam.Controls.Add(this.lstTeam);
            this.grpTeam.Location = new System.Drawing.Point(444, 190);
            this.grpTeam.Name = "grpTeam";
            this.grpTeam.Size = new System.Drawing.Size(437, 130);
            this.grpTeam.TabIndex = 10;
            this.grpTeam.TabStop = false;
            this.grpTeam.Text = "Teams";
            // 
            // btnModifyTeam
            // 
            this.btnModifyTeam.Location = new System.Drawing.Point(6, 107);
            this.btnModifyTeam.Name = "btnModifyTeam";
            this.btnModifyTeam.Size = new System.Drawing.Size(96, 23);
            this.btnModifyTeam.TabIndex = 10;
            this.btnModifyTeam.Text = "Modify Team";
            this.btnModifyTeam.UseVisualStyleBackColor = true;
            this.btnModifyTeam.Click += new System.EventHandler(this.btnModifyTeam_Click);
            // 
            // lstTeam
            // 
            this.lstTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTeam.FormattingEnabled = true;
            this.lstTeam.Location = new System.Drawing.Point(6, 14);
            this.lstTeam.Name = "lstTeam";
            this.lstTeam.Size = new System.Drawing.Size(414, 78);
            this.lstTeam.TabIndex = 8;
            // 
            // btnCreateTemplate
            // 
            this.btnCreateTemplate.Location = new System.Drawing.Point(12, 517);
            this.btnCreateTemplate.Name = "btnCreateTemplate";
            this.btnCreateTemplate.Size = new System.Drawing.Size(111, 23);
            this.btnCreateTemplate.TabIndex = 11;
            this.btnCreateTemplate.Text = "Create Template";
            this.btnCreateTemplate.UseVisualStyleBackColor = true;
            this.btnCreateTemplate.Click += new System.EventHandler(this.btnCreateTemplate_Click);
            // 
            // lblGrader
            // 
            this.lblGrader.AutoSize = true;
            this.lblGrader.Location = new System.Drawing.Point(6, 84);
            this.lblGrader.Name = "lblGrader";
            this.lblGrader.Size = new System.Drawing.Size(63, 13);
            this.lblGrader.TabIndex = 7;
            this.lblGrader.Text = "graderLabel";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(53, 13);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "userLabel";
            // 
            // AdminManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 783);
            this.Controls.Add(this.btnCreateTemplate);
            this.Controls.Add(this.grpTeam);
            this.Controls.Add(this.grpRoles);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grpTemplate);
            this.Controls.Add(this.grpAssessments);
            this.Name = "AdminManagerForm";
            this.Text = "Admin Manager Wow So Cool OMG";
            this.Load += new System.EventHandler(this.AdminManagerForm_Load);
            this.grpResults.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.grpAssessments.ResumeLayout(false);
            this.grpTemplate.ResumeLayout(false);
            this.grpRoles.ResumeLayout(false);
            this.grpTeam.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpTemplate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.GroupBox grpRoles;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnModifyRole;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.GroupBox grpTeam;
        private System.Windows.Forms.Button btnModifyTeam;
        private System.Windows.Forms.ListBox lstTeam;
        private System.Windows.Forms.Button btnGetUserInfo;
        private System.Windows.Forms.ListBox lstTemplates;
        private System.Windows.Forms.Button btnCreateTemplate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblGrader;
    }
}