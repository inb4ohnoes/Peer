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
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //testing for now
            if (txtUsername.Text.Equals("user"))
            {
                //consider initializing with initial values
                UserTemplateForm template = new UserTemplateForm();
                template.Show();

                //hide this original one until user returns or logs out
                Hide();

            } else if (txtUsername.Text.Equals("admin"))
            {
                AdminManagerForm admin = new AdminManagerForm();
                admin.Show();

                Hide();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
        }

        public class Person
        {
            private string mFirstName;
            private string mLastName;
            private string mEmail;
            private string mStatus;
            private int mGraderNumber;

            public void setFirstName(string firstName)
            {
                mFirstName = firstName;
            }
            public string getFirstName()
            {
                return mFirstName;
            }

            public void setLastName(string lastName)
            {
                mLastName = lastName;
            }
            public string getLastName() 
            {
                return mLastName;
            }

            public void setEmail(string email)
            {
                mEmail = email;
            }
            public string getEmail()
            {
                return mEmail;
            }

            public void setStatus(string status)
            {
                mStatus = status;
            }
            public string getStatus()
            {
                return mStatus;
            }

            public void setGraderNumber(int graderNumber)
            {
                mGraderNumber = graderNumber;
            }
            public int getGraderNumber()
            {
                return mGraderNumber;
            }
        }

        public class User : Person
        {
            private string mUserID;
            private string mUserName;
            private string mPassword;
            //private Team mTeamID = new Team();
            //private Role mRoles = new Role();

            public void setUserID(string userID)
            {
                mUserID = userID;
            }
            public string getUserID()
            {
                return mUserID;
            }

            public void setUserName(string userName)
            {
                mUserName = userName;
            }
            public string getUserName()
            {
                return mUserName;
            }

            public void setPassword(string password)
            {
                mPassword = password;
            }
            public string getPassword()
            {
                return mPassword;
            }
        }

        public class Admin : User
        {

        }

        public class Team
        {
           
        }

        public class Role
        {
            private string mRoleID;
            private string mName;
            private string mDescription;


            public void setRoleID(string roleID)
            {
                mRoleID = roleID;
            }
            public string getRoleID()
            {
                return mRoleID;
            }

            public void setName(string name)
            {
                mName = name;
            }
            public string getName()
            {
                return mName;
            }

            public void setDescription(string description)
            {
                mDescription = description;
            }
            public string getDescription()
            {
                return mDescription;
            }

        }

        public class Template
        {
            private string mTemplateID;
            //Role
            //Questions

            public void setTemplateID(string templateID)
            {
                mTemplateID = templateID;
            }
            public string getTemplateID()
            {
                return mTemplateID;
            }
        }

        public class Assessment
        {
            private string mAssessmentID;
            //mTemplateID
            private string mReviewee;
            private string mReviewer;

            public void setAssessmentID(string assessmentID)
            {
                mAssessmentID = assessmentID;
            }
            public string getAssessmentID()
            {
                return mAssessmentID;
            }

            public void setReviewee(string reviewee)
            {
                mReviewee = reviewee;
            }
            public string getReviewee()
            {
                return mReviewee;
            }

            public void setReviewer(string reviewer)
            {
                mReviewer = reviewer;
            }
            public string getReviewer()
            {
                return mReviewer;
            }
        }

        public class MultipleChoice
        {

        }

        public class FreeResponse
        {

        }

        public interface Question
        {
            void setQuestion(string question);

            string getQuestion();

            void setAnswers();

            string getAnswers();

            string getType();
        }
    }
}
