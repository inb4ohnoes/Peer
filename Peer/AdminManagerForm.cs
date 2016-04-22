using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ListBox.ObjectCollection;

namespace Peer
{
    public partial class AdminManagerForm : Form
    {
        public AdminManagerForm()
        {
            InitializeComponent();

            grpUser.Hide();
            grpAssessments.Hide();
        }

        //button methods


        //class methods
        public bool createUser()
        {
            //USE UserTable
            //INSERT SomeUser 
            //return true/false if successful or not successful.
            //may be useful sometime later
            return false;
        }

        public bool deleteUser()
        {
            //returns YES/NO if successful or not successful
            return false;
        }

        public User getUserInformation()
        {

            return new User();
        }

        public bool changeUserInformation()
        {
            //return true/false if successful or not successful
            return false;
        }

        public bool createAssessment()
        {
            //return true/false is successfully created or not
            return false;
        }

        public bool deleteAssessment()
        {
            return false;
        }

        public void viewResults()
        {
            //what results idk
        }

        public bool createTeam()
        {
            return false;
        }

        public bool deleteTeam()
        {
            return false;
        }

        public void createQuestion()
        {
            
        }

        public void deleteQuestion()
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //SELECT Name FROM SomeTable WHERE Name = *sender.Text*;
            String[] results = {};
            //^above should be from db

            System.Windows.Forms.ListBox.ObjectCollection collection = new System.Windows.Forms.ListBox.ObjectCollection(lstResults);
            collection.AddRange(results);

            lstResults.BeginUpdate();

            lstResults.Items.AddRange(results);

            lstResults.EndUpdate();

        }
    }
}
