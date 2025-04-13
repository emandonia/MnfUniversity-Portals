<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="Subjects.aspx.cs" Inherits="MnfUniversity_Portals.UI.Subjects" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Faculty :" meta:resourcekey="FacDrop"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LDSFaculty" DataTextField="FACULTY_DESCR_AR" DataValueField="AS_FACULTY_INFO_ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True" ControlToValidate="DropDownList1">
                        <asp:ListItem Value="0" meta:resourcekey="Fac">اختر الكلية</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">
                    <asp:LinqDataSource ID="LDSFaculty" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="AS_FACULTY_INFOs" Where="FACULTY_DESCR_AR != @FACULTY_DESCR_AR">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="null" Name="FACULTY_DESCR_AR" Type="String" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Scientific Degree &amp; Bylaw:" meta:resourcekey="DegDrop"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                   <asp:ListItem Value="0" meta:resourcekey="Deg">اختر الدرجة العلمية واللائحة</asp:ListItem>
                         </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Years :" meta:resourcekey="YearDrop"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem Value="0" meta:resourcekey="Year">اختر الفرقة</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" Text="Department :" meta:resourcekey="DepDrop"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                   <asp:ListItem Value="0" meta:resourcekey="Dep">اختر القسم إن وجد</asp:ListItem>
                         </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label5" runat="server" Text="Semester :" meta:resourcekey="SemDrop"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList5" runat="server" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Value="0" meta:resourcekey="Sem">اختر الفصل الدراسي</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Button ID="Button1" runat="server" Text="Search" meta:resourcekey="SearchButton" OnClick="Button1_Click" />
                </td>
                <td>&nbsp; </td>
            </tr>
           
        </table>
            
            <table>
                 <tr>
                     <td>
                <div >
                    <rsweb:ReportViewer ID="MyReportViwer" Width="600px" Height="500px" Visible="true" runat="server" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" ShowZoomControl="True">

                        <LocalReport ReportPath="UI/RS_ST_142.rdlc" EnableHyperlinks="True" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
            </div>
                         </td>
            </tr>
            </table>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
  