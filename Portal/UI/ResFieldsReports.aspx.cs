using App_Code;
using MisBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

namespace MnfUniversity_Portals.UI
{
    public partial class ResFieldsReports :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);
                //var DepAbbr = URLBuilder.CurrentDepAbbr(Page.RouteData);
                if (FacAbbr == null || URLBuilder.CurrentOwnerAbbr(Page.RouteData) == "Publication")
                {
                    FacDropDownList.Items.Clear();
                    FacDropDownList.Items.Add(new ListItem((string) GetLocalResourceObject("choose.Text"), "-1")); 
                    viewInUniversity();
                }
                else
                {
                    decimal id = Prtl_OwnersUtility.getFacIDByAbbr(FacAbbr);
                    FacDropDownList.SelectedValue = id.ToString();
                    FacDropDownList.DataBind();
                    FacDropDownList.Enabled = false;
                    viewInFac(Convert.ToInt32(FacDropDownList.SelectedValue));
                        
                    
                    if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
                    {
                        DepDropDownList.Enabled = true;
                    }
                    DepDropDownList.Items.Clear();
                    DepDropDownList.Items.Add(new ListItem((string) GetLocalResourceObject("choose.Text"), "-1"));
                    DepDropDownList.DataSource =
                        Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                            StaticUtilities.Currentlanguage(Page));
                    DepDropDownList.DataTextField = "DepName";
                    DepDropDownList.DataValueField = "ID";
                    DepDropDownList.DataBind();


                   
                }
            }
        }
        protected void ListView2_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager p = (DataPager)ListView1.FindControl("DataPager1");
            p.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ListView1.DataSource = (Array)Session["datasource"];
            ListView1.DataBind();

        }
        public void viewInUniversity()
        {
            Label16.Visible = true;
            

            //link.InnerText = "";

            List<string> s = Staff_Utility.getAllResFields();
            char[] delimiterChars = { ',' };
            Dictionary<string, int> newresult = new Dictionary<string, int>();
           // List<string> result1 = new List<string>();
            string y;
            foreach (string xx in s)
            {
                string[] ss = xx.Split(delimiterChars);


                foreach (string x in ss)
                {
                    y = x;
var q = (from n in s where n.Contains(y) select n).Count();
                    if (y.StartsWith(" ") || y.EndsWith(" "))
                    {
                        y = y.TrimStart().TrimEnd();
                        if (!newresult.ContainsKey(y))
                        {
                            
                            newresult.Add(y,q);
                           // result1.Add(y);
                        }
                    }
                    else if (y.StartsWith("\n"))
                    {
                        y = y.Substring(y.IndexOf("\n"), y.Length - 1);
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y,q);
                        }
                    }
                    else if (y.EndsWith("\n"))
                    {
                        y = y.Substring(0, y.IndexOf("\n"));
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y,q);
                        }
                    }
                    else if (y == " " || y == "" || y == "\n" || y==null)
                    {

                    }
                    else
                    {
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y,q);
                        }
                    }
                    



                }

            }
            //Dictionary<int, string> result2 = new Dictionary<int, string>();
            //result2.Add(newresult.Keys, newresult.Values.);
           // result2.Values=newresult.Values.Distinct(StringComparer.InvariantCultureIgnoreCase).ToString();
            var result3 = (from d in newresult orderby d.Value descending select new { field = d.Key.ToString(),count=d.Value.ToString() });
            var q2 = result3.Except(from c in result3 where (c.field == null || c.field=="" || c.field==" " || c.field=="\n") select c).ToArray();
            Session["datasource"] = q2;
            ListView1.DataSource = q2;
            ListView1.DataBind();
            //foreach (string f in result3)
            //{
            //    link.InnerHtml += @"<li style=""direction:ltr;font:bold;list-style-type:disc !important;"">" + f + "</li>";
            //}
            Label16.Text = "عدد المجالات البحثية بجامعة المنوفية : " + q2.Length;
        }
        public void viewInFac(int facid)
       {
            Label16.Visible = true;
           

            //link.InnerText = "";

            List<string> s = Staff_Utility.getAllFacResFields(facid);
            char[] delimiterChars = { ',' };
            Dictionary<string, int> newresult = new Dictionary<string, int>();
            // List<string> result1 = new List<string>();
            string y;
            foreach (string xx in s)
            {
                string[] ss = xx.Split(delimiterChars);


                foreach (string x in ss)
                {
                    y = x;
                    var q = (from n in s where n.Contains(y) select n).Count();
                    if (y.StartsWith(" ") || y.EndsWith(" "))
                    {
                        y = y.TrimStart().TrimEnd();
                        if (!newresult.ContainsKey(y))
                        {

                            newresult.Add(y, q);
                            // result1.Add(y);
                        }
                    }
                    else if (y.StartsWith("\n"))
                    {
                        y = y.Substring(y.IndexOf("\n"), y.Length - 1);
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }
                    else if (y.EndsWith("\n"))
                    {
                        y = y.Substring(0, y.IndexOf("\n"));
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }
                    else if (y == " " || y == "" || y == "\n" || y == null)
                    {

                    }
                    else
                    {
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }




                }

            }
            //Dictionary<int, string> result2 = new Dictionary<int, string>();
            //result2.Add(newresult.Keys, newresult.Values.);
            // result2.Values=newresult.Values.Distinct(StringComparer.InvariantCultureIgnoreCase).ToString();
            var result3 = (from d in newresult orderby d.Value descending select new { field = d.Key.ToString(), count = d.Value.ToString() });
            var q2 = result3.Except(from c in result3 where (c.field == null || c.field == "" || c.field == " " || c.field == "\n") select c).ToArray();
            Session["datasource"] = q2;
            ListView1.DataSource = q2;
            ListView1.DataBind();
            //foreach (string f in result3)
            //{
            //    link.InnerHtml += @"<li style=""direction:ltr;font:bold;list-style-type: disc !important;"">" + f + "</li>";
            //}
            Label16.Text = " عدد المجالات البحثية بكلية" + FacDropDownList.SelectedItem.Text + ": " + q2.Length;

        }
            
        public void viewInFacDep(int facid,int depid)
        {
            Label16.Visible = true;
           

            //link.InnerText = "";

            List<string> s = Staff_Utility.getAllFacDepResFields(facid,depid);
            char[] delimiterChars = { ',' };
            Dictionary<string, int> newresult = new Dictionary<string, int>();
            // List<string> result1 = new List<string>();
            string y;
            foreach (string xx in s)
            {
                string[] ss = xx.Split(delimiterChars);


                foreach (string x in ss)
                {
                    y = x;
                    var q = (from n in s where n.Contains(y) select n).Count();
                    if (y.StartsWith(" ") || y.EndsWith(" "))
                    {
                        y = y.TrimStart().TrimEnd();
                        if (!newresult.ContainsKey(y))
                        {

                            newresult.Add(y, q);
                            // result1.Add(y);
                        }
                    }
                    else if (y.StartsWith("\n"))
                    {
                        y = y.Substring(y.IndexOf("\n"), y.Length - 1);
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }
                    else if (y.EndsWith("\n"))
                    {
                        y = y.Substring(0, y.IndexOf("\n"));
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }
                    else if (y == " " || y == "" || y == "\n" || y == null)
                    {

                    }
                    else
                    {
                        if (!newresult.ContainsKey(y))
                        {
                            newresult.Add(y, q);
                        }
                    }




                }

            }
            //Dictionary<int, string> result2 = new Dictionary<int, string>();
            //result2.Add(newresult.Keys, newresult.Values.);
            // result2.Values=newresult.Values.Distinct(StringComparer.InvariantCultureIgnoreCase).ToString();
            var result3 = (from d in newresult orderby d.Value descending select new { field = d.Key.ToString(), count = d.Value.ToString() });
            var q2 = result3.Except(from c in result3 where (c.field == null || c.field == "" || c.field == " " || c.field == "\n") select c).ToArray();
            Session["datasource"] = q2;
            ListView1.DataSource = q2;
            ListView1.DataBind();
            //foreach (string f in result3)
            //{
            //    link.InnerHtml += @"<li style=""direction:ltr;font:bold;list-style-type: disc !important;"">" + f + "</li>";
            //}
            Label16.Text = "المجالات البحثية بقسم " + DepDropDownList.SelectedItem.Text + ": " + q2.Length;
        }
        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
                DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataBind();
            }
            else if(Convert.ToInt32(FacDropDownList.SelectedValue) == -1)
            {
                DepDropDownList.Enabled = false;
                 DepDropDownList.Items.Clear();
                 DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label16.Visible = true;


            //link.InnerText = "";

            if (FacDropDownList.SelectedValue == "-1" && DepDropDownList.SelectedValue == "-1")
            {
                viewInUniversity();
            }
            else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue == "-1")
            {
                viewInFac(Convert.ToInt32(FacDropDownList.SelectedValue));
            }else if (FacDropDownList.SelectedValue != "-1" && DepDropDownList.SelectedValue != "-1")
            {
                viewInFacDep(Convert.ToInt32(FacDropDownList.SelectedValue),Convert.ToInt32(DepDropDownList.SelectedValue));

            }
          
        }
    }
}