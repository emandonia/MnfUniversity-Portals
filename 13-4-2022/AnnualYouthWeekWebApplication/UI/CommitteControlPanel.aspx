<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommitteControlPanel.aspx.cs" Inherits="AnnualYouthWeekWebApplication.CommitteControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
      <meta charset="utf-8">
  
  
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
        <br/>
    
    <br/>
    <div style="font-size: xx-large !important;font-weight: bold !important">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="ControlUniAdmins.aspx" runat="server">محرر القيادات العليا</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="ControlGenInst.aspx" runat="server">محرر المشرفين العوام</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink3" NavigateUrl="ControlInst.aspx" runat="server">محرر المشرفين</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink4" NavigateUrl="ControlCompanions.aspx" runat="server">محرر المرافقين</asp:HyperLink><br/><br/>
    <asp:HyperLink ID="HyperLink5" NavigateUrl="ControlStudents.aspx" runat="server">محرر الطلاب</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink6" NavigateUrl="ChangePassword.aspx" runat="server">تغيير كلمة السر</asp:HyperLink><br/><br/>
         <asp:HyperLink ID="HyperLink8" NavigateUrl="Reports.aspx" runat="server">التقاريـــــــــر</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink9" NavigateUrl="ControlMembers.aspx" runat="server" Visible="False">محرر اعضاء اللجنة</asp:HyperLink><br/><br/>
        <asp:HyperLink ID="HyperLink7" NavigateUrl="~/Images/Manual.pptx" runat="server">دليل المستخدم</asp:HyperLink><br/><br/>
	
    </div>
   

</asp:Content>
