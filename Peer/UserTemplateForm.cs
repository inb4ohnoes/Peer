using System;
using System.Windows.Forms;


namespace Peer
{
    public partial class UserTemplateForm : Form
    {
        //here we should have instance variables that actually store the selected user and template information
        //again don't know what they are.

        private Person selectedPerson;
        private Template selectedTemplate;

        public UserTemplateForm()
        {
            InitializeComponent();
        }

        private void usersListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //should refresh available templates list based on which user was picked.
            //no idea what the templates even are.
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //start the form for selected user

            Hide();

            UserReviewForm form = new UserReviewForm(selectedPerson, selectedTemplate);
            form.Show();
        }
    }
}
