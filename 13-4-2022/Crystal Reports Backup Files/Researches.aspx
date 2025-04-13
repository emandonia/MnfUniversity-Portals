<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master" AutoEventWireup="true" CodeBehind="Researches.aspx.cs" Inherits="MnfUniversity_Portals.UI.Researches" %>
<%@ Import Namespace="MnfUniversity_Portals.Base_Code" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.MIS_BLL" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.Portal_BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <br/><br /><br />
            <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Style="font-size:18px;" Text="Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                    
                    <td> <asp:DropDownList ID="DropDownList1"  CssClass="textboxservice2" runat="server" DataSourceID="LDSFaculty" DataTextField="FACULTY_DESCR_AR" DataValueField="AS_FACULTY_INFO_ID" AppendDataBoundItems="True" ControlToValidate="DropDownList1">
                        <asp:ListItem Value="-1" meta:resourcekey="Fac">اختر الكلية</asp:ListItem>
                    </asp:DropDownList>
                        <asp:LinqDataSource ID="LDSFaculty" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="AS_FACULTY_INFOs" Where="FACULTY_DESCR_AR != @FACULTY_DESCR_AR">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="null" Name="FACULTY_DESCR_AR" Type="String" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                    </td>
                   
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="الاعضاء بدلالة المجالات" class="btn3" OnClick ="Button2_Click"/>  
                       <%-- <asp:HyperLink ID="HyperLink1"   Font-Bold="true" runat ="server"  
                                    Text="الاعضاء بدلالة المجالات" NavigateUrl = '<%#geturl1()%>'></asp:HyperLink>  
                   --%>

                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5"  Visible="True" runat="server" Style="font-size:18px;" Text="Title:" meta:resourcekey="Title"></asp:Label></td>
                    
                    <td> <asp:TextBox ID="TextBox1"  CssClass="textboxservice2" Visible="True" runat="server"></asp:TextBox>
                    </td>
                   
                    <td>
                        
                         <asp:Button ID="Button3" runat="server" Text="المجالات بدلالة الاعضاء" class="btn3" OnClick ="Button3_Click"/>  
                        <%--<asp:HyperLink ID="HyperLink2"   Font-Bold="true" runat ="server" 
                                    Text=" المجالات بدلالة الاعضاء" NavigateUrl ='<%#geturl2()%>' ></asp:HyperLink>--%> </td>
                   
                </tr>
                 <tr>
                    <td><asp:Label ID="Label6" Visible="True" Style="font-size:18px;" runat="server" Text="Name:" meta:resourcekey="AName"></asp:Label></td>
                     
                    <td> <asp:TextBox ID="TextBox2"  CssClass="textboxservice2" Visible="True" runat="server"></asp:TextBox>
                        <ajaxtk:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
 Enabled="True" ServiceMethod="GetCompletionList" MinimumPrefixLength="1" EnableCaching="true" ServicePath="AutoComplete.asmx" TargetControlID="TextBox2"></ajaxtk:AutoCompleteExtender>
                    </td>
                
                     <td>
                          <asp:Button ID="Button4" runat="server" Text="تقارير المجالات البحثية" class="btn3" OnClick ="Button4_Click"/>  
                        <%-- <asp:HyperLink ID="HyperLink3"   Font-Bold="true" runat ="server"  
                                    Text="تقارير المجالات البحثية" NavigateUrl ='<%#geturl3()%>'  ></asp:HyperLink>--%>

                     </td>
                
                </tr>
                <tr>
                    <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_OnClick" class="btn3" Text="Search" meta:resourcekey="search" />
                </td>
                
            </table>
            
            <br/><br/>
            <asp:Label ID="CountLbl" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br/><br/>
           <asp:ListView ID="ListView1" OnPagePropertiesChanging="ListView2_OnPagePropertiesChanging" runat="server" >

                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="Label" meta:resourcekey="NoData"></asp:Label></td>
                            
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <ItemTemplate>
                     <div id="resultsDiv">
                        <div class="pageContainer" style="display: block;">

                            <div class="webResult" style="width: 100%; direction: <%=StaticUtilities.Dir%>; text-align: <%=StaticUtilities.Textright%>;">

                                <h2>
                                     <asp:Label ID="Label12" runat="server" Text="عنوان البحث: " meta:resourcekey="title" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("SA_SC_RESEARCH.RESEARCH_TITLE") %>' runat="server" ID="AddressLabel" Font-Bold="True" />

                                </h2>
                                <p>
                                     <asp:Label ID="Label7"  runat="server" Text="اسم الباحث:"  meta:resourcekey="AName" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp; <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="BLUE" NavigateUrl='<%#StaffUrl(Eval("SA_STF_MEMBER.SA_STF_MEMBER_ID").ToString())%>'
                                    Text='<%#Eval("SA_STF_MEMBER.STF_FULL_NAME_AR")%>'></asp:HyperLink>
                                    <%--<asp:Label ID="Label7"  runat="server" Text="اسم الباحث:"  meta:resourcekey="AName" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("SA_STF_MEMBER.STF_FULL_NAME_AR") %>' runat="server" ID="EngMainResNameLabel" Font-Bold="True" /><br />--%>

                                   
                                </p>
                                <p>
                                    <asp:Label ID="Label8"  runat="server" Text="الكلية:"  meta:resourcekey="Fac" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#ResearchUtility.GetFacName(StaticUtilities.Currentlanguage(Page),Convert.ToDecimal(Eval("AS_FACULTY_INFO_ID"))) %>' runat="server" ID="Label9" Font-Bold="True" /><br />

                                   
                                </p>
                                    <p>
                                    <asp:Label ID="Label10"  runat="server" Text="تاريخ الموافقة:"  meta:resourcekey="APPROVALDATE" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#StaticUtilities.ExtractDate(StaticUtilities.FormatDate(Eval("SA_SC_RESEARCH.APPROVAL_DATE"))) %>' runat="server" ID="Label11" Font-Bold="True" /><br />

                                   
                                </p>
                                <p>
                                    <asp:Label ID="Label2"  runat="server" Text="ملخص البحث:"  meta:resourcekey="Summary" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#ResearchUtility.GetResSummery(Convert .ToDecimal(Eval("SA_SC_RESEARCH_ID")),StaticUtilities.Currentlanguage(Page))%>' runat="server" ID="Label3" Font-Bold="True" /><br />

                                   
                                </p>
                                 <p>
                                    <asp:Label ID="Label13"  runat="server" Text="عدد الصفحات:"  meta:resourcekey="PagesNumber" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("SA_SC_RESEARCH.PAGES_NUM")%>' runat="server" ID="Label14" Font-Bold="True" /><br />

                                   
                                </p>
                                  <p>
                                    <asp:Label ID="Label15"  runat="server" Text="المشاركون:"  meta:resourcekey="Researchers" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#ResearchUtility.GetResearcher(Convert.ToDecimal(Eval("SA_SC_RESEARCH.SA_SC_RESEARCH_ID"))) %>' runat="server" ID="Label16" Font-Bold="True" /><br />

                                   
                                </p>
                       
                                 
                                 
                                
                                
                            </div>
                        </div>
                    </div>
                    

                </ItemTemplate>
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholderContainer">

                        <div runat="server" id="itemPlaceholder">
                        </div>
                                   
                        <asp:DataPager runat="server"  ID="DataPager1"  PagedControlID="ListView1"  PageSize="15">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                     
                    </div>
                </LayoutTemplate>

            </asp:ListView>
            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Mis_DAL.MisDataContext" TableName="SA_RESEARCH_TEAMs"></asp:LinqDataSource>
      
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
