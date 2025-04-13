using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Net.Mail;
using App_Code;
namespace MnfUniversity_Portals.UI
{
    public partial class CompEmployee : PageBase
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
                smtpClient.Credentials = new System.Net.NetworkCredential("mfcomplains@gmail.com", "menofia_2015");

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                //   mail.From = new MailAddress("mnfportal@gmail.com", "mnfportal@");

                mail.From = new MailAddress(txtEmail.Text);
                mail.To.Add(new MailAddress("mfcomplains@gmail.com"));
                mail.CC.Add(new MailAddress("mnfportal@gmail.com"));
                string sub = "";
                if(DropDownList1 .SelectedValue =="1")
                {
                    sub="شكوى";
                }else if(DropDownList1 .SelectedValue =="2")
                {
                    sub="مقترح";
                }else if(DropDownList1 .SelectedValue =="3")
                {
                    sub="استفسار";
                }

                mail.Subject =sub ;

                string str = "Name is     :" + txtName.Text + Environment.NewLine + Environment.NewLine + " Mobile is     :" + txtMobile.Text + Environment.NewLine + Environment.NewLine + "Body is     :" + txtComp.Text;
             //  str =  str.replace(/\n/g, '<br />');
             //   mail.Body = "Name is :" + txtName.Text + "<br/> Mobile is :" + txtMobile.Text + "<br/>" + "Body is :" + txtComp.Text;
                mail.Body =str ;
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
            int x=Convert .ToInt32 ( DropDownList1 .SelectedValue );
            //if(RadioButton1.Checked ==true  )
            //{
            //    x=1;
            //}else if(RadioButton2 .Checked ==true )
            //{
            //    x=2;
            //}else
            //{
            //    x=3;
            //}

            Prtl_ComplainUtility.InsertForEmp(txtName.Text, txtMobile.Text, txtEmail.Text, txtComp.Text, CurrentOwner.Owner_ID, true , x);
        }
    }
}