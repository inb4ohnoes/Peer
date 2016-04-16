using System;

public class User : Peer.Person
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
