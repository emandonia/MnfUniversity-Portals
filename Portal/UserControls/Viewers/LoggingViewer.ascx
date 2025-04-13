<%@ Control AutoEventWireup="True" CodeBehind="LoggingViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.LoggingViewer"
    Language="C#" %>
<asp:ListView ID="LoggingListView" runat="server" DataKeyNames="ID" DataSourceID="LoggingLinqDataSource">

    <ItemTemplate>
        <tr runat="server" id="ListViewDataRow">

            <td>
                <asp:Label ID="UserName_Label" Text='<%#Bind("UserName") %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="OpDesc_Label" Text='<%#Bind("OperationDesc") %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="OpTable_Label" Text='<%#Bind("OperationTable") %>' runat="server" />
            </td>
            <td>
                <asp:Label ID="OpDateTime_Label" Text='<%# Eval("OperationDateTime") %>' runat="server" />
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Label ID="Label3" runat="server" Text="No Data"></asp:Label>
    </EmptyDataTemplate>
    <LayoutTemplate>
        <table id="Table1" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                        <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                            <th id="Th4" runat="server">
                                <asp:Label ID="Label8" runat="server" Text="User Name"></asp:Label>
                            </th>
                            <th id="Th3" runat="server">
                                <asp:Label ID="Label4" runat="server" Text="Operation Description"></asp:Label>
                            </th>
                            <th id="Th7" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="Operation Table"></asp:Label>
                            </th>
                            <th id="Th8" runat="server">
                                <asp:Label ID="Label2" runat="server" Text="Operation Date & Time"></asp:Label>
                            </th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td id="Td2" runat="server" style="text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                    <asp:DataPager ID="DataPagerProducts" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="false"
                                ButtonType="Button" ButtonCssClass="Pager_PreviousButton" />
                            <asp:NumericPagerField ButtonCount="5" ButtonType="Button" NumericButtonCssClass="Pager_Button"
                                NextPreviousButtonCssClass="Pager_NextButton" CurrentPageLabelCssClass="Pager_SelectButton" />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="false"
                                ButtonType="Button" ButtonCssClass="Pager_NextButton" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="LoggingLinqDataSource" OnSelecting="ListViewLinqDataSource_Selecting" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EntityTypeName="" TableName="prtl_Loggings">
</asp:LinqDataSource>