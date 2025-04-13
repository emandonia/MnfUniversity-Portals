<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunicationViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.CommunicationViewer" %>


<%@ Import Namespace="Common" %>



<nav class="social" >
		  <ul >
<asp:FormView ID="FormView2" runat="server"    align="center" DataSourceID="DummyDataSource">
	<ItemTemplate >
        <%--<a href='<%# GetFaceUl(StaticUtilities .Currentlanguage (Page)) %>'>Facebook <i class="facebook"></i></a> --%>
			  <li><a href='<%# GetFaceUl(StaticUtilities .Currentlanguage (Page)) %>'>Facebook <i class="facebook"></i></a></li>
			  <%--<li><a href='<%# GetTwitterUrl(StaticUtilities .Currentlanguage (Page)) %>'>Twitter <i class="Twitter"></i></a></li>--%>
			  <li><a href='<%# GetYouTubeUrl(StaticUtilities .Currentlanguage (Page)) %>'>Youtube <i class="Youtube"></i></a></li>
			 <%-- <li><a href='<%# GetWordpressUrl(StaticUtilities .Currentlanguage (Page)) %>'>Wordpress <i class="Wordpress"></i></a></li>
              <li><a href='<%# GetTumblrUrl(StaticUtilities .Currentlanguage (Page)) %>'>Tumblr <i class="Tumblr"></i></a></li>
			  <li><a href='<%# GetWixUrl(StaticUtilities .Currentlanguage (Page)) %>'>Wix <i class="Wix"></i></a></li>
			  <li><a href='<%# GetBlogUrl(StaticUtilities .Currentlanguage (Page)) %>'>Bloger <i class="Bloger"></i></a></li>
			 --%> <%-- <li>
                 <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl='<%#URLBuilder.EventsHandlerURL(Page)%>'>Events RSS
                      <i class="Events"></i>
                  </asp:HyperLink>
			  </li>
        <li>		  
              <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl='<%#URLBuilder.NewsHandlerURL(Page)%>'>News RSS<i class="News"></i></asp:HyperLink>
              </li>--%>
			  
</ItemTemplate>
</asp:FormView>
		  </ul>
	  </nav>
  <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
	TypeName="StaticUtilities"></asp:ObjectDataSource>  

	
