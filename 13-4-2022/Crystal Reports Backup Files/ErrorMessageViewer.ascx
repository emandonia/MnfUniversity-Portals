<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorMessageViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.ErrorMessageViewer" %>


<asp:LinkButton ID="dummy" runat="server" Style="display: none"></asp:LinkButton>
<ajaxtk:ModalPopupExtender ID="ErrorMessage_ModalPopupExtender" runat="server" Enabled="True"
    TargetControlID="dummy" PopupControlID="Panel1" PopupDragHandleControlID="Panel2"
    CancelControlID="ImageButton1" BackgroundCssClass="modalBackground" RepositionMode="None">
</ajaxtk:ModalPopupExtender>



<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
    <asp:Panel ID="Panel2" runat="server" CssClass="Handel_Panel" >
        <div class="Handel_Table">
            <div style="float: <%=StaticUtilities.FloatRight%>" class="Handel_Label">
                <asp:Localize ID="TitleLocalize" runat="server" Text="Title"></asp:Localize>
            </div>
            <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/styles/Main/images/close.png"
                      />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server"   Style="width: 100%;">
        <asp:Label EnableViewState="False" ID="MessageLabel" runat="server" Style="font-size: xx-large; color: Red; margin: 20px"
            Text="Message"></asp:Label>
    </asp:Panel>
</asp:Panel>
