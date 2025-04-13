<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="Admin_CreateUsers" CodeBehind="CreateUsers.aspx.cs" %>

<%@ Import Namespace="Common" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>   
 <asp:UpdatePanel UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" runat="server" OnSearchClicked="SearchClicked" />
            <br />
            <table style="float: <%= StaticUtilities.FloatLeft %>" dir="ltr" width="100%">
                <tr>
                    <td width="10%">&nbsp;
                    </td>
                    <td width="20%">&nbsp;
                    </td>
                    <td style="float: <%= StaticUtilities.FloatLeft %>" width="50%">&nbsp;
                    </td>
                    <td width="20%">&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        &nbsp;</td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="10%">
                        <asp:Button ID="Button2" runat="server" CssClass="_button" OnClick="Button2_Click"
                            Style="height: 26px" Text="Add New" meta:resourcekey="Button2Resource1" />
                    </td>
                    <td width="20%">&nbsp;
                    </td>
                    <td align="left" width="50%">&nbsp;
                        <asp:Label ID="LblMsg" runat="server" meta:resourcekey="LblMsgResource1"></asp:Label>
                    </td>
                    <td width="20%">&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 109px">&nbsp;
                    </td>
                    <td class="style2" style="width: 45px" nowrap="nowrap">&nbsp;
                    </td>
                    <td align="left" class="style5" style="width: 207px">
                        <asp:Label ID="LblError" runat="server"></asp:Label>
                        &nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" width="100%">
                        <asp:Panel ID="Panel5" runat="server" GroupingText="Searching Data" meta:resourcekey="Panel5Resource1">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Name" meta:resourcekey="Label1Resource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="_text" Style="margin-left: 0px"
                                            meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Role :" meta:resourcekey="Label3Resource1"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                                            DataTextField="RoleName" DataValueField="RoleId" Width="128px" meta:resourcekey="DropDownList1Resource1">
                                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource1">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="_button" OnClick="Button1_Click"
                                            Text="Search" meta:resourcekey="Button1Resource1" />
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 109px">&nbsp;
                    </td>
                    <td class="style2" style="width: 45px" nowrap="nowrap">&nbsp;
                    </td>

                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 109px">&nbsp;
                    </td>
                    <td class="style2" style="width: 45px">&nbsp;
                    </td>
                    <td class="style5" style="width: 207px">
                        <asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1"></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                            DataKeyNames="UserID" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="25"
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None"
                            meta:resourcekey="GridView1Resource1">
                            <AlternatingRowStyle BackColor="White" CssClass="grid_item"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit" ItemStyle-HorizontalAlign="left"
                                    meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Details" runat="server" CommandName="Select" meta:resourcekey="DetailsResource1">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="User Name" ItemStyle-HorizontalAlign="left"
                                    meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <%# Eval("UserName")%>
                                        <asp:Label ID="LbllID" runat="server" Text='<%# Eval("UserId") %>' Visible="False"
                                            meta:resourcekey="LbllIDResource1"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" meta:resourcekey="txtNameResource1"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Active" ItemStyle-HorizontalAlign="left"
                                    meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="LblActive" runat="server" meta:resourcekey="LblActiveResource1"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkActive" runat="server" meta:resourcekey="ChkActiveResource1" />
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="grid_footer" BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="grid_header" BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" />
                            <PagerStyle CssClass="pgr" BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle CssClass="grid_item" BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

                            <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
                            <AlternatingRowStyle CssClass="grid_item" BackColor="White" />
                            <RowStyle CssClass="grid_item" BackColor="White" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="style6" style="width: 109px">&nbsp;
                    </td>
                    <td class="style2" style="width: 45px">&nbsp;
                    </td>
                    <td class="style5" style="width: 207px">&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="5">
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CssClass="grid_all"
                            GridLines="Horizontal" Height="50px" OnDataBound="DetailsView1_DataBound" Visible="False"
                            Width="50%" CellPadding="4" ForeColor="#333333" meta:resourcekey="DetailsView1Resource1">
                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                            <EditRowStyle BackColor="white" />
                            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                            <Fields>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Name" ItemStyle-HorizontalAlign="Left"
                                    SortExpression="Name" meta:resourcekey="TemplateFieldResource4">
                                    <EditItemTemplate>
                                        <asp:Label ID="LblUserName" runat="server" Text='<%# Bind("aspnet_User.UserName") %>'
                                            Visible="False" meta:resourcekey="LblUserNameResource1"></asp:Label>
                                        <asp:Label ID="LblUserId" runat="server" Text='<%# Bind("UserId") %>' Visible="False"
                                            meta:resourcekey="LblUserIdResource1"></asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("aspnet_User.UserName") %>'
                                            meta:resourcekey="txtNameResource2"></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("aspnet_User.UserName") %>'
                                            meta:resourcekey="txtNameResource3"></asp:TextBox>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("aspnet_User.UserName")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Password" ItemStyle-HorizontalAlign="Left"
                                    SortExpression="Password" meta:resourcekey="TemplateFieldResource5">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' TextMode="Password" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' TextMode="Password" meta:resourcekey="txtPasswordResource2"></asp:TextBox>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("Password")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Roles" ItemStyle-HorizontalAlign="Left"
                                    meta:resourcekey="TemplateFieldResource6">
                                    <EditItemTemplate>
                                        <asp:CheckBoxList ID="ChekListRole" runat="server" DataTextField="RoleName"
                                            DataValueField="RoleId" meta:resourcekey="ChekListRoleResource2">
                                        </asp:CheckBoxList>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:CheckBoxList ID="ChekListRole" runat="server" DataTextField="RoleName"
                                            DataValueField="RoleId" meta:resourcekey="ChekListRoleResource3">
                                        </asp:CheckBoxList>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="ChekListRole" runat="server" DataSourceID="LDSRoles1" DataTextField="RoleName"
                                            DataValueField="RoleId" meta:resourcekey="ChekListRoleResource1">
                                        </asp:CheckBoxList>
                                        <asp:LinqDataSource ID="LDSRoles1" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                                            TableName="aspnet_Roles" EntityTypeName="">
                                        </asp:LinqDataSource>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Active" ItemStyle-HorizontalAlign="Left"
                                    meta:resourcekey="TemplateFieldResource7">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# Bind("IsLockedOut") %>'
                                            meta:resourcekey="ChkActiveResource2" />
                                        <asp:Label ID="LblActive" runat="server" Text='<%# Bind("IsLockedOut") %>' Visible="False"
                                            meta:resourcekey="LblActiveResource3"></asp:Label>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:CheckBox ID="ChkActive" runat="server" Checked='<%# Bind("IsLockedOut") %>'
                                            meta:resourcekey="ChkActiveResource3" />
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("IsLockedOut")%>
                                        <asp:Label ID="LblActive" runat="server" Text='<%# Bind("IsLockedOut") %>' meta:resourcekey="LblActiveResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    ShowHeader="False" meta:resourcekey="TemplateFieldResource8">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnmodfy" runat="server" OnClick="btnmodfy_Click" Text="Update"
                                            meta:resourcekey="btnmodfyResource1"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="btncancel" runat="server" CausesValidation="False" OnClick="btncancel_Click"
                                            Text="Cancel" meta:resourcekey="btncancelResource1"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:LinkButton ID="btndeadd" runat="server" OnClick="btndeadd_Click" Text="Add"
                                            meta:resourcekey="btndeaddResource1"></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" OnClick="LinkButton4_Click"
                                            Text="Cancel" meta:resourcekey="LinkButton4Resource1"></asp:LinkButton>
                                    </InsertItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Fields>
                            <AlternatingRowStyle CssClass="grid_alternating" BackColor="White" />
                            <PagerStyle BackColor="white" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle CssClass="grid_item" HorizontalAlign="left" BackColor="#EFF3FB" />
                            <FooterStyle CssClass="grid_footer" Font-Size="Medium" HorizontalAlign="left" BackColor="#507CD1"
                                Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="grid_header" HorizontalAlign="left" BackColor="#507CD1" Font-Bold="True"
                                ForeColor="White" />
                        </asp:DetailsView>
                        <asp:LinqDataSource ID="GetDetails" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                            TableName="aspnet_Memberships" Where="UserId == @UserId" EntityTypeName="">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="UserId" PropertyName="SelectedValue" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>