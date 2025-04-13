<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LibraryMaster.Master" AutoEventWireup="true" CodeBehind="infoHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.infoHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
        <img  src="<%= getImage() %>"  />
               <%-- <<img src="/Styles/University_Master/images/10721445_876929532317496_225504342_n.jpg" />--%>
    
    <%--ImageUrl="/Styles/University_Master/images/10721445_876929532317496_225504342_n.jpg"--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
