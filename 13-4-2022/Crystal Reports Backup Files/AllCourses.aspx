<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="AllCourses.aspx.cs" Inherits="MnfUniversity_Portals.UI.AllCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
      
    <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1">
        <EmptyDataTemplate>
            <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
        </EmptyDataTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#gUrl( Eval("ID").ToString() )%>' 
                    Text='<%#Eval("Type")%>' Font-Bold="True" Font-Size="Medium"></asp:HyperLink>


            </li>

        </ItemTemplate>
        <LayoutTemplate>
            <ul runat="server" id="itemPlaceholderContainer">

                <li runat="server" id="itemPlaceholder"></li>

            </ul>
        </LayoutTemplate>
    </asp:ListView>

    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_CourseTypes"></asp:LinqDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
