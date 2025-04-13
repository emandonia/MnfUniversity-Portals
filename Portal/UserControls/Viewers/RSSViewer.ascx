<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RSSViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.RSSViewer" %>
<%@ Import Namespace="Common" %>

<asp:FormView ID="RSSForm" Height="100%" runat="server" DataSourceID="DummyDataSource">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="RssIcon" ImageUrl="~/styles/Main/images/rssnews.png"
            NavigateUrl='<%#URLBuilder.NewsHandlerURL(Page)%>'>News RSS</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="RssIcon" ImageUrl="~/styles/Main/images/rssevents.png"
            NavigateUrl='<%#URLBuilder.EventsHandlerURL(Page)%>'>Events RSS</asp:HyperLink>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>
