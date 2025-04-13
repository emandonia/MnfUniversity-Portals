<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/StrategyMaster.Master" AutoEventWireup="true" CodeBehind="StaffSuggession.aspx.cs" Inherits="MnfUniversity_Portals.UI.StaffSuggession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
            <asp:Label ID="sentlabel" runat="server"   Text=" يرجى ارسال المقترحات على البريد  " ForeColor="Blue" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
            <br />
             <asp:Label ID="Label1" runat="server"   Text=" mnf_uni_strategy@yahoo.com     " ForeColor="Blue" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
          
              <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
    
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
