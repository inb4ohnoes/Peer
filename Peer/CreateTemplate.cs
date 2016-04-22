﻿using System;
using System.Collections;
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
                string question = "";
                if (counter == 0)
                {
                    question = txtQ1.Text;
                }
                if (counter == 1)
                {
                    question = txtQ2.Text;
                }
                if (counter == 2)
                {
                    question = txtQ3.Text;
                }
                if (counter == 3)
                {
                    question = txtQ4.Text;
                }
                q.setQuestion(question);
                ArrayList list = new ArrayList();
                //Submit MCQuestion
                //Get MCID from DB
                int mcid;
                q.setMCID(mcid);
                for (counter2 = 0; counter2 < 5; counter2++)
                {
                    MCAnswer m = new MCAnswer();
                    string response = "";
                    if (counter2 == 0)
                    {
                        response = "Strongly Agree";
                    }
                    if (counter2 == 1)
                    {
                        response = "Agree";
                    }
                    if (counter2 == 2)
                    {
                        response = "Neutral";
                    }
                    if (counter2 == 3)
                    {
                        response = "Disagree";
                    }
                    if (counter2 == 4)
                    {
                        response = "Strongly Disagree";
                    }
                    m.setAnswer(response);
                    m.setMCID(mcid);
                    //Submit MCAnswer to DB
                    //Get MCAnswerID
                    int MCAnswerID;
                    m.setMCAnswerID(MCAnswerID);
                    list.Add(m);
                }
                q.setAnswers(list);
            }
            for (counter = 0; counter < j; counter++)
            {
                FreeResponse q = new FreeResponse();
                string question = "";
                string answer = "";
                if (counter == 0)
                {
                    question = txtQ5.Text;
                    answer = txtFRA1.Text;
                }
                if (counter == 1)
                {
                    question = txtQ6.Text;
                    answer = txtFRA2.Text;
                }
                q.setQuestion(question);
                q.setAnswers(answer);
                //Submit MCQuestion
                //Get MCID from DB
                int frid;
                q.setFRID(frid);
            }
        }
    }
}
