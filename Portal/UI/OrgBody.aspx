<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Masterpages/SectorsMaster.Master" CodeBehind="OrgBody.aspx.cs" Inherits="MnfUniversity_Portals.UI.OrgBody" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
          
           
  <div id="post">
     
      <img src="/Styles/University_Master/images/OrgBody.png" width="900" height="330"  usemap="#planetmap">
  
<map name="planetmap">
   
      <area shape="rect" coords="708, 190, 890, 290" href="/educ/view/60853/ar" alt="إدارة شئون التسجيل" target="_self">
      <area shape="rect" coords="482, 191, 667, 288" href="/educ/view/60843/ar" alt=" إدارة شئون الدراسة" target="_self">
      <area shape="rect" coords="255, 189, 439, 293" href="/educ/view/60845/ar" alt=" إدارة شئون الخريجين" target="_self">
      <area shape="rect" coords="31, 189, 217, 293" href="/educ/view/60851/ar" alt="إدارة شئون الإمتحانات" target="_self">
  
</map> 
   
      </div>
     
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
