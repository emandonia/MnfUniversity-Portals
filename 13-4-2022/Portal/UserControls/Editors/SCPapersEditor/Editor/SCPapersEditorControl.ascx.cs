using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Editors.SCPapersEditor.Editor
{
    public partial class SCPapersEditorControl : ListViewBasedUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //EditorListView.DataSource = SPapersLinqDataSource2;
                //EditorListView.DataBind();
            }

        }

        protected override string DetailsViewBasedName
        {
            get { return "SCPapersDetailsViewControl"; }
        }


        protected override string FilterSessionName
        {
            get { return "SPapersOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "SPapersLinqDataSource"; }
        }

        public override void UpdateListItem(ListViewItem listViewItem)
        {
            base.UpdateListItem(listViewItem);

        }

        protected void SPapersEditorControl_insertClicked(object sender, EventArgs e)
        {
            SCPapersDetailsViewControl.ShowInsert(StaticUtilities.OwnerID(Page));

        }


        protected void SPapersEditorControl_DataBound(object sender,EventArgs e)
        {
            EditorListView.DataBind();
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            
        }

        protected override int TranslationCount(object data, [Optional] string abbr)
        {
            return 2;
        }

        protected override bool Published(object data, [Optional] string abbr)
        {
            return false;
        }

        #region ImagesURL Properties

         

        protected override string ListViewName
        {
            get { return "EditorListView"; }
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, [Optional] string abbr)
        {
            return Prtl_TranslationUtility.LangsNotTranslated(CurrentTranslationID, ((prtl_Highlight)data).Translation_ID.ToString());
        }

        #endregion ImagesURL Properties

        protected void SearchTypeDropDownList_IndexChanged(object sender, EventArgs e)
        {
            //if (SearchDropDown.SelectedValue != "-1")
            //{

            //    Guid x =new Guid(  );
            //    x = (Guid)Session["SPapersOwner_ID"];
            //    //ResearchType ==" + SearchDropDown.SelectedValue + " &&
            //    SPapersLinqDataSource2.Where = " FacultyTable.Prtl_FacOwnerID ==" +x;
            //  //  SPapersLinqDataSource2.Where = "FacultyTable.Prtl_FacOwnerID ==" + Session["SPapersOwner_ID"];
            //    EditorListView.DataSourceID = null;
            //    EditorListView.DataSource = SPapersLinqDataSource2;
            //    EditorListView.DataBind();
            //    //+" && ResearchType ==" + SearchDropDown.SelectedValue; ;

            //   // Session["SelectDrop"] = SearchDropDown.SelectedValue;
            //}
            //else
            //{
                
            //}



        }

        
      
        
    }
}