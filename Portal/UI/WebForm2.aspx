<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="MnfUniversity_Portals.UI.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"         
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
        </Columns>
    </asp:GridView>

    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Courses"></asp:LinqDataSource>

    </div>
    </form>
</body>
</html>
