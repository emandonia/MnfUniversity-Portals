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
    public partial class StaffSearch : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //StaffUsers_Utility. getAllstaffMembersInOwners(this);

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
                MembershipUser user = StaffUsers_Utility.GetMemberShipUser(staffmember.SA_STF_MEMBER_ID);
                //if (StaffUsers_Utility.IsUserNotified(user.ProviderUserKey))
                //{
                //    ErrorMsg.Visible = true;
                //    Panel1.Visible = false;
                //    var localResourceObject = (string) GetLocalResourceObject("Password_Is_Set");
                //    if (localResourceObject != null)
                //        ErrorMsg.Text = localResourceObject.Replace("{UserName}", user.UserName);
                //}
                //else
                //{


                ErrorMsg.Visible = false;
                Panel1.Visible = true;
                var owner = Staff_Utility.getStfOwner(staffmember.SA_STF_MEMBER_ID);
                StaffURLHyperLink.Text = URLBuilder.FilesHomeServer + "/" + owner.Abbr;
                StaffURLHyperLink.NavigateUrl = URLBuilder.FilesHomeServer + "/" + owner.Abbr;
              //  user.ChangePassword(user.ResetPassword(), "12345");
                UserNameLabel.Text = user.UserName;
                user.IsApproved = true;
                if (user.IsLockedOut)
                {
                    user.UnlockUser();
                }
                //user.ResetPassword("12345");
                //**************//
user.ChangePassword(user.ResetPassword(), "12345");
                
                PasswordLabel.Text = Staff_Utility.getMemberPassword(owner.Abbr);
                //string doc = URLBuilder.fixedpath(PathType.Local, SiteFolders.Staff);
                //    StreamReader sr1 = new StreamReader(doc);
                //    string text1 = sr1.ReadToEnd();
                //    sr1.Close();
                //    if (text1.Contains(@"<?xml")) // then the file is decrypted
                //    {
                //        var doc1 = XDocument.Load(doc);
                //        if (doc1.Root != null)
                //        {
                //            var query = from c in doc1.Root.Descendants("UserItem")
                //                        where c.Attribute("UserName").Value == user.UserName
                //                        select c;
                //            if (query.Any())
                //            {

                //                foreach (var xElement in query)
                //                {
                //                    Panel1.Visible = true;


                //                }

                //                StreamReader sr2 = new StreamReader(doc);
                //                string text2 = sr2.ReadToEnd();
                //                sr2.Close();
                //                //StreamWriter sw2 = new StreamWriter(doc);
                //                //sw2.Write(StaticUtilities.EncryptIt(text2));
                //                //sw2.Close();
                //            }

                //        }

                //    }
                //    else
                //    {
                //        //to read and decrypt
                //        StreamReader sr = new StreamReader(doc);
                //        string text = sr.ReadToEnd();
                //        sr.Close();
                //        //StreamWriter sw = new StreamWriter(doc);
                //        //sw.Write(StaticUtilities.DecryptIt(text));
                //        //sw.Close();
                //        var doc1 = XDocument.Load(doc);
                //        if (doc1.Root != null)
                //        {

                //            var query = from c in doc1.Root.Descendants("UserItem")
                //                        where c.Attribute("UserName").Value == user.UserName
                //                        select c;
                //            if (query.Any())
                //            {
                //                foreach (var xElement in query)
                //                {

                //                    PasswordLabel.Text = xElement.Attribute("Password").Value;

                //                }

                //                StreamReader sr2 = new StreamReader(doc);
                //                string text2 = sr2.ReadToEnd();
                //                sr2.Close();
                //                //StreamWriter sw2 = new StreamWriter(doc);
                //                //sw2.Write(StaticUtilities.EncryptIt(text2));
                //                //sw2.Close();
                //            }

                //        }
                //    }


                //}



            }
        }

        }
}