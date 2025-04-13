using System;
using System.Collections.Generic;
using System.Linq;
using Portal_DAL;
using System.Windows.Forms;
using Common;
using MnfUniversity_Portals;

namespace BLL
{
    public static class Prtl_NewsTransUtility
    {
        public static void DeleteTranslastion(int transid,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                var translations = dc.prtl_news_univ_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();

            }
            else if (abbr.ToLower() == "fci")
            {
                var translations = dc.prtl_news_fci_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "fee")
            {
                var translations = dc.prtl_news_fee_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "eng")
            {
                var translations = dc.prtl_news_eng_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "nur")
            {
                var translations = dc.prtl_news_nur_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edu")
            {
                var translations = dc.prtl_news_edu_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "sci")
            {
                var translations = dc.prtl_news_sci_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edv")
            {
                var translations = dc.prtl_news_edv_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "agr")
            {
                var translations = dc.prtl_news_agr_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "hec")
            {
                var translations = dc.prtl_news_hec_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "law")
            {
                var translations = dc.prtl_news_law_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "fpe")
            {
                var translations = dc.prtl_news_fpe_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
                //***************
            else if (abbr.ToLower() == "vmed")
            {
                var translations = dc.prtl_news_VMed_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "pharm")
            {
                var translations = dc.prtl_news_Pharm_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
                //***************
            else if (abbr.ToLower() == "fa")
            {
                var translations = dc.prtl_news_fa_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "art")
            {
                var translations = dc.prtl_news_art_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "ho")
            {
                var translations = dc.prtl_news_ho_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "med")
            {
                var translations = dc.prtl_news_med_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "liv")
            {
                var translations = dc.prtl_news_liv_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "com")
            {
                var translations = dc.prtl_news_com_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                var translations = dc.prtl_news_ECEDU_trans;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    var translations = dc.prtl_news_com_trans;
            //    var item = translations.Single(nr => nr.id == transid);
            //    translations.DeleteOnSubmit(item);
            //    dc.SubmitChanges();
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    var translations = dc.prtl_news_com_trans;
            //    var item = translations.Single(nr => nr.id == transid);
            //    translations.DeleteOnSubmit(item);
            //    dc.SubmitChanges();
            //}
            else
            {
                var translations = dc.prtl_News_Translations;
                var item = translations.Single(nr => nr.id == transid);
                translations.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            
        }

        public static IEnumerable<prtl_News_Translation> GetAllNews(string currentLanguage, Guid? owner_id)
        {
            
                return new PortalDataContextDataContext().prtl_News_Translations.OrderByDescending(nt => nt.prtl_New.News_date).
                 Where(tr => tr.prtl_New.Published && tr.prtl_Language.LCID == currentLanguage
                             &&
                             ((tr.prtl_New.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                             || tr.prtl_New.Owner_ID == null));   
        }
        public static IEnumerable<prtl_news_univ_tran> GetAll_univ_News(string currentLanguage, Guid? owner_id)
        {
            
            return new PortalDataContextDataContext().prtl_news_univ_trans.OrderByDescending(nt => nt.prtl_news_univ.News_date).
             Where(tr =>  tr.prtl_news_univ.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_univ.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_univ.Owner_ID == null));
            
        }
        public static IEnumerable<prtl_news_fci_tran> GetAll_fci_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_fci_trans.OrderByDescending(nt => nt.prtl_news_fci.News_date).
             Where(tr => tr.prtl_news_fci.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_fci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_fci.Owner_ID == null));
        }
        //3333333333333
        public static IEnumerable<prtl_news_media_tran> GetAll_media_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_media_trans.OrderByDescending(nt => nt.prtl_news_media.News_date).
             Where(tr => tr.prtl_news_media.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_media.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_media.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_fee_tran> GetAll_fee_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_fee_trans.OrderByDescending(nt => nt.prtl_news_fee.News_date).
             Where(tr => tr.prtl_news_fee.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_fee.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_fee.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_eng_tran> GetAll_eng_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_eng_trans.OrderByDescending(nt => nt.prtl_news_eng.News_date).
             Where(tr => tr.prtl_news_eng.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_eng.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_eng.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_sci_tran> GetAll_sci_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_sci_trans.OrderByDescending(nt => nt.prtl_news_sci.News_date).
             Where(tr => tr.prtl_news_sci.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_sci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_sci.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_nur_tran> GetAll_nur_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_nur_trans.OrderByDescending(nt => nt.prtl_news_nur.News_date).
             Where(tr => tr.prtl_news_nur.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_nur.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_nur.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_edu_tran> GetAll_edu_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_edu_trans.OrderByDescending(nt => nt.prtl_news_edu.News_date).
             Where(tr => tr.prtl_news_edu.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_edu.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_edu.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_edv_tran> GetAll_edv_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_edv_trans.OrderByDescending(nt => nt.prtl_news_edv.News_date).
             Where(tr => tr.prtl_news_edv.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_edv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_edv.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_hec_tran> GetAll_hec_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_hec_trans.OrderByDescending(nt => nt.prtl_news_hec.News_date).
             Where(tr => tr.prtl_news_hec.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_hec.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_hec.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_agr_tran> GetAll_agr_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_agr_trans.OrderByDescending(nt => nt.prtl_news_agr.News_date).
             Where(tr => tr.prtl_news_agr.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_agr.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_agr.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_med_tran> GetAll_med_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_med_trans.OrderByDescending(nt => nt.prtl_news_med.News_date).
             Where(tr => tr.prtl_news_med.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_med.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_med.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ho_tran> GetAll_hos_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_ho_trans.OrderByDescending(nt => nt.prtl_news_ho.News_date).
             Where(tr => tr.prtl_news_ho.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_ho.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_ho.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_law_tran> GetAll_law_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_law_trans.OrderByDescending(nt => nt.prtl_news_law.News_date).
             Where(tr => tr.prtl_news_law.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_law.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_law.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_art_tran> GetAll_art_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_art_trans.OrderByDescending(nt => nt.prtl_news_art.News_date).
             Where(tr => tr.prtl_news_art.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_art.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_art.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_fpe_tran> GetAll_fpe_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_fpe_trans.OrderByDescending(nt => nt.prtl_news_fpe.News_date).
             Where(tr => tr.prtl_news_fpe.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_fpe.Owner_ID == null));
        }
        //*****************
        public static IEnumerable<prtl_news_Pharm_tran> GetAll_Pharm_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_Pharm_trans.OrderByDescending(nt => nt.prtl_news_Pharm.News_date).
             Where(tr => tr.prtl_news_Pharm.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_Pharm.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_VMed_tran> GetAll_VMed_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_VMed_trans.OrderByDescending(nt => nt.prtl_news_VMed.News_date).
             Where(tr => tr.prtl_news_VMed.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_VMed.Owner_ID == null));
        }
        //*************************
        public static IEnumerable<prtl_news_fa_tran> GetAll_fas_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_fa_trans.OrderByDescending(nt => nt.prtl_news_fa.News_date).
             Where(tr => tr.prtl_news_fa.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_fa.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_fa.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_com_tran> GetAll_com_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(nt => nt.prtl_news_com.News_date).
             Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_com.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ECEDU_tran> GetAll_ecedu_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(nt => nt.prtl_news_ECEDU.News_date).
             Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_ECEDU.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ECEDU_tran> GetAll_ECEDU_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(nt => nt.prtl_news_ECEDU.News_date).
             Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_ECEDU.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_liv_tran> GetAll_liv_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_liv_trans.OrderByDescending(nt => nt.prtl_news_liv.News_date).
             Where(tr => tr.prtl_news_liv.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_liv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_liv.Owner_ID == null));
        }
//14-4-2022
        public static IEnumerable<prtl_news_AI_tran> GetAll_ai_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_AI_trans.OrderByDescending(nt => nt.prtl_news_AI.News_date).
             Where(tr => tr.prtl_news_AI.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_AI.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_AI.Owner_ID == null));
        }

        //fatma 6-6-2022
        public static IEnumerable<prtl_news_dent_tran> GetAll_dent_News(string currentLanguage, Guid? owner_id)
        {

            return new PortalDataContextDataContext().prtl_news_dent_trans.OrderByDescending(nt => nt.prtl_news_dent.News_date).
             Where(tr => tr.prtl_news_dent.Published && tr.prtl_Language.LCID == currentLanguage
                         &&
                         ((tr.prtl_news_dent.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                         || tr.prtl_news_dent.Owner_ID == null));
        }
        public static int GetCountAllNews(string currentLanguage, Guid? owner_id,string abbr)
        {

            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                return new PortalDataContextDataContext().prtl_news_univ_trans.
                 OrderByDescending(nt => nt.prtl_news_univ.News_date).Count(tr => tr.prtl_news_univ.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_univ.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_univ.Owner_ID == null));

            }
            else if (abbr.ToLower() == "fci")
            {
                return new PortalDataContextDataContext().prtl_news_fci_trans.OrderByDescending(nt => nt.prtl_news_fci.News_date).
                 Where(tr => tr.prtl_news_fci.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_fci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_fci.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "fee")
            {
                return new PortalDataContextDataContext().prtl_news_fee_trans.OrderByDescending(nt => nt.prtl_news_fee.News_date).
                 Where(tr => tr.prtl_news_fee.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_fee.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_fee.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "eng")
            {
                return new PortalDataContextDataContext().prtl_news_eng_trans.OrderByDescending(nt => nt.prtl_news_eng.News_date).
                 Where(tr => tr.prtl_news_eng.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_eng.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_eng.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "nur")
            {
                return new PortalDataContextDataContext().prtl_news_nur_trans.OrderByDescending(nt => nt.prtl_news_nur.News_date).
                 Where(tr => tr.prtl_news_nur.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_nur.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_nur.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "edu")
            {
                return new PortalDataContextDataContext().prtl_news_edu_trans.OrderByDescending(nt => nt.prtl_news_edu.News_date).
                 Where(tr => tr.prtl_news_edu.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_edu.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_edu.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "sci")
            {
                return new PortalDataContextDataContext().prtl_news_sci_trans.OrderByDescending(nt => nt.prtl_news_sci.News_date).
                  Where(tr => tr.prtl_news_sci.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_sci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_sci.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "edv")
            {
                return new PortalDataContextDataContext().prtl_news_edv_trans.OrderByDescending(nt => nt.prtl_news_edv.News_date).
                  Where(tr => tr.prtl_news_edv.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_edv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_edv.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "agr")
            {
                return new PortalDataContextDataContext().prtl_news_agr_trans.OrderByDescending(nt => nt.prtl_news_agr.News_date).
                 Where(tr => tr.prtl_news_agr.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_agr.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_agr.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "hec")
            {
                return new PortalDataContextDataContext().prtl_news_hec_trans.OrderByDescending(nt => nt.prtl_news_hec.News_date).
                  Where(tr => tr.prtl_news_hec.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_hec.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_hec.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "law")
            {
                return new PortalDataContextDataContext().prtl_news_law_trans.OrderByDescending(nt => nt.prtl_news_law.News_date).
                 Where(tr => tr.prtl_news_law.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_law.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_law.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "fpe")
            {
                return new PortalDataContextDataContext().prtl_news_fpe_trans.OrderByDescending(nt => nt.prtl_news_fpe.News_date).
                 Where(tr => tr.prtl_news_fpe.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_fpe.Owner_ID == null)).Count();
            }
                //*****************************
            else if (abbr.ToLower() == "vmed")
            {
                return new PortalDataContextDataContext().prtl_news_VMed_trans.OrderByDescending(nt => nt.prtl_news_VMed.News_date).
                 Where(tr => tr.prtl_news_VMed.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_VMed.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "pharm")
            {
                return new PortalDataContextDataContext().prtl_news_Pharm_trans.OrderByDescending(nt => nt.prtl_news_Pharm.News_date).
                 Where(tr => tr.prtl_news_Pharm.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_Pharm.Owner_ID == null)).Count();
            }
                //**********************************
            else if (abbr.ToLower() == "fa")
            {
                return new PortalDataContextDataContext().prtl_news_fa_trans.OrderByDescending(nt => nt.prtl_news_fa.News_date).
                  Where(tr => tr.prtl_news_fa.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_fa.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_fa.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "art")
            {
                return new PortalDataContextDataContext().prtl_news_art_trans.OrderByDescending(nt => nt.prtl_news_art.News_date).
                 Where(tr => tr.prtl_news_art.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_art.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_art.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "ho")
            {
                return new PortalDataContextDataContext().prtl_news_ho_trans.OrderByDescending(nt => nt.prtl_news_ho.News_date).
                 Where(tr => tr.prtl_news_ho.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_ho.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_ho.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "med")
            {
                return new PortalDataContextDataContext().prtl_news_med_trans.OrderByDescending(nt => nt.prtl_news_med.News_date).
                  Where(tr => tr.prtl_news_med.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_med.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_med.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "liv")
            {
                return new PortalDataContextDataContext().prtl_news_liv_trans.OrderByDescending(nt => nt.prtl_news_liv.News_date).
                 Where(tr => tr.prtl_news_liv.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_news_liv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_news_liv.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "com")
            {
                return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(nt => nt.prtl_news_com.News_date).
                  Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_com.Owner_ID == null)).Count();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(nt => nt.prtl_news_ECEDU.News_date).
                  Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
               &&
               ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
               || tr.prtl_news_ECEDU.Owner_ID == null)).Count();
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(nt => nt.prtl_news_com.News_date).
            //      Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
            //   &&
            //   ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
            //   || tr.prtl_news_com.Owner_ID == null)).Count();
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(nt => nt.prtl_news_com.News_date).
            //      Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
            //   &&
            //   ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
            //   || tr.prtl_news_com.Owner_ID == null)).Count();
            //}
            else
            {
                return new PortalDataContextDataContext().prtl_News_Translations.OrderByDescending(nt => nt.prtl_New.News_date).
                 Where(tr => tr.prtl_New.Published && tr.prtl_Language.LCID == currentLanguage
              &&
              ((tr.prtl_New.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
              || tr.prtl_New.Owner_ID == null)).Count();
            }
            

        }
        public static IEnumerable<prtl_News_Translation> GetNewsByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        { 
            return new PortalDataContextDataContext().prtl_News_Translations.OrderByDescending(nt => nt.prtl_New.News_date).
                Where(tr => tr.prtl_New.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_New.News_date >= FilterDate &&
                            tr.prtl_New.News_date <= FilterDate2 &&
                            ((tr.prtl_New.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_New.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_univ_tran> GetNews_univ_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_univ_trans.OrderByDescending(nt => nt.prtl_news_univ.News_date).
                Where(tr => tr.prtl_news_univ.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_univ.News_date >= FilterDate &&
                            tr.prtl_news_univ.News_date <= FilterDate2 &&
                            ((tr.prtl_news_univ.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_univ.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_fci_tran> GetNews_fci_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_fci_trans.OrderByDescending(nt => nt.prtl_news_fci.News_date).
                Where(tr => tr.prtl_news_fci.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_fci.News_date >= FilterDate &&
                            tr.prtl_news_fci.News_date <= FilterDate2 &&
                            ((tr.prtl_news_fci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_fci.Owner_ID == null));
        }


        //3333

        public static IEnumerable<prtl_news_media_tran> GetNews_media_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_media_trans.OrderByDescending(nt => nt.prtl_news_media.News_date).
                Where(tr => tr.prtl_news_media.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_media.News_date >= FilterDate &&
                            tr.prtl_news_media.News_date <= FilterDate2 &&
                            ((tr.prtl_news_media.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_media.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_fee_tran> GetNews_fee_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_fee_trans.OrderByDescending(nt => nt.prtl_news_fee.News_date).
                Where(tr => tr.prtl_news_fee.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_fee.News_date >= FilterDate &&
                            tr.prtl_news_fee.News_date <= FilterDate2 &&
                            ((tr.prtl_news_fee.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_fee.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_eng_tran> GetNews_eng_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_eng_trans.OrderByDescending(nt => nt.prtl_news_eng.News_date).
                Where(tr => tr.prtl_news_eng.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_eng.News_date >= FilterDate &&
                            tr.prtl_news_eng.News_date <= FilterDate2 &&
                            ((tr.prtl_news_eng.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_eng.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_sci_tran> GetNews_sci_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_sci_trans.OrderByDescending(nt => nt.prtl_news_sci.News_date).
                Where(tr => tr.prtl_news_sci.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_sci.News_date >= FilterDate &&
                            tr.prtl_news_sci.News_date <= FilterDate2 &&
                            ((tr.prtl_news_sci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_sci.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_nur_tran> GetNews_nur_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_nur_trans.OrderByDescending(nt => nt.prtl_news_nur.News_date).
                Where(tr => tr.prtl_news_nur.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_nur.News_date >= FilterDate &&
                            tr.prtl_news_nur.News_date <= FilterDate2 &&
                            ((tr.prtl_news_nur.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_nur.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_edu_tran> GetNews_edu_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_edu_trans.OrderByDescending(nt => nt.prtl_news_edu.News_date).
                Where(tr => tr.prtl_news_edu.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_edu.News_date >= FilterDate &&
                            tr.prtl_news_edu.News_date <= FilterDate2 &&
                            ((tr.prtl_news_edu.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_edu.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_edv_tran> GetNews_edv_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_edv_trans.OrderByDescending(nt => nt.prtl_news_edv.News_date).
                Where(tr => tr.prtl_news_edv.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_edv.News_date >= FilterDate &&
                            tr.prtl_news_edv.News_date <= FilterDate2 &&
                            ((tr.prtl_news_edv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_edv.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_hec_tran> GetNews_hec_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_hec_trans.OrderByDescending(nt => nt.prtl_news_hec.News_date).
                Where(tr => tr.prtl_news_hec.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_hec.News_date >= FilterDate &&
                            tr.prtl_news_hec.News_date <= FilterDate2 &&
                            ((tr.prtl_news_hec.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_hec.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_agr_tran> GetNews_agr_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_agr_trans.OrderByDescending(nt => nt.prtl_news_agr.News_date).
                Where(tr => tr.prtl_news_agr.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_agr.News_date >= FilterDate &&
                            tr.prtl_news_agr.News_date <= FilterDate2 &&
                            ((tr.prtl_news_agr.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_agr.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_med_tran> GetNews_med_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_med_trans.OrderByDescending(nt => nt.prtl_news_med.News_date).
                Where(tr => tr.prtl_news_med.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_med.News_date >= FilterDate &&
                            tr.prtl_news_med.News_date <= FilterDate2 &&
                            ((tr.prtl_news_med.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_med.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ho_tran> GetNews_ho_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_ho_trans.OrderByDescending(nt => nt.prtl_news_ho.News_date).
                Where(tr => tr.prtl_news_ho.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_ho.News_date >= FilterDate &&
                            tr.prtl_news_ho.News_date <= FilterDate2 &&
                            ((tr.prtl_news_ho.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_ho.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_art_tran> GetNews_art_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_art_trans.OrderByDescending(nt => nt.prtl_news_art.News_date).
                Where(tr => tr.prtl_news_art.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_art.News_date >= FilterDate &&
                            tr.prtl_news_art.News_date <= FilterDate2 &&
                            ((tr.prtl_news_art.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_art.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_law_tran> GetNews_law_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_law_trans.OrderByDescending(nt => nt.prtl_news_law.News_date).
                Where(tr => tr.prtl_news_law.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_law.News_date >= FilterDate &&
                            tr.prtl_news_law.News_date <= FilterDate2 &&
                            ((tr.prtl_news_law.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_law.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_com_tran> GetNews_com_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(nt => nt.prtl_news_com.News_date).
                Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_com.News_date >= FilterDate &&
                            tr.prtl_news_com.News_date <= FilterDate2 &&
                            ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_com.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ECEDU_tran> GetNews_ecedu_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(nt => nt.prtl_news_ECEDU.News_date).
                Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_ECEDU.News_date >= FilterDate &&
                            tr.prtl_news_ECEDU.News_date <= FilterDate2 &&
                            ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_ECEDU.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_ECEDU_tran> GetNews_ECEDU_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(nt => nt.prtl_news_ECEDU.News_date).
                Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_ECEDU.News_date >= FilterDate &&
                            tr.prtl_news_ECEDU.News_date <= FilterDate2 &&
                            ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_ECEDU.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_liv_tran> GetNews_liv_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_liv_trans.OrderByDescending(nt => nt.prtl_news_liv.News_date).
                Where(tr => tr.prtl_news_liv.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_liv.News_date >= FilterDate &&
                            tr.prtl_news_liv.News_date <= FilterDate2 &&
                            ((tr.prtl_news_liv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_liv.Owner_ID == null));
        }

        

        public static IEnumerable<prtl_news_fpe_tran> GetNews_fpe_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_fpe_trans.OrderByDescending(nt => nt.prtl_news_fpe.News_date).
                Where(tr => tr.prtl_news_fpe.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_fpe.News_date >= FilterDate &&
                            tr.prtl_news_fpe.News_date <= FilterDate2 &&
                            ((tr.prtl_news_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_fpe.Owner_ID == null));
        }
        //**************************
        public static IEnumerable<prtl_news_Pharm_tran> GetNews_Pharm_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_Pharm_trans.OrderByDescending(nt => nt.prtl_news_Pharm.News_date).
                Where(tr => tr.prtl_news_Pharm.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_Pharm.News_date >= FilterDate &&
                            tr.prtl_news_Pharm.News_date <= FilterDate2 &&
                            ((tr.prtl_news_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_Pharm.Owner_ID == null));
        }
        public static IEnumerable<prtl_news_VMed_tran> GetNews_VMed_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_VMed_trans.OrderByDescending(nt => nt.prtl_news_VMed.News_date).
                Where(tr => tr.prtl_news_VMed.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_VMed.News_date >= FilterDate &&
                            tr.prtl_news_VMed.News_date <= FilterDate2 &&
                            ((tr.prtl_news_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_VMed.Owner_ID == null));
        }
        //**********************************
        public static IEnumerable<prtl_news_fa_tran> GetNews_fa_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_fa_trans.OrderByDescending(nt => nt.prtl_news_fa.News_date).
                Where(tr => tr.prtl_news_fa.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_fa.News_date >= FilterDate &&
                            tr.prtl_news_fa.News_date <= FilterDate2 &&
                            ((tr.prtl_news_fa.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_fa.Owner_ID == null));
        }
        //14-4-2022
        public static IEnumerable<prtl_news_AI_tran> GetNews_ai_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
                return new PortalDataContextDataContext().prtl_news_AI_trans.OrderByDescending(nt => nt.prtl_news_AI.News_date).
                Where(tr => tr.prtl_news_AI.Published && tr.prtl_Language.LCID == currentLanguage
                            && tr.prtl_news_AI.News_date >= FilterDate &&
                            tr.prtl_news_AI.News_date <= FilterDate2 &&
                            ((tr.prtl_news_AI.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                            || tr.prtl_news_AI.Owner_ID == null));
        }

        //fatma 6-6-2022
        public static IEnumerable<prtl_news_dent_tran> GetNews_dent_ByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id)
        {
            return new PortalDataContextDataContext().prtl_news_dent_trans.OrderByDescending(nt => nt.prtl_news_dent.News_date).
            Where(tr => tr.prtl_news_dent.Published && tr.prtl_Language.LCID == currentLanguage
                        && tr.prtl_news_dent.News_date >= FilterDate &&
                        tr.prtl_news_dent.News_date <= FilterDate2 &&
                        ((tr.prtl_news_dent.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty))
                        || tr.prtl_news_dent.Owner_ID == null));
        }

        public static int GetCountNewsByDate(string currentLanguage, DateTime FilterDate, DateTime FilterDate2, Guid? owner_id,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                return new PortalDataContextDataContext().prtl_news_univ_trans.OrderByDescending(
                       nt => nt.prtl_news_univ.News_date).
                       Where(tr => tr.prtl_news_univ.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_univ.News_date >= FilterDate &&
                                   tr.prtl_news_univ.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_univ.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_univ.Owner_ID == null)).Count();

            }
            else if (abbr.ToLower() == "fci")
            {
                return new PortalDataContextDataContext().prtl_news_fci_trans.OrderByDescending(
                       nt => nt.prtl_news_fci.News_date).
                       Where(tr => tr.prtl_news_fci.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_fci.News_date >= FilterDate &&
                                   tr.prtl_news_fci.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_fci.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_fci.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "fee")
            {
                return new PortalDataContextDataContext().prtl_news_fee_trans.OrderByDescending(
                       nt => nt.prtl_news_fee.News_date).
                       Where(tr => tr.prtl_news_fee.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_fee.News_date >= FilterDate &&
                                   tr.prtl_news_fee.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_fee.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_fee.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "eng")
            {
                return new PortalDataContextDataContext().prtl_news_eng_trans.OrderByDescending(
                       nt => nt.prtl_news_eng.News_date).
                       Where(tr => tr.prtl_news_eng.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_eng.News_date >= FilterDate &&
                                   tr.prtl_news_eng.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_eng.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_eng.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "nur")
            {
                return new PortalDataContextDataContext().prtl_news_nur_trans.OrderByDescending(
                       nt => nt.prtl_news_nur.News_date).
                       Where(tr => tr.prtl_news_nur.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_nur.News_date >= FilterDate &&
                                   tr.prtl_news_nur.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_nur.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_nur.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "edu")
            {
                return new PortalDataContextDataContext().prtl_news_edu_trans.OrderByDescending(
                       nt => nt.prtl_news_edu.News_date).
                       Where(tr => tr.prtl_news_edu.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_edu.News_date >= FilterDate &&
                                   tr.prtl_news_edu.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_edu.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_edu.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "sci")
            {
                return new PortalDataContextDataContext().prtl_news_sci_trans.OrderByDescending(
                       nt => nt.prtl_news_sci.News_date).
                       Where(tr => tr.prtl_news_sci.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_sci.News_date >= FilterDate &&
                                   tr.prtl_news_sci.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_sci.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_sci.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "edv")
            {
                return new PortalDataContextDataContext().prtl_news_edv_trans.OrderByDescending(
                       nt => nt.prtl_news_edv.News_date).
                       Where(tr => tr.prtl_news_edv.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_edv.News_date >= FilterDate &&
                                   tr.prtl_news_edv.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_edv.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_edv.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "agr")
            {
                return new PortalDataContextDataContext().prtl_news_agr_trans.OrderByDescending(
                       nt => nt.prtl_news_agr.News_date).
                       Where(tr => tr.prtl_news_agr.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_agr.News_date >= FilterDate &&
                                   tr.prtl_news_agr.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_agr.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_agr.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "hec")
            {
                return new PortalDataContextDataContext().prtl_news_hec_trans.OrderByDescending(
                       nt => nt.prtl_news_hec.News_date).
                       Where(tr => tr.prtl_news_hec.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_hec.News_date >= FilterDate &&
                                   tr.prtl_news_hec.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_hec.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_hec.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "law")
            {
                return new PortalDataContextDataContext().prtl_news_law_trans.OrderByDescending(
                        nt => nt.prtl_news_law.News_date).
                        Where(tr => tr.prtl_news_law.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_law.News_date >= FilterDate &&
                                    tr.prtl_news_law.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_law.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_law.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "fpe")
            {
                return new PortalDataContextDataContext().prtl_news_fpe_trans.OrderByDescending(
                       nt => nt.prtl_news_fpe.News_date).
                       Where(tr => tr.prtl_news_fpe.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_fpe.News_date >= FilterDate &&
                                   tr.prtl_news_fpe.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_fpe.Owner_ID == null)).Count();
            }
                //*********************
            else if (abbr.ToLower() == "vmed")
            {
                return new PortalDataContextDataContext().prtl_news_VMed_trans.OrderByDescending(
                       nt => nt.prtl_news_VMed.News_date).
                       Where(tr => tr.prtl_news_VMed.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_VMed.News_date >= FilterDate &&
                                   tr.prtl_news_VMed.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_VMed.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "pharm")
            {
                return new PortalDataContextDataContext().prtl_news_Pharm_trans.OrderByDescending(
                       nt => nt.prtl_news_Pharm.News_date).
                       Where(tr => tr.prtl_news_Pharm.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_Pharm.News_date >= FilterDate &&
                                   tr.prtl_news_Pharm.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_Pharm.Owner_ID == null)).Count();
            }
                //*************************
            else if (abbr.ToLower() == "fa")
            {
                return new PortalDataContextDataContext().prtl_news_fa_trans.OrderByDescending(
                       nt => nt.prtl_news_fa.News_date).
                       Where(tr => tr.prtl_news_fa.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_fa.News_date >= FilterDate &&
                                   tr.prtl_news_fa.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_fa.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_fa.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "art")
            {
                return new PortalDataContextDataContext().prtl_news_art_trans.OrderByDescending(
                       nt => nt.prtl_news_art.News_date).
                       Where(tr => tr.prtl_news_art.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_art.News_date >= FilterDate &&
                                   tr.prtl_news_art.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_art.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_art.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "ho")
            {
                return new PortalDataContextDataContext().prtl_news_ho_trans.OrderByDescending(
                       nt => nt.prtl_news_ho.News_date).
                       Where(tr => tr.prtl_news_ho.Published && tr.prtl_Language.LCID == currentLanguage
                                   && tr.prtl_news_ho.News_date >= FilterDate &&
                                   tr.prtl_news_ho.News_date <= FilterDate2 &&
                                   ((tr.prtl_news_ho.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                     owner_id.GetValueOrDefault(Guid.Empty))
                                    || tr.prtl_news_ho.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "med")
            {
                return new PortalDataContextDataContext().prtl_news_med_trans.OrderByDescending(
                        nt => nt.prtl_news_med.News_date).
                        Where(tr => tr.prtl_news_med.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_med.News_date >= FilterDate &&
                                    tr.prtl_news_med.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_med.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_med.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "liv")
            {
                return new PortalDataContextDataContext().prtl_news_liv_trans.OrderByDescending(
                        nt => nt.prtl_news_liv.News_date).
                        Where(tr => tr.prtl_news_liv.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_liv.News_date >= FilterDate &&
                                    tr.prtl_news_liv.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_liv.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_liv.Owner_ID == null)).Count();
            }
            else if (abbr.ToLower() == "com")
            {
                return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(
                        nt => nt.prtl_news_com.News_date).
                        Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_com.News_date >= FilterDate &&
                                    tr.prtl_news_com.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_com.Owner_ID == null)).Count();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return new PortalDataContextDataContext().prtl_news_ECEDU_trans.OrderByDescending(
                        nt => nt.prtl_news_ECEDU.News_date).
                        Where(tr => tr.prtl_news_ECEDU.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_ECEDU.News_date >= FilterDate &&
                                    tr.prtl_news_ECEDU.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_ECEDU.Owner_ID == null)).Count();
            }//14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                return new PortalDataContextDataContext().prtl_news_AI_trans.OrderByDescending(
                        nt => nt.prtl_news_AI.News_date).
                        Where(tr => tr.prtl_news_AI.Published && tr.prtl_Language.LCID == currentLanguage
                                    && tr.prtl_news_AI.News_date >= FilterDate &&
                                    tr.prtl_news_AI.News_date <= FilterDate2 &&
                                    ((tr.prtl_news_AI.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                      owner_id.GetValueOrDefault(Guid.Empty))
                                     || tr.prtl_news_AI.Owner_ID == null)).Count();
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(
            //            nt => nt.prtl_news_com.News_date).
            //            Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
            //                        && tr.prtl_news_com.News_date >= FilterDate &&
            //                        tr.prtl_news_com.News_date <= FilterDate2 &&
            //                        ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) ==
            //                          owner_id.GetValueOrDefault(Guid.Empty))
            //                         || tr.prtl_news_com.Owner_ID == null)).Count();
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.OrderByDescending(
            //            nt => nt.prtl_news_com.News_date).
            //            Where(tr => tr.prtl_news_com.Published && tr.prtl_Language.LCID == currentLanguage
            //                        && tr.prtl_news_com.News_date >= FilterDate &&
            //                        tr.prtl_news_com.News_date <= FilterDate2 &&
            //                        ((tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) ==
            //                          owner_id.GetValueOrDefault(Guid.Empty))
            //                         || tr.prtl_news_com.Owner_ID == null)).Count();
            //}
            else
            {
                return new PortalDataContextDataContext().prtl_News_Translations.OrderByDescending(
                      nt => nt.prtl_New.News_date).
                      Where(tr => tr.prtl_New.Published && tr.prtl_Language.LCID == currentLanguage
                                  && tr.prtl_New.News_date >= FilterDate &&
                                  tr.prtl_New.News_date <= FilterDate2 &&
                                  ((tr.prtl_New.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                                    owner_id.GetValueOrDefault(Guid.Empty))
                                   || tr.prtl_New.Owner_ID == null)).Count();
            }
            


        }

        // Make owner_id by default equals to null to prevent having to update all single entity (like university) method usages
        public static IEnumerable<NewsDetails> GetNewsDetails(string currentLanguage, string abbr, Guid? owner_id = null)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                return new PortalDataContextDataContext().prtl_news_univ_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_univ.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_univ.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr,Image=ntr.prtl_news_univ.News_img, Date = ntr.prtl_news_univ.News_date, Head = ntr.News_Head, ID = ntr.News_Id });

            }
            else if (abbr.ToLower() == "fci")
            {
                return new PortalDataContextDataContext().prtl_news_fci_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_fci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_fci.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_fci.News_img, Date = ntr.prtl_news_fci.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "fee")
            {
                return new PortalDataContextDataContext().prtl_news_fee_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_fee.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_fee.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_fee.News_img, Date = ntr.prtl_news_fee.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "eng")
            {
                return new PortalDataContextDataContext().prtl_news_eng_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_eng.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_eng.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_eng.News_img, Date = ntr.prtl_news_eng.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "nur")
            {
                return new PortalDataContextDataContext().prtl_news_nur_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_nur.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_nur.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_nur.News_img, Date = ntr.prtl_news_nur.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "edu")
            {
                return new PortalDataContextDataContext().prtl_news_edu_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_edu.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_edu.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_edu.News_img, Date = ntr.prtl_news_edu.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "sci")
            {
                return new PortalDataContextDataContext().prtl_news_sci_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_sci.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_sci.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_sci.News_img, Date = ntr.prtl_news_sci.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "edv")
            {
                return new PortalDataContextDataContext().prtl_news_edv_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_edv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_edv.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_edv.News_img, Date = ntr.prtl_news_edv.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "agr")
            {
                return new PortalDataContextDataContext().prtl_news_agr_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_agr.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_agr.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_agr.News_img, Date = ntr.prtl_news_agr.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "hec")
            {
                return new PortalDataContextDataContext().prtl_news_hec_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_hec.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_hec.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_hec.News_img, Date = ntr.prtl_news_hec.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "law")
            {
                return new PortalDataContextDataContext().prtl_news_law_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_law.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_law.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_law.News_img, Date = ntr.prtl_news_law.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "fpe")
            {
                return new PortalDataContextDataContext().prtl_news_fpe_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_fpe.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_fpe.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_fpe.News_img, Date = ntr.prtl_news_fpe.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
                //******************
            else if (abbr.ToLower() == "pharm")
            {
                return new PortalDataContextDataContext().prtl_news_Pharm_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_Pharm.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_Pharm.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_Pharm.News_img, Date = ntr.prtl_news_Pharm.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "vmed")
            {
                return new PortalDataContextDataContext().prtl_news_VMed_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_VMed.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_VMed.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_VMed.News_img, Date = ntr.prtl_news_VMed.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
                //*************************
            else if (abbr.ToLower() == "fa")
            {
                return new PortalDataContextDataContext().prtl_news_fa_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_fa.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_fa.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_fa.News_img, Date = ntr.prtl_news_fa.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "art")
            {
                return new PortalDataContextDataContext().prtl_news_art_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_art.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_art.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_art.News_img, Date = ntr.prtl_news_art.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "ho")
            {
                return new PortalDataContextDataContext().prtl_news_ho_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_ho.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_ho.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_ho.News_img, Date = ntr.prtl_news_ho.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "med")
            {
                return new PortalDataContextDataContext().prtl_news_med_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_med.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_med.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_med.News_img, Date = ntr.prtl_news_med.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "liv")
            {
                return new PortalDataContextDataContext().prtl_news_liv_trans.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_news_liv.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_news_liv.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_liv.News_img, Date = ntr.prtl_news_liv.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            else if (abbr.ToLower() == "com")
            {
                return new PortalDataContextDataContext().prtl_news_com_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_com.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_com.News_img, Date = ntr.prtl_news_com.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return new PortalDataContextDataContext().prtl_news_ECEDU_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_ECEDU.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_ECEDU.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_ECEDU.News_img, Date = ntr.prtl_news_ECEDU.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                return new PortalDataContextDataContext().prtl_news_AI_trans.
                Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                    (tr.prtl_news_AI.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                    || tr.prtl_news_AI.Owner_ID == null)
                    )
                        .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_AI.News_img, Date = ntr.prtl_news_AI.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.
            //    Where(tr => tr.prtl_Language.LCID == currentLanguage &&
            //        (tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
            //        || tr.prtl_news_com.Owner_ID == null)
            //        )
            //            .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_com.News_img, Date = ntr.prtl_news_com.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            //}
            //else if (abbr.ToLower() == "media")
            //{
            //    return new PortalDataContextDataContext().prtl_news_com_trans.
            //    Where(tr => tr.prtl_Language.LCID == currentLanguage &&
            //        (tr.prtl_news_com.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
            //        || tr.prtl_news_com.Owner_ID == null)
            //        )
            //            .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_news_com.News_img, Date = ntr.prtl_news_com.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            //}
            else
            {
                return new PortalDataContextDataContext().prtl_News_Translations.
               Where(tr => tr.prtl_Language.LCID == currentLanguage &&
                   (tr.prtl_New.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                   || tr.prtl_New.Owner_ID == null)
                   )
                       .Select(ntr => new NewsDetails { Abbr = ntr.News_Abbr, Image = ntr.prtl_New.News_img, Date = ntr.prtl_New.News_date, Head = ntr.News_Head, ID = ntr.News_Id });
            }
           
        }
        public static prtl_News_Translation GetNewsById(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_News_Translations.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_univ_tran Get_univ_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_univ_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_fci_tran Get_fci_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_fci_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_media_tran Get_media_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_media_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        //14-4-2022
        public static prtl_news_AI_tran Get_ai_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_AI_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_dent_tran Get_dent_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_dent_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_fee_tran Get_fee_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_fee_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_eng_tran Get_eng_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_eng_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_sci_tran Get_sci_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_sci_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_edu_tran Get_edu_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_edu_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_nur_tran Get_nur_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_nur_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_edv_tran Get_edv_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_edv_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_art_tran Get_art_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_art_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_law_tran Get_law_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_law_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_com_tran Get_com_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_com_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        //12121212
        public static prtl_news_ECEDU_tran Get_ecedu_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_ECEDU_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_med_tran Get_med_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_med_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_fpe_tran Get_fpe_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_fpe_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        //*******************
        public static prtl_news_Pharm_tran Get_Pharm_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_Pharm_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_VMed_tran Get_VMed_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_VMed_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        //*************
        public static prtl_news_fa_tran Get_fas_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_fa_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_hec_tran Get_hec_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_hec_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_agr_tran Get_agr_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_agr_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_ho_tran Get_hos_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_ho_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
        public static prtl_news_liv_tran Get_liv_NewsByID(int id, string lang)
        {
            return new PortalDataContextDataContext().prtl_news_liv_trans.SingleOrDefault(x => x.News_Id == id && x.prtl_Language.LCID == lang);
        }
       
        public static int GetNewsTranslationCount(int newsID, string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    return dc.prtl_news_univ_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "fci")
                {
                    return dc.prtl_news_fci_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "fee")
                {
                    return dc.prtl_news_fee_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "eng")
                {
                    return dc.prtl_news_eng_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "nur")
                {
                    return dc.prtl_news_nur_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "edu")
                {
                    return dc.prtl_news_edu_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "sci")
                {
                    return dc.prtl_news_sci_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "edv")
                {
                    return dc.prtl_news_edv_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "agr")
                {
                    return dc.prtl_news_agr_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "hec")
                {
                    return dc.prtl_news_hec_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "law")
                {
                    return dc.prtl_news_law_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "fpe")
                {
                    return dc.prtl_news_fpe_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "fa")
                {
                    return dc.prtl_news_fa_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "art")
                {
                    return dc.prtl_news_art_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "ho")
                {
                    return dc.prtl_news_ho_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "med")
                {
                    return dc.prtl_news_med_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "liv")
                {
                    return dc.prtl_news_liv_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "com")
                {
                    return dc.prtl_news_com_trans.Count(x => x.News_Id == newsID);
                }//12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    return dc.prtl_news_ECEDU_trans.Count(x => x.News_Id == newsID);
                }
                else if (abbr.ToLower() == "media")
                {
                    return dc.prtl_news_media_trans.Count(x => x.News_Id == newsID);
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    return dc.prtl_news_AI_trans.Count(x => x.News_Id == newsID);
                }
                //else if (abbr.ToLower() == "dent")
                //{
                //    return dc.prtl_news_com_trans.Count(x => x.News_Id == newsID);
                //}
                else
                {
                    return dc.prtl_News_Translations.Count(x => x.News_Id == newsID);
                }
            }
            
        }

        public static IEnumerable<prtl_News_Translation> GetTopNews(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAllNews(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_univ_tran> GetTop_univ_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_univ_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_fci_tran> GetTop_fci_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_fci_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        //33333333333
        public static IEnumerable<prtl_news_media_tran> GetTop_media_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_media_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_fee_tran> GetTop_fee_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_fee_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_eng_tran> GetTop_eng_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_eng_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_sci_tran> GetTop_sci_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_sci_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_nur_tran> GetTop_nur_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_nur_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_edu_tran> GetTop_edu_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_edu_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_edv_tran> GetTop_edv_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_edv_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_hec_tran> GetTop_hec_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_hec_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_agr_tran> GetTop_agr_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_agr_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_med_tran> GetTop_med_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_med_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_ho_tran> GetTop_ho_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_hos_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_art_tran> GetTop_art_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_art_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_com_tran> GetTop_com_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_com_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }//12121212
        public static IEnumerable<prtl_news_ECEDU_tran> GetTop_ecedu_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_ECEDU_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_law_tran> GetTop_law_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_law_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_fpe_tran> GetTop_fpe_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_fpe_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        //*****************
        public static IEnumerable<prtl_news_VMed_tran> GetTop_VMed_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_VMed_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_Pharm_tran> GetTop_Pharm_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_Pharm_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        //***********************
        public static IEnumerable<prtl_news_fa_tran> GetTop_fas_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_fas_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_liv_tran> GetTop_liv_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_liv_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_news_AI_tran> GetTop_ai_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_ai_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        //fatma 6-6-2022
        public static IEnumerable<prtl_news_dent_tran> GetTop_dent_News(string currentLanguage, int count, Guid? owner_id)
        {
            return GetAll_dent_News(currentLanguage, owner_id)// This is the limit of data to be viewed
                        .Take(count);
        }
        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                 Except(dc.prtl_news_univ_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "fci")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                 Except(dc.prtl_news_fci_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "fee")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_fee_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "eng")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_eng_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "nur")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_nur_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "edu")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_edu_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "sci")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_sci_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "edv")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_edv_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "agr")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_agr_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "hec")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_hec_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "law")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_law_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "fpe")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_fpe_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
                //***************
            else if (abbr.ToLower() == "vmed")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_VMed_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "pharm")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_Pharm_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
                //********************
            else if (abbr.ToLower() == "fa")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_fa_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "art")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_art_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "ho")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_ho_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "med")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_med_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "liv")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                 Except(dc.prtl_news_liv_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "com")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_com_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_ECEDU_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "media")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_media_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            //14-4-2022
            else if (abbr.ToLower() == "ai")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_news_AI_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            //else if (abbr.ToLower() == "dent")
            //{
            //    return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
            //    Except(dc.prtl_news_com_trans.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            //}
            else
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                 Except(dc.prtl_News_Translations.Where(tr => tr.News_Id.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            
        }

        public struct NewsDetails
        {
            public string Abbr { get; set; }

            public DateTime Date { get; set; }

            public string Head { get; set; }
                 public string Image { get; set; }

            public int ID { get; set; }
        }

        public static IEnumerable<prtl_News_Translation> GetTop_Featured_News(string currentLanguage, int count, Guid? owner_id)
        
        {
            return new PortalDataContextDataContext().prtl_News_Translations.OrderByDescending(nt => nt.prtl_New.News_date).
                Where(tr => tr.prtl_New.Published && tr.prtl_New.IsFeatured && tr.prtl_New.prtl_Owner.Type==4 && tr.prtl_Language.LCID == currentLanguage
                            ).Take(count); 
        }
    }
}