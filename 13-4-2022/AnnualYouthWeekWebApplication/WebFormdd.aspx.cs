using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnnualYouthWeekWebApplication.BLL;
using Microsoft.Reporting.WebForms;

namespace AnnualYouthWeekWebApplication
{
    public partial class WebFormdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            ReportViewer1.LocalReport.Refresh();
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            var q = HigherAdminsUtility.Getadmins();
            var dss = new ReportDataSource("DataSet1", q);
            e.DataSources.Add(dss);
        }
    }
}