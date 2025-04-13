<%@ Page Title="نسيان كلمة السر" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgetpassword.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.Forgetpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>ادخل اسم المستخدم:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td><asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_OnClick" runat="server">إستعادة ضبط كلمة السر</asp:LinkButton></td>
            
        </tr>
        <tr><td>
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></td></tr>
    </table>
    

</asp:Content>
