<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="CompEmployee.aspx.cs" Inherits="MnfUniversity_Portals.UI.CompEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<asp:Label ID="Label6" runat="server" Text=".برجاء العلم ان هذه الصفحة لإرسال الشكاوي والاستفسارات والمقترحات الخاصة بالعاملين بالجامعة " Font-Bold="true" Font-Size="Larger" ForeColor="blue"></asp:Label></br>
<asp:Label ID="Label7" runat="server" Text="لسرعة الاستجابة لشكواكم برجاء كتابة ايميل او رقم تليفون صالح وشكرا " Font-Bold="true" Font-Size="Larger" ForeColor="red"></asp:Label></br></br>
<table style="width:100%">

  <td>
            <asp:Label ID="Label5" runat="server" meta:resourcekey="choose" Text="choose"> </asp:Label>
        </td>
        <td colspan="2">
             <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" CssClass ="textboxservice2"
                                            meta:resourcekey="DropDownList1Resource1">
                                            <asp:ListItem Value="-1" meta:resourcekey="ListItemResource0">اختر</asp:ListItem>
                  <asp:ListItem Value="1" meta:resourcekey="ListItemResource1">شكوى</asp:ListItem>
                  <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">مقترح</asp:ListItem>
                  <asp:ListItem Value="3" meta:resourcekey="ListItemResource3">استفسار</asp:ListItem>
                                        </asp:DropDownList>
              </td> 
<tr>
<td>
     <td>
      <td>
      </td>
</tr>

    <tr>
<td>
    <td>
    <td>
       </td>
</tr>

    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" meta:resourcekey="name" Text="name"> </asp:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtName" runat="server" CssClass="textboxservice2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="حقل مطلوب" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
<tr>
<td>
<asp:Label ID="Label2" runat="server" Text="mobile" meta:resourcekey="mobile"></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txtMobile" CssClass="textboxservice2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobile" ErrorMessage="حقل مطلوب" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label3" runat="server" Text="Email" meta:resourcekey="Email"></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txtEmail" runat="server" CssClass="textboxservice2"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="حقل مطلوب"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td>
<asp:Label ID="Label4" runat="server" Text="Complain" meta:resourcekey="complain"></asp:Label>
</td>
<td colspan="2">
<asp:TextBox ID="txtComp" CssClass="textboxservice2" runat="server" TextMode="MultiLine" Height="199px" Width="396px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComp" ForeColor="red" ErrorMessage="حقل مطلوب"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" meta:resourcekey="Send" />
</td>
</tr>
<tr><td>
<asp:Label ID="sentlabel" runat="server" ForeColor="red" Text=""></asp:Label>
</td></tr>
</table>
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
