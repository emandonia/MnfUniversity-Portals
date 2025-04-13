<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="AdminAdv.aspx.cs" Inherits="MnfUniversity_Portals.UI.Admin.AdminAdv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <h3 class="item-header1">
      <%--<asp:Label ID="Label7"  runat="server" CssClass="entry-title1" Text="<%$Resources:Resource2, Admin_Adv%>" > </asp:Label>--%> 
        </h3>
    </br>  <a class="editors_page" href="AdminEditors.aspx">  <img src="../images/editors_page.png" /> </a>
      
     
    <%-- <asp:Panel runat="server"  CssClass="editor_title" ID="AllPanel" Visible="true">
    --%>
            <table width ="100%" >
                <tr><td></td><td></td><td></td><td></td><td></td></tr>
<tr><td>
    <asp:Button ID="Button1" CssClass="btn_editor" runat="server" Text="insertnew" meta:resourcekey="insertnew" OnClick="Button1_Click" />
    </td><td></td><td></td><td></td><td></td></tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr><td><%--meta:resourcekey="Search about"--%>
                    <asp:Label ID="Label1" runat="server"    Text="Search about" ></asp:Label>
                    </td><td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td><td></td><td><%-- meta:resourcekey="Search "--%>
                        <asp:Button ID="Button2" runat="server" CssClass="btn_editor_search" OnClick="Button3_Click"  Text="Search" />
                    </td><td></td><td></td></tr>
                    
                <tr><td></td><td></td><td></td><td></td><td></td></tr>

                <tr><td colspan="5">
                     
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4"  
                        DataKeyNames="ID"  GridLines="None" Height="100%"  Width="100%" OnPageIndexChanging="GridView1_OnPageIndexChanging">
                        <AlternatingRowStyle BackColor="White"  />
                        <Columns>
                            <asp:BoundField DataField="Text_ar" ControlStyle-CssClass="row2" HeaderText="الاستشارة"  SortExpression="Text_ar" />
                              <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="تعديل" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                      <asp:LinkButton ID="Details" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="Select" OnClick="Details_OnClick">تعديل</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="center" CssClass="row2" />
                                <ItemStyle HorizontalAlign="center" CssClass="row2"  />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderStyle-HorizontalAlign="center"  HeaderText="عرض التفاصيل" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                      <asp:LinkButton ID="Details2" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="xx" OnClick="Details2_Click">عرض</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="center" CssClass="row2" />
                                <ItemStyle HorizontalAlign="center" CssClass="row2" />
                            </asp:TemplateField>
                           
                        </Columns>
                        <EditRowStyle BackColor="#4a8abb" />
                        <FooterStyle BackColor="#59c4b2" CssClass="btn3" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#59c4b2" CssClass="col5" Height="40" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" CssClass="row1" Height="40" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" Height="40" CssClass="row1"  />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Al_Arabia.DataClasses1DataContext"
                        EntityTypeName="" TableName="Cons"  >
                    </asp:LinqDataSource>
                    
            </td></tr>
                <tr><td></td><td></td><td></td><td></td><td></td></tr>
                  <tr><td></td><td></td><td></td><td></td><td></td></tr>
                  <tr><td></td><td></td><td></td><td></td><td></td></tr>
               <tr>
                    <td colspan="5">
                          <asp:DetailsView ID="DetailsView1" runat="server"   AutoGenerateEditButton="False" OnItemDeleting ="DetailsView1_OnItemDeleting"
                            OnModeChanging ="DetailsView1_ModeChanging" AutoGenerateDeleteButton ="False"    OnItemUpdating="DetailsView1_OnItemUpdating" OnItemUpdated="DetailsView1_OnItemUpdated"
                            AutoGenerateInsertButton="False" AutoGenerateRows="False" CaptionAlign="right" CellPadding="4" 
                            DataKeyNames="ID" EmptyDataText="No records." ForeColor="#333333" GridLines="None" Height="50px" 
                            Width="75%">
                            <AlternatingRowStyle  />
                            <CommandRowStyle  Font-Bold="True" />
                            <Fields>
                                 <asp:TemplateField HeaderStyle-HorizontalAlign="center" ControlStyle-CssClass="row3"  HeaderText="الاستشارة" ItemStyle-HorizontalAlign="center" SortExpression="Text_ar">
                                    <InsertItemTemplate>
                                          <ajaxtk:CustomEditor runat="server" ID="content_ar"  Text='<%# Bind("Text_ar") %>' />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatfor6" runat="server" ControlToValidate ="content_ar"  ValidationGroup="g1"
                                            ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                                        </InsertItemTemplate>
                                    <EditItemTemplate>
                                         <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>
                               
                                         <ajaxtk:CustomEditor runat="server" ID="content_ar"  Text='<%# Bind("Text_ar") %>' />
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidfator7" runat="server" ControlToValidate ="content_ar"  ValidationGroup="g2"
                                            ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                               </EditItemTemplate>
                                    <ItemTemplate>
                                           <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>
                               
                                         <asp:Label ID="LblActualContent" Text='<%#Decode(Eval("Text_ar")) %>' runat="server" />
                                          </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>



                                   <asp:TemplateField HeaderStyle-HorizontalAlign="center" ControlStyle-CssClass="row3"  HeaderText="الاستشارة-انجليزى" ItemStyle-HorizontalAlign="center" SortExpression="Text_en">
                                    <InsertItemTemplate>
                                          <ajaxtk:CustomEditor runat="server" ID="content_en"  Text='<%# Bind("Text_en") %>' />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator06" runat="server" ControlToValidate ="content_ar"  ValidationGroup="g1"
                                            ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                                        </InsertItemTemplate>
                                    <EditItemTemplate>
                                         <%--<asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>--%>
                               
                                         <ajaxtk:CustomEditor runat="server" ID="content_en"  Text='<%# Bind("Text_en") %>' />
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator07" runat="server" ControlToValidate ="content_ar"  ValidationGroup="g2"
                                            ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                               </EditItemTemplate>
                                    <ItemTemplate>
                                           <%--<asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>--%>
                               
                                         <asp:Label ID="LblActualContent0" Text='<%#Decode(Eval("Text_en")) %>' runat="server" />
                                          </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                                     <InsertItemTemplate >
                 
                                           <%--<ajaxtk:AsyncFileUpload ID="insertFileUpload" runat="server" />--%>
                                  <ajaxtk:AsyncFileUpload ID="insertFileUpload" runat="server" PersistFile="True" PersistedStoreType="Session" Width="70px"></ajaxtk:AsyncFileUpload>

                </InsertItemTemplate>
               <EditItemTemplate>
                    <img width="14" height="10"  src='<%#Eval("Image") %>'  />
                    <%--<ajaxtk:AsyncFileUpload ID="EditeFileUpload" runat="server" />--%>
                       <ajaxtk:AsyncFileUpload ID="EditeFileUpload" runat="server" PersistFile="True" PersistedStoreType="Session" Width="70px"></ajaxtk:AsyncFileUpload>

                </EditItemTemplate>
                 <ItemTemplate>
                     <img width="14" height="10" src='<%#Eval("Image") %>'  />
                  
                </ItemTemplate>
            </asp:TemplateField>     
                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="ترتيب العنصر" ItemStyle-HorizontalAlign="Right" SortExpression="ordered">
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="ordered" runat="server"   Text='<%# Bind("ordered") %>'  ></asp:TextBox>
                                  
                                             <asp:RequiredFieldValidator ID="Required00FieldValidator2" runat="server" ControlToValidate ="ordered"  ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"   ControlToValidate="ordered" ErrorMessage="Value must be a whole number" />    
                                           </InsertItemTemplate>
                                    <EditItemTemplate>
                                         <asp:TextBox ID="ordered" runat="server"   Text='<%# Bind("ordered") %>'   ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFi00eldValidator2" runat="server" ControlToValidate ="ordered"  ErrorMessage="يجب ادخال البيانات"></asp:RequiredFieldValidator>
                                   
                                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="ordered" ErrorMessage="Value must be a whole number" />    
                                           </EditItemTemplate>
                                    <ItemTemplate>
                                            <asp:Label ID="Lblorder" Text='<%# Eval("ordered") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                       
                              
 <asp:TemplateField>
  <HeaderTemplate>
  <asp:Label ID="Labelaction" runat="server" Text=""></asp:Label>
  </HeaderTemplate>
     <ItemTemplate >
 <asp:Button ID="ButtonDelete" CssClass="btn_editor" runat="server"  Text="Delete" OnCommand="ButtonDeleteOnCommand" OnClientClick="return confirm('Are you sure you wish to Delete?');" CommandName="Delete" />
  <asp:Button ID="ButtonCancel" CssClass="btn_editor" runat="server" Text="Cancel" CausesValidation="False" OnCommand="ButtonCancelOnCommand" CommandName="Cancel" />
 
     </ItemTemplate>
                             
  <EditItemTemplate>
  <asp:Button ID="ButtonUpdate" CssClass="btn_editor_search" runat="server" Text="Update" OnCommand="ButtonUpdateOnCommand" OnClientClick="return confirm('Are you sure you wish to update?');" CommandName="Update" />
  <asp:Button ID="ButtonCancelEdit" runat="server" CssClass="btn_editor" Text="Cancel" CausesValidation="False" OnCommand="ButtonCancelEditOnCommand" CommandName="CancelEdit" />
  </EditItemTemplate>
   

  <InsertItemTemplate>
  <asp:Button ID="ButtonAdd" CssClass="btn_editor_search" runat="server" Text="Add" OnCommand="ButtonAddOnCommand" OnClientClick="return confirm('Are you sure you wish to Add?');" CommandName="Add" />
  <asp:Button ID="ButtonCancelInsert" CssClass="btn_editor" runat="server" Text="Cancel" CausesValidation="False" OnCommand="ButtonCancelInsertOnCommand" CommandName="CancelInsert" />
  </InsertItemTemplate>


     </asp:TemplateField>

                            </Fields>
                            <FooterStyle BackColor="Tan" CssClass="grid_footer" Font-Size="Medium" HorizontalAlign="center" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <AlternatingRowStyle />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <RowStyle />
                            <FooterStyle  CssClass="grid_footer" Font-Bold="True" Font-Size="Medium" ForeColor="White" HorizontalAlign="center" />
                            <HeaderStyle />
                        </asp:DetailsView>
                          
       
             </td>
                </tr>
                <tr>
                    <td style="height: 23px"></td>
                    <td style="height: 23px"></td>
                    <td style="height: 23px"></td>
                    <td style="height: 23px"></td>
                    <td style="height: 23px"></td>
                </tr>
                <tr>
                    <td colspan="5">
                       
         
                    </td>
                    
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>


            </table>

     </asp:Panel>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
