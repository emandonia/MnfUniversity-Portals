#region imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using App_Code;
using BLL;
using Common;
using Portal_DAL;

// ReSharper disable EmptyGeneralCatchClause

#endregion imports

public partial class Admin_CreateUsers : PageBase
{
    #region Page Load

    private IEnumerable<aspnet_User> AspnetUsers
    {
        get
        {
            var Users = Prtl_UsersUtility.GetAllAspUsers();

            var userids = Prtl_OwnerAdminUsersUtility.GetUserIDsInOwner(Drop1.GetFilteredOwner_ID).ToList();
            if (Drop1.FacultySelected)
            {
                foreach (
                    var prtlDepartment in
                        Prtl_OwnersUtility.GetSubOwnersByOwnerID(Drop1.GetFilteredOwner_ID))
                    userids.AddRange(Prtl_OwnerAdminUsersUtility.GetUserIDsInOwner(prtlDepartment.Owner_ID));

                Users = Users.Join(userids, u => u.UserId, u => u, (u, g) => u).ToList();
            }
            var facroles = new[] { PageRoles.FacAdmin, PageRoles.DepAdmin, PageRoles.DepCoAdmin, PageRoles.FacCoAdmin };
            var deproles = new[] { PageRoles.DepCoAdmin, PageRoles.DepAdmin };

            //if supper admin logged
            if (User.Identity.Name.ToLower() != StaticUtilities.Superadmin)

                //if fac admin logged
                if (Roles.IsUserInRole(User.Identity.Name, PageRoles.FacAdmin.ToString()))
                    Users = Users.Where(x => facroles.Any(f => Roles.IsUserInRole(x.UserName, f.ToString()))).ToList();
                else if (Roles.IsUserInRole(User.Identity.Name, PageRoles.DepAdmin.ToString()))
                    Users = Users.Where(x => deproles.Any(f => Roles.IsUserInRole(x.UserName, f.ToString()))).ToList();
            return Users;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var roles = Enum.GetValues(typeof(PageRoles));
            foreach (var role in roles.Cast<object>().Where(role => !Roles.RoleExists(role.ToString())))
            {
                Roles.CreateRole(role.ToString());
            }
            GridView1.DataSource = AspnetUsers;
            GridView1.DataBind();
            FillRolesControl(DropDownList1);
        }
    }

    #endregion Page Load

    #region Search Button

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<aspnet_User> users = null;

        //if no role is selected and a user name is entered then search for All users that contain this name.
        if (TextBox1.Text != "" && DropDownList1.SelectedValue == "-1")
        {
            users = AspnetUsers.Where(x => x.LoweredUserName.Contains(TextBox1.Text)).ToList();
        }

        //else if no user name is enterd and a role is selected then search for all users in this role.
        else if (TextBox1.Text == "" && DropDownList1.SelectedValue != "-1")
        {
            //creates a new list to store users found in it.
            users = Roles.GetUsersInRole(DropDownList1.SelectedItem.Text).
               Select(xx => (AspnetUsers.Where(
               x => xx != null && x.UserName == xx)).SingleOrDefault()).
               Where(user => user != null).ToList();
        }

        // else if a user name is entered and a role is selected then search for this user in this role.
        else if (TextBox1.Text != "" && DropDownList1.SelectedValue != "-1")
        {
            users = new List<aspnet_User>();

            //loops throught the role and stores any user that contains the entered name in the users list.
            aspnet_User user = AspnetUsers.Where(x => x.UserName.ToLower().Contains(TextBox1.Text)).SingleOrDefault();
            if (user != null && Roles.IsUserInRole(user.UserName, DropDownList1.SelectedItem.Text))
                users.Add(user);
        }

        //empty the gridview before binding it.
        GridView1.DataSourceID = null;

        //if one or more users are found then set the datasource of the gridview to the users list.
        GridView1.DataSource = users;
        GridView1.DataBind();
        if (users != null && users.Count != 0)
            LblMsg.Text = "";
        else

            // display a message incase no user is found.
            LblMsg.Text = (string)GetLocalResourceObject("Sorry_No_Result_to_view");
    }

    #endregion Search Button

    #region display user info

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //display the user found from the search process in the gridview
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var id = e.Row.GetControl<Label>("LbllID");
            var LblActive = e.Row.GetControl<Label>("LblActive");

            var xxx = Prtl_UsersUtility.GetMemberShipuserByID(id.Text);
            if (xxx != null)
            {
                if (xxx.IsLockedOut)
                {
                    LblActive.Text = (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_False");
                }
                else if (xxx.IsLockedOut == false)
                {
                    LblActive.Text = (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_True");
                }
            }
        }
    }

    #endregion display user info

    #region show detailsview in edit mode

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //To display the user info in the detailsview in editing mode.
        try
        {
            if (GridView1.SelectedDataKey != null)
            {
                var g = (Guid)GridView1.SelectedDataKey.Value;

                List<aspnet_Membership> xx = Prtl_UsersUtility.GetMemberShipuserByID(g);
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                DetailsView1.Visible = true;
                DetailsView1.Fields[1].Visible = true;
                DetailsView1.DataSource = xx;
                DetailsView1.DataBind();
            }
        }
        catch
        {
        }
    }

    #endregion show detailsview in edit mode

    #region details

    private bool IsUserDepAdmin
    {
        get { return Roles.IsUserInRole(User.Identity.Name, PageRoles.DepAdmin.ToString()); }
    }

    private bool IsUserFacAdmin
    {
        get { return Roles.IsUserInRole(User.Identity.Name, PageRoles.FacAdmin.ToString()); }
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        //display user info
        if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
        {
            //hides the password field.
            DetailsView1.Fields[1].Visible = false;
            var LblActive = DetailsView1.GetControl<Label>("LblActive");
            if (LblActive == null) return;
            var LblUserName = DetailsView1.GetControl<Label>("LblUserName");
            var ChkActive1 = DetailsView1.GetControl<CheckBox>("ChkActive");
            if (LblActive.Text == (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_False"))
            {
                LblActive.Text = (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_True");
                ChkActive1.Checked = true;
            }
            else if (LblActive.Text == (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_True"))
            {
                LblActive.Text = (string)GetLocalResourceObject("Admin_CreateUsers_GridView1_RowDataBound_False");
                ChkActive1.Checked = false;
            }

            var ChekListRole = DetailsView1.GetControl<CheckBoxList>("ChekListRole");
            FillRolesControl(ChekListRole);
            foreach (var role in Roles.GetRolesForUser(LblUserName.Text))
                ChekListRole.Items.FindByText(role).Selected = true;
        }
        else
            if (DetailsView1.CurrentMode == DetailsViewMode.Insert)
            {
                DetailsView1.Fields[1].Visible = true;
                var ChekListRole = DetailsView1.GetControl<CheckBoxList>("ChekListRole");
                FillRolesControl(ChekListRole);
            }
    }

    private void FillRolesControl(DataBoundControl control)
    {
        var excludedFacultyRoles = new List<string>(new[] {
                    PageRoles.FacAdmin, PageRoles.UniAdmin, PageRoles.StaffRole
            }.Select(r => r.ToString().ToLower()).ToList()) { StaticUtilities.Superadmin };
        var excludedDepartmentRoles = new List<string>(excludedFacultyRoles) { PageRoles.DepAdmin.ToString().ToLower() };
        if (Roles.IsUserInRole(User.Identity.Name, StaticUtilities.Superadmin))
            control.DataSource = Prtl_AspNetUtility.GetAllRoles();
        else if (IsUserFacAdmin)
            control.DataSource =
                Prtl_AspNetUtility.GetAllRoles().Where(x => !excludedFacultyRoles.Contains(x.LoweredRoleName)).OrderBy(s => s.LoweredRoleName);
        else if (IsUserDepAdmin)
            control.DataSource =
                Prtl_AspNetUtility.GetAllRoles().Where(
                    x => !excludedDepartmentRoles.Contains(x.LoweredRoleName)).OrderBy(s => s.LoweredRoleName);
        control.DataBind();
    }

    #endregion details

    private OwnerTypes GetOwnerType
    {
        get { return StaticUtilities.GetOwnerType(Prtl_OwnersUtility.GetOwnerByOwnerID(Drop1.GetFilteredOwner_ID).Abbr); }
    }

    protected void SearchClicked(object sender, EventArgs e)
    {
        GridView1.DataSource = AspnetUsers;
        GridView1.DataBind();
    }

    private void AddUserToCoRoles(string username)
    {
        if (GetOwnerType == OwnerTypes.University)
        {
            Roles.AddUserToRole(username, PageRoles.UniCoAdmin.ToString());
        }
        else
            if (GetOwnerType == OwnerTypes.Department)
            {
                Roles.AddUserToRole(username, PageRoles.DepCoAdmin.ToString());
            }
            else if (GetOwnerType == OwnerTypes.Faculty && !Roles.IsUserInRole(username, PageRoles.DepAdmin.ToString()))
            {
                Roles.AddUserToRole(username, PageRoles.FacCoAdmin.ToString());
            }
    }

    #region add new user

    protected void btndeadd_Click(object sender, EventArgs e)
    {
        //add new user

        try
        {
            var txtName = DetailsView1.GetControl<TextBox>("txtName");
            var txtPassword = DetailsView1.GetControl<TextBox>("txtPassword");
            var ChekListRole = DetailsView1.GetControl<CheckBoxList>("ChekListRole");
            
            var user = Prtl_UsersUtility.GetAspUser(txtName.Text);
            if (user == null)
            {

                Membership.CreateUser(txtName.Text, txtPassword.Text);
          
                Prtl_UsersUtility.InsertUserInOwner(Drop1.GetFilteredOwner_ID, txtName.Text);
            
           
                var listRoles = ChekListRole.Items.Cast<ListItem>().Where(item => item.Selected).Select(
                    item => new Guid(item.Value)).ToList();

                foreach (var x in listRoles.Where(x => user != null))
                    Prtl_UsersUtility.InsertNewUserInRole(x, user.UserId);
                AddUserToCoRoles(txtName.Text);
                GridView1.DataSource = AspnetUsers;
                GridView1.DataBind();
                DetailsView1.Visible = false;
                LblMsg.Text =
                    (string) GetLocalResourceObject("Admin_CreateUsers_btndeadd_Click_Thanks_Add_Sucessfully_");
                Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "User Insert Operation", "aspnet_User");
            }
            else
            {
                LblError.Text = (string)GetLocalResourceObject("LblErrorMsgResource1");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            LblMsg.Text = ex.ToString();
        }
    }

    #endregion add new user

    #region cancel add

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

    #endregion cancel add

    #region update user

    protected void btnmodfy_Click(object sender, EventArgs e)
    {
        try
        {
            var txtName = DetailsView1.GetControl<TextBox>("txtName");
            var ChekListRole = DetailsView1.GetControl<CheckBoxList>("ChekListRole");
            var ChkActive1 = DetailsView1.GetControl<CheckBox>("ChkActive");
            var LblUserId = DetailsView1.GetControl<Label>("LblUserId");
            Prtl_UsersUtility.UpdateUser(ChkActive1, txtName, Guid.Parse(LblUserId.Text), ChekListRole);
            DetailsView1.Visible = false;
            GridView1.DataSource = AspnetUsers;
            GridView1.DataBind();
            LblMsg.Text = (string)GetLocalResourceObject("Admin_CreateUsers_btnmodfy_Click_Thanks_Update_Sucessfully");
            Prtl_LoggingUtility.InsertNewActionLog(Page.User.Identity.Name, "User Update Operation", "aspnet_User");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    #endregion update user

    #region cancel edit

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = false;
        }
        catch
        {
        }
    }

    #endregion cancel edit

    #region show detailsview to insert new user

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Fields[1].Visible = true;
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }
        catch
        {
        }
    }

    #endregion show detailsview to insert new user

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
     GridView1.PageIndex = e.NewPageIndex;
     GridView1.DataSource = AspnetUsers;
        GridView1.DataBind();
 

    }
}