<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="PageTranslationEditor" Culture="auto" UICulture="auto" CodeBehind="PageTranslationEditor.aspx.cs" %>

<%@ Register TagPrefix="resxEditor" TagName="ResXEditor" Src="~/UserControls/Editors/ResxEditor/ResxEditor.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <asp:UpdateProgress ID="UpdateProgress" runat="server" DisplayAfter="300" AssociatedUpdatePanelID="UpdatePanel" DynamicLayout="False">
            <ProgressTemplate>
                <asp:Panel ID="progressPanel" runat="server"
                    meta:resourcekey="progressPanelResource1">

                    <asp:Image ID="imgLoading" runat="server" SkinID="LoadingImage"
                        meta:resourcekey="imgLoadingResource1" />
                    <span style="padding-left: 8px;">
                        <asp:Literal ID="Literal1" runat="server"
                            meta:resourcekey="Literal1Resource1" Text="Please wait..."></asp:Literal>
                    </span>
                </asp:Panel>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <resxEditor:ResXEditor ID="editor" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>