
<%@ Control AutoEventWireup="True" CodeBehind="EventSliderControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.EventSliderControl"
    Language="C#" %>

<asp:Panel OnLoad="ManageHighlightItemPanel_Load" ID="InsertHighlightItemPanel" runat="server">
    <asp:LinkButton ID="AddHighlightItemButton" OnClick="AddHighlightItemButton_Click" runat="server">
        <asp:Image ID="Image1" ImageUrl="~/styles/UserControlImages/insert.png" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Add NewsItem" meta:resourcekey="AddNew"></asp:Label>
    </asp:LinkButton>
</asp:Panel>

<obshow:Show ID="HighlightsShow" runat="server" TransitionType="fading" ScrollingSpeed="50000" ScrollingStep="40" TimeBetweenPanels="3000"  Width="100%" Height="520px"
    ShowType="Show" ManualChanger="True" Changer-Type="Both" Changer-ArrowType="BothSides"
    ImagesFitAvailableSize="True"  StopScrolling="True"
  SelectedPanel="0">
    <Changer Width="370" ArrowType="BothSides" Type="Both" Height="65" HorizontalAlign="center" />
</obshow:Show>


<asp:Panel OnLoad="ManageHighlightItemPanel_Load"
    
     ID="ManageHighlightItemPanel" runat="server">
    <uc:HighlightsDetailsViewControl OnDetailsView_ItemInserted="InlineHighlightsDetailsViewControl_ItemInserted" OnDetailsView_ItemUpdated="InlineHighlightsDetailsViewControl_ItemUpdated"
        ID="InlineHighlightsDetailsViewControl" runat="server" />
</asp:Panel>


            

