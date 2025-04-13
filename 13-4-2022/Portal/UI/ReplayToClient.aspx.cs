using App_Code;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class ReplayToClient : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string getcomp()
        {

            var q = Prtl_ComplainUtility.GetComplainByID((string)Page.RouteData.Values["id"]);



            return q.Text;

        }
        public string getReplay()
        {

            var q = Prtl_ComplainUtility.GetComplainAnsByID((string)Page.RouteData.Values["id"]);



            return q.Replay;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string body = "بخصوص شكواكم:"+getcomp() + "<br/><br/>" +
                    "الرد هو:  "+getReplay();
                //string body = Prtl_ComplainUtility.getTextComplain(Convert.ToInt32(Session["iddd2"]));


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new System.Net.NetworkCredential("mnfportal@gmail.com", "mnfportal@");
                smtpClient.Credentials = new System.Net.NetworkCredential("mnfportal@gmail.com", "mnfportal@");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                //mail.From = new MailAddress("portal.menoufia@gmail.com", "Mnf12345");
                Prtl_FacultiesEmail x = Prtl_ComplainUtility.getfacemail(URLBuilder.CurrentOwnerid(Page.RouteData).ToString());
                mail.From = new MailAddress("mnfportal@gmail.com");

                mail.To.Add(new MailAddress(Prtl_ComplainUtility.getComplainantByCompsID((string)Page.RouteData.Values["id"])));
                mail.Body = body;
                mail.Subject = "رد علي شكواكم";
                smtpClient.Send(mail);
                Prtl_ComplainUtility.insert_SendToClientDate((string)Page.RouteData.Values["id"]);
                sentlabel.Text = "Message Sent successfully.";
            }
            catch (Exception ex)
            {

                sentlabel.Text = "Message not Sent Unsuccessfully";
            }
        }
    }
}