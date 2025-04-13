<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Masterpages/UniversityMaster.master"CodeBehind="OtherProject.aspx.cs" Inherits="MnfUniversity_Portals.UI.OtherProject" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
          
           
  <div id="post">
      <img src="../Styles/University_Master/images/other_proj.png" width="600" height="400"  usemap="#planetmap">

<map name="planetmap">
   
      <area shape="circle" coords="513, 240, 55" href="/view/35292/ar" alt="تطوير التعليم العالى" target="_self">
      <area shape="circle" coords="426, 322, 55" href="/view/35293/ar" alt="مشروعات بيئية" target="_self">
      <area shape="circle" coords="170, 315, 52" href="/view/35294/ar" alt="مشروعات تنافسية" target="_self">
      <area shape="circle" coords="75, 243, 54" href="/view/35295/ar" alt="مشروعات كلية التربية" target="_self">
      <area shape="circle" coords="296, 247, 54" href="/UI/SearchProject.aspx" alt="مشروعات بحثية" target="_self">
    
</map> 
   
      </div>
     
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>