<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsReports.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.StudentsReports" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>--%><h2 style="color: blue;">
            <div style="font-size: xx-large !important;font-weight: bold !important">
          <asp:HyperLink ID="HyperLink8" NavigateUrl="Reports.aspx" runat="server">عودة إلي التقارير</asp:HyperLink><br/><br/></div>    
               <strong>برجاء ادخال اسم الطالب رباعي او الضغط علي ابحث مباشرة لعرض بيانات كل طلاب جامعتكم الموقرة . . . 
                    </strong> 
                    </h2>
     <table style=" font-size: medium; font-weight: 700;">
         <tr>
            <td class="auto-style1">
                
            </td></tr>
        <tr>
            <td class="auto-style1">ادخل اسم الطالب رباعي:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                
            </td>
            
        </tr>
         <tr>
            <td class="auto-style1">او اختر الجامعة:</td>
            <td>
                 <asp:DropDownList ID="DropDownList1" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged" runat="server" DataSourceID="LinqDataSource1" DataTextField="University_Name" DataValueField="ID">

                     <asp:ListItem Value="-1">اختر</asp:ListItem>
                 </asp:DropDownList>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID, University_Name)" TableName="Universities">
                    
                </asp:LinqDataSource>              
                            </td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="ابحث" OnClick="Button1_OnClick" />
            </td>
        </tr>
         <tr><td class="auto-style1">
             <asp:Button ID="Button2" runat="server" Text="طباعة التقرير" OnClick="Button2_OnClick" /></td></tr>
        <tr>
            <td class="auto-style1">

               
                           </td>
            
        </tr>
         
       
    </table><rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" Width="800px" Height="500px"  runat="server" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
               
                </rsweb:ReportViewer>
  <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
