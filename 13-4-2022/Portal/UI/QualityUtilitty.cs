using Portal_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MnfUniversity_Portals.UI
{
    public class QualityUtilitty
    {
        public static void InsertUnitMenu(Page page)
        {

            var dc = new PortalDataContextDataContext();
            var q1 = (from x in dc.prtl_Owners where x.Type == 7 && x.Parent_Id == 4659 select x).ToList();
        
            
            foreach (var prtlOwner in q1)
            {

                prtl_Menu menu = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 1,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu);
                dc.SubmitChanges();

                prtl_Translation menutranslation = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu.Translation_ID,
                    Translation_Data = "قطاعات الكلية"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation);
                dc.SubmitChanges();
                prtl_Translation menutranslation2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu.Translation_ID,
                    Translation_Data = "Sectors of Faculty"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation2);
                dc.SubmitChanges();



                prtl_Menu menu2 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 2,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu2);
                dc.SubmitChanges();

                prtl_Translation menutranslationn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu2.Translation_ID,
                    Translation_Data = "ادارة الوحدة"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn);
                dc.SubmitChanges();
                prtl_Translation menutranslationn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu2.Translation_ID,
                    Translation_Data = "Management Unit"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn2);
                dc.SubmitChanges();


                prtl_Menu menu3 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 3,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu3);
                dc.SubmitChanges();

                prtl_Translation menutranslationnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu3.Translation_ID,
                    Translation_Data = "المشروع"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu3.Translation_ID,
                    Translation_Data = "project"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn2);
                dc.SubmitChanges();


                prtl_Menu menu4 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 4,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu4);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu4.Translation_ID,
                    Translation_Data = "تقارير ومطبوعات"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu4.Translation_ID,
                    Translation_Data = "Reports and Publications"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn2);
                dc.SubmitChanges();

                prtl_Menu menu5 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 5,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu5);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnnn = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu5.Translation_ID,
                    Translation_Data = "الطلاب"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnnn2 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu5.Translation_ID,
                    Translation_Data = "student"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn2);
                dc.SubmitChanges();






                prtl_Menu menu0 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 6,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu0);
                dc.SubmitChanges();

                prtl_Translation menutranslation0 = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu0.Translation_ID,
                    Translation_Data = "الوحدة والجودة خارجيا"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation0);
                dc.SubmitChanges();
                prtl_Translation menutranslation20 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu0.Translation_ID,
                    Translation_Data = "Unity and quality externally"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslation20);
                dc.SubmitChanges();



                prtl_Menu menu20 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 7,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu20);
                dc.SubmitChanges();

                prtl_Translation menutranslationn0 = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu20.Translation_ID,
                    Translation_Data = "اعضاء هيئة التدريس"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn0);
                dc.SubmitChanges();
                prtl_Translation menutranslationn20 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu20.Translation_ID,
                    Translation_Data = "Staff"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationn20);
                dc.SubmitChanges();


                prtl_Menu menu30 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 8,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu30);
                dc.SubmitChanges();

                prtl_Translation menutranslationnn0 = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu30.Translation_ID,
                    Translation_Data = "ألبرامج الدراسية"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn0);
                dc.SubmitChanges();
                prtl_Translation menutranslationnn20 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu30.Translation_ID,
                    Translation_Data = "Subjects"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnn20);
                dc.SubmitChanges();


                prtl_Menu menu40 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 9,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "Vertical",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu40);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnn0 = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu40.Translation_ID,
                    Translation_Data = "انشطة الوحدة"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn0);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnn20 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu40.Translation_ID,
                    Translation_Data = "Units Activities"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnn20);
                dc.SubmitChanges();

                prtl_Menu menu50 = new prtl_Menu()
                {
                    Parent_id = null,
                    Order = 10,
                    Url = null,
                    Url_target = null,
                    Owner_ID = prtlOwner.Owner_ID,
                    Position = "top",
                    Roles = "All",
                    Parameters = null,
                    Published = true

                };
                dc.prtl_Menus.InsertOnSubmit(menu50);
                dc.SubmitChanges();

                prtl_Translation menutranslationnnnn0 = new prtl_Translation()
                {
                    Lang_Id = 1,
                    Translation_ID = menu50.Translation_ID,
                    Translation_Data = "تواصل معنا"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn0);
                dc.SubmitChanges();
                prtl_Translation menutranslationnnnn20 = new prtl_Translation()
                {
                    Lang_Id = 2,
                    Translation_ID = menu50.Translation_ID,
                    Translation_Data = "Contact Us"

                };
                dc.prtl_Translations.InsertOnSubmit(menutranslationnnnn20);
                dc.SubmitChanges();


            }
        }

    }
}