using App_Code;
using Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Reporting.WebForms;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class PrintComplain : PageBase
    {public static string WebConfigConnectionString
        {
            get
            {
                var webconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                return webconfig.ConnectionStrings.ConnectionStrings["MnfUniversityConnectionString"].ConnectionString;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

               
        
        var q = Prtl_ComplainUtility.GetCompByID((string)Page.RouteData.Values["id"]);
        MyReportViwer.LocalReport.DataSources.Clear();
        var dss = new ReportDataSource("DataSet1", q);
        MyReportViwer.LocalReport.DataSources.Add(dss);
        MyReportViwer.DataBind();
        MyReportViwer.ShowPrintButton = true;
        MyReportViwer.LocalReport.Refresh();
               
            }
            
        }
    }
}