﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="StaffServices.aspx.cs" Inherits="MnfUniversity_Portals.UI.StaffServices" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr style="text-align: left; color: brown;">
                    <h1  style="color:red;">طلب دعم فنى للبوابة الالكترونية لاعضاء هيئة التدريس </h1>
                    </tr>
                        <br/>
                        <br/>
                        <tr>
                            <h2>فى حالة حدوث أى عطل أو مشكلة فى الاتصال بالانترنت فى الجامعة يرجى اجراء أى من الخطوات التالية </h2>
                            </tr>
                            
                                <br/>
                               <tr>
                                   <%-- <h2  style=" color:red;">1.الاتصال التليفونى </h2>--%>
                                    </tr>
                                   <tr>
                                      <%--  <h2>م : فاطمة شوقى محمد مرعى </h2>--%>
                                        </tr>
                                        <tr>
                                           <%-- <h2>01010683748 </h2>--%>
                                            </tr>
                                   <tr>
                                       <%-- <h2>م : ايمان احمد دنيا </h2>--%>
                                        </tr>
                                        <tr>
                                          <%--  <h2>01007881185 </h2>--%>
                                            </tr> 
                                            
                                                <br/>
                                                <br/>
                                                <tr>
                                                    <h2 style=" color:red;"> ارسال البريد الالكترونى </h2>
                                                    </tr>
                                                    <tr>
                                                        <h2>mnfportal@gmail.com </h2>
                                                        </tr>
                                                        
                                                            <br/>
                                                            <br/>
                                                            <tr>
                                                                <h1  style=" color:red;text-align:right;"> ملئ النموذج التالى </h1>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server"><h2>الاسم</h2>
                        </asp:Label>
                                                                    </td>
                                                                    <td> 
                                                                        <asp:TextBox ID="TextBox1" CssClass="textboxservice" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server"><h2>الكليه</h2></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox2" CssClass="textboxservice" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server"><h2>رقم التليفون</h2></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox3" CssClass="textboxservice" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server"><h2>البريد الالكترونى</h2></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox4" CssClass="textboxservice"  runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server"><h2>الرساله</h2></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="textboxservice" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ارسال" />
                                                                    </td>
                                                                </tr>
                <tr><td>
                    <asp:Label ID="sentlabel" runat="server" Visible="false" ForeColor="red
                        " Text="Message Sent"></asp:Label>
                    </td></tr>
                                                           
                                                      
                                                               
                           
                                                        

            </table>
               </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>