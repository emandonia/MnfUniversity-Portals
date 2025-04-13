<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageSelector.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.LanguageSelector" %>
<%@ Import Namespace="Common" %>

<div>
    <div style="width: 100%;">
        <div>

            <div style="border: 0 none; cursor: pointer;">
                <p class="style1">
                    <a title="arabic" rel="nofollow" target="_self" href='<%= ResolveUrl( URLBuilder.FormURL("ar", Page))%>'>
                        <img onmouseout="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar_1.png';"
                            onmouseover="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar.png';"
                            title="Arabic" alt="arabic" src="<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar_1.png"
                            width="25" height="25"> العربية</a>

                    <a title="english" rel="nofollow" target="_self" href='<%= ResolveUrl(URLBuilder.FormURL("en", Page))%>'>
                        <img onmouseout="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en_1.png';"
                            onmouseover="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en.png';"
                            title="English" alt="english" src="<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en_1.png"
                            width="25" height="25">English</a>
                </p>
            </div>
        </div>
    </div>
</div>
