<%@ Page Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master"
     AutoEventWireup="true" CodeBehind="ICTP.aspx.cs" Inherits="MnfUniversity_Portals.UI.ICTP" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
          
           
  <div id="post">
      <img src="../Styles/University_Master/images/ictp_group.png" width="600" height="600"  usemap="#planetmap">

<map name="planetmap">
   
      <area shape="circle" coords="297, 60, 32" href="http://mu.menofia.edu.eg/Univ_Portal/ItUnitHome/ar" alt="Portal" target="_blank">
      <area shape="circle" coords="103, 124, 32" href="#" alt="ict_traning" target="_blank">
      <area shape="circle" coords="476, 118, 32" href="http://www.menofia.edu.eg/ictp/is.asp" alt="IS" target="_blank">
      <area shape="circle" coords="301, 516, 32" href="http://www.menofia.edu.eg/projects/melc/index.asp" alt="E-learning " target="_blank">
      <area shape="circle" coords="478, 447, 32" href="http://www.menofia.edu.eg/projects/mis/Index.html" alt="MIS target="_blank" >
      <area shape="circle" coords="108, 444, 32" href="#" alt="D-Library target="_blank">
  
</map> 
   
      </div>
     
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
