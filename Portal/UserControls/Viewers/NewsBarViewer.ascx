<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBarViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.NewsBarViewer" %>


<div id="news_bar" class="news_style" style="direction: <%=StaticUtilities.Dir%>;margin-right: 50px;">
    <obshow:Show ScrollingSpeed="2000" ShowType="Show" ScrollDirection="Right" Width="100%" EnableViewState="False"
        StopFading="True" StopScrolling="True" Height="30px" TimeBetweenPanels="5000"
        ID="NewsShow" runat="server">
    </obshow:Show>
</div>

