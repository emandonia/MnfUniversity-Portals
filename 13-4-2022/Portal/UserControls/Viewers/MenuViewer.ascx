<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.MenuViewer" %>

<asp:UpdatePanel ID="MenuUpdatePanel" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div runat="server" id="MenuDiv">
             <%--<asp:Panel ID="InsertMenuItemPanel" runat="server" BackColor="#3B5998" BorderColor="Blue" BorderWidth="2" BorderStyle="Solid">--%>
            <%--<asp:ImageButton ID="InsertLinkButton" ToolTip="Insert New MenuItem" runat="server"
                ImageUrl="~/styles/UserControlImages/insert.png" OnClick="MenuEditorControlInsertClicked"
                AlternateText="Insert" />
            <asp:ImageButton ID="EditModeImageButton" ToolTip="Enter Edit Mode " runat="server"
                ImageUrl="~/styles/UserControlImages/edit.png" OnClick="EditModeImageButton_Click"
                AlternateText="Edit Mode" />--%>
          <%--  <asp:ImageButton ID="DeleteModeImageButton" ToolTip="Enter Delete Mode" runat="server"
                ImageUrl="~/styles/UserControlImages/delete.png" OnClick="DeleteModeImageButton_Click"
                AlternateText="Delete Mode" />--%>
           <%-- <asp:ImageButton ID="NormalModeImageButton" ToolTip="Enter Normal Mode" runat="server"
                ImageUrl="~/styles/UserControlImages/cancel.png" OnClick="NormalModeImageButton_Click"
                AlternateText="Normal Mode" />--%>
           <%--<br />
            <asp:Label EnableViewState="True" ViewStateMode="Enabled" ID="CurrentModeLabel" Font-Size="small" runat="server"></asp:Label>
            <uc:MenuDetailsViewControl ID="QuickEditMenuDetailsViewControl" OnDetailsView_ItemInserted="EditorDetailsView_ItemInserted"
                OnDetailsView_ItemUpdated="EditorDetailsView_ItemUpdated" runat="server" />
            <div style="display: none">
                <ajaxtk:ComboBox Width="10px" ID="Combo" runat="server">
                </ajaxtk:ComboBox>
            </div>--%>
       <%-- </asp:Panel><br/>--%>
           <%-- OnMenuItemDataBound="VerticalMenu_MenuItemDataBound" --%>
            <asp:Menu  ID="CurrentMenu" DataSourceID="MenuXmlDataSource" StaticSubMenuIndent="20" OnMenuItemDataBound="VerticalMenu_MenuItemDataBound"
             StaticPopOutImageUrl="~/styles/CommonImages/arrow_down_h.gif" DynamicPopOutImageUrl="~/styles/CommonImages/arrow_down_v.gif"  runat="server" ItemWrap="False">
                <DataBindings>
                    <asp:MenuItemBinding
                        ValueField="Id"
                        TextField="TitleAr"
                        NavigateUrlField="Url" TargetField="Url_target" />
                </DataBindings>
                

            </asp:Menu>
            <asp:XmlDataSource EnableCaching="False" ID="MenuXmlDataSource" runat="server"></asp:XmlDataSource>
        </div>
           
</ContentTemplate>
</asp:UpdatePanel>
