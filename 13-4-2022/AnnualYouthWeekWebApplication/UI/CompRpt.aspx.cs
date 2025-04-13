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
    public partial class CompRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            object q1 = null; object q2 = null; object q3 = null; object q4 = null;
            // ReportParameter UniName;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UI/CompRpt.rdlc");
            if (!CheckBox1.Checked && DropDownList1.SelectedIndex != -1)
            {
                q1 = CompanionsUtilty.GetcompByUniName(DropDownList1.SelectedItem.Text);


                var ds2 = new ReportDataSource("DataSet1", q1);

                ReportViewer1.LocalReport.DataSources.Add(ds2);

                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {

                q1 = CompanionsUtilty.Getcomps();

                var ds2 = new ReportDataSource("DataSet1", q1);

                ReportViewer1.LocalReport.DataSources.Add(ds2);

                ReportViewer1.DataBind();
                ReportViewer1.ShowPrintButton = true;
                //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                ReportViewer1.LocalReport.Refresh();


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