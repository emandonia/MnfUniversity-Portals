<%@ Control AutoEventWireup="true" CodeBehind="ResxEditor.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.ResxEditor"
    Language="C#" %>
<%@ Register TagPrefix="resx" Namespace="App_Code.Code" Assembly="Portals" %>
<div style="">
    <div style="width: auto;">
        <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Literal2Resource1" Text="Resource Translation"></asp:Literal>
    </div>
    <div style="clear: both; width: auto;">
        <div style="float: left;">
            <asp:ListBox ID="lstResX" runat="server" AutoPostBack="True" Height="150px" OnSelectedIndexChanged="lstResX_SelectedIndexChanged"
                Width="250px" meta:resourcekey="lstResXResource1" />
        </div>
        <br />
        <asp:Panel ID="pnlAddLang" runat="server" Visible="False" Style="float: right; margin-right: 15px;"
            meta:resourcekey="pnlAddLangResource1">
            <asp:Literal ID="Literal1" runat="server" Text="Add new language:" meta:resourcekey="Literal1Resource1" /><br />
            <asp:DropDownList ID="ddLanguage" runat="server" meta:resourcekey="ddLanguageResource1" />
            <asp:Button ID="btAddLang" runat="server" OnClick="btAddLang_Click" OnClientClick="this.disable=true;"
                Text="Add" meta:resourcekey="btAddLangResource1" />
            <br />
            <br />
            <asp:CheckBox ID="chShowEmpty" runat="server" Text="Show empty strings" AutoPostBack="True"
                OnCheckedChanged="OnShowEmpty" meta:resourcekey="chShowEmptyResource1" />
        </asp:Panel>
        <br style="clear: both" />
        <table style="width: 100%;">
            <tr>
                <td>
                    <h2>
                        <asp:Label ID="lblFileName" runat="server" meta:resourcekey="lblFileNameResource1" /></h2>
                    <div style="width: 650px; height: 400px; overflow: auto">
                        <resx:BulkEditGridViewEx AutoGenerateColumns="False" CssClass="GridViewTranslate"
                            DataKeyNames="Key" EnableInsert="False" ID="gridView" InsertRowCount="1" meta:resourcekey="gridViewResource1"
                            OnRowDataBound="GridView_RowDataBound" OnRowUpdating="gridView_RowUpdating" OnSaved="gridView_Saved"
                            runat="server" SaveButtonID="btSave" Width="630px" />
                    </div>
                    <br />
                    <asp:Button ID="btSave" runat="server" Text="Save" Visible="False" meta:resourcekey="btSaveResource1" /><br />
                    <br />
                    <asp:Panel ID="pnlMsg" runat="server" EnableViewState="False" Visible="False" meta:resourcekey="pnlMsgResource1">
                        <asp:MultiView ID="MultiViewMsg" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:Image ID="imgResult" runat="server" ImageUrl="~/styles/TranslationEditor/Images/tick.png"
                                    meta:resourcekey="imgResultResource1" />
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/styles/TranslationEditor/Images/exclamation.png"
                                    meta:resourcekey="Image1Resource1" />
                            </asp:View>
                        </asp:MultiView>
                        <asp:Label ID="lblMsg" runat="server" Style="padding-left: 10px; position: relative; top: -5px;"
                            meta:resourcekey="lblMsgResource1" Text="Saved sucessfully " />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</div>