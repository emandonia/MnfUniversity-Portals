<%@ Page Title="مرحبا بكم" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AnnualYouthWeekWebApplication._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="meta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <style>
table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 50%;
   
    dir: rtl;
    align-content: center;
    
}

 th {
    border: 1px solid #dddddd;
     text-align: center;
    padding: 8px;
}
td {
    border: 1px solid #dddddd;
    /*text-align: left;*/
    padding: 8px;
    font-style: normal;
    font-size: large;
}
tr:nth-child(even) {
    background-color: #dddddd;
}
.btn {
    background: #2d6656;
  background-image: -webkit-linear-gradient(top, #2d6656, #4b827b);
  background-image: -moz-linear-gradient(top, #2d6656, #4b827b);
  background-image: -ms-linear-gradient(top, #2d6656, #4b827b);
  background-image: -o-linear-gradient(top, #2d6656, #4b827b);
  background-image: linear-gradient(to bottom, #2d6656, #4b827b);
  
  -webkit-border-radius: 28;
  -moz-border-radius: 28;
  border-radius: 28px;
  font-family: Arial;
  color: #ffffff;
  font-size: 20px;
  padding: 10px 20px 10px 20px;
  text-decoration: none;
}

.btn:hover {
  background: #34d99c;
  background-image: -webkit-linear-gradient(top, #34d99c, #2bb874);
  background-image: -moz-linear-gradient(top, #34d99c, #2bb874);
  background-image: -ms-linear-gradient(top, #34d99c, #2bb874);
  background-image: -o-linear-gradient(top, #34d99c, #2bb874);
  background-image: linear-gradient(to bottom, #34d99c, #2bb874);
  text-decoration: none;
}
         .auto-style1 {
             font-size: xx-large;
         }
     </style>
    
   <%-- <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        
        <ContentTemplate>--%>
             <h2>عذرا</h2>
             <h2>تم غلق تسجيل الدخول للجامعات التالية وذلك لمراجعة بياناتهم وشكرا:</h2>
             <h2>(القاهرة-عين شمس-حلوان-بنها-طنطا-كفر الشيخ-جنوب الوادي-قناة السويس-السويس-السادات-الاسكندرية-المنصورة-الفيوم-المنيا-اسيوط-بورسعيد-دمنهور-سوهاج-دمياط-بني سويف-الازهر-اسوان-التعليم العالي)</h2>
    <asp:Label ID="Label1" runat="server" ForeColor="red" Visible="true" ></asp:Label>
    <table >
        <tr>
            <th colspan="2" style="font-size: larger;">تسجيل الدخول</th>
           
        </tr>
        <tr>
            <td >اسم المستخدم:</td>
            <td>
                
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        <tr>
            <td>كلمة السر: </td>
            <td>
                <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="red" ErrorMessage="*"></asp:RequiredFieldValidator>

            </td>
            
        </tr>
        
        <tr><td colspan="2" style="text-align: center;">
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="تسجيل دخول" OnClick="Button1_OnClick" /></td></tr>
       <%-- <tr><td>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/Forgetpassword.aspx" runat="server">نسيان كلمة المرور</asp:HyperLink></td></tr>--%>
    </table>
    
    
    
    
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
 
</asp:Content>
