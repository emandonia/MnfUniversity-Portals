using App_Code;
using MisBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class Search_Research_Fields : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label16.Visible = true;
           

                    link.InnerText="";
                   
                    string s = Staff_Utility.getResFieldsByStfID(RadioButtonList1.SelectedValue);
                    char[] delimiterChars = { ',' };
                    string[] ss = s.Split(delimiterChars);
                    

                    foreach (string x in ss)
                    {
                        link.InnerHtml += "<li>" + x + "</li>";
                        
                    }
                    HyperLink1.Visible = true;
                    HyperLink1.NavigateUrl = "http://" + Request.Url.Authority + "/" + Staff_Utility.getMemberAbbr(Convert.ToDecimal(RadioButtonList1.SelectedValue),Page) +
                        "/StaffDetails/10/" + StaticUtilities.Currentlanguage(Page);
        }

        

        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataBind();
        }
        protected void DepDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList1.DataSource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);
            RadioButtonList1.DataBind();
        }
        
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}