<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="ReplayToClient.aspx.cs" Inherits="MnfUniversity_Portals.UI.ReplayToClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Label ID="sentlabel" runat="server" ForeColor="red"  Text=""></asp:Label>
            <asp:FormView ID="FormView1" runat="server" DataSourceID="DummyDataSource">
                <ItemTemplate>
    <table ID="Table1" runat="server">

       <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Text="الشكوي:"></asp:Label></td>
           <td>
               <asp:Label ID="Label2" runat="server" 
                   Text='<%#getcomp()  %>'></asp:Label>

           </td>


       </tr>
        <tr>

            <td> <asp:Label ID="Label3" runat="server" Text="الرد:"></asp:Label></td>
            <td>
               <asp:Label ID="Label5" runat="server" 
                   Text='<%#getReplay()  %>'></asp:Label></td>

        </tr>
       
        <tr>
            <td>
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="إرسال الرد" /></td>

        </tr>




    </table>

                </ItemTemplate>
</asp:FormView>
            <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>

            </ContentTemplate></asp:UpdatePanel>






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
