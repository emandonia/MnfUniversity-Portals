<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.BannerViewer" %>
<%@ Import Namespace="Common" %>

<asp:FormView ID="OwnerImageFormView" runat="server" align="center" DataSourceID="DummyDataSource">
    <ItemTemplate>
        <div class="RssIcon">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#URLBuilder.HomeURL(Page)%>'>
                <asp:Image ID="Image1" runat="server" AlternateText="Banner" GenerateEmptyAlternateText="True"
                    ImageAlign="Middle" ImageUrl='<%#URLBuilder.BannerURL(Page)%>' /></asp:HyperLink>
            
        </div>
    </ItemTemplate>
</asp:FormView>
       <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>


