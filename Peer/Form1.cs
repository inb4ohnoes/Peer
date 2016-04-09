﻿using System;
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
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
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
            private Team mTeamID = new Team();
            private Role mRole = new Role();

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

            public void setTeamID(string teamID)
            {
                mTeamID.setTeamID(teamID);
            }
            public string getTeamID()
            {
                return mTeamID.getTeamID();
            }

            public void setRole(string roleID, string name, string description)
            {
                mRole.setRoleID(roleID);
                mRole.setName(name);
                mRole.setDescription(description);
            }
            public string getRoleID()
            {
                return mRole.getRoleID();
            }
            public string getName()
            {
                return mRole.getName();
            }
            public string getDescription()
            {
                return mRole.getDescription();
            }

        }

        public class Admin : User
        {

        }

        public class Team
        {
            private string mTeamID;
            //leader
            //user
            private int mSize;

            public Team()
            {

            }

            public Team(string teamID)
            {
                mTeamID = teamID;
            }

            public void setTeamID(string teamID)
            {
                mTeamID = teamID;
            }
            public string getTeamID()
            {
                return mTeamID;
            }

            public void setSize(int size)
            {
                mSize = size;
            }
            public int getSize()
            {
                return mSize;
            }
        }

        public class Role
        {
            private string mRoleID;
            private string mName;
            private string mDescription;
            
            public Role()
            {

            }

            public Role(string roleID, string name, string description)
            {
                mRoleID = roleID;
                mName = name;
                mDescription = description;
            }
            
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

            public Template()
            {

            }

            public Template(string templateID)
            {
                mTemplateID = templateID;
            }

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
            private Template mTemplateID = new Template();
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

            public void setTemplateID(string templateID)
            {
                mTemplateID.setTemplateID(templateID);
            }
            public string getTemplateID()
            {
                return mTemplateID.getTemplateID();
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
            public void setQuestion(string question)
            {

            }
            public string getQuestion()
            {

            }

            public void setAnswers()
            {

            }
            public string getAnswers()
            {
                
            }

            public string getType()
            {
                
            }
        }
    }
}
