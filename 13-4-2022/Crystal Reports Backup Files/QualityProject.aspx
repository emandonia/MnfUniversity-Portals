<%@ Page Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master"
     AutoEventWireup="true" CodeBehind="QualityProject.aspx.cs" Inherits="MnfUniversity_Portals.UI.QualityProject" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
          
           
  <div id="post">
      <img src="../Styles/University_Master/images/quality_projects.png" width="600" height="400"  usemap="#planetmap">

<map name="planetmap">
   
      <area shape="circle" coords="503, 228, 59" href="http://www.menofia.edu.eg/scqaa/home.asp" alt="اللجنة العليا" target="_blank">
      <area shape="circle" coords="299, 334, 59" href="http://www.menofia.edu.eg/projects/q/home.asp" alt="مركز توكيد الجودة" target="_blank">
      <area shape="circle" coords="95, 228, 59" href="/view/35291/ar" alt="مشروعات التطوير المستمر" target="_self">
      
  
</map> 
   
      </div>
     
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>