﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditForm5.aspx.cs" Inherits="AnnualYouthWeekWebApplication.UI.EditForm5" %>
<%@ Register TagPrefix="ajaxtk" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.50731.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Import Namespace="AnnualYouthWeekWebApplication.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server"><div style="width: 100%">
      <asp:DetailsView ID="DetailsView1" runat="server"  style="width: 50%" AutoGenerateRows="False" DataSourceID="LinqDataSource1">
         <Fields>
             <asp:TemplateField HeaderText="رقم الاستمارة">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtname3331" runat="server" Text='<%# Eval("SerialNo") %>'></asp:TextBox><asp:Label ID="Label3000" runat="server" Text="يجب ان يكون الرقم من 40 إلي 147 فقط"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle341" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtname3331"></asp:RequiredFieldValidator>
                                    
                                </EditItemTemplate>
                                <ItemTemplate>
                <asp:Label ID="Label231" Text='<%# Eval("SerialNo") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الاسم">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtname1" runat="server" Text='<%# Bind("Stu_Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle1" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtname1"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="ID" runat="server" Value='<%#Eval("ID") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                <asp:Label ID="Label1" Text='<%# Bind("Stu_Name") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="الرقم القومي">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtnid1" runat="server" Text='<%# Eval("National_ID") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortitle2" runat="server" ErrorMessage="You MUST insert data or cancel."
                                        ValidationGroup="UpdateGroup" ControlToValidate="txtnid1"></asp:RequiredFieldValidator>

                                </EditItemTemplate>
                                <ItemTemplate>
                <asp:Label ID="Label2" Text='<%# Bind("National_ID") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
             <asp:TemplateField HeaderText="النوع">
                                <EditItemTemplate>
                                     <asp:DropDownList SelectedValue='<%#getgender(Convert.ToInt32(Eval("ID"))) %>' AppendDataBoundItems="True" ID="DropDownList3" runat="server">
                                        <asp:ListItem Value="false">ذكر</asp:ListItem>
                                        <asp:ListItem Value="true">أنثي</asp:ListItem>
                                    </asp:DropDownList>

                                </EditItemTemplate>
                                <ItemTemplate>
                <asp:Label ID="Label4562" Text='<%# getgender(Eval("Gender")) %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="رقم التليفون">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtphno1" runat="server" Text='<%# Eval("phone_no") %>'></asp:TextBox>


                                </EditItemTemplate>
                               <ItemTemplate>
                <asp:Label ID="Label6" Text='<%# Bind("phone_no") %>' runat="server" />
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
                               
                                <ItemTemplate>
                <asp:Label ID="Label323" Text='<%# Bind("Birth_Date") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="محل الميلاد">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtbp1" runat="server" Text='<%# Eval("Birth_Place") %>'></asp:TextBox>


                                </EditItemTemplate> <ItemTemplate>
                <asp:Label ID="Label2333" Text='<%# Bind("Birth_Place") %>' runat="server" />
            </ItemTemplate>
                               </asp:TemplateField>
                            <asp:TemplateField HeaderText="العنوان">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtadd1" runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>


                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label356" Text='<%# Bind("Address") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="الايميل">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtem1" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>


                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label333" Text='<%# Bind("Email") %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="الكلية">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" AutoPostBack="True" SelectedValue='<%#StudentsUtilty.getcurrentFacid(Convert.ToInt32(Eval("ID"))) %>'  AppendDataBoundItems="True" runat="server" DataSourceID="LinqDataSource3" DataTextField="Faculty1" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Faculty1, ID)" TableName="Faculties"></asp:LinqDataSource>



                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label32423" Text='<%# StudentsUtilty.getcurrentFac(Convert.ToInt32(Eval("ID"))) %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
             <asp:TemplateField HeaderText="الفرقة">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList11"    runat="server" DataSourceID="LinqDataSource33" DataTextField="Year1" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource33" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Year1, ID)" TableName="Years" Where="Fac_id == @Fac_id1">
                                        <WhereParameters>
                                            <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="Fac_id1" Type="Int32"></asp:ControlParameter>

                                        </WhereParameters>
                                    </asp:LinqDataSource>



                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label3245523" Text='<%# StudentsUtilty.getcurrentyear(Convert.ToInt32(Eval("ID"))) %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
             <asp:TemplateField HeaderText="النشاط">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList111" AutoPostBack="True" SelectedValue='<%#StudentsUtilty.getcurrentactid(Convert.ToInt32(Eval("ID"))) %>'  AppendDataBoundItems="True" runat="server" DataSourceID="LinqDataSource333" DataTextField="Activity_Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource333" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (ID, Activity_Name)" TableName="Activities"></asp:LinqDataSource>



                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label3442423" Text='<%# StudentsUtilty.getcurrentact(Convert.ToInt32(Eval("ID"))) %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
             <asp:TemplateField HeaderText="المجال">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1111"   runat="server" DataSourceID="LinqDataSource3333" DataTextField="Field_Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3333" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext" Select="new (Field_Name, ID)" TableName="Fields" Where="Activity_id == @Activity_id">
                                        <WhereParameters>
                                            <asp:ControlParameter ControlID="DropDownList111" PropertyName="SelectedValue" Name="Activity_id" Type="Int32"></asp:ControlParameter>
                                        </WhereParameters>
                                    </asp:LinqDataSource>



                                </EditItemTemplate>
                                 <ItemTemplate>
                <asp:Label ID="Label2232423" Text='<%# StudentsUtilty.getcurrentField(Convert.ToInt32(Eval("ID"))) %>' runat="server" />
            </ItemTemplate>
                            </asp:TemplateField>
             <asp:TemplateField HeaderText="الصورة الشخصية">
                                <EditItemTemplate>
                                  <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" Width="70px" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" ThrobberID="imgLoader" />
                                     &nbsp;&nbsp; <asp:Image ID="imgLoader" runat="server" ImageUrl = "../Images/loader.gif"/> 

                                </EditItemTemplate>
                                 <ItemTemplate>
                                     <a id="example1" href='<%# HigherAdminsUtility.GetpImagePath(Eval("Personal_Image")) %>'><img width="150px" height="150px" alt="example1" src='<%# HigherAdminsUtility.GetpImagePath(Eval("Personal_Image")) %>' /></a>
                                         
                                         
            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="صورة الرقم القومي">
                                <EditItemTemplate>
                                    <ajaxtk:AsyncFileUpload ID="AsyncFileUpload2" OnUploadedComplete="AsyncFileUpload2_UploadedComplete" Width="70px" runat="server" ThrobberID="imgLoader2" />

                                     &nbsp;&nbsp; <asp:Image ID="imgLoader2" runat="server" ImageUrl = "../Images/loader.gif"/> 
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <a id="example1" href='<%# HigherAdminsUtility.GetnImagePath(Eval("NatID_Image")) %>'><img width="150px" height="150px" alt="example1" src='<%# HigherAdminsUtility.GetnImagePath(Eval("NatID_Image")) %>' /></a>
                                       
                                         
                                         
            </ItemTemplate>
                            </asp:TemplateField>

                        </Fields>
    </asp:DetailsView>

    <br/>
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_OnClick" Visible="False" runat="server">تحديث</asp:LinkButton>

    <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_OnClick" Visible="False" runat="server">عودة</asp:LinkButton>
    </div>

    <asp:LinqDataSource runat="server" ID="LinqDataSource1" EntityTypeName="" ContextTypeName="AnnualYouthWeekWebApplication.MyDataContext"
                    Select="new (SerialNo,ID, Stu_Name, National_ID, Gender, Birth_Date, Birth_Place, NatID_Image, Personal_Image, Address, Email, phone_no)" TableName="Students" Where="ID == @ID">
                   <WhereParameters>
            <asp:QueryStringParameter QueryStringField="ID" Name="ID" Type="Int32"></asp:QueryStringParameter>
        </WhereParameters>
                </asp:LinqDataSource>
</asp:Content>
