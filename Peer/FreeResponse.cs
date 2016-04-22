using System;

public class FreeResponse
{
    int FRID;
    string Question;
    string answer;

    public FreeResponse()
    {
        FRID = 0;
        Question = "";
        answer = "";
    }

    public FreeResponse(int fid, string quest, string ans)
    {
        FRID = fid;
        Question = quest;
        answer = ans;
    }
    public void setFRID(int mid)
    {
        FRID = mid;
    }
    public void setQuestion(string question)
    {
        Question = question;
    }

    public string getQuestion()
    {
        return Question;
    }

    public void setAnswers(String a1)
    {
        answer = a1;
    }

    public string getAnswers()
    {
        return answer;
    }

    public string getType()
    {
        return "";
    }
}
