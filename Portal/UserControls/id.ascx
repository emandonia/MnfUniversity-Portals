<%@ Control Language="C#" AutoEventWireup="true" CodeFile="id.ascx.cs" Inherits="WebUserControl" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
    }
    .auto-style3 {
        height: 23px;
    }
    .auto-style4 {
        height: 59px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td  align ="right" class="auto-style3" colspan="2">
                    <asp:Label ID="Label2" runat="server" Text="نتيجة الدبلوم العام"></asp:Label>
        </td>
    </tr>
    <tr>
                <td align="right" class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="depart" DataValueField="id" OnDataBound="dept_bound">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:الأولى  2014المحموعةConnectionString %>" ProviderName="<%$ ConnectionStrings:الأولى  2014المحموعةConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Departs]"></asp:SqlDataSource>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="برجاء اختيار القسم بطريقة صحيحة" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                </td>
                <td align="right" class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="القسم"></asp:Label>
                </td>
            </tr>
    <tr>
        <td  align ="right" class="auto-style2">
            <asp:TextBox ID="TextBox1" runat="server" Width="288px"></asp:TextBox>
        </td>
        <td  align ="center">
            <asp:Label ID="Label1" runat="server" Text="رقم الجلوس"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align ="center">
            <br />
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:الثانية  2014المحموعةConnectionString %>" ProviderName="<%$ ConnectionStrings:الثانية  2014المحموعةConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [A10Grades]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" Text="النتيجة" OnClick="Button1_Click" />
        </td>
    </tr>
</table>



