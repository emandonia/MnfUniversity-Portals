using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.Base_Code;
using MnfUniversity_Portals.UserControls.Base;


namespace MnfUniversity_Portals.UserControls.Viewers
{
    public partial class EventSliderControl : UserControlBase
    {
        private string Action
        {
            get { return StaticUtilities.GetSessionValueOrDefault(Page, "Action", ""); }
            set { Session["Action"] = value; }
        }

        private bool Autherized
        {
            get
            {
                return Page.User.Identity.Name.ToLower() == StaticUtilities.Superadmin ||
                      StaticUtilities.HighlightseditorRoles.Any(r => Page.User.IsInRole(r.ToString()));
            }
        }

        private string TranslationID
        {
            get { return StaticUtilities.GetSessionValueOrDefault(Page, "TranslationID", ""); }
            set { Session["TranslationID"] = value; }
        }

        protected void AddHighlightItemButton_Click(object sender, EventArgs e)
        {
            InlineHighlightsDetailsViewControl.ShowInsert(StaticUtilities.OwnerID(Page));
        }

        protected void InlineHighlightsDetailsViewControl_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            ShowHighlights();
        }

        protected void InlineHighlightsDetailsViewControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            ShowHighlights();
        }

        protected void ManageHighlightItemPanel_Load(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            StaticUtilities.SetPanelVisibility(panel, StaticUtilities.HighlightseditorRoles, this);
        }

        protected override void OnPreRender(EventArgs e)
        {
            ShowHighlights();

            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Request["__EVENTTARGET"]) && Page.Request.QueryString.AllKeys.Contains("a") && Autherized)
            {
                Action = Page.Request.QueryString["a"];
                TranslationID = Page.Request.QueryString["tid"];
                Response.Redirect(Page.Request.AppRelativeCurrentExecutionFilePath);
            }
            if (!string.IsNullOrEmpty(Action) && Autherized)
            {
                switch (Action)
                {
                    case "e":
                        InlineHighlightsDetailsViewControl.Show(StaticUtilities.OwnerID(Page), TranslationID, DetailsViewMode.Edit);
                        break;

                    case "m":
                        InlineHighlightsDetailsViewControl.Show(StaticUtilities.OwnerID(Page), TranslationID);

                        break;

                    case "i":
                        InlineHighlightsDetailsViewControl.Show(StaticUtilities.OwnerID(Page), TranslationID, DetailsViewMode.Insert);

                        break;

                    case "d":
                        Prtl_HighlightsUtility.DeleteHighlight(TranslationID);
                        break;
                }
                Action = TranslationID = "";
            }
        }

        private void ShowHighlights()
        {
            HighlightsShow.Panels.Clear();

            var query = Prtl_HighlightsUtility.GetTopItems(StaticUtilities.Currentlanguage(Page), 5,
                                                                   OwnerID);
            int i = 0;
            foreach (var y in query)
            {
                var p = new OboutInc.Show.Panel();
                
                var table = new Table { CssClass = "ob_show_panelsholder" };
                table.Attributes["style"] = "direction:" + StaticUtilities.Dir;
                var contentCell = new TableCell { ID = "leftcell" };
                string s = "";
                if (HtmlRemoval.StripTagsRegex(y.Details).Length <= 100)
                {
                    s = HtmlRemoval.StripTagsRegex(y.Details);
                }
                else if (HtmlRemoval.StripTagsRegex(y.Details).Length > 100)
                {
                    s = HtmlRemoval.StripTagsRegex(y.Details).Substring(0, 100);
                }
                contentCell.Controls.Add(new HyperLink
            {
                Text = s,
                NavigateUrl = URLBuilder.EventItemUrl(Page.RouteData, y.HighlightId)
            });

                var imageCell = new TableCell { ID = "rightcell" };
                if (Autherized)
                {
                    var editlinkbutton = new HyperLink { ID = "EditHighlight_ImageButton" + ++i, NavigateUrl = Page.Request.AppRelativeCurrentExecutionFilePath + "?a=e&tid=" + y.TranslationID };

                    editlinkbutton.Controls.Add(new Image { ID = "editImage" + i, ImageUrl = "~/styles/UserControlImages/edit.png" });
                    editlinkbutton.Controls.Add(new Label { ID = "editLabel" + i, Text = GetLocalResourceObject("Edit").ToString() });
                    contentCell.Controls.Add(editlinkbutton);
                    var managelinkbutton = new HyperLink { ID = "EditHighlight_ImageButton" + ++i, NavigateUrl = Page.Request.AppRelativeCurrentExecutionFilePath + "?a=m&tid=" + y.TranslationID };

                    managelinkbutton.Controls.Add(new Image { ID = " manageImage" + i, ImageUrl = "~/styles/UserControlImages/language.png" });
                    managelinkbutton.Controls.Add(new Label { ID = " manageLabel" + i, Text = GetLocalResourceObject("manage").ToString() });
                    contentCell.Controls.Add(managelinkbutton);
                    var inserttranslationlinkbutton = new HyperLink { ID = "inserttranslationHighlight_ImageButton" + ++i, NavigateUrl = Page.Request.AppRelativeCurrentExecutionFilePath + "?a=i&tid=" + y.TranslationID };

                    inserttranslationlinkbutton.Controls.Add(new Image { ID = "inserttranslationImage" + i, ImageUrl = "~/styles/UserControlImages/insert.png" });
                    inserttranslationlinkbutton.Controls.Add(new Label { ID = "inserttranslationLabel" + i, Text = GetLocalResourceObject("inserttranslation").ToString() });
                    contentCell.Controls.Add(inserttranslationlinkbutton);
                    var deletelinkbutton = new HyperLink { ID = "deleteHighlight_ImageButton" + ++i, NavigateUrl = Page.Request.AppRelativeCurrentExecutionFilePath + "?a=d&tid=" + y.TranslationID };
                    deletelinkbutton.Attributes.Add("onclick", "return confirm(\"Are you sure you want to delete this entry?\");");
                    deletelinkbutton.Controls.Add(new Image { ID = "deleteImage" + i, ImageUrl = "~/styles/UserControlImages/delete.png" });
                    deletelinkbutton.Controls.Add(new Label { ID = "deleteLabel" + i, Text = GetLocalResourceObject("delete").ToString() });
                    contentCell.Controls.Add(deletelinkbutton);
                }
                imageCell.Controls.Add(new ImageZoom
                    {
                        ImageAltText = "",
                        ImageTitle = "",
                        BigImageURL = URLBuilder.EventItemUrl(Page.RouteData, y.HighlightId),
                        SmallImageURL = URLBuilder.GetURLIfExists(Page,
                                                                  SiteFolders.Events,
                                                                  y.Image),
                        ImageClass = "test",
                        Page = Page
                    });

                var row = new TableRow();
                var row2 = new TableRow();
               
                row2.Cells.Add(imageCell);
                row.Cells.Add(contentCell);
            
                table.Rows.Add(row2);
                table.Rows.Add(row);
                
                p.Controls.Add(table);

                HighlightsShow.AddPanel(p);
            }
            HighlightsShow.StyleFolder = URLBuilder.VirtualPath(Page) + "/App_Themes/" + Page.Theme + "/ShowStyle";
        }
    }
}