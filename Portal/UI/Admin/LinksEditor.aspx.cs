using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using App_Code;
using Common;

namespace MnfUniversity_Portals.UI.Admin
{
    public partial class LinksEditor : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updatelinks(object sender, EventArgs e)
        {
            
            string doc = URLBuilder.Path(Page, PathType.Local, SiteFolders.RightLeftLinks,"Links.xml");
            var doc1 = XDocument.Load(doc);
            if (TextBox1.Text != "")
            {
                var s = StaticUtilities.OwnerID(Page).ToString();
                var query = (from c in doc1.Root.Descendants("MenuItem")
                            where c.Attribute("OwnerId").Value ==s  && c.Attribute("MenuItemType").Value=="Link1"
                            select c).SingleOrDefault();
                query.SetAttributeValue("Url", TextBox1.Text);
                doc1.Save(doc);
                Label5.Visible = true;
                Label5.Text = (string) GetLocalResourceObject("LinksEditor_updatelinks_updated_Succefully");
            }
            if (TextBox2.Text != "")
            {
                var query = (from c in doc1.Root.Descendants("MenuItem")
                             where c.Attribute("OwnerId").Value == StaticUtilities.OwnerID(Page).ToString() && c.Attribute("MenuItemType").Value == "Link2"
                             select c).SingleOrDefault();
                query.SetAttributeValue("Url", TextBox2.Text);
                doc1.Save(doc);
                Label5.Visible = true;
                Label5.Text = (string)GetLocalResourceObject("LinksEditor_updatelinks_updated_Succefully");
            }
            if (TextBox3.Text != "")
            {
                var query = (from c in doc1.Root.Descendants("MenuItem")
                             where c.Attribute("OwnerId").Value == StaticUtilities.OwnerID(Page).ToString() && c.Attribute("MenuItemType").Value == "Link3"
                             select c).SingleOrDefault();
                query.SetAttributeValue("Url", TextBox3.Text);
                doc1.Save(doc);
                Label5.Visible = true;
                Label5.Text = (string)GetLocalResourceObject("LinksEditor_updatelinks_updated_Succefully");
            }
            if (TextBox4.Text != "")
            {
                var query = (from c in doc1.Root.Descendants("MenuItem")
                             where c.Attribute("OwnerId").Value == StaticUtilities.OwnerID(Page).ToString() && c.Attribute("MenuItemType").Value == "Link4"
                             select c).SingleOrDefault();
                query.SetAttributeValue("Url", TextBox4.Text);
                doc1.Save(doc);
                Label5.Visible = true;
                Label5.Text = (string)GetLocalResourceObject("LinksEditor_updatelinks_updated_Succefully");
            }
        }
    }
}