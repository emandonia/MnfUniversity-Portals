<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpvReport.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.SpvReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 725px;
        }
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            width: 725px;
            font-size: medium;
        }
        .auto-style6 {
            color: #0000FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div style="font-size: xx-large !important;font-weight: bold !important">
          <asp:HyperLink ID="HyperLink8" NavigateUrl="Reports.aspx" runat="server">عودة إلي التقارير</asp:HyperLink><br/><br/></div>
     <h2 class="auto-style6">
               <strong>برجاء ادخال اسم المشرف رباعي او الضغط علي ابحث مباشرة لعرض بيانات كل مشرفين جامعتكم الموقرة . . . </strong> 
</h2> <table style=" width: 387px;">
          <tr>
            <td class="auto-style1">
                
                
            </td></tr>
        <tr>
            <td class="auto-style3"><strong style="text-align: left">ادخل اسم المشرف رباعي:</strong></td>
            <td>
                <strong>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2"></asp:TextBox>
                
                </strong>
                
            </td>
            
        </tr>
         <tr>
            <td class="auto-style3"><strong style="text-align: left">او اختر الجامعة:</strong></td>
            <td>
                 <strong>
                 <asp:DropDownList ID="DropDownList1" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged" runat="server" DataSourceID="LinqDataSource1" DataTextField="University_Name" DataValueField="ID" CssClass="auto-style2">

                     <asp:ListItem Value="-1">اختر</asp:ListItem>
                 </asp:DropDownList>
                 </strong>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID, University_Name)" TableName="Universities">
                    
                </asp:LinqDataSource>              
                            </td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <strong>
                <asp:Button ID="Button1" runat="server" Text="ابحث" OnClick="Button1_OnClick" CssClass="auto-style2" />
                </strong>
            </td>
        </tr>
         <tr><td class="auto-style1">
             <strong>
             <asp:Button ID="Button3" runat="server" Text="طباعة التقرير" OnClick="Button2_OnClick" CssClass="auto-style2" /></strong></td></tr>
        <tr>
            <td class="auto-style1">

               
                           </td>
            
        </tr>
        
          <strong>
        
       <iframe id="frmPrint" name="IframeName" width="500" 

  height="200" runat="server" 

  style="display: none" runat="server" class="auto-style2"></iframe>
          </strong>
    </table>
    <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" Width="800px" Height="500px"  runat="server" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
               
                </rsweb:ReportViewer>
</asp:Content>
