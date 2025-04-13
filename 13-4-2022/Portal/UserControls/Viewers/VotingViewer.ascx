<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VotingViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.VotingViewer" %>

<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <asp:Label ID="NoTranslation" Visible="False" meta:resourcekey="NoTranslation" runat="server" ></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
        <table style="direction: <%=Dir%>;">
            <tr>
                <td style="direction: <%=Dir%>; text-align: <%=StaticUtilities.FloatRight%>">
                    <asp:Label ID="QuesLbl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="direction: <%=Dir%>;">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="1"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="ans1" runat="server" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="ans1width" CssClass="voteImage" ImageUrl="Images/Images/votingbar.png"
                        Visible="false" runat="server" />
                </td>
                <td>
                    <asp:Label ID="ans1perc" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="direction: <%=Dir%>;">
                    <asp:Label ID="ans2" runat="server" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="ans2width" CssClass="voteImage" ImageUrl="Images/Images/votingbar.png"
                        Visible="false" runat="server" />
                </td>
                <td>
                    <asp:Label ID="ans2perc" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="direction: <%=Dir%>;">
                    <asp:Label ID="ans3" runat="server" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="ans3width" CssClass="voteImage" ImageUrl="Images/Images/votingbar.png"
                        Visible="false" runat="server" />
                </td>
                <td>
                    <asp:Label ID="ans3perc" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" class="style4">
                    <asp:Button ID="VoteButton" runat="server" OnClick="VotingButton_OnClick" Text="Vote" />
                </td>
            </tr>
        </table>
            </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>