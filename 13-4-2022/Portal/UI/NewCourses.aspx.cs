using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class NewCourses : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             // Reading DataKeyName
    int x = Convert .ToInt32 ( GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value);
 
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int x = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value);
 
        }
        protected string getUrl(object eval)
        {
            string uniabbr = "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage;

            int x = Convert.ToInt32(eval);
            //Session["Coursedd"] = eval;
            return uniabbr;
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void cccc(object sender, EventArgs e)
        {
          
            if (GridView1.SelectedIndex != -1)
            { 
                int iDHide = Convert.ToInt32(GridView1.GetControl<HiddenField>("h1").Value);

               String  x = GridView1.SelectedDataKey.Values[GridView1.SelectedIndex].ToString();
            }
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iDHide = Convert.ToInt32(GridView1.GetControl<HiddenField>("h1").Value);

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string val = (string)this.GridView1.DataKeys[rowIndex]["ID"];
      
            if (e.CommandName == "printReport")
            {
                int MRLID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            }
            if (e.CommandName == "select")
            {
                string x = e.CommandArgument.ToString();
            }
        }
    }
}