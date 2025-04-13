
<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master"
    AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Login" CodeBehind="Login.aspx.cs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>   
<uc:LoginControl runat="server" id="LoginControl" />
</asp:Content>
