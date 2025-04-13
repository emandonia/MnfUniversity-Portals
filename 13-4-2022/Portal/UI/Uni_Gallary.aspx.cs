using App_Code;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace MnfUniversity_Portals.UI
{
    public partial class Uni_Gallary : PageBase
    {

        string x = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = BindImageList();
                //Repeater1.DataSource = dt;
                //Repeater1.DataBind();
                
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["folderName"] = "Olympics";
            //  LinkButton1.PostBackUrl = URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage;
         //   Response.Redirect(URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage);
            x = "Olympics";
            DataTable dt = BindImageList();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            OwnerImageFormView.DataBind();
            panel2.Visible = true;

        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["folderName"] = "Feast";
            x = "Feast";
            //  LinkButton1.PostBackUrl = URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage;
            //   Response.Redirect(URLBuilder.FilesHomeServer + "/Uni_Gallary/" + CurrentLanguage);

            DataTable dt = BindImageList();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            OwnerImageFormView.DataBind();
            panel2.Visible = true;

        }
        public DataTable BindImageList()
        {


            if (Session["folderName"] != null)
            {
                DataTable ImageList = new DataTable();
                ImageList.Clear();
                ImageList.Columns.Add("Image", typeof(string));
                //string[] files = Directory.GetFiles(URLBuilder.PhysicalPath("") + "uni\\Portal\\Gallary\\" + (string)Session["folderName"].ToString()).Select(path => Path.GetFileName(path))
                //                         .ToArray();
                string[] files = Directory.GetFiles(URLBuilder.PhysicalPath("") + "uni\\Portal\\Gallary\\" + x).Select(path => Path.GetFileName(path))
                                        .ToArray();

                foreach (string file in files)
                {
                    if (IsImage(file))
                    {
                        //ImageList.Rows.Add(URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/Gallary/" + (string)Session["folderName"].ToString() + "/" + file);
                        ImageList.Rows.Add(URLBuilder.FilesHomeServer + "/PrtlFiles/uni/Portal/Gallary/" + x + "/" + file);

                    }
                }
                //ImageList.AcceptChanges();
                return ImageList;

            }
            else
            { return null; }
            //if (files.Length > 0)
            //    ImageList.SelectedIndex = 0;

        }
        public string getFirstImageUrl(){
            DataTable ddt=BindImageList();
            string s=ddt.Rows[0].ItemArray[0].ToString();
            return s;
        }
        private bool IsImage(string file)
        {
            return file.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                   file.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                   file.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase);
        }

    }
}