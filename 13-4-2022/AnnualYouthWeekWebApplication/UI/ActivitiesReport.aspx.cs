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
    public partial class ActivitiesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UniID"] != null)
            {
                if (Convert.ToInt32(Session["UniID"]) == 3)
                {
                    DropDownList1.Enabled = true;
                    CheckBox1.Enabled = true;
                }
                else
                {
                    DropDownList1.SelectedValue = Convert.ToInt32(Session["UniID"]).ToString();
                    DropDownList1.Enabled = false;
                    CheckBox1.Enabled = false;
                }
            }
        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            object q1 = null; object q2 = null; object q3 = null; object q4 = null;
            ReportParameter UniName;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ActivitiesReport.rdlc");
            //نشاط محدد وجامعة محددة
            if (!CheckBox2.Checked && !CheckBox1.Checked)
            {
               
                q1 = InstructorsUtility.getInstByActnameanduniname(DropDownList2.SelectedItem.Text,DropDownList1.SelectedItem.Text);
                
                var ds2 = new ReportDataSource("InstDataSet", q1);
               
                ReportViewer1.LocalReport.DataSources.Add(ds2);
                
                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();
            }
             
                //كل الانشطة لجامعة محددة
            else if (CheckBox2.Checked && DropDownList1.SelectedValue != "-1")
            {
                q1 = InstructorsUtility.GetinstByuniName(DropDownList1.SelectedItem.Text);

                var ds2 = new ReportDataSource("InstDataSet", q1);

                ReportViewer1.LocalReport.DataSources.Add(ds2);

                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();

            }
                //نشاط محدد لكل الجامعات
            else if (CheckBox1.Checked && DropDownList2.SelectedValue != "-1")
            {
                q1 = InstructorsUtility.GetinstByActName(DropDownList2.SelectedItem.Text);

                var ds2 = new ReportDataSource("InstDataSet", q1);

                ReportViewer1.LocalReport.DataSources.Add(ds2);

                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();

            }
            //كل الانشطة لكل الجامعات
            if (CheckBox2.Checked && CheckBox1.Checked)
            {
                q1 = InstructorsUtility.getInst();
              

                var ds2 = new ReportDataSource("InstDataSet", q1);
                
                ReportViewer1.LocalReport.DataSources.Add(ds2);

                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();
            }



        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
           // //كل الانشطة لكل الجامعات
           // if (!CheckBox2.Checked && !CheckBox1.Checked)
           // {

            var uniname = e.Parameters["UniName"].Values[0];
            // var ActName = e.Parameters["ActName"].Values[0];
            var FieldName = e.Parameters["FieldName"].Values[0];
            var q3 = StudentsUtilty.GetStudentByByActnameanduniname(uniname, FieldName);
            var ds3 = new ReportDataSource("DataSet1", q3);


            //var q = StudentsUtilty.GetStudentByUniId(Convert.ToInt32(DropDownList1.SelectedValue));
            //var dss = new ReportDataSource("StuDataSet", q3);
            e.DataSources.Add(ds3);
                
           // }
           ////نشاط محدد وجامعة محددة
           // else if (!CheckBox2.Checked && !CheckBox1.Checked)
            
           // {
           //     var uniname = e.Parameters["UniName"].Values[0];
           //     var FieldName = e.Parameters["FieldName"].Values[0];
           //     var q3 = StudentsUtilty.GetStudentByByFieldnameanduniname(uniname, FieldName);
           //     var ds3 = new ReportDataSource("DataSet1", q3);


           //     //var q = StudentsUtilty.GetStudentByUniId(Convert.ToInt32(DropDownList1.SelectedValue));
           //     //var dss = new ReportDataSource("StuDataSet", q3);
           //     e.DataSources.Add(ds3);
           // }
           //     //كل الانشطة لجامعة محددة
           // else if (CheckBox2.Checked && DropDownList1.SelectedIndex != -1)
           // {
           //     var uniname = e.Parameters["UniName"].Values[0];
           //     var FieldName = e.Parameters["FieldName"].Values[0];
           //     var q3 = StudentsUtilty.GetStudentByByFieldnameanduniname(uniname, FieldName);
           //     var ds3 = new ReportDataSource("DataSet1", q3);


           //     //var q = StudentsUtilty.GetStudentByUniId(Convert.ToInt32(DropDownList1.SelectedValue));
           //     //var dss = new ReportDataSource("StuDataSet", q3);
           //     e.DataSources.Add(ds3);

           // }
           //  //نشاط محدد لكل الجامعات
           // else if (CheckBox1.Checked && DropDownList2.SelectedIndex != -1)
           // {
           // }
        }

        protected void CheckBox2_OnCheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                DropDownList2.SelectedIndex = -1;
                DropDownList2.Enabled = false;

            }
            else
            {
                DropDownList2.Enabled = true;
            }
        }
        protected void CheckBox1_OnCheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                DropDownList1.SelectedIndex = -1;
                DropDownList1.Enabled = false;

            }
            else
            {
                DropDownList1.Enabled = true;
            }
        }
        protected void Button2_OnClick(object sender, EventArgs e)
        {
            //ReportPrintDocument rp = new ReportPrintDocument(ReportViewer1.LocalReport);
            //rp.Print();

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
    }
}