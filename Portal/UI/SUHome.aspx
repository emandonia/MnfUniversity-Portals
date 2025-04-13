<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="SUHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.SUHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
         <table >
        <tr><td align="center" > 
        <%--    <img  src="<%= getImage() %><%= StaticUtilities.Currentlanguage(Page) %>.jpg" />--%>
            <%--<img  src="/Styles/University_Master/images/itunits_<%= StaticUtilities.Currentlanguage(Page) %>.jpg"  />--%>
 </td></tr>
       <%-- <tr><td align="center" > <img src="/Styles/University_Master/images/speciaUnits_<%= StaticUtilities.Currentlanguage(Page) %>.jpg" />--%>


    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
     <div class="zerogrid">
     <div class="row">
         <div class="col-1-1">
          <uc:EventSliderControl runat="server" id="EventSliderControl" />
             <div class="shadow"></div>
         </div>
         

     </div>

 </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">   
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
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
    </asp:UpdatePanel>
</asp:Content>
 