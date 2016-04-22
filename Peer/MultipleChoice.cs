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
        numResponses = resp;
        answers = ans;
    }
    void setMCID(int mid)
    {
        MCID = mid;
    }
    void setQuestion(string question)
    {
        Question = question;
    }

    string getQuestion()
    {
        return Question;
    }

    void setAnswers(ArrayList a1)
    {
        answers = a1;
    }

    ArrayList getAnswers()
    {
        return answers;
    }

    string getType()
    {
        return "";
    }
}
