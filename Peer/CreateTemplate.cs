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
    public partial class CreateTemplate : Form
    {
        public CreateTemplate()
        {
            InitializeComponent();
        }

        int i = 1;
        int j = 1;
        Template template1 = new Template();

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {

            if (i == 1)
            {
                grp1.Visible = true;
                i++;
                return;
            }

            if (i == 2)
            {
                grp2.Visible = true;
                i++;
                return;
            }

            if (i == 3)
            {
                grp3.Visible = true;
                i++;
                return;
            }

            if (i == 4)
            {
                grp4.Visible = true;
                i++;
                return;
            }
        }

        private void btnFreeResponse_Click(object sender, EventArgs e)
        {
            if (j == 1)
            {
                grp5.Visible = true;
                j++;
                return;
            }

            if (j == 2)
            {
                grp6.Visible = true;
                j++;
                return;
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            template1.setName(name);
            //Get Admin?

            int counter;
            int counter2;

            for (counter = 0; counter < i; counter++)
            {
                MultipleChoice q = new MultipleChoice();
                //Get MCID from DB
                int mcid;
                q.set
                string question;
                if (counter == 1)
                {
                    question = txtQ1.Text;
                }
                if (counter == 2)
                {
                    question = txtQ2.Text;
                }
                if (counter == 3)
                {
                    question = txtQ3.Text;
                }
                if (counter == 4)
                {
                    question = txtQ4.Text;
                }
                for (counter2 = 0; counter2 < 5; counter2++)
                {
                    MCAnswer m = new MCAnswer();

                }

            }
        }
    }
}
