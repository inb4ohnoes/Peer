using System;

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
