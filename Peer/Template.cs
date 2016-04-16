using System;

public class Template
{
    private string mTemplateID;
    private Role mRole = new Role();
    //Questions

    public Template()
    {

    }

    public Template(string templateID)
    {
        mTemplateID = templateID;
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

    public void setTemplateID(string templateID)
    {
        mTemplateID = templateID;
    }
    public string getTemplateID()
    {
        return mTemplateID;
    }
}
