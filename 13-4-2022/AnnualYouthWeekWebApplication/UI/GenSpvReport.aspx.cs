using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;

namespace AnnualYouthWeekWebApplication.UI
{
    public partial class GenSpvReport : System.Web.UI.Page
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



                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UI/GenSpvCard.rdlc");
                ReportViewer1.LocalReport.EnableExternalImages = true;
                string imagePath = new Uri(Server.MapPath("~/Images/PersonalImages/")).AbsoluteUri;
                ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
                ReportViewer1.LocalReport.SetParameters(parameter);
                var qq = staticUtility.GetData("SELECT     General_Instructors.Gen_Inst_Name, General_Instructors.National_ID, General_Instructors.Gender, General_Instructors.Birth_Date, General_Instructors.Birth_Place, General_Instructors.Address," +
                                               " General_Instructors.ID, General_Instructor_Types.Gen_Inst_Type, General_Instructors.SerialNo,General_Instructors.Personal_Image, Universities.University_Name" +
                                               " FROM    General_Instructors INNER JOIN General_Instructor_Types ON General_Instructors.General_inst_type = " +
                                               "General_Instructor_Types.ID INNER JOIN Universities ON General_Instructors.University_id = Universities.ID WHERE" +
                                               "  (General_Instructors.Gen_Inst_Name = '" + TextBox1.Text + "')");
                ReportViewer1.LocalReport.DataSources.Clear();
                var dss = new ReportDataSource("DataSet1", qq);
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.LocalReport.Refresh();
            }
            else if (DropDownList1.SelectedIndex != -1)
            {



                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UI/GenSpvCard.rdlc");
                ReportViewer1.LocalReport.EnableExternalImages = true;
                string imagePath = new Uri(Server.MapPath("~/Images/PersonalImages/")).AbsoluteUri;
                ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
                ReportViewer1.LocalReport.SetParameters(parameter);
                var qq = staticUtility.GetData("SELECT     General_Instructors.Gen_Inst_Name, General_Instructors.National_ID, General_Instructors.Gender, General_Instructors.Birth_Date, General_Instructors.Birth_Place, General_Instructors.Address," +
                                               " General_Instructors.ID, General_Instructor_Types.Gen_Inst_Type,General_Instructors.Personal_Image, General_Instructors.SerialNo, Universities.University_Name" +
                                               " FROM    General_Instructors INNER JOIN General_Instructor_Types ON General_Instructors.General_inst_type = " +
                                               "General_Instructor_Types.ID INNER JOIN Universities ON General_Instructors.University_id = Universities.ID WHERE" +
                                               "  (General_Instructors.University_id =" + DropDownList1.SelectedValue + ")");
                ReportViewer1.LocalReport.DataSources.Clear();
                var dss = new ReportDataSource("DataSet1", qq);
                ReportViewer1.LocalReport.DataSources.Add(dss);
                ReportViewer1.LocalReport.Refresh();


            }
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType,
                           out encoding, out extension, out streamids, out warnings);

            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("output.pdf"),
            FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            //Open existing PDF
            Document document = new Document(PageSize.LETTER);
            PdfReader reader = new PdfReader(HttpContext.Current.Server.MapPath("output.pdf"));
            //Getting a instance of new PDF writer
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
               HttpContext.Current.Server.MapPath("Print.pdf"), FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;

            int i = 0;
            int p = 0;
            int n = reader.NumberOfPages;
            iTextSharp.text.Rectangle psize = reader.GetPageSize(1);

            float width = psize.Width;
            float height = psize.Height;

            //Add Page to new document
            while (i < n)
            {
                document.NewPage();
                p++;
                i++;

                PdfImportedPage page1 = writer.GetImportedPage(reader, i);
                cb.AddTemplate(page1, 0, 0);
            }

            //Attach javascript to the document
            PdfAction jAction = PdfAction.JavaScript("this.print(true);\r", writer);
            writer.AddJavaScript(jAction);
            document.Close();

            frmPrint.Attributes["src"] = "Print.pdf";
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