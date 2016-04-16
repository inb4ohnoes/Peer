using System;

public class Assessment
{

    private string mAssessmentID;
    private Template mTemplateID = new Template();
    private string mReviewee;
    private string mReviewer;

    public void setAssessmentID(string assessmentID)
    {
        mAssessmentID = assessmentID;
    }
    public string getAssessmentID()
    {
        return mAssessmentID;
    }

    public void setTemplateID(string templateID)
    {
        mTemplateID.setTemplateID(templateID);
    }
    public string getTemplateID()
    {
        return mTemplateID.getTemplateID();
    }

    public void setReviewee(string reviewee)
    {
        mReviewee = reviewee;
    }
    public string getReviewee()
    {
        return mReviewee;
    }

    public void setReviewer(string reviewer)
    {
        mReviewer = reviewer;
    }
    public string getReviewer()
    {
        return mReviewer;
    }
}
