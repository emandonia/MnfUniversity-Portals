<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="VotingEditor" ValidateRequest="false" CodeBehind="VotingEditor.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" runat="server" />
            <br />
            <uc:VotingEditorControl ID="VotingEditorControl1" runat="server">
            </uc:VotingEditorControl>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>