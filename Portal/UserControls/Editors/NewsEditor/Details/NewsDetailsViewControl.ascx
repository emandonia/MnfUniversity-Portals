<%@ Control AutoEventWireup="True" CodeBehind="NewsDetailsViewControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.NewsEditor.Details.NewsDetailsViewControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>

<uc:DetailsBasedControlTemplate ID="TemplateDetailsViewBasedControl" OnPreRender="Test" runat="server" DataKeys="id" DataSourceID="NewsTranslationsLinqDataSource">
    <Fields>
       
        <asp:TemplateField HeaderText="News Date">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox Text='<%# getNewsDate(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ValidationGroup="UpdateGroup" ID="EditNewsDateTextBox"
                        runat="server"></asp:TextBox>
                    <ajaxtk:CalendarExtender Format='<%# StaticUtilities.DateTimeFormat %>' ID="CalendarExtender1" runat="server" TargetControlID="EditNewsDateTextBox">
                    </ajaxtk:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatotr5" Display="Dynamic" ControlToValidate="EditNewsDateTextBox"
                        ValidationGroup="UpdateGroup" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatort1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="EditNewsDateTextBox" runat="server" ErrorMessage="Date incorrect"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="InsertNewsDateTextBox" runat="server" ValidationGroup="InsertGroup"
                        ViewStateMode="Enabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="InsertNewsDateTextBox"
                        SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender Format='<%# StaticUtilities.DateTimeFormat %>' ViewStateMode="Enabled" EnableViewState="True" ID="InsertCalendarExtender1"
                        runat="server" TargetControlID="InsertNewsDateTextBox">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="InsertNewsDateTextBox" runat="server" ErrorMessage="Date incorrect"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_DateLabel" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="News Image">
            <EditItemTemplate>
                <ajaxtk:AsyncFileUpload ID="EditAsyncFileUpload1" Width="70px" runat="server" PersistFile="True" />
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatora1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="EditAsyncFileUpload1"></asp:RequiredFieldValidator>--%>
                <asp:HiddenField runat="server" ID="News_Id" Value='<%# Bind("News_Id") %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                <ajaxtk:AsyncFileUpload ID="InsertAsyncFileUpload1" Width="70px" runat="server" PersistFile="True" />
                <%--<asp:RequiredFieldValidator ID="ImageRequiredFieldValidators1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="InsertAsyncFileUpload1"></asp:RequiredFieldValidator>--%>
            </InsertItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Image Alternate Text">
            <EditItemTemplate>
                <asp:TextBox ID="News_AltTextBox" runat="server" Text='<%# Bind("Img_alt") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatora22" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="News_AltTextBox"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="News_AltTextBoxi" runat="server" Text='<%# Bind("Img_alt") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidators22" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="News_AltTextBoxi"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_AltLabel" runat="server" Text='<%# Bind("Img_alt") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="News Head">
            <EditItemTemplate>
                <asp:TextBox ID="News_HeadTextBox" runat="server" Text='<%# Bind("News_Head") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatora33" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="News_HeadTextBox"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="News_HeadTextBoxi" runat="server" Text='<%# Bind("News_Head") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidators33" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="News_HeadTextBoxi"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_HeadLabel" runat="server" Text='<%# Bind("News_Head") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Published">
            <EditItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked='<%#GetChecked(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData))%>' runat="server"></asp:CheckBox>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked="True" runat="server" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="IsPublished" Text='<%#GetChecked(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="IsFeatured">
            <EditItemTemplate>
                <asp:CheckBox ID="CheckBox2" Checked='<%#Get_IsFeatured_Checked(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData))%>' runat="server"></asp:CheckBox>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:CheckBox ID="CheckBox2" Checked="False" runat="server" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="IsFeatured" Text='<%#Get_IsFeatured_Checked(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Preview / Editor News Abbreviation">
            <EditItemTemplate>
                
                    <asp:TextBox runat="server" ID="News_AbbrTextBox" Text='<%# Bind("News_Abbr") %>' Width="100%" Rows="4" Columns="4" Height="200px" ValidationGroup="UpdateGroup" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidato0r2" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="News_AbbrTextBox"></asp:RequiredFieldValidator>
              
            </EditItemTemplate>
            <InsertItemTemplate>
                    <asp:TextBox runat="server" ID="News_AbbrTextBox" Text='<%# Bind("News_Abbr") %>' Width="100%" Rows="4" Columns="4" Height="200px" ValidationGroup="InsertGroup" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator02" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="News_AbbrTextBox"></asp:RequiredFieldValidator>
           
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_AbbrPreviewLabel" Text='<%# Eval("News_Abbr") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Preview / Editor News Body">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="News_BodyTextBox" Text='<%# Bind("News_Body") %>'/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator0x2" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="News_BodyTextBox"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor  runat="server" ID="News_BodyTextBox" Text='<%# Bind("News_Body") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValid0ator2" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="News_BodyTextBox"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_BodyPreviewLabel" Text='<%# Decode(Eval("News_Body")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="News Source">
            <EditItemTemplate>
                <asp:TextBox ID="News_SourceTextBox" runat="server" Text='<%# Bind("News_Source") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorgf4" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="News_SourceTextBox"></asp:RequiredFieldValidator>
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="News_SourceTextBoxi" runat="server" Text='<%# Bind("News_Source") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="News_SourceTextBoxi"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_SourceLabel" runat="server" Text='<%#Bind("News_Source") %>' />
            </ItemTemplate>
        </asp:TemplateField>
 
    </Fields>

</uc:DetailsBasedControlTemplate>
<asp:LinqDataSource ID="NewsTranslationsLinqDataSource" runat="server" OnDataBinding="NewsTranslationsLinqDataSource_OnDataBinding" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    OrderBy="Lang_Id" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
    EntityTypeName=""  Where="News_Id == @News_Id">
    <WhereParameters>
        <asp:SessionParameter SessionField="News_Id" DefaultValue="0" Name="News_Id" Type="Int32" />
    </WhereParameters>
</asp:LinqDataSource>
