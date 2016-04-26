using System;

namespace Peer
{
    public class Person
    {
        public int mPersonID { get; set; }
        public string mFirstName;
        private string mLastName;
        private string mEmail;
        private int mStatus;
        private int mGraderNumber;
        public string FullName { get; set; }

        public Person ()
        {
            mPersonID = -1;
            mFirstName = "";
            mLastName = "";
            mEmail = "";
            mStatus = -1;
            mGraderNumber = -1;
        }
        public Person (int pid, String fn, String ln, String em, int st, int gn)
        {
            mPersonID = pid;
            mFirstName = fn;
            mLastName = ln;
            mEmail = em;
            mStatus = st;
            mGraderNumber = gn;
            FullName = fn + " " + ln;
        }

        public void setPersonID(int pid)
        {
            mPersonID = pid;
        }

        public int getPersonID()
        {
            return mPersonID;
        }

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

        public void setStatus(int status)
        {
            mStatus = status;
        }
        public int getStatus()
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
        public override string ToString()
        {
            return mFirstName + " " + mLastName;
        }
    }
}

