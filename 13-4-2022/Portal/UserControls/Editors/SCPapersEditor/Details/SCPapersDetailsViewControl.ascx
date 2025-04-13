 <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SCPapersDetailsViewControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.SCPapersEditor.Details.SCPapersDetailsViewControl" %>
<%@ Import Namespace="BLL" %>
 <uc:DetailsBasedControlTemplate ID="TemplateDetailsViewBasedControl" OnPreRender="DetailsViewBasedControl1_PreRender" runat="server" 
     DataKeys="PaperId" DataSourceID="TranslationsLinqDataSource"  >
 

       <Fields>
         
          <asp:TemplateField HeaderText="اسم الطالب باللغة العربية">
            <EditItemTemplate>
                <div style="position: relative">                    
                    <asp:TextBox ID="txtStudentAr" Text='<%# Bind("StudentName") %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>        
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="InsertStudentAr" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidadtor2" runat="server" ControlToValidate="InsertStudentAr"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>    
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblStudentNameAr" Text='<%# Bind("StudentName") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>      
          <asp:TemplateField HeaderText="اسم الطالب باللغة الانجليزية">
            <EditItemTemplate>
                <div style="position: relative">                    
                    <asp:TextBox ID="txtStudentEn" Text='<%# Bind("StudentNameEng") %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>        
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="txtStudentEn" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStudentEn"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>    
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" Text='<%# Bind("StudentNameEng") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="عنوان الرسالة باللغة العربية">
            <EditItemTemplate>
                <div style="position: relative">                    
                    <asp:TextBox ID="ArabicAddress" Text='<%# Bind("ArabicAddress") %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>        
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="ArabicAddress" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatornnn2" runat="server" ControlToValidate="ArabicAddress"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>    
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblArabicAddress" Text='<%# Bind("ArabicAddress") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="عنوان الرسالة باللغة الانجليزية">
            <EditItemTemplate>
                <div style="position: relative">                    
                    <asp:TextBox ID="EngAddress" Text='<%# Bind("EngAddress") %>' runat="server" ValidationGroup="UpdateGroup"
                        Width="80px"></asp:TextBox>        
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="EngAddress" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatord2" runat="server" ControlToValidate="EngAddress"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>    
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblEngAddress" Text='<%# Bind("EngAddress") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="نوع الرسالة">
            <EditItemTemplate>
              <div style="position: relative">    
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSource3"  AppendDataBoundItems="True"  DataTextField="StudyType1" DataValueField="StudyId">   
                         <asp:ListItem Value="-1" meta:resourcekey="SearchType">نوع الرسالة</asp:ListItem>                       
            </asp:DropDownList>
            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Studytypes"></asp:LinqDataSource>
           </div>
            </EditItemTemplate>
            <InsertItemTemplate>
        <div style="position: relative">
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSource3" 
                 AppendDataBoundItems="True"  DataTextField="StudyType1" DataValueField="StudyId">    
                         <asp:ListItem Value="-1" meta:resourcekey="SearchType">نوع الرسالة</asp:ListItem>
                         </asp:DropDownList>
                        <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3" 
                            ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Studytypes"></asp:LinqDataSource>
             </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" Text='<%# Bind("StudyTypee") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="تاريخ التسجيل">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="UniDate" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("RegistrationDate")) %>' runat="server" 
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="UniDate"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="UniDateCalendarExtender" runat="server" Format='<%# StaticUtilities.DateTimeFormat%>' TargetControlID="UniDate">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="UniDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="UpdateGroup"></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="UniDate" runat="server" ValidationGroup="InsertGroup"
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator03" runat="server" ControlToValidate="UniDate"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="InsertGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="UniDateCalendarExtender" runat="server" TargetControlID="UniDate" Format='<%# StaticUtilities.DateTimeFormat%>' >
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator04" runat="server" ControlToValidate="UniDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="UniverstyDate_DateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("RegistrationDate")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="تاريخ المناقشة">
            <EditItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="RegDate" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("DisscusionDate")) %>' runat="server" 
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="RegDate"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="UpdateGroup"></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="RegDateCalendarExtender" runat="server" Format='<%# StaticUtilities.DateTimeFormat%>' TargetControlID="RegDate">
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="RegDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                        ></asp:RegularExpressionValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div style="position: relative">
                    <asp:TextBox ID="RegDate" runat="server" 
                        Width="80px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RegDate"
                        Display="Dynamic" ErrorMessage="*" ></asp:RequiredFieldValidator>
                    <ajaxtk:CalendarExtender ID="RegDateCalendarExtender" runat="server" TargetControlID="RegDate" Format='<%# StaticUtilities.DateTimeFormat%>' >
                    </ajaxtk:CalendarExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="RegDate"
                        Display="Dynamic" ErrorMessage="Date incorrect" SetFocusOnError="True" ValidationExpression="\d{2}/\d{2}/\d{4}"
                         ></asp:RegularExpressionValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="UniverstyDate_DateLabel" Text='<%# StaticUtilities.FormatDate((DateTime) Eval("DisscusionDate")) %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="الكلية" >
            <EditItemTemplate>
              <div style="position: relative">    
              <asp:DropDownList AppendDataBoundItems="True"  DataSource='<%#Prtl_OwnersUtility.getFac(StaticUtilities .Currentlanguage(Page) ) %>' 
                            DataTextField="Translation_Data" DataValueField="Translation_ID" 
                   ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>


                        <asp:DropDownList ID="DropDownList5" runat="server" AppendDataBoundItems="True"                      
                      DataTextField = "Translation_Data" DataValueField = "Translation_ID"     >
                    </asp:DropDownList> 
             </div>
            </EditItemTemplate>
            <InsertItemTemplate>
        <div style="position: relative">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"  >

                <ContentTemplate ><asp:DropDownList AppendDataBoundItems="True" AutoPostBack="True"
                     DataSource='<%#Prtl_OwnersUtility.getFac(StaticUtilities .Currentlanguage(Page)) %>' 
                            DataTextField="Translation_Data" DataValueField="Translation_ID" ID="FacDropDownList" 
                    OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>

                    <asp:DropDownList ID="DropDownList5" runat="server" AppendDataBoundItems="True"                      
                      DataTextField = "Translation_Data" DataValueField = "Translation_ID"     >
                        <asp:ListItem Value="-1" Text="choose"> اختر القسم</asp:ListItem>
                    </asp:DropDownList> 
                       </ContentTemplate>

            </asp:UpdatePanel>
               
                  </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" Text='<%# Bind("Faculty") %>'  runat="server" />
                  <asp:Label ID="Label2" Text='<%# Bind("Department") %>'  runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
           
             <asp:TemplateField HeaderText="حالة الرسالة">
                    <EditItemTemplate>
                      اختر فى حالة اتمام مناقشة الرسالة  <asp:CheckBox ID="CheckBox1" Checked='<%#Eval("ResearchType") %>' runat="server"  Text="تسجيل" />
                      <%--  <asp:CheckBox ID="CheckBox2" Checked='<%#Eval("ResearchType") %>' runat="server"  Text="مناقشة"/>--%>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                      اختر فى حالة اتمام مناقشة الرسالة   <asp:CheckBox ID="CheckBox1"  runat="server"   Checked ="false"  />
                       <%-- <asp:CheckBox ID="CheckBox2"  runat="server"  Text="مناقشة"/>--%>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="IsPublished" Text='<%#Eval("ResearchType") %>' runat="server" />
                       <%-- <asp:Label ID="IsPublished2" Text='<%#Eval("ResearchType") %>' runat="server" />--%>

                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField HeaderText="لجنة الاشراف">
            <EditItemTemplate>
              <div style="position: relative">    
            1-<asp:TextBox ID="txtSuper" runat="server"></asp:TextBox>
            2-<asp:TextBox ID="txtSuper1" runat="server"></asp:TextBox>
            3-<asp:TextBox ID="txtSuper2" runat="server"></asp:TextBox>
            4-<asp:TextBox ID="txtSuper3" runat="server"></asp:TextBox>
            5-<asp:TextBox ID="txtSuper4" runat="server"></asp:TextBox>
         
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
                  <asp:Label Text='<%# Eval("PaperId") %>' runat="server" ID="PaperIdLabel2" Visible="false"/>
                <asp:DataList ID="DataList2" runat="server" DataSourceID="LinqDataSource2" DataKeyField="id">
                    <ItemTemplate>
                       
                        <asp:Label Text='<%# Eval("SUPERVISORS.SuperName") %>' runat="server" ID="SuperIdLabel" /><br />
                          </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Supers_papers" Where="PaperId == @PaperId">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="PaperIdLabel2" PropertyName="Text" Name="PaperId" Type="Int32"></asp:ControlParameter>
                    </WhereParameters>
                </asp:LinqDataSource>
               <%-- <asp:Label ID="Label1" Text='<%# Eval("SuperVisors") %>'  runat="server" />--%>
            </ItemTemplate>
        </asp:TemplateField>   
          <asp:TemplateField HeaderText="لجنة الحكم والمناقشة">
            <EditItemTemplate>
              <div style="position: relative">    
           1-   <asp:TextBox ID="txtExaminers" runat="server"></asp:TextBox>
           2-<asp:TextBox ID="txtExaminers1" runat="server"></asp:TextBox>
           3-<asp:TextBox ID="txtExaminers2" runat="server"></asp:TextBox>
           4-<asp:TextBox ID="txtExaminers3" runat="server"></asp:TextBox>
           5-<asp:TextBox ID="txtExaminers4" runat="server"></asp:TextBox>

             </div>
            </EditItemTemplate>
            <InsertItemTemplate>
        <div style="position: relative">
       
            1-<asp:TextBox ID="txtExaminers" runat="server"></asp:TextBox>
           2-<asp:TextBox ID="txtExaminers1" runat="server"></asp:TextBox>
           3-<asp:TextBox ID="txtExaminers2" runat="server"></asp:TextBox>
           4-<asp:TextBox ID="txtExaminers3" runat="server"></asp:TextBox>
           5-<asp:TextBox ID="txtExaminers4" runat="server"></asp:TextBox>
                  </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label Text='<%# Eval("PaperId") %>' runat="server" ID="PaperIdLabel" Visible="false"/>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="LinqDataSource1" DataKeyField="id">
                    <ItemTemplate>
                       
                        <asp:Label Text='<%# Eval("ResearchPlan_Paper_Supers.SuperName") %>' runat="server" ID="SuperIdLabel" /><br />
                          </ItemTemplate>
                </asp:DataList>
                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="ResearchPlan_Paper_Supers" Where="PaperId == @PaperId">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="PaperIdLabel" PropertyName="Text" Name="PaperId" Type="Int32"></asp:ControlParameter>
                    </WhereParameters>
                </asp:LinqDataSource>
            </ItemTemplate>
        </asp:TemplateField>
        

        
          <asp:TemplateField HeaderText="خطة البحث">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent2" Text='<%# Bind("ResearchPlan") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You MUST insert data or cancel."
                         ControlToValidate="txtActualContent2"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent2"  Text='<%# Bind("ResearchPlan") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator04" runat="server" ErrorMessage="You MUST insert data or cancel."
                         ControlToValidate="txtActualContent2"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblActualContent2" Text='<%# Bind("ResearchPlan") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>  
          <asp:TemplateField HeaderText="ملخص الرسالة">
            <EditItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent" Text='<%# Bind("Summary") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator01" runat="server" ErrorMessage="You MUST insert data or cancel."
                         ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <div class="DirLTR">
                    <ajaxtk:CustomEditor runat="server" ID="txtActualContent"  Text='<%# Bind("Summary") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator004" runat="server" ErrorMessage="You MUST insert data or cancel."
                         ControlToValidate="txtActualContent"></asp:RequiredFieldValidator>
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblActualContent" Text='<%# Bind("Summary") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField> 
                
    </Fields> 
    
</uc:DetailsBasedControlTemplate>
<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
     EnableDelete="True"  EnableUpdate="True" OrderBy="PaperId"
    TableName="ResearchPlan_MainDatas" EntityTypeName="" Where="FacultyTable.Prtl_FacOwnerID== @FacID">
    <WhereParameters>
        <asp:SessionParameter SessionField="factr" DefaultValue="00000000-1000-0000-0000-000000000000"
            Name="FacID" DbType="Guid" />
    </WhereParameters>
</asp:LinqDataSource>



<%--<asp:LinqDataSource ID="TranslationsLinqDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
     EnableDelete="True" EnableInsert="True" EnableUpdate="True" OrderBy="PaperId"
    TableName="ResearchPlan_MainDatas" EntityTypeName=""  Where="ResearchType== @ResearchType">
      <WhereParameters>
     <asp:SessionParameter SessionField="SelectDrop" DefaultValue="True"  name="ResearchType"  DbType="Int32"   />
            </WhereParameters>
     
</asp:LinqDataSource>--%>