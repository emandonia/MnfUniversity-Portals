<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/ItUnitsMaster.master" AutoEventWireup="true" CodeBehind="ItUnitHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.ItUnitHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
	
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
    <table >
        <tr><td align="center" > 
            <img  src="<%= getImage() %><%= StaticUtilities.Currentlanguage(Page) %>.jpg"  />
            <%--<img  src="/Styles/University_Master/images/itunits_<%= StaticUtilities.Currentlanguage(Page) %>.jpg"  />--%>
 </td></tr>
        

    </table>
		
            
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
