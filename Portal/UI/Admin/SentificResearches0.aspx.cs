using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;
using Portal_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class SentificResearches : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = LinqDataSource1;
                GridView1.DataBind();
                Session["datasource"] = LinqDataSource1;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int id = Prtl_OwnersUtility.getStaffIDbyAbbr(URLBuilder.CurrentOwnerAbbr(Page.RouteData));
           int x=   prtl_SecResUtillity.Insert_Stf_Research_Fields(id, txtName.Text, txtCoOuther.Text, txtTitle.Text,
                txtJour.Text, txtVloum.Text, txtNum.Text, txtPagen.Text, txtyear.Text,txtAbstar .Text ,txtAbsten.Text ,  id.ToString( ));


            txtName.Text = "";
            txtCoOuther.Text = "";
            txtTitle.Text = "";
            txtJour.Text = "";
            txtVloum.Text = "";
            txtNum.Text = "";
            txtPagen.Text = "";
            txtyear.Text = "";
            txtAbstar.Text = "";
            txtAbsten.Text = "";

            if (x !=0)
            {

                if (AsyncFileUpload1.HasFile)
                {
                    URLBuilder.GetURLIfExists2(Page, SiteFolders.SentficResearches, AsyncFileUpload1.PostedFile.FileName);
               
                    
                    //string z=    StaticUtilities.UploadFiles(Page, AsyncFileUpload1.PostedFile ,SiteFolders.SentficResearches);       
                    string z = StaticUtilities.UploadFileswithRename(Page, AsyncFileUpload1.PostedFile, SiteFolders.SentficResearches,x.ToString());       
                 
    
                }
            }

            string Where = "Staff_ID ==@StaffID";
            LinqDataSource1.WhereParameters.Add("StaffID",DbType.Int32, id.ToString( ));
          
            LinqDataSource1.Where = Where;
            LinqDataSource1.DataBind();

            GridView1.DataSource = LinqDataSource1;
            GridView1.DataBind();

            Session["datasource"] = LinqDataSource1;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
       {
        //To display the user info in the detailsview in editing mode.
        try
        {

            if (GridView1.SelectedDataKey != null)
            {
                int g =Convert .ToInt32(  GridView1.SelectedDataKey.Value);

                   var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx = (from x in dc.Prtl_SecntificResearches where x.ID   == g select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
              //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
            }
        }
        catch
        {
        }
    }
        public void GetUrl(object id)
        {
            
         
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            //if (GridView1.SelectedDataKey != null)
            //{
            Button Button1 = (Button)GridView1.FindControl("Button1");

                var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx =
                    (from x in dc.Prtl_SecntificResearches where x.ID == Convert .ToInt32( Button1.CommandArgument)  select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
                //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
            }
        //}
        protected void Details_OnClick(object sender, EventArgs e)
        {
             
            LinkButton btnButton = sender as LinkButton;
            GridViewRow gvRow = (GridViewRow)btnButton.NamingContainer;
            LinkButton Details = (LinkButton) gvRow.FindControl("Details");   
               
            
            
            var dc = new PortalDataContextDataContext();
                List<Prtl_SecntificResearch> xx =(from x in dc.Prtl_SecntificResearches where x.ID ==Convert .ToInt32( Details .CommandArgument) select x).ToList();
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
                //  DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
          //  }
        }

         protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

   

    #region update user

    protected void btnmodfy_Click(object sender, EventArgs e)
    {
        try
        {
            int labelID =Convert .ToInt32(  DetailsView1.GetControl<Label >("labelID").Text );
           string  txtAuthorName = DetailsView1.GetControl<TextBox>("txtAuthorName").Text ;
           string txtCo_Authors = DetailsView1.GetControl<TextBox>("txtCo_Authors").Text ;
           string txtTitle = DetailsView1.GetControl<TextBox>("txtTitle").Text ;
              string  txtJournal = DetailsView1.GetControl<TextBox>("txtJournal").Text ;
              string  txtVolume = DetailsView1.GetControl<TextBox>("txtVolume").Text ;

              string  txtNumber = DetailsView1.GetControl<TextBox>("txtNumber").Text ;

              string txtpageNum = DetailsView1.GetControl<TextBox>("txtpageNum").Text ;

              string txtYear = DetailsView1.GetControl<TextBox>("txtYear").Text ;
              string absa = DetailsView1.GetControl<TextBox>("txtabstract_ar").Text;

              string abse = DetailsView1.GetControl<TextBox>("txtabstract_en").Text;
            
            var AsyncFileUpload1 = DetailsView1.GetControl<AsyncFileUpload>("AsyncFileUpload1");

            prtl_SecResUtillity.Update(labelID, txtAuthorName, txtCo_Authors, txtTitle, txtJournal, txtVolume, txtNumber, txtpageNum, txtYear,absa ,abse );
            DetailsView1.Visible = false;
            GridView1.DataSource = Session["datasource"] ;
            GridView1.DataBind();
             
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    #endregion update user

    #region cancel edit

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

    #endregion cancel edit

        protected void GridView1_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView1.PageIndex = e.NewSelectedIndex ;
           // GridView1.SelectedIndex = e.NewSelectedIndex;
            GridView1.DataSource = Session["datasource"];
            GridView1.DataBind();
        }
    }
    
   
}