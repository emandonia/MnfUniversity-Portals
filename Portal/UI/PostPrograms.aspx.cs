using App_Code;
using Common;
using MnfUniversity_Portals.BLL.MIS_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class PostPrograms : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((string)Page.RouteData.Values["id"] == "1")
                {
                    foreach (var VARIABLE in Accordion1.Panes)
                    {
                        if (VARIABLE.ToolTip == "Diploma")
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
                        if (VARIABLE.ToolTip == "Master")
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
                        if (VARIABLE.ToolTip == "Phd")
                        {
                            VARIABLE.Visible = true;
                        }
                        else
                        {
                            VARIABLE.Visible = false;
                        }
                    }

                }



                ListView1.DataSource = PostSubject_Utility.GetDipPostPrograms(URLBuilder.CurrentOwnerAbbr(Page.RouteData), StaticUtilities.Currentlanguage(Page.RouteData));
                ListView1.DataBind();

                ListView2.DataSource = PostSubject_Utility.GetMasterPostPrograms(URLBuilder.CurrentOwnerAbbr(Page.RouteData), StaticUtilities.Currentlanguage(Page.RouteData));
                ListView2.DataBind();

                ListView3.DataSource = PostSubject_Utility.GetphdPostPrograms(URLBuilder.CurrentOwnerAbbr(Page.RouteData), StaticUtilities.Currentlanguage(Page.RouteData));
                ListView3.DataBind();






            }
        }

        protected string DipPorgUrl(string facabbr,string id)
        {
            return "http://" + Request.Url.Authority + "/" + facabbr + "/postprg_" + id;
        }
        protected string MasterPorgUrl(string facabbr, string id)
        {
            return "http://" + Request.Url.Authority + "/" + facabbr + "/postprg_" + id;
        }
        protected string PhdPorgUrl(string facabbr, string id)
        {
            return "http://" + Request.Url.Authority + "/" + facabbr + "/postprg_" + id;
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
          PostSubject_Utility.CreatePostProgramOwners();
        }
    }
}