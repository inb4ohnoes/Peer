using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace Peer
{
    
    public partial class LoginForm : Form
    {
        /*private clsDatabase db = new clsDatabase(ConfigurationManager.AppSettings["DBConnectionString"]);*/

        public LoginForm()
        {
            InitializeComponent();
        }     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < db.count; i++)
            {

            }*/
            
            //testing for now
            if (/*Job Title*/ == ("user"))
            {
                //consider initializing with initial values
                UserTemplateForm template = new UserTemplateForm();
                template.Show();

                //hide this original one until user returns or logs out
                Hide();

            } 
            else if (/*Job Title*/ == ("admin"))
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
