  

<%@ Control AutoEventWireup="True" CodeBehind="NewsEditorControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.NewsEditor.Editor.NewsEditorControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>
<fz:ImageZoom ID="Login1" ImageAltText="News Image" ImageClass="smallThumbnail" ImageTitle=""
    Style="display: none;" runat="server" />
<asp:ListView ID="NewsListView" runat="server" DataKeyNames="News_Id" DataSourceID="NewsLinqDataSource"
    InsertItemPosition="FirstItem">
    <InsertItemTemplate>
        <td colspan="6">
            <asp:LinkButton ValidationGroup="InsertValidation" OnClick="NewsEditorControl_insertClicked" ID="InsertLinkButton" ToolTip="Insert"
                runat="server" AlternateText="Insert">
                <asp:Image ID="InsertImage" CssClass="NoMargin" ImageUrl='<%# InsertImageURL %>' runat="server"></asp:Image>
                <asp:Label runat="server" Text="Insert New NewsItem"></asp:Label>
            </asp:LinkButton>
            <div style="visibility:visible ; display: none;">
                <asp:TextBox ID="EditNewsDateTextBox" runat="server"></asp:TextBox>
                <ajaxtk:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="EditNewsDateTextBox">
                </ajaxtk:CalendarExtender>
            </div>
        </td>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr runat="server" id="ListViewDataRow">
            <td class="ActionDiv">
                <asp:LinkButton CommandArgument='<%#  Bind("News_Id") %>' OnClick="Editor_ImageButton_Click"
                    ID="Editor_LinkButton" runat="server">
                    <asp:Image ID="EditorImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                </asp:LinkButton>
                <asp:LinkButton ToolTip="Delete" ID="LinkButton42" runat="server" CausesValidation="False"
                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                    <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' runat="server"></asp:Image>
                </asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="NewsDateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("News_date")) %>' runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="NewsHeadLabel" Text='<%# GetNewsHead(Convert.ToInt32(Eval("News_Id")),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server"></asp:Label>
            </td>
            <td>
                <div align="center">
                    <fz:ImageZoom ID="NewsItemImageZoom" BigImageURL='<%# URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.News,
                                        Eval("News_img") ?? URLBuilder.DefaultImageName) %>'
                        SmallImageURL='<%# URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.News_Thumb,
                                         Eval("News_img") ?? URLBuilder.DefaultImageName) %>'
                        ImageAltText="News Image"
                        ImageClass="smallThumbnail" ImageTitle="" runat="server" />
                </div>
            </td>
            <td class="DirLTR">
                <asp:Label ID="NotDoneLabel" Text='<%# NotDone(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
            </td>
            <td>
                <asp:Image ID="StatusImage" ImageUrl='<%# Status(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
            </td>
            <td>
                    <asp:Image ID="PublishedImage" ImageUrl='<%# PublishedStatus(Eval("Published")) %>' runat="server" />
                </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="Table1" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                        <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                            <th id="Th2" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="Actions"></asp:Label>
                            </th>
                            <th id="Th5" runat="server">
                                <asp:Label ID="Label8" runat="server" Text="News Date"></asp:Label>
                            </th>
                            <th id="Th7" runat="server">
                                <asp:Label ID="Label4" runat="server" Text="News Head"></asp:Label>
                            </th>
                            <th id="Th1" runat="server">
                                <asp:Label ID="Label3" runat="server" Text="News Image"></asp:Label>
                            </th>
                            <th id="Th6" runat="server">
                                <asp:Label ID="Label9" runat="server" Text="Not Done"></asp:Label>
                            </th>
                            <th id="Th4" runat="server">
                                <asp:Label ID="Label10" runat="server" Text="Status"></asp:Label>
                            </th>
                             <th id="Th3" runat="server">
                                    <asp:Label ID="Label2" runat="server" Text="Published"></asp:Label>
                                </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td id="Td2" runat="server" style="text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                    <asp:DataPager ID="DataPagerProducts" runat="server" PageSize="35">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                                ShowLastPageButton="False" ShowPreviousPageButton="False" ButtonType="Button"
                                ButtonCssClass="Pager_PreviousButton" />
                            <asp:NumericPagerField ButtonCount="5" ButtonType="Button" NumericButtonCssClass="Pager_Button"
                                CurrentPageLabelCssClass="Pager_SelectButton" />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button"
                                ButtonCssClass="Pager_NextButton" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="NewsLinqDataSource" runat="server" ContextTypeName=" Portal_DAL.PortalDataContextDataContext"
    EntityTypeName="" EnableDelete="True" EnableInsert="True"
    EnableUpdate="True" Where="Owner_ID == Guid?(@ID)" OrderBy="News_Date desc">
    <WhereParameters>
        <asp:SessionParameter SessionField="NewsOwner_ID" Name="ID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>
<uc:NewsDetailsViewControl
    ID="NewsDetailsViewControl" runat="server"
    OnUpdateSource="DetailsViewControl_UpdateSource"
    OnUpdateSourceItem="DetailsViewControl_UpdateSourceItem">
</uc:NewsDetailsViewControl>