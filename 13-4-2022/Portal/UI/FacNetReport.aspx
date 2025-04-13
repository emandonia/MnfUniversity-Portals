<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LibraryMaster.Master" AutoEventWireup="true" CodeBehind="FacNetReport.aspx.cs" Inherits="MnfUniversity_Portals.UI.Admin.FacNetReport" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
    
    <div style="float: none;" align="center">

       <%-- <table style="width: 200px;font-weight: bold">
    <tr><td colspan="2" style="text-align: center">
        نموذج عرض الاعطال بالكليات</td></tr>
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server"  Text="اختر الكلية:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="FacDropDownList"   runat="server" CssClass="textboxservice2">
                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                    <asp:ListItem Value="22">كلية الحاسبات والمعلومات</asp:ListItem>
                    <asp:ListItem Value="5">كلية الهندسة الإلكترونية</asp:ListItem>
                    <asp:ListItem Value="4">كلية الاداب</asp:ListItem>
                    <asp:ListItem Value="24">كلية العلوم</asp:ListItem>
                    <asp:ListItem Value="23">كلية الهندسة</asp:ListItem>
                    <asp:ListItem Value="25">كلية التجارة</asp:ListItem>
                    <asp:ListItem Value="39">كلية الحقوق</asp:ListItem>
                    <asp:ListItem Value="43">كلية الطب</asp:ListItem>
                    <asp:ListItem Value="42">كلية الاقتصاد المنزلي</asp:ListItem>
                    <asp:ListItem Value="30">كلية التربية</asp:ListItem>
                    <asp:ListItem Value="41">كلية التربية النوعية</asp:ListItem>
                    <asp:ListItem Value="31">كلية التمريض</asp:ListItem>
                    <asp:ListItem Value="40">كلية الزراعة</asp:ListItem>
                    <asp:ListItem Value="38">معهد الكبد </asp:ListItem>
                    <asp:ListItem Value="4659">المستشفيات الجامعية</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FacDropDownList" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr><tr><td><asp:Button ID="Button1" runat="server" OnClick="Button1_OnClick" Text="عرض" /></td></tr>
            
            </table>
        <br/><br/>--%>
        
         <rsweb:ReportViewer ID="ReportViewer1" Width="600px" Height="500px" Visible="False" runat="server" ShowPrintButton="true" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">

               
              </rsweb:ReportViewer>
    
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
