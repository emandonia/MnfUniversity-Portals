<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.StaffPage" CodeBehind="StaffPage.aspx.cs" %>
<%@ Import Namespace="Common" %>

<asp:Content ID="Content2" ContentPlaceHolderID="meta" runat="Server">

    <meta http-equiv="Content-Type" content="صفحة اعضاء هيئة التدريس بجامعة المنوفية , menofia university staff " />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
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

          
            <asp:Label ID="Label3" runat="server" BackColor="#6699FF" Text="برجاء ادخال اسم العضو او الكلية او القسم ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 500px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server"  Text="Enter Staff Name:" meta:resourcekey="NameLabelResource1"></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox  ID="txtName" CssClass="textboxservice2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true"   DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" CssClass="textboxservice2" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
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
                                DataValueField="ID"  runat="server"
                                AppendDataBoundItems="true"
                                 >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                    

                 

                    <tr>
                        <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn" ID="Button1" runat="server" Text="Search" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>

                <asp:ListView ID="ListView1" runat="server" >
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="Name" meta:resourcekey="StaffNameLabelResource1" ></asp:Label></th>
                                            <th id="Th1" runat="server" >
                                                                <asp:Label  ID="Label9" runat="server" Text="Job" meta:resourcekey="StaffJobLabelResource1" ></asp:Label></th>
                                            <th id="Th5" runat="server" >
                                                                <asp:Label  ID="Label4" runat="server" Text="Job2" meta:resourcekey="StaffJobLabelResource2" ></asp:Label></th>
                                                            <th id="Th3"  runat="server"><asp:Label  ID="Label11" runat="server" Text="Department" meta:resourcekey="StaffDepLabelResource1" ></asp:Label></th>
                                                            <th id="Th4"  runat="server"><asp:Label  ID="Label12" runat="server" Text="Faculty" meta:resourcekey="StaffFacLabelResource1" ></asp:Label></th>
                                            
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
                           
                                            <td class="col1">
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#StaffUrl(Eval("Abbr").ToString())%>'
                                    Text='<%#Eval("Name")%>'></asp:HyperLink>
                        </td>
                           <td class="col2"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("Job")%>'></asp:Label></td>
                           <td class="col2"> <asp:Label ID="Label13" runat="server" Text='<%#Eval("Job2")%>'></asp:Label></td>
                           <td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%#Eval("DepName")%>'></asp:Label></td>
                           <td class="col4"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("FacName")%>'></asp:Label></td>
                           
                           </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoStaffFound" >No Staff Data Found
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    

                   
                </asp:ListView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
