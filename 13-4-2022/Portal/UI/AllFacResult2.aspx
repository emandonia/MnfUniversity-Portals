
<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="AllFacResult2.aspx.cs" Inherits="MnfUniversity_Portals.UI.AllFacResult2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-57986194-1', 'auto');
        ga('send', 'pageview');

    </script>
 <asp:Timer ID="Timer1" OnTick="Timer1_OnTick" runat="server"></asp:Timer>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />

        </Triggers>
        <ContentTemplate>
           <p style="font: bold; color: red;font-size: xx-large">تنويه هام<br/> 
              <br/> سيتم رفع النتائج علي الايميل الرسمي للطلاب&nbsp; للحصول علي الايميل الرسمي من <a href="http://193.227.24.15/StudentMail_Publish/studentmail.aspx">هنـــــا</a></p>

             
                <asp:Label ID="Label11" runat="server" BackColor="#6699FF" Text="برجاء إدخال البيانات التالية ثم الضغط علي ابحث." Font-Bold="True" Font-Size="20" ForeColor="Black"></asp:Label>

                <br />
                <br />
                <table class="staffsearchtable" style="width: 900px;">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label1" runat="server" Text="Faculty :" meta:resourcekey="FacDrop"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:DropDownList ID="DropDownList1" CssClass="textboxservice2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="true">
                                <asp:ListItem Value="0" meta:resourcekey="Fac">اختر الكلية</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label5" runat="server" Text="Years :" meta:resourcekey="YearDrop"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:DropDownList ID="DropDownList2" CssClass="textboxservice2" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList2_OnSelectedIndexChanged">
                                <asp:ListItem Value="0" meta:resourcekey="Year">اختر الفرقة</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp; </td>
                    </tr>

                    <tr>
                        <td id="nidtd" runat="server" visible="false" class="auto-style3">
                            <asp:Label ID="Label6" runat="server" Text="National ID :" meta:resourcekey="nid"></asp:Label>
                            &nbsp;&nbsp;
                    <asp:TextBox ID="nidTextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Label ID="Label12" runat="server" Text="or :" meta:resourcekey="or"></asp:Label>
                            
                            <asp:RangeValidator runat="server" MinimumValue="0" MaximumValue="99999999999999" ControlToValidate="nidTextBox1" Type="Double" ErrorMessage="الرقم القومي يجب ان يكون 14 رقم فقط"></asp:RangeValidator>
                        </td>
                        <td id="acidtd" runat="server" visible="false" class="auto-style3">
                            <asp:Label ID="Label3" runat="server" Text="Seat Number :" Visible="false" meta:resourcekey="seatid"></asp:Label>
                            &nbsp;&nbsp;
                    <asp:TextBox ID="SeatnoTextBox1" runat="server" Visible="false"></asp:TextBox>
                            
                            <asp:RangeValidator runat="server" MinimumValue="0" MaximumValue="999999999" ControlToValidate="SeatnoTextBox1" Type="Integer" ErrorMessage="رقم الجلوس  يجب ان يكون 9 ارقام فقط"></asp:RangeValidator>
&nbsp;&nbsp; 
                    
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>

                        <td class="auto-style5">
                            <br>
                            <br></br>
                            <br></br>
                            <br>
                            <br></br>
                            <br></br>
                            <asp:Button ID="Button1" runat="server" class="btn" meta:resourcekey="SearchButton" OnClick="Button1_Click" Text="Search" />
                            </br>
                            </br>
                        </td>
                        <td>&nbsp; </td>
                    </tr>

                </table>


                <table>
                    <tr>
                        <td>
                            <div>
                                <div style="float: <%=StaticUtilities.FloatRight%>; font-size: large;">
                                    <asp:FormView ID="STFormView" runat="server" align="center">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                <%--<Triggers>
                                        <asp:PostBackTrigger ControlID="AsyncFileUpload1" />
                                        <asp:PostBackTrigger ControlID="Button1" />
                                    </Triggers>--%>
                                                <ContentTemplate>

                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <asp:HiddenField ID="paystate" Value='<%# Eval("pay_stat") %>' runat="server" />
                                                            <td>
                                                                <asp:Label ID="Label77" runat="server" Text="Faculty" meta:resourcekey="Facultyy"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label2" runat="server" Text='<%# Eval("FACULTY_DESCR_AR") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text="Year" meta:resourcekey="acYYear"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label4" runat="server" Text='<%# Eval("STU_ACD_YEAR") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text="dep" meta:resourcekey="DepDrop"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label15" runat="server" Text='<%# Eval("STU_DEPT") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>
                                                            <td>
                                                                <asp:Label ID="Label16" runat="server" Text="Year" meta:resourcekey="YearDrop"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label17" runat="server" Text='<%# Eval("GRAD_DES") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="StName" meta:resourcekey="Stname"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label7" runat="server" Text='<%# Eval("STU_NAME") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>

                                                        </tr>
                                                         <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text="Sum" meta:resourcekey="Sum"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label21" style="font: larger;color: red" runat="server" Text='<%# Eval("STU_MARKS_SUM") %>'></asp:Label>
                                                                &nbsp;&nbsp; </td>
                                                             <td>
                                                                 <asp:Label ID="Label22" runat="server" Text="Sum" meta:resourcekey="GenDegre"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label23" style="font: larger;color: red" runat="server" Text='<%# Eval("STU_DEGREE") %>'></asp:Label>
                                                                &nbsp;&nbsp;
                                                             </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text="Sum" meta:resourcekey="status"></asp:Label>
                                                                &nbsp;&nbsp;
                   <asp:Label ID="Label25" style="font: larger;color: red" runat="server" Text='<%# Eval("STU_RES_STATUS") %>'></asp:Label>
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:FormView>
                                    <br />
                                    <br />



                                    <asp:ListView ID="ResultsListView" runat="server" OnItemDataBound="ResultsListView_ItemDataBound">
                                        <LayoutTemplate>
                                            <table id="Table1" runat="server" border="1" width="100%">
                                                <tr id="Tr1" runat="server">
                                                    <td id="Td1" runat="server">
                                                        <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif; border: medium !important;">
                                                            <tr id="Tr3" runat="server">


                                                                <th id="Th2" runat="server">
                                                                    <asp:Label ID="Label10" runat="server" Text="Subject Name" meta:resourcekey="subname"></asp:Label></th>
                                                                <th id="markth" runat="server" visible="false">
                                                                    <asp:Label ID="Label18" runat="server" Text="Mark" meta:resourcekey="mark"></asp:Label></th>
                                                                <th id="Th1" runat="server">
                                                                    <asp:Label ID="Label9" runat="server" Text="Rating" meta:resourcekey="rating"></asp:Label></th>
                                                            </tr>
                                                            <tr id="itemPlaceholder" runat="server">
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </LayoutTemplate>

                                        <ItemTemplate>
                                            <tr>


                                                <td class="col1">
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("SUB_NAME")%>'></asp:Label></td>
                                                <td runat="server" id="marktd" visible="false" class="col1">
                                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("STU_SUB_MARK")%>'></asp:Label></td>
                                                <td class="col2">
                                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("STU_SUB_DEGREE")%>'></asp:Label></td>


                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                                <tr id="Tr2" runat="server">
                                                    <td id="Td3" runat="server" meta:resourcekey="NoStaffFound">لا توجد نتيجة 
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>



                                    </asp:ListView>
                                    <asp:Label ID="blocklabel" runat="server" Visible="false" Text="* عفوا النتيجة محجوبة برجاء مراجعة كليتك." Font-Bold="True" Font-Size="20" ForeColor="red"></asp:Label>


                                    <asp:Label ID="totallabel" Visible="False" runat="server" Text="* المجموع الكلي غير شامل درجات الرأفة." Font-Bold="True" Font-Size="15" ForeColor="red"></asp:Label>

                                    <asp:Label ID="nulllabel" Visible="False" runat="server" Text="لا توجد نتيجة" Font-Bold="True" Font-Size="20" ForeColor="red"></asp:Label>

                                    <%--<asp:Label ID="digitlbl" Visible="False" runat="server" Text="رقم الجلوس يجب ان يكون بحد اقصي 9 (ارقام فقط)." Font-Bold="True" Font-Size="20" ForeColor="red"></asp:Label>--%>



                                </div>

                            </div>
                        </td>
                    </tr>
                </table>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
