using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffPage : PageBase
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            //not select any condition
            if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text == "")
            {
            }

                //search by faculty only
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1" && txtName.Text == "")
            {
                var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);

                ListView1.DataSource = datasource;
                ListView1.DataBind();
            }
                //search by faculty and department
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" &&
                     txtName.Text == "")
            {
                var datasource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);

                ListView1.DataSource = datasource;
                ListView1.DataBind();
            }

                //search by faculty & name
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByFacAndName(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                         StaticUtilities.Currentlanguage(Page),
                                                         txtName.Text.Trim(), Page);

                ListView1.DataSource = datasource;
                ListView1.DataBind();
            }
                //search by faculty and department and name
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByDepAndName(
                        Convert.ToDecimal(DepDropDownList.SelectedValue),
                        StaticUtilities.Currentlanguage(Page), txtName.Text.Trim(), Page);

                ListView1.DataSource = datasource;
                ListView1.DataBind();
            }


                //search by name only
            else if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByName(StaticUtilities.Currentlanguage(Page),
                                                   txtName.Text.Trim(), Page);

                ListView1.DataSource = datasource;
                ListView1.DataBind();
            }
        }

       

        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string) GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataBind();
        }


       
        protected void Page_Load(object sender, EventArgs e)
        {

           
            //StaffUsers_Utility.InsertNewStaffMembers(Page);
           //this. DataBind();
           // DataList1.DataBind();
            if (!IsPostBack)
            {
                //Prtl_UsersUtility.updateuser();
                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
                var DepAbbr = URLBuilder.CurrentDepAbbr(Page.RouteData);
                if (FacAbbr == null)
                {
                    FacDropDownList.Items.Clear();
                    FacDropDownList.Items.Add(new ListItem((string) GetLocalResourceObject("choose.Text"), "-1"));
                }
                else
                {
                    decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                    FacDropDownList.SelectedValue = id.ToString();
                    FacDropDownList.DataBind();
                    FacDropDownList.Enabled = false;
                    var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);
                    ListView1.DataSource = datasource;
                    ListView1.DataBind();
                    if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
                    {
                        DepDropDownList.Enabled = true;
                    }
                    DepDropDownList.Items.Clear();
                    DepDropDownList.Items.Add(new ListItem((string) GetLocalResourceObject("choose.Text"), "-1"));
                    DepDropDownList.DataSource =
                        Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                     StaticUtilities.Currentlanguage(Page));
                    DepDropDownList.DataTextField = "DepName";
                    DepDropDownList.DataValueField = "ID";
                    DepDropDownList.DataBind();
                }


                //if (DepAbbr != null)
                //{

                //    decimal depid = Prtl_OwnersUtility.getDepIDByAbbr(FacAbbr, DepAbbr);
                //    DepDropDownList.SelectedValue = depid.ToString();
                //    DepDropDownList.DataBind();
                //    DepDropDownList.Enabled = false;
                //}

            }


        }

        protected string StaffUrl(string abbr)
        {
            return "http://" + Request.Url.Authority + "/" + abbr+"/StaffDetails/1/"+StaticUtilities.Currentlanguage(Page);
        }


       
    }
}