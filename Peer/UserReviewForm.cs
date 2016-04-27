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
    public partial class UserReviewForm : Form
    {
        private clsDatabase db = new clsDatabase("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\myhome.itap.purdue.edu\\puhome\\pu.data\\Desktop\\GitHub\\Peer\\Peerdb_fixed.accdb");
        User selectedUser;
        Template selectedTemplate;
        List<MultipleChoice> listmc = new List<MultipleChoice>();
        List<FreeResponse> listfr = new List<FreeResponse>();
        List<int> qids = new List<int>();
        public UserReviewForm(User selectedUserin, Template selectedTemplateIn)
        {
            InitializeComponent();

            //No idea what else to do...
            selectedUser = selectedUserin;
            selectedTemplate = selectedTemplateIn;
            callOnLoad();            

        }

        private void UserReviewForm_Load(object sender, EventArgs e)
        {
            //callOnLoad();
        }

        public void callOnLoad()
        {
            int tid = selectedTemplate.getTemplateID();
            //List<MultipleChoice> listmc = new List<MultipleChoice>();
            //List<FreeResponse> listfr = new List<FreeResponse>();\
            txtName.Text = selectedTemplate.getName();
            qids = db.getQuestionsForTemplate(tid);
            int i;
            for (i = 0; i < qids.Count; i++) {
                int c = db.getMCFromQuestion(qids[i]);
                int r = db.getFRFromQuestion(qids[i]);
                MultipleChoice mc = db.getMC(c);
                FreeResponse fr = db.getFR(r);
                if (c > 0)
                {
                    listmc.Add(mc);
                }
                else
                {
                    listfr.Add(fr);
                }
            }
            i = 1;
            foreach (MultipleChoice m in listmc)
            {
                if (i == 1)
                {
                    txtQ1.Text = m.getQuestion();
                    int j = 0;
                    foreach (string s in m.getAnswers())
                    {
                        if (j == 0)
                        {
                            SA1.Text = (string)m.getAnswers()[j];
                            j++;
                        }
                        else if (j ==1)
                        {
                            A1.Text = s;
                            j++;
                        }
                        else if (j == 2)
                        {
                            N1.Text = s;
                            j++;
                        }
                        else if (j == 3)
                        {
                            D1.Text = s;
                            j++;
                        }
                        else
                        {
                            SD1.Text = s;
                            j++;
                        }
                    }
                    grp1.Visible = true;
                    i++;
                }

                else if (i == 2)
                {
                    txtQ2.Text = m.getQuestion();
                    int j = 0;
                    foreach (string s in m.getAnswers())
                    {
                        if (j == 0)
                        {
                            SA2.Text = s;
                            j++;
                        }
                        else if (j == 1)
                        {
                            A2.Text = s;
                            j++;
                        }
                        else if (j == 2)
                        {
                            N2.Text = s;
                            j++;
                        }
                        else if (j == 3)
                        {
                            D2.Text = s;
                            j++;
                        }
                        else
                        {
                            SD2.Text = s;
                            j++;
                        }
                    }
                    grp2.Visible = true;
                    i++;
                }

                else if (i == 3)
                {
                    txtQ3.Text = m.getQuestion();
                    int j = 0;
                    foreach (string s in m.getAnswers())
                    {
                        if (j == 0)
                        {
                            SA3.Text = s;
                            j++;
                        }
                        else if (j == 1)
                        {
                            A3.Text = s;
                            j++;
                        }
                        else if (j == 2)
                        {
                            N3.Text = s;
                            j++;
                        }
                        else if (j == 3)
                        {
                            D3.Text = s;
                            j++;
                        }
                        else
                        {
                            SD3.Text = s;
                            j++;
                        }
                    }
                    grp3.Visible = true;
                    i++;
                }

                else if (i == 4)
                {
                    txtQ4.Text = m.getQuestion();
                    int j = 0;
                    foreach (string s in m.getAnswers())
                    {
                        if (j == 0)
                        {
                            SA4.Text = s;
                            j++;
                        }
                        else if (j == 1)
                        {
                            A4.Text = s;
                            j++;
                        }
                        else if (j == 2)
                        {
                            N4.Text = s;
                            j++;
                        }
                        else if (j == 3)
                        {
                            D4.Text = s;
                            j++;
                        }
                        else
                        {
                            SD4.Text = s;
                            j++;
                        }
                    }
                    grp4.Visible = true;
                    i++;
                }
            }
            i = 0;
            foreach(FreeResponse f in listfr)
            {

                if (i == 0)
                {
                    txtQ5.Text = f.getQuestion();
                    grp5.Visible = true;
                    i++;

                }
                else
                {
                    txtQ6.Text = f.getQuestion();
                    grp6.Visible = true;
                    i++;
                }
            }

        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            Assessment a1 = new Assessment();
            User rvr = LoginForm.u1;
            User rve = selectedUser;
            a1.setTemplate(selectedTemplate);
            a1.setReviewer(rvr);
            a1.setReviewee(rve);
            int aid = db.insertAssessment(selectedTemplate.getTemplateID(), rvr.getUserID(), rve.getUserID());
            a1.setAssessmentID(aid);
            int i = 1;
            foreach(MultipleChoice m in listmc)
            {
                string answer = "";
                //int index = -1;
                if (i == 1)
                {                  
                    if (radSA1.Checked) {
                        answer = SA1.Text;
                    }
                    if (radA1.Checked)
                    {
                        answer = A1.Text;
                    }
                    if (radN1.Checked)
                    {
                        answer = N1.Text;
                    }
                    if (radD1.Checked)
                    {
                        answer = D1.Text;
                    }
                    if (radSD1.Checked)
                    {
                        answer = SD1.Text;
                    }
                    i++;
                }
                else if (i == 2)
                {
                    if (radSA2.Checked)
                    {
                        answer = SA2.Text;
                    }
                    if (radA2.Checked)
                    {
                        answer = A2.Text;
                    }
                    if (radN2.Checked)
                    {
                        answer = N2.Text;
                    }
                    if (radD2.Checked)
                    {
                        answer = D2.Text;
                    }
                    if (radSD2.Checked)
                    {
                        answer = SD2.Text;
                    }
                    i++;
                }
                else if (i == 3)
                {
                    if (radSA3.Checked)
                    {
                        answer = SA3.Text;
                    }
                    if (radA3.Checked)
                    {
                        answer = A3.Text;
                    }
                    if (radN3.Checked)
                    {
                        answer = N3.Text;
                    }
                    if (radD3.Checked)
                    {
                        answer = D3.Text;
                    }
                    if (radSD3.Checked)
                    {
                        answer = SD3.Text;
                    }
                    i++;
                }
                else if (i == 4)
                {
                    if (radSA4.Checked)
                    {
                        answer = SA4.Text;
                    }
                    if (radA4.Checked)
                    {
                        answer = A4.Text;
                    }
                    if (radN4.Checked)
                    {
                        answer = N4.Text;
                    }
                    if (radD4.Checked)
                    {
                        answer = D4.Text;
                    }
                    if (radSD4.Checked)
                    {
                        answer = SD4.Text;
                    }
                    i++;
                }
                int qid = db.getQuestionIDFromMC(m.getMCID());
                db.insertAssessmentAnswer(aid, qid, answer);
            }
            i = 0;
            foreach(FreeResponse f in listfr)
            {
                string answer = "";
                if (i == 0)
                {
                    answer = txtFRA1.Text;
                    i++;
                }
                else
                {
                    answer = txtFRA2.Text;
                    i++;
                }
                db.insertAssessmentAnswer(aid, db.getQuestionIDFromFR(f.getFRID()), answer);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserTemplateForm.f.Show();
            this.Hide();
        }
    }
}
