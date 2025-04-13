using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using Microsoft.Reporting.WebForms;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UI.Admin
{
    public partial class FacNetReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/FacNtReport.rdlc");
                var q = Prtl_ComplainUtility.GetNtReportsByFac(Convert.ToInt32((string)Page.RouteData.Values["id"]));
                ReportViewer1.LocalReport.DataSources.Clear();
                //DataSett s=new DataSett();
                //s.Tables.Add(q);
                var dss = new ReportDataSource("DataSett", q);
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();
            }
        }

       
    }
}