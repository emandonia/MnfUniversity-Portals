using System;
using System.Linq;
using System.Web.UI.WebControls;
using Portal_DAL;
using System.Collections.Generic;
using MnfUniversity_Portals;

namespace BLL
{
    public static class prtl_ArticlesUtility
    {
        public static void ClearArticlesWithMenuItemTranslationID(Guid MenuTranslationID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_univ.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_univ = null;
                    dc.SubmitChanges();

                }
               
                    ////////////////**************
                else if (abbr.ToLower() == "fci")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_fci.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_fci = null;
                    dc.SubmitChanges();
                }
                    //********************************
                else if (abbr.ToLower() == "fee")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_fee.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_fee = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_eng.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_eng = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_nur.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_nur = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_edu.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_edu = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_sci.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_sci = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_edv.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_edv = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_agr.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_agr = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_hec.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_hec = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_law.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_law = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_fpe.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_fpe = null;
                    dc.SubmitChanges();
                }
                    //******************
                else if (abbr.ToLower() == "pharm")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_Pharm.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_Pharm = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_VMed.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_VMed = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fa")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_fa.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_fa = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "art")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_art.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_art = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_ho.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_ho = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_med.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_med = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_liv.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_liv = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_com.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_com = null;
                    dc.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_ECEDU.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_ECEDU = null;
                    dc.SubmitChanges();
                }
                //13-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_AI.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_AI = null;
                    dc.SubmitChanges();
                }
                //16-6-2022
                else if (abbr.ToLower() == "media")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_media.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_media = null;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "dent")
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_menu_dent.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_menu_dent = null;
                    dc.SubmitChanges();
                }
                else
                {
                    var article = dc.prtl_Articles.Where(a => a.prtl_Menu.Translation_ID == MenuTranslationID);
                    foreach (var prtlArticle in article)
                        prtlArticle.prtl_Menu = null;
                    dc.SubmitChanges();
                }
               
            }
        }

        public static prtl_Owner GetOwnerByArticleId(int id)
        {
            var dc = new PortalDataContextDataContext();
            {
                var ownerid = dc.prtl_Articles.SingleOrDefault(xx => xx.ID == id).Owner_ID;
                return dc.prtl_Owners.SingleOrDefault(x => x.Owner_ID == ownerid);


            }
        }
        public static bool GetPublishedState(string ID)
        {
            var q = new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.ID.ToString() == ID); 
            if(q.Published)
            {
                return true;
            }else
            {
                return false;
            }

        }
        public static int checkIfMenuIdExists(int MenuId)
        {
            var singleOrDefault = new PortalDataContextDataContext().prtl_Menus.SingleOrDefault(x => x.Menu_id == MenuId);
            if (singleOrDefault != null)
            {
                return singleOrDefault.Menu_id;
            }
            else
            {
                return 0;
            }
        }

        public static prtl_Article GetArticleByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.ID == ID);
        }

        public static prtl_Article GetArticlebyMenuItemID(Guid tid, Guid currentownerid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var ID = dc.prtl_menu_univ_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_univ.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID==currentownerid);

            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var ID = dc.prtl_menu_fci_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_fci.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "fee")
                {
                    var ID = dc.prtl_menu_fee_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_fee.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "eng")
                {
                    var ID = dc.prtl_menu_eng_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_eng.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "nur")
                {
                    var ID = dc.prtl_menu_nur_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_nur.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "edu")
                {
                    var ID = dc.prtl_menu_edu_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_edu.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "sci")
                {
                    var ID = dc.prtl_menu_sci_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_sci.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "edv")
                {
                    var ID = dc.prtl_menu_edv_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_edv.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "agr")
                {
                    var ID = dc.prtl_menu_agr_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_agr.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "hec")
                {
                    var ID = dc.prtl_menu_hec_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_hec.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.FirstOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "law")
                {
                    var ID = dc.prtl_menu_law_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_law.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.FirstOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var ID = dc.prtl_menu_fpe_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_fpe.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.FirstOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                    //********************
                else if (abbr.ToLower() == "vmed")
                {
                    var ID = dc.prtl_menu_VMed_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_VMed.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var ID = dc.prtl_menu_Pharm_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_Pharm.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                    ///***************************
                else if (abbr.ToLower() == "fa")
                {
                    var ID = dc.prtl_menu_fa_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_fa.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "art")
                {
                    var ID = dc.prtl_menu_art_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_art.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "ho")
                {
                    var ID = dc.prtl_menu_ho_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_ho.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "med")
                {
                    var ID = dc.prtl_menu_med_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_med.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "liv")
                {
                    var ID = dc.prtl_menu_liv_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_liv.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                else if (abbr.ToLower() == "com")
                {
                    var ID = dc.prtl_menu_com_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_com.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var ID = dc.prtl_menu_ECEDU_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_ECEDU.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
            //else if (abbr.ToLower() == "dent")
            //{
            //    var ID = dc.prtl_menu_com_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_com.Menu_id;
            //    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
            //}
            else if (abbr.ToLower() == "media")
            {
                var ID = dc.prtl_menu_media_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_media.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
            }
            //13-4-2022
            else if (abbr.ToLower() == "ai")
            {
                var ID = dc.prtl_menu_AI_trans.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID == currentlanguage).prtl_menu_AI.Menu_id;
                return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
            }
            else
                {
                    var ID = dc.prtl_Translations.SingleOrDefault(xx => xx.Translation_ID == tid && xx.prtl_Language.LCID==currentlanguage).prtl_Menu.Menu_id;
                    return new PortalDataContextDataContext().prtl_Articles.SingleOrDefault(x => x.MenuItemId == ID && x.Owner_ID == currentownerid);
                }
           
        }
        public static prtl_Article GetArticlebyMenuItemID2(int id,Guid currentowner)
        {
            var dc = new PortalDataContextDataContext();
            //return dc.prtl_Articles.SingleOrDefault(x => x.MenuItemId == id && x.Owner_ID==currentowner);
           List<prtl_Article> c =( (from s in dc.prtl_Articles where s.MenuItemId == id && s.Owner_ID == currentowner
                               orderby s.ID descending select s).ToList());



           prtl_Article cc = c.FirstOrDefault ();
            return cc ;
        }
        public static string GetArticleTitle(string abbr, string lcid, string noarticle)
        {
            var prtlArticlesTranslation = new PortalDataContextDataContext().prtl_Articles_Translations.SingleOrDefault(f => f.prtl_Article.Abbr.ToLower() == abbr && f.prtl_Language.LCID == lcid);
            return prtlArticlesTranslation != null ? prtlArticlesTranslation.Title : noarticle;
        }

        public static void InsertNewArticle(DetailsViewInsertEventArgs e, Guid? ownerid, string filteredproperty,bool published)
        {
         
            var dc = new PortalDataContextDataContext();
                  var newArticle = new prtl_Article {Owner_ID = ownerid};
            dc.prtl_Articles.InsertOnSubmit(newArticle);
            dc.SubmitChanges();
            e.Values[filteredproperty] = newArticle.ID;
            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            newArticle.Abbr = newArticle.ID.ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
            newArticle.MenuItemId = null;
            newArticle.Published = published;
            dc.SubmitChanges(); 
        }

  
        public static void UpdateArticleWithMenuID(int ArticleID, int MenuID)
        {
            var dc = new PortalDataContextDataContext();
            {
                var article = dc.prtl_Articles.Single(a => a.ID == ArticleID );
                article.MenuItemId = MenuID;
                dc.SubmitChanges();
            }
        }

        public static void UpdateArticleWithPublish(int ArticleID, bool Published)
        {
            var dc = new PortalDataContextDataContext();
            {
                var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                article.Published = Published;
                dc.SubmitChanges();
            }
        }
        public static void UpdateArticleWithMenuTranslationID(int ArticleID, Guid MenuTranslationID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_univs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();

                }
                else if (abbr.ToLower() == "fci")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_fcis.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fee")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_fees.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_engs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_nurs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_edus.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_scis.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_edvs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_agrs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_hecs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_laws.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_fpes.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                    //***********************
                else if (abbr.ToLower() == "vmed")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_VMeds.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_Pharms.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                    //***************************
                else if (abbr.ToLower() == "fa")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_fas.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "art")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_arts.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_hos.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_meds.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_livs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_coms.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ai")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_AIs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_ECEDUs.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                //16-6-2022
                else if (abbr.ToLower() == "media")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_medias.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "dent")
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_menu_dents.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                else
                {
                    var article = dc.prtl_Articles.Single(a => a.ID == ArticleID);
                    var menuId = dc.prtl_Menus.Single(m => m.Translation_ID == MenuTranslationID).Menu_id;
                    article.MenuItemId = menuId;
                    dc.SubmitChanges();
                }
                
            }
        }

       
    }
}