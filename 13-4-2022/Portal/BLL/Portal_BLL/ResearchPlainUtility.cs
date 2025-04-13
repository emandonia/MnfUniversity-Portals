using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Portal_DAL;

namespace BLL
{
    public class ResearchPlainUtility
    {


        //public static void InsertNewResearch(string s1, string se, int f, int st, int d, DateTime dd, string AddA,
        //                                     string AddE, string sum, string sume, Boolean r, string spa, string spe,
        //                                     int l, List<string> x,
        //                                     List<string> y, DateTime Dis,string c2)
        //{

        //    var dc = new PortalDataContextDataContext()
        //    {
        //        SUPERVISOR s = ((from xx in dc.SUPERVISORs orderby xx.SuperId descending select xx).First());
        //        for (int i = 0; i < y.Count; i++)
        //        {
        //            var sup = new SUPERVISOR
        //                {
        //                    SuperName = y[i],

        //                    SuperId = s.SuperId + 1,
        //                    SuperNameEng = "dfsdf"
        //                    //s.SuperId + 1
        //                };
        //            dc.SUPERVISORs.InsertOnSubmit(sup);
        //            dc.SubmitChanges();
        //        }




        //        ResearchPlan_SUPERVISOR sx =
        //            ((from xx in dc.ResearchPlan_SUPERVISORs orderby xx.SuperId descending select xx).First());
        //        for (int i = 0; i < x.Count; i++)
        //        {
        //            var ex = new ResearchPlan_SUPERVISOR
        //                {
        //                    SuperName = x[i],
        //                    SuperId = sx.SuperId + 1

        //                };
        //            dc.ResearchPlan_SUPERVISORs.InsertOnSubmit(ex);
        //            dc.SubmitChanges();
        //        }


        //        ResearchPlan_MainData rrr =
        //            ((from xx in dc.ResearchPlan_MainDatas orderby xx.PaperId descending select xx).First());

        //        var ResItem = new ResearchPlan_MainData
        //            {
        //                PaperId = rrr.PaperId + 1,
        //                StudentName = s1,
        //                StudentNameEng = se,
        //                Faculty = f,
        //                StudyTypee = st,
        //                Department = d,
        //                RegistrationDate  = dd,
        //                ArabicAddress = AddA,
        //                EngAddress = AddE,
        //                Summary = sum,
        //                SummaryEng = sume,
        //                ResearchType = r,
        //                SpecialisimAr = spa,
        //                SpecialisimEn = spe,
        //                Lang_Id = l,
        //                DisscusionDate = Dis,
        //                ResearchPlan=c2 
        //                //Examiners=ex.SuperId,
        //                //SuperVisors = sup.SuperId 
        //            };
        //        dc.ResearchPlan_MainDatas.InsertOnSubmit(ResItem);
        //        dc.SubmitChanges();

        //        Paper_Super p = ((from xx in dc.Paper_Supers orderby xx.Id descending select xx).FirstOrDefault());
        //        if (p == null)
        //        {
        //            var supx = new Paper_Super
        //                {
        //                    Id = 1,
        //                    PaperId = rrr.PaperId + 1,
        //                    SuperId = s.SuperId + 1
        //                };
        //            dc.Paper_Supers.InsertOnSubmit(supx);
        //            dc.SubmitChanges();
        //        }
        //        else
        //        {
        //            var supx = new Paper_Super
        //                {
        //                    Id = p.Id + 1,
        //                    PaperId = rrr.PaperId + 1,
        //                    SuperId = s.SuperId + 1
        //                };
        //            dc.Paper_Supers.InsertOnSubmit(supx);
        //            dc.SubmitChanges();
        //        }


        //        ResearchPlan_Paper_Super re =
        //            ((from xx in dc.ResearchPlan_Paper_Supers orderby xx.id descending select xx).First());

        //        var exx = new ResearchPlan_Paper_Super
        //            {
        //                id = re.id + 1,
        //                PaperId = rrr.PaperId + 1,
        //                SuperId = sx.SuperId + 1
        //            };

        //        dc.ResearchPlan_Paper_Supers.InsertOnSubmit(exx);
        //        dc.SubmitChanges();



        //    }
        //}
    }
}