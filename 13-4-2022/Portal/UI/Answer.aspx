<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="Answer.aspx.cs" Inherits="MnfUniversity_Portals.UI.Answer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<asp:Label ID="sentlabel" runat="server" ForeColor="red" Text=""></asp:Label>
<asp:FormView ID="FormView1" runat="server" DataSourceID="DummyDataSource">
<ItemTemplate>
<table ID="Table1" runat="server">
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="الشكوي:"></asp:Label></td>
<td>
<asp:Label ID="Label2" runat="server" Text='<%#getcomp()  %>'></asp:Label>
</td>
</tr>
<tr>
<td> <asp:Label ID="Label3" runat="server" Text="الرد:"></asp:Label></td>
<td>
<asp:TextBox ID="TextBox1" TextMode="MultiLine" Height="199px" Width="396px" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="Label4" runat="server" Text="اسم صاحب الرد:"></asp:Label></td>
<td> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>
<asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="إرسال الرد" /></td>
</tr>
</table>
</ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod" TypeName="StaticUtilities"></asp:ObjectDataSource>
</ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>