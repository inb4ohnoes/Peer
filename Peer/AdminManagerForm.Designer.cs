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
            this.grpAssessments = new System.Windows.Forms.GroupBox();
            this.lstAssessments = new System.Windows.Forms.ListBox();
            this.lstTemplate = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.grpResults.Controls.Add(this.lstResults);
            this.grpResults.Controls.Add(this.btnCreateUser);
            this.grpResults.Location = new System.Drawing.Point(12, 38);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(426, 136);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(6, 19);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(414, 82);
            this.lstResults.TabIndex = 0;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(6, 107);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(75, 23);
            this.btnCreateUser.TabIndex = 3;
            this.btnCreateUser.Text = "New User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
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
            this.grpUser.Controls.Add(this.label1);
            this.grpUser.Controls.Add(this.nameLabel);
            this.grpUser.Controls.Add(this.btnDeleteUser);
            this.grpUser.Location = new System.Drawing.Point(12, 180);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(426, 359);
            this.grpUser.TabIndex = 6;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "Selected User Information";
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
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 19);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "nameLabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // AdminManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 797);
            this.Controls.Add(this.lstTemplate);
            this.Controls.Add(this.grpAssessments);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
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
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
    }
}