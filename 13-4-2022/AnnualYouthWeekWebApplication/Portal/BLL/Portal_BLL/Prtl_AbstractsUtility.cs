using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class Prtl_AbstractsUtility
    {


        public static void UpdateStaffAbstractFiles(decimal memberid,string AbstractFile)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr == memberid.ToString());
            if (query != null)
            {
                query.AbstractFile = AbstractFile;
                dc.SubmitChanges();
            }else
            {
                
            }
        }

       

        public static void UpdateStaffCVFiles(decimal memberid, string CVFile)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr == memberid.ToString());
            if (query != null)
            {
                query.CVFile = CVFile;
                dc.SubmitChanges();
            }
            else
            {

            }
        }

        public static string getFile(decimal memberid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr == memberid.ToString());
            if(query !=null)
            {
                return query.AbstractFile;
            }else
            {
                return "";
            }
        }

        public static string getFileCV(decimal memberid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x =>x.Type ==3 && x.InitAbbr == memberid.ToString());
            if (query != null)
            {
                return query.CVFile ;
            }
            else
            {
                return "";
            }
        }
        public static void deleteFile(decimal memberid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr == memberid.ToString());
            if (query != null)
            {
                query.AbstractFile = null;
                dc.SubmitChanges();
            }
        }

        



        public static void deleteFileCV(decimal memberid)
        {
            var dc = new Portal_DAL.PortalDataContextDataContext();
            var query = dc.prtl_Owners.SingleOrDefault(x => x.InitAbbr == memberid.ToString());
            if (query != null)
            {
                query.CVFile  = null;
                dc.SubmitChanges();
            }
        }
    }
}