using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.UI.WebControls;
using App_Code;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffServices : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("mnfportal@gmail.com");

                mail.From = new MailAddress(TextBox4.Text);

                string Body = TextBox5.Text;
                mail.Body = Body;

                var smtpClient = new SmtpClient
                                     {
                                         Host = "smtp.gmail.com",
                                         Port = 587,
                                         EnableSsl = true,
                                         DeliveryMethod = SmtpDeliveryMethod.Network,
                                         UseDefaultCredentials = false,
                                         Credentials = new NetworkCredential("mnfportal@gmail.com", "P0rt@lAdm!n")
                                     };
                //Or your Smtp Email ID and Password
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                sentlabel.Text = "Message Sent Succssefully.";
                //var fromAddress = new MailAddress("mnfportal@gmail.com");
            }catch(Exception e)
            {
                sentlabel.Text = "Message not Sent Succssefully.";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendMail();
        }
    }
}