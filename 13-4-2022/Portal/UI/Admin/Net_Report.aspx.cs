using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using CrystalDecisions.Web;
using Microsoft.Reporting.WebForms;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UI
{
    public partial class Net_Report : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void SearchButtonClicked(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            var linkbutton = (LinkButton)sender;
            LinqDataSource2.Where = "ID==" + linkbutton.CommandArgument;
            Editor_ModalPopupExtender.Show();
        }
        protected void Editor_ImageButton_Click2(object sender, EventArgs e)
        {
            var linkbutton = (LinkButton)sender;
           // ReportViewer ReportViewer1 = (ReportViewer)
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/NtReport.rdlc");
            var q = Prtl_ComplainUtility.GetNtReportByID(Convert.ToInt32(linkbutton.CommandArgument));
            ReportViewer1.LocalReport.DataSources.Clear();
            var dss = new ReportDataSource("DataSett", q);
            ReportViewer1.LocalReport.DataSources.Add(dss);
            ReportViewer1.DataBind();
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            //LinqDataSource2.Where = "ID==" + linkbutton.CommandArgument;
            ModalPopupExtender1.Show();
        }

        protected string GetFacName(object eval)
        {
           return Prtl_ComplainUtility.getFac(Convert.ToInt32(eval));
        }


        

       

        

        protected void FacDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            MoreHyperLink1.Visible = true;
            MoreHyperLink1.NavigateUrl = "http://" + Request.Url.Authority + "/uni_is/FacNetReport/" + FacDropDownList.SelectedValue + "/" +
                                                StaticUtilities.Currentlanguage(Page);
        }
    }
}