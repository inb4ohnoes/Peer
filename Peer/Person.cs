using System;

namespace Peer
{
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
}

