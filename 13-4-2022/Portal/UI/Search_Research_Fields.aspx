<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="Search_Research_Fields.aspx.cs" Inherits="MnfUniversity_Portals.UI.Search_Research_Fields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <asp:Label ID="Label3" runat="server"  Text="برجاء اختيار الكلية ثم القسم ثم العضو ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 500px;">
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label1"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="true"   DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" CssClass="textboxservice2" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="FacDropDownList" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList" CssClass="textboxservice2" Enabled="false" DataTextField="DepName"
                                DataValueField="ID" AutoPostBack="true" runat="server"
                                AppendDataBoundItems="true"
                                OnSelectedIndexChanged="DepDropDownList_SelectedIndexChanged" >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DepDropDownList" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Choose Staff Member:" meta:resourcekey="NameLabelResource1"></asp:Label>
                        </td>
                        <td>
                            
                            
                                       <div style="font-weight: bold; font-size: 14px">
                                           <asp:RadioButtonList ID="RadioButtonList1" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server"></asp:RadioButtonList>
                                       
                                  </div> 
                          
                            
                        </td>
                    </tr>

                 

                    
                   
                    <tr> <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn3" ID="Button1" runat="server" Text="Search" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" />
                        </td></tr>
                    <tr>
                        <td>
                            <asp:Label ID="ResMessage" runat="server"  ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>

            </br></br>
                <table id="stftable" style="font-size:large">
                    <tr> <td style="padding-bottom:300px;">
                        <asp:Label ID="Label16" runat="server" Font-Bold="true" Visible="false" Text="المجالات البحثية للعضو: "></asp:Label></td>
                    <td style="padding-right:30px;">
                        <td style="padding-right:30px;">
                        <ul style="direction:ltr;font:bold">
<div runat="server" id="link">

</div>

</ul>
           <br /><br />
                            <div style="font-size:x-large !important;">
                            <asp:HyperLink ID="HyperLink1" Visible="false" Font-Bold="true" runat ="server" ForeColor="BLUE"
                                    Text="تعديل"></asp:HyperLink>            
                            </div>
                        <%--<asp:Label ID="ResLabel" Height="150px" Width="150px" runat="server" ></asp:Label>--%>
                       </td>
                    </tr>
                </table>


 </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
