using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Net.Mail;

namespace MnfUniversity_Portals.UI
{
    public partial class Complains : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void trySend()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("mnfportal@gmail.com", "mnfportal@");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
             //   mail.From = new MailAddress("mnfportal@gmail.com", "mnfportal@");
                mail.From = new MailAddress(txtEmail .Text );
                mail.To.Add(new MailAddress("mnfportal@gmail.com"));
                mail.Body ="Name is :"+txtName .Text +"<br/> Mobile is :"+txtMobile .Text +"<br/>"+"Body is :" +txtComp.Text;
                //mail.Subject = txtSubj.Text;



                smtpClient.Send(mail);
                sentlabel.Text = "Message Sent successfully.";
            }
            catch (Exception ex)
            {
                sentlabel.Text = "Message not Sent Unsuccessfully";
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            trySend();

            Prtl_ComplainUtility.Insert(txtName.Text, txtMobile.Text, txtEmail.Text, txtComp.Text, CurrentOwner.Owner_ID );
        }
    }
}  