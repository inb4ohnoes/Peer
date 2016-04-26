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
    public partial class EditUser : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Logan\\Documents\\GitHub\\Peer\\Peerdb_fixed.accdb");
        public static User user;
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            callOnLoad();
        }

        public void callOnLoad()
        {
            btnRemoveRole.Enabled = false;
            btnAddRole.Enabled = false;
            Person p1 = AdminManagerForm.p1;
            int pid;
            String Username;
            String Password;
            String FirstName;
            String LastName;
            String Email;
            int GraderNumber;
            Team tid;
            User TL;
            List<Role> Roles;
            FirstName = p1.getFirstName();
            LastName = p1.getLastName();
            Email = p1.getEmail();
            GraderNumber = p1.getGraderNumber();
            pid = p1.getPersonID();
            user = db.getUserbyPerson(p1, pid);
            Username = user.getUserName();
            Password = user.getPassword();
            List<User> TLs;
            tid = user.getTeamID();
            TL = db.getUser(tid.getAdmin());
            String TLName = TL.getFirstName() + " " + TL.getLastName();
            Roles = user.getRoleID();
            TLs = db.getTLs();
            List<ListItemUser> lius = new List<ListItemUser>();
            foreach (User u in TLs)
            {
                ListItemUser liu = new ListItemUser(u);
                lius.Add(liu);
            }
            cmbTextBox.DataSource = null;
            cmbTextBox.DataSource = lius;
            cmbTextBox.DisplayMember = "name";
            cmbTextBox.ValueMember = "uid";
            int index = cmbTextBox.FindString(TL.getFirstName() + " " + TL.getLastName());
            cmbTextBox.SelectedIndex = index;
            txtUserName.Text = Username;
            txtPassword.Text = Password;
            txtFirstName.Text = FirstName;
            txtLastName.Text = LastName;
            txtEmail.Text = Email;
            if (GraderNumber < 0)
            {
                txtGrader.Text = "";
            }
            else
            {
                txtGrader.Text = GraderNumber.ToString();
            }
            //txtTL.Text = TLName;
            List<ListItemRole> lirs = new List<ListItemRole>();
            foreach (Role r in Roles)
            {
                ListItemRole lir = new ListItemRole(r);
                lirs.Add(lir);
            }
            lstRoles.DataSource = null;
            lstRoles.DataSource = lirs;
            lstRoles.DisplayMember = "name";
            lstRoles.ValueMember = "roleID";

            List<Role> allroles = db.getRoles();
            List<ListItemRole> available = new List<ListItemRole>();
            foreach (Role r1 in allroles)
            {
                int r1id = r1.getRoleID();
                bool found = false;
                foreach (Role r in Roles)
                {
                    int rid = r.getRoleID();
                    if (r1id == rid)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    ListItemRole av = new ListItemRole(r1);
                    available.Add(av);
                }
            }
            cmbRolesToAdd.DataSource = null;
            cmbRolesToAdd.DataSource = available;
            cmbRolesToAdd.DisplayMember = "name";
            cmbRolesToAdd.ValueMember = "roleID";
            cmbRolesToAdd.SelectedIndex = -1;
            if (cmbRolesToAdd.Items.Count > 0 && pid > 0)
            {
                btnAddRole.Enabled = true;
            }
            if (lstRoles.Items.Count > 0 && pid > 0)
            {
                btnRemoveRole.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminManagerForm.admin.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Person p1 = AdminManagerForm.p1;
            if (p1.getPersonID() == -1)
            {
                String Username = txtUserName.Text;
                String Password = txtPassword.Text;
                String FirstName = txtFirstName.Text;
                String LastName = txtLastName.Text;
                String Email = txtEmail.Text;
                int GraderNumber = Convert.ToInt16(txtGrader.Text);
                int TLid = Convert.ToInt32(cmbTextBox.SelectedValue);
                int pid = db.insertPerson(FirstName, LastName, Email, GraderNumber, 1);
                int uid = db.insertUser(Username, Password, pid);
                db.insertUserIntoTeam(TLid, uid);
                Person p = new Person(pid, FirstName, LastName, Email, 1, GraderNumber);
                AdminManagerForm.p1 = p;
            }
            else
            {
                int pid = p1.getPersonID();
                User u1 = db.getUserbyPerson(p1, pid);
                int userid = u1.getUserID();
                String Username = txtUserName.Text;
                String Password = txtPassword.Text;
                String FirstName = txtFirstName.Text;
                String LastName = txtLastName.Text;
                String Email = txtEmail.Text;
                int GraderNumber = Convert.ToInt16(txtGrader.Text);
                Team tid = u1.getTeamID();
                int TLid = Convert.ToInt32(cmbTextBox.SelectedValue);
                User TL = db.getUser(tid.getAdmin());
                /*
                List<int> roleids = new List<int>();
                int count = lstRoles.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    lstRoles.SelectedIndex = i;
                    int roleid = Convert.ToInt32(lstRoles.SelectedValue);
                    roleids.Add(roleid);
                }
                */
                db.updateUser(pid, userid, Username, Password, FirstName, LastName, Email, GraderNumber, TLid);
            }
            callOnLoad();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(cmbRolesToAdd.SelectedValue);
            if (roleid > 0)
            {
                db.addRoleToUser(roleid, user.getUserID());
                callOnLoad();
            }
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(lstRoles.SelectedValue);
            if (roleid > 0)
            {
                db.removeRoleFromUser(roleid, user.getUserID());
                callOnLoad();
            }
        }
    }

    public class ListItemUser
    {
        private User user;
        public int uid { get; set; }
        public string name { get; set; }

        public ListItemUser ()
        {
            user = new User();
            uid = user.getPersonID();
            name = user.getFirstName() + " " + user.getLastName();
        }

        public ListItemUser (User u)
        {
            user = u;
            uid = u.getPersonID();
            name = user.getFirstName() + " " + user.getLastName();
        }
    }
    public class ListItemRole
    {
        private Role role;
        public int roleID { get; set; }
        public string name { get; set; }

        public ListItemRole()
        {
            role = new Role();
            roleID = role.getRoleID();
            name = role.getName();
        }

        public ListItemRole(Role r)
        {
            role = r;
            roleID = role.getRoleID();
            name = role.getName();
        }
    }
}
