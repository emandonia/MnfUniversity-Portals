<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    
    <br/>
    
    <br/>
    <div style="font-size: x-large;font-weight: bold">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="UniReports.aspx" runat="server">تقارير الجامعات</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink4" NavigateUrl="HARpt.aspx" runat="server">تقارير القيادات العليا</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink6" NavigateUrl="GenInstRpt.aspx" runat="server">تقارير المشرفين العوام</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="InstRpt.aspx" runat="server">تقارير المشرفين</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink8" NavigateUrl="CompRpt.aspx" runat="server">تقارير المرافقين</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink3" NavigateUrl="ActivitiesReport.aspx" runat="server">تقارير الانشطة</asp:HyperLink><br/><br/>
    <%--<asp:HyperLink ID="HyperLink4" NavigateUrl="FieldsReport.aspx" runat="server">تقارير المجالات</asp:HyperLink><br/><br/>--%>
    <asp:HyperLink ID="HyperLink5" NavigateUrl="Cards.aspx" runat="server">الكارنيهات</asp:HyperLink><br/><br/>
        
        <asp:HyperLink ID="HyperLink7" NavigateUrl="CommitteControlPanel.aspx" runat="server">عودة إلي الرئيسية</asp:HyperLink><br/><br/>
	
    </div>
</asp:Content>
