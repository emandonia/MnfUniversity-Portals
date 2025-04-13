using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using App_Code;
using Common;

namespace MnfUniversity_Portals.UI.Admin
{
    public partial class PasswordRecovery : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LinkButton1.PostBackUrl = "http://" + Request.Url.Authority + "/" + URLBuilder.CurrentOwnerAbbr(Page.RouteData) + "/StaffSearch/" + StaticUtilities.Currentlanguage(Page);

            }
        }

        protected void SubmitButtonOnClick(object sender, EventArgs e)
        {

           // var owner = StaffUsers_Utility.getstaffownerbyusername(TextBox1.Text);

        //    string doc = URLBuilder.fixedpath( PathType.Local, SiteFolders.Staff);
        //  StreamReader sr1 = new StreamReader(doc);
        //string text1 = sr1.ReadToEnd();
        //sr1.Close();
        //if (text1.Contains(@"<?xml"))// then the file is decrypted
        //{
        //    var doc1 = XDocument.Load(doc);
        //    if (doc1.Root != null)
        //    {
        //        var query = from c in doc1.Root.Descendants("UserItem")
        //                    where c.Attribute("UserName").Value == TextBox1.Text
        //                    select c;
        //        if (query.Any())
        //        {
        //            Panel2.Visible = false;
        //            foreach (var xElement in query)
        //            {
        //                Panel1.Visible = true;
        //                Label2.Text = xElement.Attribute("Password").Value;

        //            }

        //            StreamReader sr2 = new StreamReader(doc);
        //            string text2 = sr2.ReadToEnd();
        //            sr2.Close();
        //            //StreamWriter sw2 = new StreamWriter(doc);
        //            //sw2.Write(StaticUtilities.EncryptIt(text2));
        //            //sw2.Close();
        //        }
        //        else
        //        {
        //            Panel2.Visible = true;
        //        }
        //    }

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
        //    if (doc1.Root != null)
        //    {
        //        Panel2.Visible = false;
        //        var query = from c in doc1.Root.Descendants("UserItem")
        //                    where c.Attribute("UserName").Value == TextBox1.Text
        //                    select c;
        //        if (query.Any())
        //        {
        //            foreach (var xElement in query)
        //            {
        //                Panel1.Visible = true;
        //                Label2.Text = xElement.Attribute("Password").Value;

        //            }

        //            StreamReader sr2 = new StreamReader(doc);
        //            string text2 = sr2.ReadToEnd();
        //            sr2.Close();
        //            //StreamWriter sw2 = new StreamWriter(doc);
        //            //sw2.Write(StaticUtilities.EncryptIt(text2));
        //            //sw2.Close();
        //        }
        //        else
        //        {
        //            Panel2.Visible = true;
        //        }
            //}
        }
        
    }
}