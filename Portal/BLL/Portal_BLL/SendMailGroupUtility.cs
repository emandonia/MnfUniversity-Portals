using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using Portal_DAL;
namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class SendMailGroupUtility
    {
        public static Prtl_EduMail  getSendMail(int fac_id)
        {
            var dc = new PortalDataContextDataContext();
             var mail=  (from x in dc.Prtl_EduMails where x.Fac_ID == fac_id select x).SingleOrDefault();

            return mail ;
        }

        public static List < prtl_StaffGroupMail >   getSendTOMail (int fac_id,int dep)
        {

            var dc = new PortalDataContextDataContext();
            if (dep != -1)
            {
                var mail = (from x in dc.prtl_StaffGroupMails where x.Fac_ID == fac_id && x.Dep_ID == dep select x).ToList<prtl_StaffGroupMail>();
                return mail;
            }
            else
            {
                var mail = (from x in dc.prtl_StaffGroupMails where x.Fac_ID == fac_id  && x.Dep_ID == null  select x).ToList<prtl_StaffGroupMail>();
      return mail;
            }
            
        }
     


    }
}