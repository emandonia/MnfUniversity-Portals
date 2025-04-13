<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetailsViewUserControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.ArticleEditor.Details.ArticleDetailsViewUserControl" %>
<uc:DetailsBasedControlTemplate ID="ArticleTemplateDetailsViewBasedControl" runat="server" DataKeys="T_id" DataSourceID="TranslationsLinqDataSource">
    <Fields>
      
        <asp:TemplateField HeaderText="Title">
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="txtTitle1"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="ArticleID" runat="server" Value='<%#Eval("Article_ID") %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="txtTitle" Text='<%# Bind("Title") %>' runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Title" runat="server" Text='<%# Bind("Title") %>' /></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Published">
            <EditItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked='<%#Eval("prtl_Article.Published") %>' runat="server" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="IsPublished" Text='<%#Eval("prtl_Article.Published") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Preview / Editor">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent" Text='<%# Bind("Actual_Content") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent" Text='<%# Bind("Actual_Content") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblActualContent" Text='<%#  Decode(Eval("Actual_Content")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

           
    </Fields>

</uc:DetailsBasedControlTemplate>

<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="true" EnableUpdate="true" EntityTypeName=""
    TableName="prtl_Articles_Translations" Where="Article_ID == @ID" OrderBy="Lang_Id">
    <WhereParameters>
        <asp:SessionParameter SessionField="ArticleTranslation_ID" DefaultValue="0" Name="ID"
            DbType="Int32" />
    </WhereParameters>
</asp:LinqDataSource>
