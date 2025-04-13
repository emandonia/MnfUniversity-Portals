<%@ Page Title="Thesis Editor" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master"
    AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Admin.ThesisEditor" CodeBehind="ThesisEditor.aspx.cs" %>
<%--<%@ Register Src="~/UserControls/Editors/ThesisEditor/Editor/ThesisEditorUserControl.ascx" TagPrefix="uc" TagName="ThesisEditorUserControl" %>--%>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="FDDL1" runat="server" />
            <br />
              <%--<uc:ThesisEditorUserControl runat="server" ID="ThesisEditorUserControl" />--%>   </ContentTemplate>
    </asp:UpdatePanel>
    <%--asp:Button ID="Button1" runat="server" Text="View Changes" meta:resourcekey="Button1Resource4"
        CausesValidation="false" />--%>
</asp:Content>
