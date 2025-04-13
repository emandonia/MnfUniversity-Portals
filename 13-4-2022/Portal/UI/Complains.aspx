<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="Complains.aspx.cs" Inherits="MnfUniversity_Portals.UI.Complains" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<asp:Label ID="Label6" runat="server" Text="برجاء العلم ان هذه الصفحة لإرسال الشكاوي والمقترحات المتعلقة بمشروعات التطوير بالجامعات (ICTP) وشكرا" Font-Bold="true" Font-Size="Larger" ForeColor="blue"></asp:Label>

    </br></br>
<table style="width:100%">
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="name" meta:resourcekey="name"> </asp:Label>
</td>
<td>
<asp:TextBox ID="txtName" CssClass="textboxservice2" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label2" runat="server" Text="mobile" meta:resourcekey="mobile"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtMobile" CssClass="textboxservice2" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label3" runat="server" Text="Email" meta:resourcekey="Email"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server" CssClass="textboxservice2"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label4" runat="server" Text="Complain" meta:resourcekey="complain"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtComp" CssClass="textboxservice2" runat="server" TextMode="MultiLine" Height="199px" Width="396px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComp" ForeColor="red" ErrorMessage="*"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Button ID="Button1" runat="server" CssClass="login_button" OnClick="Button1_Click" Text="Send" meta:resourcekey="Send" />
</td>
</tr>
<tr><td>
<asp:Label ID="sentlabel" runat="server" ForeColor="red" Text=""></asp:Label>
</td></tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>