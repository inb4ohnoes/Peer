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
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.userChoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.templateGroupBox.SuspendLayout();
            this.userChoiceGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.templateGroupBox.Controls.Add(this.templateListBox);
            this.templateGroupBox.Location = new System.Drawing.Point(235, 31);
            this.templateGroupBox.Name = "templateGroupBox";
            this.templateGroupBox.Size = new System.Drawing.Size(213, 420);
            this.templateGroupBox.TabIndex = 1;
            this.templateGroupBox.TabStop = false;
            this.templateGroupBox.Text = "2. Available Templates";
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
            this.usersListBox.SelectedValueChanged += new System.EventHandler(this.usersListBox_SelectedValueChanged);
            // 
            // userChoiceGroupBox
            // 
            this.userChoiceGroupBox.Controls.Add(this.usersListBox);
            this.userChoiceGroupBox.Location = new System.Drawing.Point(16, 31);
            this.userChoiceGroupBox.Name = "userChoiceGroupBox";
            this.userChoiceGroupBox.Size = new System.Drawing.Size(213, 420);
            this.userChoiceGroupBox.TabIndex = 2;
            this.userChoiceGroupBox.TabStop = false;
            this.userChoiceGroupBox.Text = "1. Choose User";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Location = new System.Drawing.Point(454, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 420);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3. Start Assessment";
            // 
            // templateListBox
            // 
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Items.AddRange(new object[] {
            "test template 1",
            "test template 2",
            "test template 3",
            "test template 4"});
            this.templateListBox.Location = new System.Drawing.Point(6, 19);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(201, 394);
            this.templateListBox.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(75, 196);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // UserTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.userChoiceGroupBox);
            this.Controls.Add(this.templateGroupBox);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "UserTemplateForm";
            this.Text = "Template Chooser";
            this.templateGroupBox.ResumeLayout(false);
            this.userChoiceGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.GroupBox templateGroupBox;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.GroupBox userChoiceGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox templateListBox;
        private System.Windows.Forms.Button startButton;
    }
}