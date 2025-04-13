using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Web.Security;
namespace MnfUniversity_Portals.UI
{
    public partial class StaffCVs : PageBase
    {

        protected string FileCVUrl(object staffid)
        {
            string s1 = URLBuilder.CurrentOwnerAbbr(Page.RouteData);


            if (s1 != null)
            {
                string s = URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/CVs/" + s1 + "/" + Prtl_OwnersUtility.GetStaffCVFromPortal(Convert.ToDecimal(staffid));
                return s;
            }
            else
            {
                string s = URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/CVs/" + Session["abbr"].ToString()  + "/" + Prtl_OwnersUtility.GetStaffCVFromPortal(Convert.ToDecimal(staffid));
                return s;
            }
        }
      
        protected void DeleteCVFile(object sender, EventArgs e)
        {


            LinkButton x = (LinkButton)sender;
      

            string memberid = x.CommandArgument;
            int i = 0;
          
            if (memberid != "")
            {
                StaticUtilities.DeleteImage(Page, getFileCV(Convert.ToDecimal(memberid)), SiteFolders.CV);
                Prtl_AbstractsUtility.deleteFileCV(Convert.ToDecimal(memberid));
              // var datasource = Staff_Utility.GetMembersByFac2(Convert.ToDecimal(FacDropDownList.SelectedValue), Page);
               // CVListView.DataSource = datasource;
  CVListView.DataSource = Session["datasource"];
                CVListView.DataBind();
               
            } 
           
        }



        protected string getFileCV(object memberid)
        {
            return Prtl_AbstractsUtility.getFileCV(Convert.ToDecimal(memberid));
        }

        private  string[] GetFileNames()
        {
            string s1 = URLBuilder.CurrentFacAbbr(Page.RouteData);

            string s = URLBuilder.PhysicalPath("") + "uni\\Portal\\CVs\\" + s1;
   
            string[] files = Directory.GetFiles(s);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }
        protected void FileCVEditorControlInsertClicked(object sender, EventArgs e)
        {
            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            Editor_ModalPopupExtender.Show();
            LinkButton x = (LinkButton) sender;
            Session["ID"]=x.CommandArgument ;

            ListBox list = (ListBox)Editor_DetailsView1.FindControl("ListBox1");
            list.DataSource = GetFileNames();
            list.DataBind();

            
                
            
        }
      
        public bool checkuser()
        {
            return Roles.IsUserInRole(Page.User.Identity.Name.ToLower(), "FacAdmin");
        }
      
        
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

                Session["datasource"] = datasource;
                CVListView.DataSource = datasource;
                CVListView.DataBind();
            }
            //search by faculty and department
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" &&
                     txtName.Text == "")
            {
                var datasource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);
                Session["datasource"] = datasource;
                CVListView.DataSource = datasource;
                CVListView.DataBind();
            }

                //search by faculty & name
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByFacAndName(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                         StaticUtilities.Currentlanguage(Page),
                                                         txtName.Text.Trim(), Page);
                
                
                Session["datasource"] = datasource;
                CVListView.DataSource = datasource;
                CVListView.DataBind();
            }
            //search by faculty and department and nameF
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByDepAndName(
                        Convert.ToDecimal(DepDropDownList.SelectedValue),
                        StaticUtilities.Currentlanguage(Page), txtName.Text.Trim(), Page);
                Session["datasource"] = datasource;
                CVListView.DataSource = datasource;
                CVListView.DataBind();
            }


                //search by name only
            else if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1" &&
                     txtName.Text != "")
            {
                var datasource =
                    Staff_Utility.GetMembersByName(StaticUtilities.Currentlanguage(Page),
                                                   txtName.Text.Trim(), Page);
                Session["datasource"] = datasource;
                CVListView.DataSource = datasource;
                CVListView.DataBind();
            }
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



            string id = FacDropDownList.SelectedValue;
            string  abbr = Staff_Utility.getIDFac(id);
            Session["abbr"] = abbr;
            DepDropDownList.DataBind();
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {


           // StaffUsers_Utility.InsertNewStaffMembers(Page);
         
            if (!IsPostBack)
            {
                //Prtl_UsersUtility.updateuser();
                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
                var DepAbbr = URLBuilder.CurrentDepAbbr(Page.RouteData);
                if (FacAbbr == null)
                {
                    FacDropDownList.Items.Clear();
                    FacDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                }
                else
                {
                    decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                    FacDropDownList.SelectedValue = id.ToString();
                    FacDropDownList.DataBind();
                    FacDropDownList.Enabled = false;
                    var datasource = Staff_Utility.GetMembersByFac(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);
                    Session["datasource"] = datasource;
                    CVListView.DataSource = datasource;
                    CVListView.DataBind();
                    if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
                    {
                        DepDropDownList.Enabled = true;
                    }
                    DepDropDownList.Items.Clear();
                    DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                    DepDropDownList.DataSource =
                        Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                     StaticUtilities.Currentlanguage(Page));
                    DepDropDownList.DataTextField = "DepName";
                    DepDropDownList.DataValueField = "ID";
                    DepDropDownList.DataBind();
                }
 
            }


        }

        protected string StaffUrl(string abbr)
        {
            return "http://" + Request.Url.Authority + "/" + abbr + "/StaffDetails/1/" + StaticUtilities.Currentlanguage(Page);
        }

        //protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ListBox list = (ListBox)Editor_DetailsView1.FindControl("ListBox1");
        //   string filename= list.Items[list.SelectedIndex].Text;

        //   Prtl_AbstractsUtility.UpdateStaffCVFiles(Convert.ToDecimal(Session["ID"]), filename);
        //}


        protected void InsertButtonClicked(object sender, EventArgs e)
        {
            ListBox list = (ListBox)Editor_DetailsView1.FindControl("ListBox1");
            string filename = list.Items[list.SelectedIndex].Text;

            Prtl_AbstractsUtility.UpdateStaffCVFiles(Convert.ToDecimal(Session["ID"]), filename);
           CVListView .DataSource = Session["datasource"] ;
            CVListView.DataBind();
        }
    }
}