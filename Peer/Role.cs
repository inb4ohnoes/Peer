using System;

public class Role
{
    private int mRoleID;
    private string mName;
    private string mDescription;

    public Role()
    {
        mRoleID = -1;
        mName = "";
        mDescription = "";
    }

    public Role(int roleID, string name, string description)
    {
        mRoleID = roleID;
        mName = name;
        mDescription = description;
    }

    public void setRoleID(int roleID)
    {
        mRoleID = roleID;
    }
    public int getRoleID()
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
