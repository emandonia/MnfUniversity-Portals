using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using App_Code;
using Microsoft.Reporting.WebForms;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;
namespace MnfUniversity_Portals.UI
{
    public partial class CourseReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CourseRep.rdlc");

            var dc = new PortalDataContextDataContext();
            List<Prtl_C_Student> x = new List<Prtl_C_Student>();
            if (DropDownList1.SelectedValue != "-1")
            {
                 x = (from c in dc.Prtl_C_Students where c.CourseID == Convert.ToInt32(DropDownList1.SelectedValue) select c).ToList();

            }
            else
            {
                x = (from c in dc.Prtl_C_Students  select c).ToList();

            }

           // var q = Prtl_ComplainUtility.GetNtReportsByFac(Convert.ToInt32((string)Page.RouteData.Values["id"]));
                ReportViewer1.LocalReport.DataSources.Clear();
            //DataSett s=new DataSett();
            //s.Tables.Add(q);
            var dss = new ReportDataSource("DSCourse", x);
            ReportViewer1.LocalReport.DataSources.Add(dss);
            ReportViewer1.DataBind();
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}