using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peer
{
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //testing for now
            if (txtUsername.Text.Equals("user"))
            {
                //consider initializing with initial values
                UserTemplateForm template = new UserTemplateForm();
                template.Show();

                //hide this original one until user returns or logs out
                Hide();

            } else if (txtUsername.Text.Equals("admin"))
            {
                AdminManagerForm admin = new AdminManagerForm();
                admin.Show();

                Hide();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
