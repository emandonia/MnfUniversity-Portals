<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true"  CodeBehind="OutstandingResearches.aspx.cs" Inherits="MnfUniversity_Portals.UI.OutstandingResearches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />

  <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> 
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource1"  AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  DataTextField="FacultyName" DataValueField="FacultyID">
                             
                         <asp:ListItem Value="-1" Text="choose" meta:resourcekey="Fac">اختر الكلية</asp:ListItem>

                         </asp:DropDownList>

                        <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="FacultyTables"></asp:LinqDataSource>

                    
                    </td>
                   
                </tr>
            </table>
           
            
            
            
            
            <asp:Label ID="Label4" runat="server" ></asp:Label><br/><br/>

            <asp:ListView ID="ListView2" runat="server"  DataSourceID="LinqDataSource2" DataKeyNames="PaperId">

                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>

                <ItemTemplate>


                    <div id="resultsDiv">
                        <div class="pageContainer" style="display: block;">

                            <div class="webResult" style="width: 100%; direction: <%=StaticUtilities.Dir%>; text-align: <%=StaticUtilities.Textright%>;">


                                <p>

                                    <asp:Label Text='<%# Eval("EngAddress") %>' runat="server" ID="EngAddressLabel" />....
                       <br />
                                    <asp:LinkButton Text="More" CommandArgument='<%# Eval("PaperId") %>'  OnClick="Editor_ImageButton_Click"
                                        ID="Editor_LinkButton" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:LinkButton>
                                    <br />

                                </p>
                                <h2>
                                    <asp:Label ID="Label3" runat="server" Text="Researcher Name: "></asp:Label><asp:Label Text='<%# Eval("EngMainResName") %>' runat="server" ID="EngMainResNameLabel" /><br />

                                </h2>
                            </div>
                        </div>
                    </div>


                </ItemTemplate>
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholderContainer">

                        <div runat="server" id="itemPlaceholder">
                        </div>
                        <asp:DataPager runat="server" ID="DataPager1" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                    </div>
                </LayoutTemplate>

            </asp:ListView>

            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Portal_DAL.PortalDataContextDataContext" Select="new (PaperId, EngAddress, Faculty, EngMainResName, SummaryEng, EngResName1)" TableName="Prtl_Researches_MainDatas" OrderBy="EngMainResName"></asp:LinqDataSource>
             <asp:ImageButton ID="Dummy" runat="server" Style="display: none" />
<ajaxtk:ModalPopupExtender ID="Editor_ModalPopupExtender" runat="server" Enabled="true"
    TargetControlID="Dummy" PopupControlID="Editor_Panel" PopupDragHandleControlID="Editor_HandelPanel"
     BackgroundCssClass="modalBackground"
    RepositionMode="None" />
            <asp:Panel ID="Editor_Panel" runat="server" Style="display: none" CssClass="modalPopup">
    <asp:Panel ID="Editor_HandelPanel" CssClass="Handel_Panel" runat="server">
        <div style="float: <%=StaticUtilities.FloatRight%>" class="Handel_Label">
            <asp:Localize ID="EditorTitleLocalize" runat="server" Text=""></asp:Localize>
        </div>
        <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
            <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
                <div style="float: <%=StaticUtilities.FloatRight%>">
                    <asp:ImageButton ID="MaximizeImageButton" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
                    <asp:ImageButton ID="RestoreImageButton" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display: none;" OnClientClick="maximize_restore(this);return false;" />
                </div>
                <div style="float: <%=StaticUtilities.FloatLeft%>">
                    <asp:ImageButton ID="CancelEditorImageButton" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <div id="EditorDiv">
        <asp:DetailsView ID="Editor_DetailsView" CssClass="Editor_DetailsView" runat="server"
            AllowPaging="True" AutoGenerateRows="False" CellPadding="4"
            GridLines="None" EmptyDataText="No Data">
            <Fields>
                <asp:TemplateField  >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%# Eval("FacultyTable.FacultyNameEng") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Researcher Name:" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" Text='<%# Eval("EngMainResName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="With:" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" Text='<%# Eval("EngResName1") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Year:" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" Text='<%# Eval("Year") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Summery:" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2" Text='<%# Eval("SummaryEng") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
            <CommandRowStyle CssClass="Editor_CommandRowStyle" />
            <EditRowStyle CssClass="Editor_EditRowStyle" />
            <FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
            <FooterStyle CssClass="Editor_FooterStyle" />
            <HeaderStyle CssClass="Editor_HeaderStyle" />
            <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
            <RowStyle CssClass="Editor_RowStyle" />
        </asp:DetailsView>
    </div>
</asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>