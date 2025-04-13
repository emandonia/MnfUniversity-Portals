using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Portal_DAL;

namespace BLL
{
  public  struct Translation
    {
        public string translation;
        public string lcid;
    }
    public static class Prtl_TranslationUtility
    {

        public static void DeleteTranslations(Guid Translation_ID,string abbr)
        {
            var dac = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var translations = dac.prtl_menu_univ_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_univ_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();

                }
                else if (abbr.ToLower() == "fci")
                {
                    var translations = dac.prtl_menu_fci_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_fci_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "fee")
                {
                    var translations = dac.prtl_menu_fee_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_fee_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var translations = dac.prtl_menu_eng_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_eng_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var translations = dac.prtl_menu_nur_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_nur_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var translations = dac.prtl_menu_edu_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_edu_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var translations = dac.prtl_menu_sci_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_sci_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var translations = dac.prtl_menu_edv_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_edv_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var translations = dac.prtl_menu_agr_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_agr_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var translations = dac.prtl_menu_hec_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_hec_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var translations = dac.prtl_menu_law_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_law_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var translations = dac.prtl_menu_fpe_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_fpe_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                    //********************
                else if (abbr.ToLower() == "vmed")
                {
                    var translations = dac.prtl_menu_VMed_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_VMed_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var translations = dac.prtl_menu_Pharm_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_Pharm_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                    //****************************
                else if (abbr.ToLower() == "fa")
                {
                    var translations = dac.prtl_menu_fa_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_fa_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                    //*****************
                else if (abbr.ToLower() == "vmed")
                {
                    var translations = dac.prtl_menu_VMed_trans .Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_VMed_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }


                else if (abbr.ToLower() == "pharm")
                {
                    var translations = dac.prtl_menu_Pharm_trans .Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_Pharm_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                    //********************
                else if (abbr.ToLower() == "art")
                {
                    var translations = dac.prtl_menu_art_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_art_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var translations = dac.prtl_menu_ho_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_ho_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var translations = dac.prtl_menu_med_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_med_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var translations = dac.prtl_menu_liv_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_liv_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var translations = dac.prtl_menu_com_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_com_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var translations = dac.prtl_menu_ECEDU_trans.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_menu_ECEDU_trans.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var translations = dac.prtl_menu_com_trans.Where(x => x.Translation_ID == Translation_ID);
                //    dac.prtl_menu_com_trans.DeleteAllOnSubmit(translations);
                //    dac.SubmitChanges();
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var translations = dac.prtl_menu_com_trans.Where(x => x.Translation_ID == Translation_ID);
                //    dac.prtl_menu_com_trans.DeleteAllOnSubmit(translations);
                //    dac.SubmitChanges();
                //}
                else
                {
                    var translations = dac.prtl_Translations.Where(x => x.Translation_ID == Translation_ID);
                    dac.prtl_Translations.DeleteAllOnSubmit(translations);
                    dac.SubmitChanges();
                }
               
            }
        }
        public static void InsertNewOwnerTrans(Guid ownerid, string membername, int langid)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (!String.IsNullOrEmpty(membername))
                {
                    var u = new prtl_Translation
                    {
                        Translation_ID = ownerid,
                        Translation_Data = membername,
                        Lang_Id = langid
                    };
                    dc.prtl_Translations.InsertOnSubmit(u);
                    dc.SubmitChanges();
                }
                else
                {
                    var u = new prtl_Translation
                    {
                        Translation_ID = ownerid,
                        Translation_Data = "Not Translated",
                        Lang_Id = langid
                    };
                    dc.prtl_Translations.InsertOnSubmit(u);
                    dc.SubmitChanges();
                }
               
            }

        }
        public static prtl_Translation GetTransByMenuIDAndCurrentLang(int id, string LCID)
        {

            return new PortalDataContextDataContext().prtl_Translations.SingleOrDefault(x => x.prtl_Menu.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_univ_tran Get_univ_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_univ_trans.SingleOrDefault(x => x.prtl_menu_univ.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_fci_tran Get_fci_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_fci_trans.SingleOrDefault(x => x.prtl_menu_fci.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_AI_tran Get_ai_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_AI_trans.SingleOrDefault(x => x.prtl_menu_AI.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        //3333333
        public static prtl_menu_media_tran Get_media_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_media_trans.SingleOrDefault(x => x.prtl_menu_media.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_fee_tran Get_fee_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_fee_trans.SingleOrDefault(x => x.prtl_menu_fee.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_eng_tran Get_eng_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_eng_trans.SingleOrDefault(x => x.prtl_menu_eng.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_sci_tran Get_sci_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_sci_trans.SingleOrDefault(x => x.prtl_menu_sci.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_med_tran Get_med_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_med_trans.SingleOrDefault(x => x.prtl_menu_med.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_nur_tran Get_nur_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_nur_trans.SingleOrDefault(x => x.prtl_menu_nur.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_liv_tran Get_liv_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_liv_trans.SingleOrDefault(x => x.prtl_menu_liv.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_ho_tran Get_ho_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_ho_trans.SingleOrDefault(x => x.prtl_menu_ho.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_hec_tran Get_hec_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_hec_trans.SingleOrDefault(x => x.prtl_menu_hec.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_agr_tran Get_agr_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_agr_trans.SingleOrDefault(x => x.prtl_menu_agr.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_edu_tran Get_edu_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_edu_trans.SingleOrDefault(x => x.prtl_menu_edu.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_edv_tran Get_edv_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_edv_trans.SingleOrDefault(x => x.prtl_menu_edv.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_fpe_tran Get_fpe_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_fpe_trans.SingleOrDefault(x => x.prtl_menu_fpe.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_fa_tran Get_fa_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_fa_trans.SingleOrDefault(x => x.prtl_menu_fa.Menu_id == id && x.prtl_Language.LCID == LCID);
        }

        //***************
        public static prtl_menu_Pharm_tran Get_Pharm_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_Pharm_trans.SingleOrDefault(x => x.prtl_menu_Pharm.Menu_id == id && x.prtl_Language.LCID == LCID);
        }

        public static prtl_menu_VMed_tran Get_VMed_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_VMed_trans.SingleOrDefault(x => x.prtl_menu_VMed.Menu_id == id && x.prtl_Language.LCID == LCID);
        }

        //********************
        public static prtl_menu_art_tran Get_art_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_art_trans.SingleOrDefault(x => x.prtl_menu_art.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_law_tran Get_law_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_law_trans.SingleOrDefault(x => x.prtl_menu_law.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        public static prtl_menu_com_tran Get_com_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_com_trans.SingleOrDefault(x => x.prtl_menu_com.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        //16-6-2022
        public static prtl_menu_dent_tran Get_dent_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_dent_trans.SingleOrDefault(x => x.prtl_menu_dent.Menu_id == id && x.prtl_Language.LCID == LCID);
        }
        //12121212
        public static prtl_menu_ECEDU_tran Get_ecedu_TransByMenuIDAndCurrentLang(int id, string LCID)
        {
            return new PortalDataContextDataContext().prtl_menu_ECEDU_trans.SingleOrDefault(x => x.prtl_menu_ECEDU.Menu_id == id && x.prtl_Language.LCID == LCID);
        }

        public static string GetTransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_Translations.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_univ_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_univ_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_fci_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_fci_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_fee_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_fee_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_eng_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_eng_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_sci_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_sci_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_art_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_art_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }//12121212
        public static string Get_ecedu_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_ECEDU_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_com_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_com_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_law_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_law_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_nur_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_nur_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_liv_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_liv_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_med_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_med_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_edu_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_edu_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_edv_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_edv_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_agr_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_agr_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_hec_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_hec_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_fpe_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_fpe_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        //*******************
        public static string Get_VMed_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_VMed_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_Pharm_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_Pharm_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
         //*****************************
        public static string Get_fa_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_fa_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }
        public static string Get_ho_TransDataByTranIDandLCID(Guid tranID, string lcid)
        {
            var trans = new PortalDataContextDataContext().prtl_menu_ho_trans.
                SingleOrDefault(t => t.Translation_ID == tranID && t.prtl_Language.LCID == lcid);
            return trans == null ? null : trans.Translation_Data;
        }

        public static prtl_Translation GetTranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_Translations.Single(tr => tr.Id == id);
        }
        public static prtl_menu_univ_tran Get_univ_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_univ_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_fci_tran Get_fci_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_fci_trans.Single(tr => tr.id == id);
        }
        //333333333
        public static prtl_menu_media_tran Get_media_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_media_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_AI_tran Get_ai_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_AI_trans.Single(tr => tr.id == id);
        }
        //16-6-2022
        public static prtl_menu_dent_tran Get_dent_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_dent_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_fee_tran Get_fee_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_fee_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_eng_tran Get_eng_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_eng_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_sci_tran Get_sci_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_sci_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_art_tran Get_art_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_art_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_law_tran Get_law_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_law_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_com_tran Get_com_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_com_trans.Single(tr => tr.id == id);
        }//12121212
        public static prtl_menu_ECEDU_tran Get_ecedu_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_ECEDU_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_nur_tran Get_nur_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_nur_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_med_tran Get_med_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_med_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_ho_tran Get_hos_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_ho_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_hec_tran Get_hec_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_hec_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_agr_tran Get_agr_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_agr_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_edu_tran Get_edu_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_edu_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_edv_tran Get_edv_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_edv_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_fpe_tran Get_fpe_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_fpe_trans.Single(tr => tr.id == id);
        }
        //*************
        public static prtl_menu_VMed_tran Get_VMed_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_VMed_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_Pharm_tran Get_Pharm_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_Pharm_trans.Single(tr => tr.id == id);
        }
        //**********************
        public static prtl_menu_fa_tran Get_fas_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_fa_trans.Single(tr => tr.id == id);
        }
        public static prtl_menu_liv_tran Get_liv_TranslationByID(int id)
        {
            return new PortalDataContextDataContext().prtl_menu_liv_trans.Single(tr => tr.id == id);
        }
       
        public static IEnumerable<prtl_Translation> GetTranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_Translations.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_univ_tran> Get_univ_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_univ_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_fci_tran> Get_fci_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_fci_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_fee_tran> Get_fee_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_fee_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_eng_tran> Get_eng_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_eng_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_sci_tran> Get_sci_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_sci_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_med_tran> Get_med_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_med_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_ho_tran> Get_hos_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_ho_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_liv_tran> Get_liv_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_liv_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_edu_tran> Get_edu_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_edu_trans.Where(x => x.Translation_ID == TranslationID);
        }

        //********************
        public static IEnumerable<prtl_menu_VMed_tran> Get_VMed_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_VMed_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_Pharm_tran> Get_Pharm_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_Pharm_trans.Where(x => x.Translation_ID == TranslationID);
        }
        ///***************************
        public static IEnumerable<prtl_menu_edv_tran> Get_edv_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_edv_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_hec_tran> Get_hec_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_hec_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_agr_tran> Get_agr_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_agr_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_art_tran> Get_art_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {

            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_art_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_law_tran> Get_law_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_law_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_com_tran> Get_com_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_com_trans.Where(x => x.Translation_ID == TranslationID);
        }
        //3333333
        public static IEnumerable<prtl_menu_media_tran> Get_media_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_media_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_AI_tran> Get_ai_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_AI_trans.Where(x => x.Translation_ID == TranslationID);
        }
        //fatma 6-6-2022
        public static IEnumerable<prtl_menu_dent_tran> Get_dent_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_dent_trans.Where(x => x.Translation_ID == TranslationID);
        }
        //12121212
        public static IEnumerable<prtl_menu_ECEDU_tran> Get_ecedu_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_ECEDU_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_fpe_tran> Get_fpe_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_fpe_trans.Where(x => x.Translation_ID == TranslationID);
        }
        //**********
        //public static IEnumerable<prtl_menu_VMed_tran> Get_VMed_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        //{
        //    var _dc = dataContext ?? new PortalDataContextDataContext()
        //    return _dc.prtl_menu_VMed_trans.Where(x => x.Translation_ID == TranslationID);
        //}
        //public static IEnumerable<prtl_menu_Pharm_tran> Get_Pharm_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        //{
        //    var _dc = dataContext ?? new PortalDataContextDataContext()
        //    return _dc.prtl_menu_Pharm_trans.Where(x => x.Translation_ID == TranslationID);
        //}
        //**********************
        public static IEnumerable<prtl_menu_fa_tran> Get_fas_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_fa_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static IEnumerable<prtl_menu_nur_tran> Get_nur_TranslationsByTranslationID(Guid TranslationID, PortalDataContextDataContext dataContext = null)
        {
            var _dc = dataContext ?? new PortalDataContextDataContext();
            return _dc.prtl_menu_nur_trans.Where(x => x.Translation_ID == TranslationID);
        }
        public static void InsertTranslation(prtl_Translation newTranslation)
        {
            var dac = new PortalDataContextDataContext();
            {
                dac.prtl_Translations.InsertOnSubmit(newTranslation);
                dac.SubmitChanges();
            }
        }

        public static IEnumerable<prtl_Language> LangsNotTranslated(Guid CurrentTranslationID, string TransID,[Optional] string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_menu_univ_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();

            }
            else if (abbr.ToLower() == "fci")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_fci_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "fee")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_menu_fee_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "eng")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_eng_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "nur")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_menu_nur_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "edu")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_edu_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "sci")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_sci_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "edv")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_edv_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "agr")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_agr_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "hec")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_hec_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "law")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_law_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "fpe")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_fpe_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
                //**************
            else if (abbr.ToLower() == "pharm")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_Pharm_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "vmed")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_VMed_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
                //***********************
            else if (abbr.ToLower() == "fa")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_fa_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "art")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_art_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "ho")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_ho_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "med")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_med_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "liv")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_liv_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "com")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_com_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_ECEDU_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "media")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_com_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else if (abbr.ToLower() == "dent")
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
               Except(dc.prtl_menu_com_trans.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            else
            {
                return Prtl_LanguagesUtility.Getlanguages(CurrentTranslationID, dc).
                Except(dc.prtl_Translations.Where(tr => tr.Translation_ID.ToString() == TransID).Select(tr => tr.prtl_Language)).ToList();
            }
            
        }

        public static IEnumerable<prtl_Translation> OwnerNameTranslations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return GetTranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_univ_tran> OwnerName_univ_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_univ_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_fci_tran> OwnerName_fci_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_fci_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_fee_tran> OwnerName_fee_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_fee_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_eng_tran> OwnerName_eng_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_eng_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_nur_tran> OwnerName_nur_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_nur_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_med_tran> OwnerName_med_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_med_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_liv_tran> OwnerName_liv_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_liv_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_com_tran> OwnerName_com_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_com_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_ho_tran> OwnerName_hos_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_hos_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_art_tran> OwnerName_art_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_art_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_law_tran> OwnerName_law_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_law_TranslationsByTranslationID(ownerID, dc);
        }
        
        //33333
        public static IEnumerable<prtl_menu_media_tran> OwnerName_media_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_media_TranslationsByTranslationID(ownerID, dc);
        }
        //13-4-2022
        public static IEnumerable<prtl_menu_AI_tran> OwnerName_ai_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_ai_TranslationsByTranslationID(ownerID, dc);
        }
        //fatma 6-6-2022
        public static IEnumerable<prtl_menu_dent_tran> OwnerName_dent_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_dent_TranslationsByTranslationID(ownerID, dc);
        }
        //12121212
        public static IEnumerable<prtl_menu_ECEDU_tran> OwnerName_ecedu_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_ecedu_TranslationsByTranslationID(ownerID, dc);
        }

        //public static IEnumerable<prtl_menu_media_tran> OwnerName_media_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        //{
        //    return Get_media_TranslationsByTranslationID(ownerID, dc);
        //}
        public static IEnumerable<prtl_menu_sci_tran> OwnerName_sci_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_sci_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_edu_tran> OwnerName_edu_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_edu_TranslationsByTranslationID(ownerID, dc);
        }
        //*********************
        public static IEnumerable<prtl_menu_VMed_tran> OwnerName_VMed_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_VMed_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_Pharm_tran> OwnerName_Pharm_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_Pharm_TranslationsByTranslationID(ownerID, dc);
        }
        //**********************
        public static IEnumerable<prtl_menu_edv_tran> OwnerName_edv_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_edv_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_hec_tran> OwnerName_hec_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_hec_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_agr_tran> OwnerName_agr_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_agr_TranslationsByTranslationID(ownerID, dc);
        }
        public static IEnumerable<prtl_menu_fpe_tran> OwnerName_fpe_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_fpe_TranslationsByTranslationID(ownerID, dc);
        }
       
        public static IEnumerable<prtl_menu_fa_tran> OwnerName_fas_Translations(Guid ownerID, PortalDataContextDataContext dc = null)
        {
            return Get_fas_TranslationsByTranslationID(ownerID, dc);
        }

        public static int TranslationsCount(string tranID,[Optional]string abbr)
        {
            if (abbr == null)
            {
                return new PortalDataContextDataContext().prtl_menu_univ_trans.Count(x => x.Translation_ID.ToString() == tranID);

            }
            else if (abbr.ToLower() == "fci")
            {
                return new PortalDataContextDataContext().prtl_menu_fci_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "fee")
            {
                return new PortalDataContextDataContext().prtl_menu_fee_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "eng")
            {
                return new PortalDataContextDataContext().prtl_menu_eng_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "nur")
            {
                return new PortalDataContextDataContext().prtl_menu_nur_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "edu")
            {
                return new PortalDataContextDataContext().prtl_menu_edu_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "sci")
            {
                return new PortalDataContextDataContext().prtl_menu_sci_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "edv")
            {
                return new PortalDataContextDataContext().prtl_menu_edv_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "agr")
            {
                return new PortalDataContextDataContext().prtl_menu_agr_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "hec")
            {
                return new PortalDataContextDataContext().prtl_menu_hec_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "law")
            {
                return new PortalDataContextDataContext().prtl_menu_law_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "fpe")
            {
                return new PortalDataContextDataContext().prtl_menu_fpe_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
                //***************
            else if (abbr.ToLower() == "vmed")
            {
                return new PortalDataContextDataContext().prtl_menu_VMed_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "pharm")
            {
                return new PortalDataContextDataContext().prtl_menu_Pharm_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
                //*********************
            else if (abbr.ToLower() == "fa")
            {
                return new PortalDataContextDataContext().prtl_menu_fa_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "art")
            {
                return new PortalDataContextDataContext().prtl_menu_art_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "ho")
            {
                return new PortalDataContextDataContext().prtl_menu_ho_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "med")
            {
                return new PortalDataContextDataContext().prtl_menu_med_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "liv")
            {
                return new PortalDataContextDataContext().prtl_menu_liv_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "com")
            {
                return new PortalDataContextDataContext().prtl_menu_com_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                return new PortalDataContextDataContext().prtl_menu_ECEDU_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            else if (abbr.ToLower() == "media")
            {
                return new PortalDataContextDataContext().prtl_menu_media_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }
            //else if (abbr.ToLower() == "dent")
            //{
            //    return new PortalDataContextDataContext().prtl_menu_com_trans.Count(x => x.Translation_ID.ToString() == tranID);
            //}
            //*********
            else if (abbr.ToLower() == "vmed")
            {
                return new PortalDataContextDataContext().prtl_menu_VMed_trans.Count(x => x.Translation_ID.ToString() == tranID);
            }



            //else if (abbr.ToLower() == "pharm")
            //{
            //    return new PortalDataContextDataContext().prtl_menu_Pharm_trans.Count(x => x.Translation_ID.ToString() == tranID);
            //} 
                //*************
            else
            {
                return new PortalDataContextDataContext().prtl_Translations.Count(x => x.Translation_ID.ToString() == tranID);
            }
            
        }
        public static  prtl_Translation  GetTranslationsByTranslationID_Lang(Guid TranslationID,int langid)
        {
            var datc = new PortalDataContextDataContext();
            prtl_Translation x = (from c in datc.prtl_Translations where c.Translation_ID == TranslationID && c.Lang_Id == langid select c).SingleOrDefault();
            return x;
        }
    }
}