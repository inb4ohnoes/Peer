using System;
using System.Collections;

public class MultipleChoice : Question
{
    int MCID;
    string Question;
    ArrayList answers;

    public MultipleChoice()
    {
        MCID = 0;
        Question = "";
        answers = new ArrayList();
    }

    public MultipleChoice(int mid, string quest, ArrayList ans)
    {
        MCID = mid;
        Question = quest;
        answers = ans;
    }
    public void setMCID(int mid)
    {
        MCID = mid;
    }
    public void setQuestion(string question)
    {
        Question = question;
    }

    public string getQuestion()
    {
        return Question;
    }

    public void setAnswers(ArrayList a1)
    {
        answers = a1;
    }

    public ArrayList getAnswers()
    {
        return answers;
    }

    public string getType()
    {
        return "";
    }
}
