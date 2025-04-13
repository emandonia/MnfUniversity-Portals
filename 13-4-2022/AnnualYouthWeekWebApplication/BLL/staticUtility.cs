using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;

namespace AnnualYouthWeekWebApplication.BLL
{
    public class staticUtility
    {

        public static DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["Annual_Youth_WeekConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString); SqlCommand cmd = new SqlCommand(query, con);

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
               // Response.Write(ex.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return ResultsTable;
            

        }

        public static void printdoc(ReportViewer ReportViewer1)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType,
                           out encoding, out extension, out streamids, out warnings);

            FileStream fs = new FileStream("../output.pdf",
            FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            //Open existing PDF
            Document document = new Document(PageSize.LETTER);
            PdfReader reader = new PdfReader("../output.pdf");
            //Getting a instance of new PDF writer
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
               "../Print.pdf", FileMode.Create));
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

            
        }

        public static void uploadfile1(Page page,DetailsView dv)
        {
            
            AsyncFileUpload aa = (AsyncFileUpload)dv.FindControl("AsyncFileUpload1");
            if (aa.HasFile)
            {
                string savePath = page.MapPath("~/Images/PersonalImages/");

                
                // Get the name of the file to upload.
                string fileName = aa.FileName;


                // Create the path and file name to check for duplicates.
                string pathToCheck = savePath + fileName;


                // Create a temporary file name to use for checking duplicates.
                string tempfileName = "";


                // Check to see if a file already exists with the
                // same name as the file to upload.
                if (System.IO.File.Exists(pathToCheck))
                {
                    int counter = 0;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = counter+fileName ;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }


                    fileName = tempfileName;
                    savePath += fileName;

                    aa.SaveAs(savePath);
                    page.Session["pi"] = fileName;
                    page.Session["path1"] = savePath;

                }
                else
                {
                    aa.SaveAs(savePath+fileName);
                    page.Session["pi"] = aa.FileName;
                    page.Session["path1"] = savePath + fileName;
                }
            }
            else
            {
                page.Session["pi"] = null;
                page.Session["path1"] = null;

            }
        }

        public static void uploadfile2(Page page, DetailsView dv)
        {
            
            AsyncFileUpload aa = (AsyncFileUpload)dv.FindControl("AsyncFileUpload2");
            if (aa.HasFile)
            {
                string savePath = page.MapPath("~/Images/NatIDImages/");


                // Get the name of the file to upload.
                string fileName = aa.FileName;


                // Create the path and file name to check for duplicates.
                string pathToCheck = savePath + fileName;


                // Create a temporary file name to use for checking duplicates.
                string tempfileName = "";


                // Check to see if a file already exists with the
                // same name as the file to upload.
                if (System.IO.File.Exists(pathToCheck))
                {
                    int counter = 0;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        // if a file with this name already exists,
                        // prefix the filename with a number.
                        tempfileName = counter+fileName  ;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }


                    fileName = tempfileName;
                    savePath += fileName;

                    aa.SaveAs(savePath);
                    page.Session["ni"] = fileName;
                    page.Session["path2"] = savePath;

                }
                else
                {
                    aa.SaveAs(savePath+fileName);
                    page.Session["ni"] = aa.FileName;
                    page.Session["path2"] = savePath + fileName;
                }
            }
            else
            {
                page.Session["ni"] = null;
                page.Session["path2"] = null;

            }
        }

        public static IEnumerable<University> getalluniversities()
        {
           var dc=new MyDataContext();
            var y = from x in dc.Universities select x;
            return y;
        }
    }
}