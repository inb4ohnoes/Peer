using System;

public class Team
{
    private int mTeamID;
    private int mTeamLeader;
    //user
    //private int mSize;

    public Team()
    {
        mTeamID = -1;
        mTeamLeader = -1;
    }

    public Team(int tid, int aid)
    {
        mTeamID = tid;
        mTeamLeader = aid;

    }

    public void setTeamID(int teamID)
    {
        mTeamID = teamID;
    }
    public int getTeamID()
    {
        return mTeamID;
    }
    public void setAdmin(int aid)
    {
        mTeamLeader = aid;
    }
    public int getAdmin()
    {
        return mTeamLeader;
    }
}