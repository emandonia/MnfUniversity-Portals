<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SectorsMaster.Master" AutoEventWireup="true" CodeBehind="SectorsHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.SectorsHome" %>

<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EventsPlaceHolder" runat="Server">
 
  

    <div class="zerogrid">
        <div class="row">
            <div class="col-1-1">
              
                <uc:EventSliderControl runat="server" id="EventSliderControl" />
                <div class="shadow"></div>
            </div>
        

        </div>

    </div>
   
</asp:Content><asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="Server">
 
  
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="Server">
     
   
        
   
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <section class="content-box box-1">
                <div class="row">
                                <uc:NewsViewerControl ID="NewsViewerControl1" TopNewsCounter="8" runat="server" />
                      <asp:Button ID ="Button2" CssClass="login_button" runat="server" OnClick="Button555_Click" meta:resourcekey ="MoreNews"></asp:Button>
		  
                      </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


