<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResearchesDetailsViewControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.ResearchsEditor.Details.ResearchesDetailsViewControl" %>
<uc:DetailsBasedControlTemplate ID="ResearchesTemplateDetailsViewBasedControl" runat="server" OnItemInserted="ItemInserted" DataKeys="ID" DataSourceID="TranslationsLinqDataSource">
    <Fields>
      
        <asp:TemplateField HeaderText="Research Title">
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle1" runat="server" Text='<%# Bind("ResearchTitle") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="txtTitle1"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="ResIDD" runat="server" Value='<%#Eval("ResID") %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="txtTitle" Text='<%# Bind("ResearchTitle") %>' runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Title" runat="server" Text='<%# Bind("ResearchTitle") %>' /></ItemTemplate>
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Research Date">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Research.ResDate")) %>' ValidationGroup="UpdateGroup" ID="EditResDateTextBox"
                        runat="server"></asp:TextBox>
                     <asp:HiddenField ID="ResDate" runat="server" Value='<%#Eval("Prtl_Research.ResDate") %>' />
                    <ajaxtk:CalendarExtender Format='<%# StaticUtilities.DateTimeFormat %>' ID="CalendarExtender1" runat="server" TargetControlID="EditResDateTextBox">
                    </ajaxtk:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatotr5" Display="Dynamic" ControlToValidate="EditResDateTextBox"
                        ValidationGroup="UpdateGroup" runat="server" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatort1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="EditResDateTextBox" runat="server" ErrorMessage="Date incorrect"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="InsertResDateTextBox" runat="server" ValidationGroup="InsertGroup"
                        ViewStateMode="Enabled"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="InsertResDateTextBox"
                        SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender Format='<%# StaticUtilities.DateTimeFormat %>' ViewStateMode="Enabled" EnableViewState="True" ID="InsertCalendarExtender1"
                        runat="server" TargetControlID="InsertResDateTextBox">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ControlToValidate="InsertResDateTextBox" runat="server" ErrorMessage="Date incorrect"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="News_DateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Research.ResDate")) %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Published">
            <EditItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked='<%#Eval("Prtl_Research.Published") %>' runat="server" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="IsPublished" Text='<%#Eval("Prtl_Research.Published") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Research Summery">
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle11" runat="server" Text='<%# Bind("ResearchSummery") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle11" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="txtTitle11"></asp:RequiredFieldValidator>
               
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="txtTitle2" Text='<%# Bind("ResearchSummery") %>' runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle2" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="txtTitle2"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Summery" runat="server" Text='<%# Bind("ResearchSummery") %>' /></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Researcher Name">
            <EditItemTemplate>
                
                <asp:DropDownList ID="DropDownList1" DataSource='<%# StaffSelectorDataSource(Eval("Prtl_Research.FacOwner_ID"),Page)%>' DataTextField="Name" DataValueField="OWNERID" runat="server"></asp:DropDownList>
            </EditItemTemplate>
            <InsertItemTemplate>
               
                <asp:DropDownList ID="DropDownList1" DataSource='<%# StaffSelectorDataSource2(Page)%>' DataTextField="Name" DataValueField="OWNERID" runat="server"></asp:DropDownList>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ResNAME" runat="server" Text='<%# Bind("MainResearcherName") %>' /></ItemTemplate>
        </asp:TemplateField>
        
           
    </Fields>

</uc:DetailsBasedControlTemplate>

<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="True"  EnableUpdate="true" EntityTypeName=""
    TableName="Prtl_ResearchTranslations" Where="ResID == @ID" OrderBy="LangID">
    <WhereParameters>
        <asp:SessionParameter SessionField="ResearchTranslation_ID" DefaultValue="0" Name="ID"
            DbType="Int32" />
    </WhereParameters>
</asp:LinqDataSource>
