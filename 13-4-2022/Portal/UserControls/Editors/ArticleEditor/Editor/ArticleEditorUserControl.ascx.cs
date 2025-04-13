using System;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.UI.WebControls;
using BLL;
using Common;
using FancyImageZoom;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.ArticleEditor
{
    public partial class ArticleEditorUserControl : ListViewBasedUserControl
    {
        protected override string DetailsViewBasedName
        {
            get { return "ArticleDetailsViewControl1"; }
        }

        protected override string FilterSessionName
        {
            get { return "ArticleOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "ArticlesLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "ArticlesListView"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);

            var data = prtl_ArticlesUtility.GetArticleByID(int.Parse(GetCommandArgForListItem(listViewItem)));

            var title_Label = GetControl<Label>("title_Label", listViewItem);
            title_Label.Text = ArticleTitle(data.ID);
        
            var MenuItemLbl = GetControl<Label>("MenuItemLbl", listViewItem);
            MenuItemLbl.Text = GetMenuItemText(data.ID);
        }

        protected void ArticleEditorControlInsertClicked(object sender, EventArgs e)
        {
            ArticleDetailsViewControl1.ShowInsert(FilterOwnerID, "0");
        }

        protected string ArticleTitle(object Article_ID)
        {
            var article = Prtl_ArticlesTranslationUtility.GetArticleTranslation(StaticUtilities.Currentlanguage(Page), Article_ID);
            return (article == null) ? "Not_Translated" : article.Title;
        }

        protected string GetMenuItemText(object ArticleID)
        {
            string abbr = (string)System.Web.HttpContext.Current.Session["owner_abbr"];
            int type = (int)System.Web.HttpContext.Current.Session["ownertype"];
            if (abbr == null && type == 0)
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }
                if (mid.prtl_menu_univ != null)
                {
                    var data =
                        Prtl_TranslationUtility.Get_univ_TransDataByTranIDandLCID(mid.prtl_menu_univ.Translation_ID,
                            StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "fci" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }
                if (mid.prtl_menu_fci != null)
                {
                    var data = Prtl_TranslationUtility.Get_fci_TransDataByTranIDandLCID(
                        mid.prtl_menu_fci.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "fee" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }
                if (mid.prtl_menu_fee != null)
                {
                    var data = Prtl_TranslationUtility.Get_fee_TransDataByTranIDandLCID(
                        mid.prtl_menu_fee.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }

            }
            else if (abbr != null && (abbr.ToLower() == "eng" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_eng != null)
                {
                    var data = Prtl_TranslationUtility.Get_eng_TransDataByTranIDandLCID(
                        mid.prtl_menu_eng.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "nur" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_nur != null)
                {
                    var data = Prtl_TranslationUtility.Get_nur_TransDataByTranIDandLCID(
                        mid.prtl_menu_nur.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "edu" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_edu != null)
                {
                    var data = Prtl_TranslationUtility.Get_edu_TransDataByTranIDandLCID(
                        mid.prtl_menu_edu.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "sci" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_sci != null)
                {
                    var data = Prtl_TranslationUtility.Get_sci_TransDataByTranIDandLCID(
                        mid.prtl_menu_sci.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "edv" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_edv != null)
                {
                    var data = Prtl_TranslationUtility.Get_edv_TransDataByTranIDandLCID(
                        mid.prtl_menu_edv.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "agr" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_agr != null)
                {
                    var data = Prtl_TranslationUtility.Get_agr_TransDataByTranIDandLCID(
                        mid.prtl_menu_agr.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "hec" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_hec != null)
                {
                    var data = Prtl_TranslationUtility.Get_hec_TransDataByTranIDandLCID(
                        mid.prtl_menu_hec.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "law" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_law != null)
                {
                    var data = Prtl_TranslationUtility.Get_law_TransDataByTranIDandLCID(
                        mid.prtl_menu_law.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "fpe" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_fpe != null)
                {
                    var data = Prtl_TranslationUtility.Get_fpe_TransDataByTranIDandLCID(
                        mid.prtl_menu_fpe.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
                //***************
            else if (abbr != null && (abbr.ToLower() == "pharm" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_Pharm != null)
                {
                    var data = Prtl_TranslationUtility.Get_Pharm_TransDataByTranIDandLCID(
                        mid.prtl_menu_Pharm.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "vmed" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_VMed != null)
                {
                    var data = Prtl_TranslationUtility.Get_VMed_TransDataByTranIDandLCID(
                        mid.prtl_menu_VMed.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
                //**********************
            else if (abbr != null && (abbr.ToLower() == "fa" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_fa != null)
                {
                    var data = Prtl_TranslationUtility.Get_fa_TransDataByTranIDandLCID(
                        mid.prtl_menu_fa.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "art" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_art != null)
                {
                    var data = Prtl_TranslationUtility.Get_art_TransDataByTranIDandLCID(
                        mid.prtl_menu_art.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "ho" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_ho != null)
                {
                    var data = Prtl_TranslationUtility.Get_ho_TransDataByTranIDandLCID(
                        mid.prtl_menu_ho.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "med" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_med != null)
                {
                    var data = Prtl_TranslationUtility.Get_med_TransDataByTranIDandLCID(
                        mid.prtl_menu_med.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "liv" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_liv != null)
                {
                    var data = Prtl_TranslationUtility.Get_liv_TransDataByTranIDandLCID(
                        mid.prtl_menu_liv.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            else if (abbr != null && (abbr.ToLower() == "com" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_com != null)
                {
                    var data = Prtl_TranslationUtility.Get_com_TransDataByTranIDandLCID(
                        mid.prtl_menu_com.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            //12121212
            else if (abbr != null && (abbr.ToLower() == "ecedu" && type == 1))
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

                if (mid.prtl_menu_ECEDU != null)
                {
                    var data = Prtl_TranslationUtility.Get_ecedu_TransDataByTranIDandLCID(
                        mid.prtl_menu_ECEDU.Translation_ID, StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else
                {
                    return "Not Translated";
                }
            }
            //else if (abbr != null && (abbr.ToLower() == "media" && type == 1))
            //{
            //    var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
            //    int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
            //    if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

            //    if (mid.prtl_menu_com != null)
            //    {
            //        var data = Prtl_TranslationUtility.Get_com_TransDataByTranIDandLCID(
            //            mid.prtl_menu_com.Translation_ID, StaticUtilities.Currentlanguage(Page));
            //        return data ?? "Not Translated";
            //    }
            //    else
            //    {
            //        return "Not Translated";
            //    }
            //}
            //else if (abbr != null && (abbr.ToLower() == "dent" && type == 1))
            //{
            //    var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
            //    int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
            //    if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }

            //    if (mid.prtl_menu_com != null)
            //    {
            //        var data = Prtl_TranslationUtility.Get_com_TransDataByTranIDandLCID(
            //            mid.prtl_menu_com.Translation_ID, StaticUtilities.Currentlanguage(Page));
            //        return data ?? "Not Translated";
            //    }
            //    else
            //    {
            //        return "Not Translated";
            //    }
            //}
            else
            {
                var mid = prtl_ArticlesUtility.GetArticleByID((int)ArticleID);
                int menuid = prtl_ArticlesUtility.checkIfMenuIdExists(Convert.ToInt32(mid.MenuItemId));
                if (mid.MenuItemId == null || menuid == 0) { return "No Item"; }
                if (mid.prtl_Menu != null)
                {
                    var data = Prtl_TranslationUtility.GetTransDataByTranIDandLCID(mid.prtl_Menu.Translation_ID,
                        StaticUtilities.Currentlanguage(Page));
                    return data ?? "Not Translated";
                }
                else { return "Not Translated"; }
            }
           

        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return Prtl_ArticlesTranslationUtility.LangsNotTranslated(CurrentTranslationID, data.ToString());
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return Prtl_ArticlesTranslationUtility.GetCountTranslations(data.ToString());
        }

        protected override bool Published(object data, string abbr = null)
        {
            return prtl_ArticlesUtility.GetPublishedState(data.ToString());
        }

       


        //protected void LinkButton1_OnClick(object sender, EventArgs e)
        //{
        //    HiddenField H = GetControl<HiddenField>("ArticleId",ArticlesListView);
        //    GetItemURL(H.Value);
        //}
    }
}