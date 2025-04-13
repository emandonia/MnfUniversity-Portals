using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Base;

namespace MnfUniversity_Portals.UserControls.Editors.ArticleEditor.Details
{
    public partial class ArticleDetailsViewUserControl : DetailsViewBasedUserControl
    {
        protected override string DefaultValueForFiltering
        {
            get { return "0"; }
        }

        protected override string FilterValueName
        {
            get { return "ArticleTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get
            {
                return GetClientIDs("txtActualContent");
            }
        }


        private DataControlField EditorField
        {
            get { return EditorDetailsView.Fields[3]; }
        }

       

        private string InsertPrimaryKey
        {
            get { return "Article_ID"; }
        }



        protected override IEnumerable<Portal_DAL.prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_ArticlesTranslationUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }

        protected override object EditorTitle
        {
            get { return GetLocalResourceObject("Title"); }
        }

        protected override void ItemInserting(DetailsView detailsview, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
               
                var x = detailsview.GetControl<CheckBox>("CheckBox1");

                prtl_ArticlesUtility.InsertNewArticle(e,  CurrentOwnerID, InsertPrimaryKey,x.Checked);
            }
            else
            {
                e.Values[InsertPrimaryKey] = FilterValue;
            }
            var langddl = GetDVControl<DropDownList>("LangDropDownList");
            e.Values["Lang_id"] = langddl.SelectedValue;
        }

        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
            var Article_ID = detailsview.GetControl<HiddenField>("ArticleID");
            var x = detailsview.GetControl<CheckBox>("CheckBox1");
            prtl_ArticlesUtility.UpdateArticleWithPublish(Convert.ToInt32(Article_ID.Value), x.Checked);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EditorField.HeaderText = GetPreViewHeaderText();
        }

        protected override int TranslationsCount
        {
            get { return Prtl_ArticlesTranslationUtility.GetCountTranslations(FilterValue); }
        }
    }
}