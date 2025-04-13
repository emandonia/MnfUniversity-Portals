<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="gallary.aspx.cs" Inherits="MnfUniversity_Portals.UI.gallary" %>
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
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
    <table >
        <tr><td>
            
            <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
              
                test
            </asp:LinkButton>--%>
            <asp:FormView ID="OwnerImageFormView" runat="server"    align="center" DataSourceID="DummyDataSource">
    <ItemTemplate >
<%--            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#gallarypage() %>' runat="server" Text="الالعاب الاوليمبية"></asp:HyperLink>
        </br></br></br></br>
<asp:HyperLink ID="HyperLink2" NavigateUrl='<%#gallarypage2() %>' runat="server" Text="العيد"></asp:HyperLink>--%>
        </ItemTemplate>
</asp:FormView>
    <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>
             </td></tr>


    </table>
             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
 