using System;

namespace Peer
{
    public class Template
    {
        private string mTemplateName;
        private int mTemplateID;
        private User mTemplateCreator;
        private Role mRole = new Role();
        //Questions

        public Template()
        {
            mTemplateID = 0;
            mTemplateName = "";
            mTemplateCreator = new User();
        }

        public Template(int id, string name, User creator)
        {
            mTemplateName = name;
            mTemplateID = id;
            mTemplateCreator = creator;
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

        public void setCreator(User u)
        {
            mTemplateCreator = u;
        }
        public User getCreator()
        {
            return mTemplateCreator;
        }
    }
}