using System;

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