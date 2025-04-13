<%@ Control AutoEventWireup="True" CodeBehind="VotingEditorControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.VotingEditor.Editor.VotingEditorControl"
    Language="C#" %>

<asp:ListView ID="VotingListView" runat="server" DataKeyNames="VotingID" DataSourceID="VotingLinqDataSource"
    InsertItemPosition="LastItem">
    <InsertItemTemplate>
        <tr>
            <td colspan="8">
                <asp:LinkButton ValidationGroup="InsertValidation" OnClick="VotingEditorControl_insertClicked" ID="InsertLinkButton" ToolTip="Insert"
                    runat="server" AlternateText="Insert">
                    <asp:Image ID="InsertImage" CssClass="NoMargin" ImageUrl='<%#InsertImageURL %>' runat="server"></asp:Image>
                    <asp:Label ID="Label6" runat="server" Text="Insert New Voting"></asp:Label>
                </asp:LinkButton>
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr runat="server" id="ListViewDataRow">
            <td class="ActionDiv">
                <asp:LinkButton CommandArgument='<%# Bind("VotingID") %>' OnClick="Editor_ImageButton_Click" ID="Editor_LinkButton"
                    runat="server">
                    <asp:Image ID="EditImage" ImageUrl='<%# EditImageURL %>' Style="margin: 0px;" runat="server"></asp:Image>
                </asp:LinkButton>
                <asp:LinkButton ToolTip="Delete" CommandArgument='<%# Bind("VotingID") %>' ID="Delete_LinkButton"
                    runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                    <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' Style="margin: 0px;" runat="server"></asp:Image>
                </asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="Question_Label" Text='<%# GetQuestion(Eval("VotingID")) %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="Ans1_Label" Text='<%# GetAnswers(Eval("VotingID")).Ans1 %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="Ans2_Label" Text='<%# GetAnswers(Eval("VotingID")).Ans2 %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="Ans3_Label" Text='<%# GetAnswers(Eval("VotingID")).Ans3 %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="NotDoneLabel" Text='<%# NotDone(Eval("VotingID")) %>' runat="server" />
            </td>
            <td>
                <asp:Image ID="StatusImage" ImageUrl='<%# Status(Eval("VotingID")) %>' runat="server" />
            </td>
            <td class="DirLTR">
                <asp:Label ID="ActiveLbl" Text='<%#GetActive(Eval("VotingID")) %>' runat="server" />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="Table1" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                        <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                            <th id="Th4" runat="server">
                                <asp:Label ID="Label8" runat="server" Text="Actions"></asp:Label>
                            </th>
                            <th id="Th3" runat="server">
                                <asp:Label ID="Label4" runat="server" Text="Question"></asp:Label>
                            </th>
                            <th id="Th7" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="Ans1"></asp:Label>
                            </th>
                            <th id="Th8" runat="server">
                                <asp:Label ID="Label2" runat="server" Text="Ans2"></asp:Label>
                            </th>
                            <th id="Th1" runat="server">
                                <asp:Label ID="Label3" runat="server" Text="Ans3"></asp:Label>
                            </th>
                            <th id="Th5" runat="server">
                                <asp:Label ID="Label9" runat="server" Text="Not Done"></asp:Label>
                            </th>
                            <th id="Th6" runat="server">
                                <asp:Label ID="Label10" runat="server" Text="Status"></asp:Label>
                            </th>
                            <th id="Th2" runat="server">
                                <asp:Label ID="Label5" runat="server" Text="Active"></asp:Label>
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
<asp:LinqDataSource ID="VotingLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EntityTypeName="" TableName="prtl_Votings" Where="Owner_ID == Guid?(@ID)"
    OrderBy="VotingID desc">
    <WhereParameters>
        <asp:SessionParameter SessionField="VotingOwner_ID" Name="ID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>
<uc:VotingDetailsControl ID="VotingDetailsControl1"
    runat="server"
    OnUpdateSource="DetailsViewControl_UpdateSource"
    OnUpdateSourceItem="DetailsViewControl_UpdateSourceItem">
</uc:VotingDetailsControl>