<%@ Page Title="News" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master"
    AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.News" CodeBehind="News.aspx.cs" %>

<%@ Register Src="~/UserControls/Viewers/NewsSearchControl.ascx" TagPrefix="uc" TagName="NewsSearchControl" %>


<%--<%@ Register Src="~/UserControls/Viewers/NewsSearchControl.ascx" TagPrefix="uc" TagName="NewsSearchControl" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="meta" runat="Server">

    <meta http-equiv="Content-Type" content="الأخبار بجامعة المنوفية , menofia university News" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>   
 <div style="">

       
     <asp:Button ID="ResetMenuB" runat="server" Text="ResetMenu" Visible="false" OnClick="ButtonM_Click" />
    <table style="width: 25%;"  dir='<%=StaticUtilities.Dir %>' >
        <tr>
            <td>
            <asp:Label ID="Label1" runat="server"  meta:resourcekey="Label1"></asp:Label>
            
            <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="InsertGroup"
                        ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="TextBox1"
                        SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender Format="dd/MM/yyyy" ViewStateMode="Enabled" EnableViewState="True" ID="InsertCalendarExtender1"
                        runat="server" TargetControlID="TextBox1">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="TextBox1" runat="server" ErrorMessage="Date incorrect must be dd/MM/yyyy"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
          
           </td>
           <td></td>
            </tr>
        <tr>
            <td> <asp:Label ID="Label2" runat="server"    meta:resourcekey="Label2"></asp:Label>
            
          
            <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="InsertGroup2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="TextBox2"
                        SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender Format="dd/MM/yyyy" ViewStateMode="Enabled" EnableViewState="True" ID="CalendarExtender2"
                        runat="server" TargetControlID="TextBox2">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="TextBox2" runat="server" ErrorMessage="Date incorrect must be dd/MM/yyyy"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
          </td>
            <td><asp:Button ID="Button1" runat="server" CssClass="btn_editor_search"   OnClick="Button1_Click"  meta:resourcekey="btnSearch"  /></td>
            </tr>
               
         
         
    </table>
        </div>
  <%--  <uc:NewsViewerControl runat="server" ID="NewsViewerControl" />--%>
 <%--   <uc:NewsSearchControl runat="server" ID="NewsSearchControl" />--%>
                
            <%--<uc:NewsViewerControl  runat="server" ID="NewsViewerControl" />--%>
       <uc:NewsSearchControl runat="server" ID="NewsSearchControl" />
     <asp:Button ID="Button222" runat="server" Text="Change Password" Visible="false" OnClick="Button222_Click" />

</asp:Content>