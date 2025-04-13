using App_Code;
using BLL;
using Common;
using Mis_DAL;
using MisBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class AllFacResults : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Interval = Properties.Settings.Default.ResultsTimerInterval;
            
            if (!IsPostBack)
            {
                if (Session["fac_datasource"] != null)
                {
                    if (Session["fac"] != null)
                    {
                        if ((int) Session["fac"] != 0)
                        {

                            DropDownList1.Items.Clear();

                            DropDownList1.Items.Add(new ListItem((string) GetLocalResourceObject("Fac.Text"), "0"));

                            DropDownList1.DataSource = (Dictionary<string, decimal>) Session["fac_datasource"];
                            DropDownList1.DataTextField = "key";
                            DropDownList1.DataValueField = "Value";

                            DropDownList1.DataBind();
                            DropDownList1.SelectedIndex = (int) Session["fac"];


                            if ((int) Session["year"] != 0)
                            {
                                DropDownList2.Items.Clear();

                                DropDownList2.Items.Add(new ListItem((string) GetLocalResourceObject("Year.Text"), "0"));
                                DropDownList2.DataSource = ResultsUtility.GetYears(decimal.Parse(DropDownList1.SelectedValue));
                                DropDownList2.DataTextField = "key";
                                DropDownList2.DataValueField = "Value";
                                DropDownList2.DataBind();
                                DropDownList2.SelectedIndex = (int) Session["year"];
                            }
                            nidtd.Visible = (bool) Session["nidtd"];
                            acidtd.Visible = (bool) Session["acidtd"];
                        }
                    }
                    else
                    {
                        DropDownList1.Items.Clear();

                        DropDownList1.Items.Add(new ListItem((string) GetLocalResourceObject("Fac.Text"), "0"));

                        DropDownList1.DataSource = (Dictionary<string, decimal>) Session["fac_datasource"];
                        DropDownList1.DataTextField = "key";
                        DropDownList1.DataValueField = "Value";

                        DropDownList1.DataBind();
                        //DropDownList1.SelectedIndex = (int)Session["fac"];
                    }
                }
                else
                {
                    if (Session["fac"] != null)
                    {
                        if ((int)Session["fac"] != 0)
                        {

                            DropDownList1.Items.Clear();

                            DropDownList1.Items.Add(new ListItem((string)GetLocalResourceObject("Fac.Text"), "0"));

                            DropDownList1.DataSource = ResultsUtility.GetFaculties();
                            DropDownList1.DataTextField = "key";
                            DropDownList1.DataValueField = "Value";

                            DropDownList1.DataBind();
                            DropDownList1.SelectedIndex = (int)Session["fac"];


                            if ((int)Session["year"] != 0)
                            {
                                DropDownList2.Items.Clear();

                                DropDownList2.Items.Add(new ListItem((string)GetLocalResourceObject("Year.Text"), "0"));
                                DropDownList2.DataSource = ResultsUtility.GetYears(decimal.Parse(DropDownList1.SelectedValue));
                                DropDownList2.DataTextField = "key";
                                DropDownList2.DataValueField = "Value";
                                DropDownList2.DataBind();
                                DropDownList2.SelectedIndex = (int)Session["year"];
                            }
                            nidtd.Visible = (bool)Session["nidtd"];
                            acidtd.Visible = (bool)Session["acidtd"];
                        }
                    }
                    else
                    {
                        DropDownList1.Items.Clear();

                        DropDownList1.Items.Add(new ListItem((string)GetLocalResourceObject("Fac.Text"), "0"));

                        DropDownList1.DataSource = ResultsUtility.GetFaculties();
                        DropDownList1.DataTextField = "key";
                        DropDownList1.DataValueField = "Value";

                        DropDownList1.DataBind();
                        //DropDownList1.SelectedIndex = (int)Session["fac"];
                    }
                }
                SeatnoTextBox1.Text = null;
                nidTextBox1.Text = null;
            }

        }


        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    Global.M_dc.Dispose();
        //    new PortalDataContextDataContext().Dispose();
        //}


        protected void Button1_Click(object sender, EventArgs e)
        {


            //digitlbl.Text = null;
            var dc = Global.M_dc;

            #region Search while Seatno Is Null
            if (SeatnoTextBox1.Text == "")
            {
                
               
                    var q = ResultsUtility.GetStd_info(null, nidTextBox1.Text,
                        Decimal.Parse(DropDownList1.SelectedValue),
                        int.Parse(DropDownList2.SelectedValue));

                    STFormView.DataSource = q;
                    STFormView.DataBind();
                    HiddenField pay_flag = (HiddenField)STFormView.FindControl("paystate");
                    if (pay_flag != null)
                    {
                        if (decimal.Parse(pay_flag.Value) == 1)
                        {
                            ResultsListView.Items.Clear();

                            ResultsListView.DataSource = ResultsUtility.GetResult_info(null, nidTextBox1.Text,
                                Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));

                            ResultsListView.DataBind();
                            ResultsListView.Visible = true;
                            totallabel.Visible = true;
                            nulllabel.Visible = false;
                        }
                        else
                        {
                            ResultsListView.Visible = false;
                            totallabel.Visible = false;
                            blocklabel.Visible = true;
                            nulllabel.Visible = false;


                        }
                    }
                    else
                    {
                        ResultsListView.Visible = false;
                        totallabel.Visible = false;
                        blocklabel.Visible = false;
                        nulllabel.Visible = true;
                    }
                    //digitlbl.Visible = false;
                

            }
#endregion
            #region Search while Nationalno Is Null
            else if (nidTextBox1.Text == "")
            {
                
                //var x = new Regex(@"^\d{9}$", RegexOptions.None);
                //bool t = x.IsMatch(SeatnoTextBox1.Text);
               
                //if (t )
                //{
                    var q = ResultsUtility.GetStd_info(Decimal.Parse(SeatnoTextBox1.Text), null,
                        Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));
                    STFormView.DataSource = q;
                    STFormView.DataBind();
                    HiddenField pay_flag = (HiddenField) STFormView.FindControl("paystate");
                    if (pay_flag != null)
                    {
                        if (decimal.Parse(pay_flag.Value) == 1)
                        {
                            ResultsListView.Items.Clear();
                            ResultsListView.DataSource =
                                ResultsUtility.GetResult_info(Decimal.Parse(SeatnoTextBox1.Text),
                                    null,
                                    Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));

                            ResultsListView.DataBind();
                            ResultsListView.Visible = true;
                            totallabel.Visible = true;
                            nulllabel.Visible = false;
                        }
                        else
                        {
                            ResultsListView.Visible = false;

                            blocklabel.Visible = true;
                            totallabel.Visible = false;
                            nulllabel.Visible = false;
                        }
                    }
                    else
                    {
                        ResultsListView.Visible = false;
                        blocklabel.Visible = false;
                        nulllabel.Visible = true;
                        totallabel.Visible = false;
                    }
                    //digitlbl.Visible = false;
                //}
                //else
                //{
                //    ResultsListView.Visible = false;
                //    totallabel.Visible = false;
                //    blocklabel.Visible = false;
                //    nulllabel.Visible = false;
                //    digitlbl.Text = "رقم الجلوس يجب ان يكون بحد اقصي 9 (ارقام فقط).";
                //    digitlbl.Visible = true;
                //}
            }
#endregion
            #region Search With All Inputs

            

            
            else
            {
                
                    var q = ResultsUtility.GetStd_info(Decimal.Parse(SeatnoTextBox1.Text), nidTextBox1.Text,
                        Decimal.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));
                    STFormView.DataSource = q;
                    STFormView.DataBind();
                    HiddenField pay_flag = (HiddenField) STFormView.FindControl("paystate");
                    if (pay_flag != null)
                    {
                        if (decimal.Parse(pay_flag.Value) == 1)
                        {
                            ResultsListView.Items.Clear();
                            ResultsListView.DataSource =
                                ResultsUtility.GetResult_info(Decimal.Parse(SeatnoTextBox1.Text),
                                    nidTextBox1.Text, Decimal.Parse(DropDownList1.SelectedValue),
                                    int.Parse(DropDownList2.SelectedValue));

                            ResultsListView.DataBind();
                            ResultsListView.Visible = true;
                            totallabel.Visible = true;
                            nulllabel.Visible = false;
                        }
                        else
                        {
                            ResultsListView.Visible = false;

                            blocklabel.Visible = true;
                            totallabel.Visible = false;
                            nulllabel.Visible = false;
                        }
                    }
                    else
                    {
                        ResultsListView.Visible = false;
                        totallabel.Visible = false;
                        blocklabel.Visible = false;
                        nulllabel.Visible = true;
                    }
                    //digitlbl.Visible = false;
                
            }

            #endregion
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeatnoTextBox1.Text = null;
            nidTextBox1.Text = null;

            if (ResultsUtility.Getis_Mis_or_ext(decimal.Parse(DropDownList1.SelectedValue)) == 1)
            {

                nidtd.Visible = true;
                acidtd.Visible = true;
                Session["nidtd"] = true;
                Session["acidtd"] = true;
            }
            else
            {

                nidtd.Visible = false;
                acidtd.Visible = true;
                Session["nidtd"] = false;
                Session["acidtd"] = true;


            }
            DropDownList2.Items.Clear();

            DropDownList2.Items.Add(new ListItem((string)GetLocalResourceObject("Year.Text"), "0"));
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
            Session["fac"] = DropDownList1.SelectedIndex;
            Session["year"] = DropDownList2.SelectedIndex;

        }

        protected void Timer1_OnTick(object sender, EventArgs e)
        {
            Session["fac_datasource"] = ResultsUtility.GetFaculties();
            //Session["year_datasource"] = ResultsUtility.GetYears(decimal.Parse(DropDownList1.SelectedValue));
        }

        
    }
}