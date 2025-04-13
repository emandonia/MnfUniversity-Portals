#region imports

using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using App_Code;
using Common;
using MisBLL;
using BLL;

#endregion imports

public partial class Admin_ChangePassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

  

    protected void changedPassword(object sender, EventArgs e)
    {
        string username = Page.User.Identity.Name;   
        string newpass = ChangePassword1.NewPassword;
        var owner = StaffUsers_Utility.getstaffownerbyusername(username);
        if (owner.Type == 3)
        {
            Prtl_OwnersUtility.updatestaffpassword(StaffUsers_Utility.getstaffownerbyusername(username), newpass);
        }
        //string doc = URLBuilder.fixedpath( PathType.Local, SiteFolders.Staff);
        //StreamReader sr1 = new StreamReader(doc);
        //string text1 = sr1.ReadToEnd();
        //sr1.Close();
        //if(text1.Contains(@"<?xml"))// then the file is decrypted
        //{
        //    var doc1 = XDocument.Load(doc);
        //    var query = from c in doc1.Root.Descendants("UserItem")
        //                where c.Attribute("UserName").Value == username
        //                select c;
        //    foreach (var xElement in query)
        //    {
        //        xElement.SetAttributeValue("Password",newpass);
                
        //    }
        //    doc1.Save(doc);
        //    StreamReader sr2 = new StreamReader(doc);
        //    string text2 = sr2.ReadToEnd();
        //    sr2.Close();
        //    //StreamWriter sw2 = new StreamWriter(doc);
        //    //sw2.Write(StaticUtilities.EncryptIt(text2));
        //    //sw2.Close();
        //}else
        //{
        //    //to read and decrypt
        //    StreamReader sr = new StreamReader(doc);
        //    string text = sr.ReadToEnd();
        //    sr.Close();
        //    //StreamWriter sw = new StreamWriter(doc);
        //    //sw.Write(StaticUtilities.DecryptIt(text));
        //    //sw.Close();
        //    var doc1 = XDocument.Load(doc);
        //    var query = from c in doc1.Root.Descendants("UserItem")
        //                where c.Attribute("UserName").Value == username
        //                select c;
        //    foreach (var xElement in query)
        //    {
        //        xElement.SetAttributeValue("Password", newpass);

        //    }
        //    doc1.Save(doc);
        //    StreamReader sr2 = new StreamReader(doc);
        //    string text2 = sr2.ReadToEnd();
        //    sr2.Close();
        //    //StreamWriter sw2 = new StreamWriter(doc);
        //    //sw2.Write(StaticUtilities.EncryptIt(text2));
        //    //sw2.Close();
        //}
    }
}