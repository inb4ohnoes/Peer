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
using System.Data.OleDb;

namespace Peer
{
    public partial class LoginForm : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Logan\\Documents\\GitHub\\Peer\\Peerdb_fixed.accdb");
        //static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:\Users\Logan\Documents\GitHub\Peer\Peerdb_fixed.accdb;";
        //string query = "SELECT * FROM [USER]";
        //OleDbConnection connection = new OleDbConnection(connectionString);
        public static User u1;

        public LoginForm()
        {
            InitializeComponent();
        }     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            /*try
            {
                OleDbCommand c1 = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = c1.ExecuteReader();
                while (reader.Read())
                {
                    int userid = reader.GetInt32(0);
                    lblError.Text = userid.ToString();
                    lblError.Visible = true;
                }
                reader.Close();
            }
            finally
            {
                connection.Close();
            }
            */
            int userid = -1;
            userid = db.login(username, password);
            if (userid == -1)
            {
                lblError.Visible = true;
            }
            else
            {
                int accountStatus = db.isAdmin(userid);
                if (accountStatus == 0)
                {
                    u1 = db.getUser(userid);
                    UserTemplateForm template = new UserTemplateForm();
                    template.Show();

                    //hide this original one until user returns or logs out
                    Hide();
                }
                else
                {
                    u1 = db.getUser(userid);
                    AdminManagerForm admin = new AdminManagerForm();
                    admin.Show();

                    Hide();
                }
            }
            //testing for now
            /*
            if (/*Job Title/ == ("user"))
            {
                //consider initializing with initial values
                UserTemplateForm template = new UserTemplateForm();
                template.Show();

                //hide this original one until user returns or logs out
                Hide();

            } 
            else if (//Job Title == ("admin"))
            {
                AdminManagerForm admin = new AdminManagerForm();
                admin.Show();

                Hide();
            }
            */
            
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
