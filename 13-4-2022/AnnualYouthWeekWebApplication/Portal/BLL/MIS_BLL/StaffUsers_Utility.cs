using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;
using BLL;
using Common;
using Mis_DAL;
using MnfUniversity_Portals;
using Portal_DAL;

namespace MisBLL
{
    public class StaffUsers_Utility
    {
public static void InsertNewStaffMembers(Page page)
{
   
     var allMisMembers = getAllStaffMembersInMis();
    foreach (var Member in allMisMembers)
    {
        if (!CheckIfMemberExistsInOwners(Member.SA_STF_MEMBER_ID))
        {
            string newAbbr;
            //if (Member.SA_STF_MEMBER_ID != null && (!string.IsNullOrEmpty(Member.STF_FULL_NAME_EN) && Member.STF_FULL_NAME_EN.Contains(" ")
            //                   && !Member.STF_FULL_NAME_EN.Contains(".") && !Member.STF_FULL_NAME_EN.Contains("/")))
            //{
            if (Member.STF_FULL_NAME_EN != null)
            {
                string[] words = Member.STF_FULL_NAME_EN.Split(' ');

                newAbbr = words[0] + "_" + words[words.Length - 1];
                if (Prtl_OwnersUtility.AbbrExists(newAbbr))
                    newAbbr = newAbbr + Member.SA_STF_MEMBER_ID.ToString();
            }
            else
            {
                newAbbr = Member.SA_STF_MEMBER_ID.ToString();
            }
            var newstf = Prtl_OwnersUtility.InsertNewStfOwner(newAbbr, Member.SA_STF_MEMBER_ID);
            var user = Membership.CreateUser(newAbbr, "12345");
            Prtl_UsersUtility.InsertUserInOwner(newstf.Owner_ID, newAbbr);
            // ReSharper disable PossibleNullReferenceException
            Prtl_TranslationUtility.InsertNewOwnerTrans(newstf.Owner_ID, Member.STF_FULL_NAME_AR, 1);
            Prtl_TranslationUtility.InsertNewOwnerTrans(newstf.Owner_ID, Member.STF_FULL_NAME_EN, 2);
            Prtl_UsersUtility.InsertNewUserInRole(Prtl_RolesUtility.GetRole("StaffRole").RoleId,
                (Guid) user.ProviderUserKey);

          //  AddMemberDataInXml(page, newAbbr, Member.STF_NATIONAL_ID_NUM, Member.SA_STF_MEMBER_ID.ToString());

        }


    }



}
public static prtl_Owner getstaffownerbyusername(string username)
{
    var dc = new PortalDataContextDataContext();
    var q1 = dc.aspnet_Users.SingleOrDefault(x=>x.LoweredUserName==username).UserId;
    var q2 = dc.prtl_OwnersAdminUsers.SingleOrDefault(xx=>xx.User_ID==q1).prtl_Owner;
    return q2;
}
        public static void AddMemberDataInXml(Page page,string username,string national_id,string password)
        {

            string doc = URLBuilder.fixedpath(PathType.Local, SiteFolders.Staff);
           
            StreamReader sr1 = new StreamReader(doc);
            string text1 = sr1.ReadToEnd();
            sr1.Close();
            if (text1.Contains(@"<?xml")) // then the file is decrypted
            {
                var doc1 = XDocument.Load(doc);
                if (doc1.Root != null)
                {
                    //var query = from c in doc1.Root.Descendants("UserItem")
                    //            where c.Attribute("UserName").Value == username
                    //            select c;
                    //if (!query.Any())
                    //{

                        var root = doc1.Element("Users");
                        root.Add(GetMenuXElement(national_id, password, username));
                        doc1.Save(URLBuilder.Path(page, PathType.Local, SiteFolders.Staff));
                        StreamReader sr2 = new StreamReader(doc);
                        string text2 = sr2.ReadToEnd();
                        sr2.Close();
                        //StreamWriter sw2 = new StreamWriter(doc);
                        //sw2.Write(StaticUtilities.EncryptIt(text2));
                        //sw2.Close();
                    //}

                }

            }
            else
            {
                //to read and decrypt
                StreamReader sr = new StreamReader(doc);
                string text = sr.ReadToEnd();
                sr.Close();
                //StreamWriter sw = new StreamWriter(doc);
                //sw.Write(StaticUtilities.DecryptIt(text));
                //sw.Close();
                var doc1 = XDocument.Load(doc);
                if (doc1.Root != null)
                {

                    //var query = from c in doc1.Root.Descendants("UserItem")
                    //            where c.Attribute("UserName").Value == username
                    //            select c;
                    //if (!query.Any())
                    //{
                        var root = doc1.Element("Users");
                        root.Add(GetMenuXElement(national_id, password, username));
                        doc1.Save(URLBuilder.Path(page, PathType.Local, SiteFolders.Staff));
                        StreamReader sr2 = new StreamReader(doc);
                        string text2 = sr2.ReadToEnd();
                        sr2.Close();
                        //StreamWriter sw2 = new StreamWriter(doc);
                        //sw2.Write(StaticUtilities.EncryptIt(text2));
                        //sw2.Close();
                    //}

                }
            }
        }
        public static bool CheckIfMemberExistsInOwners(decimal stfid)
        {
            return new PortalDataContextDataContext().prtl_Owners.Any(x => x.InitAbbr == stfid.ToString());

        }
public static List<SA_STF_MEMBER> getAllStaffMembersInMis()
{
    var dc = Global.M_dc;
    var query = (from x in dc.SA_STF_MEMBERs select x).ToList();
    return query;
}
        public static void getAllstaffMembersInOwners(Page page)
        {
            List<prtl_Owner> list = Prtl_OwnersUtility.getAllStaffMembers();
            var dc = Global.M_dc;
            var userxml = new XDocument(new XElement("Users"));
            var root = userxml.Element("Users");
            string StaffNationalId="";
            foreach (var prtlOwner in list)
            {
                MembershipUser user = GetMemberShipUser(Convert.ToDecimal(prtlOwner.InitAbbr));
                user.ChangePassword(user.ResetPassword(), "12345");
                var saStfMember = dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == Convert.ToDecimal(prtlOwner.InitAbbr));
                if (
                    saStfMember !=
                    null)
                    StaffNationalId =
                        saStfMember.STF_NATIONAL_ID_NUM;
                root.Add(GetMenuXElement(StaffNationalId, "12345",user.UserName));
            }
            userxml.Save(URLBuilder.Path(page, PathType.Local, SiteFolders.Staff));
        }
       
        static XElement GetMenuXElement(string UserNationalId,string Password,string username)
        {
            var element = new XElement("UserItem");
            element.SetAttributeValue("UserNationalId", UserNationalId);
            element.SetAttributeValue("Password", Password);
            element.SetAttributeValue("UserName", username); 
            element.ReplaceAttributes(element.Attributes().OrderBy(e => e.Name.ToString()));
            return element;
        }
        public static MembershipUser GetMemberShipUser(decimal memberid)
        {

            var ownerid = Staff_Utility.getStfOwner(memberid);
            if (ownerid != null)
            {
                var username = Staff_Utility.getStfUser(ownerid.Owner_ID).UserName;
               bool xx= Staff_Utility.getStfUser(ownerid.Owner_ID).IsAnonymous;
               var x = Membership.GetUser(username);
             var d=   Membership.ApplicationName;
               
                return x;
            }
var id = Staff_Utility.getStf(memberid);
if (id == null) { }
                string newAbbr;
                if (id != null && (!string.IsNullOrEmpty(id.STF_FULL_NAME_EN) && id.STF_FULL_NAME_EN.Contains(" ")
                                   && !id.STF_FULL_NAME_EN.Contains(".") && !id.STF_FULL_NAME_EN.Contains("/")))
                {
                    string[] words = id.STF_FULL_NAME_EN.Split(' ');

                    newAbbr = words[0] + "_" + words[words.Length - 1];
                    if (Prtl_OwnersUtility.AbbrExists(newAbbr))
                        newAbbr = memberid.ToString();
                }
                else
                
                    newAbbr = memberid.ToString();
                    var newstf = Prtl_OwnersUtility.InsertNewStfOwner(newAbbr, memberid);
                     var user = Membership.CreateUser(newAbbr, memberid.ToString());
                    Prtl_UsersUtility.InsertUserInOwner(newstf.Owner_ID, newAbbr);
                    // ReSharper disable PossibleNullReferenceException

                    Prtl_UsersUtility.InsertNewUserInRole(Prtl_RolesUtility.GetRole("StaffRole").RoleId,
                        (Guid) user.ProviderUserKey);
                    // ReSharper restore PossibleNullReferenceException


                    //Prtl_MenuUtility.InsertParentMenuItem(newstf.Owner_ID, "StaffDetails",
                    //                                      translations: new[]
                    //                                          {
                    //                                              new Translation { lcid = "ar", translation = "السيرة الذاتية" },
                    //                                              new Translation { lcid = "en", translation = "Curriculum Vitae" }
                    //                                          }
                    //                                      );
                    return user;
                
                 
           
        }

        public static void ImportMISEmails()
        {
            var dc = Global.M_dc;
            foreach (SA_STF_MEMBER Staff in dc.SA_STF_MEMBERs)
            {
                var staffEmails =
                    Staff.GS_CONTACT_METHOD_H.GS_CONTACT_METHOD_Ds.Where(y => y.GS_CODE_CONTACT_METHOD_ID == 2).Select(
                        r => r.METHOD_DESCR);
                string emails = null;
                foreach (var email in staffEmails)
                {
                    if (!string.IsNullOrEmpty(email) &&
                        Regex.IsMatch(email, @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                             + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
	                                                                        			[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
	                                                                        			[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                             + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$"))
                        emails += email + ";";
                }
                var user = GetMemberShipUser(Staff.SA_STF_MEMBER_ID);
                user.Email = emails;
                Membership.UpdateUser(user);
            }
        }
        public static void SetUserNotified(object userid)
        {
            var dc = new PortalDataContextDataContext();
            dc.aspnet_Users.Single(u => u.UserId.ToString() == userid.ToString()).IsPasswordInformed = true;
            dc.SubmitChanges();
        }
        public static bool IsUserNotified(object userid)
        {
            var dc = new PortalDataContextDataContext();
            return dc.aspnet_Users.Single(u => u.UserId.ToString() == userid.ToString()).IsPasswordInformed;

        }

        public static string SendStaffPasswordViaEmail(string nationalID,string emailsubject, string emailbody)
        {
            var member = Staff_Utility.getStfByNationalId(nationalID);
            if (member == null)
                return "This National ID doesn't exist.";
            var user = GetMemberShipUser(member.SA_STF_MEMBER_ID);
            if (string.IsNullOrEmpty(user.Email))
                return "The member has no registerd email and the details for his account are<br/>" +
                       "User Name:" + user.UserName + "<br/>" +
                       "Password :" + user.ResetPassword();
            return SendStaffEmail(user,emailsubject,emailbody, false);
        }
        public static string SendStaffEmail(string username, string emailsubject, string emailbody, bool checkUserNotified)
        {
            return SendStaffEmail(Membership.GetUser(username),emailsubject,emailbody, checkUserNotified);
        }

        public static string SendStaffEmail(MembershipUser user,string emailsubject, string emailbody, bool checkUserNotified)
        {
            string errors = null;

            if (!string.IsNullOrEmpty(user.Email) && user.Email.EndsWith(";") && Roles.IsUserInRole(user.UserName, "StaffRole") && ((checkUserNotified && !IsUserNotified(user.ProviderUserKey)) || !checkUserNotified))
            {
                //string URL = "http://193.227.24.22/" +
                //             Staff_Utility.getStfOwner(user.ProviderUserKey).Abbr;
                string URL = "http://mu.menofia.edu.eg/" +
                             Staff_Utility.getStfOwner(user.ProviderUserKey).Abbr;
                 emailbody =
                    emailbody.Replace("{UserName}", user.UserName).Replace("{NewPassword}", user.ResetPassword()).
                        Replace("{StaffURL}", URL);
                
                bool sent;
                errors = SendEmail(user.Email, emailsubject, emailbody, out sent);
                if (sent)
                    SetUserNotified(user.ProviderUserKey);
            }
            return errors;
        }

        public static string SendStaffEmail(string emailsubject, string emailbody,bool checkUserNotified)
        {
            var users = Membership.GetAllUsers();
            string result = null;
            foreach (MembershipUser user in users)
                result += SendStaffEmail(user,emailsubject,emailbody ,checkUserNotified);
            return result;
        }

        public static string SendEmail(string Toemails, string subject, string body, out bool sent)
        {
            sent = false;
            string errors = null;
            var message = new MailMessage();
            //var fromAddress = new MailAddress("mnfportal@gmail.com");
            // var smtpClient = new SmtpClient
            // {
            //     Host = "smtp.gmail.com",
            //     Port = 587,
            //     EnableSsl = true,
            //     DeliveryMethod = SmtpDeliveryMethod.Network,
            //     UseDefaultCredentials = false,
            //     Credentials = new NetworkCredential("mnfportal@gmail.com", "P0rt@lAdm!n")
            // };
            var fromAddress = new MailAddress("admin@mnfportal.menofia.edu.eg");
            var smtpClient = new SmtpClient("localhost");




            message.From = fromAddress;
            message.Subject = subject;
            //Set IsBodyHtml to true means you can send HTML email.
            message.IsBodyHtml = true;
            message.Body = body;
            try
            {
                if (Toemails.EndsWith(";"))
                {
                    var emails = Toemails.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var email in emails)
                        if (!message.To.Contains(new MailAddress(email)))
                            message.To.Add(email);
                }




                smtpClient.Send(message);

                sent = true;
            }
            catch (Exception ex)
            {
                //Error, could not send the message
                errors += ex.Message;
            }
            return errors;
        }

        public static string InsertNewStaffMember(decimal id,Page page)
        {
            if (!CheckIfMemberExistsInOwners(id))
            {
                var Member = Global.M_dc.SA_STF_MEMBERs.SingleOrDefault(x => x.SA_STF_MEMBER_ID == id);
                string newAbbr="";
                if (Member != null)
                {
                    if (Member.STF_FULL_NAME_EN != null)
                    {
                        string[] words = Member.STF_FULL_NAME_EN.Split(' ');

                        newAbbr = words[0] + "_" + words[words.Length - 1];
                    }else
                    {
                        newAbbr = Member.SA_STF_MEMBER_ID.ToString();
                    }
                    if (Prtl_OwnersUtility.AbbrExists(newAbbr))
                        newAbbr = newAbbr + Member.SA_STF_MEMBER_ID.ToString();

                    var newstf = Prtl_OwnersUtility.InsertNewStfOwner(newAbbr, Member.SA_STF_MEMBER_ID);
                    var user = Membership.CreateUser(newAbbr, Member.SA_STF_MEMBER_ID.ToString());
                    Prtl_UsersUtility.InsertUserInOwner(newstf.Owner_ID, newAbbr);
                    // ReSharper disable PossibleNullReferenceException
                    Prtl_TranslationUtility.InsertNewOwnerTrans(newstf.Owner_ID, Member.STF_FULL_NAME_AR, 1);
                    if (Member.STF_FULL_NAME_EN != null)
                    {
                        Prtl_TranslationUtility.InsertNewOwnerTrans(newstf.Owner_ID, Member.STF_FULL_NAME_EN, 2);
                    }else
                    {
                        Prtl_TranslationUtility.InsertNewOwnerTrans(newstf.Owner_ID, "", 2);
                    }
                    Prtl_UsersUtility.InsertNewUserInRole(Prtl_RolesUtility.GetRole("StaffRole").RoleId,
                                                          (Guid)user.ProviderUserKey);

                    AddMemberDataInXml(page, newAbbr, Member.STF_NATIONAL_ID_NUM, Member.SA_STF_MEMBER_ID.ToString());
                }

                return newAbbr;
            }else
            {
                return "";
            } 

        }
    }
}