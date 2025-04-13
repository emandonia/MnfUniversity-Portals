using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using MnfUniversity_Portals.BLL.Portal_BLL;

namespace MnfUniversity_Portals.UI
{
    public partial class OutstandingResearches : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var FacAbbr = URLBuilder.CurrentFacAbbr(Page.RouteData);

                if (FacAbbr == null)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add(new ListItem((string)GetLocalResourceObject("Fac.Text"), "-1"));
                }
                else
                {
                    //int id = Prtl_OwnersUtility.getSPapersFacIDByAbbr(FacAbbr);
                    //DropDownList1.SelectedValue = id.ToString();
                    //DropDownList1.DataBind();
                    //DropDownList1.Enabled = false;

                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView2.Items.Clear();
            LinqDataSource2.Where = "Faculty == " + DropDownList1.SelectedValue;
            ListView2.DataBind();
            Label4.Text = NumberOfResearchesReturned();
        }

        protected void Editor_ImageButton_Click(object sender, EventArgs e)
        {
          
            var Linkbutton = (LinkButton)sender;
            
          var ds=  Prtl_ResearchesUtility.GetResearchByPaperId(Convert.ToInt32(Linkbutton.CommandArgument));
            Editor_DetailsView.DataSource = ds;
            Editor_DetailsView.DataBind();
            Editor_ModalPopupExtender.Show();
        }

        protected string NumberOfResearchesReturned()
        {
            var s = (string)GetLocalResourceObject("Researches")+" ";
            return s + Prtl_ResearchesUtility.GetResearchsCount(Convert.ToInt32(DropDownList1.SelectedValue));
        }
    }
}