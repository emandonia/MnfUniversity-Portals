<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThesisEditorUserControl.ascx.cs"
    Inherits="MnfUniversity_Portals.UserControls.Editors.ThesisEditor.ThesisEditorUserControl" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<div style="overflow: auto; width: 100%;">
    <asp:ListView ID="ThesisListView" runat="server" DataKeyNames="ID" DataSourceID="ThesisLinqDataSource"
        InsertItemPosition="FirstItem" OnItemDeleting="ListViewControl_ItemDeleting"
        OnItemInserted="ListViewControl_ItemInserted" OnItemUpdating="ListViewControl_ItemUpdating">
        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                    <asp:LinkButton ValidationGroup="InsertValidation" OnClick="ThesisEditorControlInsertClicked"
                        ID="InsertLinkButton" ToolTip="Insert" runat="server" AlternateText="Insert" >
                        <asp:Image ID="InsertImage" ImageUrl='<%#InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                        <asp:Label ID="Labe0l10" runat="server" Text="Insert New Thesis"></asp:Label>
                    </asp:LinkButton>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr runat="server" id="ListViewDataRow" align="center">
                <td class="ActionDiv">
                    <asp:HiddenField runat="server" ID="FilterValueControl" Value='<%# Eval("ID") %>' />
                    <asp:LinkButton CommandArgument='<%# Eval("ID") %>' OnClick="Editor_ImageButton_Click"
                        ID="Editor_LinkButton" runat="server" CausesValidation="False" ToolTip="Edit">
                        <asp:Image ID="EditImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                    <asp:LinkButton ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' ID="Delete_LinkButton"
                        runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                        <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' CssClass="NoMargin"
                            runat="server"></asp:Image>
                    </asp:LinkButton>


                </td>
                <td>
                    <asp:Label ID="StudentName_label" Text='<%# ThesisStudentName(Eval("ID"))  %>' runat="server" />
                </td>

                <td>
                    <asp:Label ID="Address_label" Text='<%# ThesisAddress(Eval("ID"))  %>' runat="server" />
                </td>

               <%-- <td>
                    <asp:Label ID="Label6" Text='<%# ThesisSummary(Eval("ID"))  %>' runat="server" />
                </td>

                <td>
                    <asp:Label ID="Label7" Text='<%# ThesisSpecialisim(Eval("ID"))  %>' runat="server" />
                </td>

                <td>
                    <asp:Label ID="Label11" Text='<%# ThesisResearchPlan(Eval("ID"))  %>' runat="server" />
                </td>--%>




               
                <td class="DirLTR">
                    <asp:Label ID="NotDoneLabel" Text='<%# NotDone(Eval("ID")) %>' runat="server" />
                </td>
                <td>
                    <asp:Image ID="StatusImage" ImageUrl='<%# Status(Eval("ID")) %>' runat="server" />
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
                                    <asp:Label ID="Label4" runat="server" Text="Student Name"></asp:Label>
                                </th>
                                <th id="Th8" runat="server">
                                    <asp:Label ID="Label44" runat="server" Text="Address"></asp:Label>
                                </th>
                                <th id="Th5" runat="server">
                                    <asp:Label ID="Label9" runat="server" Text="Not Done"></asp:Label>
                                </th>
                                <th id="Th6" runat="server">
                                    <asp:Label ID="Label010" runat="server" Text="Status"></asp:Label>
                                </th>
                                 
                                 

                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPagerProducts" runat="server" PageSize="50">
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
    <asp:LinqDataSource ID="ThesisLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
        EnableDelete="True" EntityTypeName="" TableName="prtl_Thesis" Where="Owner_ID == Guid?(@ID)"
        OrderBy="ID desc">
        <WhereParameters>
            <asp:SessionParameter SessionField="ThesisOwner_ID" Name="ID" DbType="Guid" />
        </WhereParameters>
    </asp:LinqDataSource>

    <uc:ThesisDetailsViewControl ID="ThesisDetailsViewControl1" runat="server" OnUpdateSource="DetailsViewControl_UpdateSource"
        OnUpdateSourceItem="DetailsViewControl_UpdateSourceItem" />
</div>
