namespace Peer
{
    partial class UserTemplateForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.templateGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.templateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(13, 13);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(273, 13);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome, %@. Please choose a template to get started.";
            // 
            // templateGroupBox
            // 
            this.templateGroupBox.Controls.Add(this.usersListBox);
            this.templateGroupBox.Location = new System.Drawing.Point(16, 30);
            this.templateGroupBox.Name = "templateGroupBox";
            this.templateGroupBox.Size = new System.Drawing.Size(213, 420);
            this.templateGroupBox.TabIndex = 1;
            this.templateGroupBox.TabStop = false;
            this.templateGroupBox.Text = "1. Available Templates";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(235, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 420);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Choose User";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(454, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 420);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3. Start Assessment";
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Items.AddRange(new object[] {
            "test user 1",
            "test user 2",
            "test uers 3",
            "test user 4"});
            this.usersListBox.Location = new System.Drawing.Point(6, 19);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(201, 394);
            this.usersListBox.TabIndex = 0;
            // 
            // UserTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.templateGroupBox);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "UserTemplateForm";
            this.Text = "Template Chooser";
            this.templateGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.GroupBox templateGroupBox;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}