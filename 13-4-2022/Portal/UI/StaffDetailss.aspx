<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.StaffDetailss" CodeBehind="StaffDetailss.aspx.cs" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MisBLL" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">

        <ContentTemplate>
 
            <div style="font-weight: bold">
                <asp:HiddenField ID="MisId" runat="server" />
                <ajaxtk:Accordion 
                    ID="Accordion1"
                    CssClass="accordion"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent"
                    runat="server" >
                    <Panes>
                        <ajaxtk:AccordionPane ID="AccordionPane1" ToolTip="Personal Data" runat="server">
                            <Header>
                                <asp:Label ID="Label1" runat="server" Text="Personal Data" meta:resourcekey="PdLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView1" runat="server" DataKeyNames="SA_STF_MEMBER_ID"
                                    DataSourceID="LinqDataSource1">

                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>

                                    <ItemTemplate>
                                       
                                        <tr><td></td>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text="الاسم الاول:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp; <asp:Label ID="STF_FULL_NAME_ARLabel" runat="server"
                                                    Text='<%#Eval("STF_NAME_AR") %>' /></td>
                                        </tr>
                                        <tr><td></td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="اسم العائلة:"></asp:Label>
                                            </td>
                                            <td>
                                               &nbsp;&nbsp;&nbsp; <asp:Label ID="STF_FULL_NAME_ENLabel" runat="server"
                                                    Text='<%# Eval("STF_LNAME_AR") %>' />
                                            </td>
                                        </tr>
                                       
                                      <tr><td></td>
                                            <td>
                                                <asp:Label ID="Label31" runat="server" Text="التخصص العام:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="PG_THESIS_GENERAL_SPEC_IDLabel" runat="server"
                                                    Text='<%# Eval("PG_THESIS_GENERAL_SPEC.GENERAL_SPEC_DESCR_AR") %>' />
                                            </td>
                                        </tr>

                                        <tr><td></td>
                                            <td>
                                                <asp:Label ID="Label32" runat="server" Text="التخصص الدقيق:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="PG_THESIS_DETAILED_SPEC_IDLabel" runat="server"
                                                    Text='<%# Eval("PG_THESIS_DETAILED_SPEC.DETAILED_SPEC_DESC_AR") %>' />
                                            </td>
                                        </tr>

                                        <tr><td></td>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text="الوظيفة الحالية:"></asp:Label>
                                            </td>
                                            <td>
                                               &nbsp;&nbsp;&nbsp; <asp:Label ID="Label44" runat="server"
                                                    Text='<%# Eval("SA_CODE_SC_DEG.SC_DEG_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                        <tr >
                                           
                                            <td>
                                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="addresschecked" Checked='<%# GetAdressPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>'  /> 
                                             </td>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" Visible='<%#checkAdress() %>' Text="العنوان:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label43" Visible='<%#checkAdress() %>' runat="server"
                                                    Text='<%# Eval("STF_CURR_ADD") %>' />

                                            </td>
                                        </tr>

                                        <tr><td>
                                                <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="Emailchecked" Checked='<%# GetEmailPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>'  />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label35" runat="server" Visible='<%#checkEmail() %>' Text="البريد الالكتروني:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label36" Visible='<%#checkEmail() %>' runat="server"
                                                    Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),2) %>' />
                                            </td>
                                        </tr>

                                        <tr><td>
                                                <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="Telchecked" Checked='<%# GetTelPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>'  />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label37" runat="server" Visible='<%#checkTel() %>' Text="الهاتف المحمول:"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label38" Visible='<%#checkTel() %>' runat="server"
                                                    Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),5) %>' />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                                                
                                               <asp:Button ID="Button5" runat="server" class="btn" Text="Update_Info" Visible='<%#checkUser() %>'  OnClick="UpdateInfo"  />
                                              
                                            </td>
                                        </tr>

                                        
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table2" runat="server">

                                            <tr id="Tr1" runat="server">

                                                <td id="Td1" runat="server">

                                                    <table id="Table1" runat="server" border="0" >

                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                  
                                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Mis_DAL.MisDataContext"
                                    EntityTypeName="" TableName="SA_STF_MEMBERs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane2" ToolTip="Scientific Degree" runat="server">
                            <Header>
                                <asp:Label ID="Label2" runat="server" Text="Scientific Degree" meta:resourcekey="sdLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView2" runat="server" DataKeyNames="SA_SC_QUAL_ID"
                                    DataSourceID="SciDegreeLinqDataSource">
                                    <EmptyDataTemplate>
                                        <table id="Table5" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="SC_DEG_DATELabel" runat="server"
                                                    Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime(Eval("SC_DEG_DATE")) )  %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="GS_COUNTRY_NODE_IDLabel" runat="server"
                                                    Text='<%# Eval("GS_COUNTRY_NODE.NODE_DESCR_AR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="AS_CODE_DEGREE_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_CODE_DEGREE.DEGREE_DESCR_AR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="AS_NODE_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table3" runat="server">
                                            <tr id="Tr2" runat="server">
                                                <td id="Td2" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr3" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th1" runat="server">SC_DEG_DATE</th>

                                                            <th id="Th2" runat="server">COUNTRY</th>
                                                            <th id="Th3" runat="server">DEGREE</th>
                                                            <th id="Th4" runat="server">Faculty</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr4" runat="server">
                                                <td id="Td3" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="SciDegreeLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_SC_QUALs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane3" ToolTip="Position" runat="server">
                            <Header>
                                <asp:Label ID="Label4" runat="server" Text="Position" meta:resourcekey="poLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView3" runat="server" DataKeyNames="SA_EMP_HIERARCHY_ID"
                                    DataSourceID="posLinqDataSource">
                                    <EmptyDataTemplate>
                                        <table id="Table5" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="FROM_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("FROM_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="TO_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("TO_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="SA_CODE_SC_DEG_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_SC_DEG.SC_DEG_DESCR_AR") %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table4" runat="server">
                                            <tr id="Tr5" runat="server">
                                                <td id="Td4" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr6" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th5" runat="server">FROM_DATE</th>
                                                            <th id="Th6" runat="server">TO_DATE</th>
                                                            <th id="Th7" runat="server">DEGREE</th>
                                                            <th id="Th8" runat="server">place</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr7" runat="server">
                                                <td id="Td5" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="posLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_EMP_HIERARCHies">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane4" ToolTip="Training" runat="server">
                            <Header>
                                <asp:Label ID="Label5" runat="server" Text="Training" meta:resourcekey="trLabelResource1"></asp:Label>
                            </Header>
                            <Content>

                                <asp:ListView ID="ListView4" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table5" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_FROM"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_TO"))) %>' runat="server" ID="Label45" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SC_MEETING_NAME") %>' runat="server" ID="Label46" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("ADDRESS") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th44" runat="server">MEETING NAME</th>
                                                            <th id="Th45" runat="server">ADDRESS</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane5" ToolTip="Sharing" runat="server">
                            <Header>
                                <asp:Label ID="Label6" runat="server" Text="Sharing" meta:resourcekey="shLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView145" runat="server" DataSourceID="LinqDataSource2" DataKeyNames="Project_ID">


                                    <EmptyDataTemplate>
                                        <table id="Table5" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>

                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("StartDate"))) %>' runat="server" ID="StartDateLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("Project_Name") %>' runat="server" ID="Project_NameLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("Fund") %>' runat="server" ID="FundLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("Sponsor") %>' runat="server" ID="SponsorLabel" /></td>


                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table16" runat="server">
                                            <tr id="Tr8" runat="server">
                                                <td id="Td6" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr9" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th1" runat="server">Start Date</th>
                                                            <th id="Th11" runat="server">Project Name</th>
                                                            <th id="Th12" runat="server">Fund</th>
                                                            <th id="Th46" runat="server">Sponsor</th>

                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr10" runat="server">
                                                <td id="Td7" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>

                                </asp:ListView>
                                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Mis_DAL.MisDataContext" TableName="Project_Infos"></asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane6" ToolTip="Membership" runat="server">
                            <Header>
                                <asp:Label ID="Label7" runat="server" Text="Membership" meta:resourcekey="memLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView167" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("FROM_DATE"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("TO_DATE"))) %>' runat="server" ID="Label45" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("SCIENTIFIC_DESCR_AR") %>' runat="server" ID="Label48" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("MEMBERSHIP_DESCR_AR") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th44" runat="server">SCIENTIFIC DESCR AR</th>

                                                            <th id="Th45" runat="server">MEMBERSHIP DESCR AR</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane7" ToolTip="Admin" runat="server">
                            <Header>
                                <asp:Label ID="Label8" runat="server" Text="Admin" meta:resourcekey="adminLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView5" runat="server"
                                    DataKeyNames="SA_SUPERVISING_JOBS_ID" DataSourceID="AdminLinqDataSource">

                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="SA_CODE_SUPERVISE_JOB_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_SUPERVISE_JOB.JOB_DESCR_AR") %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <LayoutTemplate>
                                        <table id="Table6" runat="server">
                                            <tr id="Tr11" runat="server">
                                                <td id="Td8" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr12" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th13" runat="server">START DATE</th>
                                                            <th id="Th14" runat="server">END DATE</th>
                                                            <th id="Th15" runat="server">JOB</th>
                                                            <th id="Th16" runat="server">PLACE</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr13" runat="server">
                                                <td id="Td9" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>

                                <asp:LinqDataSource ID="AdminLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_SUPERVISING_JOBs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane8" ToolTip="structural works" runat="server">
                            <Header>
                                <asp:Label ID="Label9" runat="server" Text="structural works" meta:resourcekey="stLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView166" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label Text='<%# Eval("ESTABLISH_DESCR_AR") %>' runat="server" ID="Label48" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("FROM_DATE"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("TO_DATE"))) %>' runat="server" ID="Label45" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("PLACE") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th44" runat="server">ESTABLISH DESC</th>
                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th45" runat="server">PLACE</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane9" ToolTip="Prices" runat="server">
                            <Header>
                                <asp:Label ID="Label10" runat="server" Text="Prices" meta:resourcekey="PricesLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView6" runat="server" DataKeyNames="SA_STF_PRIZE_ID"
                                    DataSourceID="prizeLinqDataSource">

                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="PRIZE_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("PRIZE_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="SA_CODE_PRIZE_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_PRIZE.PRIZE_DESCR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <LayoutTemplate>
                                        <table id="Table7" runat="server">
                                            <tr id="Tr14" runat="server">
                                                <td id="Td10" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr15" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th17" runat="server">PRIZE_DATE</th>

                                                            <th id="Th18" runat="server">SA_CODE_PRIZE_ID</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr16" runat="server">
                                                <td id="Td11" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>

                                <asp:LinqDataSource ID="prizeLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_STF_PRIZEs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane10" ToolTip="Visitor" runat="server">
                            <Header>
                                <asp:Label ID="Label11" runat="server" Text="Visitor" meta:resourcekey="visitorLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView12" runat="server" DataKeyNames="SA_PAR_DEL_ID"
                                    DataSourceID="visitLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label ID="SA_CODE_ORG_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="ACT_START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("ACT_START_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="ACT_END_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("ACT_END_DATE"))) %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table13" runat="server">
                                            <tr id="Tr32" runat="server">
                                                <td id="Td22" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr33" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th37" runat="server">ORGANIZATION</th>
                                                            <th id="Th38" runat="server">START DATE</th>
                                                            <th id="Th39" runat="server">END DATE</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr34" runat="server">
                                                <td id="Td23" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="visitLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_PAR_DELs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane11" ToolTip="Educational Activities" runat="server">
                            <Header>
                                <asp:Label ID="Label12" runat="server" Text="Educational Activities" meta:resourcekey="eduLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                التدريس
        <br />
                                <asp:ListView ID="ListView11" runat="server" DataKeyNames="SA_STF_SUBJECT_ID"
                                    DataSourceID="teachingLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="ED_CODE_SUBJECT_IDLabel" runat="server"
                                                    Text='<%# Eval("ED_CODE_SUBJECT.SUBJECT_DESCR_AR") %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table12" runat="server">
                                            <tr id="Tr29" runat="server">
                                                <td id="Td20" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr30" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th35" runat="server">SUBJECT</th>

                                                            <th id="Th36" runat="server">FACULTY</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr31" runat="server">
                                                <td id="Td21" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="teachingLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_STF_SUBJECTs">
                                </asp:LinqDataSource>
                                تصميم مقرارات إلكترونية
        <br />
                                <asp:ListView ID="ListView168" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label Text='<%# Eval("level") %>' runat="server" ID="Label49" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("name") %>' runat="server" ID="Label48" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("site") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th42" runat="server">LEVEL</th>
                                                            <th id="Th43" runat="server">NAME</th>
                                                            <th id="Th44" runat="server">SITE</th>


                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                الندوات تعليمية وورش العمل المحلية والدولية التي تم حضورها
        <br />
                                <asp:ListView ID="ListView157" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_FROM"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_TO"))) %>' runat="server" ID="Label45" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SC_MEETING_NAME") %>' runat="server" ID="Label46" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("ADDRESS") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th44" runat="server">MEETING NAME</th>
                                                            <th id="Th45" runat="server">ADDRESS</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane12" ToolTip="Conferences" runat="server">
                            <Header>
                                <asp:Label ID="Label13" runat="server" Text="Conferences" meta:resourcekey="loconfLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView155" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_FROM"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_TO"))) %>' runat="server" ID="Label45" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SC_MEETING_NAME") %>' runat="server" ID="Label46" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("ADDRESS") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th44" runat="server">MEETING NAME</th>
                                                            <th id="Th45" runat="server">ADDRESS</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane13" ToolTip="Workshop" runat="server">
                            <Header>
                                <asp:Label ID="Label14" runat="server" Text="Workshop" meta:resourcekey="worksLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView156" runat="server">
                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_FROM"))) %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("DURATION_TO"))) %>' runat="server" ID="Label45" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SC_MEETING_NAME") %>' runat="server" ID="Label46" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("ADDRESS") %>' runat="server" ID="Label47" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th42" runat="server">DURATION FROM</th>
                                                            <th id="Th43" runat="server">DURATION TO</th>
                                                            <th id="Th44" runat="server">MEETING NAME</th>
                                                            <th id="Th45" runat="server">ADDRESS</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane16" ToolTip="Books" runat="server">
                            <Header>
                                <asp:Label ID="Label17" runat="server" Text="Books" meta:resourcekey="booksLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView15" runat="server" DataSourceID="LinqDataSource3" DataKeyNames="SA_BOOKS_ID">




                                    <EmptyDataTemplate>
                                        <table id="Table17" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>


                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">


                                            <td>
                                                <asp:Label Text='<%# Eval("TITLE") %>' runat="server" ID="TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("AUTHORS") %>' runat="server" ID="AUTHORSLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("PUBLISHERS") %>' runat="server" ID="PUBLISHERSLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("ISBN") %>' runat="server" ID="ISBNLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("EDITION_NUMBER") %>' runat="server" ID="EDITION_NUMBERLabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("EDITION_DESCR") %>' runat="server" ID="EDITION_DESCRLabel" /></td>

                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table18" runat="server">
                                            <tr id="Tr41" runat="server">
                                                <td id="Td28" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr42" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th9" runat="server">TITLE</th>
                                                            <th id="Th10" runat="server">AUTHORS</th>
                                                            <th id="Th47" runat="server">PUBLISHERS</th>
                                                            <th id="Th48" runat="server">ISBN</th>
                                                            <th id="Th49" runat="server">EDITION NUMBER</th>
                                                            <th id="Th50" runat="server">EDITION DESCR</th>

                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr43" runat="server">
                                                <td id="Td29" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>


                                </asp:ListView>
                                <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource3" ContextTypeName="Mis_DAL.MisDataContext" TableName="U2_SA_BOOKs"></asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane17" ToolTip="Scientific Papers" runat="server">
                            <Header>
                                <asp:Label ID="Label18" runat="server" Text="Scientific Papers" meta:resourcekey="ScLeLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                الاشراف على الرسائل العلمية
                                <br />
                                <asp:ListView ID="ListView16" runat="server">






                                    <EmptyDataTemplate>
                                        <table id="Table19" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>



                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">



                                            <td>
                                                <asp:Label Text='<%# Eval("PAPER_TITLE") %>' runat="server" ID="PAPER_TITLELabel" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("SUPERVISORS") %>' runat="server" ID="SUPERVISORSLabel" /></td>

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime(  Eval("DISCUSS_DATE"))) %>' runat="server" ID="DISCUSS_DATELabel" /></td>

                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table20" runat="server">
                                            <tr id="Tr44" runat="server">
                                                <td id="Td30" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr45" runat="server" style="background-color: #DCDCDC; color: #000000;">


                                                            <th id="Th53" runat="server">PAPER_TITLE</th>

                                                            <th id="Th55" runat="server">SUPERVISORS</th>

                                                            <th id="Th58" runat="server">DISCUSS_DATE</th>

                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr46" runat="server">
                                                <td id="Td31" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>



                                </asp:ListView>

                                مناقشة الرسائل العلمية
                                <br />
                                <asp:ListView ID="ListView17" runat="server">






                                    <EmptyDataTemplate>
                                        <table id="Table19" runat="server" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>



                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">



                                            <td>
                                                <asp:Label Text='<%# Eval("PAPER_TITLE") %>' runat="server" ID="PAPER_TITLELabel" /></td>

                                            <td>
                                                <asp:Label Text='<%# Eval("SUPERVISORS") %>' runat="server" ID="SUPERVISORSLabel" /></td>

                                            <td>
                                                <asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime(  Eval("DISCUSS_DATE"))) %>' runat="server" ID="DISCUSS_DATELabel" /></td>

                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table20" runat="server">
                                            <tr id="Tr44" runat="server">
                                                <td id="Td30" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr45" runat="server" style="background-color: #DCDCDC; color: #000000;">


                                                            <th id="Th53" runat="server">PAPER_TITLE</th>

                                                            <th id="Th55" runat="server">SUPERVISORS</th>

                                                            <th id="Th58" runat="server">DISCUSS_DATE</th>

                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr46" runat="server">
                                                <td id="Td31" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>



                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane18" ToolTip="Scientific Researches" runat="server">
                            <Header>
                                <asp:Label ID="Label19" runat="server" Text="Scientific Researches" meta:resourcekey="screLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView14" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label Text='<%# Eval("RESEARCH_TITLE") %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th42" runat="server">RESEARCH TITLE</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane19" ToolTip="Global missions" runat="server">
                            <Header>
                                <asp:Label ID="Label20" runat="server" Text="Global missions" meta:resourcekey="outLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView7" runat="server" DataKeyNames="SA_SC_MISSION_ID"
                                    DataSourceID="GlobalMissionsLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="SA_CODE_SC_TRIP_TYPE_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_SC_TRIP_TYPE.SC_TRIP_TYPE_DESCR_AR") %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="SA_CODE_ORG_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table8" runat="server">
                                            <tr id="Tr17" runat="server">
                                                <td id="Td12" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr18" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th19" runat="server">START DATE</th>
                                                            <th id="Th20" runat="server">END DATE</th>

                                                            <th id="Th21" runat="server">Mission Type</th>

                                                            <th id="Th22" runat="server">Organization</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr19" runat="server">
                                                <td id="Td13" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="GlobalMissionsLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_SC_MISSIONs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane20" ToolTip="Missions" runat="server">
                            <Header>
                                <asp:Label ID="Label21" runat="server" Text="Missions" meta:resourcekey="missLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                البعثات الخارجية
        <br />
                                <asp:ListView ID="ListView8" runat="server" DataKeyNames="SA_EXT_EXP_ID"
                                    DataSourceID="outmissLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="SA_CODE_EXT_EXP_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_EXT_EXP.EXP_TYPE_DESCR_AR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="GS_COUNTRY_NODE_IDLabel" runat="server"
                                                    Text='<%# Eval("GS_COUNTRY_NODE.NODE_DESCR_AR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="END_DATELabel" runat="server"
                                                    Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("END_DATE"))) %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table9" runat="server">
                                            <tr id="Tr20" runat="server">
                                                <td id="Td14" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr21" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th23" runat="server">Mission Type</th>

                                                            <th id="Th24" runat="server">COUNTRY</th>

                                                            <th id="Th25" runat="server">START DATE</th>

                                                            <th id="Th26" runat="server">END DATE</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr22" runat="server">
                                                <td id="Td15" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="outmissLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_EXT_EXPs">
                                </asp:LinqDataSource>

                                البعثات الداخلية
        <br />
                                <asp:ListView ID="ListView9" runat="server" DataKeyNames="SA_INT_DEL_ID"
                                    DataSourceID="IntLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="TITLE_ARLabel" runat="server" Text='<%# Eval("TITLE_AR") %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="ACT_END_DATELabel" runat="server"
                                                    Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("ACT_END_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table10" runat="server">
                                            <tr id="Tr23" runat="server">
                                                <td id="Td16" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr24" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th27" runat="server">TITLE</th>

                                                            <th id="Th28" runat="server">START DATE</th>

                                                            <th id="Th29" runat="server">END DATE</th>

                                                            <th id="Th30" runat="server">FACULTY</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr25" runat="server">
                                                <td id="Td17" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="IntLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_INT_DELs">
                                </asp:LinqDataSource>

                                بعثات الاشراف المشترك
        <br />
                                <asp:ListView ID="ListView10" runat="server"
                                    DataKeyNames="SA_JOINT_SUPERVISION_ID" DataSourceID="CommLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">

                                            <td>
                                                <asp:Label ID="THESIS_TOPIC_ARLabel" runat="server"
                                                    Text='<%# Eval("THESIS_TOPIC_AR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server"
                                                    Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table11" runat="server">
                                            <tr id="Tr26" runat="server">
                                                <td id="Td18" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr27" runat="server" style="background-color: #DCDCDC; color: #000000;">

                                                            <th id="Th31" runat="server">THESIS TOPIC AR</th>
                                                            <th id="Th32" runat="server">START DATE</th>
                                                            <th id="Th33" runat="server">END DATE</th>

                                                            <th id="Th34" runat="server">FACULTY</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr28" runat="server">
                                                <td id="Td19" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="CommLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_JOINT_SUPERVISIONs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane21" ToolTip="Travels" runat="server">
                            <Header>
                                <asp:Label ID="Label22" runat="server" Text="Travels" meta:resourcekey="TravelsLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView13" runat="server" DataKeyNames="SA_SECONDMENT_ID"
                                    DataSourceID="VISITSLinqDataSource">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label ID="SA_CODE_SECONDMENT_TYPELabel" runat="server"
                                                    Text='<%# Staff_Utility.GET_SEC_TYPE(Eval("SA_STF_MEMBER_ID")) %>' />
                                            </td>

                                            <td>
                                                <asp:Label ID="SA_CODE_ORG_IDLabel" runat="server"
                                                    Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="START_DATELabel" runat="server"
                                                    Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="END_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("END_DATE"))) %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table14" runat="server">
                                            <tr id="Tr35" runat="server">
                                                <td id="Td24" runat="server">
                                                    <table id="itemPlaceholderContainer" runat="server" border="1"
                                                        style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr id="Tr36" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th411" runat="server">SECONDMENT TYPE</th>
                                                            <th id="Th421" runat="server">ORG</th>
                                                            <th id="Th40" runat="server">START DATE</th>
                                                            <th id="Th41" runat="server">END DATE</th>
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr37" runat="server">
                                                <td id="Td25" runat="server"
                                                    style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                                <asp:LinqDataSource ID="VISITSLinqDataSource" runat="server"
                                    ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName=""
                                    TableName="SA_SECONDMENTs">
                                </asp:LinqDataSource>
                            </Content>
                        </ajaxtk:AccordionPane>

                        <ajaxtk:AccordionPane ID="AccordionPane22" ToolTip="Social Services" runat="server">
                            <Header>
                                <asp:Label ID="Label3" runat="server" Text="Social Services" meta:resourcekey="socserLabelResource1"></asp:Label>
                            </Header>
                            <Content>
                                <asp:ListView ID="ListView152" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label Text='<%# Eval("ACTIVITY_DESCR_AR") %>' runat="server" ID="Label50" /></td>
                                            <td>
                                                <asp:Label Text='<%# Eval("PLACE") %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
                                            <td>
                                                <asp:Label Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("FROM_DATE"))) %>' runat="server" ID="Label48" /></td>
                                            <td>
                                                <asp:Label Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("TO_DATE"))) %>' runat="server" ID="Label49" /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table id="Table15" runat="server">
                                            <tr id="Tr38" runat="server">
                                                <td id="Td26" runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" style="border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                                        <tr id="Tr39" runat="server" style="background-color: #DCDCDC; color: #000000;">
                                                            <th id="Th47" runat="server">ACTIVITY</th>
                                                            <th id="Th42" runat="server">PLACE</th>
                                                            <th id="Th9" runat="server">FROM DATE</th>
                                                            <th id="Th10" runat="server">TO DATE</th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="Tr40" runat="server">
                                                <td id="Td27" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>
                            </Content>
                        </ajaxtk:AccordionPane>
                    </Panes>
                </ajaxtk:Accordion>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
 