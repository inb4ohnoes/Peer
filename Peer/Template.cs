using System;

public class Template
{
    private string mTemplateName;
    private int mTemplateID;
    private int mTemplateCreator;
    private Role mRole = new Role();
    //Questions

    public Template()
    {
        mTemplateID = 0;
        mTemplateName = "";
        mTemplateCreator = 0;
    }

    public Template(int id, string name, int creator)
    {
        mTemplateName = name;
        mTemplateID = id;
        mTemplateCreator = creator;
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
    public void setName(string nm)
    {
        mTemplateName = nm;
    }
    public string getName()
    {
        return mRole.getName();
    }
    public string getDescription()
    {
        return mRole.getDescription();
    }

    public void setTemplateID(int templateID)
    {
        mTemplateID = templateID;
    }
    public int getTemplateID()
    {
        return mTemplateID;
    }
}
