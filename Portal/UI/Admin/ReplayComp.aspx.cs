using App_Code;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Portal_DAL;
namespace MnfUniversity_Portals.UI
{
    public partial class ReplayComp : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["NewsOwner_ID"] = URLBuilder.CurrentOwnerid(Page.RouteData);
                //ListView2.DataBind();
            }

            
        }

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
            var Linkbutton = (LinkButton)sender;

            Editor_ModalPopupExtender.Show();



            Session["iddd"] = Linkbutton.CommandArgument;


        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {


                trySend(Prtl_ComplainUtility.getComplainantByCompsID((string)Session["iddd"]));

                Prtl_ComplainUtility.Insertreplay(TextBox1.Text, Convert.ToString(Session["iddd"]));
                sentlabel.Text = "Message Sent successfully.";
            }
            catch (Exception ex)
            {

                sentlabel.Text = "Message not Sent Unsuccessfully";
            }
        }
        public void trySend(string tomail)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("mnfportal@gmail.com", "mnfportal@");

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("mnfportal@gmail.com", "mnfportal@");
            mail.To.Add(new MailAddress(tomail));
            mail.Body = TextBox1.Text;

            smtpClient.Send(mail);

            //MessageBox.Show("mail Send");


        }

        protected void linkbutton2_Click(object sender, EventArgs e)
        {
            var Linkbutton = (LinkButton)sender;

            ModalPopupExtender1.Show();



            Session["iddd2"] = Linkbutton.CommandArgument;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {



            try
            {
                string answerurl="";
                if(URLBuilder.CurrentOwnerAbbr(Page.RouteData)==null){
                    answerurl = "http://" + Request.Url.Authority +  "/Answer/" + Convert.ToInt32(Session["iddd2"]) + "/" + StaticUtilities.Currentlanguage(Page.RouteData);
            }else{
                answerurl = "http://" + Request.Url.Authority +  "/" +URLBuilder.CurrentOwnerAbbr(Page.RouteData)+"/Answer/"+ Convert.ToInt32(Session["iddd2"]) + "/" + StaticUtilities.Currentlanguage(Page.RouteData);
            }
                string body ="السيد الاستاذ الدكتور- تحية طيبة-الرجاء من سيادتكم التفضل بالرد علي الشكوي التالية: "+ Prtl_ComplainUtility.getTextComplain(Convert.ToInt32(Session["iddd2"]))+
                    "<br/><br/>"+"نرجو من سيادتكم استخدام الرابط التالي للرد علي الشكوي: "+answerurl;
                //string body = Prtl_ComplainUtility.getTextComplain(Convert.ToInt32(Session["iddd2"]));


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                Prtl_FacultiesEmail x = Prtl_ComplainUtility.getfacemail(URLBuilder.CurrentOwnerid(Page.RouteData).ToString());
                smtpClient.Credentials = new System.Net.NetworkCredential("mnfportal@gmail.com", "mnfportal@");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                //mail.From = new MailAddress("portal.menoufia@gmail.com", "Mnf12345");
              
                mail.From = new MailAddress("mnfportal@gmail.com");
                
                mail.To.Add(new MailAddress(txtEmail.Text));
                mail.Body = body;
                mail.Subject = txtsub.Text;
                smtpClient.Send(mail);
                Prtl_ComplainUtility.insert_SendToDrDate((string)Session["iddd2"]);
                sentlabel.Text = "Message Sent successfully.";
            }
            catch (Exception ex)
            {

                sentlabel.Text = "Message not Sent Unsuccessfully";
            }


        }
    }
}