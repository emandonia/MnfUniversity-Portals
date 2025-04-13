using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using CKEditor.NET;
using MnfUniversity_Portals.UserControls.Editors.MenuEditor;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.ThesisEditor.Details
{
    public partial class ThesisDetailsViewUserControl : DetailsViewBasedUserControl
    {
        protected override string DefaultValueForFiltering
        {
            get { return "0"; }
        }

        protected override string FilterValueName
        {
            get { return "ThesisTranslation_ID"; }
        }

        public override string EditorClientID
        {
            get
            {
                return "";
            }
            
        }


        //private DataControlField EditorField
        //{
        //    get { return EditorDetailsView.Fields[12]; }
        //}
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           // EditorField.HeaderText = GetPreViewHeaderText();
        }
    

       

        private string InsertPrimaryKey
        {
            get { return "Thesis_ID"; }
        }

        //protected override void DataBound(object sender, EventArgs e)
        //{
        //    var headers = new[]
        //    {
        //        GetLocalResourceObject("Reg_date.HeaderText"), GetLocalResourceObject("diss_date.HeaderText"),
        //        GetLocalResourceObject("Thesis_Status.HeaderText"), GetLocalResourceObject("ThesisType.HeaderText"),
        //        GetLocalResourceObject("file.HeaderText")
        //    };
        //    foreach (
        //        var field in
        //            EditorDetailsView.Fields.Cast<DataControlField>().Where(field => headers.Contains(field.HeaderText))
        //        )
        //    {
        //        field.Visible = EditorDetailsView.CurrentMode == DetailsViewMode.Edit || Mode == DetailsViewMode.Insert;
        //    }
        //}

        //}
        //protected override void ModeChanging(DetailsView sender, DetailsViewModeEventArgs e)
        //{
        //    SetFieldsVisibility(e.NewMode);
        //}
        protected override IEnumerable<Portal_DAL.prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_ThesisTranslationUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }

       

        protected override void ItemInserting(DetailsView detailsView, DetailsViewInsertEventArgs e)
        {
            int Thesisid = 0;
            if (Mode == DetailsViewMode.Insert)
            {

                TextBox txtStudentName = detailsView.GetControl<TextBox>("txtStudentName");
                TextBox txtAddress = detailsView.GetControl<TextBox>("txtAddress");
                bool xx = false;
                RadioButton RadioButton01 = detailsView.GetControl<RadioButton>("RadioButton01");
                RadioButton RadioButton02 = detailsView.GetControl<RadioButton>("RadioButton02");
                RadioButtonList RadioButtonList1 = detailsView.GetControl<RadioButtonList>("RadioButtonList1");
                TextBox RegistrationDate = detailsView.GetControl<TextBox>("Registration");
                TextBox DisscusionDate = detailsView.GetControl<TextBox>("DisscusionDate");
                RadioButton RadioButton1 = detailsView.GetControl<RadioButton>("RadioButton1");
                RadioButton RadioButton2 = detailsView.GetControl<RadioButton>("RadioButton2");

                TextBox txtExaminers = detailsView.GetControl<TextBox>("txtExaminers");
                TextBox txtExaminers1 = detailsView.GetControl<TextBox>("txtExaminers1");
                TextBox txtExaminers2 = detailsView.GetControl<TextBox>("txtExaminers2");
                TextBox txtExaminers3 = detailsView.GetControl<TextBox>("txtExaminers3");
                TextBox txtExaminers4 = detailsView.GetControl<TextBox>("txtExaminers4");

                List<string> Examiners = new List<string>();

                TextBox txtSuper = detailsView.GetControl<TextBox>("txtSuper");
                TextBox txtSuper1 = detailsView.GetControl<TextBox>("txtSuper1");
                TextBox txtSuper2 = detailsView.GetControl<TextBox>("txtSuper2");
                TextBox txtSuper3 = detailsView.GetControl<TextBox>("txtSuper3");
                TextBox txtSuper4 = detailsView.GetControl<TextBox>("txtSuper4");


                CustomEditor c1 = detailsView.GetControl<CustomEditor>("txtActualContent2");
                CustomEditor c2 = detailsView.GetControl<CustomEditor>("txtSummary");
                TextBox c3 = detailsView.GetControl<TextBox>("txtSpecialisim");





                string x = upload(detailsView);
                Thesisid = prtl_ThesisUtility.insertThesis(e, InsertPrimaryKey,CurrentOwnerID.Value,
                                                              !Convert.ToBoolean( RadioButtonList1.SelectedValue) , 
                                                               StaticUtilities.ExtractDate(RegistrationDate.Text), 
                                                               RadioButton1 .Checked ,
                                                               StaticUtilities.ExtractDate(DisscusionDate.Text),StaticUtilities .Currentlanguage(Page),
                                                               txtStudentName.Text ,
                                                              txtAddress.Text ,
                                                              c2.Text,
                                                             c3.Text ,
                                                             c1.Text ,x);
            int supervisiorID=prtl_ThesisUtility.insertSuperVisor(txtSuper.Text);   
                      prtl_ThesisUtility .insertMapSuperVisor(Thesisid,supervisiorID);

            int supervisiorID1= prtl_ThesisUtility.insertSuperVisor(txtSuper1.Text);
                      prtl_ThesisUtility .insertMapSuperVisor(Thesisid,supervisiorID1);

                int supervisiorID2=prtl_ThesisUtility.insertSuperVisor(txtSuper2.Text);
                      prtl_ThesisUtility .insertMapSuperVisor(Thesisid,supervisiorID2);


                 // if (txtSuper3.Text != "")
                 int supervisiorID3=prtl_ThesisUtility.insertSuperVisor(txtSuper3.Text);
                      prtl_ThesisUtility .insertMapSuperVisor(Thesisid,supervisiorID3);


                 // if (txtSuper4.Text != "") 
                  int supervisiorID4= prtl_ThesisUtility.insertSuperVisor(txtSuper4.Text);
                      prtl_ThesisUtility.insertMapSuperVisor(Thesisid,supervisiorID4); 

                  //  if (txtExaminers.Text != "")
                    
                      int superID=  prtl_ThesisUtility.insertSuper(txtExaminers.Text) ;
                        
                        
                        prtl_ThesisUtility .insertMapSuper(Thesisid,superID);
                 // if (txtExaminers1.Text != "")
                   int superID1= prtl_ThesisUtility.insertSuper(txtExaminers1.Text);
                      prtl_ThesisUtility .insertMapSuper(Thesisid,superID1);
                 // if (txtExaminers2.Text != "")
                    int superID2= prtl_ThesisUtility.insertSuper(txtExaminers2.Text);
                      prtl_ThesisUtility .insertMapSuper(Thesisid,superID2);
                //  if (txtExaminers3.Text != "")
                  int superID3=prtl_ThesisUtility.insertSuper(txtExaminers3.Text);
                  prtl_ThesisUtility.insertMapSuper(Thesisid, superID3);
                  
                  //if (txtExaminers4.Text != "") 
                  int superID4=prtl_ThesisUtility.insertSuper(txtExaminers4.Text);
                      prtl_ThesisUtility .insertMapSuper(Thesisid,superID4);

         

            }
           
            
            
            else
            {
                e.Values[InsertPrimaryKey] = FilterValue;

                //detailsView.ChangeMode(DetailsViewMode.Insert);

                //HiddenField Thesis_ID2 = detailsView.GetControl<HiddenField>("Thesis_ID2");

                TextBox txtStudentName = detailsView.GetControl<TextBox>("txtStudentName");
                TextBox txtAddress = detailsView.GetControl<TextBox>("txtAddress");



                TextBox txtExaminers = detailsView.GetControl<TextBox>("txtExaminers");
                TextBox txtExaminers1 = detailsView.GetControl<TextBox>("txtExaminers1");
                TextBox txtExaminers2 = detailsView.GetControl<TextBox>("txtExaminers2");
                TextBox txtExaminers3 = detailsView.GetControl<TextBox>("txtExaminers3");
                TextBox txtExaminers4 = detailsView.GetControl<TextBox>("txtExaminers4");

                TextBox txtSuper = detailsView.GetControl<TextBox>("txtSuper");
                TextBox txtSuper1 = detailsView.GetControl<TextBox>("txtSuper1");
                TextBox txtSuper2 = detailsView.GetControl<TextBox>("txtSuper2");
                TextBox txtSuper3 = detailsView.GetControl<TextBox>("txtSuper3");
                TextBox txtSuper4 = detailsView.GetControl<TextBox>("txtSuper4");


                CustomEditor c1 = detailsView.GetControl<CustomEditor>("txtActualContent2");
                CustomEditor c2 = detailsView.GetControl<CustomEditor>("txtSummary");
                TextBox c3 = detailsView.GetControl<TextBox>("txtSpecialisim");

                //prtl_ThesisUtility.insertThesisTrans(Convert.ToInt32(FilterValue), 2,
                //                                              txtStudentName.Text,
                //                                             txtAddress.Text,
                //                                             c2.Text,
                //                                            c3.Text,
                //                                            c1.Text);

                InsertENSuper(Convert.ToInt32(FilterValue), txtSuper.Text, txtSuper1.Text, txtSuper2.Text, txtSuper3.Text, txtSuper4.Text);
                insertENSupervisor(Convert.ToInt32(FilterValue), txtExaminers.Text, txtExaminers1.Text, txtExaminers2.Text, txtExaminers3.Text, txtExaminers4.Text);

        

            }
            var langddl = GetDVControl<DropDownList>("LangDropDownList");
            e.Values["Lang_id"] = langddl.SelectedValue;
            //e.Values["Thesis_ID"] = Thesisid;
            

        }


        protected string upload(DetailsView detailsView)
        {
            string file = "";
            AsyncFileUpload f = (AsyncFileUpload)detailsView.FindControl("AsyncFileUpload1");
            if (f.HasFile)
            {
               
                string s = URLBuilder.GetURLIfExists3(Page, SiteFolders.Thesis, f.FileName ,null);

                StaticUtilities.UploadFile3(detailsView, "AsyncFileUpload1", SiteFolders.Thesis);
               
            }
            return f.FileName;
        }


        //public override void Show(Guid? currentOwnerID, string filterValue, DetailsViewMode EditMode = DetailsViewMode.ReadOnly)
        //{
        //    base.Show(currentOwnerID, filterValue, EditMode);
        //    SetFieldsVisibility(EditorDetailsView.CurrentMode);
        //}

        //internal override void ShowInsert(Guid? currentOwnerID, string defaultempty = null)
        //{
        //    base.ShowInsert(currentOwnerID, defaultempty);
        //    SetFieldsVisibility(EditorDetailsView.CurrentMode);
        //}

        //private void SetFieldsVisibility(DetailsViewMode mode)
        //{

        //    var viewall = Mode != DetailsViewMode.Insert && mode == DetailsViewMode.Insert;
        //    var headers = new[] { GetLocalResourceObject("Reg_date.HeaderText"), GetLocalResourceObject("diss_date.HeaderText"),
        //        GetLocalResourceObject("Thesis_Status.HeaderText"), GetLocalResourceObject("ThesisType.HeaderText"), GetLocalResourceObject("file.HeaderText") };
        //    foreach (var field in EditorDetailsView.Fields.Cast<DataControlField>().Where(field => headers.Contains(field.HeaderText)))
        //    {
        //        field.Visible = !viewall;
        //    }
        //}


        //protected override void ModeChanging(DetailsView sender, DetailsViewModeEventArgs e)
        //{
        //    SetFieldsVisibility(e.NewMode);
        //}


        protected override void ItemUpdating(DetailsView detailsview, DetailsViewUpdateEventArgs e)
        {
                TextBox txtExaminers = detailsview.GetControl<TextBox>("txtExaminers");
                TextBox txtExaminers1 = detailsview.GetControl<TextBox>("txtExaminers1");
                TextBox txtExaminers2 = detailsview.GetControl<TextBox>("txtExaminers2");
                TextBox txtExaminers3 = detailsview.GetControl<TextBox>("txtExaminers3");
                TextBox txtExaminers4 = detailsview.GetControl<TextBox>("txtExaminers4");

                
                TextBox txtSuper = detailsview.GetControl<TextBox>("txtSuper");
                TextBox txtSuper1 = detailsview.GetControl<TextBox>("txtSuper1");
                TextBox txtSuper2 = detailsview.GetControl<TextBox>("txtSuper2");
                TextBox txtSuper3 = detailsview.GetControl<TextBox>("txtSuper3");
                TextBox txtSuper4 = detailsview.GetControl<TextBox>("txtSuper4");
              // RadioButton RadioButton01 = detailsview.GetControl<RadioButton>("RadioButton01");
              
              RadioButton RadioButton1 = detailsview.GetControl<RadioButton>("RadioButton1");
           
            RadioButtonList RadioButtonList1 = detailsview.GetControl<RadioButtonList>("RadioButtonList1");
                Label lblThesis_ID = detailsview.GetControl<Label>("lblThesis_ID");


            prtl_ThesisUtility.UpdateSuper(Convert.ToInt32(lblThesis_ID.Text), txtSuper.Text, txtSuper1.Text,
                txtSuper2.Text, txtSuper3.Text, txtSuper4.Text);


            prtl_ThesisUtility.UpdateSupervisor(Convert.ToInt32(lblThesis_ID.Text), txtExaminers.Text, txtExaminers1.Text,
                txtExaminers2.Text, txtExaminers3.Text, txtExaminers4.Text);

            prtl_ThesisUtility.UpdateStudy(Convert.ToInt32(lblThesis_ID.Text), Convert.ToBoolean(RadioButtonList1.SelectedValue));  
            string x = upload(detailsview);
            prtl_ThesisUtility.UpdateRes(Convert.ToInt32(lblThesis_ID.Text), RadioButton1.Checked,x);


          
        }



        protected List<Prtl_ThesisSuper> Get(int thesis)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<int> x =
                    (from c in dc.Prtl_ThesisMapSupers  where c.ThesisId.ToString() == thesis.ToString() select c.SuperId ).ToList();
                List<Prtl_ThesisSuper> su = new List<Prtl_ThesisSuper>();
                foreach (var v in x)
                {
                    su.Add((from d in dc.Prtl_ThesisSupers where d.ID == v select d).SingleOrDefault());
                }
                return su;

            }
        }

        //protected string  getselectValue(string e)
        //{
        //        var dc = new PortalDataContextDataContext();
        //    {
        //        from c in dc.Studytypes where c.StudyId ==Convert .ToInt32( e) select c.StudyType1 
        //    }

        //}
        protected string GetSuper(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupers.Count > 0)
                {
                    return thesisSupers[0].SuperName;
                }
                else
                {
                    return "";
                }

              
            }
        }


        protected void InsertENSuper(int ThesisID, string s0, string s1, string s2, string s3, string s4)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == ThesisID select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }

                thesisSupers[0].SuperNameEn = s0;
                thesisSupers[1].SuperNameEn = s1;
                thesisSupers[2].SuperNameEn = s2;
                thesisSupers[3].SuperNameEn = s3;
                thesisSupers[4].SuperNameEn = s4;

                dc.SubmitChanges();

            }
        }


        protected void insertENSupervisor(int ThesisID, string s0, string s1, string s2, string s3, string s4)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == ThesisID select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }
                thesisSupervisors[0].SuperNameEng = s0;
                thesisSupervisors[1].SuperNameEng= s1;
                thesisSupervisors[2].SuperNameEng= s2;
                thesisSupervisors[3].SuperNameEng= s3;
                thesisSupervisors[4].SuperNameEng= s4;
                                      
                dc.SubmitChanges();

                 
            }
        }


        protected string GetSupervisor(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupervisors.Count > 0)
                {
                    return thesisSupervisors[0].SuperName;
                }
                else
                {
                    return "";
                }
            }
        }
        protected string GetSupervisor1(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupervisors.Count > 1)
                {
                    return thesisSupervisors[1].SuperName;
                }
                else
                {
                    return "";
                }
            }
        }
        protected string GetSupervisor2(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupervisors.Count > 2)
                {
                    return thesisSupervisors[2].SuperName;
                }
                else
                {
                    return "";
                }
            }
        }
        protected string GetSupervisor3(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupervisors.Count > 3)
                {
                    return thesisSupervisors[3].SuperName;
                }
                else
                {
                    return "";
                }
            }
        }
        protected string GetSupervisor4(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSupervisor> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupervisors where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSUPERVISOR> thesisSupervisors = new List<Prtl_ThesisSUPERVISOR>();
                foreach (Prtl_ThesisMapSupervisor c in mapSupers)
                {
                    thesisSupervisors.Add(
                        (from c1 in dc.Prtl_ThesisSUPERVISORs where c1.SuperId == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupervisors.Count > 4)
                {
                    return thesisSupervisors[4].SuperName;
                }
                else
                {
                    return "";
                }
            }
        }


        protected string GetSuper1(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }
                if (thesisSupers.Count > 1)
                {
                    return thesisSupers[1].SuperName;
                }
                else
                {
                     return "" ;
                }
               
            }
        }



        protected string GetSuper2(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupers.Count > 2)
                {
                    return thesisSupers[2].SuperName;
                }
                else
                {
                    return "";
                }
              
            }
        }



        protected string GetSuper3(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupers.Count > 3)
                {
                    return thesisSupers[3].SuperName;
                }
                else
                {
                    return "";
                }
                 
            }
        }


        protected string GetSuper4(object eval)
        {
            var dc = new PortalDataContextDataContext();
            {
                List<Prtl_ThesisMapSuper> mapSupers =
                    (from x in dc.Prtl_ThesisMapSupers where x.ThesisId == Convert.ToInt32(eval) select x).ToList();

                List<Prtl_ThesisSuper> thesisSupers = new List<Prtl_ThesisSuper>();
                foreach (Prtl_ThesisMapSuper c in mapSupers)
                {
                    thesisSupers.Add(
                        (from c1 in dc.Prtl_ThesisSupers where c1.ID == c.SuperId select c1).SingleOrDefault());
                }

                if (thesisSupers.Count > 4)
                {
                    return thesisSupers[4].SuperName;
                }
                else
                {
                    return "";
                }

                 
            }
        }

        protected bool GetCheck2(object eval)
        {
            return (! Convert.ToBoolean(eval));
        }

        protected bool GetCheck1(object eval)
        {
            return (!Convert.ToBoolean(eval));
        }

        protected string GetRes(object eval)
        {
            if (Convert.ToBoolean(eval) == true) return "تم مناقشتها";
            else return "لم تتم المناقشة";
        }


        protected string GetStud(object eval)
        {
            if (Convert.ToBoolean(eval) == true){ return "ماجستير";}
            else {return "دكتوراه";}
        }


        protected override int TranslationsCount
        {
            get { return prtl_ThesisUtility.GetCountTranslations(FilterValue); }
        }
    }
            
}