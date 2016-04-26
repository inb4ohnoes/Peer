namespace Peer
{
    partial class EditTeam
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.lstTeam = new System.Windows.Forms.ListBox();
            this.lblTL = new System.Windows.Forms.Label();
            this.cmbAvaliableAdmin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 282);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(12, 282);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 13;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click_1);
            // 
            // lstTeam
            // 
            this.lstTeam.FormattingEnabled = true;
            this.lstTeam.Location = new System.Drawing.Point(12, 51);
            this.lstTeam.Name = "lstTeam";
            this.lstTeam.Size = new System.Drawing.Size(234, 225);
            this.lstTeam.TabIndex = 12;
            // 
            // lblTL
            // 
            this.lblTL.AutoSize = true;
            this.lblTL.Location = new System.Drawing.Point(28, 9);
            this.lblTL.Name = "lblTL";
            this.lblTL.Size = new System.Drawing.Size(195, 13);
            this.lblTL.TabIndex = 8;
            this.lblTL.Text = "Avaliable Admins Not Assigned to Team";
            // 
            // cmbAvaliableAdmin
            // 
            this.cmbAvaliableAdmin.FormattingEnabled = true;
            this.cmbAvaliableAdmin.Location = new System.Drawing.Point(12, 25);
            this.cmbAvaliableAdmin.Name = "cmbAvaliableAdmin";
            this.cmbAvaliableAdmin.Size = new System.Drawing.Size(234, 21);
            this.cmbAvaliableAdmin.TabIndex = 16;
            // 
            // EditTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 322);
            this.Controls.Add(this.cmbAvaliableAdmin);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lstTeam);
            this.Controls.Add(this.lblTL);
            this.Name = "EditTeam";
            this.Text = "EditTeam";
            this.Load += new System.EventHandler(this.EditTeam_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.ListBox lstTeam;
        private System.Windows.Forms.Label lblTL;
        private System.Windows.Forms.ComboBox cmbAvaliableAdmin;
    }
}