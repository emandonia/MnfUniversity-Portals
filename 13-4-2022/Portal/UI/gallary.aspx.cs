using App_Code;
using Common;
using MnfUniversity_Portals.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class gallary : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LinkButton1.PostBackUrl = URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage;
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["folderName"] = "Olympics";
          //  LinkButton1.PostBackUrl = URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage;
           Response.Redirect (URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage);

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Session["folderName"] = "Olympics";
        //    //Button1 .PostBackUrl = URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage;
  
        //}
    }
}