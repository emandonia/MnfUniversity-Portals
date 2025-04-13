using System;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_VotingUtility
    {
        public static prtl_Owner GetcurrentVoting(Guid? Owner_ID)
        {
            return new PortalDataContextDataContext().prtl_Owners.Single(x => x.Owner_ID == Owner_ID);
        }

        //    }
        //}
        public static prtl_Voting GetVotingByID(int parse)
        {
            return new PortalDataContextDataContext().prtl_Votings.Single(x => x.VotingID == parse);
        }

        public static void InsertNewVote(prtl_Voting newVoting)
        {
            var dc = new PortalDataContextDataContext();
            {
                dc.prtl_Votings.InsertOnSubmit(newVoting);
                dc.SubmitChanges();
            }
        }

      
        //public static prtl_Voting getvoting(int VoteId,Guid? Owner_ID)
        //{
        //    return new PortalDataContextDataContext().prtl_Votings.Single(x => x.VotingID == VoteId && x.Owner_ID == Owner_ID);
        //}
        //public static void setCurrentVotingID(object id,Guid? Owner_ID)
        //{
        //  var dc=new PortalDataContextDataContext()
        //    {
        //        var owner = dc.prtl_Owners.Single(a => a.Owner_ID == Owner_ID);
        //        owner.CurrentVotingID =Convert.ToInt32(id) ;
        //        dc.SubmitChanges();
    }
}