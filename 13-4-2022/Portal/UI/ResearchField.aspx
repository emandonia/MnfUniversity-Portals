<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="ResearchField.aspx.cs" Inherits="MnfUniversity_Portals.UI.ResearchField" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MisBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <link href="../../Styles/University_Master/css/grade.css" rel="stylesheet" />
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <%--<asp:Label ID="Label3" runat="server" BackColor="#6699FF" Text="برجاء ادخال اسم العضو او الكلية او القسم ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>--%>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 500px;">
                    <tr> <td>
                            <asp:Label ID="Label7" runat="server" Text="Insert Research Fields:" meta:resourcekey="Rsf1"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox3" CssClass="textboxservice2" TextMode="MultiLine" Columns="5" Rows="5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                      </td>
                    </tr>

                  <%--   <tr> <td>
                            <asp:Label ID="Label6" runat="server" Text="Select University:" meta:resourcekey="uni"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="true"   runat="server" >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">جامعة المنوفية</asp:ListItem>
                            </asp:DropDownList>
                          </td>
                    </tr>--%>


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
                            <asp:Label ID="Label2" runat="server"  Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList" CssClass="textboxservice2" Enabled="false" DataTextField="DepName"
                                DataValueField="ID" AutoPostBack="true" runat="server"
                                AppendDataBoundItems="true"
                                OnSelectedIndexChanged="DepDropDownList_SelectedIndexChanged" >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="textboxservice2" ControlToValidate="DepDropDownList" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                        </td>
                    </tr>
                    <tr> 
                         
                        <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            
                             <asp:Button ID="Button1" runat="server"  CssClass="btn3" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" Text="Insert" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="ResMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr> 
                         
                        <td colspan="2">
                            
                             <asp:GridView ID="GridView1" Width="400px" Height="400px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                  OnPageIndexChanging="GridViewPageIndexChanging" runat="server" DataKeyNames="SA_STF_MEMBER_ID"  AllowPaging="True" PageSize="30" 
                                 CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                           

                           <Columns>

                               <asp:TemplateField HeaderText="Name"  meta:resourcekey="nameG" InsertVisible="False">

                                   <ItemTemplate >
                                       <div style="font-weight: bold; font-size: 18px; text-align:center;">


                                               <%--<asp:Label ID="Label44" runat="server"  Text='<%#Eval("STF_FULL_NAME_AR") %>'   ></asp:Label>--%>
                     <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#StaffUrl(Staff_Utility.getMemberAbbr( Convert .ToDecimal (  Eval("SA_STF_MEMBER_ID")),Page))%>'
                                    Text='<%#Eval("STF_FULL_NAME_AR")%>'></asp:HyperLink>
                                           </div> </ItemTemplate>
                               </asp:TemplateField>



                           </Columns>
                           <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                           <AlternatingRowStyle CssClass ="col6"></AlternatingRowStyle>

                           <FooterStyle CssClass="btn3"></FooterStyle>

                           <HeaderStyle CssClass="col5"></HeaderStyle>

                           <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                           <RowStyle  CssClass ="grid"></RowStyle>

                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                           <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                           <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                           <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                           <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                       </asp:GridView>
                            
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
