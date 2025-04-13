using App_Code;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals
{
    public partial class Courses : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //if ( Session["id"] != null)
                //{
                //  //  int x = Convert.ToInt32(Page.RouteData.Values["id"]);
                //    int x = Convert.ToInt32(Session["id"]);
                //    LinqDataSource1.Where = "ID== " + x;
                //    ListView1.DataBind();
                //}
            }
        }
        protected string getUrl(object eval)
        {
            string uniabbr = "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage;
             
           
            //Session["Coursedd"] = eval;
               return uniabbr;
        }
        //protected void getx(int   ID)
        //{
        //    string uniabbr = "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage;
        //    //var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
        //    //var lang = CurrentLanguage;


        //    Session["Coursedd"] = ID;
        //    //string url = uniabbr + "/" + FacAbbr + "/SUB_" + eval + "/SubjectHome/" + lang;
        //    //return uniabbr;
        //}

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView1.SelectedIndex >= 0)
                ViewState["SelectedKey"] = ListView1.SelectedValue;
            else
                ViewState["SelectedKey"] = null;

            var x = ViewState["SelectedKey"];
            
            int id = (int)ListView1.SelectedDataKey.Values[ListView1.SelectedIndex];  
            
        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListView1.SelectedIndex = e.NewSelectedIndex;

            string pid = ListView1.SelectedDataKey.Value.ToString();

            //string pid = ListView1.DataKeys[e.NewSelectedIndex].Value.ToString();

          // Label1.Text = "Selected Product ID: " + pid;
   

            //int y = Convert.ToInt32(ListView1.SelectedValue  );
            //int x = Convert.ToInt32(ListView1.SelectedDataKey.Value);
            //Session["Coursedd"] = x;

        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    ListViewDataItem di = (ListViewDataItem)e.Item;
            //    int CurrentItemValue = int.Parse(ListView1.DataKeys[di.DataItemIndex].Value.ToString());
            //    Session["Coursedd"] = CurrentItemValue;
            //    //if (CurrentItemValue == ID)
            //    //    ListView1.SelectedIndex = di.DataItemIndex;
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            string uniabbr = "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage;
          

        }

        protected void lnkSelect_Command(object sender, CommandEventArgs e)
        {
            int x = Convert.ToInt32(e.CommandArgument);
            Response .Redirect ( "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" + CurrentLanguage);
          
        }

        protected void RestoName_Click(object sender, EventArgs e)
        {
            ListViewDataItem item = (ListViewDataItem)(sender as Control).NamingContainer;
            string ResturantId = ListView1.DataKeys[item.DataItemIndex].Value.ToString();
            //Label lblStatus = (Label)item.FindControl("lblStatus");


            //Response.Write("RestuantId: " + ResturantId + "<br /> Status: " + lblStatus.Text);
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName =="Select")
            {
                int x =Convert .ToInt32 ( e.CommandArgument);
            }
        }

        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
            int iDHide2 = Convert.ToInt32(ListView1.GetControl<HiddenField>("hide2").Value);
            int iDHide1 = Convert.ToInt32(ListView1.GetControl<HiddenField>("hide1").Value);
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
              int iDHide2 = Convert.ToInt32(ListView1.GetControl<HiddenField>("hide3").Value);
             
        }
        public string GetUrl(object id)
        {
            //here you can do validation e.g. if companyname is not null or something 
            //Also you can do some customization based on your logged-in user 
            //You can get the Page location dynamically from say web.config

    string url =  "http://" + Request.Url.Authority + "/univ_ITs/CourseRegister/" +id+ "/"+ CurrentLanguage;
       //     string url = "~/CustomerDetails.aspx?customerid=" + id.ToString() + "&companyname=" +
       //    Server.UrlEncode(id.ToString());

            return url;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           // LinqDataSource2.WhereParameters 
                
            //string Where = "CourseType ==@CourseType";
            //LinqDataSource1.WhereParameters.Add("CourseType", DbType.Int32, DropDownList1.SelectedValue .ToString());
          
            //LinqDataSource1.Where = Where;
            //LinqDataSource1.DataBind();


            //ListView1.DataSource = LinqDataSource1;
            ListView1.DataBind();
             
        }
    }
}