using App_Code;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class Answer : PageBase
    {


        public string getcomp()
        {

            var q = Prtl_ComplainUtility.GetComplainByID((string)Page.RouteData.Values["id"]);



            return q.Text;

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try{

            
            TextBox t1=(TextBox)FormView1.FindControl("TextBox1");
TextBox t2=(TextBox)FormView1.FindControl("TextBox2");

Prtl_ComplainUtility.insertReplay2(t1.Text, t2.Text, (string)Page.RouteData.Values["id"]);
Prtl_ComplainUtility.insert_DrAnswerDate((string)Page.RouteData.Values["id"]);
sentlabel.Text = "Message Sent successfully.";
            } catch (Exception ex)
            {

                sentlabel.Text = "Message not Sent Unsuccessfully";
            }


        }
    }
}