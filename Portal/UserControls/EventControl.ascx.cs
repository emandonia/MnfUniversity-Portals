using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using MnfUniversity_Portals.Base_Code;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls
{
    public partial class EventControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! IsPostBack )
            {
                var dc = new PortalDataContextDataContext();

                Guid abbr = URLBuilder.CurrentOwnerid(Page.RouteData);
                string lcid = StaticUtilities.Currentlanguage(Page.RouteData);
               
                
                List<prtl_Highlight > xx = (from c in dc.prtl_Highlights 
                                             where c.Published == true&&
                                             
                                             c.Owner_ID  == abbr 
                                            
                                             select c).ToList();


               // List<prtl_Translation> xx = (from c in dc.prtl_Translations where c.prtl_Highlight.Published == true select c).Take(4).ToList();


                NewsListView.DataSource = xx;
                NewsListView.DataBind();




            }
            
        }
        public string getData(int Highlight_Id)
        {
            var dc = new PortalDataContextDataContext();
            prtl_Highlight ddddc = (from f in dc.prtl_Highlights where f.Highlight_Id == Highlight_Id select f).SingleOrDefault();
          
            
            prtl_Translation x = (from c in dc.prtl_Translations
                                  where c.Translation_ID == ddddc.Translation_ID   
                                   && c.prtl_Language .LCID  == StaticUtilities .Currentlanguage (Page .RouteData)   
                               select c).SingleOrDefault ();
                              
           return Decode(x.Translation_Data );
        }
        public string Decode(object data)
        {
            return Page.Server.HtmlDecode(data == null ? "" : data.ToString());
        }
    }
}