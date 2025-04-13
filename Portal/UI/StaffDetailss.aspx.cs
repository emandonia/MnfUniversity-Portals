using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffDetailss : PageBase
    {
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
            var owner = Prtl_OwnersUtility.GetOwnerByAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Owner_ID;
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

                decimal id = GetMemeberIdByAbbr;

                ListView152.DataSource = MisBLL.Staff_Utility.getStfComEnv(id);
                ListView152.DataBind();
                ListView166.DataSource = MisBLL.Staff_Utility.getMemberEstablish(id);
                ListView166.DataBind();
                ListView167.DataSource = MisBLL.Staff_Utility.getMemberMembership(id);
                ListView167.DataBind();
                ListView168.DataSource = MisBLL.Staff_Utility.getMemberESubject(id);
                ListView168.DataBind();
                ListView4.DataSource = MisBLL.Staff_Utility.getMemberTrainings(id);
                ListView4.DataBind();
                ListView157.DataSource = MisBLL.Staff_Utility.getMemberSeminars(id);
                ListView157.DataBind();
                ListView156.DataSource = MisBLL.Staff_Utility.getMemberWorkshops(id);
                ListView156.DataBind();
                ListView155.DataSource = MisBLL.Staff_Utility.getMemberConferences(id);
                ListView155.DataBind();
                ListView14.DataSource = MisBLL.Staff_Utility.GetReasearchesBySTFID(id);
                ListView14.DataBind();
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


    }
}