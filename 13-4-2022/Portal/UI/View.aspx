<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.Master" Inherits="MnfUniversity_Portals.UI.View" CodeBehind="View.aspx.cs" %>
<%@ Import Namespace="Common" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
  

</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '1825093471150195',
                xfbml: true,
                version: 'v2.8'
            });
            FB.AppEvents.logPageView();
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
</script>
    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.8&appId=1825093471150195";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="ManageArticlePanel" runat="server" meta:resourcekey="ManageArticlePanelResource1">
                <asp:LinkButton ID="Edit_ImageButton" OnClick="EditImageButton_Click" runat="server"
                    meta:resourcekey="EditImageButtonResource1">
                    <asp:Image ID="Image1" ImageUrl="~/styles/UserControlImages/edit.png" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text="Edit Page" meta:resourcekey="Label1Resource1"></asp:Label>
                </asp:LinkButton>
                <asp:LinkButton ID="EditArticleLinkButton" OnClick="EditArticleLinkButton_Click" runat="server"
                    meta:resourcekey="EditImageButtonResource1">
                    <asp:Image ID="Image2" ImageUrl="~/styles/UserControlImages/edit.png" runat="server" />
                    <asp:Label ID="Label2" runat="server" Text="Edit Article" meta:resourcekey="EditArticleResource"></asp:Label>
                </asp:LinkButton>
                <asp:LinkButton Visible="False" ID="SaveArticleLinkButton" OnClick="SaveArticleLinkButton_Click" runat="server"
                    meta:resourcekey="EditImageButtonResource1">
                    <asp:Image ID="Image3" ImageUrl="~/styles/UserControlImages/save.png" runat="server" />
                    <asp:Label ID="Label3" runat="server" Text="Save Article" meta:resourcekey="SaveArticleResource"></asp:Label>
                </asp:LinkButton>
                <asp:LinkButton Visible="False" ID="CloseArticleLinkButton" OnClick="CloseArticleLinkButton_Click" runat="server"
                    meta:resourcekey="EditImageButtonResource1">
                    <asp:Image ID="Image4" ImageUrl="~/styles/UserControlImages/close.png" runat="server" />
                    <asp:Label ID="Label5" runat="server" Text="Close Article" meta:resourcekey="CloseArticleResource"></asp:Label>
                </asp:LinkButton>
                <uc:ArticleDetailsViewControl OnDetailsView_ItemUpdated="ArticleDetailsViewControl_ItemUpdated"
                    ID="ArticleDetailsViewControl1" runat="server" />
            </asp:Panel>
            <br />
            <br />

            <asp:MultiView ActiveViewIndex="0" ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <uc:ViewControl ID="ViewControl1" runat="server" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />
                    <br />
                    <br />
                    <ajaxtk:CustomEditor runat="server" ToolbarCanCollapse="True" Width="100%" EnableTabKeyTools="True" DefaultLanguage="ar" ID="txtActualContent" />
                </asp:View>
            </asp:MultiView>
            <br/><br/>
            <%string url = string.Format("http://{0}/{1}/View/{2}/{3}", Request.Url.Authority, URLBuilder.CurrentOwnerAbbr(Page.RouteData), ViewControl1.ArticleID, Page.RouteData.Values["lang"]);%>
   <% string fburl = string.Format("https://www.facebook.com/sharer/sharer.php?u={0}&amp;src=sdkpreparse", url); %>

            <div class="fb-share-button" data-href='<%=url %>' data-layout="button_count" data-size="large" data-mobile-iframe="true"><a class="fb-xfbml-parse-ignore" target="_blank" href=<%=fburl%>>Share</a></div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

