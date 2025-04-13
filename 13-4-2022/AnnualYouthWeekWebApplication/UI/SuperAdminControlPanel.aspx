<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuperAdminControlPanel.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.SuperAdminControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <div style="font-size: x-large;font-weight: bold">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="ControlUsers.aspx" runat="server">محرر المستخدمين</asp:HyperLink><br/><br/></div>
</asp:Content>
