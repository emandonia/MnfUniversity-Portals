using Mis_DAL;
using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_ResearchFieldsUtillity
    {
        public static List<SA_STF_MEMBER> getMemberByResearchField(string resField)
        {
            var dc = new PortalDataContextDataContext();

            List<prtl_Res_Field> x = (from xx in dc.prtl_Res_Fields where xx.Res_Fields.Contains(resField) select xx).ToList();

           
            
            var dc1 = new MisDataContext();
            List<SA_STF_MEMBER> staff = new List<SA_STF_MEMBER>();
            foreach (var c in x )
            {

                SA_STF_MEMBER cc = dc1.SA_STF_MEMBERs.SingleOrDefault(i => i.SA_STF_MEMBER_ID == c.Stf_ID);

                if (cc != null)
                {
                    staff.Add(cc);
                }
            }

            return staff;
        }


        public static List<SA_STF_MEMBER> getMemberByResearchFieldAndFac(string resField,int facID)
        {
            var dc = new PortalDataContextDataContext();

            List<prtl_Res_Field> x = (from xx in dc.prtl_Res_Fields where xx.Res_Fields.Contains(resField) && xx.Fac_ID ==facID  select xx).ToList();



            var dc1 = new MisDataContext();
            List<SA_STF_MEMBER> staff = new List<SA_STF_MEMBER>();
            foreach (var c in x)
            {
              SA_STF_MEMBER cc=  dc1.SA_STF_MEMBERs.SingleOrDefault(i => i.SA_STF_MEMBER_ID == c.Stf_ID  );

              if (cc != null)
              {
                  staff.Add(cc);
              }
            }

            return staff;
        }

        public static List<SA_STF_MEMBER> getMemberByResearchFieldAnddep(string resField, int depID)
        {
            var dc = new PortalDataContextDataContext();

            List<prtl_Res_Field> x = (from xx in dc.prtl_Res_Fields where xx.Res_Fields.Contains(resField) && xx.Dep_ID  == depID  select xx).ToList();



            var dc1 = new MisDataContext();
            List<SA_STF_MEMBER> staff = new List<SA_STF_MEMBER>();
            foreach (var c in x)
            {
                SA_STF_MEMBER cc = dc1.SA_STF_MEMBERs.SingleOrDefault(i => i.SA_STF_MEMBER_ID == c.Stf_ID);

                if (cc != null)
                {
                    staff.Add(cc);
                }
            }

            return staff;
        }



        public static List<SA_STF_MEMBER> getMemberByResearchFieldFacDep(string resField, int facID,int depID)
        {
            var dc = new PortalDataContextDataContext();

            List<prtl_Res_Field> x = (from xx in dc.prtl_Res_Fields where xx.Res_Fields.Contains(resField)  && xx.Fac_ID ==facID && xx.Dep_ID ==depID   select xx).ToList();



            var dc1 = new MisDataContext();
            List<SA_STF_MEMBER> staff = new List<SA_STF_MEMBER>();
            foreach (var c in x)
            {

                SA_STF_MEMBER cc = dc1.SA_STF_MEMBERs.SingleOrDefault(i => i.SA_STF_MEMBER_ID == c.Stf_ID  );

                if (cc != null)
                {
                    staff.Add(cc);
                }
            }

            return staff;
        }


    }
}