﻿using System;
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
    public partial class AdminManagerForm : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Logan\\Documents\\GitHub\\Peer\\Peerdb_fixed.accdb");
        //Admin admin;
        public static Person p1;
        public static AdminManagerForm admin;

        public AdminManagerForm()
        {
            InitializeComponent();
            grpUser.Hide();
            grpAssessments.Hide();
            admin = this;
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
            string name = txtSearch.Text.Trim();
            List<Person> people = db.searchUsers(name);
            //String[] results = {};
            //^above should be from db
            
            System.Windows.Forms.ListBox.ObjectCollection collection = new System.Windows.Forms.ListBox.ObjectCollection(lstResults);
            //collection.AddRange(results);

            lstResults.BeginUpdate();

            //lstResults.Items.AddRange(results);
            /*

            foreach (Person p in people)
            {
                lstResults.Items.Add(p);
                label1.Text = p.getFirstName();
                label1.Visible = true;
            }
            
            */
            BindingSource bs = new BindingSource();
            bs.DataSource = people;
            lstResults.DataSource = null;
            lstResults.DataSource = bs;
            lstResults.DisplayMember = "FullName";
            lstResults.ValueMember = "mPersonID";
            //lstResults.DataSource = people;
            //lstResults.Update();
            lstResults.EndUpdate();
            lblTest.Text = people.Count.ToString();
            
            if (people.Count > 0)
            {
                string str = lstResults.SelectedIndex.ToString();
                int index = lstResults.FindString(str);
                index = (int)lstResults.SelectedValue;
                //int index = lstResults.SelectedIndex;
                //List<Person> people = db.searchUsers(value);
                grpUser.Show();
                p1 = db.getPerson(index);
                lblName.Text = p1.getFirstName() + " " + p1.getLastName();
                lblEmail.Text = p1.getEmail();
                lblName.Visible = true;
                lblEmail.Visible = true;
                btnEditUser.Enabled = true;
                lblTest.Text = str + "/" + index.ToString();

            }
            //lstResults.SelectedIndex = -1;

        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = lstResults.SelectedIndex.ToString().Trim();
            //int index = lstResults.FindString(str);
            int index = lstResults.SelectedIndex;
            //List<Person> people = db.searchUsers(value);
            if (index > 0)
            {
                p1 = db.getPerson(index);
                lblName.Text = p1.getFirstName() + " " + p1.getLastName();
                lblEmail.Text = p1.getEmail();
                lblName.Visible = true;
                lblEmail.Visible = true;
                btnEditUser.Enabled = true;
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            p1 = new Person();
            EditUser ed = new EditUser();
            ed.Show();
            Hide();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            EditUser ed = new EditUser();
            ed.Show();
            this.Hide();
        }
    }
}
