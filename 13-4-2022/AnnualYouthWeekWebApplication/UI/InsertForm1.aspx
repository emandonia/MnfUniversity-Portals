<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertForm1.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.InsertForm1" %>
<%@ Register TagPrefix="ajaxtk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.50731.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="LinkButton5" runat="server"/>
    </Triggers>
        <ContentTemplate>
   
                    <div style="width: 100%">
                    <asp:DetailsView ID="Editor_DetailsView1" DataKeyNames="ID" CssClass="Editor_DetailsView" Style="background-color:#cccccc" runat="server"
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
                                    <asp:TextBox ID="txtnamee" Text='<%# Eval("SerialNo") %>' runat="server"></asp:TextBox><asp:Label ID="Label3000" runat="server" Text="يجب ان يكون الرقم من 1 إلي 3 فقط"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitleee" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtnamee"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="namee" runat="server" Text='<%# Eval("SerialNo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtname1" runat="server" Text='<%# Bind("Admin_Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtname1"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="ID" runat="server" Value='<%#Eval("ID") %>' />
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtname" Text='<%# Bind("Admin_Name") %>' runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtname"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="name" runat="server" Text='<%# Bind("Admin_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="الرقم القومي">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtnid1" runat="server" Text='<%# Eval("National_ID") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle2" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtnid1"></asp:RequiredFieldValidator>

                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtnid" Text='<%# Eval("National_ID") %>' runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle3" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="InsertGroup" ControlToValidate="txtnid"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="nid" runat="server" Text='<%# Eval("National_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="رقم التليفون">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtphno1" runat="server" Text='<%# Eval("Phone_Number") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtphno" Text='<%# Eval("Phone_Number") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="phno" runat="server" Text='<%# Eval("Phone_Number") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="تاريخ الميلاد">
                                <EditItemTemplate>
                                    <div style="position: relative">
                                        <asp:TextBox Text='<%# Eval("Birth_Date")%>' ValidationGroup="UpdateGroup" ID="EditNewsDateTextBox"
                                            runat="server"></asp:TextBox>
                                        <ajaxtk:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="EditNewsDateTextBox">
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
                                        <ajaxtk:CalendarExtender Format="dd/MM/yyyy" ViewStateMode="Enabled" EnableViewState="True" ID="InsertCalendarExtender1"
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
                            <asp:TemplateField HeaderText="محل الميلاد">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtbp1" runat="server" Text='<%# Eval("Birth_Place") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtbp" Text='<%# Eval("Birth_Place") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="bp" runat="server" Text='<%# Eval("Birth_Place") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="العنوان">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtadd1" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtadd" Text='<%# Eval("Address") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="add" runat="server" Text='<%# Eval("Address") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الايميل">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtem1" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtem" Text='<%# Eval("Email") %>' runat="server"></asp:TextBox>

                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="em" runat="server" Text='<%# Eval("Email") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الصورة الشخصية">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtpi1" runat="server" Text='<%# Eval("Personal_Image") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    
 <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" Width="70px" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" PersistFile="True" />
                                    
                <%--<asp:RequiredFieldValidator ID="ImageRequiredFieldValidators1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="InsertAsyncFileUpload1"></asp:RequiredFieldValidator>--%>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="pi" runat="server" Text='<%# Eval("Personal_Image") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="صورة الرقم القومي">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtni1" runat="server" Text='<%# Eval("NatID_Image") %>'></asp:TextBox>


                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="txtni" Text='<%# Eval("NatID_Image") %>' runat="server"></asp:TextBox>
 <ajaxtk:AsyncFileUpload ID="AsyncFileUpload2" OnUploadedComplete="AsyncFileUpload2_UploadedComplete" Width="70px" runat="server" PersistFile="True" />
                <%--<asp:RequiredFieldValidator ID="ImageRequiredFieldValidators1" runat="server" ErrorMessage="You MUST insert data or cancel."
                    ValidationGroup="InsertGroup" ControlToValidate="InsertAsyncFileUpload1"></asp:RequiredFieldValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="ni" runat="server" Text='<%# Eval("NatID_Image") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="نوع القائد">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSource3"  DataTextField="Admin_Type" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Admin_Type, ID)" TableName="Higher_Admin_Types"></asp:LinqDataSource>



                                </EditItemTemplate>
                                <InsertItemTemplate>

                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource2" DataTextField="Admin_Type" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Admin_Type, ID)" TableName="Higher_Admin_Types"></asp:LinqDataSource>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="at" runat="server" Text='<%# Eval("Admin_type_id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Fields>


                        <HeaderStyle CssClass="Editor_HeaderStyle" />
                        <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
                        <RowStyle CssClass="Editor_RowStyle" />
                    </asp:DetailsView>

               
                </div>

                <asp:LinqDataSource runat="server" ID="LinqDataSource1" EntityTypeName="" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID,Admin_Name, National_ID, Phone_Number, Birth_Date, Birth_Place, Address, Email,Personal_Image,University_id,Admin_type_id,SerialNo)" TableName="Higher_Admins"
                    EnableDelete="True" EnableUpdate="True" Where="University_id == @University_id">
                    <WhereParameters>
                        <asp:SessionParameter SessionField="UniID" Name="University_id" Type="Int32"></asp:SessionParameter>
                    </WhereParameters>
                </asp:LinqDataSource>
        <br/><asp:LinkButton ID="LinkButton5" Text="إدخال" OnClick="InsertButtonClicked" style="font-size: large;font-weight: bold " runat="server"></asp:LinkButton><br/>
                
                
                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_OnClick"  runat="server">عودة</asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
