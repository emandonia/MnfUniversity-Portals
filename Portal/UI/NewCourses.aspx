<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="NewCourses.aspx.cs" Inherits="MnfUniversity_Portals.UI.NewCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"    OnDataBinding ="GridView1_DataBinding"      
    OnSelectedIndexChanged ="GridView1_SelectedIndexChanged"
        OnSelectedIndexChanging="GridView1_SelectedIndexChanging"    DataSourceID="LinqDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
            <asp:BoundField DataField="CourseName" HeaderText="CourseName" SortExpression="CourseName"></asp:BoundField>
            <asp:BoundField DataField="CourseTime" HeaderText="CourseTime" SortExpression="CourseTime"></asp:BoundField>
            <asp:BoundField DataField="HoureNumber" HeaderText="HoureNumber" SortExpression="HoureNumber"></asp:BoundField>
            <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost"></asp:BoundField>
            <asp:BoundField DataField="CourseContent" HeaderText="CourseContent" SortExpression="CourseContent"></asp:BoundField>
            <asp:BoundField DataField="CourseType" HeaderText="CourseType" SortExpression="CourseType"></asp:BoundField>

                 
            <%--  <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"  Text='<%#Eval("CourseName")%>' NavigateUrl='<%#getUrl(Eval("ID"))%>'   > </asp:HyperLink>
            <asp:LinkButton ID="lnkSelect" Text="Select" CommandName="Select" CommandArgument="ID" Enabled="true" runat="server" ForeColor="White" OnCommand="" />
            --%>
         
              
            <%--<asp:CommandField ShowSelectButton="True" ></asp:CommandField> 
            <asp:ButtonField Text="Button" ></asp:ButtonField>
        
         
        </Columns>

    </asp:GridView>--%>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LinqDataSource2"
        OnRowCommand ="GridView1_OnRowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
            <asp:BoundField DataField="CourseName" HeaderText="CourseName" SortExpression="CourseName"></asp:BoundField>
            <asp:BoundField DataField="CourseTime" HeaderText="CourseTime" SortExpression="CourseTime"></asp:BoundField>
            <asp:BoundField DataField="HoureNumber" HeaderText="HoureNumber" SortExpression="HoureNumber"></asp:BoundField>
            <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost"></asp:BoundField>
            <asp:BoundField DataField="CourseContent" HeaderText="CourseContent" SortExpression="CourseContent"></asp:BoundField>
            <asp:BoundField DataField="CourseType" HeaderText="CourseType" SortExpression="CourseType"></asp:BoundField>
     <asp:ButtonField ButtonType="Link" CommandName="printReport" Text="Print" HeaderText="Action" />

             <asp:TemplateField >
         <ItemTemplate >
            <asp:HiddenField runat="server" ID ="h1"  Value ='<%#Eval("ID")%>'/>
             <asp:Button runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  OnClick ="cccc"/>
         </ItemTemplate>
     </asp:TemplateField>
            <asp:templatefield headertext="Choose your dream home">
 <itemtemplate>
  <asp:linkbutton runat="server" commandname="select" text='<%# Eval ( "ID" ) %>' />
 </itemtemplate>
</asp:templatefield>
               </Columns>
    </asp:GridView>



    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Courses"></asp:LinqDataSource>
    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Courses"></asp:LinqDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
