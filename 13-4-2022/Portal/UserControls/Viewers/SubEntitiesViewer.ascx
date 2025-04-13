<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubEntitiesViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.SubEntitiesViewer" %>
<obshow:Show ScrollingSpeed="2000" ShowType="Show" ScrollDirection="Right" Width="100%" EnableViewState="False"
    StopFading="True" StopScrolling="True" Height="180px" TimeBetweenPanels="5000"
    ManualChanger="True" Changer-Type="Arrow" Changer-ArrowType="BothSides" ID="SubownersShow"
    runat="server">
    <Changer Width="170" ArrowType="BothSides" Type="Arrow" Height="45" HorizontalAlign="center" />
</obshow:Show>


     

<%--<asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate><div id="example">
		  <div id="slides">
				<div class="slides_container">
</HeaderTemplate>
    <ItemTemplate>
        <div class="slide">
						<a href="#1" class="link" >كليه الأداب</a>
						<p><img src="images/slide1.jpg"></p>
					</div>
        <li><%# Container.DataItem %></li>
    </ItemTemplate>
    <FooterTemplate></div>
				<a href="#" class="prev"></a>
				<a href="#" class="next"></a>			
				</div>
						
	</div></FooterTemplate>
</asp:Repeater>--%>