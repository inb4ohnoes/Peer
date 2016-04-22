using System;

public class MCAnswer
{
    int mcid;
    int mcAnswerID;
    string answer;

    public MCAnswer()
    {
        mcid = 0;
        mcAnswerID = 0;
        answer = "";
    }
    public MCAnswer(int mid, int mcaid, string ans)
    {
        mcid = mid;
        mcAnswerID = mcaid;
        answer = ans;
    }
    public void setMCID(int mid)
    {
        mcid = mid;
    }
    public void setMCAnswerID(int mcaid)
    {
        mcAnswerID = mcaid;
    }
    public void setAnswer(string ans)
    {
        answer = ans;
    }
    public int getMCID()
    {
        return mcid;
    }
    public int getMCAnswerID()
    {
        return mcAnswerID;
    }
    public string getAnswer()
    {
        return answer;
    }
}
