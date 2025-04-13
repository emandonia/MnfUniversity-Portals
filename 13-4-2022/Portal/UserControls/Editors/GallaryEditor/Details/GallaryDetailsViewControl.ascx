<%@ Control AutoEventWireup="True" CodeBehind="GallaryDetailsViewControl.ascx.cs"
     Inherits="MnfUniversity_Portals.UserControls.Editors.GallaryEditor.Details.GallaryDetailsViewControl"
    Language="C#" %>
 <uc:DetailsBasedControlTemplate ID="TemplateDetailsViewBasedControl" OnPreRender="DetailsViewBasedControl1_PreRender" runat="server" DataKeys="Translation_ID" DataSourceID="TranslationsLinqDataSource">
     <Fields>
        <asp:TemplateField HeaderText="Start Date">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="EditStartDateTextBox" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("prtl_Highlight.Start_Date")) %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EditStartDateTextBox"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="EditStartDateTextBox"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="StartEventCalendarExtender" Format='<%# StaticUtilities.DateTimeFormat %>' runat="server" TargetControlID="EditStartDateTextBox">
                    </ajaxtk:CalendarExtender>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="InsertStartDateTextBox" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="InsertStartDateTextBox"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="StartEventCalendarExtender" runat="server" TargetControlID="InsertStartDateTextBox" Format='<%# StaticUtilities.DateTimeFormat%>' >
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="InsertStartDateTextBox"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="EventStart_DateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("prtl_Highlight.Start_Date")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="End Date">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="EditEndDateTextBox" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("prtl_Highlight.End_Date")) %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="EditEndDateTextBox"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="EndEventCalendarExtender" runat="server" Format='<%# StaticUtilities.DateTimeFormat%>' TargetControlID="EditEndDateTextBox">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EditEndDateTextBox"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="InsertEndDateTextBox" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="InsertEndDateTextBox"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="EndEventCalendarExtender" runat="server" TargetControlID="InsertEndDateTextBox" Format='<%# StaticUtilities.DateTimeFormat%>' >
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="InsertEndDateTextBox"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="EventEnd_DateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("prtl_Highlight.End_Date")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="Published">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Checked='<%#Eval("prtl_Highlight.Published") %>' runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Checked="True" runat="server" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="IsPublished" Text='<%#Eval("prtl_Highlight.Published") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField HeaderText="Event Image">
            <EditItemTemplate>
                <asp:HiddenField runat="server" ID="HighlightID" Value='<%# Bind("prtl_Highlight.Highlight_Id") %>' />
                <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistedStoreType="Session"
                    PersistFile="True" Width="70px"></ajaxtk:AsyncFileUpload>

            </EditItemTemplate>
            <InsertItemTemplate>
                <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" Width="70px"></ajaxtk:AsyncFileUpload>
            </InsertItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Preview / Editor">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent" Text='<%# Bind("Translation_Data") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent"  Text='<%# Bind("Translation_Data") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblActualContent" Text='<%# Decode(Eval("Translation_Data")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

           
    </Fields>
</uc:DetailsBasedControlTemplate>
<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    OrderBy="Lang_Id" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
    TableName="prtl_Translations" EntityTypeName="" Where="Translation_ID== @Translation_ID">
    <WhereParameters>
        <asp:SessionParameter SessionField="EventTranslation_ID" DefaultValue="00000000-1000-0000-0000-000000000000"
            Name="Translation_ID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>
