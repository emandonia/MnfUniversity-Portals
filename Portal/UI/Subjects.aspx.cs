using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using App_Code;
using Microsoft.Reporting.WebForms;
using MisBLL;

using Mis_DAL;
using BLL;
using Common;
using ReportParameter = Microsoft.Reporting.WebForms.ReportParameter;

namespace MnfUniversity_Portals.UI
{
    public partial class Subjects : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyReportViwer.LocalReport.DataSources.Clear();
                MyReportViwer.LocalReport.DataSources.Add( new ReportDataSource("Ds1"));
                MyReportViwer.DataBind();

                MyReportViwer.LocalReport.Refresh();
                string FacAbbr = URLBuilder.CurrentFacAbbr(RouteData);
                
                if (FacAbbr == null)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add(new ListItem((string)GetLocalResourceObject("Fac.Text"), "0"));
                }
                else
                {
                    decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                    DropDownList1.SelectedValue = id.ToString();
                    DropDownList1.DataBind();
                    DropDownList1.Enabled = false;
                    DropDownList2.Items.Clear();

                    DropDownList2.Items.Add(new ListItem((string)GetLocalResourceObject("Deg.Text")));
                    DropDownList2.DataSource = SubjectUtility.GET_ScentificDeg(decimal.Parse(DropDownList1.SelectedValue));
                    DropDownList2.DataTextField = "key";
                    DropDownList2.DataValueField = "Value";
                    DropDownList2.DataBind();
                }
                //if(DepAbbr ==null)
                //{
                //    DropDownList4.Items.Clear();
                //    DropDownList4.Items.Add(new ListItem((string)GetLocalResourceObject("Dep.Text"), "0"));
                //}else
                //{
                //    DropDownList4.DataSource = SubjectUtility.GET_Dept(decimal.Parse(DropDownList1.SelectedValue));
                //    DropDownList4.DataTextField = "NODE_DESCR_AR";
                //    DropDownList4.DataValueField = "AS_NODE_ID";
                //    DropDownList4.DataBind();
                //    decimal DepId = Prtl_OwnersUtility.getDepIDByAbbr(DepAbbr);
                //    DropDownList4.SelectedValue = DepId.ToString();
                //    DropDownList4.DataBind();
                //    DropDownList4.Enabled = false;

                //    DropDownList5.Items.Clear();
                //    DropDownList5.Items.Add(new ListItem((string)GetLocalResourceObject("Sem.Text"), "0"));
                //    DropDownList5.DataSource = SubjectUtility.GET_Sem(decimal.Parse(DropDownList3.SelectedValue));
                //    DropDownList5.DataTextField = "NODE_DESCR_AR";
                //    DropDownList5.DataValueField = "ED_PHASE_NODE_ID";
                //    DropDownList5.DataBind();
                    
                //}

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
           
            DropDownList2.Items.Add(new ListItem((string)GetLocalResourceObject("Deg.Text")));
            DropDownList2.DataSource = SubjectUtility.GET_ScentificDeg(decimal.Parse(DropDownList1.SelectedValue));
            DropDownList2.DataTextField = "key";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem((string)GetLocalResourceObject("Year.Text"), "0"));
            DropDownList3.DataSource = SubjectUtility.GET_Year(decimal.Parse(DropDownList2.SelectedValue));
            DropDownList3.DataTextField = "NODE_DESCR_AR";
            DropDownList3.DataValueField = "ED_PHASE_NODE_ID";
            DropDownList3.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add(new ListItem((string)GetLocalResourceObject("Dep.Text"), "0"));
            DropDownList4.DataSource = SubjectUtility.GET_Dept(decimal.Parse(DropDownList1.SelectedValue));
            DropDownList4.DataTextField = "NODE_DESCR_AR";
            DropDownList4.DataValueField = "AS_NODE_ID";
            DropDownList4.DataBind();
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add(new ListItem((string)GetLocalResourceObject("Sem.Text"), "0"));
            DropDownList5.DataSource = SubjectUtility.GET_Sem(decimal.Parse(DropDownList3.SelectedValue));
            DropDownList5.DataTextField = "NODE_DESCR_AR";
            DropDownList5.DataValueField = "ED_PHASE_NODE_ID";
            DropDownList5.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var dc = new List<SubjectsResult>();
            if (DropDownList4.SelectedValue != "0")
                dc = SubjectUtility.getSubjects(Convert.ToDecimal(DropDownList1.SelectedValue),
                                                Convert.ToDecimal(DropDownList5.SelectedValue),
                                                Convert.ToDecimal(DropDownList4.SelectedValue));
            else if (DropDownList4.SelectedValue == "0")
                dc = SubjectUtility.getSubjects(Convert.ToDecimal(DropDownList1.SelectedValue),
                                                Convert.ToDecimal(DropDownList5.SelectedValue));

            var ds = new ReportDataSource("Ds1", dc);

            // MyReportViwer.Visible = true;
            MyReportViwer.ShowZoomControl = true;
            MyReportViwer.ProcessingMode = ProcessingMode.Local;
            MyReportViwer.LocalReport.DataSources.Clear();
            MyReportViwer.LocalReport.DataSources.Add(ds);

            var FacNam = new ReportParameter("FacNam", DropDownList1.SelectedItem.Text);
            MyReportViwer.LocalReport.SetParameters(FacNam);
            var UniNam = new ReportParameter("UniNam", "جامعة المنوفية");
            MyReportViwer.LocalReport.SetParameters(UniNam);
            var Lang = new ReportParameter("Lang", CurrentLanguage);
            MyReportViwer.LocalReport.SetParameters(Lang);

            string s1 = DropDownList2.SelectedItem.Text.Substring(DropDownList2.SelectedItem.Text.IndexOf('-')).Trim('-');
            string uniabbr = "http://" + Request.Url.Authority;
          

            var UniAbbr = new ReportParameter("UniAbbr", uniabbr);
            MyReportViwer.LocalReport.SetParameters(UniAbbr);
            var FacAbbr = new ReportParameter("FacAbbr", Prtl_OwnersUtility.getFacAbbrByID(Convert.ToInt32(DropDownList1.SelectedValue)));
            MyReportViwer.LocalReport.SetParameters(FacAbbr);
            var Bylaw = new ReportParameter("p_ed_bylaw", s1);
            MyReportViwer.LocalReport.SetParameters(Bylaw);
            string s2 = DropDownList2.SelectedItem.Text.Substring(0, DropDownList2.SelectedItem.Text.IndexOf('-'));
            var degree = new ReportParameter("p_as_grantable_degree", s2);
            MyReportViwer.LocalReport.SetParameters(degree);

            MyReportViwer.DataBind();

            MyReportViwer.LocalReport.Refresh();

        }


      
    }
}