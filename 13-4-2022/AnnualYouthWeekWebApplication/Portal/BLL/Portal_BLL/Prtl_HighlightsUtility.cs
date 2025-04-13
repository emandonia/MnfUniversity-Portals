using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Common;
using Portal_DAL;

namespace BLL
{
    public static class Prtl_HighlightsUtility
    {
        public static void DeleteHighlight(string s)
        {
            var dc = new PortalDataContextDataContext();
            var item = dc.prtl_Highlights.Single(hl => hl.Translation_ID.ToString() == s);
            dc.prtl_Highlights.DeleteOnSubmit(item);
            dc.SubmitChanges();
        }

        public static IEnumerable<Data> GetDateAndDetails(string currentLanguage)
        {
            return (new PortalDataContextDataContext().prtl_Translations.
                Where(tr => tr.prtl_Language.LCID == currentLanguage && tr.prtl_Highlight.Translation_ID != null).
                Select(et => new Data { Details = et.Translation_Data, Date = et.prtl_Highlight.Start_Date }));
        }

        public static IEnumerable<Data> GetTopItems(string currentLanguage, int count , Guid? owner_id = null)
        {
            return new PortalDataContextDataContext().prtl_Translations.OrderByDescending(ev => ev.prtl_Highlight.Start_Date).
                Where(
                    tr => tr.prtl_Language.LCID == currentLanguage && tr.prtl_Highlight.Published && tr.prtl_Highlight.prtl_Owner.Owner_ID == owner_id &&
                          tr.prtl_Highlight.Translation_ID != null
                          && (tr.prtl_Highlight.Owner_ID.GetValueOrDefault(Guid.Empty) == owner_id.GetValueOrDefault(Guid.Empty)
                              || tr.prtl_Highlight.Owner_ID == null)).
                Select(et => new Data { HighlightId = et.prtl_Highlight.Highlight_Id, TranslationID = et.Translation_ID, Image = et.prtl_Highlight.Image, Details = et.Translation_Data, Date = et.prtl_Highlight.Start_Date })

                // This is the limit of data to be viewed
                        .Take(count);
        }

        public static void Insert(DetailsViewInsertEventArgs detailsViewInsertEventArgs, string filename, Guid? ownerid, string filterValueName, DateTime startdate, DateTime enddate,bool published)
        {

            var dc = new PortalDataContextDataContext();
            var newItem = new prtl_Highlight
                {
                    Owner_ID = ownerid,
                    Image = filename,
                    Start_Date = startdate,
                    Published = published,
                    End_Date = enddate
                };

            dc.prtl_Highlights.InsertOnSubmit(newItem);
            dc.SubmitChanges();
            detailsViewInsertEventArgs.Values[filterValueName] = newItem.Translation_ID;
        }

        public static prtl_Highlight SelectByID(int ID)
        {
            return new PortalDataContextDataContext().prtl_Highlights.SingleOrDefault(x => x.Highlight_Id == ID);
        }

        public static prtl_Highlight SelectByTransID(Guid ID)
        {
            return new PortalDataContextDataContext().prtl_Highlights.SingleOrDefault(x => x.Translation_ID == ID);
        }

        public static string UpdateItem(string filterValue, string filename, DateTime startdate, DateTime enddate)
        {
            var oldname = "";
            var dc = new PortalDataContextDataContext();
            {
                var item = dc.prtl_Highlights.Single(e => e.Translation_ID.ToString() == filterValue);
                item.Start_Date = startdate;
                item.End_Date = enddate;
                if (!string.IsNullOrEmpty(filename))
                {
                    oldname = item.Image;
                    item.Image = filename;
                }
                dc.SubmitChanges();
            }
            return oldname;
        }

        public struct Data
        {
            public DateTime Date { get; set; }

            public string Details { get; set; }

            public string Image { get; set; }

            public Guid TranslationID { get; set; }
            public int HighlightId { get; set; }
        }

        public static bool GetPublishedState(string ID)
        {
            var q = new PortalDataContextDataContext().prtl_Highlights.SingleOrDefault(x => x.Highlight_Id.ToString() == ID);
            if (q.Published )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UpdateHighlightWithPublish(int Highlightid, bool Published)
        {
            var dc = new PortalDataContextDataContext();
            {
                var Highlight = dc.prtl_Highlights.Single(a => a.Highlight_Id == Highlightid);
                Highlight.Published = Published;
                dc.SubmitChanges();
            }
        }
    }
}