<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailsBasedControlTemplate.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Base.DetailsBasedControlTemplate" %>
<asp:ImageButton ID="Dummy" runat="server" Style="display: none" />
<ajaxtk:ModalPopupExtender ID="Editor_ModalPopupExtender" runat="server" Enabled="true"
    TargetControlID="Dummy" PopupControlID="Editor_Panel" PopupDragHandleControlID="Editor_HandelPanel"
    CancelControlID="CancelEditorImageButton" BackgroundCssClass="modalBackground"
    RepositionMode="None" />
<asp:TextBox ID="Test" Style="display: none" runat="server"
    Width="80px"></asp:TextBox>
<ajaxtk:CalendarExtender runat="server" TargetControlID="Test">
</ajaxtk:CalendarExtender>
<asp:Panel ID="Editor_Panel" runat="server" Style="display: none" CssClass="modalPopup">
    <asp:Panel ID="Editor_HandelPanel" CssClass="Handel_Panel" runat="server">
        <div style="float: <%=floatright%>" class="Handel_Label">
            <asp:Localize ID="EditorTitleLocalize" runat="server" Text=""></asp:Localize>
        </div>
        <div style="float: <%=floatleft%>" class="Handle_Controlbox">
            <div style="float: <%=floatleft%>" class="Handle_Controlbox">
                <div style="float: <%=floatright%>">
                    <asp:ImageButton ID="MaximizeImageButton" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
                    <asp:ImageButton ID="RestoreImageButton" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display: none;" OnClientClick="maximize_restore(this);return false;" />
                </div>
                <div style="float: <%=floatleft%>">
                    <asp:ImageButton ID="CancelEditorImageButton" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <div id="EditorDiv">
        <asp:DetailsView ID="Editor_DetailsView" CssClass="Editor_DetailsView" runat="server"
            AllowPaging="True" AutoGenerateRows="False" CellPadding="4" 
            GridLines="None" EmptyDataText="No Data" OnLoad="Editor_DetailsView_Load"
            OnItemCreated="Editor_DetailsView_ItemCreated" OnPreRender="Editor_DetailsView_PreRender"
            OnDataBound="Editor_DetailsView_DataBound" OnItemDeleted="Editor_DetailsView_ItemDeleted"
            OnItemInserting="Editor_DetailsView_ItemInserting" OnItemInserted="Editor_DetailsView_ItemInserted"
            OnItemDeleting="Editor_DetailsView_ItemDeleting" OnItemUpdating="Editor_DetailsView_ItemUpdating"
            OnItemUpdated="Editor_DetailsView_ItemUpdated" OnModeChanging="Editor_DetailsView_ModeChanging"
            OnPageIndexChanging="EditorDetailsView_PageIndexChanging">
            <Fields>
                <asp:TemplateField meta:resourcekey="Language" HeaderText="Language">
                    <EditItemTemplate>
                        <asp:Label ID="Language" Text='<%# StaticUtilities.LanguageName( Eval("prtl_Language.LCID")) %>' runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="LangDropDownList" runat="server">
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%# StaticUtilities.LanguageName(Eval("prtl_Language.LCID")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
            <CommandRowStyle CssClass="Editor_CommandRowStyle" />
            <EditRowStyle CssClass="Editor_EditRowStyle" />
            <FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
            <FooterStyle CssClass="Editor_FooterStyle" />
            <HeaderStyle CssClass="Editor_HeaderStyle" />
            <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
            <RowStyle CssClass="Editor_RowStyle" />
        </asp:DetailsView>
    </div>
</asp:Panel>
