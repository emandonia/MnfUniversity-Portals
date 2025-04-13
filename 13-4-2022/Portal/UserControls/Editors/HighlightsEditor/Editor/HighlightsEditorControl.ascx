<%@ Control AutoEventWireup="True" CodeBehind="HighlightsEditorControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.HighlightsEditor.Editor.HighlightsEditorControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>

<div style="overflow: scroll; width: 100%;">
    <%-- ReSharper disable UnusedMember.Global --%>
    <asp:Label ID="DateErrorLabel" runat="server" Visible="false" ForeColor="Red" Text="Start Date must be before End Date."></asp:Label>
    <br />
    <asp:ListView ID="EditorListView" DataSourceID="EventsLinqDataSource" runat="server"
        DataKeyNames="Highlight_Id" InsertItemPosition="FirstItem">
        <InsertItemTemplate>
            <td colspan="6">
                <asp:LinkButton ValidationGroup="InsertValidation" OnClick="EventEditorControl_insertClicked" ID="InsertLinkButton" ToolTip="Insert"
                    runat="server" AlternateText="Insert">
                    <asp:Image ID="InsertImage" ImageUrl='<%# InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    <asp:Label runat="server" Text="Insert New EventItem"></asp:Label>
                </asp:LinkButton>
                <div style="visibility: hidden; display: none;">
                    <asp:TextBox ID="EditNewsDateTextBox" runat="server"></asp:TextBox>
                    <ajaxtk:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="EditNewsDateTextBox">
                    </ajaxtk:CalendarExtender>
                </div>
            </td>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr runat="server" id="ListViewDataRow">
                <td class="ActionDiv">
                    <asp:LinkButton CommandArgument='<%# Bind("Translation_ID") %>' ID="Editor_LinkButton" OnClick="Editor_ImageButton_Click"
                        runat="server">
                        <asp:Image ID="EditorImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                    <asp:LinkButton ToolTip="Delete" ID="LinkButton42" runat="server" CausesValidation="False"
                        CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                        <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="StartDateLabel" Text='<%#  StaticUtilities.FormatDate((DateTime) Eval("Start_Date")) %>' runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="EndDateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("End_Date")) %>' runat="server"></asp:Label>
                </td>
                <td>
                    <div align="center">
                        <fz:ImageZoom ID="EventImageZoom" BigImageURL='<%# URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.Events ,
                                        Eval("Image") ?? URLBuilder.DefaultImageName) %>'
                            SmallImageURL='<%# URLBuilder.Path(Page, PathType.WebServer,
                                         SiteFolders.Events_Thumb ,
                                         Eval("Image") ?? URLBuilder.DefaultImageName) %>'
                            ImageAltText="Events Image" ImageClass="smallThumbnail"
                            ImageTitle="" runat="server" />
                    </div>
                </td>
                <td class="DirLTR">
                    <asp:Label ID="NotDoneLabel" runat="server" />
                </td>
                <td>
                    <asp:Image ID="StatusImage" runat="server" />
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
                                    <asp:Label ID="Label8" runat="server" Text="Start Date"></asp:Label>
                                </th>
                                <th id="Th1" runat="server">
                                    <asp:Label ID="Label3" runat="server" Text="End Date"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="ImageLabel" runat="server" Text="Image"></asp:Label>
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
    <asp:LinqDataSource ID="EventsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
        EntityTypeName="" TableName="prtl_Highlights" EnableDelete="True" EnableInsert="True"
        OrderBy="Highlight_Id desc" EnableUpdate="True" Where="Owner_ID == Guid?(@ID)">
        <WhereParameters>
            <asp:SessionParameter SessionField="EventOwner_ID" Name="ID" DbType="Guid" />
        </WhereParameters>
    </asp:LinqDataSource>
    <uc:HighlightsDetailsViewControl ID="EventDetailsViewControl1" runat="server" />
    <%-- ReSharper restore UnusedMember.Global --%>
</div>