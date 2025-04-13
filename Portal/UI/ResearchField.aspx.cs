using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using Mis_DAL;
using MnfUniversity_Portals.BLL.MIS_BLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using MisBLL;


namespace MnfUniversity_Portals.UI
{
    public partial class ResearchField : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
           //search by field only
            if (TextBox3.Text != "" & FacDropDownList.SelectedValue == "-1" & DepDropDownList.SelectedValue == "-1")
            {
               GridView1 .DataSource = Prtl_ResearchFieldsUtillity .getMemberByResearchField (TextBox3 .Text );
               GridView1.DataBind();
            }
                //search by fields and fac
            else if(TextBox3.Text !="" & FacDropDownList .SelectedValue !="-1" & DepDropDownList .SelectedValue =="-1")
            {

                GridView1.DataSource = Prtl_ResearchFieldsUtillity.getMemberByResearchFieldAndFac(TextBox3.Text,Convert .ToInt32 ( FacDropDownList .SelectedValue) );
               GridView1.DataBind();
               
            } //search by fields and dep
            else if (TextBox3.Text != "" & FacDropDownList.SelectedValue == "-1" & DepDropDownList.SelectedValue != "-1")
            {
                GridView1.DataSource = Prtl_ResearchFieldsUtillity.getMemberByResearchFieldAnddep(TextBox3.Text, Convert.ToInt32(DepDropDownList.SelectedValue));
                GridView1.DataBind();
            }
            //search by fields and fac and dep
            else if (TextBox3.Text != "" & FacDropDownList.SelectedValue != "-1" & DepDropDownList.SelectedValue != "-1")
            {
                GridView1.DataSource = Prtl_ResearchFieldsUtillity.getMemberByResearchFieldFacDep(TextBox3.Text, Convert.ToInt32(FacDropDownList.SelectedValue),Convert .ToInt32 (DepDropDownList .SelectedValue ));
                GridView1.DataBind();
            }
            
            
             

        }

        
        

        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
                DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataBind();
            }
          
        }
        protected void DepDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.DataSource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
            //                                                   StaticUtilities.Currentlanguage(Page), Page);
            //GridView1.DataBind();
        }
        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);


            GridView1.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            GridView1.SelectedIndexChanged += this.GridView1_SelectedIndexChanged;
        }


        protected string StaffUrl(string abbr)
        {
            return "http://" + Request.Url.Authority + "/" + abbr + "/StaffDetails/1/" + StaticUtilities.Currentlanguage(Page);
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string memberid = "";
            //int i = 0;
            ////GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            //foreach (var row in GridView1.Rows)
            //{
            //    RadioButton b = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1");

            //    if (b.Checked)
            //    {
            //        memberid = b.ToolTip;
            //    }
            //    i++;
            //}
            //if (Staff_Utility.checkMemberinResFields(Convert.ToDecimal(memberid)) == true)
            //{

            //    TextBox1.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Res_Fields;
            //    TextBox2.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Insert_By;
            //    Staff_Utility.update_Stf_Research_Fields(Convert.ToDecimal(memberid), TextBox1.Text, TextBox2.Text);
            //    ResMessage.Text = "تم التعديل بنجاح";

            //}

        }
    }
}