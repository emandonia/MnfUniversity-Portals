#region imports

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using App_Code;
using Portal_DAL;

#endregion imports

public partial class Admin_Create_Roles : PageBase
{
    #region page load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //List<aspnet_Role>  roles = (from x in dc.aspnet_Roles select x).ToList();
            //GridView1.DataSource = Prtl_RolesUtility .GetAllRoles() ;
            //GridView1.DataBind();
        }
    }

    #endregion page load

    #region cancel edit

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;

        GridView1.DataBind();
    }

    #endregion cancel edit

    #region Update a Role

    protected void UpdateRecord(object sender, GridViewUpdateEventArgs e)
    {
        //To get the selected row and its contents.
        var row = GridView1.Rows[e.RowIndex];

        //gets a specific control (Dropdownlist, textbox and label) inside the selected row .
        var DropDownList1 = (DropDownList)row.FindControl("DropDownList1");
        var txtRole = (TextBox)row.FindControl("txtRole");
        var LblRoleID = (Label)row.FindControl("LblRoleID");

        // to get an instance of the data context.
        var dc = new PortalDataContextDataContext();

        try
        {
            //search for the selected role by roleid.
            aspnet_Role role =
                (from x in dc.aspnet_Roles where x.RoleId.ToString() == LblRoleID.Text select x).SingleOrDefault();

            //Get the applicationid from the dropdownlist.
            var g = new Guid(DropDownList1.SelectedValue);
            /*If a role is found then update the applicationid of this role to the selected value from the dropdownlist
            and update the role name to the text in the textbox control in the gridview.*/
            if (role != null)
            {
                role.ApplicationId = g;

                role.RoleName = txtRole.Text;
                role.LoweredRoleName = txtRole.Text.ToLower();
            }

            //save the changes made so far.
            dc.SubmitChanges();

            //at last reset the selected index to null and binds the gridview .
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        catch (Exception)
        {
        }
    }

    #endregion Update a Role

    #region Delete a Role

    protected void DeleteRecord(object sender, GridViewDeleteEventArgs e)
    {
        var row = GridView1.Rows[e.RowIndex];

        //gets the role name.
        var txtRole = (Label)row.FindControl("LblRoleName");

        //  Label LblRoleID = (Label)row.FindControl("LblRoleID");
        var dc = new PortalDataContextDataContext();

        try
        {
            //deletes the selected role and binds the gridview.
            if (!Roles.GetUsersInRole(txtRole.Text).Any())
            {
                Roles.DeleteRole(txtRole.Text);
                GridView1.DataSourceID = null;
                GridView1.DataSource = (from x in dc.aspnet_Roles select x).ToList();
                GridView1.DataBind();
            }
            else
            {
                LblMsg.Text = "you can't delete this role .";
            }
        }

        catch (SqlException)
        {
        }
    }

    #endregion Delete a Role

    #region Insert new Role

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert"))
        {
            //gets the new role name from the footer row.
            var txtRole = GridView1.FooterRow.FindControl("txtRole") as TextBox;

            //if a role name is not empty then create a new role with the inserted name.
            if (txtRole != null) Roles.CreateRole(txtRole.Text);

            //at last bind the gridview after the changes has been made and hide the footer.
            GridView1.DataBind();
            GridView1.ShowFooter = false;
        }
    }

    #endregion Insert new Role

    #region Show Footer Row Button

    protected void Button1_Click1(object sender, EventArgs e)
    {
        // to show the footer row to the user for inserting new role.
        GridView1.ShowFooter = true;
    }

    #endregion Show Footer Row Button
}