<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.DepStaff" CodeBehind="DepStaff.aspx.cs" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<asp:Label ID="Label3" runat="server" BackColor="#6699FF" Text="برجاء ادخال اسم العضو او الكلية او القسم ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"></asp:Label>
<br/><br/>
<div align="center">
<table class="staffsearchtable" style="width:400px">
<tr>
<td>
<asp:Label ID="Label5" runat="server" Text="Enter Staff Name:" meta:resourcekey="NameLabelResource1"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
</td>
<td>
<asp:DropDownList AppendDataBoundItems="true" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
<asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
</asp:DropDownList>
<asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
<SelectParameters>
<asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
</SelectParameters>
</asp:ObjectDataSource>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label2" runat="server" Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
</td>
<td>
<asp:DropDownList ID="DepDropDownList" Enabled="false" DataTextField="DepName" DataValueField="ID" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="DepDropDownList_SelectedIndexChanged">
<asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td colspan="2" style="float:<%=StaticUtilities.FloatLeft%>">
<asp:Button class="btn" ID="Button1" runat="server" Text="Search" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" />
</td>
</tr>
</table>
<asp:ListView ID="ListView1" runat="server">
<LayoutTemplate>
<table id="Table1" runat="server" border="0" width="100%">
<tr id="Tr1" runat="server">
<td id="Td1" runat="server">
<table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style="font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr3" runat="server">
<th id="Th2" runat="server"><asp:Label ID="Label10" runat="server" Text="Name" meta:resourcekey="StaffNameLabelResource1"></asp:Label></th>
<th id="Th1" runat="server">
<asp:Label ID="Label9" runat="server" Text="Job" meta:resourcekey="StaffJobLabelResource1"></asp:Label></th>
<th id="Th3" runat="server"><asp:Label ID="Label11" runat="server" Text="Department" meta:resourcekey="StaffDepLabelResource1"></asp:Label></th>
<th id="Th4" runat="server"><asp:Label ID="Label12" runat="server" Text="Faculty" meta:resourcekey="StaffFacLabelResource1"></asp:Label></th>
</tr>
<tr id="itemPlaceholder" runat="server">
</tr>
</table>
</td>
</tr>
</table>
</LayoutTemplate>
<ItemTemplate>
<tr>
<td class="col1">
<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#StaffUrl(Eval("Abbr").ToString())%>' Text='<%#Eval("Name")%>'></asp:HyperLink>
</td>
<td class="col2"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("Job")%>'></asp:Label></td>
<td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%#Eval("DepName")%>'></asp:Label></td>
<td class="col4"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("FacName")%>'></asp:Label></td>
</tr>
</ItemTemplate>
<EmptyDataTemplate>
<table id="Table2" runat="server" style="background-color:#fff;border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr id="Tr2" runat="server">
<td id="Td3" runat="server" meta:resourcekey="NoStaffFound">No Staff Data Found
</td>
</tr>
</table>
</EmptyDataTemplate>
</asp:ListView>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>