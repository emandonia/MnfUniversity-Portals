<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Common.LoginControl" %>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
     
         <ContentTemplate>
<asp:Panel ID="LoginPanel" runat="server">
    <asp:Login ID="MainLogin" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
        OnLoggingIn="MainLogin_LoggingIn" Font-Size="0.8em" ForeColor="#333333" meta:resourcekey="Login1Resource1"
        OnLoggedIn="MainLogin_LoggedIn" OnLoginError="MainLogin_LoginError" Style="width: 267px">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LayoutTemplate>
            <div id="loginForm">
                <fieldset id="body">
                    <fieldset>

                        <label runat="server" id="usernameFieldLabel" for="email">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="Small"
                                meta:resourcekey="UserNameLabelResource1" Text="User Name:"></asp:Label></label>

                        <asp:TextBox name="email" ID="UserName" runat="server" meta:resourcekey="UserNameResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="User Name is required." meta:resourcekey="UserNameRequiredResource1"
                            Text="*" ToolTip="User Name is required." ValidationGroup="ctl00$Login1"></asp:RequiredFieldValidator>
                    </fieldset>
                    <fieldset>
                        <label for="password" runat="server" id="passwordFieldLabel">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="Small"
                                meta:resourcekey="PasswordLabelResource1" Text="Password:"></asp:Label></label>
                        <asp:TextBox name="password" ID="Password" runat="server" meta:resourcekey="PasswordResource1"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ErrorMessage="Password is required." meta:resourcekey="PasswordRequiredResource1"
                            Text="*" ToolTip="Password is required." ValidationGroup="ctl00$Login1"></asp:RequiredFieldValidator>
                    </fieldset>
                    <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                        BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                        ForeColor="#284775" meta:resourcekey="LoginButtonResource1"
                        Text="Log In" ValidationGroup="ctl00$Login1" />
                   <div>

                       <asp:Literal ID="FailureText" meta:resourcekey="FailureTextResource1" runat="server" Visible="False" ></asp:Literal></div>
                </fieldset>

            </div>


        </LayoutTemplate>

    </asp:Login>
</asp:Panel>
</ContentTemplate>
    </asp:UpdatePanel>