using BLL;
using MnfUniversity_Portals.Base_Code;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;
using MnfUniversity_Portals.UserControls.Viewers;
using Portal_DAL;

namespace MnfUniversity_Portals.Masterpages
{

    public partial class SiteMaster : MasterBase
    {

        #region Methods










        internal MenuViewer MenuViewer
        {
            get { return MenuViewerControl; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.SessionID == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

            if (Page.Request["__ASYNCPOST"] != "true")
            {

                //SubEntitiesLabel.Text = SetSubLabel(Page);
                //FillSubOwners();
                StaticUtilities.AddSiteIcon(Page);
            }
            if (!Page.IsPostBack)
            {
                AddJsFiles(Page);
                ShowErrorMessage();
                Image1.ImageUrl = URLBuilder.FooterURL(Page);
HorizontalMenu.Build(MenuMode.Normal);
                
            }
        }

        /// <summary>
        /// When the Theme Dropdownlist is databound it selects the current theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        protected void Themeddl_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Themeddl.SelectedValue = Page.Theme;
        }


        private void AddJsFiles(Page page)
        {
            string[] jsFiles = { "~/Scripts/jquery-1.9.1.min.js",
                                 "~/Scripts/js.js",
                                 "~/Scripts/languageswitcher.js"
                                                               };
            foreach (var jsFile in jsFiles)
            {
                var scriptTag = new HtmlGenericControl { TagName = "script" };
                scriptTag.Attributes.Add("type", "text/javascript");
                scriptTag.Attributes.Add("src", page.ResolveClientUrl(jsFile));
                page.Header.Controls.Add(scriptTag);
            }
        }





       



        #endregion Methods


    }
}