<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="LinksEditor.aspx.cs" Inherits="MnfUniversity_Portals.UI.Admin.LinksEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Link1"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Link2"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Link3"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Link4"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <asp:Button ID="Button1" runat="server" Text="Update Links" OnClick="updatelinks" />
        </tr>
        <tr><td>
            <asp:Label ID="Label5" runat="server" Text="Updtaed Succeffully" Visible="False" meta:resourcekey="label" BackColor="#6699FF" Font-Bold="True" Font-Size="20" ForeColor="Black"></asp:Label></td></tr>
    </table>

</asp:Content>

