<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" CodeBehind="ResearchesEditor.aspx.cs"
     Inherits="MnfUniversity_Portals.UI.Admin.ResearchesEditor" %>

<asp:Content ID="Content8" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" runat="server" />
            <br />
           <%--<uc:ResearchesEditorControl ID="ResearchesEditorr" runat="server"></uc:ResearchesEditorControl>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
</asp:Content>

