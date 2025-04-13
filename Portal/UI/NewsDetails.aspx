<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.NewsDetails" CodeBehind="NewsDetails.aspx.cs" %>
<%@ Import Namespace="Common" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

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
<br></br>
    <br></br>
    <uc:NewsDetailsControl ID="NewsDetailsControl1" runat="server" />
    
      <br/><br/>
    

    <%string url=string.Format("http://{0}/{1}/NewsDetails/{2}/{3}", Request.Url.Authority, URLBuilder.CurrentOwnerAbbr(Page.RouteData), Page.RouteData.Values["id"], Page.RouteData.Values["lang"]);%>
   <% string fburl = string.Format("https://www.facebook.com/sharer/sharer.php?u={0}&amp;src=sdkpreparse", url); %>
            <div class="fb-share-button" data-href='<%=url %>' data-layout="button_count" data-size="large" data-mobile-iframe="true"><a class="fb-xfbml-parse-ignore" target="_blank" href=<%=fburl%>>Share</a></div>
    <%--<div class="fb-share-button" data-href="http://mu.menofia.edu.eg/NewsDetails/130634/ar" data-layout="button_count" data-size="small" data-mobile-iframe="true"><a class="fb-xfbml-parse-ignore" target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=http%3A%2F%2Fmu.menofia.edu.eg%2FNewsDetails%2F130634%2Far&amp;src=sdkpreparse">Shar</a></div>--%>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>