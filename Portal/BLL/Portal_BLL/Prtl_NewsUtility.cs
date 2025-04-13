using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using MnfUniversity_Portals.UserControls.Viewers;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_NewsUtility
    {
        public static void DeleteItem(int NewsID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            if (abbr == null)
            {
                var item = dc.prtl_news_univs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_univs.DeleteOnSubmit(item);
                dc.SubmitChanges();

            }
            else if (abbr.ToLower() == "fci")
            {
                var item = dc.prtl_news_fcis.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_fcis.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "fee")
            {
                var item = dc.prtl_news_fees.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_fees.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "eng")
            {
                var item = dc.prtl_news_engs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_engs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "nur")
            {
                var item = dc.prtl_news_nurs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_nurs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edu")
            {
                var item = dc.prtl_news_edus.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_edus.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "sci")
            {
                var item = dc.prtl_news_scis.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_scis.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "edv")
            {
                var item = dc.prtl_news_edvs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_edvs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "agr")
            {
                var item = dc.prtl_news_agrs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_agrs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "hec")
            {
                var item = dc.prtl_news_hecs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_hecs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "law")
            {
                var item = dc.prtl_news_laws.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_laws.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "fpe")
            {
                var item = dc.prtl_news_fpes.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_fpes.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
                //***************
            else if (abbr.ToLower() == "pharm")
            {
                var item = dc.prtl_news_Pharms.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_Pharms.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "vmed")
            {
                var item = dc.prtl_news_VMeds.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_VMeds.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
                //**********************
            else if (abbr.ToLower() == "fa")
            {
                var item = dc.prtl_news_fas.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_fas.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "art")
            {
                var item = dc.prtl_news_arts.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_arts.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "ho")
            {
                var item = dc.prtl_news_hos.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_hos.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "med")
            {
                var item = dc.prtl_news_meds.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_meds.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "liv")
            {
                var item = dc.prtl_news_livs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_livs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "com")
            {
                var item = dc.prtl_news_coms.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_coms.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            //12121212
            else if (abbr.ToLower() == "ecedu")
            {
                var item = dc.prtl_news_ECEDUs.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_ECEDUs.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else if (abbr.ToLower() == "media")
            {
                var item = dc.prtl_news_medias.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_medias.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }//fatma 6-6-2022
            else if (abbr.ToLower() == "dent")
            {
                var item = dc.prtl_news_dents.Single(nr => nr.News_Id == NewsID);
                dc.prtl_news_dents.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            else
            {
                var item = dc.prtl_News.Single(nr => nr.News_Id == NewsID);
                dc.prtl_News.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            
        }
        public static prtl_New GeNewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_News.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_Owner GetOwnerByNewsID(int ID)
        {
            return new PortalDataContextDataContext().prtl_News.SingleOrDefault(xx=>xx.News_Id==ID).prtl_Owner;
        }
        public static prtl_news_univ Get_univ_NewsByID(int ID)
        {
                    return new PortalDataContextDataContext().prtl_news_univs.SingleOrDefault(x => x.News_Id == ID);    
        }
        public static prtl_news_fci Get_fci_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_fcis.SingleOrDefault(x => x.News_Id == ID);
        }
        //3333333333333
        public static prtl_news_media Get_media_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_medias.SingleOrDefault(x => x.News_Id == ID);
        }
        //14-4-2022
        public static prtl_news_AI Get_ai_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_AIs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_dent Get_dent_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_dents.SingleOrDefault(x => x.News_Id == ID);
        }
        //***************
        public static prtl_news_Pharm Get_Pharm_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_Pharms.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_VMed Get_VMed_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_VMeds.SingleOrDefault(x => x.News_Id == ID);
        }//********************
        public static prtl_news_fee Get_fee_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_fees.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_eng Get_eng_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_engs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_sci Get_sci_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_scis.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_edu Get_edu_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_edus.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_nur Get_nur_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_nurs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_edv Get_edv_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_edvs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_art Get_art_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_arts.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_law Get_law_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_laws.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_com Get_com_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_coms.SingleOrDefault(x => x.News_Id == ID);
        }
        //12121212
        public static prtl_news_ECEDU Get_ecedu_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_ECEDUs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_med Get_med_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_meds.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_fpe Get_fpe_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_fpes.SingleOrDefault(x => x.News_Id == ID);
        }
        ////*************
        //public static prtl_news_Pharm Get_Pharm_NewsByID(int ID)
        //{
        //    return new PortalDataContextDataContext().prtl_news_Pharms.SingleOrDefault(x => x.News_Id == ID);
        //}
        //public static prtl_news_VMed Get_VMed_NewsByID(int ID)
        //{
        //    return new PortalDataContextDataContext().prtl_news_VMeds.SingleOrDefault(x => x.News_Id == ID);
        //}
        ////*******************
        public static prtl_news_fa Get_fas_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_fas.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_hec Get_hec_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_hecs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_agr Get_agr_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_agrs.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_ho Get_hos_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_hos.SingleOrDefault(x => x.News_Id == ID);
        }
        public static prtl_news_liv Get_liv_NewsByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_news_livs.SingleOrDefault(x => x.News_Id == ID);
        }
        //public static prtl_news_dent Get_dent_NewsByID(int ID)
        //{
        //    return new PortalDataContextDataContext().prtl_news_dents.SingleOrDefault(x => x.News_Id == ID);
        //}
        public static void InsertNewNewsItem(DetailsViewInsertEventArgs e, string filename, Guid? ownerid, string filteredproperty, DateTime newsdate,DateTime currentdate, bool published,string abbr,bool Featured)
        {


            var dc = new PortalDataContextDataContext();
            {
                 if (abbr==null)
                {
                var newNewsItem = new prtl_news_univ()
                    {
                        Owner_ID = ownerid,
                        News_img = filename,
                        News_date = newsdate,
                        currentNews_date = currentdate,
                        Published = published,
                        IsFeatured = Featured
                        
                    };

                dc.prtl_news_univs.InsertOnSubmit(newNewsItem);
                dc.SubmitChanges();
                e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "fci")
                 {
                     var newNewsItem = new prtl_news_fci()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_fcis.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "fee")
                 {
                     var newNewsItem = new prtl_news_fee()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_fees.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "eng")
                 {
                     var newNewsItem = new prtl_news_eng()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_engs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "sci")
                 {
                     var newNewsItem = new prtl_news_sci()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_scis.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "edu")
                 {
                     var newNewsItem = new prtl_news_edu()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_edus.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "edv")
                 {
                     var newNewsItem = new prtl_news_edv()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_edvs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "nur")
                 {
                     var newNewsItem = new prtl_news_nur()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_nurs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "med")
                 {
                     var newNewsItem = new prtl_news_med()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_meds.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "hec")
                 {
                     var newNewsItem = new prtl_news_hec()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_hecs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "agr")
                 {
                     var newNewsItem = new prtl_news_agr()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_agrs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "art")
                 {
                     var newNewsItem = new prtl_news_art()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_arts.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "law")
                 {
                     var newNewsItem = new prtl_news_law()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_laws.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "com")
                 {
                     var newNewsItem = new prtl_news_com()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_coms.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 //12121212
                 else if (abbr.ToLower() == "ecedu")
                 {
                     var newNewsItem = new prtl_news_ECEDU()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_ECEDUs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                else if (abbr.ToLower() == "media")
                {
                    var newNewsItem = new prtl_news_media()
                    {
                        Owner_ID = ownerid,
                        News_img = filename,
                        News_date = newsdate,
                        currentNews_date = currentdate,
                        Published = published

                    };

                    dc.prtl_news_medias.InsertOnSubmit(newNewsItem);
                    dc.SubmitChanges();
                    e.Values[filteredproperty] = newNewsItem.News_Id;
                }
                 //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var newNewsItem = new prtl_news_AI()
                    {
                        Owner_ID = ownerid,
                        News_img = filename,
                        News_date = newsdate,
                        currentNews_date = currentdate,
                        Published = published

                    };

                    dc.prtl_news_AIs .InsertOnSubmit(newNewsItem);
                    dc.SubmitChanges();
                    e.Values[filteredproperty] = newNewsItem.News_Id;
                }
                //fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var newNewsItem = new prtl_news_dent()
                    {
                        Owner_ID = ownerid,
                        News_img = filename,
                        News_date = newsdate,
                        currentNews_date = currentdate,
                        Published = published

                    };

                    dc.prtl_news_dents.InsertOnSubmit(newNewsItem);
                    dc.SubmitChanges();
                    e.Values[filteredproperty] = newNewsItem.News_Id;
                }
                else if (abbr.ToLower() == "fpe")
                 {
                     var newNewsItem = new prtl_news_fpe()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_fpes.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                     //***********************
                 else if (abbr.ToLower() == "vmed")
                 {
                     var newNewsItem = new prtl_news_VMed()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_VMeds.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "pharm")
                 {
                     var newNewsItem = new prtl_news_Pharm()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_Pharms.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                     //*******************************
                 else if (abbr.ToLower() == "liv")
                 {
                     var newNewsItem = new prtl_news_liv()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_livs.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "fa")
                 {
                     var newNewsItem = new prtl_news_fa()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_fas.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else if (abbr.ToLower() == "ho")
                 {
                     var newNewsItem = new prtl_news_ho()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published

                     };

                     dc.prtl_news_hos.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
                 else
                 {
                     var newNewsItem = new prtl_New()
                     {
                         Owner_ID = ownerid,
                         News_img = filename,
                         News_date = newsdate,
                         currentNews_date = currentdate,
                         Published = published,
                         IsFeatured = Featured

                     };

                     dc.prtl_News.InsertOnSubmit(newNewsItem);
                     dc.SubmitChanges();
                     e.Values[filteredproperty] = newNewsItem.News_Id;
                 }
            }
        }

        public static string UpdateNewsItem(string News_Id, string imagefilename, DateTime news_date,string abbr)
        {
            var oldname = "";
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var newsitem = dc.prtl_news_univs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }

                else if (abbr.ToLower() == "fci")
                {
                    var newsitem = dc.prtl_news_fcis.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fee")
                {
                    var newsitem = dc.prtl_news_fees.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var newsitem = dc.prtl_news_engs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var newsitem = dc.prtl_news_nurs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var newsitem = dc.prtl_news_edus.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var newsitem = dc.prtl_news_scis.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var newsitem = dc.prtl_news_edvs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var newsitem = dc.prtl_news_agrs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var newsitem = dc.prtl_news_hecs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var newsitem = dc.prtl_news_laws.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var newsitem = dc.prtl_news_fpes.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                    //*********************
                else if (abbr.ToLower() == "pharm")
                {
                    var newsitem = dc.prtl_news_Pharms.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var newsitem = dc.prtl_news_VMeds.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                    //*************************
                else if (abbr.ToLower() == "fa")
                {
                    var newsitem = dc.prtl_news_fas.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "art")
                {
                    var newsitem = dc.prtl_news_arts.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var newsitem = dc.prtl_news_hos.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var newsitem = dc.prtl_news_meds.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var newsitem = dc.prtl_news_livs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var newsitem = dc.prtl_news_coms.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var newsitem = dc.prtl_news_ECEDUs.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "media")
                {
                    var newsitem = dc.prtl_news_medias.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var newsitem = dc.prtl_news_AIs .Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                //fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var newsitem = dc.prtl_news_dents.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
                else
                {
                    var newsitem = dc.prtl_News.Single(n => n.News_Id.ToString() == News_Id);
                    newsitem.News_date = news_date;
                    if (!string.IsNullOrEmpty(imagefilename))
                    {
                        oldname = newsitem.News_img;
                        newsitem.News_img = imagefilename;
                    }

                    dc.SubmitChanges();
                }
            }
            return oldname;
        }
        public static void UpdateNewsItemWithPublish(int NewsID, bool Published,string abbr,bool Featured)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var NewsItem = dc.prtl_news_univs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    NewsItem.IsFeatured = Featured;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fci")
                {
                    var NewsItem = dc.prtl_news_fcis.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fee")
                {
                    var NewsItem = dc.prtl_news_fees.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "eng")
                {
                    var NewsItem = dc.prtl_news_engs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "nur")
                {
                    var NewsItem = dc.prtl_news_nurs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edu")
                {
                    var NewsItem = dc.prtl_news_edus.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "sci")
                {
                    var NewsItem = dc.prtl_news_scis.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "edv")
                {
                    var NewsItem = dc.prtl_news_edvs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "agr")
                {
                    var NewsItem = dc.prtl_news_agrs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "hec")
                {
                    var NewsItem = dc.prtl_news_hecs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "law")
                {
                    var NewsItem = dc.prtl_news_laws.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var NewsItem = dc.prtl_news_fpes.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                    //***************
                else if (abbr.ToLower() == "vmed")
                {
                    var NewsItem = dc.prtl_news_VMeds.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var NewsItem = dc.prtl_news_Pharms.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                    //**************************
                else if (abbr.ToLower() == "fa")
                {
                    var NewsItem = dc.prtl_news_fas.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "art")
                {
                    var NewsItem = dc.prtl_news_arts.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "ho")
                {
                    var NewsItem = dc.prtl_news_hos.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "med")
                {
                    var NewsItem = dc.prtl_news_meds.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "liv")
                {
                    var NewsItem = dc.prtl_news_livs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "com")
                {
                    var NewsItem = dc.prtl_news_coms.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var NewsItem = dc.prtl_news_ECEDUs.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else if (abbr.ToLower() == "media")
                {
                    var NewsItem = dc.prtl_news_medias.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var NewsItem = dc.prtl_news_AIs .Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                //fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var NewsItem = dc.prtl_news_dents.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    dc.SubmitChanges();
                }
                else
                {
                    var NewsItem = dc.prtl_News.Single(a => a.News_Id == NewsID);
                    NewsItem.Published = Published;
                    NewsItem.IsFeatured = Featured;
                    dc.SubmitChanges();
                }
            }
        }
        public static bool GetPublishedState(string ID,string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                
                if (abbr == null)
                {
                    var q = dc.prtl_news_univs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_fcis.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_fees.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_engs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_nurs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_edus.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_scis.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_edvs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_agrs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_hecs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_laws.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_fpes.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                    //**********************
                else if (abbr.ToLower() == "vmed")
                {
                    var q = dc.prtl_news_VMeds.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (abbr.ToLower() == "pharm")
                {
                    var q = dc.prtl_news_Pharms.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }//**********************
                else if (abbr.ToLower() == "fa")
                {
                    var q = dc.prtl_news_fas.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_arts.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_hos.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_meds.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_livs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_coms.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                    var q = dc.prtl_news_ECEDUs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var q = dc.prtl_news_AIs.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
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
                //    var q = dc.prtl_news_coms.SingleOrDefault(x => x.News_Id.ToString() == ID);
                //    if (q != null && q.Published == true)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var q = dc.prtl_news_dents.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    var q = dc.prtl_News.SingleOrDefault(x => x.News_Id.ToString() == ID);
                    if (q != null && q.Published == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }


        public static bool GetCheckedByIDAbbr(object id, string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var NewsItem = dc.prtl_news_univs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                    
                }
                else if (abbr.ToLower() == "fci")
                {
                    var NewsItem = dc.prtl_news_fcis.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "fee")
                {
                    var NewsItem = dc.prtl_news_fees.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "eng")
                {
                    var NewsItem = dc.prtl_news_engs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "nur")
                {
                    var NewsItem = dc.prtl_news_nurs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "edu")
                {
                    var NewsItem = dc.prtl_news_edus.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "sci")
                {
                    var NewsItem = dc.prtl_news_scis.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "edv")
                {
                    var NewsItem = dc.prtl_news_edvs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "agr")
                {
                    var NewsItem = dc.prtl_news_agrs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "hec")
                {
                    var NewsItem = dc.prtl_news_hecs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "law")
                {
                    var NewsItem = dc.prtl_news_laws.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "fpe")
                {
                    var NewsItem = dc.prtl_news_fpes.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                    //********************
                else if (abbr.ToLower() == "pharm")
                {
                    var NewsItem = dc.prtl_news_Pharms.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "vmed")
                {
                    var NewsItem = dc.prtl_news_VMeds.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                    //*************************
                else if (abbr.ToLower() == "fa")
                {
                    var NewsItem = dc.prtl_news_fas.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "art")
                {
                    var NewsItem = dc.prtl_news_arts.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "ho")
                {
                    var NewsItem = dc.prtl_news_hos.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "med")
                {
                    var NewsItem = dc.prtl_news_meds.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "liv")
                {
                    var NewsItem = dc.prtl_news_livs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "com")
                {
                    var NewsItem = dc.prtl_news_coms.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    var NewsItem = dc.prtl_news_ECEDUs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else if (abbr.ToLower() == "media")
                {
                    var NewsItem = dc.prtl_news_medias.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    var NewsItem = dc.prtl_news_AIs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }//fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    var NewsItem = dc.prtl_news_dents.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
                else
                {
                    var NewsItem = dc.prtl_News.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.Published;
                }
            }
        }

        public static string GetNewsDateByIDAbbr(object id, string abbr,string viewerID)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (viewerID == "NewsViewerControl1")
                {
                    if (abbr == null)
                    {
                        var NewsItem = dc.prtl_news_univs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);

                    }
                    else if (abbr.ToLower() == "fci")
                    {
                        var NewsItem = dc.prtl_news_fcis.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "fee")
                    {
                        var NewsItem = dc.prtl_news_fees.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "eng")
                    {
                        var NewsItem = dc.prtl_news_engs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "nur")
                    {
                        var NewsItem = dc.prtl_news_nurs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "edu")
                    {
                        var NewsItem = dc.prtl_news_edus.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "sci")
                    {
                        var NewsItem = dc.prtl_news_scis.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "edv")
                    {
                        var NewsItem = dc.prtl_news_edvs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "agr")
                    {
                        var NewsItem = dc.prtl_news_agrs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "hec")
                    {
                        var NewsItem = dc.prtl_news_hecs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "law")
                    {
                        var NewsItem = dc.prtl_news_laws.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "fpe")
                    {
                        var NewsItem = dc.prtl_news_fpes.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    //****************
                    else if (abbr.ToLower() == "pharm")
                    {
                        var NewsItem = dc.prtl_news_Pharms.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "vmed")
                    {
                        var NewsItem = dc.prtl_news_VMeds.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    //////////////////////
                    else if (abbr.ToLower() == "fa")
                    {
                        var NewsItem = dc.prtl_news_fas.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "art")
                    {
                        var NewsItem = dc.prtl_news_arts.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "ho")
                    {
                        var NewsItem = dc.prtl_news_hos.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "med")
                    {
                        var NewsItem = dc.prtl_news_meds.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "liv")
                    {
                        var NewsItem = dc.prtl_news_livs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "com")
                    {
                        var NewsItem = dc.prtl_news_coms.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                    //12121212
                    else if (abbr.ToLower() == "ecedu")
                    {
                        var NewsItem = dc.prtl_news_ECEDUs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime)NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "media")
                    {
                        var NewsItem = dc.prtl_news_medias.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime)NewsItem.News_date);
                    }
                    else if (abbr.ToLower() == "ai")
                    {
                        var NewsItem = dc.prtl_news_AIs.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime)NewsItem.News_date);
                    }//fatma 6-6-2022
                    else if (abbr.ToLower() == "dent")
                    {
                        var NewsItem = dc.prtl_news_dents.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime)NewsItem.News_date);
                    }
                    else
                    {
                        var NewsItem = dc.prtl_News.Single(a => a.News_Id == Convert.ToInt32(id));
                        return StaticUtilities.FormatDate((DateTime) NewsItem.News_date);
                    }
                }
                else 
                {
                    var NewsItem = dc.prtl_News.Single(a => a.News_Id == Convert.ToInt32(id));
                    return StaticUtilities.FormatDate((DateTime)NewsItem.News_date);
                }
            }
        }

        public static object GetfacNewsByID(int ID, string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    return new PortalDataContextDataContext().prtl_news_univs.SingleOrDefault(x => x.News_Id == ID);

                }
                else if (abbr.ToLower() == "fci")
                {
                    return new PortalDataContextDataContext().prtl_news_fcis.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "fee")
                {
                    return new PortalDataContextDataContext().prtl_news_fees.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "eng")
                {
                    return new PortalDataContextDataContext().prtl_news_engs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "nur")
                {
                    return new PortalDataContextDataContext().prtl_news_nurs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "edu")
                {
                    return new PortalDataContextDataContext().prtl_news_edus.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "sci")
                {
                    return new PortalDataContextDataContext().prtl_news_scis.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "edv")
                {
                    return new PortalDataContextDataContext().prtl_news_edvs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "agr")
                {
                    return new PortalDataContextDataContext().prtl_news_agrs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "hec")
                {
                    return new PortalDataContextDataContext().prtl_news_hecs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "law")
                {
                    return new PortalDataContextDataContext().prtl_news_laws.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "fpe")
                {
                    return new PortalDataContextDataContext().prtl_news_fpes.SingleOrDefault(x => x.News_Id == ID);
                }
                    //*****************
                else if (abbr.ToLower() == "pharm")
                {
                    return new PortalDataContextDataContext().prtl_news_Pharms.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "vmed")
                {
                    return new PortalDataContextDataContext().prtl_news_VMeds.SingleOrDefault(x => x.News_Id == ID);
                }
                    ///*************************
                else if (abbr.ToLower() == "fa")
                {
                    return new PortalDataContextDataContext().prtl_news_fas.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "art")
                {
                    return new PortalDataContextDataContext().prtl_news_arts.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "ho")
                {
                    return new PortalDataContextDataContext().prtl_news_hos.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "med")
                {
                    return new PortalDataContextDataContext().prtl_news_meds.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "liv")
                {
                    return new PortalDataContextDataContext().prtl_news_livs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "com")
                {
                    return new PortalDataContextDataContext().prtl_news_coms.SingleOrDefault(x => x.News_Id == ID);
                }
                //12121212
                else if (abbr.ToLower() == "ecedu")
                {
                    return new PortalDataContextDataContext().prtl_news_ECEDUs.SingleOrDefault(x => x.News_Id == ID);
                }
                else if (abbr.ToLower() == "media")
                {
                    return new PortalDataContextDataContext().prtl_news_medias.SingleOrDefault(x => x.News_Id == ID);
                }
                //14-4-2022
                else if (abbr.ToLower() == "ai")
                {
                    return new PortalDataContextDataContext().prtl_news_AIs.SingleOrDefault(x => x.News_Id == ID);
                }//fatma 6-6-2022
                else if (abbr.ToLower() == "dent")
                {
                    return new PortalDataContextDataContext().prtl_news_dents.SingleOrDefault(x => x.News_Id == ID);
                }
                else
                {
                    return new PortalDataContextDataContext().prtl_News.SingleOrDefault(x => x.News_Id == ID);
                }
            }
        }


        public static bool Get_Is_Featured_CheckedByIDAbbr(object id, string abbr)
        {
            var dc = new PortalDataContextDataContext();
            {
                if (abbr == null)
                {
                    var NewsItem = dc.prtl_news_univs.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.IsFeatured;

                }
                
                else if (StaticUtilities.GetOwnerType(abbr) == OwnerTypes.Sectors)
                {
                    var NewsItem = dc.prtl_News.Single(a => a.News_Id == Convert.ToInt32(id));
                    return NewsItem.IsFeatured;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}