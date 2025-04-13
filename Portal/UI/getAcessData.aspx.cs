using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnfUniversity_Portals.UI
{
    public partial class getAcessData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strquery = "SELECT * FROM userdetails";
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12;" + @"DATA SOURCE=D:\Database2.accdb"))
            {
                using (cmd = new OleDbCommand(strquery, con))
                {
                    OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
                    Da.Fill(ds);
                }
            }
            //gvDetails.DataSource = ds;
            //gvDetails.DataBind();
        }
    }
}