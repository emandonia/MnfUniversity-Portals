<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="PasswordRecovery.aspx.cs" Inherits="MnfUniversity_Portals.UI.Admin.PasswordRecovery" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
            <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Insert Your User Name" meta:resourcekey="UserNameLabelResource1"></asp:Label></td>
                    
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>            
                </tr>
                <tr><td><asp:LinkButton ID="LinkButton1" ForeColor="blue" Text="If You Forgot Your Password, Click Here" meta:resourcekey="ForgotLabelResource1" runat="server"></asp:LinkButton>  </td></tr>
                
              
                <tr>
                    <td><asp:Button ID="Button1" runat="server" OnClick="SubmitButtonOnClick" Text="Submit" meta:resourcekey="ForgotButtonResource1" /></td>     
                </tr>
              
            </table>
            <asp:Panel ID="Panel1" Visible="False" runat="server">
    <asp:Label ID="Label1"  runat="server" Text="Your Password is: " meta:resourcekey="PassLabelResource1"></asp:Label>
    <asp:Label ID="Label2"  runat="server" ></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel2" Visible="False" runat="server">
                <asp:Label ID="Label4" ForeColor="red" runat="server" Text="User Not Found" meta:resourcekey="UserNotFoundLabelResource1"></asp:Label>

            </asp:Panel>
              </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>