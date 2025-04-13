<%@ Page Title="محرر المستخدمين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUsers.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.ControlUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DynamicDataManager  ID="DynamicDataManager1" runat="server"></asp:DynamicDataManager>
            <asp:ListView ID="ListView1" InsertItemPosition="LastItem" runat="server" DataSourceID="LinqDataSource1" DataKeyNames="ID">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFF8DC;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />

                        </td>
                        
                        <td>
                            <asp:DynamicControl DataField="UserName" Mode="ReadOnly" runat="server" />
                        </td>


                        <td>
                            <asp:DynamicControl DataField="Password" Mode="ReadOnly" runat="server" />
                        </td>
                       
                        <td>
                            <asp:DynamicControl DataField="University" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="UserType" Mode="ReadOnly" runat="server" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #008A8C; color: #FFFFFF;">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        
                        <td>
                            <asp:DynamicControl DataField="UserName" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Password" Mode="Edit" runat="server" />
                        </td>


                        
                        <td>
                            <asp:DynamicControl DataField="University" Mode="Edit" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="UserType" Mode="Edit" runat="server" />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" ValidationGroup="Insert" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                       
                        <td>
                            <asp:DynamicControl DataField="UserName" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="Password" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>


                        
                        <td>
                            <asp:DynamicControl DataField="University" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="UserType" Mode="Insert" ValidationGroup="Insert" runat="server" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #DCDCDC; color: #000000;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />

                        </td>
                        
                        <td>
                            <asp:DynamicControl DataField="UserName" Mode="ReadOnly" runat="server" />
                        </td>


                        <td>
                            <asp:DynamicControl DataField="Password" Mode="ReadOnly" runat="server" />
                        </td>
                       
                        
                        <td>
                            <asp:DynamicControl DataField="University" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="UserType" Mode="ReadOnly" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                    <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                        <th runat="server">Control</th>
                                       
                                        <th runat="server">UserName</th>
                                        <th runat="server">Password</th>

                                        
                                        <th runat="server">University</th>
                                        <th runat="server">UserType</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager runat="server" ID="DataPager2">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        
                        <td>
                            <asp:DynamicControl DataField="UserName" Mode="ReadOnly" runat="server" />
                        </td>

                        <td>
                            <asp:DynamicControl DataField="Password" Mode="ReadOnly" runat="server" />
                        </td>

                        
                        <td>
                            <asp:DynamicControl DataField="University" Mode="ReadOnly" runat="server" />
                        </td>
                        <td>
                            <asp:DynamicControl DataField="UserType" Mode="ReadOnly" runat="server" />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:LinqDataSource runat="server" EnableDelete="True" EnableUpdate="True" EnableInsert="True" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" TableName="Users"></asp:LinqDataSource>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
