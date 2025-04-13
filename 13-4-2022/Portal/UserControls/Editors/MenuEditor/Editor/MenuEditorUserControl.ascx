<%@ Control AutoEventWireup="True" CodeBehind="MenuEditorUserControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.MenuEditor.MenuEditorUserControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>


<asp:DropDownList ID="PositionDropDownList"  runat="server" AutoPostBack ="True" OnSelectedIndexChanged="PositionDropDownList_SelectedIndexChanged" >
    <asp:ListItem>top</asp:ListItem>
    <asp:ListItem Text="Vertical"></asp:ListItem>
    <asp:ListItem Text="Horizontal"></asp:ListItem>
    <asp:ListItem Value ="implink2" >قائمة 3</asp:ListItem>
    <asp:ListItem Value ="implink3">قائمة2</asp:ListItem>
  
    <asp:ListItem Value ="implink9">قائمة 1</asp:ListItem>
</asp:DropDownList>
<div style="overflow: scroll">
    <asp:ListView ID="Menu_ListView" OnItemDeleting="ListViewControl_ItemDeleting" OnItemInserted="ListViewControl_ItemInserted" OnItemUpdating="ListViewControl_ItemUpdating"
        runat="server" DataSourceID="Menu_LinqDataSource" DataKeyNames="Menu_id" InsertItemPosition="FirstItem">
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                            <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                                <th id="Th1" runat="server"></th>
                                <th id="Th2" runat="server">
                                    <asp:Label ID="Label3" runat="server" Text="Parent"></asp:Label>
                                </th>
                                <th id="Th3" runat="server">
                                    <asp:Label ID="Label5" runat="server" Text="Order"></asp:Label>
                                </th>
                                <th id="Th4" runat="server">
                                    <asp:Label ID="Labele" runat="server" Text="Current Text"></asp:Label>
                                </th>
                                <th id="Th6" runat="server">
                                    <asp:Label ID="NotDoneLabel" runat="server" Text="Not Done"></asp:Label>
                                </th>
                                <th id="Th7" runat="server">
                                    <asp:Label ID="StatusLabel" runat="server" Text="Status"></asp:Label>
                                </th>
                                <th id="Th5" runat="server">
                                    <asp:Label ID="Label1" runat="server" Text="Published"></asp:Label>
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPagerProducts" runat="server" PageSize="15">
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
        <ItemTemplate>
            <tr runat="server" id="ListViewDataRow" style='color: #000000;'>
                <td class="ActionDiv">
                    <asp:LinkButton ID="Editor_LinkButton" OnClick="Editor_ImageButton_Click" CommandArgument='<%#Bind("Translation_ID") %>'
                        runat="server" CausesValidation="False" ToolTip="Edit">
                        <asp:Image ID="EditImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                    <asp:LinkButton ToolTip="Delete" ID="LinkButton42" runat="server" CausesValidation="False"
                        CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                        <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' CssClass="NoMargin"
                            runat="server"></asp:Image>
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="Parent_id" runat="server" Text='<%# TranslationData( Eval("Parent_id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                        Width="100px" />
                </td>
                <td>
                    <asp:Label ID="OrderLabel" Style="text-align: center;" Text='<%#  Eval("Order") %>'
                        runat="server" />
                </td>
                <td>
                    
                    <asp:Label ID="Label4" Style="text-align: center;" Text='<%# TranslationData( Eval("Menu_id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                        runat="server" />
                    <asp:HyperLink Style="text-align: center;" 
                        NavigateUrl='<%# MenuItemNavigateURL( Eval("Menu_id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ID="MenuItemLabel"
                        runat="server"></asp:HyperLink>
                </td>
                <td dir="ltr">
                    <asp:Label ID="NotDoneLabel" Text='<%# NotDone(Eval("Translation_ID"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
                </td>
                <td align="center">
                    <asp:Image ID="StatusImage" ImageUrl='<%# Status(Eval("Translation_ID"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
                </td>
                
                
                

                <td>
                    
                    <asp:Image ID="PublishedImage" ImageUrl='<%# PublishedStatus(Eval("Published")) %>' runat="server" />
                    
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <td colspan="7">
                <asp:LinkButton ID="InsertLinkButton" ToolTip="Insert" runat="server" OnClick="MenuEditorControlInsertClicked"
                    AlternateText="Insert">
                    <asp:Image ID="InsertImage" CssClass="NoMargin" ImageUrl='<%#InsertImageURL %>' runat="server"></asp:Image>
                    <asp:Label ID="Label2" runat="server" Text="Insert New MenuItem"></asp:Label>
                </asp:LinkButton>
                <div style="display: none">
                    <ajaxtk:ComboBox Width="10px" ID="Combo" runat="server">
                    </ajaxtk:ComboBox>
                </div>
            </td>
        </InsertItemTemplate>
    </asp:ListView>
</div>
<uc:MenuDetailsViewControl ID="MenuDetailsViewControl1" OnUpdateSourceItem="DetailsViewControl_UpdateSourceItem" OnUpdateSource="DetailsViewControl_UpdateSource" runat="server"></uc:MenuDetailsViewControl>
<asp:LinqDataSource ID="Menu_LinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
    OrderBy="Parent_Id, Order"  Where="Owner_ID == Guid?(@ID) && Position == @position">
    <WhereParameters>
        <asp:ControlParameter ControlID="PositionDropDownList" Name="position" PropertyName="SelectedValue"
            Type="String" />
        <asp:SessionParameter SessionField="MenuOwner_ID" Name="ID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>