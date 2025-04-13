using System;
using System.Web;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class VotingViewer : ViewersBase
    {
        protected static string Dir
        {
            get { return StaticUtilities.Dir; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            if (Prtl_OwnersUtility.checkOwnerVoting(s))
            {
                NoTranslation.Visible = true;
                Panel1.Visible = false;

            }
            else
            {
                NoTranslation.Visible = false;
                Panel1.Visible = true;
                ViewVote();
            }
        }

        protected void VotingButton_OnClick(object sender, EventArgs e)
        {
            HttpCookie httpCookie = Response.Cookies[URLBuilder.OwnerAbbr(Page.RouteData) + "VotingCookie"];
            if (httpCookie != null)
            {
                httpCookie.Values.Add("voted", "true");
                if (Page.User.Identity.Name != null)
                    httpCookie.Values.Add("UserId", Page.User.Identity.Name);
                httpCookie.Values.Add("OwnerID", StaticUtilities.OwnerID(Page).ToString());
                httpCookie.Values.Add("votedID", StaticUtilities.VoteID(Page).ToString());
                httpCookie.Expires = DateTime.Now.AddDays(7);
            }
            prtl_VotingTranslation query = Prtl_VotingTransUtility.GetVotTranByVIDAndLCID(StaticUtilities.VoteID(Page),
                                                                                          StaticUtilities.Currentlanguage(
                                                                                              Page));
            if (RadioButtonList1.SelectedValue == "1")
            {
                int x1 = query.prtl_Voting.Ans1Count;
                x1++;
                query.prtl_Voting.Ans1Count = x1;
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                int x2 = query.prtl_Voting.Ans2Count;
                x2++;
                query.prtl_Voting.Ans2Count = x2;
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                int x3 = query.prtl_Voting.Ans3Count;
                x3++;
                query.prtl_Voting.Ans3Count = x3;
            }
            showVotingResults(query);
        }

        private string GetQues()
        {
            prtl_VotingTranslation question = Prtl_VotingTransUtility.GetVotTranByVIDAndLCID(StaticUtilities.VoteID(Page),
                                                                                             StaticUtilities.Currentlanguage(Page));
            return (question == null) ? "Not_Translated" : question.Question;
        }

        private void showVotingResults(prtl_VotingTranslation query)
        {
            double x11, x22, x33;
            double total = query.prtl_Voting.Ans1Count + query.prtl_Voting.Ans2Count + query.prtl_Voting.Ans3Count;
            RadioButtonList1.Visible = false;
            VoteButton.Visible = false;
            ans1.Visible = true;
            ans1width.Visible = true;
            ans1perc.Visible = true;
            ans1.Text = query.Ans1;
            double width1 = query.prtl_Voting.Ans1Count;
            ans1width.Width = (int)width1;
            const double EPSILON = 0;
            if (Math.Abs(total - 0) < EPSILON)
                x11 = 0;
            else
                x11 = (width1 / total) * 100;
            ans1perc.Text = (int)x11 + @"%";
            ans2.Visible = true;
            ans2width.Visible = true;
            ans2perc.Visible = true;
            ans2.Text = query.Ans2;
            double width2 = query.prtl_Voting.Ans2Count;
            ans2width.Width = (int)width2;
            if (Math.Abs(total - 0) < EPSILON)
                x22 = 0;
            else
                x22 = (width2 / total) * 100;
            ans2perc.Text = (int)x22 + @"%";
            ans3.Visible = true;
            ans3width.Visible = true;
            ans3perc.Visible = true;
            ans3.Text = query.Ans3;
            double width3 = query.prtl_Voting.Ans3Count;
            ans3width.Width = (int)width3;
            if (Math.Abs(total - 0) < EPSILON)
                x33 = 0;
            else
                x33 = (width3 / total) * 100;
            ans3perc.Text = (int)x33 + @"%";
        }

        private void ViewVote()
        {
            prtl_VotingTranslation query = Prtl_VotingTransUtility.GetVotTranByVIDAndLCID(StaticUtilities.VoteID(Page),
                                                                                            StaticUtilities.Currentlanguage(
                                                                                                Page));
            string voted = "";
            string votedid = "";
            string voteownerid = "";
            string voteuserid = "";
            HttpCookie httpCookie = Request.Cookies[URLBuilder.OwnerAbbr(Page.RouteData) + "VotingCookie"];
            if (httpCookie != null)
            {
                voted = httpCookie.Values["voted"];
                if (Page.User.Identity.Name != null)
                {
                    voteuserid = httpCookie.Values["UserId"];
                }
                voteownerid = httpCookie.Values["OwnerID"];
                votedid = httpCookie.Values["votedID"];
            }
            if (voted != "true" || Page.User.Identity.Name != voteuserid || votedid != StaticUtilities.VoteID(Page).ToString() ||
                voteownerid != StaticUtilities.OwnerID(Page).ToString())
            {
                QuesLbl.Text = GetQues();
                if (query != null)
                {
                    RadioButtonList1.Items[0].Text = query.Ans1;
                    RadioButtonList1.Items[1].Text = query.Ans2;
                    RadioButtonList1.Items[2].Text = query.Ans3;
                }
            }
            else
            {
                showVotingResults(query);
            }
        }
    }
}