using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Mis_DAL;

namespace ResultsWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                
                
                DropDownList1.Items.Clear();

                DropDownList1.Items.Add(new ListItem("اختر الكلية", "0"));
                    
                    DropDownList1.DataSource =ResultsUtility.GetFaculties();
                DropDownList1.DataTextField = "key";
                DropDownList1.DataValueField = "Value";
               
                DropDownList1.DataBind();

                
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {



            var dc = new Mis_DAL.MisDataContext();
            
            if (SeatnoTextBox1.Text == "")
            {

                var q = dc.Natega_PUBLISH_STUD(null, nidTextBox1.Text, Decimal.Parse(DropDownList1.SelectedValue),
                    int.Parse(DropDownList2.SelectedValue)).AsEnumerable();

                STFormView.DataSource = q;
               STFormView.DataBind();
                HiddenField pay_flag = (HiddenField)STFormView.FindControl("paystate");
                if (pay_flag != null)
                {
                    if (decimal.Parse(pay_flag.Value) == 1)
                    {
                        ResultsListView.DataSource = ResultsUtility.GetResult_info(null, nidTextBox1.Text,
                            Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));

                        ResultsListView.DataBind();
                    }
                    else
                    {
                        ResultsListView.Visible = false;

                        Label21.Visible = true;


                    }
                }
                else
                {
                    ResultsListView.DataSource = null;
                    ResultsListView.DataBind();
                }



            } 
            else if (nidTextBox1.Text == "")
            {
                var q = dc.Natega_PUBLISH_STUD(Decimal.Parse(SeatnoTextBox1.Text), null,
                    Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue)).AsEnumerable();
                STFormView.DataSource = q;
                STFormView.DataBind();
                HiddenField pay_flag = (HiddenField)STFormView.FindControl("paystate");
                if (pay_flag != null)
                {
                    if (decimal.Parse(pay_flag.Value) == 1)
                    {
                        ResultsListView.DataSource = ResultsUtility.GetResult_info(Decimal.Parse(SeatnoTextBox1.Text),
                            null,
                            Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));

                        ResultsListView.DataBind();
                    }
                    else
                    {
                        ResultsListView.Visible = false;

                        Label21.Visible = true;

                    }
                }
                else
                {
                    ResultsListView.DataSource = null;
                    ResultsListView.DataBind();
                }
            }
            else
            {
                var q = dc.Natega_PUBLISH_STUD(Decimal.Parse(SeatnoTextBox1.Text), nidTextBox1.Text,
                    Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue)).AsEnumerable();
                STFormView.DataSource = q;
                STFormView.DataBind();
                HiddenField pay_flag = (HiddenField)STFormView.FindControl("paystate");
                if (pay_flag != null)
                {
                    if (decimal.Parse(pay_flag.Value) == 1)
                    {
                        ResultsListView.DataSource = ResultsUtility.GetResult_info(Decimal.Parse(SeatnoTextBox1.Text),
                            nidTextBox1.Text, Decimal.Parse(DropDownList1.SelectedValue),
                            int.Parse(DropDownList2.SelectedValue));

                        ResultsListView.DataBind();
                    }
                    else
                    {
                        ResultsListView.Visible = false;

                        Label21.Visible = true;

                    }
                }
                else
                {
                    ResultsListView.DataSource = null;
                    ResultsListView.DataBind();
                }
            }
            
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeatnoTextBox1.Text = null;
            nidTextBox1.Text = null;
            
            if (ResultsUtility.Getis_Mis_or_ext(decimal.Parse(DropDownList1.SelectedValue)) == 1)
            {

                nidtd.Visible = true;
                acidtd.Visible = true;
            }else{
            
                    nidtd.Visible = false;
                    acidtd.Visible = true;
                   


            }
            DropDownList2.Items.Clear();

            DropDownList2.Items.Add(new ListItem("اختر الفرقة", "0"));
            DropDownList2.DataSource = ResultsUtility.GetYears(decimal.Parse(DropDownList1.SelectedValue));
            DropDownList2.DataTextField = "key";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind();
        }

        protected void ResultsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (ResultsUtility.Getis_mark_appear(Decimal.Parse(DropDownList1.SelectedValue)) == decimal.Parse("1"))
                {
                    HtmlControl markth = ResultsListView.FindControl("markth") as HtmlControl;
                    markth.Visible = true;
                    HtmlControl marktd = e.Item.FindControl("marktd") as HtmlControl;
                    if (marktd != null)
                    marktd.Visible = true;
                }
                else if (ResultsUtility.Getis_mark_appear(Decimal.Parse(DropDownList1.SelectedValue)) == decimal.Parse("0"))
                {
                    HtmlControl markth = ResultsListView.FindControl("markth") as HtmlControl;
                    markth.Visible = false;
                    HtmlControl marktd = e.Item.FindControl("marktd") as HtmlControl;
                    if (marktd != null)
                    marktd.Visible = false;
                }
            }
        }

        protected void DropDownList2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SeatnoTextBox1.Text = null;
            nidTextBox1.Text = null;
        }
    }
    }
