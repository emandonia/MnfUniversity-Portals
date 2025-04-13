using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;
using AnnualYouthWeekWebApplication.UniDataSetTableAdapters;
using Microsoft.Reporting.WebForms;
using PrintReportSample;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class StudentsReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UniID"] != null)
            {
                if (Convert.ToInt32(Session["UniID"]) == 3)
                {
                    DropDownList1.Enabled = true;
                    //CheckBox1.Enabled = true;
                }
                else
                {
                    DropDownList1.SelectedValue = Convert.ToInt32(Session["UniID"]).ToString();
                    DropDownList1.Enabled = false;
                    //CheckBox1.Enabled = false;
                }
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            if (TextBox1.Enabled && TextBox1.Text != "")
            {
               


                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UI/StudentReport.rdlc");
                ReportViewer1.LocalReport.EnableExternalImages = true;
                string imagePath = new Uri(Server.MapPath("~/Images/PersonalImages/")).AbsoluteUri;
                ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
                ReportViewer1.LocalReport.SetParameters(parameter);
                var qq = GetData("SELECT  Students.ID, Students.Stu_Name, Students.National_ID, Students.Gender, Students.Birth_Date, Students.Birth_Place, Students.phone_no, Students.Email, Students.Address," +
                                 "  Students.Personal_Image , Students.NatID_Image, Students.SerialNo, Universities.University_Name, Fields.Field_Name, Activities.Activity_Name, Faculties.Faculty, Years.Year FROM         Students INNER JOIN Universities ON Students.University_id = Universities.ID INNER JOIN Fields ON Students.Field_id = Fields.ID INNER JOIN Activities ON Fields.Activity_id = Activities.ID INNER JOIN Faculties ON Students.Faculty_ID = Faculties.ID INNER JOIN Years ON Students.Year_ID = Years.ID AND Faculties.ID = Years.Fac_id WHERE  (Students.Stu_Name = '" + TextBox1.Text + "')");
                ReportViewer1.LocalReport.DataSources.Clear();
                var dss = new ReportDataSource("DataSet1", qq);
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (DropDownList1.SelectedIndex != -1)
            {



                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UI/StudentReport.rdlc");
                ReportViewer1.LocalReport.EnableExternalImages = true;
                string imagePath = new Uri(Server.MapPath("~/Images/PersonalImages/")).AbsoluteUri;
                ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
                ReportViewer1.LocalReport.SetParameters(parameter);
                var qq = GetData("SELECT Students.ID, Students.Stu_Name, Students.National_ID, Students.Gender, Students.Birth_Date, Students.Birth_Place," +
                             " Students.phone_no, Students.Email, Students.Address,  Students.Personal_Image ," +
                            " Students.NatID_Image, Students.SerialNo, Universities.University_Name, Fields.Field_Name, Activities.Activity_Name, Faculties.Faculty, Years.Year FROM Students INNER JOIN Universities ON Students.University_id = Universities.ID INNER JOIN Fields ON Students.Field_id = Fields.ID INNER JOIN Activities ON Fields.Activity_id = Activities.ID INNER JOIN Faculties ON Students.Faculty_ID = Faculties.ID INNER JOIN Years ON Students.Year_ID = Years.ID AND Faculties.ID = Years.Fac_id WHERE (Students.University_id = " + DropDownList1.SelectedValue + ")");
                ReportViewer1.LocalReport.DataSources.Clear();
                var dss = new ReportDataSource("DataSet1", qq);
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.LocalReport.Refresh();

           
            }
        }
        public DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["Annual_Youth_WeekConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);SqlCommand cmd = new SqlCommand(query,con); 
            
            DataTable ResultsTable = new DataTable();
            try
    {
           
            
                
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@id", 1);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ResultsTable);
    }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return ResultsTable;
                //using (SqlDataAdapter sda = new SqlDataAdapter())
                //{
                //    cmd.Connection = con;

                //    sda.SelectCommand = cmd;
                //    using (Student dsCustomers = new Student())
                //    {
                //        sda.Fill(dsCustomers, "DataTable1");
                //        return dsCustomers;
                //    }
               //}
            
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            ReportPrintDocument rp = new ReportPrintDocument(ReportViewer1.LocalReport);
            rp.Print();
        }

        protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "-1")
            {
                TextBox1.Enabled = true;
            }
            else
            {
                TextBox1.Enabled = false;
            }
        }
    }
}