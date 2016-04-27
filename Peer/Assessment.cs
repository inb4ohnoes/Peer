using System;
namespace Peer
{
    public class Assessment
    {

        private int mAssessmentID;
        private Template mTemplateID;
        private User mReviewee;
        private User mReviewer;

        public Assessment ()
        {
            mAssessmentID = -1;
            mTemplateID = new Template();
            mReviewee = new User();
            mReviewer = new User();
        }

        public Assessment (int aid, Template tid, User rve, User rvr)
        {
            mAssessmentID = aid;
            mTemplateID = tid;
            mReviewee = rve;
            mReviewer = rvr;
        }

        public void setAssessmentID(int assessmentID)
        {
            mAssessmentID = assessmentID;
        }
        public int getAssessmentID()
        {
            return mAssessmentID;
        }

        public void setTemplate(Template templ)
        {
            mTemplateID = templ;
        }
        public Template getTemplateID()
        {
            return mTemplateID;
        }

        public void setReviewee(User reviewee)
        {
            mReviewee = reviewee;
        }
        public User getReviewee()
        {
            return mReviewee;
        }

        public void setReviewer(User reviewer)
        {
            mReviewer = reviewer;
        }
        public User getReviewer()
        {
            return mReviewer;
        }
    }
}
