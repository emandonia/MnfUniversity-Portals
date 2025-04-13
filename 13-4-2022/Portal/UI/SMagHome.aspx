<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SMagazineMaster.master" AutoEventWireup="true" CodeBehind="SMagHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.SMagHome" %>
<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="Server">
 
  
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="EventsPlaceHolder" runat="Server">
 
  
   
</asp:Content><asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="Server">
     
   
        
   
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
