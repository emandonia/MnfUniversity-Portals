<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="MnfUniversity_Portals.UserControls.Common.FilterDropControl" CodeBehind="FilterDropControl.ascx.cs" %>
<table width="100%">
    <tr>
        <td style="text-align: <%= StaticUtilities.FloatLeft%>">
            <asp:Label ID="ChooseOwnerLabel" runat="server" Text="Choose Owner:" Width="160px"
                Visible="False"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="OwnerTypeDropDownList" DataTextField="Text" DataValueField="Value"
                OnSelectedIndexChanged="OwnerTypeDropDownList_SelectedIndexChanged" AutoPostBack="True"
                runat="server" Width="150px" AppendDataBoundItems="True" Visible="False">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: <%= StaticUtilities.FloatLeft%>">
            <asp:Label ID="ChooseFacultyLabel" runat="server" Text="Choose Faculty:" Width="160px"
                meta:resourcekey="ChooseFacultyLabelResource1"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="FacultyDropDownList" DataTextField="Text" DataValueField="Value"
                AppendDataBoundItems="true" OnSelectedIndexChanged="FacDropDown_SelectedIndexChanged"
                AutoPostBack="True" runat="server" Width="150px" meta:resourcekey="FacultyDropDownListResource1">
                <asp:ListItem>Choose Faculty</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: <%= StaticUtilities.FloatLeft%>">
            <asp:Label ID="ChooseDepartmentLabel" runat="server" Text="Choose Department:" Width="160px"
                meta:resourcekey="ChooseDepartmentLabelResource1"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DeparmentDropDownList" runat="server" AppendDataBoundItems="true"
                DataTextField="Text" DataValueField="Value" Width="150px" meta:resourcekey="DeparmentDropDownListResource1">
                <asp:ListItem>Choose Department</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click"
                meta:resourcekey="ButtonSearchResource1" />
        </td>
    </tr>
</table>