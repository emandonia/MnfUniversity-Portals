<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="Insert_Research_Fields.aspx.cs" Inherits="MnfUniversity_Portals.UI.Insert_Research_Fields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <asp:Label ID="Label3" runat="server" BackColor="#6699FF" Text="برجاء اختيار الكلية ثم القسم ثم العضو ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

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
                            
                             <asp:GridView ID="GridView1" Width="400px" Height="400px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                  OnPageIndexChanging="GridViewPageIndexChanging" runat="server" DataKeyNames="ID"  AllowPaging="True" PageSize="30" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                           

                           <Columns>

                               <asp:TemplateField HeaderText="Name" InsertVisible="False">

                                   <ItemTemplate>
                                       <div style="font-weight: bold; font-size: 14px">
                                       <asp:RadioButton GroupName="anygroup" ID="RadioButton1" AutoPostBack="True" ToolTip='<%#Eval("ID") %>' Text='<%#Eval("Name") %>' OnCheckedChanged="RadioButtonCheckedChanged" runat="server" />
                                  </div> </ItemTemplate>
                               </asp:TemplateField>



                           </Columns>
                           <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                           <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                           <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                           <RowStyle BackColor="#EFF3FB"></RowStyle>

                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                           <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                           <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                           <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                           <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                       </asp:GridView>
                            
                        </td>
                    </tr>

                 

                    <tr> <td>
                            <asp:Label ID="Label5" runat="server" Text="Insert Research Fields:" meta:resourcekey="Rsf1"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox1" CssClass="textboxservice2" TextMode="MultiLine" Columns="5" Rows="5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                    <tr> <td>
                            <asp:Label ID="Label6" runat="server" Text="Inserted By:" meta:resourcekey="insby"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextBox2"  CssClass="textboxservice2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                      </td>
                    </tr>
                    <tr> <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn" ID="Button1" runat="server" Text="Insert" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" />
                        </td></tr>
                    <tr>
                        <td>
                            <asp:Label ID="ResMessage" runat="server"  ForeColor="Red"></asp:Label>
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
