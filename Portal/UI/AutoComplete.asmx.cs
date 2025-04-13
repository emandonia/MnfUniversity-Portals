using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MnfUniversity_Portals.BLL.MIS_BLL;

namespace MnfUniversity_Portals.UI
{
    
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : WebService
    {
        public AutoComplete()
        {
        }
        [WebMethod]
        public string[] GetCompletionList(string prefixText)
        {
            return ResearchUtility.GetListofStaffMembers(prefixText).ToArray();
        }

        
    }
}
