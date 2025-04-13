using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Net.Mail;
using App_Code;
using MisBLL;
using Portal_DAL;
using System.IO;
namespace MnfUniversity_Portals
{
    public partial class sendMailGroup : PageBase
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
               // mail.From = new MailAddress(txtEmail.Text);


                //string mailfrom = "mnfportal@gmail.com";
                //string passfrom = "mnfportal@";

                string mailfrom = SendMailGroupUtility.getSendMail(Convert.ToInt32(FacDropDownList.SelectedValue)).MailFrom;
                string passfrom = SendMailGroupUtility.getSendMail(Convert.ToInt32(FacDropDownList.SelectedValue)).pass;
                mail.From = new MailAddress(mailfrom, passfrom);

                List<prtl_StaffGroupMail> xx = SendMailGroupUtility.getSendTOMail(Convert.ToInt32(FacDropDownList.SelectedValue), Convert.ToInt32(DepDropDownList.SelectedValue));
                //foreach (var x in xx)
                //{
                //    mail.To .Add(new MailAddress(x.StaffGrpMail ));
                //}
                mail.To.Add(new MailAddress("eng_fatma_shawky@yahoo.com"));
                mail.Bcc .Add(new MailAddress("asmaa_el-battanony_3@hotmail.com"));

                mail.CC .Add(new MailAddress("gamal.attiya@yahoo.com"));
                mail.CC.Add(new MailAddress("mnfportal@gmail.com"));

              //  mail.Body = "Name is :" + txtName.Text + "<br/> Mobile is :" + txtMobile.Text + "<br/>" + "Body is :" + txtComp.Text;
                mail.Subject = txtSubj.Text;
                mail.Body = txtComp.Text;

                string fileName = Path.GetFileName(InsertAsyncFileUpload1.PostedFile.FileName);
                Attachment myAttachment = new Attachment(InsertAsyncFileUpload1.FileContent, fileName);
                mail.Attachments.Add(myAttachment);


                smtpClient.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            trySend();

             
        }
     
    }
}