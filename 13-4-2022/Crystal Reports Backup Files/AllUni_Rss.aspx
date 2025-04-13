<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="AllUni_Rss.aspx.cs" Inherits="MnfUniversity_Portals.UI.AllUni_Rss" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../Styles/University_Master/css/Links.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:Label ID="Label1" runat="server" Text="خدمة عرض اخبار الجامعات المصرية" meta:resourcekey="title" CssClass="classs5"></asp:Label>
<br /><br />
<%--<asp:HyperLink ID="HyperLink1" runat="server"  Target ="_self"  ></asp:HyperLink>--%>
<asp:FormView ID="FormView2" runat="server" align="center" DataSourceID="DummyDataSource">
<ItemTemplate>
<table class="links" dir='<%=StaticUtilities.Dir %>'>
<tr>
<ul class="vv">
<li><asp:HyperLink ID="HyperLink1" runat="server" Target="iframe" Text="جامعة المنوفية" meta:resourcekey="facName1"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink2" runat="server" Target="iframe" Text="جامعة طنطا" meta:resourcekey="facName2"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink3" runat="server" Target="iframe" Text="جامعة القاهرة" meta:resourcekey="facName3"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink4" runat="server" Target="iframe" Text="جامعة اسوان" meta:resourcekey="facName4"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink5" runat="server" Target="iframe" Text="جامعة المنيا" meta:resourcekey="facName5"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink6" runat="server" Target="iframe" Text="جامعة بنها" meta:resourcekey="facName6"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink7" runat="server" Target="iframe" Text="جامعة اسيوط" meta:resourcekey="facName7"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink8" runat="server" Target="iframe" Text="جامعة قناة السويس" meta:resourcekey="facName8"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink9" runat="server" Target="iframe" Text="جامعة بورسعيد" meta:resourcekey="facName9"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink10" runat="server" Target="iframe" Text="جامعة كفرالشيخ" meta:resourcekey="facName10"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink11" runat="server" Target="iframe" Text="جامعة جنوب الوادى" meta:resourcekey="facName11"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink12" runat="server" Target="iframe" Text="جامعة المنصورة" meta:resourcekey="facName12"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink13" runat="server" Target="iframe" Text="جامعة سوهاج" meta:resourcekey="facName13"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink14" runat="server" Target="iframe" Text="جامعة السادات" meta:resourcekey="facName14"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink15" runat="server" Target="iframe" Text="جامعة الزقازيق" meta:resourcekey="facName15"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink16" runat="server" Target="iframe" Text="جامعة دمياط" meta:resourcekey="facName16"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink17" runat="server" Target="iframe" Text="جامعة الفيوم" meta:resourcekey="facName17"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink18" runat="server" Target="iframe" Text="جامعة عين شمس" meta:resourcekey="facName18"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink19" runat="server" Target="iframe" Text="جامعة الاسكندرية" meta:resourcekey="facName19"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink20" runat="server" Target="iframe" Text="جامعة حلوان" meta:resourcekey="facName20"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink21" runat="server" Target="iframe" Text="جامعة دمنهور" meta:resourcekey="facName21"> </asp:HyperLink></li>
<li><asp:HyperLink ID="HyperLink22" runat="server" Target="iframe" Text="جامعة بنى سويف" meta:resourcekey="facName22"> </asp:HyperLink></li>
</ul>
<td>
<iframe name="iframe" id="iframe" class="bb" width="700" height="900" src="http://mu.menofia.edu.eg/NewsRSS/ar"></iframe>
</td>
</tr>
</table>
</ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod" TypeName="StaticUtilities"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>