<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstRpt.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.InstRpt" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"><style type="text/css">
        .auto-style1 {
            width: 152px;
        }
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            width: 152px;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <div style="font-size: xx-large !important;font-weight: bold !important">
          <asp:HyperLink ID="HyperLink8" NavigateUrl="Reports.aspx" runat="server">عودة إلي التقارير</asp:HyperLink><br/><br/></div>
    <table style="">
        <tr>
            <td class="auto-style3"><strong>اختر الجامعة:</strong></td>
            <td>
                <strong>
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="LinqDataSource1" DataTextField="University_Name" DataValueField="ID" CssClass="auto-style2">
                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                </asp:DropDownList></strong><asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID, University_Name)" TableName="Universities">
                    
                </asp:LinqDataSource> <span class="auto-style2"><strong>&nbsp; &nbsp;</strong></span><strong><asp:CheckBox ID="CheckBox1" AutoPostBack="True" Text="كل الجامعات" OnCheckedChanged="CheckBox1_OnCheckedChanged" runat="server" CssClass="auto-style2" />
                </strong>
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
             <asp:Button ID="Button2" runat="server" Text="طباعة التقرير" OnClick="Button2_OnClick" CssClass="auto-style2" /></strong></td></tr>
        <tr>
            <td class="auto-style1">
               

               
             
                 </td>
            
        </tr>
        
    </table>
    <strong>
    <iframe id="frmPrint" name="IframeName" width="500" 

  height="200" runat="server" 

  style="display: none" runat="server" class="auto-style2"></iframe> </strong><div style="overflow: scroll"> <rsweb:ReportViewer ID="ReportViewer1"  Width="800px" Height="500px"  runat="server" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                   
                    
                </rsweb:ReportViewer></div>
</asp:Content>
