<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Admin.AdminPreferences" CodeBehind="AdminPreferences.aspx.cs" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <uc:FDDL ID="FilterControl" OnSearchClicked="FilterControl_SearchClicked" runat="server" />
            <asp:Label ID="Label6" runat="server" Text="Choose OwnerType:"></asp:Label>

            <asp:DropDownList ID="OwnerTypeDropDownList" OnSelectedIndexChanged="OwnerTypeDropDownList_SelectedIndexChanged"
                runat="server" AutoPostBack="True" /><a href="../OutstandingResearches.aspx">../OutstandingResearches.aspx</a>
            <br />
            <ajaxtk:TabContainer ID="MainTabContainer" runat="server">
                <ajaxtk:TabPanel ID="OwnersManagement_TabPanel" runat="server" HeaderText="OwnersManagement">
                    <HeaderTemplate>
                        <asp:Localize ID="Localize2" runat="server" Text=" Owners Management Settings"></asp:Localize>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <br />
                        <br />

                        <asp:ListView ID="OwnersListView" OnItemInserted="OwnersListViewControl_ItemInserted" runat="server" DataKeyNames="Owner_ID" OnItemInserting="OwnersListView_ItemInserting"
                            OnItemDeleting="OwnersListView_ItemDeleting" OnItemUpdating="OwnersListViewControl_ItemUpdating" DataSourceID="OwnersLinqDataSource"
                            InsertItemPosition="LastItem">
                            <EditItemTemplate>
                                <tr class="ListViewItemTemplateRow">
                                    <td class="ActionDiv">
                                        <asp:ImageButton ID="Update_ImageButton" CommandName="Update" ImageUrl="~/styles/Main/images/update.png"
                                            runat="server" ValidationGroup="EditValidation" CausesValidation="False" />
                                        <asp:ImageButton ID="Cancel_ImageButton" CommandName="Cancel" CausesValidation="False"
                                            ImageUrl="~/styles/Main/images/cancel.png" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="UniName_Label" runat="server" Text='<%#OwnerName(Eval("Owner_ID")) %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ValidationGroup="EditValidation" ID="EditFacAbbTextBox" Text='<%# Bind("Abbr") %>'
                                            runat="server">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="EditFacAbbTextBox"
                                            ValidationGroup="EditValidation" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Themes_DropDownList1" Text='<%# Bind("Name") %>' DataSourceID="ThemeDataSource"
                                            DataTextField="name" DataValueField="name" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="Themes_DropDownList1"
                                            ValidationGroup="vinsert" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <tr class="ListViewItemTemplateRow">
                                    <td class="ActionDiv">
                                        <asp:ImageButton ID="Editor_ImageButton" OnClick="Editor_ImageButton_Click" ImageUrl="~/styles/Main/images/Language.png"
                                            CommandArgument='<%# Eval("Owner_ID") %>' runat="server" CausesValidation="False" />
                                        <asp:ImageButton ID="EditRow_ImageButton" ImageUrl="~/styles/Main/images/edit.png"
                                            CommandName="Edit" runat="server" CausesValidation="False" />
                                        <asp:ImageButton ID="ImageButton1" CausesValidation="False" CommandName="Delete"
                                            OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                                            ImageUrl="~/styles/Main/images/delete.png" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="UniName_Label" runat="server" Text='<%# OwnerName(Eval("Owner_ID")) %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Abbr") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Theme") %>' />
                                    </td>
                                    <td class="DirLTR">
                                        <asp:Label ID="NotDoneLabel" runat="server" Text='<%# Done(Eval("Owner_ID")) %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <InsertItemTemplate>
                                <td class="ActionDiv">
                                    <asp:ImageButton ID="Insert_ImageButton" CommandName="Insert" ImageUrl="~/styles/Main/images/insert.png"
                                        runat="server" ValidationGroup="vinsert" CausesValidation="true" />
                                </td>
                                <td class="ListViewEditRowData">
                                    <asp:TextBox ID="InsertOwnerTextBox" runat="server" ValidationGroup="vinsert" CausesValidation="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="InsertOwnerTextBox"
                                        ValidationGroup="vinsert" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ListViewEditRowData">
                                    <asp:TextBox ID="InsertAbbrTextBox" Text='<%# Bind("Abbr") %>' runat="server" ValidationGroup="vinsert"
                                        CausesValidation="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="InsertAbbrTextBox"
                                        ValidationGroup="vinsert" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ListViewEditRowData">
                                    <asp:DropDownList ID="Themes_DropDownList1" Text='<%# Bind("Name") %>' ValidationGroup="vinsert"
                                        CausesValidation="true" DataSourceID="ThemeDataSource" DataTextField="name" DataValueField="name"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                            </InsertItemTemplate>
                            <LayoutTemplate>
                                <table id="Table1" runat="server">
                                    <tr id="Tr1" runat="server">
                                        <td id="Td1" runat="server">
                                            <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                                                <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                                                    <th id="Th4" runat="server">
                                                        <asp:Label ID="Label8" runat="server" Text="Actions"></asp:Label>
                                                    </th>
                                                    <th id="Th3" runat="server">
                                                        <asp:Label ID="Label4" runat="server" Text="Owner Name"></asp:Label>
                                                    </th>
                                                    <th id="Th1" runat="server">
                                                        <asp:Label ID="Label5" runat="server" Text="Abbr"></asp:Label>
                                                    </th>
                                                    <th id="Th7" runat="server">
                                                        <asp:Label ID="Label1" runat="server" Text="Theme"></asp:Label>
                                                    </th>
                                                    <th id="Th5" runat="server">
                                                        <asp:Label ID="Label9" runat="server" Text="Done"></asp:Label>
                                                    </th>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                        <asp:ObjectDataSource ID="ThemeDataSource" runat="server" SelectMethod="GetThemes"
                            TypeName="App_Code.ThemeManager"></asp:ObjectDataSource>
                        <asp:LinqDataSource ID="OwnersLinqDataSource" runat="server" OnInserted="OwnersLinqDataSource_Inserted"
                            ContextTypeName="Portal_DAL.PortalDataContextDataContext" EnableDelete="True"
                            EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="prtl_Owners"
                            Where="prtl_Owner1.Owner_ID ==Guid (@ID) && Type == Int32 (@xx)">
                            <WhereParameters>

                                <asp:SessionParameter Name="ID" DbType="Guid" SessionField="EditorParentOwner_ID" />

                                <asp:ControlParameter ControlID="OwnerTypeDropDownList" Name="xx"
                                    PropertyName="SelectedValue" DbType="Int32" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                        <asp:ImageButton ID="Dummy" runat="server" Style="display: none" />
                        <ajaxtk:ModalPopupExtender ID="Editor_ModalPopupExtender" runat="server" Enabled="True"
                            TargetControlID="Dummy" PopupControlID="Editor_Panel" PopupDragHandleControlID="Editor_HandelPanel"
                            CancelControlID="CancelEditorImageButton" BackgroundCssClass="modalBackground"
                            RepositionMode="None" DynamicServicePath="" />
                        <asp:Panel ID="Editor_Panel" runat="server" Style="display: none" CssClass="modalPopup">
                            <asp:Panel ID="Editor_HandelPanel" CssClass="Handel_Panel" runat="server">
                                <div class="Handel_Table">
                                    <div style="float: <%= StaticUtilities.FloatRight %>" class="Handel_Label">
                                        <asp:Localize ID="Localize1" runat="server" Text="Faculties Settings"></asp:Localize>
                                    </div>
                                    <div style="float: <%= StaticUtilities.FloatLeft %>" class="Handle_Controlbox">
                                        <asp:ImageButton ID="CancelEditorImageButton" runat="server" ImageUrl="~/styles/Main/images/cancel.png" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <div>
                                <asp:DetailsView ID="Editor_DetailsView" CssClass="Editor_DetailsView" runat="server"
                                    AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="Translation_ID"
                                    GridLines="None" OnModeChanging="Editor_DetailsView_ModeChanging" OnItemDeleted="Editor_DetailsView_ItemDeleted"
                                    OnItemInserting="Editor_DetailsView_ItemInserting" OnItemUpdated="Editor_DetailsView_ItemUpdated" OnItemDeleting="Editor_DetailsView_ItemDeleting" OnItemInserted="Editor_DetailsView_ItemInserted" DataSourceID="TranslationsLinqDataSource"
                                    OnPageIndexChanging="Editor_DetailsView_PageIndexChanging" OnItemCreated="DetailsView_ItemCreated">
                                    <Fields>
                                        <asp:TemplateField HeaderText="Language">
                                            <EditItemTemplate>
                                                <asp:Label ID="Language" runat="server" Text='<%#StaticUtilities.LanguageName( Eval("prtl_Language.LCID"))%>' />
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="LangDropDownList" DataTextField="Text" DataValueField="Value"
                                                    DataSource='<%#BLL.Prtl_LanguagesUtility.AllLanguagesExceptAdded(Translation_Id) %>'
                                                    runat="server">
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Language" runat="server" Text='<%# StaticUtilities.LanguageName( Eval("prtl_Language.LCID")) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Owner Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTitle1" runat="server" Text='<%# Bind("Translation_Data") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                                                    ValidationGroup="UpdateGroup" ControlToValidate="txtTitle1"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtTitle2" Text='<%# Bind("Translation_Data") %>' runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle2" runat="server" ErrorMessage="You MUST insert data or cancel."
                                                    ValidationGroup="InsertGroup" ControlToValidate="txtTitle2"></asp:RequiredFieldValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Title" runat="server" Text='<%# Eval("Translation_Data") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                
<%--                                            DeleteImageUrl="~/styles/Main/images/delete.png" EditImageUrl="~/styles/Main/images/edit.png"
                                            InsertImageUrl="~/styles/Main/images/insert.png" NewImageUrl="~/styles/Main/images/insert.png"
                                            UpdateImageUrl="~/styles/Main/images/update.png" ButtonType="Image" CancelImageUrl="~/styles/Main/images/cancel.png" />--%>
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
                                <asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                                    EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                                    TableName="prtl_Translations" Where="Translation_ID== @ID">
                                    <WhereParameters>
                                        <asp:SessionParameter SessionField="Translation_ID" DefaultValue="00000000-0000-0000-0000-000000000000"
                                            Name="ID" DbType="Guid" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxtk:TabPanel>
                <ajaxtk:TabPanel ID="StaffManagementTabPanel" runat="server" HeaderText="Staff Management">
                    <HeaderTemplate>
                        <asp:Localize ID="Localize4" runat="server" Text=" Staff Management Settings"></asp:Localize>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Button ID="MISUsersImport_Button" Text="Import MIS Emails and users" OnClick="MISUsersImport_Button_Click" runat="server" />
                        <br />
                        <asp:Label runat="server" ID="ImportResultLabel"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label13" Text="Email Subject"></asp:Label>
                        <asp:TextBox runat="server" ID="EmailSubjectTextBox"></asp:TextBox>                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You MUST insert data or cancel."
                                ValidationGroup="SendGroup" ControlToValidate="EmailSubjectTextBox"></asp:RequiredFieldValidator>
           
                        <br />
                        <asp:Label runat="server" ID="Label14" Text="Email Body"></asp:Label>
                        <ajaxtk:CustomEditor runat="server" ID="txtActualContent1" />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                                ValidationGroup="SendGroup" ControlToValidate="txtActualContent1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="InsertStandardPasswordInformButton" Text="Insert Standard Password Inform Message " OnClick="InsertStandardPasswordInformButton_OnClick" runat="server" />
                        <asp:CheckBox runat="server" ID ="SendToStaffMembersNotPasswordInformedCheckBox" Text="Send To Staff Members with Not Password Informed yet" Checked="True"/>

                        <asp:Button  ValidationGroup="SendGroup" ID="SendPortal_PasswordsEmails" Text="Send Password Emails" OnClick="SendPortal_PasswordsEmails_Click" runat="server" />

                        <br />
                        <asp:Label runat="server" ID="ErrorsLabel"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label12" Text="Staff National ID"></asp:Label>
                        <asp:TextBox runat="server" ID="NationalIDTextBox"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You MUST insert data or cancel."
                                ValidationGroup="SendGroup" ControlToValidate="NationalIDTextBox"></asp:RequiredFieldValidator>
                        <asp:Button runat="server" ValidationGroup="SendGroup"  ID="SendPasswordToStaffMemberEmailsButton" OnClick="SendPasswordToStaffMemberEmailsButton_OnClick" Text="Send Password to Staff Emails" />
                        <br />
                        <asp:Label runat="server" ID="ResetResultLabel"></asp:Label>
                    </ContentTemplate>
                </ajaxtk:TabPanel>
                <ajaxtk:TabPanel ID="BannersLogosIcons_TabPanel" runat="server" HeaderText="Banners,Logos & Icons">
                    <HeaderTemplate>
                        <asp:Localize ID="Localize7" runat="server" Text=" Banners , Logos , Intros & Icons Settings"></asp:Localize>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 25%">
                                    <asp:Label ID="introLabel1" runat="server" Text="Insert Intro:" Width="160px"></asp:Label>
                                </td>
                                <td style="width: 25%">
                                    <fz:ImageZoom ID="IntroImageZoom" runat="server" ImageAltText="Image" ImageClass="smallThumbnail"
                                        ImageTitle="" />
                                </td>
                                <td style="width: 25%">
                                    <ajaxtk:AsyncFileUpload Width="30px" ID="IntroFileUploader" OnUploadedComplete="IntroFileUploader_UploadedComplete"
                                        PersistFile="true" runat="server" />
                                </td>
                                <td style="width: 25%">
                                    <asp:Label ID="Introerrorlbl" runat="server" Width="160px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    <asp:Label ID="Label7" runat="server" Text="Insert Banner:" Width="160px"></asp:Label>
                                </td>
                                <td style="width: 25%">
                                    <fz:ImageZoom ID="BannerImageZoom" runat="server" ImageAltText="Image" ImageClass="smallThumbnail"
                                        ImageTitle="" />
                                </td>
                                <td style="width: 25%">
                                    <ajaxtk:AsyncFileUpload Width="30px" ID="BannerFileUploader" OnUploadedComplete="BannerFileUploader_UploadedComplete"
                                        PersistFile="true" runat="server" />
                                </td>
                                <td style="width: 25%">
                                    <asp:DropDownList ID="BannerLangDropDownList" runat="server" DataTextField="Text"
                                        AutoPostBack="True" DataValueField="Value" OnSelectedIndexChanged="BannerLangDropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="bannererrorlbl" runat="server" Width="160px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    <asp:Label ID="Label11" Enabled="false" runat="server" Text="Insert Icon:" Width="160px"></asp:Label>
                                </td>
                                <td style="width: 25%">
                                    <fz:ImageZoom ID="IconImageZoom" runat="server" ImageAltText="Image" ImageClass="smallThumbnail"
                                        ImageTitle="" />
                                </td>
                                <td style="width: 25%">
                                    <ajaxtk:AsyncFileUpload Width="30px" ID="IconFileUploader" OnUploadedComplete="IconFileUploader_UploadedComplete"
                                        PersistFile="true" runat="server" />
                                </td>
                                <td style="width: 25%">
                                    <asp:Label ID="iconerrorlbl" Visible="false" runat="server" Width="160px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    <asp:Label ID="Label10" runat="server" Text="Insert Logo:" Width="160px"></asp:Label>
                                </td>
                                <td style="width: 25%">
                                    <fz:ImageZoom ID="LogoImageZoom" runat="server" ImageAltText="Image" ImageClass="smallThumbnail"
                                        ImageTitle="" />
                                </td>
                                <td style="width: 25%">
                                    <ajaxtk:AsyncFileUpload Width="30px" ID="LogoFileUploader" OnUploadedComplete="LogoFileUploader_UploadedComplete"
                                        PersistFile="true" runat="server" />
                                </td>
                                <td style="width: 25%">
                                    <asp:Label ID="logoerrorlbl" runat="server" Width="160px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxtk:TabPanel>
                <ajaxtk:TabPanel ID="StaffAbbrTab" runat="server" HeaderText="OwnersManagement">
                    <HeaderTemplate>
                        <asp:Localize ID="Localize3" runat="server" Text=" Owners Management Settings"></asp:Localize>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>Change Current Abbrivation:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAbbr" runat="server"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAbbr" runat="server" ErrorMessage="Invalid Abbr Not Contains . or space" ValidationExpression='^(?!.*[\.\s]).*$'></asp:RegularExpressionValidator>
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" OnClick="ChangeAbbr" Text="Change" />
                                </td>
                            </tr>
                            <tr>
                                <td>Change Current UserName:
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName2" runat="server"></asp:TextBox><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="UserName2" runat="server" ErrorMessage="Invalid UserName Not Contains . or space" ValidationExpression='^(?!.*[\.\s]).*$'></asp:RegularExpressionValidator>
                                    <asp:Label ID="lblError2" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" OnClick="ChangeUserName" Text="Change" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxtk:TabPanel>
            </ajaxtk:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
