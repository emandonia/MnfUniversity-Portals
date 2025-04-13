<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="CourseReport.aspx.cs" Inherits="MnfUniversity_Portals.UI.CourseReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <table width="100%"  >
        <tr>
            <td>&nbsp;</td>
             <td>
                <asp:Label ID="Label2" runat="server" Text="اسم الدورة :" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
          
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource1" CssClass="textboxservice2"   AppendDataBoundItems ="true"  DataTextField="CourseName" DataValueField="ID">
               <asp:ListItem  Selected="True"   Text="اختر" Value="-1"> </asp:ListItem>
                     </asp:DropDownList>
            </td>
             <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="بحث" CssClass ="btn"/>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext" EntityTypeName="" TableName="Prtl_Courses" Where="used == @used">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="True" Name="used" Type="Boolean" />
                    </WhereParameters>
                </asp:LinqDataSource>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="570px">
                </rsweb:ReportViewer>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
