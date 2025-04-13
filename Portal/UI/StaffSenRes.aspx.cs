using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;

namespace MnfUniversity_Portals.UI
{
    public partial class StaffSenRes : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Prtl_OwnersUtility.getStaffIDbyAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));

                string Where = "Staff_ID ==@StaffID";
                LinqDataSource1.WhereParameters.Add("StaffID", DbType.Int32, id.ToString());

                LinqDataSource1.Where = Where;
                LinqDataSource1.DataBind();

                ListView1.DataSource = LinqDataSource1;
                ListView1.DataBind();
            }
        }

        protected string GetUrl(object eval)
        {
          //  Label x = (Label) ListView1.FindControl("FilesLabel");
        
           
            
            string c = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
           
                string s1 ="http://" + Request.Url.Authority + "/uni/Portal/SentficResearches/" + c+"/"+ eval .ToString()  ;

            string s2=Server.MapPath( "/uni/Portal/SentficResearches/" + c+"/"+ eval .ToString() ) ;
       string s3=    URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/SentficResearches/" + c + "/"+ eval .ToString() ;

            return s3;
            //string x = Server.MapPath("/uni/Portal/SentficResearches/") ;
            //return (x + URLBuilder.CurrentOwnerAbbr).to;
        }

        protected void Details_OnClick(object sender, EventArgs e)
        {
            //string filePath = (sender as LinkButton).CommandArgument;
            //Response.ContentType = ContentType;
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            //Response.WriteFile(filePath);
            //Response.End();


            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            // find other controls:
            var Details = (LinkButton)item.FindControl("Details");

            string c = URLBuilder.CurrentOwnerAbbr(Page.RouteData);
            Response.ContentType = "APPLICATION/OCTET-STREAM";
            String Header = "Attachment; Filename=XMLFile.xml";
            Response.AppendHeader("Content-Disposition", Header);
            string s1 = URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/SentficResearches/" + c + "/" + Details.CommandArgument.ToString();
          
            System.IO.FileInfo Dfile = new System.IO.FileInfo(s1);


             Response.WriteFile(Dfile.FullName);
            //Don't forget to add the following line
            Response.End();
        }
    }
}