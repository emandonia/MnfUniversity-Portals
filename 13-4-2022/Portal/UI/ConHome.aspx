<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/CONMaster.Master" AutoEventWireup="true" CodeBehind="ConHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.ConHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <%-- <img src="http://i66.tinypic.com/20sf22b.png" title="" Alt=""   border="0" >--%>
    <img src="http://mu.menofia.edu.eg/PrtlFiles/Faculties/edu/Portal/Images/408431-8.jpg" title="" Alt=""   border="0"   />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
<%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="right_1" style="  float: left;">
     <div style="direction: rtl">
                <uc:EventSliderControl ID="EventSliderControl1" runat="server"></uc:EventSliderControl>
            </div></div> 
              </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
 <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="news" style="margin-top: 30px">
                <div id="main">
<div class="clear"></div>
                    <div id="tabContent">
                        <div id="contentHolder">
                                <uc:NewsViewerControl ID="NewsViewerControl1" TopNewsCounter="8" runat="server" />
                             <asp:Button ID ="Button2" CssClass="login_button" runat="server" OnClick="Button555_Click" meta:resourcekey ="MoreNews"></asp:Button>
		
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
