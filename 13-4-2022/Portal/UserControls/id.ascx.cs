using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(DropDownList1.SelectedValue.ToString()) == 1 || int.Parse(DropDownList1.SelectedValue.ToString()) == 4 || int.Parse(DropDownList1.SelectedValue.ToString()) == 18)
        {
            Response.Redirect("first.aspx?id=" + this.TextBox1.Text + "&dept=" + this.DropDownList1.SelectedValue.ToString());
        }
        else if (int.Parse(DropDownList1.SelectedValue.ToString()=2 ||int.Parse(DropDownList1.SelectedValue.ToString()=5 ||int.Parse(DropDownList1.SelectedValue.ToString()=8 ||int.Parse(DropDownList1.SelectedValue.ToString()=9 ||int.Parse(DropDownList1.SelectedValue.ToString()=16))
        {
            Response.Redirect("second.aspx?id=" + this.TextBox1.Text + "&dept=" + this.DropDownList1.SelectedValue.ToString());
        }
        else
        {
            Response.Redirect("wait.aspx");
        }
    }
    protected void dept_bound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("اختر القسم", "0"));
    }
}