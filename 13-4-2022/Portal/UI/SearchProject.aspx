<%@ Page AutoEventWireup="true" CodeBehind="SearchProject.aspx.cs" Inherits="MnfUniversity_Portals.UI.SearchProject" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" %>
  

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
          
           
  <div id="post">
      <img src="../Styles/University_Master/images/search_project.png" width="600" height="400"  usemap="#planetmap1">

<map name="planetmap1">
   
       <area shape="circle" coords="523, 228, 57" href="/view/35284/ar" alt="برنامج البحوث والتنمية التكنولوجية" >
       <area shape="circle" coords="300, 312, 59" href="/view/35289/ar" alt="STDF" >
       <area shape="circle" coords="90, 224, 56" href="/view/35290/ar" alt="TEMPUS" > 
         
</map> 
   
      </div>
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
