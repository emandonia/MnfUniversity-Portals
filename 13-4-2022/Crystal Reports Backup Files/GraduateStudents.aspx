<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" CodeBehind="GraduateStudents.aspx.cs" Inherits="GraduateStudents" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.Portal_BLL" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL"%>
<asp:Content ID="Content8" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <link href="../../../Styles/University_Master/css/grade.css" rel="stylesheet" />
     
     <asp:UpdatePanel runat ="server" > 
         <ContentTemplate > 
          <asp:Panel ID ="panel2" runat ="server" >
              <table dir="rtl"  style="width: 100%"  >
                  <tr>
                      <td></td>
                      <td></td>
                      <td></td>

                  </tr>


                  <tr>
                      <td>
                          <asp:Button ID="Button2" runat="server" CssClass="login_button" meta:resourcekey="bInsert" Text="ادخال خريج جديد" OnClick="Button2_Click" ValidationGroup ="g1"/>
                      </td>
                      <td>
                          <asp:Button ID="Button3" runat="server" CssClass="login_button" meta:resourcekey="bSearch"   Text="تعديل بيانات خريج" OnClick="Button3_Click" CausesValidation ="false"  />
                      </td>
                      <td></td>

                  </tr>

                  <tr>
                      <td></td>
                      <td></td>
                      <td><asp:Label ID="lblMsg" runat="server" Text=""  ></asp:Label></td>

                  </tr>

              </table>

          </asp:Panel>   

             <asp:Panel ID ="panel3" runat ="server"  Visible ="false" >

                 <table  dir="rtl"  style="width: 100%">
                         <tr>
                        <td>
                            <asp:Label ID="Label17"  runat="server" Text="Choose Faculty" meta:resourcekey="fc"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true"  DataTextField ="name" DataValueField ="ID"   AutoPostBack="true" 
                                  ID="DropDownList1" CssClass="textboxservice2" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                            
                            
                                                     
                        
                        </td>
                    </tr>
             <tr>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Choose Department:" meta:resourcekey="db"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" CssClass="textboxservice2" Enabled="true"  
                                  AutoPostBack="false" runat="server"
                                AppendDataBoundItems="true"
                                 >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label19" runat="server"  text ="Name" meta:resourcekey="na"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtName" runat="server" CssClass ="textboxservice2" ></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button4" runat="server" CssClass="login_button" Text="Button" OnClick="Button4_Click" meta:resourcekey="sa" />
                        </td>
                    </tr>

                 </table>

             </asp:Panel>
             
             <asp:Panel ID ="panel1" runat ="server"  Visible ="false" > 
      <table dir="rtl"  style="width: 100%"  >

       
        <tr  >
            <td style="width: 186px">
                <asp:Label ID="Label1" runat="server" Text="إسم الخريج باللغة العربية "></asp:Label>
            </td><td>
               
                <asp:TextBox ID="txtNameA" runat="server" CssClass ="textboxservice2"  ></asp:TextBox>
            </td><td  >
                &nbsp;</td>
        </tr>
          <tr>
            <td style="width: 186px">
                <asp:Label ID="Label2" runat="server" Text="إسم الخريج باللغة الانجليزية  "></asp:Label>
              </td><td>
            <asp:TextBox ID="txtNameE" runat="server" CssClass ="textboxservice2"></asp:TextBox>
              </td><td  >
                  &nbsp;</td>
        </tr>
          <tr>
            <td style="height: 24px; width: 186px;">
                  <asp:Label ID="Label3" runat="server" Text="العنوان"></asp:Label>
              </td><td style="height: 24px">
            <asp:TextBox ID="txtAdd" runat="server" CssClass ="textboxservice2"></asp:TextBox>
              </td><td  >
                  &nbsp;</td>
        </tr>
          <tr>
            <td style="width: 186px">
                  <asp:Label ID="Label4" runat="server" Text="التليفون"></asp:Label>
               
              </td><td>
            <asp:TextBox  ID="txtTel" runat="server" MaxLength ="10" ValidationGroup ="g1" CssClass ="textboxservice2"></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
     ControlToValidate="txtTel"
     ErrorMessage="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">please, enter numeric value
</asp:RegularExpressionValidator>
              </td><td  >
                  &nbsp;</td>
        </tr>
          <tr>
            <td style="width: 186px">
                  <asp:Label ID="Label13" runat="server" Text="المحمول" ></asp:Label>
              </td><td>
                  <asp:TextBox ID="txtMob" runat="server" MaxLength ="11" CssClass ="textboxservice2"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
     ControlToValidate="txtMob"
     ErrorMessage="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">please, enter numeric value
</asp:RegularExpressionValidator>
              </td><td  >
                  &nbsp;</td>
        </tr>
          <tr>
            <td style="width: 186px">
                  <asp:Label ID="Label5" runat="server" Text="البريد الالكترونى"></asp:Label>
              </td><td>
            <asp:TextBox   ID="txtEmail" runat="server" ValidationGroup ="g1" CssClass ="textboxservice2"></asp:TextBox>

              </td><td style="width: 396px">

                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
              
                  <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please enter valid email address. Eg. Something@domain.com" ValidationExpression="^\w+([-+.']\w+)*@domain.com$"></asp:RegularExpressionValidator>--%>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
              </td>
                <tr>
            <td style="width: 186px">
                        <asp:Label ID="Label10" runat="server" Text="الجامعة"></asp:Label>
                    </td><td>

                         
                    <asp:DropDownList ID="dropUni" runat="server" CssClass ="textboxservice2">
                        <asp:ListItem Text="اختر الجامعة "  Value="-1" ></asp:ListItem>
                         <asp:ListItem Text="جامعة المنوفية "  Value="1" ></asp:ListItem>
                    </asp:DropDownList>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>

               <tr>
                        <td>
                            <asp:Label ID="Label6"  runat="server" Text="Choose Faculty" meta:resourcekey="fc"></asp:Label>
                        </td>
                        <td>
                             
                            <asp:DropDownList CssClass ="textboxservice2" AppendDataBoundItems="true"  DataTextField ="name" DataValueField ="ID"   AutoPostBack="true" 
                                  ID="FacDropDownList"   OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Choose Department" meta:resourcekey="db"></asp:Label>
                        </td>
                        <td>
                              
                            <asp:DropDownList ID="DepDropDownList" CssClass="textboxservice2"  
                                  AutoPostBack="true" runat="server"
                                AppendDataBoundItems="true"
                                 >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>

            
               
            <td style="width: 186px">
                        <asp:Label ID="Label8" runat="server" Text="التخصص"></asp:Label>
                    </td><td>
            <asp:TextBox ID="txtspec" runat="server" Width="247px" CssClass ="textboxservice2"></asp:TextBox>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="height: 24px; width: 186px;">
                        <asp:Label ID="Label16" runat="server" Text="التقدير العام"></asp:Label>
                    </td><td style="height: 24px">
            <asp:TextBox ID="txtgrad" runat="server" CssClass ="textboxservice2"></asp:TextBox>
                    </td><td style="width: 396px; height: 24px;">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="width: 186px">
                        <asp:Label ID="Label9" runat="server" Text="سنة التخرج" ValidationGroup ="g1"></asp:Label>
                    </td><td>
            <asp:TextBox  ID="txtyear" runat="server" CssClass ="textboxservice2"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
     ControlToValidate="txtyear"
     ErrorMessage="Only numeric allowed." ForeColor="Red"
     ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">*
</asp:RegularExpressionValidator>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="width: 186px">
                        <asp:Label ID="Label15" runat="server" Text="الوظيفة الحالية"></asp:Label>
                    </td><td>
            <asp:TextBox ID="txtjob" runat="server" CssClass ="textboxservice2"></asp:TextBox>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="width: 186px">
                        <asp:label  ID="Label11" runat="server" Text="مكان العمل"></asp:label>
                    </td><td>
            <asp:TextBox ID="txtplace" runat="server" CssClass ="textboxservice2"></asp:TextBox>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="width: 186px">
                        <asp:label ID="Label12" runat="server" Text="الانشطة و المهارات"></asp:label>
                    </td><td>
            <asp:TextBox ID="txtskill" runat="server" Height="68px"  CssClass ="textboxservice2" TextMode="MultiLine" Width="288px"></asp:TextBox>
                    </td><td style="width: 396px">
                        &nbsp;</td>
        </tr>
                <tr>
            <td style="height: 22px; width: 186px;">
                <asp:Label ID="Label14" runat="server" Text="الدورات التدريبة"></asp:Label>
                    </td><td style="height: 22px">
            <asp:TextBox ID="txtcources" runat="server" Height="68px" CssClass ="textboxservice2" TextMode="MultiLine" Width="288px"></asp:TextBox>
                    </td><td dir="rtl" style="height: 22px; width: 396px"></td>
        </tr>
                <tr>
            <td style="width: 186px">&nbsp;</td><td dir="rtl">
                    <asp:Button ID="Button1" runat="server" Text="تسجيل" OnClick="Button1_Click" CssClass="login_button"  ValidationGroup ="g1"/>
                    </td><td style="width: 396px">&nbsp;</td>
        </tr>
        </table>

                 </asp:Panel>

             <asp:Panel  runat ="server" id ="panel4">
                 <table >
                     
                     <tr><td><%-- <asp:Label ID="lblMsg" runat="server" Text=""  ></asp:Label>--%></td></tr>
                     <tr><td>     <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CssClass="grid_all" OnDataBinding ="DetailsView1_DataBinding"
                         OnDataBound="DetailsView1_DataBound"
                            GridLines="None" Height="50px"    AllowPaging ="true"  OnPageIndexChanging ="DetailsView1_PageIndexChanging"
                            Width="50%" CellPadding="4" ForeColor="#333333" meta:resourcekey="DetailsView1Resource1" DataKeyNames="Id" >
                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                            <Fields>
                               <asp:TemplateField  HeaderText ="StuNameA" meta:resourcekey="StuNameA"     >
                                  
                                    <ItemTemplate > 
                                        <asp:HiddenField ID ="iDHide" runat ="server"  Value ='<%#Eval("Id")%>' />
                                        <asp:TextBox   ID ="StuNameA" runat ="server" ForeColor="BLUE"  CssClass ="textboxservice2" Text='<%#Eval("StuNameA")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="StuNameE"  meta:resourcekey="StuNameE"   >
                                   <ItemTemplate > <asp:TextBox ID ="StuNameE" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("StuNameE")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                
                               
                                
                                   <asp:TemplateField HeaderText="Adress"  meta:resourcekey="Adress">
                                   <ItemTemplate > <asp:TextBox ID ="Adress" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("Adress")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="Tel"  meta:resourcekey="Tel" >
                                   <ItemTemplate > <asp:TextBox ID ="Tel" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("Tel")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                
                                  <asp:TemplateField HeaderText="Email"  meta:resourcekey="Email"  >
                                   <ItemTemplate > <asp:TextBox ID ="Email" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("Email")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="faculty"  meta:resourcekey="faculty"  >
                                   <ItemTemplate >
                                       <asp:HiddenField ID ="fachide1" Value ='<%#Eval("FacID")%>'  runat ="server" />
                                        <asp:HiddenField ID ="Dephide1" Value ='<%#Eval("DepID")%>'  runat ="server" />
                                          
                                      <%--  <asp:TextBox ID ="faculty" runat ="server" ForeColor="BLUE"  Text='<%# gradeUtility.gettrans(Convert.ToInt32  (Eval("FacID")),StaticUtilities .Currentlanguage (Page ))%>'></asp:TextBox>--%>
                                   <asp:DropDownList AppendDataBoundItems="true"  DataTextField ="name" DataValueField ="ID"   AutoPostBack="true"  DataSource ='<%# Prtl_OwnersUtility.getFac(StaticUtilities.Currentlanguage(Page)) %>' OnDataBinding ="FacDrop_DataBinding"
                                  ID="FacDrop" CssClass="textboxservice2" OnSelectedIndexChanged ="FacDrop_SelectedIndexChanged"   runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>


                                       <asp:HiddenField ID ="Dephide2" Value ='<%#Eval("DepID")%>'  runat ="server" />
                                      <asp:DropDownList ID="DepDrop" CssClass="textboxservice2" Enabled="true" OnDataBinding ="DepDrop_DataBinding" 
                                            AutoPostBack="false" runat="server"   AppendDataBoundItems="true"  DataSource = '<%# getSource(Convert.ToInt32  (Eval("FacID")),StaticUtilities .Currentlanguage (Page ))%>'>
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>

                                      
                                   </ItemTemplate>
                               </asp:TemplateField>
                                 
                                <asp:TemplateField HeaderText="Department"  meta:resourcekey="Department" >
                                   <ItemTemplate >
                                         
                                        <%--<asp:TextBox ID ="faculty" runat ="server" ForeColor="BLUE"  Text='<%# gradeUtility.gettrans(Convert.ToInt32  (Eval("DepID")),StaticUtilities .Currentlanguage (Page ))%>'></asp:TextBox>--%>
                                      <%-- <asp:DropDownList ID="DepDrop" CssClass="textboxservice2" Enabled="true" OnDataBound="DepDrop_DataBinding"
                                            AutoPostBack="false" runat="server"   AppendDataBoundItems="true" >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>--%>
                                   </ItemTemplate>
                               </asp:TemplateField>
                                
                             
                                <asp:TemplateField  HeaderText="Grade"  meta:resourcekey="Grade">
                                   <ItemTemplate > <asp:TextBox ID ="Grade" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("Grade")%>' ></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                  
                                
                                    <asp:TemplateField HeaderText="WorkPlace"  meta:resourcekey="WorkPlace">
                                   <ItemTemplate > <asp:TextBox ID ="WorkPlace" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("WorkPlace")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                  
                                   <asp:TemplateField HeaderText="Skills"  meta:resourcekey="Skills">
                                   <ItemTemplate > <asp:TextBox ID ="Skills" runat ="server" TextMode="MultiLine"   CssClass ="textboxservice2" ForeColor="BLUE"  Text='<%#Eval("Skills")%>' Rows="5"></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                 
                                
                                
                                   <asp:TemplateField HeaderText="mobile"  meta:resourcekey="mobile" >
                                   <ItemTemplate > <asp:TextBox ID ="mobile" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2"  Text='<%#Eval("mobile")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="currentJob"  meta:resourcekey="currentJob" >
                                   <ItemTemplate > <asp:TextBox ID ="currentJob" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("currentJob")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="course"  meta:resourcekey="course" >
                                   <ItemTemplate > <asp:TextBox ID ="course" TextMode="MultiLine" Rows="5" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("course")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                               
                                 <asp:TemplateField  HeaderText="Year"  meta:resourcekey="Year">
                                   <ItemTemplate > <asp:TextBox ID ="Year" runat ="server" ForeColor="BLUE" CssClass ="textboxservice2" Text='<%#Eval("Year")%>'></asp:TextBox></ItemTemplate>
                               </asp:TemplateField>
                                
                                          <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    ShowHeader="False" meta:resourcekey="TemplateFieldResource8">
                                  <ItemTemplate >
                                        <asp:LinkButton ID="btnmodfy" runat="server" OnClick="btnmodfy_Click" Text="Update" meta:resourcekey="Update" CssClass="login_button"
                                            ></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="btncancel" runat="server" CausesValidation="False" meta:resourcekey="cc" OnClick="btncancel_Click" CssClass="login_button"
                                            Text="Cancel"  ></asp:LinkButton>
                                  </ItemTemplate >
                                  
                                    <HeaderStyle   />
                                    <ItemStyle   />
                                </asp:TemplateField> 


                            </Fields>
                            <AlternatingRowStyle CssClass="grid_alternat"  />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle CssClass="grid_item"  />
                            <FooterStyle CssClass="grid_footer"  />
                            <HeaderStyle CssClass="grid_header" Width ="400px" />
                        </asp:DetailsView>
               </td></tr>
                 </table>
                    


             </asp:Panel>

       </ContentTemplate></asp:UpdatePanel>

</asp:Content>

