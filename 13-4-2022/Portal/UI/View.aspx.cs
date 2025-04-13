using System;
using System.Web.UI.WebControls;
using App_Code;
using BLL;

namespace MnfUniversity_Portals.UI
{
    public partial class View : PageBase
    {
        protected void ArticleDetailsViewControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            ViewControl1.DataBind();
        }

        protected void EditImageButton_Click(object sender, EventArgs e)
        {
            if (ViewControl1.ArticleID != null)
            {
                ArticleDetailsViewControl1.Show(StaticUtilities.OwnerID(Page), ViewControl1.ArticleID);
            }
            else
            {
                ArticleDetailsViewControl1.ShowInsert(StaticUtilities.OwnerID(Page), "0");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StaticUtilities.SetPanelVisibility(ManageArticlePanel, StaticUtilities.PageeditorRoles, this);
        }

        protected void EditArticleLinkButton_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            txtActualContent.Text =
                Prtl_ArticlesTranslationUtility.GetArticleTranslation(CurrentLanguage, RouteData.Values["ArticleAbbr"])
                                               .Actual_Content;
            SaveArticleLinkButton.Visible = true;
            CloseArticleLinkButton.Visible = true;
            EditArticleLinkButton.Visible = false;
            StaticUtilities.SetSessionWithPaths(txtActualContent.ClientID, Page);
        }

        protected void SaveArticleLinkButton_Click(object sender, EventArgs e)
        {
            SaveArticleLinkButton.Visible = false;
            EditArticleLinkButton.Visible = true;
            MultiView1.ActiveViewIndex = 0;
            CloseArticleLinkButton.Visible = false;
            Prtl_ArticlesTranslationUtility.UpdateArticleTranslation(CurrentLanguage, RouteData.Values["ArticleAbbr"], txtActualContent.Text);
            ViewControl1.DataBind();
        }

        protected void CloseArticleLinkButton_Click(object sender, EventArgs e)
        {
            SaveArticleLinkButton.Visible = false;
            EditArticleLinkButton.Visible = true;
            CloseArticleLinkButton.Visible = false;
            MultiView1.ActiveViewIndex = 0;
        }
    }
}