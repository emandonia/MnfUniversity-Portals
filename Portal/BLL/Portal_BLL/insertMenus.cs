using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MisBLL;
using MnfUniversity_Portals.BLL.Portal_BLL;
using AjaxControlToolkit;
using App_Code;
 
 
using MnfUniversity_Portals.BLL.Portal_BLL;
using System.Web.Security;
using Portal_DAL;

namespace MnfUniversity_Portals.BLL.Portal_BLL
{
    public class insertMenus
    {

        public static void insertpostProgramMenu(Page page)
        {
            var dc = new PortalDataContextDataContext();

            #region
            List<prtl_Owner> o = (from cc in dc.prtl_Owners where cc.Type == 14   select cc).ToList();

            foreach (var c in o)
            {
                var menuitem1 = new prtl_Menu
                {
                    
                    Roles = "All",
                    Position = "Vertical",
                    Published = true,
                    Order = 1,
                    Owner_ID = c.Owner_ID
                };

                dc.prtl_Menus.InsertOnSubmit(menuitem1);
                dc.SubmitChanges();


                var menutranslations01 = new prtl_Translation();

                menutranslations01.Translation_Data = "الرؤية";
                menutranslations01.Lang_Id = 1;
                menutranslations01.Translation_ID = menuitem1.Translation_ID;


                dc.prtl_Translations.InsertOnSubmit(menutranslations01);
                dc.SubmitChanges();

                prtl_Translation menutranslations1 = new prtl_Translation();

                menutranslations1.Translation_Data = "Vision";
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

                menutranslations02.Translation_Data = "الرسالة";
                menutranslations02.Lang_Id = 1;
                menutranslations02.Translation_ID = menuitem2.Translation_ID;

                dc.prtl_Translations.InsertOnSubmit(menutranslations02);
                dc.SubmitChanges();

                prtl_Translation menutranslations2 = new prtl_Translation();

                menutranslations2.Translation_Data = "Mission";
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

                menutranslations03.Translation_Data = "الأهداف";
                menutranslations03.Lang_Id = 1;
                menutranslations03.Translation_ID = menuitem3.Translation_ID;

                dc.prtl_Translations.InsertOnSubmit(menutranslations03);
                dc.SubmitChanges();

                prtl_Translation menutranslations3 = new prtl_Translation();

                menutranslations3.Translation_Data = "Goals";
                menutranslations3.Lang_Id = 2;
                menutranslations3.Translation_ID = menuitem3.Translation_ID;

                dc.prtl_Translations.InsertOnSubmit(menutranslations3);
                dc.SubmitChanges();



                  dc.prtl_Menus.InsertOnSubmit(menuitem3);
                dc.SubmitChanges();




                 prtl_Menu menuitem4 = new prtl_Menu();

                 
                menuitem4.Roles = "All";
                menuitem4.Position = "Vertical";
                menuitem4.Published = true;
                menuitem4.Order = 4;
                menuitem4.Owner_ID = c.Owner_ID;
                menuitem4.Url = "http://http://mu.menofia.edu.eg/" + URLBuilder.CurrentOwnerAbbr(page.RouteData) + "/" + StaticUtilities.Currentlanguage(page);


                dc.prtl_Menus.InsertOnSubmit(menuitem3);
                dc.SubmitChanges();


                prtl_Translation menutranslations04 = new prtl_Translation();

                menutranslations04.Translation_Data = "المقررات";
                menutranslations04.Lang_Id = 1;
                menutranslations04.Translation_ID = menuitem4.Translation_ID;

                dc.prtl_Translations.InsertOnSubmit(menutranslations04);
                dc.SubmitChanges();

                prtl_Translation menutranslations4 = new prtl_Translation();

                menutranslations4.Translation_Data = "Subjects";
                menutranslations4.Lang_Id = 2;
                menutranslations4.Translation_ID = menuitem4.Translation_ID;

                dc.prtl_Translations.InsertOnSubmit(menutranslations4);
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


            //////////            var dc = new PortalDataContextDataContext()


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
            //////////            var dc1 = new PortalDataContextDataContext()
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

         //protected   string getUrl()
         //{

         //   string uniabbr = "http://" + Request.Url.Authority;
         //   var currentowner = URLBuilder.CurrentOwnerAbbr(Page.RouteData);

         //   var lang = StaticUtilities.Currentlanguage(RouteData);

         //    string url = uniabbr + "/" + currentowner +  "/PostProgSubjects/" + lang;
         //    return url;
         //}

    }
}