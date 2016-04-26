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
    public partial class EditTeam : Form
    {
        public EditTeam()
        {
            InitializeComponent();
        }

        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Logan\\Documents\\GitHub\\Peer\\Peerdb_fixed.accdb");

        public void callOnLoad()
        {
            List<User> currentAdmins = db.getAdmins();
            List<User> currentTLs = db.getTLs();
            List<ListItemUser> listTLs = new List<ListItemUser>();
            List<ListItemUser> available = new List<ListItemUser>();
            foreach (User u1 in currentAdmins)
            {
                bool found = false;
                foreach (User u2 in currentTLs)
                {
                    if (u2.getUserID() == u1.getUserID())
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    ListItemUser av = new ListItemUser(u1);
                    available.Add(av);
                }
            }
            foreach (User u1 in currentTLs)
            {
                ListItemUser av = new ListItemUser(u1);
                listTLs.Add(av);
            }
            cmbAvaliableAdmin.DataSource = null;
            cmbAvaliableAdmin.DataSource = available;
            cmbAvaliableAdmin.DisplayMember = "name";
            cmbAvaliableAdmin.ValueMember = "uid";
            cmbAvaliableAdmin.SelectedIndex = -1;
            lstTeam.DataSource = null;
            lstTeam.DataSource = listTLs;
            lstTeam.DisplayMember = "name";
            lstTeam.ValueMember = "uid";
            lstTeam.SelectedIndex = -1;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            AdminManagerForm.admin.Show();
            this.Hide();
            AdminManagerForm.admin.callOnLoad();
        }

        private void EditTeam_Load(object sender, EventArgs e)
        {
            callOnLoad();
        }

        public class ListItemUser
        {
            private User user;
            public int uid { get; set; }
            public string name { get; set; }

            public ListItemUser()
            {
                user = new User();
                uid = user.getPersonID();
                name = user.getFirstName() + " " + user.getLastName();
            }

            public ListItemUser(User u)
            {
                user = u;
                uid = u.getPersonID();
                name = user.getFirstName() + " " + user.getLastName();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int adminIndex = cmbAvaliableAdmin.SelectedIndex;
            int adminID = Convert.ToInt32(cmbAvaliableAdmin.SelectedValue);
            if (adminIndex != -1)
            {
                db.insertTeam(adminID);
                callOnLoad();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int tlid = Convert.ToInt32(lstTeam.SelectedValue);
            int tlIndex = Convert.ToInt32(lstTeam.SelectedIndex);
            if (tlIndex != -1)
            {
                db.deleteTeam(tlid);
            }
            callOnLoad();
        }

        private void btnGoBack_Click_1(object sender, EventArgs e)
        {
            AdminManagerForm.admin.Show();
            this.Hide();
            AdminManagerForm.admin.callOnLoad();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int adminIndex = cmbAvaliableAdmin.SelectedIndex;
            int adminID = Convert.ToInt32(cmbAvaliableAdmin.SelectedValue);
            if (adminIndex != -1)
            {
                db.insertTeam(adminID);
                callOnLoad();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int tlid = Convert.ToInt32(lstTeam.SelectedValue);
            int tlIndex = Convert.ToInt32(lstTeam.SelectedIndex);
            if (tlIndex != -1)
            {
                db.deleteTeam(tlid);
            }
            callOnLoad();
        }

        private void EditTeam_Load_1(object sender, EventArgs e)
        {
            callOnLoad();
        }
    }
}

