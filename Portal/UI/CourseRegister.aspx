<%@ Page  Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="CourseRegister.aspx.cs" Inherits="MnfUniversity_Portals.UI.CourseRegister" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div align="right" dir="rtl">
        <table width ="100%" align="right" dir="rtl" >
            <tr>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
            </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#009933" ></asp:Label>
                 </td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="اسم الدارس باللغة العربية :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

              <tr>
                 <td>
                     <asp:Label ID="Label3" runat="server" Text="اسم الدارس باللغة الانجليزية :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

              <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="الرقم القومى :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox3" runat="server" MaxLength ="14" CssClass="textboxservice2" ></asp:TextBox>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  
                          ControlToValidate="TextBox3" ValidationExpression="^[0-9]*$" Text="من فضللك ادخل الرقم القومى صحيح ."
                       ErrorMessage="Accepts only numbers." ></asp:RegularExpressionValidator> 
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>


             <tr>
                 <td>
                     <asp:Label ID="Label4" runat="server" Text="عنوان الدارس(محل الاقامة ) :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox4" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>
              <tr>
                 <td>
                     <asp:Label ID="Label5" runat="server" Text="الوظيفة او المهنة :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox5" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>
                     <asp:Label ID="Label6" runat="server" Text="الجهة /مكان العمل :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox6" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

              <tr>
                 <td>
                     <asp:Label ID="Label7" runat="server" Text="البريد الالكترونى :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox7" runat="server" CssClass="textboxservice2" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server"
                             ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBox7" 
                            ErrorMessage="يجب ادخال البريد الالكترونى بصورة صحيحة ."></asp:RegularExpressionValidator>
               
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

              <tr>
                 <td>
                     <asp:Label ID="Label8" runat="server" Text="رقم الموبايل :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                        </td>
                 <td>
                     <asp:TextBox ID="TextBox8" runat="server" MaxLength ="11" CssClass="textboxservice2" ></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="TextBox9"
                           ValidationExpression="^[0-9]*$" Text="من فضللك ادخل رقم محمول صحيح ."
                       ErrorMessage="Accepts only numbers." ></asp:RegularExpressionValidator> 
                     <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"  ErrorMessage="Accepts only numbers." 
                         ControlToValidate="TextBox8" ValidationExpression=""^[0-9]*$" Text="*"></asp:RegularExpressionValidator> 
         --%>     
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>
            
               <tr>
                 <td>
                     <asp:Label ID="Label9" runat="server" Text="رقم التليفون :" Font-Bold="True" Font-Size="Small" ></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox9" runat="server" MaxLength ="10" CssClass="textboxservice2" ></asp:TextBox>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  
                          ControlToValidate="TextBox9" ValidationExpression="^[0-9]*$" Text="من فضللك ادخل رقم تيفون صحيح ."
                       ErrorMessage="Accepts only numbers." ></asp:RegularExpressionValidator> 
                  
                 </td>
                 <td></td>
                 <td></td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>&nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td>&nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
            </tr>

             <tr>
                 <td></td>
                 <td>
                     <asp:Button ID="Button1" runat="server" Text="تسجيل"  CssClass ="btn" OnClick="Button1_Click" /></td>
                 <td>
                     &nbsp;</td>
                 <td></td>
                 <td></td>
            </tr>
             <tr>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
            </tr>
             <tr>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
                 <td></td>
            </tr>
        </table>


    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>--%>
