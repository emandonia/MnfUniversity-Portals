<%@ Page Title="محرر القائد العام" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUniAdmins.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.ControlUniAdmins" %>

<%@ Register TagPrefix="ajaxtk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.50731.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
           

            <%--<asp:DynamicDataManager ViewStateMode="Enabled"  ID="DynamicDataManager1" runat="server"/>--%>

         
            <div style="overflow: auto; width: 100%">
                <asp:ListView ID="ListView1" DataKeyNames="ID" InsertItemPosition="FirstItem"  runat="server" DataSourceID="LinqDataSource1">

                 
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr>
                                <td>لا توجد بيانات.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td colspan="6">
                                <asp:LinkButton ValidationGroup="InsertValidation" OnClick="ArticleEditorControlInsertClicked"
                                    ID="InsertLinkButton" ToolTip="Insert" runat="server" AlternateText="Insert">
                                    <%--<asp:Image ID="InsertImage" ImageUrl='<%#InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>--%>
                                    <asp:Label ID="Label1" runat="server" Text="إدخال عنصر جديد"></asp:Label>
                                </asp:LinkButton>
                            </td>

                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td colspan="4">
                                <asp:HiddenField runat="server" ID="FilterValueControl" Value='<%# Bind("ID") %>' />
                                <asp:LinkButton Text="تعديل" CommandArgument='<%# Bind("ID") %>' OnClick="Editor_ImageButton_Click"
                                    ID="Editor_LinkButton" runat="server">
                        <%--<asp:Image ID="EditImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>--%>
                                </asp:LinkButton>
                                <asp:LinkButton ToolTip="حذف" Text="حذف" OnClick="Delete_LinkButton_OnClick" CommandArgument='<%# Bind("ID") %>' ID="Delete_LinkButton"
                                    runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                       <%-- <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' CssClass="NoMargin"
                            runat="server"></asp:Image>--%>
                                </asp:LinkButton>

                                <asp:LinkButton Text="عرض" CommandArgument='<%# Bind("ID") %>' OnClick="Editor_ImageButton_Click2"
                                    ID="LinkButton2" runat="server">
                        <%--<asp:Image ID="EditImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>--%>
                                </asp:LinkButton>
                            </td>
                            <td>
                                
                            <asp:Label Text='<%# Eval("SerialNo") %>' runat="server" ID="Label2" />
                            </td>
                            <td>
                                
                            <asp:Label Text='<%# Eval("Admin_Name") %>' runat="server" ID="Admin_NameLabel" />
                            </td>
                        
                        <td>
                            <asp:Label Text='<%# getadmintype2(Eval("Admin_type_id"))  %>' runat="server" ID="EmailLabel" /></td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" style=" font-size: larger; font-weight: bold; align-content: center;width: 100%">
                            <tr runat="server">
                                <td runat="server">
                                    <table runat="server" id="itemPlaceholderContainer" style="width: 100%;background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                            <th runat="server" colspan="4">التحكم</th>
                                            <th runat="server">رقم الاستمارة</th>
                                            <th runat="server">الاسم</th>
                                           
                                            <th runat="server">نوع القائد</th>
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                    <asp:DataPager runat="server" ID="DataPager1">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                </asp:ListView>


              
                </div>

                <asp:LinqDataSource runat="server" ID="LinqDataSource1" EntityTypeName="" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID,Admin_Name, National_ID, Phone_Number, Birth_Date, Birth_Place, Address, Email,Personal_Image,University_id,Admin_type_id,SerialNo)" TableName="Higher_Admins"
                    EnableDelete="True" EnableUpdate="True" Where="University_id == @University_id">
                    <WhereParameters>
                        <asp:SessionParameter SessionField="UniID" Name="University_id" Type="Int32"></asp:SessionParameter>
                    </WhereParameters>
                </asp:LinqDataSource>
                
                
                
                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_OnClick"  runat="server">عودة</asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
