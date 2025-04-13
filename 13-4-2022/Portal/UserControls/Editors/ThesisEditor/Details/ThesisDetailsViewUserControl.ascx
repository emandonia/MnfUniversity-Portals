<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThesisDetailsViewUserControl.ascx.cs"   Inherits="MnfUniversity_Portals.UserControls.Editors.ThesisEditor.Details.ThesisDetailsViewUserControl" %>
<uc:DetailsBasedControlTemplate ID="ThesisTemplateDetailsViewBasedControl" runat="server"
    DataKeys="ID" DataSourceID="TranslationsLinqDataSource">
    <Fields>
                
        
         
        
        <asp:TemplateField HeaderText="Student Name" meta:resourcekey="sname">
            <EditItemTemplate> <asp:HiddenField ID="Thesis_ID2" runat="server" Value='<%#Eval("Thesis_ID") %>' />
                <asp:TextBox ID="txtStudentName" runat="server" Text='<%# Bind("StudentName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentName1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="txtStudentName"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="StudentNameID" runat="server" Value='<%#Eval("Thesis_ID") %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                 <asp:HiddenField ID="Thesis_ID2" runat="server" Value='<%#Eval("Thesis_ID") %>' />
                <asp:TextBox ID="txtStudentName" Text='<%# Bind("StudentName") %>' runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentName" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="txtStudentName"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:HiddenField ID="Thesis_ID2" runat="server" Value='<%#Eval("Thesis_ID") %>' />
                <asp:Label ID="StudentName" runat="server" Text='<%# Bind("StudentName") %>' />
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="title" meta:resourcekey="title">
            <EditItemTemplate>
                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="UpdateGroup" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                <asp:HiddenField ID="AddressID" runat="server" Value='<%#Eval("Thesis_ID") %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="txtAddress"  Text='<%# Bind("Address") %>' runat="server" Columns="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Address" runat="server" Text='<%# Bind("Address") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        
        
        
        <asp:TemplateField HeaderText="specialism" meta:resourcekey="specialism">
            <EditItemTemplate>
                 <div style="position: relative">
                    
                       <asp:TextBox ID="txtSpecialisim" Rows="3" Columns="60" Text='<%# Bind("Specialisim") %>' runat="server"></asp:TextBox>

                   <%-- <ajaxtk:CustomEditor runat="server" ID="txtSpecialisim" Text='<%# Bind("Specialisim") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator001" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="txtSpecialisim"></asp:RequiredFieldValidator>
               --%> 
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                 <div style="position: relative">
                    
                    
                    
                    <asp:TextBox ID="txtSpecialisim" Columns="60"  Text='<%# Bind("Specialisim") %>' runat="server" Rows="3"></asp:TextBox>

                   <%-- <ajaxtk:CustomEditor runat="server" ID="txtSpecialisim" Text='<%# Bind("Specialisim") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator002" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="txtSpecialisim"></asp:RequiredFieldValidator>
                --%></div>
            </InsertItemTemplate>
            <ItemTemplate>
                 <div class="DirLTR">
                <asp:Label ID="LblSpecialisim" Text='<%#  Decode(Eval("Specialisim")) %>' runat="server" /></div>
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="Thesis Type" meta:resourcekey="ThesisType">
            <EditItemTemplate>
                
                
               <asp:RadioButtonList ID="RadioButtonList1" SelectedValue='<%#Eval("Prtl_Thesi.StudyTypee") %>' runat="server">

                    <asp:ListItem    Value="False" meta:resourcekey="phd"  ></asp:ListItem>
                    <asp:ListItem   Value="True" meta:resourcekey="master" ></asp:ListItem>
                </asp:RadioButtonList>
                 
            </EditItemTemplate>
            <InsertItemTemplate>
               
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">

                    <asp:ListItem  Value="False" meta:resourcekey="phd"></asp:ListItem>
                    <asp:ListItem Value="True" meta:resourcekey="master"></asp:ListItem>
                </asp:RadioButtonList>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblStudyType" Text='<%#GetStud(Eval("Prtl_Thesi.StudyTypee")) %>' runat="server" />

            </ItemTemplate>


      
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Registration Date" meta:resourcekey="Reg_date" >
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="Registration" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Thesi.RegistrationDate")) %>' runat="server"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator022" runat="server" ControlToValidate="Registration"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="UniDateCalendarExtender" runat="server" Format='<%# StaticUtilities.DateTimeFormat%>' TargetControlID="Registration">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator02" runat="server" ControlToValidate="Registration"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="Registration" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator03" runat="server" ControlToValidate="Registration"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="UniDateCalendarExtender" runat="server" TargetControlID="Registration" Format='<%# StaticUtilities.DateTimeFormat%>'>
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator04" runat="server" ControlToValidate="Registration"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="RegistrationLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Thesi.RegistrationDate")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="Disscusion Date" meta:resourcekey="diss_date">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="DisscusionDate" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Thesi.DisscusionDate")) %>' runat="server"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator202" runat="server" ControlToValidate="DisscusionDate"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="RegDateCalendarExtender" runat="server" Format='<%# StaticUtilities.DateTimeFormat%>' TargetControlID="DisscusionDate">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValida0tor2" runat="server" ControlToValidate="DisscusionDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="DisscusionDate" runat="server"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DisscusionDate"
                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="RegDateCalendarExtender" runat="server" TargetControlID="DisscusionDate" Format='<%# StaticUtilities.DateTimeFormat%>'>
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="DisscusionDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="DisscusionDateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("Prtl_Thesi.DisscusionDate")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
             <asp:TemplateField HeaderText="File" meta:resourcekey="file">
                  
            <EditItemTemplate>
                <div style="position: relative">
                  <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" PersistedStoreType="Session"
                     Width="70px"></ajaxtk:AsyncFileUpload> </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                 <div style="position: relative">
                    <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" PersistedStoreType="Session"
                     Width="70px"></ajaxtk:AsyncFileUpload> </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblFilName" Text='<%#  Eval("Prtl_Thesi.FileName") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Thesis Status" meta:resourcekey="Thesis_Status">
            <EditItemTemplate>
              
                <asp:RadioButton ID="RadioButton1" runat="server" Text="تم مناقشتها" GroupName="g1" Checked='<%#Eval("Prtl_Thesi.ResearchType") %>' />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="لم تتم المناقشة" GroupName="g1"  Checked='<%#GetCheck2(Eval("Prtl_Thesi.ResearchType")) %>' />
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:RadioButton ID="RadioButton1" runat="server" Text="تم مناقشتها" GroupName="g1" />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="لم تتم المناقشة" GroupName="g1" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="IsPublished" Text='<%#GetRes(Eval("Prtl_Thesi.ResearchType")) %>' runat="server" />

            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supervisor_commite" meta:resourcekey="super_comm">
            <EditItemTemplate>
                <div style="position: relative">


                    <asp:Label Text='<%# Eval("Thesis_ID") %>' runat="server" ID="lblThesis_ID" Visible="false" />

                    1-<asp:TextBox ID="txtSuper" runat="server" Text='<%#GetSuper( Eval("Thesis_ID")) %>'></asp:TextBox>
                    2-<asp:TextBox ID="txtSuper1" runat="server" Text='<%#GetSuper1( Eval("Thesis_ID")) %>'></asp:TextBox>
                    3-<asp:TextBox ID="txtSuper2" runat="server" Text='<%#GetSuper2( Eval("Thesis_ID")) %>'></asp:TextBox>
                    4-<asp:TextBox ID="txtSuper3" runat="server" Text='<%#GetSuper3( Eval("Thesis_ID")) %>'></asp:TextBox>
                    5-<asp:TextBox ID="txtSuper4" runat="server" Text='<%#GetSuper4( Eval("Thesis_ID")) %>'></asp:TextBox>




                   
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    1-<asp:TextBox ID="txtSuper" runat="server"></asp:TextBox>
                    2-<asp:TextBox ID="txtSuper1" runat="server"></asp:TextBox>
                    3-<asp:TextBox ID="txtSuper2" runat="server"></asp:TextBox>
                    4-<asp:TextBox ID="txtSuper3" runat="server"></asp:TextBox>
                    5-<asp:TextBox ID="txtSuper4" runat="server"></asp:TextBox>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label Text='<%# Eval("Thesis_ID") %>' runat="server" ID="lblThesis_ID" Visible="false" />

                <asp:DataList ID="DataList2" runat="server" DataKeyField="id" DataSourceID="LinqDataSource4">
                    <ItemTemplate>

                        <asp:Label Text='<%# Eval("Prtl_ThesisSuper.SuperName") %>' runat="server" ID="ThesisIdLabel" /><br />

                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource4" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                    TableName="Prtl_ThesisMapSupers" Where="ThesisId == @ThesisId">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="lblThesis_ID" PropertyName="Text" Name="ThesisId" Type="Int32"></asp:ControlParameter>

                    </WhereParameters>
                </asp:LinqDataSource>

            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="disscussion_commite" meta:resourcekey="dissc_comm">
            <EditItemTemplate>
                <hr />
                <div style="position: relative">

                    <asp:Label Text='<%# Eval("Thesis_ID") %>' runat="server" ID="lblThesis_ID2" Visible="false" />
                    1-<asp:TextBox Text='<%#GetSupervisor( Eval("Thesis_ID")) %>' ID="txtExaminers" runat="server"></asp:TextBox>
                    2-<asp:TextBox Text='<%#GetSupervisor1( Eval("Thesis_ID")) %>' ID="txtExaminers1" runat="server"></asp:TextBox>
                    3-<asp:TextBox Text='<%#GetSupervisor2( Eval("Thesis_ID")) %>' ID="txtExaminers2" runat="server"></asp:TextBox>
                    4-<asp:TextBox Text='<%#GetSupervisor3( Eval("Thesis_ID")) %>' ID="txtExaminers3" runat="server"></asp:TextBox>
                    5-<asp:TextBox Text='<%#GetSupervisor4( Eval("Thesis_ID")) %>' ID="txtExaminers4" runat="server"></asp:TextBox>



                   
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <hr />
                    1-<asp:TextBox ID="txtExaminers" runat="server"></asp:TextBox>
                    2-<asp:TextBox ID="txtExaminers1" runat="server"></asp:TextBox>
                    3-<asp:TextBox ID="txtExaminers2" runat="server"></asp:TextBox>
                    4-<asp:TextBox ID="txtExaminers3" runat="server"></asp:TextBox>
                    5-<asp:TextBox ID="txtExaminers4" runat="server"></asp:TextBox>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>

                <asp:Label Text='<%# Eval("Thesis_ID") %>' runat="server" ID="lblThesis_ID2" Visible="false" />

                <asp:DataList ID="DataList22" runat="server" DataKeyField="id" DataSourceID="LinqDataSource04">
                    <ItemTemplate>

                        <asp:Label Text='<%# Eval("Prtl_ThesisSUPERVISOR.SuperName") %>' runat="server" ID="ThesisIdLabel2" /><br />

                    </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource04" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                    TableName="Prtl_ThesisMapSupervisors" Where="ThesisId == @ThesisId">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="lblThesis_ID2" PropertyName="Text" Name="ThesisId" Type="Int32"></asp:ControlParameter>

                    </WhereParameters>
                </asp:LinqDataSource>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Researchplan" meta:resourcekey="res_plan">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent2" Text='<%# Bind("ResearchPlan") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator01" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ControlToValidate="txtActualContent2"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent2" Text='<%# Bind("ResearchPlan") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator04" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ControlToValidate="txtActualContent2"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblActualContent2" Text='<%# Bind("ResearchPlan") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="summery" meta:resourcekey="summery">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtSummary" Text='<%# Bind("Summary") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="UpdateGroup" ControlToValidate="txtSummary"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtSummary" Text='<%# Bind("Summary") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You MUST insert data or cancel."
                        ValidationGroup="InsertGroup" ControlToValidate="txtSummary"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblSummary" Text='<%#  Decode(Eval("Summary")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>


    
        

    </Fields>

</uc:DetailsBasedControlTemplate>

<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EnableDelete="True" EnableInsert="true" EnableUpdate="true" EntityTypeName=""
    TableName="prtl_Thesis_Translations" Where="Thesis_ID == @ID" OrderBy="Lang_Id">
    <WhereParameters>
        <asp:SessionParameter SessionField="ThesisTranslation_ID" DefaultValue="0" Name="ID"
            DbType="Int32" />
    </WhereParameters>
</asp:LinqDataSource>
