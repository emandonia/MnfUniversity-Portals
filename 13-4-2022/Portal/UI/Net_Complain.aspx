<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LibraryMaster.Master" AutoEventWireup="true" CodeBehind="Net_Complain.aspx.cs" Inherits="MnfUniversity_Portals.UI.Net_Complain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 142px;
        }
        .auto-style2 {
            width: 172px
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
    
    <div style="float: none;" align="center">

        <table style="width: 500px;font-weight: bold">
    <tr><td colspan="2" style="text-align: center">
        نموذج تسجيل اعطال</td></tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label1" runat="server" meta:resourcekey="Fac" Text="Choose Faculty:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="FacDropDownList" runat="server" CssClass="textboxservice2">
                    <%--<asp:ListItem Value="-1">اختر</asp:ListItem>--%>
                    <asp:ListItem Value="22">كلية الحاسبات والمعلومات</asp:ListItem>
                    <asp:ListItem Value="5">كلية الهندسة الإلكترونية</asp:ListItem>
                    <asp:ListItem Value="4">كلية الاداب</asp:ListItem>
                    <asp:ListItem Value="24">كلية العلوم</asp:ListItem>
                    <asp:ListItem Value="23">كلية الهندسة</asp:ListItem>
                    <asp:ListItem Value="25">كلية التجارة</asp:ListItem>
                    <asp:ListItem Value="39">كلية الحقوق</asp:ListItem>
                    <asp:ListItem Value="43">كلية الطب</asp:ListItem>
                    <asp:ListItem Value="42">كلية الاقتصاد المنزلي</asp:ListItem>
                    <asp:ListItem Value="30">كلية التربية</asp:ListItem>
                    <asp:ListItem Value="41">كلية التربية النوعية</asp:ListItem>
                    <asp:ListItem Value="31">كلية التمريض</asp:ListItem>
                    <asp:ListItem Value="40">كلية الزراعة</asp:ListItem>
                    <asp:ListItem Value="38">معهد الكبد </asp:ListItem>
                    <asp:ListItem Value="4659">المستشفيات الجامعية</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FacDropDownList" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="lbl1" runat="server" meta:resourcekey="EngName" Text="Engineer"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEngName" runat="server" CssClass="textboxservice2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEngName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label2" runat="server" meta:resourcekey="Date" Text="Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="DateTextBox" runat="server" ValidationGroup="InsertGroup"
                        ViewStateMode="Enabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="DateTextBox"
                        SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender Format='<%# StaticUtilities.DateTimeFormat %>' ViewStateMode="Enabled" EnableViewState="True" ID="DateCalendarExtender1"
                        runat="server" TargetControlID="DateTextBox">
                    </ajaxtk:CalendarExtender>
                   
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label3" runat="server" meta:resourcekey="Informer" Text="Informer"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxservice2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label4" runat="server" meta:resourcekey="Damage" Text="Damage"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="textboxservice2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label5" runat="server" meta:resourcekey="Fixing" Text="Fixing"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="textboxservice2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Label ID="Label6" runat="server" meta:resourcekey="Notes" Text="Notes"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Columns="10" CssClass="textboxservice2" Rows="10" TextMode="MultiLine" Width="170px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Button ID="Button1" runat="server" CssClass="btn1" meta:resourcekey="Search" OnClick="SearchButtonClicked" Text="Search" />
            </td>
        </tr>
            <tr>
            <td class="auto-style2" >
                <asp:Label ID="errorlbl" runat="server" Visible="False" meta:resourcekey="status" ForeColor="red" Font-Bold="True" Text="Report Sent successfully"></asp:Label>
            </td>
        </tr>
         
            </table>

    </div>
    
 
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
