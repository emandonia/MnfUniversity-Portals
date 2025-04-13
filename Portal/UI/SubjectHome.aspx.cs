using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using App_Code;
using BLL;
using Common;
using MisBLL;
using Portal_DAL;

namespace MnfUniversity_Portals.UI
{
    public partial class SubjectHome : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                
            
                //SubjectUtility.CreateSubjectsOwners();
               
               //string ss=URLBuilder.CurrentOwnerAbbr(Page.RouteData);
               //if (ss.StartsWith("Post"))
               //{

               //    string s = ss.Substring(8); //to start after postsub_

               //    LinqDataSource1.Where = "PG_SUBJECT_ID == " + s;
               //    ListView1.DataBind();
               //}
               //else
               //{
                string s = URLBuilder.CurrentOwnerAbbr(Page.RouteData).Substring(4); //to start after sub_

                   LinqDataSource1.Where = "ED_SUBJECT_ID == " + s;
                   ListView1.DataBind();
               //}
            }
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }


       
        

        public string CourseSpecs()
        {
            return URLBuilder.GetURLIfExists2(Page, SiteFolders.Course_Specs,getCourseSpecsFileName());
        }

        public string CourseReports()
        {
            return URLBuilder.GetURLIfExists2(Page, SiteFolders.Course_Report, getCourseReportFileName());
        }

        protected bool checkuser()
        {

            return Roles.IsUserInRole(Page.User.Identity.Name.ToLower(), "FacAdmin");
        }

        

        public string getCourseReportFileName()
        {

            string s = URLBuilder.GetURLIfExists3(Page, SiteFolders.Course_Report,
                                                  null);
            if (Directory.Exists(s))
            {
                string[] ss = Directory.GetFiles(s);
                if (ss.Length != 0)
                {
                    string file = Path.GetFileName(ss[0]);


                    return file;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return "";
            }
        }

        public string getCourseSpecsFileName()
        {

            string s = URLBuilder.GetURLIfExists3(Page, SiteFolders.Course_Specs,
                                                  null);
            if (Directory.Exists(s))
            {
                string[] ss = Directory.GetFiles(s);
                if (ss.Length != 0)
                {
                    string file = Path.GetFileName(ss[0]);


                    return file;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return "";
            }
        }
        protected void InsertCourseSpecsInsertClicked(object sender, EventArgs e)
        {

            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            Editor_DetailsView1.Fields[0].Visible = true;
            Editor_DetailsView1.Fields[1].Visible = false;
            //LinkButton LinkButton1 = (LinkButton) Editor_DetailsView1.FindControl("LinkButton1");
            //LinkButton1.Visible = true;
            //LinkButton LinkButton2 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton2");
            //LinkButton2.Visible = true;
            //LinkButton LinkButton5 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton5");
            //LinkButton5.Visible = false;
            //LinkButton LinkButton6= (LinkButton)Editor_DetailsView1.FindControl("LinkButton6");
            //LinkButton6.Visible = false;
            Editor_ModalPopupExtender.Show();


        }

        protected void InsertCourseReportInsertClicked(object sender, EventArgs e)
        {
            Editor_DetailsView1.ChangeMode(DetailsViewMode.Insert);
            Editor_DetailsView1.Fields[1].Visible = true;
            Editor_DetailsView1.Fields[0].Visible = false;
            //LinkButton LinkButton1 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton1");
            //LinkButton1.Visible = false;
            //LinkButton LinkButton2 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton2");
            //LinkButton2.Visible = false;
            //LinkButton LinkButton5 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton5");
            //LinkButton5.Visible = true;
            //LinkButton LinkButton6 = (LinkButton)Editor_DetailsView1.FindControl("LinkButton6");
            //LinkButton6.Visible = true;
            Editor_ModalPopupExtender.Show();
        }

        protected void InsertSpecsButtonClicked(object sender, EventArgs e)
        {
            AsyncFileUpload f = (AsyncFileUpload) Editor_DetailsView1.FindControl("AsyncFileUpload1");
            if (f.HasFile)
            {
                string s = URLBuilder.GetURLIfExists3(Page, SiteFolders.Course_Specs,
                                                      null);
                if (Directory.Exists(s))
                {
                    string[] ss = Directory.GetFiles(s);
                    if (ss.Length != 0)
                    {
                        string file = Path.GetFileName(ss[0]);
                        string filepath = s + "\\" + file;
                        if (File.Exists(filepath))
                        {
                            File.Delete(filepath);
                        }
                    }
                }
                StaticUtilities.UploadFile(Editor_DetailsView1, "AsyncFileUpload1",
                                           SiteFolders.Course_Specs);
                Label13.Text = (string) GetLocalResourceObject("SubjectHome_InsertSpecsButtonClicked_File_Uploaded_Successuffly_");
                Editor_DetailsView1.DataBind();
            }
            else
            {
                Label13.Text = (string) GetLocalResourceObject("SubjectHome_InsertSpecsButtonClicked_File_Not_Uploaded_");
            }

        }

        protected void DeleteSpecsButtonClicked(object sender, EventArgs e)
        {
            try
            {
                StaticUtilities.DeleteImage(Page, getCourseSpecsFileName(), SiteFolders.Course_Specs);
                Label13.Text =
                    (string) GetLocalResourceObject("SubjectHome_DeleteSpecsButtonClicked_File_Deleted_Successffuly_");
                Editor_DetailsView1.DataBind();
            }catch(Exception ee)
            {
                Label13.Text = ee.Message;
            }
        }


        protected void InsertReportButtonClicked(object sender, EventArgs e)
        {



            AsyncFileUpload f = (AsyncFileUpload)Editor_DetailsView1.FindControl("AsyncFileUpload2");
            if (f.HasFile)
            {
                string s = URLBuilder.GetURLIfExists3(Page, SiteFolders.Course_Report,
                                                      null);
                if (Directory.Exists(s))
                {
                    string[] ss = Directory.GetFiles(s);
                    if (ss.Length != 0)
                    {
                        string file = Path.GetFileName(ss[0]);
                        string filepath = s + "\\" + file;
                        if (File.Exists(filepath))
                        {
                            File.Delete(filepath);
                        }
                    }
                }
                StaticUtilities.UploadFile(Editor_DetailsView1, "AsyncFileUpload2",
                                           SiteFolders.Course_Report);
                Label13.Text = (string)GetLocalResourceObject("SubjectHome_InsertSpecsButtonClicked_File_Uploaded_Successuffly_");
                Editor_DetailsView1.DataBind();
            }
            else
            {
                Label13.Text = (string)GetLocalResourceObject("SubjectHome_InsertSpecsButtonClicked_File_Not_Uploaded_");
            }
            
        }

        protected void DeleteReportButtonClicked(object sender, EventArgs e)
        {
            try{
            StaticUtilities.DeleteImage(Page, getCourseReportFileName(), SiteFolders.Course_Report);
            Label13.Text = (string)GetLocalResourceObject("SubjectHome_DeleteSpecsButtonClicked_File_Deleted_Successffuly_");
            Editor_DetailsView1.DataBind();
             }catch(Exception ee)
            {
                Label13.Text = ee.Message;
            }
        }


        protected string getsubjectDes(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
               return  SubjectUtility.getsubjectbyid(Convert.ToDecimal(eval)).SUBJECT_DESCR_AR;

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return SubjectUtility.getsubjectbyid(Convert.ToDecimal(eval)).SUBJECT_DESCR_EN;
            }
            else
            {
                return "";
            }
        }
        protected string getsubjectCont(object eval)
        {
            if (StaticUtilities.Currentlanguage(Page) == "ar")
            {
                return SubjectUtility.getsubjectbyid(Convert.ToDecimal(eval)).SUBJECT_CONTENTS_AR;

            }
            else if (StaticUtilities.Currentlanguage(Page) == "en")
            {
                return SubjectUtility.getsubjectbyid(Convert.ToDecimal(eval)).SUBJECT_CONTENTS_EN;
            }
            else
            {
                return "";
            }
        }
    }
}