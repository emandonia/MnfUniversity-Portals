<%@ Control AutoEventWireup="True" CodeBehind="VotingDetailsControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.VotingEditor.Details.VotingDetailsControl"
    Language="C#" %>
<%-- ReSharper disable UnusedMember.Global --%>
<uc:DetailsBasedControlTemplate ID="TemplateDetailsViewBasedControl" runat="server" DataKeys="T_ID" DataSourceID="TranslationsLinqDataSource">
                <Fields>
                <asp:TemplateField HeaderText="Language">
                    <EditItemTemplate>
                        <asp:Label ID="Language" Text='<%# StaticUtilities.LanguageName(Eval("prtl_Language.LCID")) %>' runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="LangDropDownList" runat="server">
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%# StaticUtilities.LanguageName(Eval("prtl_Language.LCID")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Question">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQues" runat="server" Text='<%# Bind("Question") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorQues" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="UpdateGroup" ControlToValidate="txtQues"></asp:RequiredFieldValidator>
                        <asp:Label ID="DefaultLbl" runat="server" Text="set as default"></asp:Label>
                        <asp:CheckBox ID="DefaultCheck" runat="server" />
                        <asp:HiddenField runat="server" ID="VotingID" Value='<%# Bind("VotingID") %>' />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" Text='<%# Bind("Question") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="InsertGroup" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        <asp:Label ID="Label2" runat="server" Text="set as default"></asp:Label>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Question" runat="server" Text='<%# Bind("Question") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Answer1">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtans1" runat="server" Text='<%# Bind("Ans1") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorans1" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="UpdateGroup" ControlToValidate="txtans1"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" Text='<%# Bind("Ans1") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="InsertGroup" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Answer1" runat="server" Text='<%# Bind("Ans1") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Answer2">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtans2" runat="server" Text='<%# Bind("Ans2") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorans2" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="UpdateGroup" ControlToValidate="txtans2"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" Text='<%# Bind("Ans2") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="InsertGroup" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Answer2" runat="server" Text='<%# Bind("Ans2") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Answer3">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtans3" runat="server" Text='<%# Bind("Ans3") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorans3" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="UpdateGroup" ControlToValidate="txtans3"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" Text='<%# Bind("Ans3") %>' runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You MUST insert data or cancel."
                            ValidationGroup="InsertGroup" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Answer3" runat="server" Text='<%# Bind("Ans3") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"
                    ButtonType="Link" />
            </Fields>

</uc:DetailsBasedControlTemplate>
<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="true" EnableUpdate="true" EntityTypeName=""
    OrderBy="Lang_Id" TableName="prtl_VotingTranslations" Where="VotingID== @ID">
    <WhereParameters>
        <asp:SessionParameter SessionField="VotingTranslation_ID" DefaultValue="0" Name="ID"
            DbType="Int32" />
    </WhereParameters>
</asp:LinqDataSource>
