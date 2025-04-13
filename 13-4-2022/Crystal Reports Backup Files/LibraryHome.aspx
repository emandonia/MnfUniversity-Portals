<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LibraryMaster.Master" AutoEventWireup="true" CodeBehind="LibraryHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.LibraryHome" %>

<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="Server">
 </asp:Content>
  
   <asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
       
       <img  src="<%= getImage() %>"  />
     <%--<table >
        <tr><td align="center" > <img src="/Styles/University_Master/images/library_<%= StaticUtilities.Currentlanguage(Page) %>.jpg" />
 </td></tr>
        

    </table>--%>
     
		
            
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="Server">
 
</asp:Content>
   

<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="Server">
     
   
        
   
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


