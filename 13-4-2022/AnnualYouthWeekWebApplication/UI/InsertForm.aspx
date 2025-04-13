<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertForm.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.InsertForm" %>
<%@ Register TagPrefix="ajaxtk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.50731.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
     <Triggers>
        <asp:PostBackTrigger ControlID="LinkButton1" runat="server"/>
    </Triggers>
        <ContentTemplate>
     <asp:DetailsView ID="Editor_DetailsView1" DataKeyNames="ID" CssClass="Editor_DetailsView" Style="background-color: #cccccc" runat="server"
                        AllowPaging="True" AutoGenerateRows="False" CellPadding="4"
                        GridLines="None" EmptyDataText="No Data" DataSourceID="LinqDataSource1">
                        <Fields>
                        </Fields>
                        <FooterTemplate>
                            
                            &nbsp;&nbsp;
              
                        </FooterTemplate>
                        <AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
                        <CommandRowStyle CssClass="Editor_CommandRowStyle" />
                        <EditRowStyle CssClass="Editor_EditRowStyle" />
                        <FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
                        <Fields>
                            <asp:TemplateField HeaderText="رقم الاستمارة">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtname451" runat="server" Text='<%# Eval("SerialNo") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1111" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtname451"></asp:RequiredFieldValidator>
                                   
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtnamee" Text='<%# Eval("SerialNo") %>' runat="server"></asp:TextBox><asp:Label ID="Label3000" runat="server" Text="يجب ان يكون الرقم من 40 إلي 147 فقط"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitleee" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtnamee"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="namee" runat="server" Text='<%# Eval("SerialNo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم">
                                
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtname" Text='<%# Bind("Comp_Name") %>' runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtname"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الرقم القومي">
                                
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtnid" Text='<%# Eval("National_ID") %>' runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle3" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtnid"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="رقم التليفون">
                                
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtphno" Text='<%# Eval("phone_no") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النوع">
                                
                                <InsertItemTemplate>
                                    
                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                        <asp:ListItem Value="false">ذكر</asp:ListItem>
                                        <asp:ListItem Value="true">أنثي</asp:ListItem>
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الميلاد">
                               
                                <InsertItemTemplate>
                                    <div style="position: relative">
                                        <asp:TextBox ID="InsertNewsDateTextBox" runat="server" ValidationGroup="InsertGroup"
                                            ViewStateMode="Enabled"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" ControlToValidate="InsertNewsDateTextBox"
                                            SetFocusOnError="True" ValidationGroup="InsertGroup" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <ajaxtk:CalendarExtender format="dd/MM/yyyy" viewstatemode="Enabled" enableviewstate="True" id="InsertCalendarExtender1"
                                            runat="server" targetcontrolid="InsertNewsDateTextBox">
                                        </ajaxtk:CalendarExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\d{2}/\d{2}/\d{4}"
                                            ControlToValidate="InsertNewsDateTextBox" runat="server" ErrorMessage="Date incorrect"
                                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="InsertGroup"></asp:RegularExpressionValidator>
                                </InsertItemTemplate>
                               

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="محل الميلاد">
                               
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtbp" Text='<%# Eval("Birth_Place") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="العنوان">
                                
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtadd" Text='<%# Eval("Address") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الايميل">
                                
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtem" Text='<%# Eval("Email") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="الكلية">
                                
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="DropDownList121" AutoPostBack="true" runat="server" DataSourceID="LinqDataSource323" DataTextField="Faculty1" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource323" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Faculty1, ID)" TableName="Faculties" >
                                        
                                    </asp:LinqDataSource>
                                    <%--<asp:Label ID="Label3" runat="server" Text='<%# getfacname() %>'></asp:Label></InsertItemTemplate>--%>
                               </InsertItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="الفرقة">
                                
                                <InsertItemTemplate>

                                    <asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="LinqDataSource33" DataTextField="Year1" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource33" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Year1, ID)" TableName="Years" Where="Fac_id == @Fac_id1">
                                        <WhereParameters>
                                            <asp:ControlParameter ControlID="DropDownList121" PropertyName="SelectedValue" Name="Fac_id1" Type="Int32"></asp:ControlParameter>


                                        </WhereParameters>
                                    </asp:LinqDataSource>

               </InsertItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="النشاط">
                                
                                <InsertItemTemplate>

                                    <asp:Label ID="Label33" runat="server" Text='<%# getactiname() %>'></asp:Label>

                                </InsertItemTemplate>
              
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="المجال">
                                
                                <InsertItemTemplate>

                                    <asp:DropDownList ID="DropDownList1111" runat="server" DataSourceID="LinqDataSource3333" DataTextField="Field_Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3333" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Field_Name, ID)" TableName="Fields" Where="Activity_id == @Activity_id1">
                                        <WhereParameters>
                                            <asp:QueryStringParameter QueryStringField="actid" Name="Activity_id1" Type="Int32"></asp:QueryStringParameter>

                                        </WhereParameters>
                                    </asp:LinqDataSource>

               </InsertItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الصورة الشخصية">
                               
                                <InsertItemTemplate>

                                    <ajaxtk:AsyncFileUpload id="AsyncFileUpload1" width="70px" runat="server" onuploadedcomplete="AsyncFileUpload1_UploadedComplete" PersistFile="True" ThrobberID="imgLoader" />
                                    <%--<asp:RequiredFieldValidator ID="ImageRequiredFieldValidators1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="InsertAsyncFileUpload1"></asp:RequiredFieldValidator>--%> &nbsp;&nbsp; <asp:Image ID="imgLoader" runat="server" ImageUrl = "../Images/loader.gif"/> 
                                </InsertItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="صورة الرقم القومي">
                                
                                <InsertItemTemplate>
                                    <%--<asp:TextBox ID="txtni" Text='<%# Eval("NatID_Image") %>' runat="server"></asp:TextBox>--%>
                                    <ajaxtk:AsyncFileUpload id="AsyncFileUpload2" onuploadedcomplete="AsyncFileUpload2_UploadedComplete" width="70px" runat="server" PersistFile="True" ThrobberID="imgLoader2" />
                                    <%--<asp:RequiredFieldValidator ID="ImageRequiredFieldValidators1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="InsertAsyncFileUpload1"></asp:RequiredFieldValidator>--%> &nbsp;&nbsp; <asp:Image ID="imgLoader2" runat="server" ImageUrl = "../Images/loader.gif"/> 
                                </InsertItemTemplate>
                               
                            </asp:TemplateField>
                        </Fields>


                        <HeaderStyle CssClass="Editor_HeaderStyle" />
                        <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
                        <RowStyle CssClass="Editor_RowStyle" />
                    </asp:DetailsView>

                
            <br />
            <asp:LinkButton ID="LinkButton1" Text="إدخال" OnClick="InsertButtonClicked" Style="font-size: large; font-weight: bold" runat="server"></asp:LinkButton>
            <br/>
                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_OnClick"  runat="server">عودة</asp:LinkButton>
            <asp:LinqDataSource runat="server" ID="LinqDataSource1" EntityTypeName="" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext"
                Select="new (SerialNo,ID, Stu_Name, National_ID, Gender, Birth_Date, Birth_Place, NatID_Image, Personal_Image, Address, Email, phone_no, Faculty_ID, University_id)" TableName="Students" Where="University_id == @University_id ">
                <WhereParameters>
                    <asp:SessionParameter SessionField="UniID" Name="University_id" Type="Int32"></asp:SessionParameter>
                    

                </WhereParameters>
                </asp:LinqDataSource>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
