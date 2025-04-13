<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Admin.LoggingViewer" CodeBehind="LoggingRecord.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" OnSearchClicked="handlesearch" runat="server" />
            <br />
            <table>
                <tr>
                    <td dir="ltr">
                        <asp:Label ID="Label1" runat="server" Text="Choose User:"
                            Width="160px" meta:resourcekey="ChooseUserLabelResource1"></asp:Label>
                    </td>
                    <td dir="ltr">
                        <asp:DropDownList ID="UsersDropDown" DataTextField="UserName" DataValueField="UserId" Width="150px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" OnClick="viewlistview" runat="server" Text="view logs" /></td>
                </tr>
            </table>
            <uc:LoggingViewer ID="LoggingViewer1" Visible="false" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>