<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.MenuViewer" %>

<asp:UpdatePanel ID="MenuUpdatePanel" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div runat="server" id="MenuDiv">
             
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
</asp:UpdatePanel>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.MenuViewer" %>

<asp:UpdatePanel ID="MenuUpdatePanel" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <!-- Add the CSS style directly in the ContentTemplate -->
        <style>
          /*********************************7-2-2025*/
            /* Dropdown/second-level menu (hidden by default) */
            .PrettyMenu li ul {
                display: none; /* Initially hidden */
                position: absolute;
                top: 100%; /* Position it below the parent item */
                left: 0;
              /*  background-color: #CFDBE4;*/
                list-style-type: none;
                padding: 0;
                margin: 0;
                border-radius: 5px;
                z-index: 100;
            }
 
            /* Style for links inside sub-menus */
            .PrettyMenu li ul li a {
                padding: 10px;
                /*background-color: #CFDBE4;*/
            }
 
            
        </style>

        <div runat="server" id="MenuDiv">
            <asp:Menu  ID="CurrentMenu" DataSourceID="MenuXmlDataSource" StaticSubMenuIndent="20" 
                OnMenuItemDataBound="VerticalMenu_MenuItemDataBound"
                StaticPopOutImageUrl="~/styles/CommonImages/arrow_down_h.gif" 
                DynamicPopOutImageUrl="~/styles/CommonImages/arrow_down_v.gif" 
                runat="server" ItemWrap="False" CssSelectorClass="PrettyMenu">
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
