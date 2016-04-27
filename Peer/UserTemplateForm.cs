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
    public partial class UserTemplateForm : Form
    {
        //here we should have instance variables that actually store the selected user and template information
        //again don't know what they are.
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\myhome.itap.purdue.edu\\puhome\\pu.data\\Desktop\\GitHub\\Peer\\Peerdb_fixed.accdb");
        private User currentUser = LoginForm.u1;
        private User selectedUser;
        private Template selectedTemplate;

        public UserTemplateForm()
        {
            InitializeComponent();
            callOnLoad();
        }

        private void usersListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //should refresh available templates list based on which user was picked.
            //no idea what the templates even are.
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //start the form for selected user
            int uid = (int)lstUsers.SelectedValue;
            int tid = (int)lstTemplate.SelectedValue;
            selectedUser = db.getUser(uid);
            selectedTemplate = db.getTemplate(tid);

            Hide();

            UserReviewForm form = new UserReviewForm(selectedUser, selectedTemplate);
            form.Show();
        }

        private void UserTemplateForm_Load(object sender, EventArgs e)
        {
            callOnLoad();
        }

        public void callOnLoad()
        {
            List<User> people = db.getAllUsers();
            List<ListItemUser> users = new List<ListItemUser>();
            foreach (User u in people)
            {
                ListItemUser uv = new ListItemUser(u);
                users.Add(uv);
            }
            lstUsers.DataSource = null;
            lstUsers.DataSource = users;
            lstUsers.DisplayMember = "name";
            lstUsers.ValueMember = "uid";
            lstUsers.SelectedIndex = -1;

            List<Template> templates = db.getTemplates();
            List<ListItemTemplate> templists = new List<ListItemTemplate>();

            foreach (Template t in templates)
            {
                ListItemTemplate tv = new ListItemTemplate(t);
                templists.Add(tv);
            }
            lstTemplate.DataSource = null;
            lstTemplate.DataSource = templists;
            lstTemplate.DisplayMember = "name";
            lstTemplate.ValueMember = "tid";
            lstTemplate.SelectedIndex = -1;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            callOnLoad();
        }
    }
}
