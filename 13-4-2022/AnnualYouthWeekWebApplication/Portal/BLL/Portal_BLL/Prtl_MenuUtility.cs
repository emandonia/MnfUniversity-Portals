using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using Common;
using MnfUniversity_Portals;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_MenuUtility
    {
       static void DeleteMenuItem(int menu_ID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                var item = dc.prtl_menu_univs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_univs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID==Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();

            }
            else if (abbr.ToLower() == "fci")
            {
                var item = dc.prtl_menu_fcis.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_fcis.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            
            else if (abbr.ToLower() == "fee")
            {
                var item = dc.prtl_menu_fees.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_fees.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "eng")
            {
                var item = dc.prtl_menu_engs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_engs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "nur")
            {
                var item = dc.prtl_menu_nurs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_nurs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edu")
            {
                var item = dc.prtl_menu_edus.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_edus.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "sci")
            {
                var item = dc.prtl_menu_scis.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_scis.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edv")
            {
                var item = dc.prtl_menu_edvs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_edvs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "agr")
            {
                var item = dc.prtl_menu_agrs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_agrs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "hec")
            {
                var item = dc.prtl_menu_hecs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_hecs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "law")
            {
                var item = dc.prtl_menu_laws.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_laws.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "fpe")
            {
                var item = dc.prtl_menu_fpes.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_fpes.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            //**************
            else if (abbr.ToLower() == "pharm")
            {
                var item = dc.prtl_menu_Pharms.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_Pharms.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "vmed")
            {
                var item = dc.prtl_menu_VMeds.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_VMeds.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }

//**********************
            else if (abbr.ToLower() == "fa")
            {
                var item = dc.prtl_menu_fas.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_fas.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "art")
            {
                var item = dc.prtl_menu_arts.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_arts.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "ho")
            {
                var item = dc.prtl_menu_hos.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_hos.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "med")
            {
                var item = dc.prtl_menu_meds.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_meds.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "liv")
            {
                var item = dc.prtl_menu_livs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_livs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "com")
            {
                var item = dc.prtl_menu_coms.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_coms.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                var item = dc.prtl_menu_ECEDUs.Single(m => m.Menu_id == menu_ID);

                dc.prtl_menu_ECEDUs.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    var item = dc.prtl_menu_coms.Single(m => m.Menu_id == menu_ID);

            //    dc.prtl_menu_coms.DeleteOnSubmit(item);
            //    var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
            //    foreach (var menuarticle in menuarticles)
            //        menuarticle.MenuItemId = null;
            //    dc.SubmitChanges();
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    var item = dc.prtl_menu_coms.Single(m => m.Menu_id == menu_ID);

            //    dc.prtl_menu_coms.DeleteOnSubmit(item);
            //    var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
            //    foreach (var menuarticle in menuarticles)
            //        menuarticle.MenuItemId = null;
            //    dc.SubmitChanges();
            //}
            else
            {
                var item = dc.prtl_Menus.Single(m => m.Menu_id == menu_ID);

                dc.prtl_Menus.DeleteOnSubmit(item);
                var menuarticles = dc.prtl_Articles.Where(a => a.MenuItemId == menu_ID && a.Owner_ID == Prtl_OwnersUtility.GetOwnerIDByAbbr(abbr));
                foreach (var menuarticle in menuarticles)
                    menuarticle.MenuItemId = null;
                dc.SubmitChanges();

            }
            
        }
        public static void DeleteMenuItemAndSubItems(prtl_Menu menuitem, bool deletemenuitem)
        {
            prtl_Owner owner = (prtl_Owner)System.Web.HttpContext.Current.Session["CurrentOwner"];

            DeleteSubItems(menuitem,owner.Abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, owner.Abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, owner.Abbr);
        }
        public static void Delete_univ_MenuItemAndSubItems(prtl_menu_univ menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_univ_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_fci_MenuItemAndSubItems(prtl_menu_fci menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_fci_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_media_MenuItemAndSubItems(prtl_menu_media menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_media_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_fee_MenuItemAndSubItems(prtl_menu_fee menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_fee_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_eng_MenuItemAndSubItems(prtl_menu_eng menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_eng_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_sci_MenuItemAndSubItems(prtl_menu_sci menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_sci_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_med_MenuItemAndSubItems(prtl_menu_med menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_med_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_liv_MenuItemAndSubItems(prtl_menu_liv menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_liv_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_hos_MenuItemAndSubItems(prtl_menu_ho menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_hos_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_hec_MenuItemAndSubItems(prtl_menu_hec menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_hec_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_agr_MenuItemAndSubItems(prtl_menu_agr menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_agr_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_edu_MenuItemAndSubItems(prtl_menu_edu menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_edu_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_edv_MenuItemAndSubItems(prtl_menu_edv menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_edv_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_fpe_MenuItemAndSubItems(prtl_menu_fpe menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_fpe_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        //****************************
        public static void Delete_VMed_MenuItemAndSubItems(prtl_menu_VMed menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_VMed_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_Pharm_MenuItemAndSubItems(prtl_menu_Pharm menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_Pharm_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        //**********************************
        public static void Delete_fas_MenuItemAndSubItems(prtl_menu_fa menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_fas_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_art_MenuItemAndSubItems(prtl_menu_art menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_art_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_law_MenuItemAndSubItems(prtl_menu_law menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_law_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_com_MenuItemAndSubItems(prtl_menu_com menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_com_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        //12121212//12121212
        public static void Delete_ecedu_MenuItemAndSubItems(prtl_menu_ECEDU menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_ecedu_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        public static void Delete_nur_MenuItemAndSubItems(prtl_menu_nur menuitem, bool deletemenuitem)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            Delete_nur_SubItems(menuitem, abbr);
            Prtl_TranslationUtility.DeleteTranslations(menuitem.Translation_ID, abbr);
            if (deletemenuitem)
                DeleteMenuItem(menuitem.Menu_id, abbr);
        }
        
        static void DeleteSubItems(prtl_Menu menuitem,string abbr)
        { 
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_Menus)
            {
                DeleteSubItems(submenu,abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID,abbr);
                DeleteMenuItem(menuitem.Menu_id,abbr);
            }

        }
        static void Delete_univ_SubItems(prtl_menu_univ menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_univs)
            {
                Delete_univ_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_fci_SubItems(prtl_menu_fci menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_fcis)
            {
                Delete_fci_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        //33333333333
        static void Delete_media_SubItems(prtl_menu_media menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_medias)
            {
                Delete_media_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_fee_SubItems(prtl_menu_fee menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_fees)
            {
                Delete_fee_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_eng_SubItems(prtl_menu_eng menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_engs)
            {
                Delete_eng_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_sci_SubItems(prtl_menu_sci menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_scis)
            {
                Delete_sci_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }

        private static void Delete_med_SubItems(prtl_menu_med menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_meds)
            {
                Delete_med_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }
        }
        private static void Delete_nur_SubItems(prtl_menu_nur menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_nurs)
            {
                Delete_nur_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }
        }
        static void Delete_liv_SubItems(prtl_menu_liv menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_livs)
            {
                Delete_liv_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_edu_SubItems(prtl_menu_edu menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_edus)
            {
                Delete_edu_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_edv_SubItems(prtl_menu_edv menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_edvs)
            {
                Delete_edv_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_hec_SubItems(prtl_menu_hec menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_hecs)
            {
                Delete_hec_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_agr_SubItems(prtl_menu_agr menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_agrs)
            {
                Delete_agr_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_art_SubItems(prtl_menu_art menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_arts)
            {
                Delete_art_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_law_SubItems(prtl_menu_law menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_laws)
            {
                Delete_law_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_com_SubItems(prtl_menu_com menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_coms)
            {
                Delete_com_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }//12121212
        static void Delete_ecedu_SubItems(prtl_menu_ECEDU menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_ECEDUs)
            {
                Delete_ecedu_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_hos_SubItems(prtl_menu_ho menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_hos)
            {
                Delete_hos_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_fpe_SubItems(prtl_menu_fpe menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_fpes)
            {
                Delete_fpe_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        //***********************
        static void Delete_Pharm_SubItems(prtl_menu_Pharm menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_Pharms)
            {
                Delete_Pharm_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        static void Delete_VMed_SubItems(prtl_menu_VMed menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_VMeds)
            {
                Delete_VMed_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }
        //***********************
        static void Delete_fas_SubItems(prtl_menu_fa menuitem, string abbr)
        {
            if (menuitem == null)
                return;
            foreach (var submenu in menuitem.prtl_menu_fas)
            {
                Delete_fas_SubItems(submenu, abbr);
                Prtl_TranslationUtility.DeleteTranslations(submenu.Translation_ID, abbr);
                DeleteMenuItem(menuitem.Menu_id, abbr);
            }

        }

        public static IEnumerable<prtl_Menu> GetDBMenuItems(Guid? currentOwnerID)
        {
                return new PortalDataContextDataContext().prtl_Menus.Where(m => m.Owner_ID.Equals(currentOwnerID));
 
        }
        public static IEnumerable<prtl_menu_univ> Get_univ_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_univs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_fci> Get_fci_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_fcis.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_media> Get_media_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_medias.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_fee> Get_fee_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_fees.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_eng> Get_eng_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_engs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_sci> Get_sci_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_scis.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_law> Get_law_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_laws.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_art> Get_art_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_arts.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_com> Get_com_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_coms.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_med> Get_med_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_meds.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_liv> Get_liv_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_livs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        //12121212//12121212
        public static IEnumerable<prtl_menu_ECEDU> Get_ecedu_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_ECEDUs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_nur> Get_nur_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_nurs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_fpe> Get_fpe_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_fpes.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        //*********************
        public static IEnumerable<prtl_menu_VMed> Get_VMed_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_VMeds.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_Pharm> Get_Pharm_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_Pharms.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        //****************************
        public static IEnumerable<prtl_menu_fa> Get_fa_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_fas.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_ho> Get_ho_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_hos.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_edu> Get_edu_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_edus.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_edv> Get_edv_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_edvs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_hec> Get_hec_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_hecs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static IEnumerable<prtl_menu_agr> Get_agr_DBMenuItems(Guid? currentOwnerID)
        {
            return new PortalDataContextDataContext().prtl_menu_agrs.Where(m => m.Owner_ID.Equals(currentOwnerID));
        }
        public static prtl_Menu GetMenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_Menus.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_univ Get_univ_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_univs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_fci Get_fci_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_fcis.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_media Get_media_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_medias.SingleOrDefault(m => m.Menu_id == menu_ID);
        }


        public static prtl_menu_fee Get_fee_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_fees.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_eng Get_eng_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_engs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_art Get_art_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_arts.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_law Get_law_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_laws.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_com Get_com_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_coms.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        //12121212
        public static prtl_menu_ECEDU Get_ecedu_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_ECEDUs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_nur Get_nur_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_nurs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_med Get_med_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_meds.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_liv Get_liv_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_livs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_ho Get_ho_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_hos.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_edu Get_edu_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_edus.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_edv Get_edv_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_edvs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_hec Get_hec_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_hecs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_agr Get_agr_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_agrs.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_fpe Get_fpe_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_fpes.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        //*************************
        public static prtl_menu_VMed Get_VMed_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_VMeds.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_Pharm Get_Pharm_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_Pharms.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        //********************************
        public static prtl_menu_sci Get_sci_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_scis.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
        public static prtl_menu_fa Get_fas_MenuByID(int menu_ID)
        {
            return new PortalDataContextDataContext().prtl_menu_fas.SingleOrDefault(m => m.Menu_id == menu_ID);
        }
       
        
        public static prtl_Menu GetMenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_Menus.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_univ Get_univ_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_univs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_fci Get_fci_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_fcis.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        //33333333333
        public static prtl_menu_media Get_media_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_medias.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_fee Get_fee_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_fees.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_eng Get_eng_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_engs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_nur Get_nur_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_nurs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_sci Get_sci_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_scis.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_art Get_art_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_arts.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_law Get_law_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_laws.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_com Get_com_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_coms.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        //12121212//12121212
        public static prtl_menu_ECEDU Get_ecedu_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_ECEDUs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }

        public static prtl_menu_med Get_med_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_meds.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_edu Get_edu_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_edus.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_edv Get_edv_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_edvs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_hec Get_hec_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_hecs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_agr Get_agr_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_agrs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_fpe Get_fpe_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_fpes.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        //*************************
        public static prtl_menu_Pharm Get_Pharm_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_Pharms.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_VMed Get_VMed_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_VMeds.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        //***********************
        public static prtl_menu_fa Get_fa_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_fas.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static prtl_menu_liv Get_liv_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_livs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        //public static prtl_menu_ECEDU Get_ecedu_MenuByTranslationID(string translationID)
        //{
        //    return new PortalDataContextDataContext().prtl_menu_ECEDUs.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        //}
        public static prtl_menu_ho Get_ho_MenuByTranslationID(string translationID)
        {
            return new PortalDataContextDataContext().prtl_menu_hos.SingleOrDefault(m => m.Translation_ID.ToString() == translationID);
        }
        public static object GetMenuIDs(Guid t_ID, Guid? ownerID, string currentlang, string position,string abbr)
        {


            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            var dc = new PortalDataContextDataContext();
            if (abbr == null && type==0)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuUnivTran != null)
                {
                    var menu_ID =
                        prtlMenuUnivTran.prtl_menu_univ.Menu_id;
                    return dc.prtl_menu_univ_trans
                        .Where(
                            m =>
                                m.prtl_menu_univ.Position == position && m.prtl_menu_univ.Menu_id != menu_ID &&
                                m.prtl_menu_univ.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new {tr.prtl_menu_univ.Menu_id, tr.Translation_Data})
                        .OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "fci" &&type==1))
            {
                var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuFciTran != null)
                {
                    var menu_ID =
                        prtlMenuFciTran.prtl_menu_fci.Menu_id;
                    return dc.prtl_menu_fci_trans
                        .Where(m => m.prtl_menu_fci.Position == position && m.prtl_menu_fci.Menu_id != menu_ID && m.prtl_menu_fci.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fci.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
          
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuFeeTran != null)
                {
                    var menu_ID =
                        prtlMenuFeeTran.prtl_menu_fee.Menu_id;
                    return dc.prtl_menu_fee_trans
                        .Where(m => m.prtl_menu_fee.Position == position && m.prtl_menu_fee.Menu_id != menu_ID && m.prtl_menu_fee.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fee.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuEngTran != null)
                {
                    var menu_ID =
                        prtlMenuEngTran.prtl_menu_eng.Menu_id;
                    return dc.prtl_menu_eng_trans
                        .Where(m => m.prtl_menu_eng.Position == position && m.prtl_menu_eng.Menu_id != menu_ID && m.prtl_menu_eng.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_eng.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuNurTran != null)
                {
                    var menu_ID =
                        prtlMenuNurTran.prtl_menu_nur.Menu_id;
                    return dc.prtl_menu_nur_trans
                        .Where(m => m.prtl_menu_nur.Position == position && m.prtl_menu_nur.Menu_id != menu_ID && m.prtl_menu_nur.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_nur.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuEduTran != null)
                {
                    var menu_ID =
                        prtlMenuEduTran.prtl_menu_edu.Menu_id;
                    return dc.prtl_menu_edu_trans
                        .Where(m => m.prtl_menu_edu.Position == position && m.prtl_menu_edu.Menu_id != menu_ID && m.prtl_menu_edu.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_edu.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuSciTran != null)
                {
                    var menu_ID =
                        prtlMenuSciTran.prtl_menu_sci.Menu_id;
                    return dc.prtl_menu_sci_trans
                        .Where(m => m.prtl_menu_sci.Position == position && m.prtl_menu_sci.Menu_id != menu_ID && m.prtl_menu_sci.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_sci.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuEdvTran != null)
                {
                    var menu_ID =
                        prtlMenuEdvTran.prtl_menu_edv.Menu_id;
                    return dc.prtl_menu_edv_trans
                        .Where(m => m.prtl_menu_edv.Position == position && m.prtl_menu_edv.Menu_id != menu_ID && m.prtl_menu_edv.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_edv.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuAgrTran != null)
                {
                    var menu_ID =
                        prtlMenuAgrTran.prtl_menu_agr.Menu_id;
                    return dc.prtl_menu_agr_trans
                        .Where(m => m.prtl_menu_agr.Position == position && m.prtl_menu_agr.Menu_id != menu_ID && m.prtl_menu_agr.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_agr.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuHecTran != null)
                {
                    var menu_ID =
                        prtlMenuHecTran.prtl_menu_hec.Menu_id;
                    return dc.prtl_menu_hec_trans
                        .Where(m => m.prtl_menu_hec.Position == position && m.prtl_menu_hec.Menu_id != menu_ID && m.prtl_menu_hec.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_hec.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
                var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuLawTran != null)
                {
                    var menu_ID =
                        prtlMenuLawTran.prtl_menu_law.Menu_id;
                    return dc.prtl_menu_law_trans
                        .Where(m => m.prtl_menu_law.Position == position && m.prtl_menu_law.Menu_id != menu_ID && m.prtl_menu_law.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_law.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
                var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuFpeTran != null)
                {
                    var menu_ID =
                        prtlMenuFpeTran.prtl_menu_fpe.Menu_id;
                    return dc.prtl_menu_fpe_trans
                        .Where(m => m.prtl_menu_fpe.Position == position && m.prtl_menu_fpe.Menu_id != menu_ID && m.prtl_menu_fpe.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fpe.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            //***********************
            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {
                var prtlMenuPharmTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuPharmTran != null)
                {
                    var menu_ID =
                        prtlMenuPharmTran.prtl_menu_Pharm.Menu_id;
                    return dc.prtl_menu_Pharm_trans
                        .Where(m => m.prtl_menu_Pharm.Position == position && m.prtl_menu_Pharm.Menu_id != menu_ID && m.prtl_menu_Pharm.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_Pharm.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }

            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {
                var prtlMenuvmedTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuvmedTran != null)
                {
                    var menu_ID =
                        prtlMenuvmedTran.prtl_menu_VMed.Menu_id;
                    return dc.prtl_menu_VMed_trans
                        .Where(m => m.prtl_menu_VMed.Position == position && m.prtl_menu_VMed.Menu_id != menu_ID && m.prtl_menu_VMed.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_VMed.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }

//****************************
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                var prtlMenuFasTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuFasTran != null)
                {
                    var menu_ID =
                        prtlMenuFasTran.prtl_menu_fa.Menu_id;
                    return dc.prtl_menu_fa_trans
                        .Where(m => m.prtl_menu_fa.Position == position && m.prtl_menu_fa.Menu_id != menu_ID && m.prtl_menu_fa.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fa.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
                var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuArtTran != null)
                {
                    var menu_ID =
                        prtlMenuArtTran.prtl_menu_art.Menu_id;
                    return dc.prtl_menu_art_trans
                        .Where(m => m.prtl_menu_art.Position == position && m.prtl_menu_art.Menu_id != menu_ID && m.prtl_menu_art.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_art.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                var prtlMenuHosTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuHosTran != null)
                {
                    var menu_ID =
                        prtlMenuHosTran.prtl_menu_ho.Menu_id;
                    return dc.prtl_menu_ho_trans
                        .Where(m => m.prtl_menu_ho.Position == position && m.prtl_menu_ho.Menu_id != menu_ID && m.prtl_menu_ho.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_ho.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuMedTran != null)
                {
                    var menu_ID =
                        prtlMenuMedTran.prtl_menu_med.Menu_id;
                    return dc.prtl_menu_med_trans
                        .Where(m => m.prtl_menu_med.Position == position && m.prtl_menu_med.Menu_id != menu_ID && m.prtl_menu_med.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_med.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuLivTran != null)
                {
                    var menu_ID =
                        prtlMenuLivTran.prtl_menu_liv.Menu_id;
                    return dc.prtl_menu_liv_trans
                        .Where(m => m.prtl_menu_liv.Position == position && m.prtl_menu_liv.Menu_id != menu_ID && m.prtl_menu_liv.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_liv.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlMenuComTran != null)
                {
                    var menu_ID =
                        prtlMenuComTran.prtl_menu_com.Menu_id;
                    return dc.prtl_menu_com_trans
                        .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
            //12121212
            //else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            //{
            //    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
            //        x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
            //    if (prtlMenueceduTran != null)
            //    {
            //        var menu_ID =
            //            prtlMenueceduTran.prtl_menu_ECEDU.Menu_id;
            //        return dc.prtl_menu_ECEDU_trans
            //            .Where(m => m.prtl_menu_ECEDU.Position == position && m.prtl_menu_ECEDU.Menu_id != menu_ID && m.prtl_menu_ECEDU.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
            //            .Select(tr => new { tr.prtl_menu_ECEDU.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //}
            //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            //{
            //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
            //        x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
            //    if (prtlMenuComTran != null)
            //    {
            //        var menu_ID =
            //            prtlMenuComTran.prtl_menu_com.Menu_id;
            //        return dc.prtl_menu_com_trans
            //            .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
            //            .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //}
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{
            //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
            //        x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
            //    if (prtlMenuComTran != null)
            //    {
            //        var menu_ID =
            //            prtlMenuComTran.prtl_menu_com.Menu_id;
            //        return dc.prtl_menu_com_trans
            //            .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
            //            .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            //}
            else
            {
                var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                    x => x.Translation_ID == t_ID && x.prtl_Language.LCID == currentlang);
                if (prtlTranslation != null)
                {
                    var menu_ID =
                        prtlTranslation.prtl_Menu.Menu_id;
                    return dc.prtl_Translations
                        .Where(m => m.prtl_Menu.Position == position && m.prtl_Menu.Menu_id != menu_ID && m.prtl_Menu.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_Menu.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                }
                else
                {
                    return -1;
                }
            }
        }

       
        public static IEnumerable<string> GetUniquePositions(Guid? ownerID)
        {

            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            if (abbr == null && type==0)
            {
                return new PortalDataContextDataContext().prtl_menu_univs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();

            }
            else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_fcis.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_fees.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_engs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_nurs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_edus.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_scis.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_edvs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                     ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_agrs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_hecs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                     ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_laws.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_fpes.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
                //*******************************
            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_VMeds.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_Pharms.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
                ////////////////////////////////
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_fas.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_arts.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_hos.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_meds.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_livs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_coms.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            //12121212
            else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            {
                return new PortalDataContextDataContext().prtl_menu_ECEDUs.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            //{
            //    return new PortalDataContextDataContext().prtl_menu_coms.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
            //        ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            //}
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{
            //    return new PortalDataContextDataContext().prtl_menu_coms.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) ==
            //        ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            //}
            else
            {
                return new PortalDataContextDataContext().prtl_Menus.Where(m => m.Owner_ID.GetValueOrDefault(Guid.Empty) == 
                    ownerID.GetValueOrDefault(Guid.Empty)).Select(m => m.Position).Distinct().ToList();
            }
            
        }
        public static IEnumerable<XMLMenuItem> GetXMLMenuItems(string position, Guid? ownerID = null)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            var dc = new PortalDataContextDataContext();
            if (abbr == null && type==0)
            {
                var menuItems = from mt in dc.prtl_menu_univs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_univ_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_univ_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });

            }
            else if (abbr != null && (abbr.ToLower() == "fci" && type==1))
            {
                var menuItems = from mt in dc.prtl_menu_fcis
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_fci_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_fci_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_fees
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_fee_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_fee_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_engs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_eng_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_eng_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_nurs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_nur_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_nur_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_edus
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_edu_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_edu_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_scis
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_sci_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_sci_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_edvs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_edv_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_edv_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_agrs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_agr_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_agr_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_hecs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_hec_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_hec_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_laws
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_law_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_law_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_fpes
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_fpe_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_fpe_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
                //************************************
            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_VMeds
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_VMed_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_VMed_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_Pharms
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_Pharm_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_Pharm_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
                //////////////////////////////////////////////
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_fas
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_fa_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_fa_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_arts
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_art_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_art_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_hos
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_ho_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_ho_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_meds
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_med_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_med_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_livs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_liv_trans.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_liv_trans.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_coms
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            //12121212
            else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            {
                var menuItems = from mt in dc.prtl_menu_ECEDUs
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_menu_ECEDU_trans.First(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_menu_ECEDU_trans.First(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            //{
            //    var menuItems = from mt in dc.prtl_menu_coms
            //                    orderby mt.Parent_id, mt.Order
            //                    where mt.Published && mt.Position == position
            //                    && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
            //                    || mt.Owner_ID == null)
            //                    select mt;
            //    return menuItems.Select(s => new XMLMenuItem
            //    {
            //        Id = s.Menu_id
            //        ,
            //        Parent_id = s.Parent_id
            //        ,
            //        Roles = s.Roles
            //        ,
            //        Url = s.Url
            //        ,
            //        Url_target = s.Url_target
            //        ,
            //        TitleAr = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "ar").Translation_Data
            //        ,
            //        TitleEn = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "en").Translation_Data

            //    });
            //}
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{
            //    var menuItems = from mt in dc.prtl_menu_coms
            //                    orderby mt.Parent_id, mt.Order
            //                    where mt.Published && mt.Position == position
            //                    && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
            //                    || mt.Owner_ID == null)
            //                    select mt;
            //    return menuItems.Select(s => new XMLMenuItem
            //    {
            //        Id = s.Menu_id
            //        ,
            //        Parent_id = s.Parent_id
            //        ,
            //        Roles = s.Roles
            //        ,
            //        Url = s.Url
            //        ,
            //        Url_target = s.Url_target
            //        ,
            //        TitleAr = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "ar").Translation_Data
            //        ,
            //        TitleEn = s.prtl_menu_com_trans.First(t => t.prtl_Language.LCID == "en").Translation_Data

            //    });
            //}
            
            else
            {
                var menuItems = from mt in dc.prtl_Menus
                                orderby mt.Parent_id, mt.Order
                                where mt.Published && mt.Position == position
                                && (mt.Owner_ID.GetValueOrDefault(Guid.Empty) == ownerID.GetValueOrDefault(Guid.Empty)
                                || mt.Owner_ID == null)
                                select mt;
                return menuItems.Select(s => new XMLMenuItem
                {
                    Id = s.Menu_id
                    ,
                    Parent_id = s.Parent_id
                    ,
                    Roles = s.Roles
                    ,
                    Url = s.Url
                    ,
                    Url_target = s.Url_target
                    ,
                    TitleAr = s.prtl_Translations.SingleOrDefault(t => t.prtl_Language.LCID == "ar").Translation_Data
                    ,
                    TitleEn = s.prtl_Translations.SingleOrDefault(t => t.prtl_Language.LCID == "en").Translation_Data

                });
            }
            
        }
        public static prtl_Menu InsertMenuItem(prtl_Menu menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_Menus.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_univ Insert_univ_MenuItem(prtl_menu_univ menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_univs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_fci Insert_fci_MenuItem(prtl_menu_fci menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_fcis.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        //33333333333
        public static prtl_menu_media Insert_media_MenuItem(prtl_menu_media menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_medias.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_fee Insert_fee_MenuItem(prtl_menu_fee menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_fees.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_eng Insert_eng_MenuItem(prtl_menu_eng menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_engs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_sci Insert_sci_MenuItem(prtl_menu_sci menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_scis.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_nur Insert_nur_MenuItem(prtl_menu_nur menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_nurs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_med Insert_med_MenuItem(prtl_menu_med menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_meds.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_liv Insert_liv_MenuItem(prtl_menu_liv menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_livs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_ho Insert_hos_MenuItem(prtl_menu_ho menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_hos.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_art Insert_art_MenuItem(prtl_menu_art menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_arts.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_com Insert_com_MenuItem(prtl_menu_com menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_coms.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        //12121212
        public static prtl_menu_ECEDU Insert_ecedu_MenuItem(prtl_menu_ECEDU menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_ECEDUs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }

        public static prtl_menu_law Insert_law_MenuItem(prtl_menu_law menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_laws.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_edu Insert_edu_MenuItem(prtl_menu_edu menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_edus.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_edv Insert_edv_MenuItem(prtl_menu_edv menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_edvs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_hec Insert_hec_MenuItem(prtl_menu_hec menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_hecs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_agr Insert_agr_MenuItem(prtl_menu_agr menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_agrs.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_fpe Insert_fpe_MenuItem(prtl_menu_fpe menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_fpes.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        //*************
        public static prtl_menu_VMed Insert_VMed_MenuItem(prtl_menu_VMed menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_VMeds.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }
        public static prtl_menu_Pharm Insert_Pharm_MenuItem(prtl_menu_Pharm menuitem)
         {
             var dc = new PortalDataContextDataContext();
             dc.prtl_menu_Pharms.InsertOnSubmit(menuitem);
             dc.SubmitChanges();
             return menuitem;
         }
        /////**********************
        public static prtl_menu_fa Insert_fas_MenuItem(prtl_menu_fa menuitem)
        {
            var dc = new PortalDataContextDataContext();
            dc.prtl_menu_fas.InsertOnSubmit(menuitem);
            dc.SubmitChanges();
            return menuitem;
        }


        //public static prtl_Menu InsertParentMenuItem(Guid? menuowner, string url, string urlTarget = "", string roles = "All", string position = "Vertical", bool published = true, params Translation[] translations)
        //{
        //    prtl_Owner owner = null;
        //    if (menuowner.HasValue)
        //        owner = Prtl_OwnersUtility.GetOwnerByOwnerID(menuowner.Value);
        //    var menuitem = new prtl_Menu
        //    {
        //        prtl_Owner = owner,
        //        Parent_id = null,
        //        Url = url,
        //        Url_target = urlTarget,
        //        Roles = roles,
        //        Position = position,
        //        Published = published
        //    };
        //    var dc = new PortalDataContextDataContext();
        //    dc.prtl_Menus.InsertOnSubmit(menuitem);


        //    dc.SubmitChanges();
        //    var menutranslations = translations.Select(translation =>
        //        new prtl_Translation
        //        {
        //            Translation_Data = translation.translation,
        //            prtl_Language = Prtl_LanguagesUtility.getLangByLCID(translation.lcid),
        //            prtl_Menu = menuitem
        //        });
        //    foreach (var trans in menutranslations)
        //    {
        //        dc.prtl_Translations.InsertOnSubmit(trans);
        //    }
        //    dc.SubmitChanges();
        //    return menuitem;
        //}

        public static void UpdateMenuItem(Guid tr, Func<prtl_Menu, prtl_Menu> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_Menus.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_univ_MenuItem(Guid tr, Func<prtl_menu_univ, prtl_menu_univ> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_univs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_fci_MenuItem(Guid tr, Func<prtl_menu_fci, prtl_menu_fci> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_fcis.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        //333333333
        public static void Update_media_MenuItem(Guid tr, Func<prtl_menu_media, prtl_menu_media> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_medias.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_fee_MenuItem(Guid tr, Func<prtl_menu_fee, prtl_menu_fee> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_fees.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_eng_MenuItem(Guid tr, Func<prtl_menu_eng, prtl_menu_eng> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_engs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_sci_MenuItem(Guid tr, Func<prtl_menu_sci, prtl_menu_sci> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_scis.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_med_MenuItem(Guid tr, Func<prtl_menu_med, prtl_menu_med> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_meds.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_liv_MenuItem(Guid tr, Func<prtl_menu_liv, prtl_menu_liv> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_livs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        //12121212
        public static void Update_ecedu_MenuItem(Guid tr, Func<prtl_menu_ECEDU, prtl_menu_ECEDU> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_ECEDUs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_hos_MenuItem(Guid tr, Func<prtl_menu_ho, prtl_menu_ho> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_hos.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_nur_MenuItem(Guid tr, Func<prtl_menu_nur, prtl_menu_nur> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_nurs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_art_MenuItem(Guid tr, Func<prtl_menu_art, prtl_menu_art> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_arts.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_law_MenuItem(Guid tr, Func<prtl_menu_law, prtl_menu_law> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_laws.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_com_MenuItem(Guid tr, Func<prtl_menu_com, prtl_menu_com> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_coms.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_hec_MenuItem(Guid tr, Func<prtl_menu_hec, prtl_menu_hec> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_hecs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_agr_MenuItem(Guid tr, Func<prtl_menu_agr, prtl_menu_agr> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_agrs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_edu_MenuItem(Guid tr, Func<prtl_menu_edu, prtl_menu_edu> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_edus.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_edv_MenuItem(Guid tr, Func<prtl_menu_edv, prtl_menu_edv> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_edvs.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_fpe_MenuItem(Guid tr, Func<prtl_menu_fpe, prtl_menu_fpe> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_fpes.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        //*******************
        public static void Update_Pharm_MenuItem(Guid tr, Func<prtl_menu_Pharm, prtl_menu_Pharm> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_Pharms.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        public static void Update_VMed_MenuItem(Guid tr, Func<prtl_menu_VMed, prtl_menu_VMed> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_VMeds.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }
        //***********************
        public static void Update_fas_MenuItem(Guid tr, Func<prtl_menu_fa, prtl_menu_fa> func)
        {
            var dc = new PortalDataContextDataContext();
            {
                var menuItem = func(dc.prtl_menu_fas.Single(m => m.Translation_ID == tr));
                dc.SubmitChanges();
            }
        }

        public struct MenuItem
        {
            public int Id { get; set; }

            public int? Parent_id { get; set; }

            public string Roles { get; set; }

            public string Translation_Data { get; set; }

            public string Url { get; set; }
            public string Position { get; set; }

            public string Url_target { get; set; }
        }
        public struct XMLMenuItem
        {
            public int Id { get; set; }

            public int? Parent_id { get; set; }

            public string Roles { get; set; }

            public string TitleAr { get; set; }
            public string TitleEn { get; set; }

            public string Url { get; set; }

            public string Url_target { get; set; }
        }


        public static bool GetPublishedState(string MenuId,string abbr)
        {
            if (abbr == null)
            {
                var q = new PortalDataContextDataContext().prtl_menu_univs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (abbr.ToLower() == "fci")
            {
                var q = new PortalDataContextDataContext().prtl_menu_fcis.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "fee")
            {
                var q = new PortalDataContextDataContext().prtl_menu_fees.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "eng")
            {
                var q = new PortalDataContextDataContext().prtl_menu_engs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "nur")
            {
                var q = new PortalDataContextDataContext().prtl_menu_nurs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "edu")
            {
                var q = new PortalDataContextDataContext().prtl_menu_edus.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "sci")
            {
                var q = new PortalDataContextDataContext().prtl_menu_scis.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "edv")
            {
                var q = new PortalDataContextDataContext().prtl_menu_edvs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "agr")
            {
                var q = new PortalDataContextDataContext().prtl_menu_agrs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "hec")
            {
                var q = new PortalDataContextDataContext().prtl_menu_hecs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "law")
            {
                var q = new PortalDataContextDataContext().prtl_menu_laws.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "fpe")
            {
                var q = new PortalDataContextDataContext().prtl_menu_fpes.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
                //**************************
            else if (abbr.ToLower() == "pharm")
            {
                var q = new PortalDataContextDataContext().prtl_menu_Pharms.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "vmed")
            {
                var q = new PortalDataContextDataContext().prtl_menu_VMeds.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
                //*****************************
            else if (abbr.ToLower() == "fa")
            {
                var q = new PortalDataContextDataContext().prtl_menu_fas.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "art")
            {
                var q = new PortalDataContextDataContext().prtl_menu_arts.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "ho")
            {
                var q = new PortalDataContextDataContext().prtl_menu_hos.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "med")
            {
                var q = new PortalDataContextDataContext().prtl_menu_meds.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "liv")
            {
                var q = new PortalDataContextDataContext().prtl_menu_livs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (abbr.ToLower() == "com")
            {
                var q = new PortalDataContextDataContext().prtl_menu_coms.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                var q = new PortalDataContextDataContext().prtl_menu_ECEDUs.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    var q = new PortalDataContextDataContext().prtl_menu_coms.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

            //    if (q.Published)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    var q = new PortalDataContextDataContext().prtl_menu_coms.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

            //    if (q.Published)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            else
            {
                var q = new PortalDataContextDataContext().prtl_Menus.SingleOrDefault(x => x.Translation_ID.ToString() == MenuId);

                if (q.Published)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           


        }

        public static void UpdateMenuWithPublish(int id, bool Published,[Optional] string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var Menu = dc.prtl_menu_univs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();

                }
                else if (abbr.ToLower() == "fci")
                {
                    var Menu = dc.prtl_menu_fcis.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fee")
                {
                    var Menu = dc.prtl_menu_fees.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var Menu = dc.prtl_menu_engs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var Menu = dc.prtl_menu_nurs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var Menu = dc.prtl_menu_edus.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var Menu = dc.prtl_menu_scis.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var Menu = dc.prtl_menu_edvs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var Menu = dc.prtl_menu_agrs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var Menu = dc.prtl_menu_hecs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var Menu = dc.prtl_menu_laws.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var Menu = dc.prtl_menu_fpes.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                    //*************************
                else if (abbr.ToLower() == "VMed")
                {
                    var Menu = dc.prtl_menu_VMeds.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var Menu = dc.prtl_menu_Pharms.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }

                    //********************
                else if (abbr.ToLower() == "fa")
                {
                    var Menu = dc.prtl_menu_fas.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "art")
                {
                    var Menu = dc.prtl_menu_arts.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var Menu = dc.prtl_menu_hos.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var Menu = dc.prtl_menu_meds.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var Menu = dc.prtl_menu_livs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var Menu = dc.prtl_menu_coms.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var Menu = dc.prtl_menu_ECEDUs.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var Menu = dc.prtl_menu_coms.Single(a => a.Menu_id == id);
                //    Menu.Published = Published;
                //    dc.SubmitChanges();
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var Menu = dc.prtl_menu_coms.Single(a => a.Menu_id == id);
                //    Menu.Published = Published;
                //    dc.SubmitChanges();
                //}
                else
                {
                    var Menu = dc.prtl_Menus.Single(a => a.Menu_id == id);
                    Menu.Published = Published;
                    dc.SubmitChanges();
                }
                
            }
        }

        //public static Decimal GetMenuIDByTranslationID(string trans)
        //{
        //    var dc = new PortalDataContextDataContext();
        //    {
        //        prtl_Menu Menu = dc.prtl_Menus.Single(a => a.Translation_ID.ToString() == trans);
        //        return Menu.Menu_id;
        //    }
        //}



        public static void insertCouncilMenu()
        { 
            var dc = new PortalDataContextDataContext();

            #region
            List<prtl_Owner> o = (from cc in dc.prtl_Owners where cc.Type == 6 && (cc.Abbr.Contains("Student")) select cc).ToList();

             foreach (var c in o)
             {
                 var menuitem1 = new prtl_Menu
                                {
                                    // Parent_id = 145753,
                                    Roles = "All",
                                    Position = "Vertical",
                                    Published = true,
                                    Order = 1,
                                    Owner_ID = c.Owner_ID
                                };

                 dc.prtl_Menus.InsertOnSubmit(menuitem1);
                 dc.SubmitChanges();


                 var menutranslations01 = new prtl_Translation();

                 menutranslations01.Translation_Data = "اتحاد الطلاب";
                 menutranslations01.Lang_Id = 1;
                 menutranslations01.Translation_ID = menuitem1.Translation_ID;


                 dc.prtl_Translations.InsertOnSubmit(menutranslations01);
                 dc.SubmitChanges();

                 prtl_Translation menutranslations1 = new prtl_Translation();

                 menutranslations1.Translation_Data = "Student Union";
                 menutranslations1.Lang_Id = 2;
                 menutranslations1.Translation_ID = menuitem1.Translation_ID;

                 dc.prtl_Translations.InsertOnSubmit(menutranslations1);
                 dc.SubmitChanges();


                 prtl_Menu menuitem2 = new prtl_Menu();

                 // menuitem2.    Parent_id = 145753;
                 menuitem2.Roles = "All";
                 menuitem2.Position = "Vertical";
                 menuitem2.Published = true;
                 menuitem2.Order = 2;
                 menuitem2.Owner_ID = c.Owner_ID;



                 dc.prtl_Menus.InsertOnSubmit(menuitem2);
                 dc.SubmitChanges();


                 prtl_Translation menutranslations02 = new prtl_Translation();

                 menutranslations02.Translation_Data = "انشطة الكلية";
                 menutranslations02.Lang_Id = 1;
                 menutranslations02.Translation_ID = menuitem2.Translation_ID;

                 dc.prtl_Translations.InsertOnSubmit(menutranslations02);
                 dc.SubmitChanges();

                 prtl_Translation menutranslations2 = new prtl_Translation();

                 menutranslations2.Translation_Data = "College activities";
                 menutranslations2.Lang_Id = 2;
                 menutranslations2.Translation_ID = menuitem2.Translation_ID;

                 dc.prtl_Translations.InsertOnSubmit(menutranslations2);
                 dc.SubmitChanges();


                 prtl_Menu menuitem3 = new prtl_Menu();

                 // menuitem2.    Parent_id = 145753;
                 menuitem3.Roles = "All";
                 menuitem3.Position = "Vertical";
                 menuitem3.Published = true;
                 menuitem3.Order = 3;
                 menuitem3.Owner_ID = c.Owner_ID;



                 dc.prtl_Menus.InsertOnSubmit(menuitem3);
                 dc.SubmitChanges();


                 prtl_Translation menutranslations03 = new prtl_Translation();

                 menutranslations03.Translation_Data = "خدمات التدريب";
                 menutranslations03.Lang_Id = 1;
                 menutranslations03.Translation_ID = menuitem3.Translation_ID;

                 dc.prtl_Translations.InsertOnSubmit(menutranslations03);
                 dc.SubmitChanges();

                 prtl_Translation menutranslations3 = new prtl_Translation();

                 menutranslations3.Translation_Data = "Training Services";
                 menutranslations3.Lang_Id = 2;
                 menutranslations3.Translation_ID = menuitem3.Translation_ID;

                 dc.prtl_Translations.InsertOnSubmit(menutranslations3);
                 dc.SubmitChanges();
             }
            #endregion





            #region
            //List<prtl_Owner> o = (from cc in dc.prtl_Owners where cc.Type == 6 && (cc.Abbr.Contains("UnitElec")) select cc).ToList();

            //foreach (var c in o)
            //{
            //    var menuitem1 = new prtl_Menu
            //                   {
            //                       // Parent_id = 145753,
            //                       Roles = "All",
            //                       Position = "Vertical",
            //                       Published = true,
            //                       Order = 1,
            //                       Owner_ID = c.Owner_ID
            //                   };

            //    dc.prtl_Menus.InsertOnSubmit(menuitem1);
            //    dc.SubmitChanges();


            //    var menutranslations01 = new prtl_Translation();

            //    menutranslations01.Translation_Data = "الرؤية و الرسالة و الأهداف";
            //    menutranslations01.Lang_Id = 1;
            //    menutranslations01.Translation_ID = menuitem1.Translation_ID;


            //    dc.prtl_Translations.InsertOnSubmit(menutranslations01);
            //    dc.SubmitChanges();

            //    prtl_Translation menutranslations1 = new prtl_Translation();

            //    menutranslations1.Translation_Data = "Vision Mission Goals";
            //   menutranslations1.Lang_Id = 2;
            //    menutranslations1.Translation_ID = menuitem1.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations1);
            //    dc.SubmitChanges();


            //    prtl_Menu menuitem2 = new prtl_Menu();

            //    // menuitem2.    Parent_id = 145753;
            //    menuitem2.Roles = "All";
            //    menuitem2.Position = "Vertical";
            //    menuitem2.Published = true;
            //    menuitem2.Order = 2;
            //    menuitem2.Owner_ID = c.Owner_ID;



            //    dc.prtl_Menus.InsertOnSubmit(menuitem2);
            //    dc.SubmitChanges();


            //    prtl_Translation menutranslations02 = new prtl_Translation();

            //    menutranslations02.Translation_Data = "أخبار الوحدة و خدماتها";
            //    menutranslations02.Lang_Id = 1;
            //    menutranslations02.Translation_ID = menuitem2.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations02);
            //    dc.SubmitChanges();

            //    prtl_Translation menutranslations2 = new prtl_Translation();

            //    menutranslations2.Translation_Data = "Unit News and Services";
            //    menutranslations2.Lang_Id = 2;
            //    menutranslations2.Translation_ID = menuitem2.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations2);
            //    dc.SubmitChanges();


            //    var menuitem3 = new prtl_Menu
            //        {
            //            //    Parent_id = 145753,
            //            Roles = "All",
            //            Position = "Vertical",
            //            Published = true,
            //            Order = 3,
            //            Owner_ID = c.Owner_ID
            //        };

            //    dc.prtl_Menus.InsertOnSubmit(menuitem3);
            //    dc.SubmitChanges();


            //    prtl_Translation menutranslations03 = new prtl_Translation();

            //    menutranslations03.Translation_Data = "الأعضاء";
            //    menutranslations03.Lang_Id = 1;
            //    menutranslations03.Translation_ID = menuitem3.Translation_ID;


            //    dc.prtl_Translations.InsertOnSubmit(menutranslations03);
            //    dc.SubmitChanges();
            //    prtl_Translation menutranslations3 = new prtl_Translation();

            //    menutranslations3.Translation_Data = "Members";
            //    menutranslations3.Lang_Id = 2;
            //    menutranslations3.Translation_ID = menuitem3.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations3);
            //    dc.SubmitChanges();

            //    var menuitem4 = new prtl_Menu
            //  {
            //      //    Parent_id = 145753,
            //      Roles = "All",
            //      Position = "Vertical",
            //      Published = true,
            //      Order = 4,
            //      Owner_ID = c.Owner_ID
            //  };

            //    dc.prtl_Menus.InsertOnSubmit(menuitem4);
            //    dc.SubmitChanges();


            //    prtl_Translation menutranslations04 = new prtl_Translation();

            //    menutranslations04.Translation_Data = "مدير الوحدة ";
            //    menutranslations04.Lang_Id = 1;
            //    menutranslations04.Translation_ID = menuitem4.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations04);
            //    dc.SubmitChanges();
            //    prtl_Translation menutranslations4 = new prtl_Translation();

            //    menutranslations4.Translation_Data = "Unit Manager";
            //    menutranslations4.Lang_Id = 2;
            //    menutranslations4.Translation_ID = menuitem4.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations4);
            //    dc.SubmitChanges();

            //    var menuitem5 = new prtl_Menu
            //    {
            //        //    Parent_id = 145753,
            //        Roles = "All",
            //        Position = "Vertical",
            //        Published = true,
            //        Order = 5,
            //        Owner_ID = c.Owner_ID
            //    };

            //    dc.prtl_Menus.InsertOnSubmit(menuitem5);
            //    dc.SubmitChanges();


            //    prtl_Translation menutranslations05 = new prtl_Translation();

            //    menutranslations05.Translation_Data = "كيفية الاتصال والمواعيد  ";
            //    menutranslations05.Lang_Id = 1;
            //    menutranslations05.Translation_ID = menuitem5.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations05);



            //    prtl_Translation menutranslations5 = new prtl_Translation();

            //    menutranslations5.Translation_Data = "contact and session dates";
            //    menutranslations5.Lang_Id = 2;
            //    menutranslations5.prtl_Menu = menuitem5;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations5);
            //    dc.SubmitChanges();


            //    var menuitem6 = new prtl_Menu
            //    {
            //        //   Parent_id = 145753,
            //        Roles = "All",
            //        Position = "Vertical",
            //        Published = true,
            //        Order = 6,
            //        Owner_ID = c.Owner_ID
            //    };

            //    dc.prtl_Menus.InsertOnSubmit(menuitem6);
            //    dc.SubmitChanges();


            //    prtl_Translation menutranslations06 = new prtl_Translation();

            //    menutranslations06.Translation_Data = "مكتبه للوثائق ";
            //    menutranslations06.Lang_Id = 1;
            //    menutranslations06.Translation_ID = menuitem6.Translation_ID;


            //    dc.prtl_Translations.InsertOnSubmit(menutranslations06);
            //    dc.SubmitChanges();
            //    prtl_Translation menutranslations6 = new prtl_Translation();

            //    menutranslations6.Translation_Data = "Office documents";
            //    menutranslations6.Lang_Id = 2;
            //    menutranslations6.Translation_ID = menuitem6.Translation_ID;

            //    dc.prtl_Translations.InsertOnSubmit(menutranslations6);
            //    dc.SubmitChanges();



            //}
#endregion
            #region insertMenuthe4first
           
            //List<prtl_Owner> o = (from cc in dc.prtl_Owners where cc.Type == 6 && (cc.Parent_Id == 23 || cc.Parent_Id == 24 || cc.Parent_Id == 25 || cc.Parent_Id == 30 || cc.Parent_Id == 31 || cc.Parent_Id == 38 || cc.Parent_Id == 39 || cc.Parent_Id == 40 || cc.Parent_Id == 41 || cc.Parent_Id == 42 || cc.Parent_Id == 43) && !(cc.Abbr.Contains("Student")) && !(cc.Abbr.Contains("UnitFac")) && !(cc.Abbr.Contains("UnitElec")) select cc).ToList();
            //foreach (var c in o)
            //{
            //                var menuitem1 = new prtl_Menu
            //                {
            //                   // Parent_id = 145753,
            //                    Roles = "All",
            //                    Position = "Vertical",
            //                    Published = true ,
            //                    Order =1,
            //                    Owner_ID =c.Owner_ID 
            //                };
                           
            //                dc.prtl_Menus.InsertOnSubmit(menuitem1);
            //                dc.SubmitChanges();


            //                var menutranslations01 =  new prtl_Translation();

            //                       menutranslations01. Translation_Data = "أخبار المجلس";
            //                      menutranslations01.  Lang_Id  = 1;
            //                     menutranslations01.   Translation_ID =menuitem1.Translation_ID ;


            //             dc.prtl_Translations.InsertOnSubmit(menutranslations01);
            //                 dc.SubmitChanges();

            //             prtl_Translation menutranslations1 = new prtl_Translation();

            //                       menutranslations1. Translation_Data = "Council News";
            //                      menutranslations1.  Lang_Id  = 2;
            //                     menutranslations1.   Translation_ID =menuitem1.Translation_ID ;

            //                   dc.prtl_Translations.InsertOnSubmit(menutranslations1);
            //                dc.SubmitChanges();

            //prtl_Menu menuitem2 = new prtl_Menu();

            //               // menuitem2.    Parent_id = 145753;
            //                    menuitem2.Roles = "All";
            //                  menuitem2.  Position = "Vertical";
            //                   menuitem2. Published = true ;
            //                  menuitem2.  Order =2;
            //                 menuitem2.    Owner_ID =c.Owner_ID ;


                          
            //                dc.prtl_Menus.InsertOnSubmit(menuitem2);
            //                dc.SubmitChanges();


            //                prtl_Translation menutranslations02 = new prtl_Translation();

            //                      menutranslations02.  Translation_Data = "قرارات المجلس";
            //                      menutranslations02.  Lang_Id  = 1;
            //                      menutranslations02.  Translation_ID =menuitem2.Translation_ID ;

            //              dc.prtl_Translations.InsertOnSubmit(menutranslations02);
            //                 dc.SubmitChanges();

            //                 prtl_Translation menutranslations2 =new prtl_Translation();

            //                       menutranslations2. Translation_Data = "Council Decisions";
            //                      menutranslations2.   Lang_Id  = 2;
            //                    menutranslations2.   Translation_ID =menuitem2.Translation_ID ;

            //                  dc.prtl_Translations.InsertOnSubmit(menutranslations2);
            //                dc.SubmitChanges();


            //            var menuitem3 = new prtl_Menu
            //                {
            //                //    Parent_id = 145753,
            //                    Roles = "All",
            //                    Position = "Vertical",
            //                    Published = true ,
            //                    Order =3,
            //                     Owner_ID =c.Owner_ID 
            //                };

            //                dc.prtl_Menus.InsertOnSubmit(menuitem3);
            //                dc.SubmitChanges();


            //                prtl_Translation menutranslations03 =new prtl_Translation();

            //                      menutranslations03.  Translation_Data = "اعضاء المجلس ";
            //                    menutranslations03.    Lang_Id  = 1;
            //                    menutranslations03.   Translation_ID =menuitem3.Translation_ID ;


            //              dc.prtl_Translations.InsertOnSubmit(menutranslations03);
            //                 dc.SubmitChanges();
            //              prtl_Translation menutranslations3 =new prtl_Translation();

            //                      menutranslations3.  Translation_Data = "Council Members";
            //                      menutranslations3. Lang_Id  = 2;
            //                     menutranslations3.  Translation_ID =menuitem3.Translation_ID;

            //               dc.prtl_Translations.InsertOnSubmit(menutranslations3);
            //                dc.SubmitChanges();

            //                  var menuitem4 = new prtl_Menu
            //                {
            //                //    Parent_id = 145753,
            //                    Roles = "All",
            //                    Position = "Vertical",
            //                    Published = true ,
            //                    Order =4,
            //                     Owner_ID =c.Owner_ID 
            //                };

            //                dc.prtl_Menus.InsertOnSubmit(menuitem4);
            //                dc.SubmitChanges();


            //                prtl_Translation menutranslations04 = new prtl_Translation();

            //                      menutranslations04.  Translation_Data = "معلومات عن رئيس المجلس ";
            //                     menutranslations04.    Lang_Id  = 1;
            //                    menutranslations04.  Translation_ID =menuitem4.Translation_ID ;

            //              dc.prtl_Translations.InsertOnSubmit(menutranslations04);
            //                 dc.SubmitChanges();
            //              prtl_Translation menutranslations4 = new prtl_Translation();

            //                      menutranslations4.  Translation_Data = "About the President of the Council";
            //                     menutranslations4.  Lang_Id  = 2;
            //                     menutranslations4.  Translation_ID =menuitem4.Translation_ID ;

            //                dc.prtl_Translations.InsertOnSubmit(menutranslations4);
            //                dc.SubmitChanges();

            //                var menuitem5 = new prtl_Menu
            //                {
            //                //    Parent_id = 145753,
            //                    Roles = "All",
            //                    Position = "Vertical",
            //                    Published = true ,
            //                    Order =5,
            //                     Owner_ID =c.Owner_ID 
            //                };

            //                dc.prtl_Menus.InsertOnSubmit(menuitem5);
            //                dc.SubmitChanges();


            //                prtl_Translation menutranslations05 =  new prtl_Translation();

            //                      menutranslations05.  Translation_Data = "كيفية الاتصال ومواعيد الانعقاد ";
            //                      menutranslations05.Lang_Id  = 1;
            //                      menutranslations05. Translation_ID =menuitem5.Translation_ID ;

            //                      dc.prtl_Translations.InsertOnSubmit(menutranslations05);



            //              prtl_Translation menutranslations5 = new prtl_Translation();

            //                       menutranslations5. Translation_Data = "contact and session dates";
            //                      menutranslations5.Lang_Id  = 2;
            //                       menutranslations5. prtl_Menu = menuitem5;

            //            dc.prtl_Translations.InsertOnSubmit(menutranslations5);
            //                 dc.SubmitChanges();


            //                var menuitem6 = new prtl_Menu
            //                {
            //                 //   Parent_id = 145753,
            //                    Roles = "All",
            //                    Position = "Vertical",
            //                    Published = true ,
            //                    Order =6,
            //                     Owner_ID =c.Owner_ID 
            //                };

            //                dc.prtl_Menus.InsertOnSubmit(menuitem6);
            //                dc.SubmitChanges();


            //                prtl_Translation menutranslations06 = new prtl_Translation();

            //                        menutranslations06. Translation_Data = "مكتبه للوثائق ";
            //                      menutranslations06 .Lang_Id  = 1;
            //                     menutranslations06. Translation_ID =menuitem6.Translation_ID ;


            //              dc.prtl_Translations.InsertOnSubmit(menutranslations06);
            //                 dc.SubmitChanges();
            //              prtl_Translation menutranslations6 = new prtl_Translation();

            //                       menutranslations6. Translation_Data = "Office documents";
            //                       menutranslations6.Lang_Id  = 2;
            //                       menutranslations6.  Translation_ID =menuitem6.Translation_ID ;

            //                 dc.prtl_Translations.InsertOnSubmit(menutranslations6);
            //                dc.SubmitChanges();



            //}
            #endregion


            #region council
            


            //********************insert menu Council*****************//

           
//////////            var dc = new PortalDataContextDataContext();
          

//////////            var menuitem0 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Order = 1,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_CounFac"

//////////              ,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////             dc.prtl_Menus.InsertOnSubmit(menuitem0);
//////////            dc.SubmitChanges();


//////////            var menutranslations00 = new prtl_Translation();

//////////            menutranslations00.Translation_Data = "موقع مجلس الكلية";
//////////            menutranslations00.Lang_Id = 1;
//////////            menutranslations00.Translation_ID = menuitem0.Translation_ID;


//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations00);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations0 = new prtl_Translation();

//////////            menutranslations0.Translation_Data = "Faculity Council Site";
//////////            menutranslations0.Lang_Id = 2;
//////////            menutranslations0.Translation_ID = menuitem0.Translation_ID;

//////////           dc.prtl_Translations.InsertOnSubmit(menutranslations0);
//////////            dc.SubmitChanges();


//////////            var menuitem1 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Order = 2,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_CounStud"
//////////                ,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")

//////////            };
//////////            var dc1 = new PortalDataContextDataContext();
//////////             dc.prtl_Menus.InsertOnSubmit(menuitem1);
//////////            dc.SubmitChanges();


//////////            var menutranslations01 = new prtl_Translation();

//////////            menutranslations01.Translation_Data = "موقع مجلس شئون الطلاب";
//////////            menutranslations01.Lang_Id = 1;
//////////            menutranslations01.Translation_ID = menuitem1.Translation_ID;


//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations01);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations1 = new prtl_Translation();

//////////            menutranslations1.Translation_Data = "Student Affairs Council website";
//////////            menutranslations1.Lang_Id = 2;
//////////            menutranslations1.Translation_ID = menuitem1.Translation_ID;

//////////              dc.prtl_Translations.InsertOnSubmit(menutranslations1);
//////////            dc.SubmitChanges();


//////////            var menuitem2 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Order = 3,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_CounPost",

//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////             dc.prtl_Menus.InsertOnSubmit(menuitem2);
//////////            dc.SubmitChanges();


//////////            var menutranslations02 = new prtl_Translation();

//////////            menutranslations02.Translation_Data = "موقع مجلس الدراسات العليا";
//////////            menutranslations02.Lang_Id = 1;
//////////            menutranslations02.Translation_ID = menuitem2.Translation_ID;


//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations02);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations2 = new prtl_Translation();

//////////            menutranslations2.Translation_Data = "Council of Graduate Studies site";
//////////            menutranslations2.Lang_Id = 2;
//////////            menutranslations2.Translation_ID = menuitem2.Translation_ID;

//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations2);
//////////            dc.SubmitChanges();

//////////            var menuitem3 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Order = 4,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_CounSoc"
//////////,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////             dc.prtl_Menus.InsertOnSubmit(menuitem3);
//////////            dc.SubmitChanges();


//////////            var menutranslations03 = new prtl_Translation();

//////////            menutranslations03.Translation_Data = "موقع مجلس خدمة المجتمع وشئون البيئة";
//////////            menutranslations03.Lang_Id = 1;
//////////            menutranslations03.Translation_ID = menuitem3.Translation_ID;


//////////            dc.prtl_Translations.InsertOnSubmit(menutranslations03);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations3 = new prtl_Translation();

//////////            menutranslations3.Translation_Data = "Community Service Council and Environmental Affairs";
//////////            menutranslations3.Lang_Id = 2;
//////////            menutranslations3.Translation_ID = menuitem3.Translation_ID;

//////////              dc.prtl_Translations.InsertOnSubmit(menutranslations3);
//////////            dc.SubmitChanges();

//////////            var menuitem4 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_UnitElec"
//////////,
//////////                Order = 5,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////             dc.prtl_Menus.InsertOnSubmit(menuitem4);
//////////            dc.SubmitChanges();


//////////            var menutranslations04 = new prtl_Translation();

//////////            menutranslations04.Translation_Data = "موقع وحدة الخدمات الالكترونية";
//////////            menutranslations04.Lang_Id = 1;
//////////            menutranslations04.Translation_ID = menuitem4.Translation_ID;


//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations04);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations4 = new prtl_Translation();

//////////            menutranslations4.Translation_Data = "Site and electronic services unit";
//////////            menutranslations4.Lang_Id = 2;
//////////            menutranslations4.Translation_ID = menuitem4.Translation_ID;

//////////              dc.prtl_Translations.InsertOnSubmit(menutranslations4);
//////////            dc.SubmitChanges();


//////////            var menuitem5 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_UnitFac"
//////////,
//////////                Order = 6,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////            dc.prtl_Menus.InsertOnSubmit(menuitem5);
//////////            dc.SubmitChanges();


//////////            var menutranslations05 = new prtl_Translation();

//////////            menutranslations05.Translation_Data = "موقع خدمات الكليه";
//////////            menutranslations05.Lang_Id = 1;
//////////            menutranslations05.Translation_ID = menuitem5.Translation_ID;


//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations05);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations5 = new prtl_Translation();

//////////            menutranslations5.Translation_Data = "Services college site";
//////////            menutranslations5.Lang_Id = 2;
//////////            menutranslations5.Translation_ID = menuitem5.Translation_ID;

//////////             dc.prtl_Translations.InsertOnSubmit(menutranslations5);
//////////            dc.SubmitChanges();



//////////            var menuitem6 = new prtl_Menu
//////////            {
//////////                Parent_id = 145801,
//////////                Roles = "All",
//////////                Position = "Vertical",
//////////                Published = true,
//////////                Url = "http://mu.menofia.edu.eg/LAW/Law_Student"
//////////,
//////////                Order = 7,
//////////                Owner_ID = new Guid("bd1ccc98-9958-461e-a7e7-493178588e16")
//////////            };

//////////             dc.prtl_Menus.InsertOnSubmit(menuitem6);
//////////            dc.SubmitChanges();


//////////            var menutranslations06 = new prtl_Translation();

//////////            menutranslations06.Translation_Data = "موقع الطلاب";
//////////            menutranslations06.Lang_Id = 1;
//////////            menutranslations06.Translation_ID = menuitem6.Translation_ID;


//////////              dc.prtl_Translations.InsertOnSubmit(menutranslations06);
//////////            dc.SubmitChanges();

//////////            prtl_Translation menutranslations6 = new prtl_Translation();

//////////            menutranslations6.Translation_Data = "Student Site";
//////////            menutranslations6.Lang_Id = 2;
//////////            menutranslations6.Translation_ID = menuitem6.Translation_ID;

//////////              dc.prtl_Translations.InsertOnSubmit(menutranslations6);
            //////////            dc.SubmitChanges();
            #endregion
        }


        public static string GetParentidValues(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();
            
            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuUnivTran != null) { 
        return prtlMenuUnivTran
            .prtl_menu_univ.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            if (abbr.ToLower() == "fci")
            {
                var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFciTran != null) { 
                    return prtlMenuFciTran
                        .prtl_menu_fci.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "fee")
            {
                var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFeeTran != null) { 
                    return prtlMenuFeeTran
                        .prtl_menu_fee.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "eng")
            {
                var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuEngTran != null) { 
                    return prtlMenuEngTran
                        .prtl_menu_eng.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "nur")
            {
                var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuNurTran != null) { 
                    return prtlMenuNurTran
                        .prtl_menu_nur.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "edu")
            {
                var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuEduTran != null) { 
                    return prtlMenuEduTran
                        .prtl_menu_edu.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "sci")
            {
                var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuSciTran != null) { 
                    return prtlMenuSciTran
                        .prtl_menu_sci.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "edv")
            {
                var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuEdvTran != null) { 
                    return prtlMenuEdvTran
                        .prtl_menu_edv.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "agr")
            {
                var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuAgrTran != null) { 
                    return prtlMenuAgrTran
                        .prtl_menu_agr.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "hec")
            {
                var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuHecTran != null) { 
                    return prtlMenuHecTran
                        .prtl_menu_hec.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "law")
            {
                var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuLawTran != null) { 
                    return prtlMenuLawTran
                        .prtl_menu_law.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "fpe")
            {
                var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFpeTran != null) { 
                    return prtlMenuFpeTran
                        .prtl_menu_fpe.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
                //********************************
            else if (abbr.ToLower() == "pharm")
            {
                var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFpeTran != null)
                {
                    return prtlMenuFpeTran
                        .prtl_menu_Pharm.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "vmed")
            {
                var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFpeTran != null)
                {
                    return prtlMenuFpeTran
                        .prtl_menu_VMed.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
                ///////////////////////////////////////
            else if (abbr.ToLower() == "fa")
            {
                var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuFaTran != null) { 
                    return prtlMenuFaTran
                        .prtl_menu_fa.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "art")
            {
                var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuArtTran != null) {
                    return prtlMenuArtTran
                        .prtl_menu_art.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "ho")
            {
                var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuHoTran != null) { 
                    return prtlMenuHoTran
                        .prtl_menu_ho.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "med")
            {
                var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuMedTran != null) { 
                    return prtlMenuMedTran
                        .prtl_menu_med.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "liv")
            {
                var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuLivTran != null) { 
                    return prtlMenuLivTran
                        .prtl_menu_liv.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            else if (abbr.ToLower() == "com")
            {
                var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuComTran != null) { 
                    return prtlMenuComTran
                        .prtl_menu_com.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                var prtlMenueceduTran1 = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenueceduTran1 != null)
                {
                    return prtlMenueceduTran1
                        .prtl_menu_ECEDU.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            //else if (abbr.ToLower() == "media")
            //{
            //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
            //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
            //    if (prtlMenuComTran != null)
            //    {
            //        return prtlMenuComTran
            //            .prtl_menu_com.Parent_id.ToString();
            //    }
            //    else
            //    {
            //        return "";
            //    }
            //}
            //else if (abbr.ToLower() == "dent")
            //{
            //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
            //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
            //    if (prtlMenuComTran != null)
            //    {
            //        return prtlMenuComTran
            //            .prtl_menu_com.Parent_id.ToString();
            //    }
            //    else
            //    {
            //        return "";
            //    }
            //}
            else
            {
                var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlTranslation != null) { 
                    return
                        prtlTranslation
                            .prtl_Menu.Parent_id.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public static string GetOrder(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var q = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (q != null)
                {
                    return q.prtl_menu_univ.Order.ToString();
                }
                else
                {
                    return "0";
                }

            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var q = dc.prtl_menu_fci_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_fci.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "fee")
                {
                    var q = dc.prtl_menu_fee_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_fee.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "eng")
                {
                    var q = dc.prtl_menu_eng_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_eng.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "nur")
                {
                    var q = dc.prtl_menu_nur_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_nur.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "edu")
                {
                    var q = dc.prtl_menu_edu_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_edu.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "sci")
                {
                    var q = dc.prtl_menu_sci_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_sci.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "edv")
                {
                    var q = dc.prtl_menu_edv_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_edv.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "agr")
                {
                    var q = dc.prtl_menu_agr_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_agr.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "hec")
                {
                    var q = dc.prtl_menu_hec_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_hec.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "law")
                {
                    var q = dc.prtl_menu_law_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_law.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var q = dc.prtl_menu_fpe_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_fpe.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                    //***************************
                else if (abbr.ToLower() == "vmed")
                {
                    var q = dc.prtl_menu_VMed_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_VMed.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var q = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_Pharm.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }

                    //***********************************
                else if (abbr.ToLower() == "fa")
                {
                    var q = dc.prtl_menu_fa_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_fa.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "art")
                {
                    var q = dc.prtl_menu_art_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_art.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "ho")
                {
                    var q = dc.prtl_menu_ho_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_ho.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "med")
                {
                    var q = dc.prtl_menu_med_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_med.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "liv")
                {
                    var q = dc.prtl_menu_liv_trans.SingleOrDefault(
                   x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_liv.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "com")
                {
                    var q = dc.prtl_menu_com_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_com.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var q = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return q.prtl_menu_ECEDU.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var q = dc.prtl_menu_com_trans.SingleOrDefault(
                //    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (q != null)
                //    {
                //        return q.prtl_menu_com.Order.ToString();
                //    }
                //    else
                //    {
                //        return "0";
                //    }
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var q = dc.prtl_menu_com_trans.SingleOrDefault(
                //    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (q != null)
                //    {
                //        return q.prtl_menu_com.Order.ToString();
                //    }
                //    else
                //    {
                //        return "0";
                //    }
                //}
                else
                {
                    var q = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (q != null)
                    {
                        return

                            q.prtl_Menu.Order.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
        
            
        }

        public static string GetURL(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuUnivTran != null) { 
                    return
                        prtlMenuUnivTran
                            .prtl_menu_univ.Url;
                }
                else
                {
                    return "";
                }
            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFciTran != null) { 
                        return
                            prtlMenuFciTran
                                .prtl_menu_fci.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "fee")
                {
                    var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFeeTran != null) { 
                        return
                            prtlMenuFeeTran
                                .prtl_menu_fee.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "eng")
                {
                    var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEngTran != null) { 
                        return
                            prtlMenuEngTran
                                .prtl_menu_eng.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "nur")
                {
                    var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuNurTran != null) { 
                        return
                            prtlMenuNurTran
                                .prtl_menu_nur.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edu")
                {
                    var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEduTran != null) { 
                        return
                            prtlMenuEduTran
                                .prtl_menu_edu.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "sci")
                {
                    var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuSciTran != null) { 
                        return
                            prtlMenuSciTran
                                .prtl_menu_sci.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edv")
                {
                    var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEdvTran != null) { 
                        return
                            prtlMenuEdvTran
                                .prtl_menu_edv.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "agr")
                {
                    var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuAgrTran != null) { 
                        return
                            prtlMenuAgrTran
                                .prtl_menu_agr.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "hec")
                {
                    var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHecTran != null) { 
                        return
                            prtlMenuHecTran
                                .prtl_menu_hec.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "law")
                {
                    var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLawTran != null) { 
                        return
                            prtlMenuLawTran
                                .prtl_menu_law.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null) { 
                        return
                            prtlMenuFpeTran
                                .prtl_menu_fpe.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                    //****************
                else if (abbr.ToLower() == "pharm")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_Pharm.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_VMed.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                    //*********************
                else if (abbr.ToLower() == "fa")
                {
                    var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFaTran != null) { 
                        return
                            prtlMenuFaTran
                                .prtl_menu_fa.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "art")
                {
                    var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuArtTran != null) { 
                        return
                            prtlMenuArtTran
                                .prtl_menu_art.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "ho")
                {
                    var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHoTran != null) { 
                        return
                            prtlMenuHoTran
                                .prtl_menu_ho.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "med")
                {
                    var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuMedTran != null) { 
                        return
                            prtlMenuMedTran
                                .prtl_menu_med.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "liv")
                {
                    var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLivTran != null) { 
                        return
                            prtlMenuLivTran
                                .prtl_menu_liv.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "com")
                {
                    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuComTran != null) { 
                        return
                            prtlMenuComTran
                                .prtl_menu_com.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenueceduTran != null)
                    {
                        return
                            prtlMenueceduTran
                                .prtl_menu_ECEDU.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Url;
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Url;
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                else
                {
                    var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlTranslation != null) { 
                        return
                            prtlTranslation
                                .prtl_Menu.Url;
                    }
                    else
                    {
                        return "";
                    }
                }
        }

        //public static string GetURLTarget(Guid tid, string currentlanguage, string abbr)
        //{
        //    var dc = new PortalDataContextDataContext();

        //    if (abbr == null)
        //    {
        //        var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
        //            x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //        if (prtlMenuUnivTran != null) { 
        //            return
        //                prtlMenuUnivTran
        //                    .prtl_menu_univ.Url_target.ToString();
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    else
        //        if (abbr.ToLower() == "fci")
        //        {
        //            var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuFciTran != null) { 
        //                return
        //                    prtlMenuFciTran
        //                        .prtl_menu_fci.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "fee")
        //        {
        //            var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuFeeTran != null) { 
        //                return
        //                    prtlMenuFeeTran
        //                        .prtl_menu_fee.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "eng")
        //        {
        //            var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuEngTran != null) { 
        //                return
        //                    prtlMenuEngTran
        //                        .prtl_menu_eng.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "nur")
        //        {
        //            var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuNurTran != null) { 
        //                return
        //                    prtlMenuNurTran
        //                        .prtl_menu_nur.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "edu")
        //        {
        //            var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuEduTran != null) { 
        //                return
        //                    prtlMenuEduTran
        //                        .prtl_menu_edu.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "sci")
        //        {
        //            var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuSciTran != null) { 
        //                return
        //                    prtlMenuSciTran
        //                        .prtl_menu_sci.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "edv")
        //        {
        //            var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuEdvTran != null) { 
        //                return
        //                    prtlMenuEdvTran
        //                        .prtl_menu_edv.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "agr")
        //        {
        //            var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuAgrTran != null) { 
        //                return
        //                    prtlMenuAgrTran
        //                        .prtl_menu_agr.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "hec")
        //        {
        //            var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuHecTran != null) { 
        //                return
        //                    prtlMenuHecTran
        //                        .prtl_menu_hec.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "law")
        //        {
        //            var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuLawTran != null) { 
        //                return
        //                    prtlMenuLawTran
        //                        .prtl_menu_law.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "fpe")
        //        {
        //            var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuFpeTran != null) { 
        //                return
        //                    prtlMenuFpeTran
        //                        .prtl_menu_fpe.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "fa")
        //        {
        //            var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuFaTran != null) { 
        //                return
        //                    prtlMenuFaTran
        //                        .prtl_menu_fa.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "art")
        //        {
        //            var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuArtTran != null) { 
        //                return
        //                    prtlMenuArtTran
        //                        .prtl_menu_art.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "ho")
        //        {
        //            var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuHoTran != null) { 
        //                return
        //                    prtlMenuHoTran
        //                        .prtl_menu_ho.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "med")
        //        {
        //            var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuMedTran != null) { 
        //                return
        //                    prtlMenuMedTran
        //                        .prtl_menu_med.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "liv")
        //        {
        //            var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuLivTran != null) { 
        //                return
        //                    prtlMenuLivTran
        //                        .prtl_menu_liv.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else if (abbr.ToLower() == "com")
        //        {
        //            var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlMenuComTran != null)
        //            {
        //                return
        //                    prtlMenuComTran
        //                        .prtl_menu_com.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else
        //        {
        //            var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
        //                x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
        //            if (prtlTranslation != null) { 
        //                return
        //                    prtlTranslation
        //                        .prtl_Menu.Url_target.ToString();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //}

        public static string GetRoles(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuUnivTran != null)
                {
                    return
                        prtlMenuUnivTran
                            .prtl_menu_univ.Roles.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFciTran != null) { 
                        return
                            prtlMenuFciTran
                                .prtl_menu_fci.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "fee")
                {
                    var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFeeTran != null) { 
                        return
                            prtlMenuFeeTran
                                .prtl_menu_fee.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "eng")
                {
                    var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEngTran != null) { 
                        return
                            prtlMenuEngTran
                                .prtl_menu_eng.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "nur")
                {
                    var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuNurTran != null) { 
                        return
                            prtlMenuNurTran
                                .prtl_menu_nur.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edu")
                {
                    var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEduTran != null)
                    {
                        return
                            prtlMenuEduTran
                                .prtl_menu_edu.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "sci")
                {
                    var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuSciTran != null) { 
                        return
                            prtlMenuSciTran
                                .prtl_menu_sci.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edv")
                {
                    var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEdvTran != null) { 
                        return
                            prtlMenuEdvTran
                                .prtl_menu_edv.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "agr")
                {
                    var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuAgrTran != null) { 
                        return
                            prtlMenuAgrTran
                                .prtl_menu_agr.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "hec")
                {
                    var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHecTran != null) { 
                        return
                            prtlMenuHecTran
                                .prtl_menu_hec.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "law")
                {
                    var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLawTran != null) { 
                        return
                            prtlMenuLawTran
                                .prtl_menu_law.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null) { 
                        return
                            prtlMenuFpeTran
                                .prtl_menu_fpe.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                    //***********************
                else if (abbr.ToLower() == "vmed")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_VMed.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_Pharm.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                    //**********************************
                else if (abbr.ToLower() == "fa")
                {
                    var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFaTran != null) { 
                        return
                            prtlMenuFaTran
                                .prtl_menu_fa.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "art")
                {
                    var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuArtTran != null) { 
                        return
                            prtlMenuArtTran
                                .prtl_menu_art.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "ho")
                {
                    var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHoTran != null) { 
                        return
                            prtlMenuHoTran
                                .prtl_menu_ho.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "med")
                {
                    var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuMedTran != null) { 
                        return
                            prtlMenuMedTran
                                .prtl_menu_med.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "liv")
                {
                    var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLivTran != null) { 
                        return
                            prtlMenuLivTran
                                .prtl_menu_liv.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "com")
                {
                    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuComTran != null) { 
                        return
                            prtlMenuComTran
                                .prtl_menu_com.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenueceduTran != null)
                    {
                        return
                            prtlMenueceduTran
                                .prtl_menu_ECEDU.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Roles.ToString();
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Roles.ToString();
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                else
                {
                    var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlTranslation != null) { 
                        return
                            prtlTranslation
                                .prtl_Menu.Roles.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
        }

        public static string GetPosition(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuUnivTran != null)
                {
                    return
                        prtlMenuUnivTran
                            .prtl_menu_univ.Position.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFciTran != null){
                        return
                            prtlMenuFciTran
                                .prtl_menu_fci.Position.ToString();
                    }
                else
                {
                    return "";
                }
                }
                else if (abbr.ToLower() == "fee")
                {
                    var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFeeTran != null) { 
                        return
                            prtlMenuFeeTran
                                .prtl_menu_fee.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "eng")
                {
                    var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEngTran != null)
                    {
                        return
                            prtlMenuEngTran
                                .prtl_menu_eng.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "nur")
                {
                    var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuNurTran != null) { 
                        return
                            prtlMenuNurTran
                                .prtl_menu_nur.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edu")
                {
                    var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEduTran != null)
                    {
                        return
                            prtlMenuEduTran
                                .prtl_menu_edu.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "sci")
                {
                    var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuSciTran != null) { 
                        return
                            prtlMenuSciTran
                                .prtl_menu_sci.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "edv")
                {
                    var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEdvTran != null) { 
                        return
                            prtlMenuEdvTran
                                .prtl_menu_edv.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "agr")
                {
                    var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuAgrTran != null) { 
                        return
                            prtlMenuAgrTran
                                .prtl_menu_agr.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "hec")
                {
                    var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHecTran != null) { 
                        return
                            prtlMenuHecTran
                                .prtl_menu_hec.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "law")
                {
                    var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLawTran != null) { 
                        return
                            prtlMenuLawTran
                                .prtl_menu_law.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null) { 
                        return
                            prtlMenuFpeTran
                                .prtl_menu_fpe.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                    //***************
                else if (abbr.ToLower() == "pharm")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_Pharm.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return
                            prtlMenuFpeTran
                                .prtl_menu_VMed.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                    //************************
                else if (abbr.ToLower() == "fa")
                {
                    var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFaTran != null) { 
                        return
                            prtlMenuFaTran
                                .prtl_menu_fa.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "art")
                {
                    var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuArtTran != null) { 
                        return
                            prtlMenuArtTran
                                .prtl_menu_art.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "ho")
                {
                    var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHoTran != null)
                    {
                        return
                            prtlMenuHoTran
                                .prtl_menu_ho.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "med")
                {
                    var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuMedTran != null) { 
                        return
                            prtlMenuMedTran
                                .prtl_menu_med.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "liv")
                {
                    var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLivTran != null) { 
                        return
                            prtlMenuLivTran
                                .prtl_menu_liv.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (abbr.ToLower() == "com")
                {
                    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuComTran != null)
                    {
                        return
                            prtlMenuComTran
                                .prtl_menu_com.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenueceduTran != null)
                    {
                        return
                            prtlMenueceduTran
                                .prtl_menu_ECEDU.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Position.ToString();
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return
                //            prtlMenuComTran
                //                .prtl_menu_com.Position.ToString();
                //    }
                //    else
                //    {
                //        return "";
                //    }
                //}
                else
                {
                    var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlTranslation != null)
                    {
                        return
                            prtlTranslation
                                .prtl_Menu.Position.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
        }

        public static bool GetPublished(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                return
                    prtlMenuUnivTran != null && prtlMenuUnivTran
                            .prtl_menu_univ.Published;
            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                    prtlMenuFciTran != null && prtlMenuFciTran
                            .prtl_menu_fci.Published;
                }
                else if (abbr.ToLower() == "fee")
                {
                    var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuFeeTran != null && prtlMenuFeeTran
                           .prtl_menu_fee.Published;
                }
                else if (abbr.ToLower() == "eng")
                {
                    var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuEngTran != null && prtlMenuEngTran
                           .prtl_menu_eng.Published;
                }
                else if (abbr.ToLower() == "nur")
                {
                    var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuNurTran != null && prtlMenuNurTran
                           .prtl_menu_nur.Published;
                }
                else if (abbr.ToLower() == "edu")
                {
                    var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuEduTran != null && prtlMenuEduTran
                           .prtl_menu_edu.Published;
                }
                else if (abbr.ToLower() == "sci")
                {
                    var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuSciTran != null && prtlMenuSciTran
                           .prtl_menu_sci.Published;
                }
                else if (abbr.ToLower() == "edv")
                {
                    var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuEdvTran != null && prtlMenuEdvTran
                           .prtl_menu_edv.Published;
                }
                else if (abbr.ToLower() == "agr")
                {
                    var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuAgrTran != null && prtlMenuAgrTran
                           .prtl_menu_agr.Published;
                }
                else if (abbr.ToLower() == "hec")
                {
                    var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuHecTran != null && prtlMenuHecTran
                           .prtl_menu_hec.Published;
                }
                else if (abbr.ToLower() == "law")
                {
                    var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuLawTran != null && prtlMenuLawTran
                           .prtl_menu_law.Published;
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuFpeTran != null && prtlMenuFpeTran
                           .prtl_menu_fpe.Published;
                }
                    //****************************
                else if (abbr.ToLower() == "pharm")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuFpeTran != null && prtlMenuFpeTran
                           .prtl_menu_Pharm.Published;
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuFpeTran != null && prtlMenuFpeTran
                           .prtl_menu_VMed.Published;
                }
                    //***********************************
                else if (abbr.ToLower() == "fa")
                {
                    var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuFaTran != null && prtlMenuFaTran
                           .prtl_menu_fa.Published;
                }
                else if (abbr.ToLower() == "art")
                {
                    var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuArtTran != null && prtlMenuArtTran
                           .prtl_menu_art.Published;
                }
                else if (abbr.ToLower() == "ho")
                {
                    var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuHoTran != null && prtlMenuHoTran
                           .prtl_menu_ho.Published;
                }
                else if (abbr.ToLower() == "med")
                {
                    var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuMedTran != null && prtlMenuMedTran
                           .prtl_menu_med.Published;
                }
                else if (abbr.ToLower() == "liv")
                {
                    var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuLivTran != null && prtlMenuLivTran
                           .prtl_menu_liv.Published;
                }
                else if (abbr.ToLower() == "com")
                {
                    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenuComTran != null && prtlMenuComTran
                           .prtl_menu_com.Published;
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                   prtlMenueceduTran != null && prtlMenueceduTran
                           .prtl_menu_ECEDU.Published;
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    return
                //   prtlMenuComTran != null && prtlMenuComTran
                //           .prtl_menu_com.Published;
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    return
                //   prtlMenuComTran != null && prtlMenuComTran
                //           .prtl_menu_com.Published;
                //}
                else
                {
                    var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    return
                    prtlTranslation != null && prtlTranslation
                            .prtl_Menu.Published;
                }
        }

        public static string GetMenuId(Guid tid, string currentlanguage, string abbr)
        {
            var dc = new PortalDataContextDataContext();

            if (abbr == null)
            {
                var prtlMenuUnivTran = dc.prtl_menu_univ_trans.SingleOrDefault(
                    x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                if (prtlMenuUnivTran != null)
                {
                    return prtlMenuUnivTran
                        .prtl_menu_univ.Menu_id.ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
                if (abbr.ToLower() == "fci")
                {
                    var prtlMenuFciTran = dc.prtl_menu_fci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFciTran != null){
                        return prtlMenuFciTran
                            .prtl_menu_fci.Menu_id.ToString();
                    }
                else
                {
                    return "0";
                }
                }
                else if (abbr.ToLower() == "fee")
                {
                    var prtlMenuFeeTran = dc.prtl_menu_fee_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFeeTran != null){
                        return prtlMenuFeeTran
                            .prtl_menu_fee.Menu_id.ToString();
                    }
                else
                {
                    return "0";
                }
                }
                else if (abbr.ToLower() == "eng")
                {
                    var prtlMenuEngTran = dc.prtl_menu_eng_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEngTran != null) 
                    {
            return prtlMenuEngTran
                            .prtl_menu_eng.Menu_id.ToString();
                    }
                else
                {
                    return "0";
                }
                }
                else if (abbr.ToLower() == "nur")
                {
                    var prtlMenuNurTran = dc.prtl_menu_nur_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuNurTran != null){
                        return prtlMenuNurTran
                            .prtl_menu_nur.Menu_id.ToString();
                    }
                else
                {
                    return "0";
                }
                }
                else if (abbr.ToLower() == "edu")
                {
                    var prtlMenuEduTran = dc.prtl_menu_edu_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEduTran != null) { 
                        return prtlMenuEduTran
                            .prtl_menu_edu.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "sci")
                {
                    var prtlMenuSciTran = dc.prtl_menu_sci_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuSciTran != null) { 
                        return prtlMenuSciTran
                            .prtl_menu_sci.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "edv")
                {
                    var prtlMenuEdvTran = dc.prtl_menu_edv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuEdvTran != null) { 
                        return prtlMenuEdvTran
                            .prtl_menu_edv.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "agr")
                {
                    var prtlMenuAgrTran = dc.prtl_menu_agr_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuAgrTran != null) { 
                        return prtlMenuAgrTran
                            .prtl_menu_agr.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "hec")
                {
                    var prtlMenuHecTran = dc.prtl_menu_hec_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHecTran != null) { 
                        return prtlMenuHecTran
                            .prtl_menu_hec.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "law")
                {
                    var prtlMenuLawTran = dc.prtl_menu_law_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLawTran != null) { 
                        return prtlMenuLawTran
                            .prtl_menu_law.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_fpe_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null) { 
                        return prtlMenuFpeTran
                            .prtl_menu_fpe.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                    //**********************
                else if (abbr.ToLower() == "pharm")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_Pharm_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return prtlMenuFpeTran
                            .prtl_menu_Pharm.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var prtlMenuFpeTran = dc.prtl_menu_VMed_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFpeTran != null)
                    {
                        return prtlMenuFpeTran
                            .prtl_menu_VMed.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                    //*******************************
                else if (abbr.ToLower() == "fa")
                {
                    var prtlMenuFaTran = dc.prtl_menu_fa_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuFaTran != null) { 
                        return prtlMenuFaTran
                            .prtl_menu_fa.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "art")
                {
                    var prtlMenuArtTran = dc.prtl_menu_art_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuArtTran != null) { 
                        return prtlMenuArtTran
                            .prtl_menu_art.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "ho")
                {
                    var prtlMenuHoTran = dc.prtl_menu_ho_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuHoTran != null) { 
                        return prtlMenuHoTran
                            .prtl_menu_ho.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "med")
                {
                    var prtlMenuMedTran = dc.prtl_menu_med_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuMedTran != null) { 
                        return prtlMenuMedTran
                            .prtl_menu_med.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "liv")
                {
                    var prtlMenuLivTran = dc.prtl_menu_liv_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuLivTran != null) { 
                        return prtlMenuLivTran
                            .prtl_menu_liv.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else if (abbr.ToLower() == "com")
                {
                    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenuComTran != null) { 
                        return prtlMenuComTran
                            .prtl_menu_com.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var prtlMenueceduTran = dc.prtl_menu_ECEDU_trans.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlMenueceduTran != null)
                    {
                        return prtlMenueceduTran
                            .prtl_menu_ECEDU.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                //else if (abbr.ToLower() == "media")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return prtlMenuComTran
                //            .prtl_menu_com.Menu_id.ToString();
                //    }
                //    else
                //    {
                //        return "0";
                //    }
                //}
                //else if (abbr.ToLower() == "dent")
                //{
                //    var prtlMenuComTran = dc.prtl_menu_com_trans.SingleOrDefault(
                //        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                //    if (prtlMenuComTran != null)
                //    {
                //        return prtlMenuComTran
                //            .prtl_menu_com.Menu_id.ToString();
                //    }
                //    else
                //    {
                //        return "0";
                //    }
                //}
                else
                {
                    var prtlTranslation = dc.prtl_Translations.SingleOrDefault(
                        x => x.Translation_ID == tid && x.prtl_Language.LCID == currentlanguage);
                    if (prtlTranslation != null) { 
                        return
                            prtlTranslation
                                .prtl_Menu.Menu_id.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
        }

        public static object GetMenuIDs2(int menu_ID, Guid? ownerID, string currentlang, string position, string abbr)
        {
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            var dc = new PortalDataContextDataContext();
            if (abbr == null && type == 0)
            {
               
                   
                    return dc.prtl_menu_univ_trans
                        .Where(
                            m =>
                                m.prtl_menu_univ.Position == position && m.prtl_menu_univ.Menu_id != menu_ID &&
                                m.prtl_menu_univ.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_univ.Menu_id, tr.Translation_Data })
                        .OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
            {
                
                    return dc.prtl_menu_fci_trans
                        .Where(m => m.prtl_menu_fci.Position == position && m.prtl_menu_fci.Menu_id != menu_ID && m.prtl_menu_fci.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fci.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
               
            }
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                
                    return dc.prtl_menu_fee_trans
                        .Where(m => m.prtl_menu_fee.Position == position && m.prtl_menu_fee.Menu_id != menu_ID && m.prtl_menu_fee.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fee.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                
                    return dc.prtl_menu_eng_trans
                        .Where(m => m.prtl_menu_eng.Position == position && m.prtl_menu_eng.Menu_id != menu_ID && m.prtl_menu_eng.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_eng.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                
                    return dc.prtl_menu_nur_trans
                        .Where(m => m.prtl_menu_nur.Position == position && m.prtl_menu_nur.Menu_id != menu_ID && m.prtl_menu_nur.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_nur.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                
                    return dc.prtl_menu_edu_trans
                        .Where(m => m.prtl_menu_edu.Position == position && m.prtl_menu_edu.Menu_id != menu_ID && m.prtl_menu_edu.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_edu.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                
                    return dc.prtl_menu_sci_trans
                        .Where(m => m.prtl_menu_sci.Position == position && m.prtl_menu_sci.Menu_id != menu_ID && m.prtl_menu_sci.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_sci.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                
                    return dc.prtl_menu_edv_trans
                        .Where(m => m.prtl_menu_edv.Position == position && m.prtl_menu_edv.Menu_id != menu_ID && m.prtl_menu_edv.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_edv.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                
                    return dc.prtl_menu_agr_trans
                        .Where(m => m.prtl_menu_agr.Position == position && m.prtl_menu_agr.Menu_id != menu_ID && m.prtl_menu_agr.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_agr.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                
                    return dc.prtl_menu_hec_trans
                        .Where(m => m.prtl_menu_hec.Position == position && m.prtl_menu_hec.Menu_id != menu_ID && m.prtl_menu_hec.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_hec.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
               
                    return dc.prtl_menu_law_trans
                        .Where(m => m.prtl_menu_law.Position == position && m.prtl_menu_law.Menu_id != menu_ID && m.prtl_menu_law.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_law.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
               
                    return dc.prtl_menu_fpe_trans
                        .Where(m => m.prtl_menu_fpe.Position == position && m.prtl_menu_fpe.Menu_id != menu_ID && m.prtl_menu_fpe.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fpe.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
               
            }
                //******************************

            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {

                return dc.prtl_menu_Pharm_trans
                    .Where(m => m.prtl_menu_Pharm.Position == position && m.prtl_menu_Pharm.Menu_id != menu_ID && m.prtl_menu_Pharm.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                    .Select(tr => new { tr.prtl_menu_Pharm.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();

            }
            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {

                return dc.prtl_menu_VMed_trans
                    .Where(m => m.prtl_menu_VMed.Position == position && m.prtl_menu_VMed.Menu_id != menu_ID && m.prtl_menu_VMed.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                    .Select(tr => new { tr.prtl_menu_VMed.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();

            }
                //*************************************
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                
                    return dc.prtl_menu_fa_trans
                        .Where(m => m.prtl_menu_fa.Position == position && m.prtl_menu_fa.Menu_id != menu_ID && m.prtl_menu_fa.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_fa.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
               
                    return dc.prtl_menu_art_trans
                        .Where(m => m.prtl_menu_art.Position == position && m.prtl_menu_art.Menu_id != menu_ID && m.prtl_menu_art.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_art.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                
                    return dc.prtl_menu_ho_trans
                        .Where(m => m.prtl_menu_ho.Position == position && m.prtl_menu_ho.Menu_id != menu_ID && m.prtl_menu_ho.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_ho.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                
                    return dc.prtl_menu_med_trans
                        .Where(m => m.prtl_menu_med.Position == position && m.prtl_menu_med.Menu_id != menu_ID && m.prtl_menu_med.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_med.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                
                    return dc.prtl_menu_liv_trans
                        .Where(m => m.prtl_menu_liv.Position == position && m.prtl_menu_liv.Menu_id != menu_ID && m.prtl_menu_liv.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_liv.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
               
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                
                    return dc.prtl_menu_com_trans
                        .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
            //12121212
            else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            {

                return dc.prtl_menu_ECEDU_trans
                    .Where(m => m.prtl_menu_ECEDU.Position == position && m.prtl_menu_ECEDU.Menu_id != menu_ID && m.prtl_menu_ECEDU.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                    .Select(tr => new { tr.prtl_menu_ECEDU.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();

            }
            //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            //{

            //    return dc.prtl_menu_com_trans
            //        .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
            //        .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();

            //}
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{

            //    return dc.prtl_menu_com_trans
            //        .Where(m => m.prtl_menu_com.Position == position && m.prtl_menu_com.Menu_id != menu_ID && m.prtl_menu_com.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
            //        .Select(tr => new { tr.prtl_menu_com.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();

            //}
            else
            {
                
                    return dc.prtl_Translations
                        .Where(m => m.prtl_Menu.Position == position && m.prtl_Menu.Menu_id != menu_ID && m.prtl_Menu.Owner_ID.Equals(ownerID) && m.prtl_Language.LCID == currentlang)
                        .Select(tr => new { tr.prtl_Menu.Menu_id, tr.Translation_Data }).OrderBy(t => t.Translation_Data).ToList();
                
            }
        }
    }
}