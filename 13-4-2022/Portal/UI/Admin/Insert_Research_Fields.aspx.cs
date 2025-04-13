using App_Code;
using MisBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class Insert_Research_Fields : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string memberid = "";
            int i = 0;
                    //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
                    foreach (var row in GridView1.Rows)
                    {
                        RadioButton b = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1");

                        if (b.Checked)
                        {
                            memberid = b.ToolTip;
                        }
                        i++;
                    }

                    if (memberid != "" && Staff_Utility.checkMemberinResFields(Convert.ToDecimal(memberid))==false)
                    {char[] delimiterChars = { ',' };
                        string[] ss = TextBox1.Text.Split(delimiterChars);

                        if (ss.Length > 7) { ResMessage.Text = "لم يتم الادخال - أكثر من 7 مجالات"; } else { 
                       bool x= Staff_Utility.Insert_Stf_Research_Fields(Convert.ToDecimal(memberid), TextBox1.Text, TextBox2.Text,FacDropDownList.SelectedValue,DepDropDownList.SelectedValue);
                       if (x == true)
                       {
ResMessage.Text = "تم الادخال بنجاح";
                       }
                       else
                       {
                           ResMessage.Text = "لم يتم الادخال";

                       }
                        }
                        
                    }
                    else if (Staff_Utility.checkMemberinResFields(Convert.ToDecimal(memberid)) == true)
                    {char[] delimiterChars = { ',' };
                        string[] ss = TextBox1.Text.Split(delimiterChars);

                        if (ss.Length > 7) { ResMessage.Text = "لم يتم الادخال - أكثر من 7 مجالات"; }
                        else
                        { 

                      bool xx=  Staff_Utility.update_Stf_Research_Fields(Convert.ToDecimal(memberid), TextBox1.Text, TextBox2.Text);
                            if (xx == true)
                       {
                        ResMessage.Text = "تم التعديل بنجاح";
                    }
                    else
                    {
                        ResMessage.Text = "لم يتم التعديل";
                    }
                    }
                    }
        }

        protected void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            deselct_radiobutton();
            RadioButton r = (RadioButton)sender;
            r.Checked = true;
            string memberid = "";
            int i = 0;
            //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            foreach (var row in GridView1.Rows)
            {
                RadioButton b = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1");

                if (b.Checked)
                {
                    memberid = b.ToolTip;
                }
                i++;
            }
            if (Staff_Utility.checkMemberinResFields(Convert.ToDecimal(memberid)) == true)
            {

                TextBox1.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Res_Fields;
               
                TextBox2.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Insert_By;
                //Staff_Utility.update_Stf_Research_Fields(Convert.ToDecimal(memberid), TextBox1.Text, TextBox2.Text);


            }
            else
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                ResMessage.Text = "";
            }
                   
        }

        public void deselct_radiobutton()
        {
            int i = 0;
            //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            foreach (var row in GridView1.Rows)
            {
                RadioButton b = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1");
                b.Checked = false;
                i++;
            }
        }

        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Staff_Utility.GetDepartments(Convert.ToDecimal(FacDropDownList.SelectedValue),
                                                                      StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataBind();
        }
        protected void DepDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);
            GridView1.DataBind();
        }
        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Staff_Utility.GetMembersByDep(Convert.ToDecimal(DepDropDownList.SelectedValue),
                                                               StaticUtilities.Currentlanguage(Page), Page);


            GridView1.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            GridView1.SelectedIndexChanged += this.GridView1_SelectedIndexChanged;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string memberid = "";
            int i = 0;
                    //GridView g = (GridView)Editor_DetailsView1.FindControl("GridView1");
                    foreach (var row in GridView1.Rows)
                    {
                        RadioButton b = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1");

                        if (b.Checked)
                        {
                            memberid = b.ToolTip;
                        }
                        i++;
                    }
                    if (Staff_Utility.checkMemberinResFields(Convert.ToDecimal(memberid)) == true)
                    {

                        TextBox1.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Res_Fields;
                        TextBox2.Text = Staff_Utility.getMemberinResFields(Convert.ToDecimal(memberid)).Insert_By;
                       Staff_Utility. update_Stf_Research_Fields(Convert.ToDecimal(memberid), TextBox1.Text, TextBox2.Text);
                        ResMessage.Text = "تم التعديل بنجاح";

                    }
                   
        }
    }
}