<%@ Control AutoEventWireup="True" CodeBehind="MenuDetailsViewUserControl.ascx.cs"
    Inherits="MnfUniversity_Portals.UserControls.Editors.MenuEditor.MenuDetailsViewUserControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>


<uc:DetailsBasedControlTemplate OnDGVLoad="MenuEditorDetailsView_Load" ID="TemplateDetailsViewBasedControl" runat="server" DataKeys="Translation_ID" DataSourceID="Menu_Translations_LinqDataSource">
    <Fields>
        <asp:BoundField DataField="Translation_ID" HeaderText="id" InsertVisible="False"
            ReadOnly="True" SortExpression="id" Visible="False" />
        <asp:BoundField DataField="Translation_Data" HeaderText="Name" SortExpression="Translation_Data" />
       
        <asp:TemplateField HeaderText="Parent">
            <EditItemTemplate>
                <asp:DropDownList DataSource='<%# GetParents((Guid)Eval("Translation_ID"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'  
                    SelectedValue='<%# GetParentidValues((Guid)Eval("Translation_ID"),URLBuilder.CurrentOwnerAbbr(Page.RouteData))%>' ID="ParentEditDropDownList"
                    runat="server" AppendDataBoundItems="True" DataTextField="Translation_Data" DataValueField="Menu_id"
                    Width="120px">
                    <asp:ListItem Selected="True" Value="">(Root)</asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:DropDownList ID="ParentInsertDropDownList" runat="server" AppendDataBoundItems="True"  
                    DataSource='<%# GetParents2(-1,URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' DataTextField="Translation_Data" DataValueField="Menu_id"
                    Width="100px">
                    <asp:ListItem Selected="True" Value="">(Root)</asp:ListItem>
                </asp:DropDownList>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Parent_id" Text='<%#TranslationData((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData)) %>'
                    runat="server" Width="100px" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Order">
            <EditItemTemplate>
                <asp:TextBox Style="text-align: center;" Width="50px" Text='<%# GetOrder((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                    ID="EditOrderTextBox" runat="server" ValidationGroup="UpdateGroup" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="EditOrderTextBox"
                    runat="server" Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                <ajaxtk:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    FilterType="Numbers" TargetControlID="EditOrderTextBox">
                </ajaxtk:FilteredTextBoxExtender>
                <ajaxtk:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                    TargetControlID="EditOrderTextBox" WatermarkText="Order">
                </ajaxtk:TextBoxWatermarkExtender>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox Text='<%# GetOrder(Guid.Empty,StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Style="text-align: center;" Width="50px"
                    ID="InsertOrderTextBox" runat="server" ValidationGroup="InsertGroup" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="InsertOrderTextBox"
                    runat="server" Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>
                <ajaxtk:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                    FilterType="Numbers" TargetControlID="InsertOrderTextBox">
                </ajaxtk:FilteredTextBoxExtender>
                <ajaxtk:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                    TargetControlID="InsertOrderTextBox" WatermarkText="Order">
                </ajaxtk:TextBoxWatermarkExtender>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="OrderLabel" Text='<%# GetOrder((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Style="text-align: center;"
                    runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="URL">
            <EditItemTemplate>
                <ajaxtk:ComboBox Text='<%# GetURL((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Width="200px" OnSelectedIndexChanged="UrlSelectorSelectedIndexChanged"  
                    ID="URLSelector" DataSource='<%# UrlSelectorDataSource()%>' OnItemInserting="URLSelector_TextChanged"
                    runat="server" AutoCompleteMode="Suggest" AutoPostBack="true" ItemInsertLocation="OrdinalValue">
                </ajaxtk:ComboBox>
                <br />
                <asp:DropDownList SelectedValue='<%# ArticleData((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ID="ArticleTitlesDropDownList"
                    DataSource='<%#GetArticlesTitles((Guid)Eval("Translation_ID"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' DataTextField="Title" DataValueField="Article_ID"
                    runat="server">
                </asp:DropDownList>
            </EditItemTemplate>
            <InsertItemTemplate>
                <ajaxtk:ComboBox Width="200px" ID="URLSelector" DataSource='<%# UrlSelectorDataSource()%>'  OnItemInserting="URLSelector_TextChanged"
                    OnSelectedIndexChanged="UrlSelectorSelectedIndexChanged" runat="server" AutoCompleteMode="Suggest"
                    AutoPostBack="true" ItemInsertLocation="OrdinalValue">
                </ajaxtk:ComboBox>
                <br />
                <asp:DropDownList ID="ArticleTitlesDropDownList" DataSource='<%#GetArticlesTitles2(-1,URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                    DataTextField="Title" DataValueField="Article_ID" runat="server">
                </asp:DropDownList>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# MenuItemHyperLink(Eval("Id")) %>'
                    Text='<%# MenuItemHyperLink(Eval("Id")) %>' ID="URLHyperLink"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
     <%--   <asp:TemplateField HeaderText="Url Target">
            <EditItemTemplate>
                <asp:DropDownList SelectedValue='<%#GetUrlTarget((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ID="Url_targetDropDownList"
                    runat="server">
                    <asp:ListItem Text="(none)" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="_parent"></asp:ListItem>
                    <asp:ListItem Text="_self"></asp:ListItem>
                    <asp:ListItem Text="_blank"></asp:ListItem>
                    <asp:ListItem Text="_top"></asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:DropDownList ID="Url_targetDropDownList" runat="server">
                    <asp:ListItem Text="(none)" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="_parent"></asp:ListItem>
                    <asp:ListItem Text="_self"></asp:ListItem>
                    <asp:ListItem Text="_blank"></asp:ListItem>
                    <asp:ListItem Text="_top"></asp:ListItem>
                </asp:DropDownList>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label runat="server" Text='<%#GetUrlTarget((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ToolTip='<%# Eval("prtl_Menu.Roles") %>'
                    DataSource='Roles.GetAllRoles()' ID="URLTargetLabel"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Roles">
            <EditItemTemplate>
                <asp:CheckBoxList ID="LDSRoles" OnDataBound="RolesCheckBoxList_DataBound" runat="server">
                </asp:CheckBoxList>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:CheckBoxList ID="LDSRoles" runat="server" DataSourceID="LDS_Roles" DataTextField="RoleName"
                    DataValueField="RoleName">
                </asp:CheckBoxList>
                <asp:LinqDataSource ID="LDS_Roles" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                    EntityTypeName="" TableName="aspnet_Roles">
                </asp:LinqDataSource>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="RolesLabel" Text='<%# GetRoles((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="Position">
                    <EditItemTemplate>

<asp:Label runat="server" ID="lblposition" Visible="false" Text='<%# GetPosition((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ></asp:Label>
                        <asp:DropDownList ID="PositionDropDownList1" runat="server" DataTextField ='<%# GetPosition((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'   >
    <asp:ListItem Text ="top"></asp:ListItem>
    <asp:ListItem Text="Vertical"></asp:ListItem>
    <asp:ListItem Text="Horizontal"></asp:ListItem>
    <asp:ListItem Value ="implink2" >قائمة 3</asp:ListItem>
    <asp:ListItem Value ="implink3">قائمة2</asp:ListItem>
    
    <asp:ListItem Value ="implink9">قائمة 1</asp:ListItem>
</asp:DropDownList>
                         
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:Label runat="server" ID="lblposition" Visible="false" Text='<%# GetPosition(Guid.Empty,StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ></asp:Label>
                       
                                <asp:DropDownList ID="PositionDropDownList1" runat="server" DataTextField ='<%# GetPosition(Guid.Empty,StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' >
    <asp:ListItem Text ="top"></asp:ListItem>
    <asp:ListItem Text="Vertical"></asp:ListItem>
    <asp:ListItem Text="Horizontal"></asp:ListItem>
    <asp:ListItem Value ="implink2" >قائمة 3</asp:ListItem>
    <asp:ListItem Value ="implink3">قائمة2</asp:ListItem>
    
    <asp:ListItem Value ="implink9">قائمة 1</asp:ListItem>
</asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="IsPublished" Text='<%#GetPosition((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

          <asp:TemplateField HeaderText="Published">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Checked='<%#GetPublished((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
                        <asp:HiddenField runat="server" ID="MenuID" Value='<%# GetMenuId((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Checked="True" runat="server" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="IsPublished" Text='<%#GetPublished((Guid)Eval("Translation_ID"),StaticUtilities.Currentlanguage(Page.RouteData),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

           
    </Fields>

</uc:DetailsBasedControlTemplate>
<asp:LinqDataSource ID="Menu_Translations_LinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
    OrderBy="Lang_id"  Where="Translation_ID== @Translation_ID">
    <WhereParameters>
        <asp:SessionParameter SessionField="MenuTranslation_ID" DefaultValue="00000000-0000-1000-0000-000000000000"
            Name="Translation_ID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>
