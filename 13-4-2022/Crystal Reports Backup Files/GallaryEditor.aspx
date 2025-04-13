<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" CodeBehind="GallaryEditor.aspx.cs" Inherits="MnfUniversity_Portals.UI.Admin.GallaryEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<%@ Register Src="~/UserControls/Editors/GallaryEditor/Editor/GallaryEditorControl.ascx" TagPrefix="uc" TagName="GallaryEditorControl" %>--%>
<asp:Content ID="Content8" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>    
 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="Drop1" runat="server" />
            <br />
<%--            <uc:GallaryEditorControl ID="Editor1" runat="server" />--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
