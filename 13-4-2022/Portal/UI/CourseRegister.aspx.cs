using App_Code;
using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class CourseRegister : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int courseID = Convert.ToInt32(Page.RouteData.Values["id"]);
                var dc = new PortalDataContextDataContext();
                {
                    string x = (from c in dc.Prtl_Courses where c.ID == courseID select c.CourseName).SingleOrDefault().ToString();
                    lblMsg.Text = "يتم التسجيل فى دورة " + "  " + x;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = Convert.ToInt32(Page.RouteData.Values["id"]);

                var dc = new PortalDataContextDataContext();
                var x = new Prtl_C_Student
                {
                    Name_Ar = TextBox1.Text,
                    Name_En = TextBox2.Text,
                    NationalID = TextBox3.Text,

                    Address = TextBox4.Text,
                    Job = TextBox5.Text,
                    Work_Place = TextBox6.Text,
                    Mail = TextBox7.Text,
                    Mobile = TextBox8.Text,
                    phone = TextBox9.Text,
                    CourseID = courseID
                };

                dc.Prtl_C_Students.InsertOnSubmit(x);
                dc.SubmitChanges();

                Prtl_Course v = (from c in dc.Prtl_Courses where c.ID == courseID select c).SingleOrDefault();
                v.used =true ;
                dc.SubmitChanges();



                Label10.Text ="شكرا  تم التسجيل بنجاح";

                lblMsg.Text = "";

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";

                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";

            }
            catch
            {
                Label10.Text = " ناسف حدث خطا";
            }
            //dc..InsertOnSubmit(x);
            
        }
    }
}