using App_Code;
using MnfUniversity_Portals.BLL.Portal_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Common;
using MisBLL;
    public partial class GraduateStudents : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FacDropDownList.DataSource = Prtl_OwnersUtility.getFac(StaticUtilities.Currentlanguage(Page));

                FacDropDownList.DataBind();
            }



                
          
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string StuNameA = txtNameA.Text;
            string StuNameE = txtNameE.Text;
            string Tel = txtTel.Text;
            string mobile = txtMob.Text;
            string Grade = txtgrad.Text;
            string Email = txtEmail.Text;
            string currentJob = txtjob.Text;
            string course = txtcources.Text;
            string Adress = txtAdd.Text;
            string Year = txtyear.Text;
            string WorkPlace = txtplace.Text;
            string Skills = txtskill.Text;
            int University = Convert.ToInt32(dropUni.SelectedValue);
            int FacID = Convert.ToInt32(FacDropDownList.SelectedValue);
            int DepID = Convert.ToInt32(DepDropDownList.SelectedValue);

            gradeUtility.insertGrade(StuNameA, StuNameE, Tel, mobile, Grade, Email, currentJob, course, Adress, Year, WorkPlace, Skills, University, FacID, DepID);


            lblMsg.Text = "تم الادخال بنجاح";
            panel1.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DropDownList1.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DropDownList2.DataSource = Prtl_OwnersUtility.getDepsOfFac(Convert.ToInt32(DropDownList1.SelectedValue), StaticUtilities.Currentlanguage(Page));

            DropDownList2.DataTextField = "Key";
            DropDownList2.DataValueField = "Value";


            DropDownList2.DataBind();
        }

        protected void FacDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FacDropDownList.SelectedValue) != -1)
            {
                DepDropDownList.Enabled = true;
            }
            DepDropDownList.Items.Clear();
            DepDropDownList.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDropDownList.DataSource = Prtl_OwnersUtility.getDepsOfFac(Convert.ToInt32(FacDropDownList.SelectedValue), StaticUtilities.Currentlanguage(Page));

            DepDropDownList.DataTextField = "Key";
            DepDropDownList.DataValueField = "Value";


            DepDropDownList.DataBind();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

            panel3.Visible = false;
            panel4.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            panel1.Visible = false;
            panel2.Visible = true ;


            DropDownList1.DataSource = Prtl_OwnersUtility.getFac(StaticUtilities.Currentlanguage(Page));

            DropDownList1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            

            panel4.Visible = true;
            panel1.Visible = false;
            DetailsView1.Visible = true;
            int fac = Convert.ToInt32(DropDownList1.SelectedValue);
            int dep = Convert.ToInt32(DropDownList2.SelectedValue);
            string n = txtName.Text;

            //get All
            if (DropDownList1.SelectedValue == "-1" && DropDownList2.SelectedValue == "-1" && txtName.Text == "")
            {

                DetailsView1.DataSource = gradeUtility.getsBu();
                DetailsView1.DataBind();



            }
            //get by fac and department and name
            if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtName.Text != "")
            {

                DetailsView1.DataSource = gradeUtility.getsBfdn(fac, dep, n);
                DetailsView1.DataBind();
               

                
            }//search by fac and name
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtName.Text != "")
            {
                DetailsView1.DataSource = gradeUtility.getsBfn(fac, n);
                DetailsView1.DataBind();
               
            }//search by name
            else if (DropDownList1.SelectedValue == "-1" && DropDownList2.SelectedValue == "-1" && txtName.Text != "")
            {
                DetailsView1.DataSource = gradeUtility.getsBn(n);
                DetailsView1.DataBind();
                
            }//by fac
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue == "-1" && txtName.Text == "")
            {
                DetailsView1.DataSource = gradeUtility.getsBf(fac);
                DetailsView1.DataBind();
               
            }//by fac and depaertment
            else if (DropDownList1.SelectedValue != "-1" && DropDownList2.SelectedValue != "-1" && txtName.Text == "")
            {
                DetailsView1.DataSource = gradeUtility.getsBfd(fac, dep);
                DetailsView1.DataBind();
                
            }
            Session["db"] = DetailsView1.DataSource;

        }


        protected void btnmodfy_Click(object sender, EventArgs e)
    {
        try
        {
            string StuNameA = DetailsView1.GetControl<TextBox>("StuNameA").Text .ToString()  ;
            string StuNameE = DetailsView1.GetControl<TextBox>("StuNameE").Text.ToString();
            string Adress = DetailsView1.GetControl<TextBox>("Adress").Text.ToString();
            string Tel = DetailsView1.GetControl<TextBox>("Tel").Text.ToString();
            string Email = DetailsView1.GetControl<TextBox>("Email").Text.ToString();
            string Grade = DetailsView1.GetControl<TextBox>("Grade").Text.ToString();
            string WorkPlace = DetailsView1.GetControl<TextBox>("WorkPlace").Text.ToString();
            string Skills = DetailsView1.GetControl<TextBox>("Skills").Text.ToString();
            string mobile = DetailsView1.GetControl<TextBox>("mobile").Text.ToString();
            string currentJob = DetailsView1.GetControl<TextBox>("currentJob").Text.ToString();
            string course = DetailsView1.GetControl<TextBox>("course").Text.ToString();
            string Year = DetailsView1.GetControl<TextBox>("Year").Text.ToString();


            int FacDrop =Convert .ToInt32 ( DetailsView1.GetControl<DropDownList >("FacDrop") .SelectedValue );
            int DepDrop =Convert .ToInt32 ( DetailsView1.GetControl<DropDownList >("DepDrop").SelectedValue );

            

            int iDHide =Convert .ToInt32 ( DetailsView1.GetControl<HiddenField>("iDHide").Value );

            if (FacDrop == -1 || DepDrop == -1)
            {
                gradeUtility.updateGrade(iDHide, StuNameA, StuNameE, Tel, mobile, Grade, Email, currentJob, course, Adress, Year, WorkPlace, Skills, 1, null , null);

            }
            else
            {
                gradeUtility.updateGrade(iDHide, StuNameA, StuNameE, Tel, mobile, Grade, Email, currentJob, course, Adress, Year, WorkPlace, Skills, 1, FacDrop, DepDrop);

            } 
            
            lblMsg.Text = "تم التعديل بنجاح";
                DetailsView1 .Visible =false;
              }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    

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

        protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
       
        if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
        {
            //hides the password field.
           
            var facdrop = DetailsView1.GetControl<DropDownList>("FacDrop");
            facdrop.DataSource = Prtl_OwnersUtility.getFac(StaticUtilities.Currentlanguage(Page));
            facdrop.DataBind();


            var f=DetailsView1 .GetControl <HiddenField >("fachide1").Value ;
            facdrop .SelectedValue = f.ToString ();


           
            var DepDrop = DetailsView1.GetControl<DropDownList>("DepDrop");
            var d=DetailsView1 .GetControl <HiddenField >("Dephide1").Value ;
            DepDrop.SelectedValue = d.ToString();
        }
        else
            if (DetailsView1.CurrentMode == DetailsViewMode.Insert)
            {
                //DetailsView1.Fields[1].Visible = true;
                //var ChekListRole = DetailsView1.GetControl<CheckBoxList>("ChekListRole");
                //FillRolesControl(ChekListRole);
            }
    }

        protected void FacDrop_SelectedIndexChanged(object sender, EventArgs e)
        {


            int Dephide2 = Convert .ToInt32 (DetailsView1.GetControl<HiddenField >("Dephide1").Value );

            var DepDrop = DetailsView1.GetControl<DropDownList>("DepDrop");
            var FacDrop = DetailsView1.GetControl<DropDownList>("FacDrop");
            if (Convert.ToInt32(FacDrop.SelectedValue) != -1)
            {
                DepDrop.Enabled = true;
            }
            DepDrop.Items.Clear();
            DepDrop.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            DepDrop.DataSource = Prtl_OwnersUtility.getDepsOfFac(Convert.ToInt32(FacDrop.SelectedValue), StaticUtilities.Currentlanguage(Page));

            DepDrop.DataTextField = "Key";
            DepDrop.DataValueField = "Value";
           

            DepDrop.DataBind();
         //   DepDrop.SelectedValue = Dephide2.ToString ();
       DepDrop.SelectedValue = Session["Dephide1"].ToString();
        }

        protected void FacDrop_DataBinding(object sender, EventArgs e)
        {
             string fachide1 = "";

            //if (DetailsView1.GetControl<HiddenField>("fachide1").Value != null || DetailsView1.GetControl<HiddenField>("fachide1").Value != "")
            //{
            fachide1 = Convert.ToString(DetailsView1.GetControl<HiddenField>("fachide1").Value);

            DropDownList FacDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("FacDrop"));

            FacDrop.SelectedValue = fachide1.ToString();
            //    Session["fachide2"] = fachide1;
            //}
            //else
            //{
            //    DropDownList FacDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("FacDrop"));

            //    FacDrop.SelectedValue = "-1";
            //}
        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsView1.PageIndex = e.NewPageIndex;
            DetailsView1.DataSource = Session["db"];
	DetailsView1.DataBind();
        }

        protected void DepDrop_DataBinding(object sender, EventArgs e)
        {
               DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));

            if (DetailsView1.GetControl<HiddenField>("Dephide2").Value != null || DetailsView1.GetControl<HiddenField>("Dephide2").Value != "-1")
            {

                DepDrop.SelectedValue = (DetailsView1.GetControl<HiddenField>("Dephide2").Value).ToString();
            }
            else
            {
                DepDrop.SelectedValue = "-1";
            }
            
            //Session["Dephide1"] = Dephide1;




            //string Dephide1 = "";

            //DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));

            ////DepDrop.Enabled = true;

            //DepDrop.Items.Clear();
            //DepDrop.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));

            //DropDownList FacDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("FacDrop"));

            //int x = Convert.ToInt32(FacDrop.SelectedValue);
            //DepDrop.DataSource = Prtl_OwnersUtility.getDepsOfFac(x, StaticUtilities.Currentlanguage(Page));

            //DepDrop.DataTextField = "Key";
            //DepDrop.DataValueField = "Value";


            //DepDrop.DataBind();
            
           //// if (DetailsView1.GetControl<HiddenField>("Dephide1").Value != "" || DetailsView1.GetControl<HiddenField>("Dephide1").Value != null)
           //// {
           //  Dephide1 = Convert.ToString(DetailsView1.GetControl<HiddenField>("Dephide1").Value);
           ////  DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));
           //  DepDrop.SelectedValue = Dephide1;
           ////     Session["Dephide1"] = Dephide1;
           //// }
           //// else
           //// {
           ////    // DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));
           ////     DepDrop.SelectedValue = "-1";
           //// }
           ////// DepDrop.SelectedValue = Dephide1.ToString();
        }

        protected void DetailsView1_DataBinding(object sender, EventArgs e)
        {
            if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
            {
               
                //var facdrop = DetailsView1.GetControl<DropDownList>("FacDrop");
                //var f = DetailsView1.GetControl<HiddenField>("fachide1").Value;
                //facdrop.SelectedValue = f.ToString();



                //var DepDrop = DetailsView1.GetControl<DropDownList>("DepDrop");
               var d = DetailsView1.GetControl<HiddenField>("Dephide1").Value;
                //DepDrop.SelectedValue = d.ToString();

                string fachide1 = "";

                if (DetailsView1.GetControl<HiddenField>("fachide1").Value != "" || DetailsView1.GetControl<HiddenField>("fachide1").Value != null)
                {
                    fachide1 = Convert.ToString(DetailsView1.GetControl<HiddenField>("fachide1").Value);

                    DropDownList FacDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("FacDrop"));

                    FacDrop.SelectedValue = fachide1.ToString();
                    Session["fachide1"] = fachide1;
                }
                else
                {
                    DropDownList FacDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("FacDrop"));

                    FacDrop.SelectedValue = "-1";
                }


                string Dephide1 = "";

                DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));

                DepDrop.Enabled = true;

                DepDrop.Items.Clear();
                DepDrop.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
                DepDrop.DataSource = Prtl_OwnersUtility.getDepsOfFac(Convert.ToInt32(Session["fachide1"]), StaticUtilities.Currentlanguage(Page));

                DepDrop.DataTextField = "Key";
                DepDrop.DataValueField = "Value";


                DepDrop.DataBind();


                if (DetailsView1.GetControl<HiddenField>("Dephide1").Value != null || DetailsView1.GetControl<HiddenField>("Dephide1").Value != "")
                {
                    Dephide1 = Convert.ToString(DetailsView1.GetControl<HiddenField>("Dephide1").Value);
                 //   DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));
                    DepDrop.SelectedValue = Dephide1;
                    Session["Dephide1"] = Dephide1;
                }
                else
                {
                   // DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));
                    DepDrop.SelectedValue = "-1";
                }
            }
        }

        protected   object getSource(int ID, string lang)
        {
            DropDownList DepDrop = (DropDownList)(DetailsView1.GetControl<DropDownList>("DepDrop"));

            if (ID != -1)
            {
                DepDrop.Enabled = true;
            }
            DepDrop.Items.Clear();
            DepDrop.Items.Add(new ListItem((string)GetLocalResourceObject("choose.Text"), "-1"));
            
            DepDrop.DataTextField = "Key";
            DepDrop.DataValueField = "Value";
            return  Prtl_OwnersUtility.getDepsOfFac(ID, StaticUtilities.Currentlanguage(Page));

           


          //  DepDrop.DataBind();
        }

        
    }
