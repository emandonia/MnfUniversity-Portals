<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ResultsWebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
           <Triggers>
               <asp:PostBackTrigger ControlID="Button1" />
               <asp:PostBackTrigger ControlID="DropDownList1" />
               <asp:PostBackTrigger ControlID="DropDownList2" />
           </Triggers>
            <ContentTemplate>
                
            
    <div align="center">
        <asp:Label ID="Label11" runat="server" BackColor="#6699FF" Text="برجاء إدخال البيانات التالية ثم الضغط علي ابحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
        <table class="staffsearchtable" style="width: 900px;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="الكلية:" ></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" CssClass="textboxservice2" runat="server"   OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  AppendDataBoundItems="True" AutoPostBack="true" ControlToValidate="DropDownList1">
                        <asp:ListItem Value="0" meta:resourcekey="Fac">اختر الكلية</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <%--<td class="auto-style1">
                    <asp:LinqDataSource ID="LDSFaculty" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="AS_FACULTY_INFOs" Where="FACULTY_DESCR_AR != @FACULTY_DESCR_AR">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="null" Name="FACULTY_DESCR_AR" Type="String" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                </td>--%>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5"  runat="server" Text="الفرقة:" meta:resourcekey="YearDrop"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList2"  CssClass="textboxservice2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_OnSelectedIndexChanged" AppendDataBoundItems="True"  >
                    <asp:ListItem Value="0" meta:resourcekey="Year">اختر الفرقة</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp; </td>
            </tr>
           
             <tr>
                <td id="nidtd" runat="server" Visible="false"  class="auto-style3">
                    <asp:Label ID="Label6" runat="server" Text="الرقم القومي:" meta:resourcekey="nid"></asp:Label> &nbsp;&nbsp;
                    <asp:TextBox ID="nidTextBox1"  runat="server"></asp:TextBox>&nbsp;&nbsp; <asp:Label ID="Label12" runat="server" Text="or :" meta:resourcekey="or"></asp:Label>
                    
                </td>
                <td id="acidtd" runat="server" Visible="false"  class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="رقم الجلوس:" meta:resourcekey="seatid"></asp:Label> &nbsp;&nbsp;
                    <asp:TextBox ID="SeatnoTextBox1"  runat="server"></asp:TextBox>&nbsp;&nbsp; 
                    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                
                <td class="auto-style5"></br></br>
                    <asp:Button ID="Button1" runat="server" class="btn" Text="ابحث" meta:resourcekey="SearchButton" OnClick="Button1_Click" />
                </td>
                <td>&nbsp; </td>
            </tr>
           
        </table>

            
            <table>
                 <tr>
                     <td>
                <div >
                    <div style="float:right;font-size:large;">
                        <asp:FormView ID="STFormView" runat="server" align="center" >
                            <ItemTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                    <%--<Triggers>
                                        <asp:PostBackTrigger ControlID="AsyncFileUpload1" />
                                        <asp:PostBackTrigger ControlID="Button1" />
                                    </Triggers>--%>
                                    <ContentTemplate>
                                       
                                        <table style="width: 100%;">
                                            <tr>
                                                <asp:HiddenField ID="paystate" Value='<%# Eval("pay_stat") %>' runat="server"/>
                                                <td><asp:Label ID="Label77" runat="server" Text="الكلية:" meta:resourcekey="Facultyy"></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="Label2" runat="server" Text='<%# Eval("FACULTY_DESCR_AR") %>' ></asp:Label> &nbsp;&nbsp; </td>
                                                <td><asp:Label ID="Label8" runat="server" Text="العام الاكاديمي:" meta:resourcekey="acYYear"></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="Label4" runat="server" Text='<%# Eval("STU_ACD_YEAR") %>' ></asp:Label> &nbsp;&nbsp; </td>
                                               
                                            </tr>
                                             <tr>
                                                <td><asp:Label ID="Label14" runat="server" Text="القسم:" meta:resourcekey="DepDrop"></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="Label15" runat="server" Text='<%# Eval("STU_DEPT") %>' ></asp:Label> &nbsp;&nbsp; </td>
                                                <td><asp:Label ID="Label16" runat="server" Text="الفرقة:" meta:resourcekey="YearDrop"></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="Label17" runat="server" Text='<%# Eval("GRAD_DES") %>' ></asp:Label> &nbsp;&nbsp; </td>
                                               
                                            </tr>
                                            <tr>
                                                <td><asp:Label ID="Label9" runat="server" Text="اسم الطالب:" meta:resourcekey="Stname"></asp:Label> &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text='<%# Eval("STU_NAME") %>' ></asp:Label> &nbsp;&nbsp; </td>
                                                
                                            </tr>
                                            
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                        </asp:FormView>
                       <br /><br />

                         
              
                         <asp:ListView ID="ResultsListView" runat="server" OnItemDataBound="ResultsListView_ItemDataBound" >
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="1" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;border:medium !important;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="اسم المادة" meta:resourcekey="subname" ></asp:Label></th>
                                            <th id="markth" runat="server" visible="false"  ><asp:Label ID="Label18" runat="server" Text="الدرجة" meta:resourcekey="mark" ></asp:Label></th>
                                            <th id="Th1" runat="server" >
                                                                <asp:Label  ID="Label9" runat="server" Text="التقدير" meta:resourcekey="rating" ></asp:Label></th>     
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server" >
                                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                       <tr >
                           
                                            
                           <td class="col1"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("SUB_NAME")%>'></asp:Label></td>
                           <td runat="server" id="marktd" visible="false" class="col1"> <asp:Label ID="Label19" runat="server" Text='<%#Eval("STU_SUB_MARK")%>'></asp:Label></td>
                           <td class="col2"> <asp:Label ID="Label13" runat="server" Text='<%#Eval("STU_SUB_DEGREE")%>'></asp:Label></td>
                          
                           
                           </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoStaffFound" >لا توجد نتيجة 
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    

                   
                </asp:ListView>
                        <asp:Label ID="Label21" runat="server" Visible="false"  Text="* عفوا النتيجة محجوبة برجاء مراجعة كليتك." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

                        <br/><br/><br/>
                        <asp:Label ID="Label20" runat="server"  Text="* المجموع الكلي غير شامل درجات الرأفة." Font-Bold="True" Font-Size="15" ForeColor="Black"  ></asp:Label>
                   
                        
                        
                        
                         </div>
                  
            </div>
                         </td>
            </tr>
            </table>
        </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
