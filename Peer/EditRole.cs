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
    public partial class EditRole : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Logan\\Documents\\GitHub\\Peer\\Peerdb_fixed.accdb");

        private Role role;

        public EditRole()
        {
            InitializeComponent();
        }

        public void callOnLoad()
        {
            role = AdminManagerForm.r1;
            int roleid = role.getRoleID();
            String name = role.getName();
            String desc = role.getDescription();
            List<Role> currentRoles = db.getRoles();
            txtName.Text = name;
            txtDescription.Text = desc;
            List<ListItemRole> available = new List<ListItemRole>();
            foreach (Role r1 in currentRoles)
            {
                ListItemRole av = new ListItemRole(r1);
                available.Add(av);
            }
            lstRoles.DataSource = null;
            lstRoles.DataSource = available;
            lstRoles.DisplayMember = "name";
            lstRoles.ValueMember = "roleID";
            lstRoles.SelectedIndex = -1;
            if (roleid == -1)
            {
                btnSave.Text = "Add Role";
            }
            else
            {
                btnSave.Text = "Save";
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            AdminManagerForm.admin.Show();
            this.Hide();
            AdminManagerForm.admin.callOnLoad();
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            callOnLoad();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int roleid = role.getRoleID();
            String name = txtName.Text;
            String desc = txtDescription.Text;

            if (roleid == -1)
            {
                roleid = db.insertRole(name, desc);
            }
            else
            {
                db.updateRole(roleid, name, desc);
            }
            role.setRoleID(roleid);
            role.setName(name);
            role.setDescription(desc);
            callOnLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(lstRoles.SelectedValue);
            int index = Convert.ToInt32(lstRoles.SelectedIndex);
            if (index != -1)
            {
                db.deleteRole(roleid);
            }
            callOnLoad();
        }
    }
}
