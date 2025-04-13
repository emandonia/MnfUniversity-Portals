using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UI
{
    public partial class Net_Complain : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButtonClicked(object sender, EventArgs e)
        {
           
          int x=  Prtl_ComplainUtility.insert_Nt_Damage_Report(Convert.ToInt32(FacDropDownList.SelectedValue), txtEngName.Text,
             DateTextBox.Text  , TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);
            if (x == 1)
            {
                errorlbl.Visible = true;
            }
            else
            {
                errorlbl.Visible = false;
            }
        }
    }
}