using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MnfUniversity_Portals.UserControls.Editors.Base;
using Portal_DAL;

namespace MnfUniversity_Portals.UserControls.Viewers
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:LoggingViewer runat=server></{0}:LoggingViewer>")]
    public class LoggingViewer : ListViewBasedUserControl
    {
        protected override string DetailsViewBasedName
        {
            get { return ""; }
        }

        protected override string FilterSessionName
        {
            get { return "LoggingOwner_ID"; }
        }

        protected override string ListViewLinqDataSourceName
        {
            get { return "LoggingLinqDataSource"; }
        }

        protected override string ListViewName
        {
            get { return "LoggingListView"; }
        }

        protected override void ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
        }

        protected void ListViewLinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = Prtl_LoggingUtility.GetActoinLogs(FilterOwnerID).OrderByDescending(i => i.OperationDateTime);
        }

        protected override IEnumerable<prtl_Language> NotTranslatedLangs(object data, string abbr = null)
        {
            return null;
        }

        protected override int TranslationCount(object data, string abbr = null)
        {
            return 0;
        }

        protected override bool Published(object data, string abbr = null)
        {
            throw new System.NotImplementedException();
        }
    }
}