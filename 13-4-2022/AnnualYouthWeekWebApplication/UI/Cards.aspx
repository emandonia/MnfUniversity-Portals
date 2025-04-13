<%@ Page Title="Title" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cards.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.Cards" %>
<asp:Content runat="server" ID="Meta" ContentPlaceHolderID="meta"></asp:Content>
<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContentPlaceHolder">
    
    
    
    
    
     <br/>
    
    <br/>
    <div style="font-size: x-large;font-weight: bold">
         <asp:HyperLink ID="HyperLink4" NavigateUrl="GenSpvReport.aspx" runat="server">كارنيهات المشرفين العوام</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="SpvReport.aspx" runat="server">كارنيهات المشرفين</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink5" NavigateUrl="CompReport.aspx" runat="server">كارنيهات المرافقين</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink3" NavigateUrl="StudentsReports.aspx" runat="server">كارنيهات الطلاب</asp:HyperLink><br/><br/>
       
    
   
   
        <asp:HyperLink ID="HyperLink2" NavigateUrl="Reports.aspx" runat="server">عودة إلي التقارير</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink7" NavigateUrl="CommitteControlPanel.aspx" runat="server">عودة إلي الرئيسية</asp:HyperLink><br/><br/>
	
    </div>
</asp:Content>


