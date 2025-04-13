using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using System.Web.Security;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Data;
using System.Collections.Generic;
using Portal_DAL;
using Mis_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffDetails : PageBase
    {


        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
           
            var linkbutton = (LinkButton)sender;
            LinqDataSource4.Where = "SA_SC_RESEARCH_ID==" + linkbutton.CommandArgument;
            Editor_ModalPopupExtender.Show();

            //Convert.ToInt32(Linkbutton.CommandArgument)

            //Session["iddd"] = Linkbutton.CommandArgument;

        }
    
        private decimal GetMemeberIdByAbbr
        {
            get { return MisBLL.Staff_Utility.getMemeberIDByAbbr(Page.RouteData); }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            StaticUtilities.ChooseMaster(Page);
          
        }
        public string GetUserName()
        {
            var owner = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Owner_ID;
            var userid = Prtl_OwnerAdminUsersUtility.GetUserIdByOwnerId(owner);
            return Prtl_UsersUtility.GetAspUser(userid).UserName.ToLower();
        }
        public bool checkAdress()
        {

            if (Page.User.Identity.Name.ToLower() == GetUserName())
            {
                Session["address"] = false;
                return true;

            }
            else
            {
                Session["address"] = Staff_Utility.AdressCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
                return Staff_Utility.AdressCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
            }
        }
        public bool checkUser()
        {

            if (Page.User.Identity.Name.ToLower() == GetUserName())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         public bool checkuserr()
        {
            return Roles.IsUserInRole(Page.User.Identity.Name.ToLower(), "StaffRole");
        }
        //protected string GetImageUrl(Page page)
        //{
        //    // Base URL from configuration or constant
        //    string baseUrl = "http://193.227.24.15/umisbuilt_new";

        //    // Get the member ID and photo path
        //    decimal memberId = Staff_Utility.getMemeberIDByAbbr(page.RouteData);
        //    var member = Staff_Utility.getMemberByID(memberId);
        //    string photoPath = member.STF_PHOTO;

        //    // Split the photo path and construct the full URL
        //    string[] photoParts = photoPath.Split('~');
        //    if (photoParts.Length > 1)
        //    {
        //        string relativePath = photoParts[1].TrimStart('/'); // Remove leading slashes
        //        string fullUrl = $"{baseUrl}/{relativePath}";
        //        return fullUrl;
        //    }

        //    // Handle the case where the photo path is invalid
        //    return string.Empty;
        //}
        protected string GetImageUrl(Page page)
        {
          //  string url =  (Staff_Utility.getMemberByID(Convert.ToDecimal(Staff_Utility.getMemeberIDByAbbr(Page.RouteData))).STF_PHOTO).Split('~')[1];
            string url = (Staff_Utility.getMemberByID
                (Convert.ToDecimal(Staff_Utility.getMemeberIDByAbbr(Page.RouteData)))
                .STF_PHOTO)
                .Replace("~","").Replace("//","/");
            
            
            return url;
            //var owner = URLBuilder.CurrentOwnerAbbr(page.RouteData);
            //var ownerid = Prtl_OwnersUtility.getOwnerInitAbbr(owner);
            // string ss = URLBuilder.GetURLIfExists2(Page, SiteFolders.StaffImage, "Image");         
            //    int flag = 0;
            //if (Directory.Exists(ss))
            //{
            //    var allFilenames = Directory.EnumerateFiles(ss).Select(p => Path.GetFileName(p));
            //    var candidates = allFilenames.Where(fn => Path.GetExtension(fn) == ".png")
            //                                 .Select(fn => Path.GetFileNameWithoutExtension(fn));
            //    foreach (var candidate in candidates)
            //    {
            //        if (candidate == "Image")
            //        {
            //            flag = 1;
            //            return URLBuilder.FilesHomeServer + "/PrtlFiles/Staff/" + ownerid + "/Portal/SiteInfo/Image.png";

            //        }
            //        else
            //        {
            //            flag = 0;
            //        }

            //    }
            //    if (flag == 0)
            //    {
            //        return URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/SiteInfo/Image.png";


            //    }
            //    else
            //    {
            //        return "";
            //    }


            //} else
            //{
            //    return "";
            //}

        }
    public bool checkTel()
        {

            if (Page.User.Identity.Name.ToLower() == GetUserName())
            {
                Session["Tel"] = false;
                return true;
            }
            else
            {
                Session["Tel"] = Staff_Utility.TelCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
                return Staff_Utility.TelCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
            }
        }
        public bool checkEmail()
        {

            if (Page.User.Identity.Name.ToLower() == GetUserName())
            {
                Session["email"] = true;
                return true;

            }
            else
            {
                Session["email"] = Staff_Utility.EmailCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
                return Staff_Utility.EmailCheck(Staff_Utility.getMemeberIDByAbbr(Page.RouteData));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {
             

             //   Menu mp_Menu = (Menu)  this.Master.FindControl("MainContent").FindControl("StaffMenu") ;
                //foreach (MenuItem mi in mp_Menu.Items)
                //{
                //    if (mi.Text == "قائمة الابحاث العلمية")
                //    {
                //        mi.NavigateUrl = "http://" + Request.Url.Authority + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSenRes/" + StaticUtilities.Currentlanguage(Page.RouteData); ;

                //    }
                //}



               



                if ((string)Page.RouteData.Values["id"] == "1")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Personal Data")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
//************

                else if ((string)Page.RouteData.Values["id"] == "505")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "SentificResearches")
                        {

                            var ddc = new MisDataContext();

                           //int idd = Prtl_OwnersUtility.getStaffIDbyAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));

                            int idd =Convert.ToInt32( Staff_Utility.getMemeberIDByAbbr(Page.RouteData));

                           var stringq = "select SA_STF_MEMBER.SA_STF_MEMBER_ID,sa_sc_research.sa_sc_research_id,AS_FACULTY_INFO.FACULTY_DESCR_AR,SA_SC_RESEARCH.RESEARCH_TITLE as RESEARCH_TITLE ,SA_SC_RESEARCH.RESEARCH_TITLEEN as RESEARCH_TITLEEN1 , SA_SC_RESEARCH.RESEARCH_SUMM_AR as RESEARCH_SUMM_AR,SA_SC_RESEARCH.RESEARCH_SUMM_EN,SA_STF_MEMBER.STF_FULL_NAME_AR,SA_STF_MEMBER.STF_FULL_NAME_EN,RESEARCHER_TYPE.RESEARCHER_TYPE_AR_DESC,RESEARCHER_TYPE.RESEARCHER_TYPE_EN_DESC,RESEARCH_TYPE.RESEARCH_TYPE_AR_DESC,RESEARCH_TYPE.RESEARCH_TYPE_EN_DESC from SA_SC_RESEARCH inner join  RESEARCH_TYPE on SA_SC_RESEARCH.RESEARCH_TYPE=RESEARCH_TYPE.RESEARCH_TYPE_ID inner join SA_RESEARCH_TEAM on SA_RESEARCH_TEAM.SA_SC_RESEARCH_ID=SA_SC_RESEARCH.SA_SC_RESEARCH_ID inner join RESEARCHER_TYPE on SA_RESEARCH_TEAM.RESEARCHER_TYPE=RESEARCHER_TYPE.RESEARCHER_TYPE_ID inner join SA_STF_MEMBER on SA_STF_MEMBER.SA_STF_MEMBER_ID=SA_RESEARCH_TEAM.SA_STF_MEMBER_ID inner join AS_FACULTY_INFO on SA_SC_RESEARCH.AS_FACULTY_INFO_ID=AS_FACULTY_INFO.AS_FACULTY_INFO_ID where SA_STF_MEMBER.SA_STF_MEMBER_ID=" + idd.ToString();


                            var quary = ddc.ExecuteQuery<SA_SC_RESEARCH>(stringq);
                            GridView1 .DataSource= quary.ToList();
                            GridView1.DataBind();


                            //string Where = "Staff_ID ==@StaffID";
                            //LinqDataSource19.WhereParameters.Add("StaffID", DbType.Int32, idd.ToString());

                            //LinqDataSource19.Where = Where;
                            //LinqDataSource19.DataBind();

                            //ListView19.DataSource = LinqDataSource19;
                            //ListView19.DataBind();


                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }

                else if ((string)Page.RouteData.Values["id"] == "2")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Scientific Degree")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "3")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Position")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "4")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Educational Activities")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "5")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Scientific Papers" || VARIABLE.ToolTip == "Scientific Researches"
                            || VARIABLE.ToolTip == "Books" || VARIABLE.ToolTip == "Conferences"
                            || VARIABLE.ToolTip == "Sharing" || VARIABLE.ToolTip == "Membership")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "51")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Sharing")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "52")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Membership")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "53")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Conferences")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "54")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Books")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }

                else if ((string)Page.RouteData.Values["id"] == "99")
                {
                    Response .Redirect( "http://" + Request.Url.Authority + URLBuilder.CurrentOwnerAbbr(Page.RouteData)+ "/StaffSenRes/" + StaticUtilities.Currentlanguage(Page.RouteData ));

                }


                else if ((string)Page.RouteData.Values["id"] == "55")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Scientific Papers")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "56")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Scientific Researches")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "6")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Global missions" || VARIABLE.ToolTip == "Missions"
                            || VARIABLE.ToolTip == "Travels")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "61")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Global missions")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "62")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Missions"
                            )
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "63")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Travels")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "7")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Workshop")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "8")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Admin" || VARIABLE.ToolTip == "structural works" || VARIABLE.ToolTip == "Prices" || VARIABLE.ToolTip == "Visitor")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "81")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Admin")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "82")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "structural works")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "83")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Prices")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "84")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Visitor")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "9")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Social Services")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }
                else if ((string)Page.RouteData.Values["id"] == "10")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Research Fields")
                        {
                            link.InnerHtml.Remove(0);
                            //FieldsList.Items.Clear();
                            string s = Staff_Utility.getResFieldsByStfAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                            char[] delimiterChars = { ',' };
                            string[] ss = s.Split(delimiterChars);
                            //Label ResLabel = (Label)FormView1.FindControl("ResLabel"); 
                            
                            foreach (string x in ss)
                            {
                                link.InnerHtml += "<li>" + x + "</li>";
                                //FieldsList.Items.Add(new ListItem(x));
                                //ResLabel.Text += x + Environment.NewLine;
                            }
                            
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }
                }

                decimal id = GetMemeberIdByAbbr;

                ListView152.DataSource = MisBLL.Staff_Utility.getStfComEnv(id);
                ListView152.DataBind();
                ListView166.DataSource = MisBLL.Staff_Utility.getMemberEstablish(id);
                //ListView166.DataBind();
                ListView167.DataSource = MisBLL.Staff_Utility.getMemberMembership(id);
                ListView167.DataBind();
                ListView168.DataSource = MisBLL.Staff_Utility.getMemberESubject(id);
                ListView168.DataBind();
                ListView4.DataSource = MisBLL.Staff_Utility.getMemberTrainings(id);
                ListView4.DataBind();
                ListView157.DataSource = MisBLL.Staff_Utility.getMemberSeminars(id);
                ListView157.DataBind();
                //ListView18.DataSource = MisBLL.Staff_Utility.getMemberWorkshops(id);
                //ListView18.DataBind();
                ListView155.DataSource = MisBLL.Staff_Utility.getMemberConferences(id);
                ListView155.DataBind();
                //14-6-2023
                //ListView14.DataSource = MisBLL.Staff_Utility.GetReasearchesBySTFID(id);
                //ListView14.DataBind();
                ListView16.DataSource = MisBLL.Staff_Utility.getMemberSupervisePapers(id);
                ListView16.DataBind();
                ListView17.DataSource = MisBLL.Staff_Utility.getMemberDiscussPapers(id);
                ListView17.DataBind();
                LinqDataSource1.Where = "SA_STF_MEMBER_ID == " + id;
                ListView1.DataBind();
                SciDegreeLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView2.DataBind();
                posLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView3.DataBind();

                //courLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                //ListView4.DataBind();
                AdminLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView5.DataBind();
                prizeLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView6.DataBind();
                visitLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView12.DataBind();
                teachingLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView11.DataBind();
                GlobalMissionsLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView7.DataBind();
                outmissLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView8.DataBind();
                IntLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView9.DataBind();
                CommLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView10.DataBind();
                VISITSLinqDataSource.Where = "SA_STF_MEMBER_ID == " + id;
                ListView13.DataBind();
                LinqDataSource2.Where = "SA_STF_MEMBER_ID == " + id;
                ListView145.DataBind();
                LinqDataSource3.Where = "SA_STF_MEMBER_ID == " + id;
                ListView15.DataBind();
                LinqDataSource5.Where = "SA_STF_MEMBER_ID == " + id;
                ListView18.DataBind();
                Page.Form.Attributes.Add("enctype", "multipart/form-data"); 
            }
        }
        protected void UpdateClicked(object sender, EventArgs e)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
            ModalPopupExtender1.Show();
            TextBox x = (TextBox)DetailsView1.FindControl("TextBox1");
            x.Text= Staff_Utility.getResFieldsByStfAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
                            

        }
        protected void UpdateButtonClicked(object sender, EventArgs e)
        {
            TextBox x = (TextBox)DetailsView1.FindControl("TextBox1");
            //string s = Staff_Utility.getResFieldsByStfAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
            char[] delimiterChars = { ',' };
            string[] ss = x.Text.Split(delimiterChars);
            Label xx = (Label)DetailsView1.FindControl("Label28");
            if (ss.Length >7) { xx.Text = "أكثر من 7 مجالات"; ModalPopupExtender1.Show(); }
            else { xx.Text = "";bool xy= Staff_Utility.update_Stf_Research_Fields2(GetMemeberIdByAbbr, x.Text);
            if (xy == true) { Label29.Text = "تم التحديث بنجاح برجاء تحديث الصفحة"; }
            else
            {
                Label29.Text = "لم يتم التحديث";
            }
               }
            
        }
        protected void DeleteButtonClicked(object sender, EventArgs e)
        {
          
           bool x= Staff_Utility.Delete_Stf_Research_Fields(GetMemeberIdByAbbr);
           if (x==true) { Label29.Text = "تم الحذف بنجاح برجاء تحديث الصفحة"; }
           else
           {
               Label29.Text = "لم يتم الحذف";
           }
            
        }
        protected bool GetAdressPublished(string currentOwnerAbbr)
        {
            return Prtl_OwnersUtility.GetAdressPublished(currentOwnerAbbr);
        }
        protected bool GetTelPublished(string currentOwnerAbbr)
        {
            return Prtl_OwnersUtility.GetTelPublished(currentOwnerAbbr);
        }
        protected bool GetEmailPublished(string currentOwnerAbbr)
        {
            return Prtl_OwnersUtility.GetEmailPublished(currentOwnerAbbr);
        }

        protected void UpdateInfo(object sender, EventArgs e)
        {
            bool Adress = (bool)Session["address"];
            bool Email = (bool)Session["email"];
            bool Tel = (bool)Session["Tel"];
            Staff_Utility.UpdateStaffInfo(URLBuilder.CurrentOwnerAbbr(Page.RouteData), Adress, Email, Tel);

        }

        protected void addresschecked(object sender, EventArgs e)
        {
            CheckBox address = (CheckBox)sender;
            Session["address"] = address.Checked;
        }
        protected void Emailchecked(object sender, EventArgs e)
        {
            CheckBox email = (CheckBox)sender;
            Session["email"] = email.Checked;
        }
        protected void Telchecked(object sender, EventArgs e)
        {
            CheckBox Tel = (CheckBox)sender;
            Session["Tel"] = Tel.Checked;
        }


        

        protected void UpdateImage(object sender, EventArgs e)
        {
            AsyncFileUpload f = (AsyncFileUpload)OwnerImageFormView.FindControl("AsyncFileUpload1");
            if (f.HasFile)
            {
           
            
            string ss = URLBuilder.GetURLIfExists2(Page, SiteFolders.StaffImage, "Image");
           
                int flag = 0;
                if (Directory.Exists(ss))
                {
                    var allFilenames = Directory.EnumerateFiles(ss).Select(p => Path.GetFileName(p));

                    // Get all filenames that have a .txt extension, excluding the extension
                    var candidates = allFilenames.Where(fn => Path.GetExtension(fn) == ".png")
                                                 .Select(fn => Path.GetFileNameWithoutExtension(fn));
                    foreach (var candidate in candidates)
                    {
                        if (candidate == "Image")
                        {
                            f.PostedFile.SaveAs(ss + "/Image.png");
                            flag = 1;
                            //f.PostedFile.SaveAs(Server.MapPath(@ss + "/" + f.PostedFile.FileName));
                            //File.Move(f.PostedFile.FileName, "Image.png");
                            //File.Delete(Server.MapPath(s+"/Image.png"));
                        }
                        else
                        {
                            flag = 0;
                        }

                    }
                    if (flag == 0)
                    {
                        f.PostedFile.SaveAs(ss + "/Image.png");
                        
                    }


                }
              
            }

        }

        protected string GetStaffFname(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).STF_NAME_AR;

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).STF_FNAME_EN;
            }
            else
            {
                return "";
            }
        }

        protected string GetStaffFuname(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).STF_LNAME_AR;

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).STF_LNAME_EN;
            }
            else
            {
                return "";
            }
        }

        protected string GetStaffGSPECS(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).PG_THESIS_GENERAL_SPEC != null)
                {

                    return
                        Staff_Utility.getMemberByID(Convert.ToDecimal(eval))
                                     .PG_THESIS_GENERAL_SPEC.GENERAL_SPEC_DESCR_AR;
                }
                else
                {
                    return "";
                }
            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).PG_THESIS_GENERAL_SPEC != null)
                {
                    return
                        Staff_Utility.getMemberByID(Convert.ToDecimal(eval))
                                     .PG_THESIS_GENERAL_SPEC.GENERAL_SPEC_DESCR_EN;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        protected string GetStaffDSPECS(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {

                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).PG_THESIS_DETAILED_SPEC != null)
                { var x= Staff_Utility.getMemberByID(Convert.ToDecimal(eval))
                                     .PG_THESIS_DETAILED_SPEC.DETAILED_SPEC_DESC_AR;
                    return
                        Staff_Utility.getMemberByID(Convert.ToDecimal(eval))
                                     .PG_THESIS_DETAILED_SPEC.DETAILED_SPEC_DESC_AR;
                }
                else
                {
                    return "";
                }

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).PG_THESIS_DETAILED_SPEC != null)
                {
                    return
                        Staff_Utility.getMemberByID(Convert.ToDecimal(eval))
                                     .PG_THESIS_DETAILED_SPEC.DETAILED_SPEC_DESC_EN;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        protected string GetCJob(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).SA_CODE_SC_DEG != null)
                {
                    var x = Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).SA_CODE_SC_DEG.SC_DEG_DESCR_AR;
                    return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).SA_CODE_SC_DEG.SC_DEG_DESCR_AR;
                }
                else
                {
                    return "";
                }

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                if (Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).SA_CODE_SC_DEG != null)
                {
                    return Staff_Utility.getMemberByID(Convert.ToDecimal(eval)).SA_CODE_SC_DEG.SC_DEG_DESCR_EN;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        int id = Prtl_OwnersUtility.getStaffIDbyAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));

        //        string Where = "Staff_ID ==@StaffID";
        //        LinqDataSource1.WhereParameters.Add("StaffID", DbType.Int32, id.ToString());

        //        LinqDataSource1.Where = Where;
        //        LinqDataSource1.DataBind();

        //        ListView1.DataSource = LinqDataSource1;
        //        ListView1.DataBind();
        //    }
        //}

        protected string GetUrl(object eval)
        {
           
            string s1 = URLBuilder.FilesHomeServer + "\\PrtlFiles\\uni\\Portal\\SentficResearches\\" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "\\" + eval.ToString();
          
            return s1;
          
        }


        protected void DownloadFile(object sender, EventArgs e)
        {
          //  string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;


            string s1 = URLBuilder.PhysicalPath("") + "uni\\Portal\\SentficResearches\\" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "\\" + (sender as LinkButton).CommandArgument;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(s1));
            Response.WriteFile(s1);
            Response.End();
      
        
        
        
        }

        

        protected void Details_OnClick(object sender, EventArgs e)
        {

            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            // find other controls:
            var Details = (LinkButton)item.FindControl("Details");

            string c = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Response.ContentType = "APPLICATION/OCTET-STREAM";
            String Header = "Attachment; Filename=XMLFile.xml";
            Response.AppendHeader("Content-Disposition", Header);
             string s1 =   URLBuilder.PhysicalPath("") + "uni\\Portal\\SentficResearches\\" + c+"\\"+ Details.CommandArgument.ToString();
          System.IO.FileInfo Dfile = new System.IO.FileInfo(s1);


            Response.WriteFile(Dfile.FullName);
            //Don't forget to add the following line
            Response.End();
        }

    }
}