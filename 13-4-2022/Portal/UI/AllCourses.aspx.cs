using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class AllCourses : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string  gUrl(  string id)
        {
            Session["id"] = id;
          //  string uniabbr = "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage;

            return "http://" + Request.Url.Authority + "/univ_ITs/Courses/" +  CurrentLanguage;
        }
    }
}