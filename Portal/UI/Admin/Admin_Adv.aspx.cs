using App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal_DAL;
using CKEditor.NET;
using System.IO;
namespace MnfUniversity_Portals.Admin
{
    public partial class Admin_Adv : PageBase
    {
        private PortalDataContextDataContext dc1 = new PortalDataContextDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AllPanel.Visible = getVisability();
                List<Adv> AllEvente = (from x in dc1.Advs 
                                       where x.Text_ar != null
                                       select x).ToList<Adv>();

                GridView1.DataSource = AllEvente;
                GridView1.DataBind();
                Session["datasource"] = AllEvente;
                //    Page.EnableViewState = false;
                //Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            }
        }
        protected bool getVisability()
        {
            if (Session["logedID"] != null && Session["loged"] != null && Session["loged"].ToString() == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Decode(object data)
        {
            return Page.Server.HtmlDecode(data == null ? "" : data.ToString());
        }
        protected void txtBody_OnInit(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "SetEditor", string.Format("SetEditor('{0}');", ((TextBox)sender).ClientID), true);
        }
        protected void ButtonAddOnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int recentGenerateId = 0;

                string content_ar = ((CustomEditor)DetailsView1.FindControl("content_ar")).Text;
                string content_en = ((CustomEditor)DetailsView1.FindControl("content_en")).Text;
                int ordered = Convert.ToInt32(((TextBox)DetailsView1.FindControl("ordered")).Text);

                PortalDataContextDataContext dc = new PortalDataContextDataContext();
                Adv firstOrDefault = dc.Advs.OrderByDescending(u => u.ID).FirstOrDefault();
                if (firstOrDefault != null)
                {
                    recentGenerateId = (firstOrDefault.ID) + 1;
                    //Assign ID that you are getting from DB
                }
                else
                {
                    recentGenerateId = 1;
                }

                string folderName = "Adv/";
                FileUpload insertFileUpload = (FileUpload)DetailsView1.FindControl("insertFileUpload");
                string filename = "";
                Adv x = new Adv();
                if (insertFileUpload.HasFile)
                {
                    filename = folderName + recentGenerateId + Path.GetExtension(insertFileUpload.FileName);
                    insertFileUpload.SaveAs(Server.MapPath(filename));

                    //  x.Image = filename;
                    x.Image = "../Admin/" + folderName + recentGenerateId + Path.GetExtension(insertFileUpload.FileName);
                }
                else
                {
                    x.Image = "Not Found";
                }



                x.Text_ar = content_ar;
                x.Text_en = content_en;
                x.ordered = ordered;
                dc.Advs .InsertOnSubmit(x);
                dc.SubmitChanges();


                DetailsView1.Visible = false;


                LinqDataSource1.DataBind();
                GridView1.DataSource = LinqDataSource1;
                GridView1.DataBind();
                Session["datasource"] = LinqDataSource1;


                Response.Redirect(Request.Url.AbsolutePath);
            }
        }
        void Page_PreRender(object obj, EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }
        protected void ButtonUpdateOnCommand(object sender, CommandEventArgs e)
        {

        }

        protected void ButtonDeleteOnCommand(object sender, CommandEventArgs e)
        {

        }
        protected void ButtonCancelOnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                DetailsView1.Visible = false;
            }
        }

        protected void ButtonCancelInsertOnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CancelInsert")
            {
                DetailsView1.Visible = false;
            }
        }

        protected void ButtonCancelEditOnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CancelEdit")
            {
                DetailsView1.Visible = false;
            }
        }
        protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            // GridView1.SelectedIndex = e.NewSelectedIndex;
            GridView1.DataSource = Session["datasource"];
            GridView1.DataBind();
        }
        //عرض للتعديل
        protected void Details_OnClick(object sender, EventArgs e)
        {

            LinkButton btnButton = sender as LinkButton;
            GridViewRow gvRow = (GridViewRow)btnButton.NamingContainer;
            LinkButton Details = (LinkButton)gvRow.FindControl("Details");



            var dc = new PortalDataContextDataContext ();
            List<Adv > xx = (from x in dc.Advs where x.ID == Convert.ToInt32(Details.CommandArgument) select x).ToList();
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            DetailsView1.Visible = true;
            //  DetailsView1.Fields[1].Visible = true;
            DetailsView1.DataSource = xx;
            DetailsView1.DataBind();
            Session["DetailDataSource"] = xx;
            //  }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            DetailsView1.Visible = true;

            DetailsView1.ChangeMode(DetailsViewMode.Insert);

        }


        //هرض التفاضيل
        protected void Details2_Click(object sender, EventArgs e)
        {
            LinkButton btnButton = sender as LinkButton;
            GridViewRow gvRow = (GridViewRow)btnButton.NamingContainer;
            LinkButton Details = (LinkButton)gvRow.FindControl("Details2");



            var dc = new PortalDataContextDataContext ();
            List<Adv> xx = (from x in dc.Advs where x.ID == Convert.ToInt32(Details.CommandArgument) select x).ToList();

            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            DetailsView1.Visible = true;

            DetailsView1.DataSource = xx;
            DetailsView1.DataBind();

            Session["DetailDataSource"] = xx;

        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView1.ChangeMode(e.NewMode);

            if (e.NewMode != DetailsViewMode.Insert)
            {
                DetailsView1.DataSource = Session["DetailDataSource"];
                DetailsView1.DataBind();
            }
        }


        protected void DetailsView1_OnItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            string content_ar = ((CustomEditor)DetailsView1.FindControl("content_ar")).Text;
            string content_en = ((CustomEditor)DetailsView1.FindControl("content_en")).Text;
            int ordered = Convert.ToInt32(((TextBox)DetailsView1.FindControl("ordered")).Text);

            int ID = Convert.ToInt32(((Label)DetailsView1.FindControl("labelID")).Text);

            var dc = new PortalDataContextDataContext ();
            Adv c = (from x in dc.Advs where x.ID == ID select x).SingleOrDefault();
            

            string folderName = "Cons/";
            FileUpload EditeFileUpload = (FileUpload)DetailsView1.FindControl("EditeFileUpload");
            string fileName = "";
            if (EditeFileUpload.HasFile)
            {
                string s = c.Image;

                if (s != "Not Found" && s != null && s != "")
                {
                    string[] words = s.Split('.');
                    string extention = words[words.Length - 1];

                    string[] words2 = s.Split('/');
                    string folderrrrr = words2[0];
                    string imagExt = words2[1];
                    //update in folder(delete then save)
                    //delete
                    string path = Server.MapPath(words[0] + "." + extention);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();

                    }
                }
                fileName = folderName + c.ID.ToString() + System.IO.Path.GetExtension(EditeFileUpload.FileName);

                EditeFileUpload.SaveAs(Server.MapPath(fileName));
                //c.Image = fileName;
                c.Image = "../Admin/" + folderName + c.ID.ToString() + System.IO.Path.GetExtension(EditeFileUpload.FileName);
            }
           


            c.Text_ar = content_ar;
            c.Text_en = content_en;
            c.ordered = ordered;
            dc.SubmitChanges();


            DetailsView1.Visible = false;


            LinqDataSource1.DataBind();
            GridView1.DataSource = LinqDataSource1;
            GridView1.DataBind();

            Session["datasource"] = LinqDataSource1;
        }

        protected void DetailsView1_OnItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void DetailsView1_OnItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {

            int ID = Convert.ToInt32(((Label)DetailsView1.FindControl("labelID")).Text);

            var dc = new PortalDataContextDataContext ();
            Adv c = (from x in dc.Advs where x.ID == ID select x).SingleOrDefault();
            //get  name of image

            //if (c.Image != null || c.Image != "" || c.Image != "NULL" || c.Image != "Not Found")

            if (!((c.Image).Equals(null)) && c.Image != "Not Found")
            {
                string s = c.Image;
                string[] words = s.Split('.');
                string extention = words[words.Length - 1];

                string[] words2 = s.Split('/');
                string folderrrrr = words2[0];
                string imagExt = words2[1];
                //update in folder(delete then save)
                //delete
                string path = Server.MapPath(words[0] + "." + extention);
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not
                {
                    file.Delete();

                }
            }

            dc.Advs.DeleteOnSubmit(c);
            dc.SubmitChanges();


            DetailsView1.Visible = false;

            LinqDataSource1.DataBind();
            GridView1.DataSource = LinqDataSource1;
            GridView1.DataBind();

            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var dc = new PortalDataContextDataContext ();

            List<Adv> event0 = (from x in dc.Advs
                                where x.Text_ar.Contains(TextBox1.Text)
                                select x).ToList<Adv>();

            GridView1.DataSource = event0;
            GridView1.DataBind();
            Session["datasource"] = event0;
        }
    }
}