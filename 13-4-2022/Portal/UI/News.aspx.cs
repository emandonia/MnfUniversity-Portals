using System;
using System.Globalization;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Portal_DAL;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using AjaxControlToolkit;
using System.Linq;


using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Web.Security;
using Portal_DAL;
using System.Collections.Generic;
using MnfUniversity_Portals.BLL.MIS_BLL;
using System.Web.UI;

namespace MnfUniversity_Portals.UI
{
    public partial class News : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var owner = URLBuilder.CurrentOwnerAbbr(Page.RouteData);

                if (owner != null)
                {
                    bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                    if (owner.ToLower() == "med" && val1)
                    {
                        ResetMenuB.Visible = true;
                    }
                    else
                    {
                        ResetMenuB.Visible = false;
                    }
                }
            }
        }


        protected bool GetVisible(Page page)
        {



            var owner =URLBuilder.CurrentOwnerAbbr(Page.RouteData)  ;
           
            if(owner.ToLower ()=="med" )
            {
                return true;
            }
            else
            {
                return false;
            }
            //var ownerid = Prtl_OwnersUtility.getOwnerInitAbbr(owner);


        }
        protected void ButtonM_Click(object sender, EventArgs e)
        {

            var dc = new PortalDataContextDataContext();
            {
                prtl_Owner o = dc.prtl_Owners.SingleOrDefault(s => s.Abbr.ToLower() == "med");
                o.MenuUpdated = false;
                dc.SubmitChanges();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            NewsSearchControl.FilterDate = StaticUtilities.ExtractDate(TextBox1.Text);
            NewsSearchControl.FilterDate2 = StaticUtilities.ExtractDate(TextBox2.Text);
           // NewsSearchControl.LDSTableName = (string)Session["TbName2"];
            NewsSearchControl.DataBind();
          
        }

        protected void Button222_Click(object sender, EventArgs e)
        {

            string username = "adminquality";
            string password = "123456";
            MembershipUser mu = Membership.GetUser(username);
           
            mu.ChangePassword(mu.ResetPassword(), password);

        }
        
        
    }
}