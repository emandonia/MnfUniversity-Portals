<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SectorsMaster.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="MnfUniversity_Portals.UI.Calender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" OnDayRender="Calendar1_DayRender" Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
<DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
<DayStyle BackColor="#CCCCCC" />
<NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
<OtherMonthDayStyle ForeColor="#999999" />
<SelectedDayStyle BackColor="#333399" ForeColor="White" />
<TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
<TodayDayStyle BackColor="#999999" ForeColor="White" />
</asp:Calendar>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>