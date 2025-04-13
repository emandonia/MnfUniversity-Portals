using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_LanguagesUtility
    {
        public static object AllLanguagesExceptAdded(string translationId)
        {
            if (!string.IsNullOrEmpty(translationId))
            {
                var dc = new PortalDataContextDataContext();

                var languagesExeptDone =
                    dc.prtl_Translations.Where(t => t.Translation_ID == Guid.Parse(translationId)).Select(
                        t => t.prtl_Language);
                return CultureInfo.GetCultures(CultureTypes.NeutralCultures).
                    Except(
                        languagesExeptDone.Select(l => CultureInfo.CreateSpecificCulture(l.LCID).Parent).ToArray()).
                    Select(
                        cultureInfo =>
                        new { Value = cultureInfo.TwoLetterISOLanguageName, Text = cultureInfo.NativeName })
                    .ToArray();
            }
            return CultureInfo.GetCultures(CultureTypes.NeutralCultures).
                Select(cultureInfo =>
                    new { Value = cultureInfo.TwoLetterISOLanguageName, Text = cultureInfo.NativeName })
                .ToArray();
        }

        public static prtl_Language getLangByLCID(string lcid)
        {
            return new PortalDataContextDataContext().prtl_Languages.Single(x => x.LCID == lcid);
        }

        public static IEnumerable<prtl_Language> Getlanguages(Guid TranslationID, PortalDataContextDataContext dc = null)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            if (abbr == null && type == 0)
            {
                return
                    (TranslationID == Guid.Empty)
                        ? GetStoredLanguages(dc)
                        : Prtl_TranslationUtility.OwnerName_univ_Translations(TranslationID, dc).
                            Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_fci_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_fee_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_eng_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_sci_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_med_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_liv_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_nur_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_edu_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
               
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_edv_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_hec_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_agr_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_art_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_law_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_com_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            //12121212
            else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_ecedu_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_media_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{
            //    return
            //           (TranslationID == Guid.Empty)
            //               ? GetStoredLanguages(dc)
            //               : Prtl_TranslationUtility.OwnerName_com_Translations(TranslationID, dc).
            //                   Select(tr => tr.prtl_Language);
            //}
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_fpe_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            //***************
            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_VMed_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {
                return
                       (TranslationID == Guid.Empty)
                           ? GetStoredLanguages(dc)
                           : Prtl_TranslationUtility.OwnerName_Pharm_Translations(TranslationID, dc).
                               Select(tr => tr.prtl_Language);
            }
            //*********************
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                return
                    (TranslationID == Guid.Empty)
                        ? GetStoredLanguages(dc)
                        : Prtl_TranslationUtility.OwnerName_fas_Translations(TranslationID, dc).
                            Select(tr => tr.prtl_Language);
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                return
                    (TranslationID == Guid.Empty)
                        ? GetStoredLanguages(dc)
                        : Prtl_TranslationUtility.OwnerName_hos_Translations(TranslationID, dc).
                            Select(tr => tr.prtl_Language);
            }
            else
            {
                return
                    (TranslationID == Guid.Empty)
                        ? GetStoredLanguages(dc)
                        : Prtl_TranslationUtility.OwnerNameTranslations(TranslationID, dc).
                            Select(tr => tr.prtl_Language);
            }
        }

        public static IEnumerable<prtl_Language> GetLanguages()
        {
            return new PortalDataContextDataContext().prtl_Languages;
        }

        public static IEnumerable<prtl_Language> GetStoredLanguages(PortalDataContextDataContext dataContext = null)
        {
            return (dataContext == null) ? new PortalDataContextDataContext().prtl_Languages : dataContext.prtl_Languages;
        }

        public static void InsertLanguage(prtl_Language newLanguage)
        {
            var dc = new PortalDataContextDataContext();
            {
                dc.prtl_Languages.InsertOnSubmit(newLanguage);
                dc.SubmitChanges();
            }
        }

        public static prtl_Language SelectTLanguageByLangID(int Lang_id)
        {
            return new PortalDataContextDataContext().prtl_Languages.Single(x => x.Lang_Id == Lang_id);
        }
    }
}