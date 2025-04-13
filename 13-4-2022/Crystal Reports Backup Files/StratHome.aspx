<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/StrategyMaster.Master" AutoEventWireup="true" CodeBehind="StratHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.StratHome" %>
<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <table >
        <tr><td align="center" > <img src="/Styles/University_Master/images/strategy_<%= StaticUtilities.Currentlanguage(Page) %>.jpg" />
 </td></tr>
        
         <%= StaticUtilities.Currentlanguage(Page) %>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
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
