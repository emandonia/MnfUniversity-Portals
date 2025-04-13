<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="GetEmployee.aspx.cs" Inherits="MnfUniversity_Portals.UI.GetEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

   <table width="100%" >
       <tr><td></td><td></td><td></td><td></td><td></td></tr>
       <tr><td></td><td></td><td>
           <asp:Button ID="Button2" runat="server" Text="بحث" OnClick="Button2_Click" />
           </td><td>
               <asp:TextBox ID="TextBox1" CssClass="textboxservice2" runat="server"></asp:TextBox>
           </td><td>
               <asp:Label ID="Label6" runat="server" Text="الاسم"></asp:Label>
           </td></tr>
       <tr><td></td><td></td><td></td><td></td><td></td></tr>
       <tr><td></td><td colspan="4">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Width ="100%"
               CellPadding="4"  ForeColor="#333333" GridLines="None" AllowPaging="True">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:BoundField DataField="Department" HeaderText="القسم" SortExpression="Department" />
                   <asp:BoundField DataField="Name" HeaderText="الاسم" SortExpression="Name" />
                   <asp:BoundField DataField="BirthDate" HeaderText="تاريخ الميلاد" SortExpression="BirthDate" />
               </Columns>
               <FooterStyle  BackColor="#074982" Font-Size="18px"  Height="30px" Font-Bold="True" ForeColor="#ffffff" />
               <HeaderStyle BackColor="#074982" Font-Size="18px"  Height="40px" Font-Bold="True" ForeColor="#ffffff" />
               <PagerStyle  BackColor="#b7d6ee" Font-Size="18px"  Height="30px" Font-Bold="True" ForeColor="#ffffff" />
               <RowStyle BackColor="#b7d6ee" ForeColor="#000000" Height="35px" Font-Bold="True" HorizontalAlign="Center" Font-Size="17px" />
               <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
               <SortedAscendingCellStyle BackColor="#FDF5AC" />
               <SortedAscendingHeaderStyle BackColor="#4D0000" />
               <SortedDescendingCellStyle BackColor="#FCF6C0" />
               <SortedDescendingHeaderStyle BackColor="#820000" />
           </asp:GridView>
           <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext" EntityTypeName="" TableName="Prtl_Employees">
           </asp:LinqDataSource>
           </td></tr>
       <tr><td></td><td></td><td></td><td></td><td></td></tr>
       <tr><td></td><td></td><td></td><td></td><td></td></tr>
       <tr><td></td><td></td><td></td><td></td><td></td></tr>
   </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
