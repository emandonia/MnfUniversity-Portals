<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="DepSubjects.aspx.cs" Inherits="MnfUniversity_Portals.UI.DepSubjects" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MisBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:ListView ID="ListView1" runat="server">
<LayoutTemplate>
<table id="Table1" runat="server">
<tr id="Tr1" runat="server">
<td id="Td1" runat="server">
<table id="groupPlaceholderContainer" class="stafftable" border="0" width="100%" runat="server" style="font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr3" runat="server">
<th id="Th1" runat="server">
<asp:Label ID="Label1" runat="server" Text="Subject Code" meta:resourcekey="SubjectCodeLabelResource1"></asp:Label></th>
<th id="Th2" runat="server"><asp:Label ID="Label2" runat="server" Text="Subject Name" meta:resourcekey="SubjectNameLabelResource1"></asp:Label></th>
<th id="Th4" runat="server"><asp:Label ID="Label5" runat="server" Text="Subject Name"></asp:Label></th>
<th id="Th3" runat="server"><asp:Label ID="Label3" runat="server" Text="Year" meta:resourcekey="SubjectYearLabelResource1"></asp:Label></th>
</tr>
<tr id="itemPlaceholder" runat="server">
</tr>
</table>
</td>
</tr>
</table>
</LayoutTemplate>
<ItemTemplate>
<tr> <div style="width:100%">
<td class="col1"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("SUBJECT_CODE")%>'></asp:Label></td>
<td class="col2">
<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="blue" NavigateUrl='<%#getSubjectUrl(Eval("ED_SUBJECT_ID"))%>' Text='<%#Eval("SUBJECT_DESCR_AR")%>'></asp:HyperLink>
</td>
<td class="col1"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("SUBJECT_DESCR_EN")%>'></asp:Label></td>
<td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%# SubjectUtility.GetSubjectYear(Convert.ToDecimal(Eval("ED_SUBJECT_ID")))%>'></asp:Label></td>
</div> </tr>
</ItemTemplate>
<EmptyDataTemplate>
<table id="Table2" runat="server" style="background-color:#fff;border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr id="Tr2" runat="server">
<td id="Td3" runat="server">
<asp:Label ID="Label4" runat="server" Text="No Subjects Data Found" meta:resourcekey="NoSubjectFoundLabelResource1"></asp:Label>
</td>
</tr>
</table>
</EmptyDataTemplate>
</asp:ListView>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>