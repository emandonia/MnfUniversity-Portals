<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="OutstandingResearchesEditor.aspx.cs" Inherits="MnfUniversity_Portals.UI.OutstandingResearchesEditor" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
   <script>
       (function (i, s, o, g, r, a, m) {
           i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
               (i[r].q = i[r].q || []).push(arguments)
           }, i[r].l = 1 * new Date(); a = s.createElement(o),
           m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
       })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

       ga('create', 'UA-57986194-1', 'auto');
       ga('send', 'pageview');

</script>   
 <asp:UpdatePanel UpdateMode="Conditional" runat="server">
        <ContentTemplate> 
    <div style="overflow: scroll">
        <asp:Label runat="server" ID="Label1"></asp:Label>
        <br/><br/>

        <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_OnRowEditing" AutoGenerateColumns="False" DataKeyNames="PaperId" DataSourceID="LinqDataSource1" AllowPaging="True" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowEditButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                <asp:BoundField DataField="PaperId" HeaderText="PaperId" ReadOnly="True" SortExpression="PaperId"></asp:BoundField>
                <asp:BoundField DataField="ArabicAddress" HeaderText="ArabicAddress" SortExpression="ArabicAddress"></asp:BoundField>
                <asp:BoundField DataField="EngAddress" HeaderText="EngAddress" SortExpression="EngAddress"></asp:BoundField>
                <asp:TemplateField HeaderText="Summary" SortExpression="Summary">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("Summary") %>' ID="TextBox1"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="height: 100px; overflow: scroll">
                            <asp:Label runat="server" Text='<%# Bind("Summary") %>' ID="Label1"></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SummaryEng" SortExpression="SummaryEng">
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Bind("SummaryEng") %>' ID="TextBox2"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="height: 100px; overflow: scroll">
                            <asp:Label runat="server" Text='<%# Bind("SummaryEng") %>' ID="Label2"></asp:Label></div>
                    </ItemTemplate>
                </asp:TemplateField>

              <%--  <asp:BoundField DataField="Faculty" HeaderText="Faculty" SortExpression="Faculty"></asp:BoundField>
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year"></asp:BoundField>
                <asp:BoundField DataField="YearOfRe" HeaderText="YearOfRe" SortExpression="YearOfRe"></asp:BoundField>--%>
                <asp:BoundField DataField="MainResName" HeaderText="MainResName" SortExpression="MainResName"></asp:BoundField>
                <%--<asp:BoundField DataField="ResName1" HeaderText="ResName1" SortExpression="ResName1"></asp:BoundField>
                <asp:BoundField DataField="ResName2" HeaderText="ResName2" SortExpression="ResName2"></asp:BoundField>
                <asp:BoundField DataField="ResName3" HeaderText="ResName3" SortExpression="ResName3"></asp:BoundField>
                <asp:BoundField DataField="ResName4" HeaderText="ResName4" SortExpression="ResName4"></asp:BoundField>
                <asp:BoundField DataField="EngMainResName" HeaderText="EngMainResName" SortExpression="EngMainResName"></asp:BoundField>
                <asp:BoundField DataField="EngResName1" HeaderText="EngResName1" SortExpression="EngResName1"></asp:BoundField>
                <asp:BoundField DataField="EngResName2" HeaderText="EngResName2" SortExpression="EngResName2"></asp:BoundField>
                <asp:BoundField DataField="EngResName3" HeaderText="EngResName3" SortExpression="EngResName3"></asp:BoundField>
                <asp:BoundField DataField="EngResName4" HeaderText="EngResName4" SortExpression="EngResName4"></asp:BoundField>
                <asp:BoundField DataField="MagTitle" HeaderText="MagTitle" SortExpression="MagTitle"></asp:BoundField>
                <asp:BoundField DataField="MagTitleEng" HeaderText="MagTitleEng" SortExpression="MagTitleEng"></asp:BoundField>
                <asp:BoundField DataField="ResName5" HeaderText="ResName5" SortExpression="ResName5"></asp:BoundField>
                <asp:BoundField DataField="ResName6" HeaderText="ResName6" SortExpression="ResName6"></asp:BoundField>
                <asp:BoundField DataField="EngResName5" HeaderText="EngResName5" SortExpression="EngResName5"></asp:BoundField>
                <asp:BoundField DataField="EngResName6" HeaderText="EngResName6" SortExpression="EngResName6"></asp:BoundField>
                <asp:BoundField DataField="FileName" HeaderText="FileName" SortExpression="FileName"></asp:BoundField>--%>


                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        
                            <asp:HiddenField ID="hf1" runat="server" Value='<%# URLBuilder.CurrentFacID(Page.RouteData)%>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

            <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
            </asp:GridView>
            </div>




            <asp:LinqDataSource runat="server" EntityTypeName="" EnableUpdate="True" EnableDelete="True" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Researches_MainDatas"
                Where="Faculty == @Faculty">
                <WhereParameters>
                    <asp:RouteParameter RouteKey="currentowner" Name="Faculty" Type="String"></asp:RouteParameter>

                </WhereParameters>
            </asp:LinqDataSource>

            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
