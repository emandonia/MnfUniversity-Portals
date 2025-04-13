using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using App_Code;
using BLL;
using Common;
using MisBLL;
using Portal_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffEmail : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Mis_DAL.SA_STF_MEMBER staffmember = Staff_Utility.getStfByNationalId(TextBox1.Text);

            if (staffmember == null)
            {
                ErrorMsg.Visible = true;
                Panel1.Visible = false;
                ErrorMsg.Text = (string)GetLocalResourceObject("StaffSearch_Button1_Click_No_Staff_Member");

            }
            else
            {
                string email; string password;
                Staff_Utility.getStfEmail(TextBox1.Text, out email, out password);

                Panel1.Visible = true;
                EmailLabel.Text = email;
                PasswordLabel.Text = password;

            }




        }
    }
}