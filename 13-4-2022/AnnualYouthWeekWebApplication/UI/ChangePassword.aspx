<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:Label ID="Label1" Visible="False" runat="server" ></asp:Label><br/><br/>
    <table style="width: 100%;">
        <tr>
            <td>ادخل كلمة المرور القديمة</td>
            <td><asp:TextBox ID="TextBox1" TextMode="Password" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
           
            <td>ادخل كلمة المرور الجديدة</td>
            <td><asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>
            <asp:Button CssClass="btn" ID="Button1" OnClick="Button1_OnClick" runat="server" Text="تغيير كلمة السر" /></td>
        </tr>

    </table>


</asp:Content>
