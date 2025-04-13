using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;

namespace AnnualYouthWeekWebApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)

        {
           if (Session["UserName"] != null) 
            {
                
                    Session["UniID"] =
                        Convert.ToInt32(UsersUtility.GetUniFromUser((string) Session["UserName"]).University_id);
                    LinkButton1.Visible = true;
                    Label2.Text = "مرحبا بك: " + Session["UserName"];
                }
                else
                {
                    LinkButton1.Visible = false;


                }
            
            //else
            //{
            //    Response.Redirect("Default.aspx");
            //}
        }
        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            UsersUtility.updateloginstate(Convert.ToInt32(Session["uid"]), false);
            Session["uid"] = null;
            Session["UserName"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}