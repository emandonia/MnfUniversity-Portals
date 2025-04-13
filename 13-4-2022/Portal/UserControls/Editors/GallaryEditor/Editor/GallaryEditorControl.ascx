<%@ Control AutoEventWireup="True" CodeBehind="GallaryEditorControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.GallaryEditor.Editor.GallaryEditorControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>

<div style="overflow: scroll; width: 100%;">
    <%-- ReSharper disable UnusedMember.Global --%>
    <asp:ListView ID="EditorListVieww" DataSourceID="GallaryLinqDataSource" runat="server"
        DataKeyNames="Gallary_ID" InsertItemPosition="FirstItem">
          <InsertItemTemplate>
            <td colspan="6">
                <asp:LinkButton ValidationGroup="InsertValidation" OnClick="GallaryEditorControl_insertClicked" ID="InsertLinkButton" ToolTip="Insert"
                    runat="server" AlternateText="Insert">
                    <asp:Image ID="InsertImage" ImageUrl='<%# InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    <asp:Label ID="Label3" runat="server" Text="Insert New GallaryItem"></asp:Label>
                </asp:LinkButton>
              
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
                    
                    <asp:Label ID="GallaryLabel" runat="server" Text='<%#   Eval("Translation_Data") %>'></asp:Label>
                </td>
             
                
                <td class="DirLTR">
                    <asp:Label ID="NotDoneLabel" runat="server" />
                </td>
                <td>
                    <asp:Image ID="StatusImage" runat="server" />
                </td>
                <td>
                    <asp:Image ID="PublishedImage" ImageUrl='<%# PublishedStatus(Eval("prtl_Gallary.Published")) %>' runat="server" />
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
                                    <asp:Label ID="Label8" runat="server" Text="Gallary Name"></asp:Label>
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
   
    <asp:LinqDataSource ID="GallaryLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
        EntityTypeName="" TableName="Prtl_GallaryTrans" EnableDelete="True" EnableInsert="True"
        OrderBy="Gallary_ID desc" EnableUpdate="True" Where="prtl_Gallary.Owner_ID == Guid?(@ID)">
        <WhereParameters>
            <asp:SessionParameter SessionField="GallaryOwner_ID" Name="ID" DbType="Guid" />
        </WhereParameters>
    </asp:LinqDataSource>
<%-- <uc:GallaryDetailsViewControl ID="GallaryDetailsViewControl1" runat="server" />--%>
    <%-- ReSharper restore UnusedMember.Global --%>
</div>