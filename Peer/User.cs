using System;
using System.Collections.Generic;

namespace Peer
{
    public class User : Person
    {
        private int mUserID;
        private string mUserName;
        private string mPassword;
        private Team mTeamID;
        private List<Role> mRole;

        public User()
        {
            mUserID = -1;
            mUserName = "";
            mPassword = "";
            mTeamID = new Team();
            mRole = new List<Role>();
        }

        public User(int uid, string un, string ps, Team tm, List<Role> ro, int pid, String fn, String ln, String em, int st, int gn) :base(pid, fn, ln, em, st, gn)
        {
            mUserID = uid;
            mUserName = un;
            mPassword = ps;
            mTeamID = tm;
            mRole = ro;
        }

        public void setUserID(int userID)
        {
            mUserID = userID;
        }
        public int getUserID()
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

        public void setTeamID(Team teamID)
        {
            mTeamID = teamID;
        }
        public Team getTeamID()
        {
            return mTeamID;
        }

        public void setRole(List<Role> roleID)
        {
            mRole = roleID;
        }
        public List<Role> getRoleID()
        {
            return mRole;
        }
        public void addRole(Role roleID)
        {
            mRole.Add(roleID);
        }
        public void removeRole(Role roleID)
        {
            mRole.Remove(roleID);
        }
    }
}
