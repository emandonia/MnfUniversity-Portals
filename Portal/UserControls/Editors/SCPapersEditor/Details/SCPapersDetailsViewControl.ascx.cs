using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BLL;
using Common;
using MnfUniversity_Portals.UserControls.Base;
using Portal_DAL;
using CKEditor.NET;

namespace MnfUniversity_Portals.UserControls.Editors.SCPapersEditor.Details
{
    public partial class SCPapersDetailsViewControl : DetailsViewBasedUserControl
    {
        protected override string DefaultValueForFiltering
        {
            get { return "00000000-1000-0000-0000-000000000000"; }
        }

        protected override string FilterValueName
        {
            get { return "factr"; }
        }

        public override string EditorClientID
        {
            get
            {
                return "";
            }
        }

       
        protected override object EditorTitle { get { return GetLocalResourceObject("Title"); } }

      
        private string FilteredProperty
        {
            get { return "FacID"; }
        }

       
        protected override void DataBound(object sender, EventArgs e)
        {
               }


        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            DropDownList Department = EditorDetailsView.GetControl<DropDownList>("DropDownList5");
            DropDownList FacDropDownList = EditorDetailsView.GetControl<DropDownList>("FacDropDownList");
             if (Department != null)
            {
                Department.Items.Clear();
                Guid x = new Guid(FacDropDownList.SelectedValue);
                Prtl_OwnersUtility.getIDByTranslationID(x);
                Department.DataSource = Prtl_OwnersUtility.getDepsOfFac(Prtl_OwnersUtility.getIDByTranslationID(x), StaticUtilities.Currentlanguage(Page));
               
                Department.DataBind();
            }
        }






        protected override IEnumerable<prtl_Language> GetLanguagesNotTranslatedDatasource(string filteringdata)
        {
            // ReSharper disable PossibleInvalidOperationException
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentOwnerID.Value, filteringdata);

            // ReSharper restore PossibleInvalidOperationException
        }

        protected override void ItemInserting(DetailsView detailsView, DetailsViewInsertEventArgs e)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                TextBox InsertStudentAr = detailsView.GetControl<TextBox>("InsertStudentAr");
                TextBox txtStudentEn = detailsView.GetControl<TextBox>("txtStudentEn");


                TextBox ArabicAddress = detailsView.GetControl<TextBox>("ArabicAddress");
                TextBox EngAddress = detailsView.GetControl<TextBox>("EngAddress");
                CustomEditor c = detailsView.GetControl<CustomEditor>("txtActualContent");

                CustomEditor c2 = detailsView.GetControl<CustomEditor>("txtActualContent2");

                DropDownList StudyType1 = detailsView.GetControl<DropDownList>("DropDownList2");
                DropDownList FacDropDownList = detailsView.GetControl<DropDownList>("FacDropDownList");
                 DropDownList DropDownList5 = detailsView.GetControl<DropDownList>("DropDownList5");
                
                TextBox UniDate = detailsView.GetControl<TextBox>("UniDate");
                TextBox RegDate = detailsView.GetControl<TextBox>("RegDate");
                CheckBox CheckBox1 = detailsView.GetControl<CheckBox>("CheckBox1");

                TextBox txtExaminers = detailsView.GetControl<TextBox>("txtExaminers");
                TextBox txtExaminers1 = detailsView.GetControl<TextBox>("txtExaminers1");
                TextBox txtExaminers2 = detailsView.GetControl<TextBox>("txtExaminers2");
                TextBox txtExaminers3 = detailsView.GetControl<TextBox>("txtExaminers3");
                TextBox txtExaminers4 = detailsView.GetControl<TextBox>("txtExaminers4");

                List<string> Examiners = new List<string>();
                if (txtExaminers.Text != null) Examiners.Add(txtExaminers.Text);
                if (txtExaminers1.Text != null) Examiners.Add(txtExaminers1.Text);
                if (txtExaminers2.Text != null) Examiners.Add(txtExaminers2.Text);
                if (txtExaminers3.Text != null) Examiners.Add(txtExaminers3.Text);
                if (txtExaminers4.Text != null) Examiners.Add(txtExaminers4.Text);



                TextBox txtSuper = detailsView.GetControl<TextBox>("txtSuper");
                TextBox txtSuper1 = detailsView.GetControl<TextBox>("txtSuper1");
                TextBox txtSuper2 = detailsView.GetControl<TextBox>("txtSuper2");
                TextBox txtSuper3 = detailsView.GetControl<TextBox>("txtSuper3");
                TextBox txtSuper4 = detailsView.GetControl<TextBox>("txtSuper4");

                List<string> super = new List<string>();
                if (txtSuper.Text !=null ) super.Add(txtSuper.Text);
                if (txtSuper1.Text != null) super.Add(txtSuper1.Text);
                if (txtSuper2.Text != null) super.Add(txtSuper2.Text);
                if (txtSuper3.Text != null) super.Add(txtSuper3.Text);
                if (txtSuper4.Text != null) super.Add(txtSuper4.Text);
                ResearchPlainUtility.InsertNewResearch(InsertStudentAr.Text,
                    txtStudentEn.Text,
                    Prtl_OwnersUtility.getIDByTranslationID(new Guid ( FacDropDownList.SelectedValue)),
                    Convert.ToInt32(StudyType1.SelectedValue)
                    , Prtl_OwnersUtility.getIDByTranslationID(new Guid (DropDownList5.SelectedValue))
                    , StaticUtilities.ExtractDate(UniDate.Text),
                    ArabicAddress.Text
                    , EngAddress.Text ,
                    c.Text ,"",
                    CheckBox1.Checked
                    , ""
                    , "",
                    1,  super
                    , Examiners, StaticUtilities.ExtractDate(RegDate.Text),c2.Text );



                 }
            else
            {
                detailsView.CompleteTranslationData(e, FilterValue);
            }
        }
        protected  void add_DetailsView_ItemInserted(DetailsView detailsView, DetailsViewUpdateEventArgs e)
      {
          
      }

        protected override void ItemUpdating(DetailsView detailsView, DetailsViewUpdateEventArgs e)
        {
           
        }



        protected override int TranslationsCount
        {
            get { return 0; }
        }

        

        protected void DetailsViewBasedControl1_PreRender(object sender, EventArgs e)
        {
           // EditorField.HeaderText = GetPreViewHeaderText();
        }

        protected void viewsuper__(DetailsBasedControlTemplate detailsView)
        {
            if (Mode == DetailsViewMode.Insert)
            {
                CheckBox CheckBox1 = detailsView.GetControl<CheckBox>("CheckBox1");
                if (CheckBox1.Checked )
                {
                    EditorDetailsView.Fields[11].Visible = false;
                }
                else
                {
                    EditorDetailsView.Fields[11].Visible = true;

                }
            }
           
        }
    }
}