<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master"
    AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Admin.SPapersEditor" ValidateRequest="false" CodeBehind="SPapersEditor.aspx.cs" %>

<%--<%@ Register Src="~/UserControls/Editors/SCPapersEditor/Editor/SCPapersEditorControl.ascx" TagPrefix="uc" TagName="SCPapersEditorControl" %>--%>





<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" runat="server" />
            <br />
            <%--<uc:SCPapersEditorControl runat="server" ID="SCPapersEditorControl" />--%>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>