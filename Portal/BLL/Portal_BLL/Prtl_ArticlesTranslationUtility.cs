using System;
using System.Collections.Generic;
using System.Linq;
using MnfUniversity_Portals;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_ArticlesTranslationUtility
    {
        public static prtl_Articles_Translation GetArticleTranslation(string CurrentLanguage, object Article_ID)
        {
            return new PortalDataContextDataContext().prtl_Articles_Translations.SingleOrDefault(a => a.prtl_Language.LCID == CurrentLanguage && a.Article_ID.ToString() == Article_ID.ToString());
        }
        public static void UpdateArticleTranslation(string CurrentLanguage, object Article_ID, string content)
        {
            var dc = new PortalDataContextDataContext();
            var articletranslation =dc .prtl_Articles_Translations.Single(a => a.prtl_Language.LCID == CurrentLanguage && a.Article_ID.ToString() == Article_ID.ToString());
            articletranslation.Actual_Content = content;
            dc.SubmitChanges();
        }



        public static int GetCountTranslations(string id)
        {
            return new PortalDataContextDataContext().prtl_Articles_Translations.Count(tr => tr.Article_ID.ToString() == id.ToString());
        }

        public static string GetTitleArtTranByAbbrAndLCID(string abbr, string lcid)
        {
            return new PortalDataContextDataContext().prtl_Articles_Translations.Single(
                f =>
                f.prtl_Article.Abbr.ToLower() == abbr &&
                f.prtl_Language.LCID == lcid).Title;
        }

        public static IEnumerable<prtl_Language> GetTranslationsLanguages(string id)
        {
            return new PortalDataContextDataContext().prtl_Articles_Translations.Where(tr => tr.Article_ID.ToString() == id.ToString()).Select(tr => tr.prtl_Language);
        }

        public static object GetUnMappedArticles(Guid? ownerID, string currentlang, Guid tid,string abbr)
        {
            if (abbr == null)
            {
                var menuid =
                    new PortalDataContextDataContext().prtl_menu_univ_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_univ.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_univ.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fci")
            {
                var menuid =
                       new PortalDataContextDataContext().prtl_menu_fci_trans.SingleOrDefault(
                           x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_fci.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fci.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fee")
            {
                var menuid =
                      new PortalDataContextDataContext().prtl_menu_fee_trans.SingleOrDefault(
                          x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_fee.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fee.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "eng")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_eng_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_eng.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_eng.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "nur")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_nur_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_nur.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_nur.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "edu")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_edu_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_edu.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_edu.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "sci")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_sci_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_sci.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_sci.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "edv")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_edv_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_edv.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_edv.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "agr")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_agr_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_agr.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_agr.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "hec")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_hec_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_hec.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_hec.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "law")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_law_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_law.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_law.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fpe")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_fpe_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_fpe.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fpe.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //*******************
            else if (abbr.ToLower() == "vmed")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_VMed_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_VMed.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_VMed.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }


            else if (abbr.ToLower() == "pharm")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_Pharm_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_Pharm.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_Pharm.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }

                //********************
            else if (abbr.ToLower() == "fa")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_fa_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_fa.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fa.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }

            
            else if (abbr.ToLower() == "art")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_art_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_art.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_art.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "ho")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_ho_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_ho.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_ho.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "med")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_med_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_med.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_med.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "liv")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_liv_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_liv.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_liv.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "com")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_com_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_com.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_com.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }//12121212
            //else if (abbr.ToLower() == "ecedu")
            //{
            //    var menuid =
            //             new PortalDataContextDataContext().prtl_menu_ECEDU_trans.SingleOrDefault(
            //                 x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_ECEDU.Menu_id;
            //    return new PortalDataContextDataContext().prtl_Articles_Translations.
            //    Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
            //        tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_ECEDU.Menu_id == menuid)
            //    .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            //}
            ///*********3-12-2020***********************///
            else if (abbr.ToLower() == "media")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_media_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_media.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_media.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_menu_AI_trans.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_AI.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_AI.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //else if (abbr.ToLower() == "dent")
            //{
            //    var menuid =
            //             new PortalDataContextDataContext().prtl_menu_com_trans.SingleOrDefault(
            //                 x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_menu_com.Menu_id;
            //    return new PortalDataContextDataContext().prtl_Articles_Translations.
            //    Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
            //        tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_com.Menu_id == menuid)
            //    .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            //}
            else
            {
                var menuid =
                         new PortalDataContextDataContext().prtl_Translations.SingleOrDefault(
                             x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlang).prtl_Menu.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_Menu.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);
            }
            
        }
        public static object GetUnMappedArticles2(int menuid, string currentlang, Guid? ownerID, string abbr)
        {
            if (abbr == null)
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_univ.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fci")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fci.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fee")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fee.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "eng")
            {
               
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_eng.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "nur")
            {
               
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_nur.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "edu")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_edu.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "sci")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_sci.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "edv")
            {
               
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_edv.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "agr")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_agr.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "hec")
            {
               
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_hec.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "law")
            {
               
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_law.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fpe")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fpe.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "fa")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_fa.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "art")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_art.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "ho")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_ho.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "med")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_med.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "liv")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_liv.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            else if (abbr.ToLower() == "com")
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_com.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {

                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_ECEDU.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {

                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_AI.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            }
            //else if (abbr.ToLower() == "media")
            //{

            //    return new PortalDataContextDataContext().prtl_Articles_Translations.
            //    Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
            //        tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_com.Menu_id == menuid)
            //    .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            //}
            //else if (abbr.ToLower() == "dent")
            //{

            //    return new PortalDataContextDataContext().prtl_Articles_Translations.
            //    Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
            //        tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_menu_com.Menu_id == menuid)
            //    .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);

            //}
            else
            {
                
                return new PortalDataContextDataContext().prtl_Articles_Translations.
                Where(tr => tr.prtl_Article.Owner_ID.Equals(ownerID) &&
                    tr.prtl_Language.LCID == currentlang && tr.prtl_Article.MenuItemId == null || tr.prtl_Article.prtl_Menu.Menu_id == menuid)
                .Select(tr => new { tr.Title, tr.Article_ID }).OrderBy(a => a.Title);
            }

        }
        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID)
        {
            var dc = new PortalDataContextDataContext();
            return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_Articles_Translations.Where(tr => tr.Article_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
        }

        internal static string GetArticleTranslation(int ArticleTranslationID)
        {
            return new PortalDataContextDataContext().prtl_Articles_Translations.Single(a => a.T_id==ArticleTranslationID).Actual_Content;

        }
  
        internal static void UpdateArticleTranslation(int ArticleTranslationID, string translation)
        {
            var  dc= new PortalDataContextDataContext();
            var trans = dc.prtl_Articles_Translations.Single(a => a.T_id == ArticleTranslationID);
            trans.Actual_Content = translation;
            dc.SubmitChanges();
        }  }
}