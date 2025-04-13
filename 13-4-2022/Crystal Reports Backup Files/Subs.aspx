<%@ Page Title="News" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Subs" CodeBehind="Subs.aspx.cs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div align="center">
        <asp:ListView ID="ListView1" runat="server" GroupItemCount="3">
            <LayoutTemplate>
                <table id="Table1" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table id="groupPlaceholderContainer" runat="server" style="border-collapse: collapse; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <AlternatingItemTemplate>
                <td id="Td2" runat="server" style="width: 400px; font-size: large; font-weight: bold; font-family: Tahoma; height: 75px; color: #284775;">
                    <div>
                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#HomeURL(Eval("Abbr"))%>' runat="server">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#LogoPath(Eval("Abbr"))%>' ImageAlign="Middle"
                                GenerateEmptyAlternateText="True" AlternateText="Faculty Logo" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("Translation_Data")%>' NavigateUrl='<%#HomeURL(Eval("Abbr"))%>'
                            runat="server"></asp:HyperLink>
                    </div>
                </td>
            </AlternatingItemTemplate>
            <ItemTemplate>
                <td id="Td1" runat="server" style="width: 400px; font-size: large; font-weight: bold; font-family: Tahoma; height: 75px; color: #284775;">
                    <div>
                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#HomeURL(Eval("Abbr"))%>' runat="server">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#LogoPath(Eval("Abbr"))%>' ImageAlign="Middle"
                                GenerateEmptyAlternateText="True" AlternateText="Faculty Logo" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("Translation_Data")%>' NavigateUrl='<%#HomeURL(Eval("Abbr"))%>'
                            runat="server"></asp:HyperLink>
                    </div>
                </td>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr id="Tr2" runat="server">
                        <td id="Td3" runat="server">No Faculties Translated in this language
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td id="Td4" runat="server" />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
        </asp:ListView>
    </div>
</asp:Content>