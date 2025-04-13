using System;
using System.Collections.Generic;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_ThesisTranslationUtility
    {
        public static Prtl_Thesis_Translation GetThesisTranslation(string CurrentLanguage, object Thesis_ID)
        {
            return new PortalDataContextDataContext().Prtl_Thesis_Translations.SingleOrDefault(a => a.prtl_Language.LCID == CurrentLanguage && a.Thesis_ID.ToString() == Thesis_ID.ToString());
        }
        //public static void UpdateArticleTranslation(string CurrentLanguage, object Article_ID, string content)
        //{
        //    var dc = new PortalDataContextDataContext()
        //    var articletranslation =dc .prtl_Articles_Translations.Single(a => a.prtl_Language.LCID == CurrentLanguage && a.Article_ID.ToString() == Article_ID.ToString());
        //    articletranslation.Actual_Content = content;
        //    dc.SubmitChanges();
        //}



        public static int GetCountTranslations(string id)
        {
            return new PortalDataContextDataContext().Prtl_Thesis_Translations.Count(tr => tr.Thesis_ID.ToString() == id.ToString());
        }

        //public static string GetTitleArtTranByAbbrAndLCID(string abbr, string lcid)
        //{
        //    return new PortalDataContextDataContext().prtl_Articles_Translations.Single(
        //        f =>
        //        f.prtl_Article.Abbr == abbr &&
        //        f.prtl_Language.LCID == lcid).Title;
        //}

        //public static IEnumerable<prtl_Language> GetTranslationsLanguages(string id)
        //{
        //    return new PortalDataContextDataContext().prtl_Articles_Translations.Where(tr => tr.Article_ID.ToString() == id.ToString()).Select(tr => tr.prtl_Language);
        //}

        //public static object GetUnMappedArticles(Guid? ownerID, string currentlang, int menuid)
        //{
        //    return new PortalDataContextDataContext().prtl_Articles_Translations.
        //        Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
        //            tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_Menu.Menu_id == menuid)
        //        .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);
        //}

        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID)
        {
            var dc = new PortalDataContextDataContext();
            return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.Prtl_Thesis_Translations  .Where(tr => tr.Thesis_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
        }

        //internal static string GetArticleTranslation(int ArticleTranslationID)
        //{
        //    return new PortalDataContextDataContext().prtl_Articles_Translations.Single(a => a.T_id==ArticleTranslationID).Actual_Content;

        //}
  
        //internal static void UpdateArticleTranslation(int ArticleTranslationID, string translation)
        //{
        //    var  dc= new PortalDataContextDataContext()
        //    var trans = dc.prtl_Articles_Translations.Single(a => a.T_id == ArticleTranslationID);
        //    trans.Actual_Content = translation;
        //    dc.SubmitChanges();
       // }  
}
}