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
    public partial class AdminManagerForm : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\myhome.itap.purdue.edu\\puhome\\pu.data\\Desktop\\GitHub\\Peer\\Peerdb_fixed.accdb");
        //Admin admin;
        //public static Person p1;
        public static User u1;
        public static Role r1;
        public static AdminManagerForm admin;

        public AdminManagerForm()
        {
            InitializeComponent();
            grpUser.Hide();
            grpAssessments.Hide();
            admin = this;
        }

        public void callOnLoad()
        {
            
            lblName.Text = "";
            lblEmail.Text = "";
            lblName.Visible = false;
            lblEmail.Visible = false;
            btnEditUser.Enabled = false;
            grpUser.Visible = false;
            txtSearch.Text = "";
            

            List<Role> currentRoles = db.getRoles();
            List < ListItemRole > available = new List<ListItemRole>();
            foreach (Role r1 in currentRoles)
            {
                ListItemRole av = new ListItemRole(r1);
                available.Add(av);
            }
            List<User> currentTLs = db.getTLs();
            List<ListItemUser> ctls = new List<ListItemUser>();
            foreach (User u1 in currentTLs)
            {
                ListItemUser uv = new ListItemUser(u1);
                ctls.Add(uv);
            }
            lstTeam.DataSource = null;
            lstTeam.DataSource = ctls;
            lstTeam.DisplayMember = "name";
            lstTeam.ValueMember = "uid";
            lstRoles.DataSource = null;
            lstRoles.DataSource = available;
            lstRoles.DisplayMember = "name";
            lstRoles.ValueMember = "roleID";
            lstRoles.SelectedIndex = -1;
            lstResults.DataSource = null;
            lstResults.SelectedIndex = -1;

            List<Template> currentTemplates = db.getTemplates();
            List<ListItemTemplate> cts = new List<ListItemTemplate>();
            foreach (Template t in currentTemplates)
            {
                ListItemTemplate tv = new ListItemTemplate(t);
                cts.Add(tv);
            }
            lstTemplates.DataSource = null;
            lstTemplates.DataSource = cts;
            lstTemplates.DisplayMember = "name";
            lstTemplates.ValueMember = "tid";
            lstTemplates.SelectedIndex = -1;
        }

        //button methods

        public bool createAssessment()
        {
            //return true/false is successfully created or not
            return false;
        }

        public bool deleteAssessment()
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
            List<User> people = db.searchUsers(name);
            //String[] results = {};
            //^above should be from db

            //System.Windows.Forms.ListBox.ObjectCollection collection = new System.Windows.Forms.ListBox.ObjectCollection(lstResults);
            //collection.AddRange(results);

            //lstResults.BeginUpdate();

            //lstResults.Items.AddRange(results);
            /*

            foreach (Person p in people)
            {
                lstResults.Items.Add(p);
                label1.Text = p.getFirstName();
                label1.Visible = true;
            }
            
            */
            //BindingSource bs = new BindingSource();
            //bs.DataSource = people;
            List<ListItemUser> users = new List<ListItemUser>();
            foreach (User user in people)
            {
                ListItemUser uv = new ListItemUser(user);
                users.Add(uv);
            }
            lstResults.DataSource = null;
            lstResults.DataSource = users;
            lstResults.DisplayMember = "name";
            lstResults.ValueMember = "uid";
            lstResults.SelectedIndex = -1;
            //lstResults.DataSource = people;
            //lstResults.Update();
            //lstResults.EndUpdate();
            //lblTest.Text = people.Count.ToString();
            //lstResults.SelectedIndex = -1;

        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            string str = lstResults.SelectedIndex.ToString().Trim();
            //int index = lstResults.FindString(str);
            int index = (int)lstResults.SelectedValue;
            //List<Person> people = db.searchUsers(value);
            if (index > 0)
            {
                u1 = db.getUser(index);
                lblName.Text = p1.getFirstName() + " " + p1.getLastName();
                lblEmail.Text = p1.getEmail();
                lblName.Visible = true;
                lblEmail.Visible = true;
                btnEditUser.Enabled = true;
            }
            */
            btnEditUser.Enabled = true;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            u1 = new User();
            EditUser ed = new EditUser();
            ed.Show();
            Hide();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(lstResults.SelectedValue);
            int index = Convert.ToInt32(lstResults.SelectedIndex);
            u1 = db.getUser(uid);
            EditUser ed = new EditUser();
            ed.Show();
            this.Hide();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            r1 = new Role();
            EditRole er = new EditRole();
            er.Show();
            this.Hide();
        }

        private void btnModifyRole_Click(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(lstRoles.SelectedValue);
            int index = Convert.ToInt32(lstRoles.SelectedIndex);
            r1 = db.getRoleByID(roleid);
            EditRole er = new EditRole();
            er.Show();
            this.Hide();
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(lstRoles.SelectedValue);
            int index = Convert.ToInt32(lstRoles.SelectedIndex);
            if (index != -1)
            {
                db.deleteRole(roleid);
            }
            callOnLoad();
        }

        private void AdminManagerForm_Load(object sender, EventArgs e)
        {
            callOnLoad();
        }

        private void btnModifyTeam_Click(object sender, EventArgs e)
        {
            EditTeam et = new EditTeam();
            et.Show();
            this.Hide();
        }

        private void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(lstResults.SelectedValue);
            int index = Convert.ToInt32(lstResults.SelectedIndex);
            u1 = db.getUser(uid);
            grpUser.Show();
            lblName.Text = u1.getFirstName() + " " + u1.getLastName();
            lblEmail.Text = u1.getEmail();
            lblName.Visible = true;
            lblEmail.Visible = true;
            List<Assessment> assessments = db.getAssessmentsForUser(u1);
            List<ListItemAssessment> list = new List<ListItemAssessment>();
            foreach (Assessment a in assessments)
            {
                ListItemAssessment av = new ListItemAssessment(a);
                list.Add(av);
            }
            grpAssessments.Show();
            lstAssessments.DataSource = null;
            lstAssessments.DataSource = list;
            lstAssessments.DisplayMember = "name";
            lstAssessments.ValueMember = "aid";
            lstAssessments.SelectedIndex = -1;
        }

        public class ListItemAssessment
        {
            private Assessment a;
            public int aid { get; set; }
            public string name { get; set; }

            public ListItemAssessment()
            {
                a = new Assessment();
                aid = a.getAssessmentID();
                name = a.getReviewer() + " -> " + a.getReviewee();
            }

            public ListItemAssessment(Assessment ass)
            {
                a = ass;
                aid = a.getAssessmentID();
                name = aid + ". " + a.getReviewer() + " -> " + a.getReviewee();
            }
        }

        public class ListItemTemplate
        {
            private Template t;
            public int tid { get; set; }
            public string name { get; set; }

            public ListItemTemplate()
            {
                t = new Template();
                tid = t.getTemplateID();
                name = tid + ". " + t.getName() + " - " + t.getCreator();
            }

            public ListItemTemplate(Template temp)
            {
                t = temp;
                tid = t.getTemplateID();
                name = tid + ". " + t.getName() + " - " + t.getCreator();
            }
        }

        private void btnCreateTemplate_Click(object sender, EventArgs e)
        {
            CreateTemplate ct = new CreateTemplate();
            ct.Show();
            this.Hide();
        }
    }
}
