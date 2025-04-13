using App_Code;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using App_Code;
using BLL;
using Common;
using System.Web.Security;
using MisBLL;

namespace MnfUniversity_Portals.UI
{
    public partial class FestalHome : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string abbr = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Session["owner_abbr"] = abbr;
            int type = URLBuilder.CurrentOwner(Page.RouteData).Type;
            Session["ownertype"] = type;
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                //   OwnerImageFormView.CssClass = "table111";

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                //  OwnerImageFormView.CssClass="table1111";

            }



            var menuxmlfilepath = URLBuilder.Path(Page, PathType.Local, SiteFolders.RightLeftLinks);
            var localpath = URLBuilder.GetLocalpath(Page, SiteFolders.RightLeftLinks, "", StaticUtilities.Currentlanguage(Page.RouteData));

            var directory = System.IO.Path.GetDirectoryName(localpath);
            if (!Directory.Exists(directory))
            {
            }
            else
                if (!File.Exists(menuxmlfilepath))
                {
                    Prtl_OwnersUtility.BuildRightLeftLinksXML(Page);
                    if (Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) != null)
                    {
                        var s = Prtl_OwnersUtility.GetOwnerByAbbr2(URLBuilder.CurrentOwnerAbbr(Page.RouteData)).Owner_ID;
                        Prtl_OwnersUtility.AddXMLChildren2(Page, "Link1", readlinkurl("Link1"), s);
                        Prtl_OwnersUtility.AddXMLChildren2(Page, "Link2", readlinkurl("Link2"), s);
                        Prtl_OwnersUtility.AddXMLChildren2(Page, "Link3", readlinkurl("Link3"), s);
                        Prtl_OwnersUtility.AddXMLChildren2(Page, "Link4", readlinkurl("Link4"), s);
                    }
                }



            // Checks it there is data in ShowLogin Session Variable to Show Login Panel if there was a try to view a protected page
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                panel1Manager.Visible = true;
                //HyperLink1.NavigateUrl = "http://" + Request.Url.Authority + "/StaffPage/" +
                //StaticUtilities.Currentlanguage(Page);
            }
            else
            {
                panel1Manager.Visible = false;
                //HyperLink1.NavigateUrl = "http://" + Request.Url.Authority + "/" +
                //                         URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffPage/" +
                //                         StaticUtilities.Currentlanguage(Page);
            }


            // Clear ShowLogin to prevernt viewing it again if dismissed
            if (!string.IsNullOrEmpty(ShowAccessDenied))
            {
                StaticUtilities.ShowErrorMessage(Page.Master, (string)GetLocalResourceObject("AccessDeniedTitle"),
                                                 (string)GetLocalResourceObject("AccessDeniedMessage"));

                // Clear ShowAccessDenied to prevernt viewing it again if dismissed
                ShowAccessDenied = "";
            }
        }
        private bool getvisability()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string readlinkurl(string link)
        {



            string doc = URLBuilder.Path(Page, PathType.Local, SiteFolders.RightLeftLinks, "Links.xml");
            if (File.Exists(doc))
            {
                var doc1 = XDocument.Load(doc);

                var s = StaticUtilities.OwnerID(Page).ToString();
                var query = (from c in doc1.Root.Descendants("MenuItem")
                             where c.Attribute("OwnerId").Value == s && c.Attribute("MenuItemType").Value == link
                             select c).SingleOrDefault();

                if (query != null)
                {
                    return query.Attribute("Url").Value;
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




        protected string Getmargin()
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                return "margin-right:12px";
            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return "margin-left:12px";
            }
            return "";
        }







        protected string getimageHoversource()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/ictp_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/results_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }

        }

        protected string getimagesource()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/ictp_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/results_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }


        }




        protected string Sgetimage2source()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/search_ projects_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else if (StaticUtilities.GetOwnerType(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) == OwnerTypes.Faculty)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/faculty_strategy_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");
            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/search_ projects_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }
        protected void Button555_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/News/" + StaticUtilities.Currentlanguage(Page));
        }

        protected string Sgetimage2sourceHover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/search_projects_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else if (StaticUtilities.GetOwnerType(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) == OwnerTypes.Faculty)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/faculty_strategy_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");
            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/search_projects_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }


        protected string Qgetimage2source()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/quality_projects_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/faculty_quality_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string Qgetimage2sourceHover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/quality_projects_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/faculty_quality_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }




        protected string Ogetimage2source()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/other_projects_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/other_projects_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string Ogetimage2sourceHover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/other_projects_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/other_projects_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }






        protected string Eportal()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/E-Portal_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/E-Portal_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string Eportal_hover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/E-portal_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/E-portal_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }


        protected string Staffportal()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_Portal_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_Portal_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string staffportal_hover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_portal_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_portal_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string develpeStaff()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_devolpment_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_devolpment_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string develpeStaff_hover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_devolpment_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/staff_devolpment_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string Dlibrary()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/digital_library_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/digital_library_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected string Dlibrary_hover()
        {
            if (URLBuilder.CurrentOwnerAbbr(Page.RouteData) == null)
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/digital_library_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
            else
            {
                return URLBuilder.ImageURLBase + "/uni/Portal/SiteInfo/digital_library_hover_" +
                       StaticUtilities.Currentlanguage(Page.RouteData) + (".png");

            }
        }

        protected object getLink1url()
        {
            return readlinkurl("Link1");
        }

        protected object getLink2url()
        {
            return readlinkurl("Link2");
        }

        protected object getLink3url()
        {
            return readlinkurl("Link3");
        }

        protected object getLink4url()
        {
            return readlinkurl("Link4");
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    MembershipUser user = StaffUsers_Utility.GetMemberShipUser(5049);
        //    user.ChangePassword(user.ResetPassword(), "12345");
        //}

        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //    Prtl_MenuUtility.insertCouncilMenu();
        //}
        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //  Prtl_OwnersUtility.  insertstafffacid();
        //}
    }
}