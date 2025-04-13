<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="CommittieGallary.aspx.cs" Inherits="MnfUniversity_Portals.UI.CommittieGallary" %>
<%@ Import Namespace="Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-57986194-1', 'auto');
        ga('send', 'pageview');

</script>    
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
             

                <asp:Panel runat="server" id ="panel1">
    <table >
        <tr><td>
            
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
              
                الحفل الخيرى الأول لذوى الاحتياجات الخاصة 25-2-2015 م
            </asp:LinkButton>
          
             </td></tr>

          <tr><td>
            
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
              
              مبادرة جمعية زويل
            </asp:LinkButton>
          
             </td></tr>
    </table>
              
           </asp:Panel>

             <asp:Panel runat="server" id ="panel2" Visible ="false" >
    
               <div id="gallery">
<ul>
                <asp:Repeater ID="Repeater1" runat="server" >
                    <ItemTemplate>

                      <li ><i><img src='<%#DataBinder.Eval(Container, "DataItem.Image")%>' title="" width="400px" height="400px" alt="" /></i></li>
		 
		

                    </ItemTemplate>

                </asp:Repeater>
   <asp:FormView ID="OwnerImageFormView" runat="server"    align="center" DataSourceID="DummyDataSource">
    <ItemTemplate >
     <li class="default"><i><img src='<%#getFirstImageUrl() %>' title="" alt="" /></i></li>
    </ItemTemplate>
</asp:FormView>
    <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>
    </ul>
</div>
   </asp:Panel>

</ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
            
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
