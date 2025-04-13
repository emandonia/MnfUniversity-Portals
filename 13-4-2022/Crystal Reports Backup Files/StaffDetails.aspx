<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/StaffMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.StaffDetails" CodeBehind="StaffDetails.aspx.cs" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MisBLL" %>

<asp:Content ID="Content2" ContentPlaceHolderID="meta" runat="Server">

    <meta http-equiv="Content-Type" content="الموقع الشخصي لأعضاء هيئة التدريس بجامعة المنوفية , menofia university staff Website" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="Server">
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>اعضاء هيئة التدريس</title><link href="css/bootstrap.min.css">');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
     
<script>(function (d, e, j, h, f, c, b) { d.GoogleAnalyticsObject = f; d[f] = d[f] || function () { (d[f].q = d[f].q || []).push(arguments) }, d[f].l = 1 * new Date(); c = e.createElement(j), b = e.getElementsByTagName(j)[0]; c.async = 1; c.src = h; b.parentNode.insertBefore(c, b) })(window, document, "script", "//www.google-analytics.com/analytics.js", "ga"); ga("create", "UA-57986194-1", "auto"); ga("send", "pageview");</script>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<div style="float:<%=StaticUtilities.FloatLeft%>">
<asp:FormView ID="OwnerImageFormView" runat="server" align="center" DataSourceID="DummyDataSource">
<ItemTemplate>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<Triggers>
<asp:PostBackTrigger ControlID="AsyncFileUpload1" />
<asp:PostBackTrigger ControlID="Button1" />
</Triggers>
<ContentTemplate>
<div class="staff_image" style="float:<%=StaticUtilities.FloatLeft%>">
<img id="Img1" alt="Image" runat="server" width="120" height="120" src='<%#GetImageUrl(Page)%>' />
</div><br/>
<ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" Visible='<%#checkUser() %>' runat="server" PersistFile="True" PersistedStoreType="Session" Width="70px"></ajaxtk:AsyncFileUpload><br/>
<asp:Button ID="Button1" Visible='<%#checkUser() %>' runat="server" Text="Update Image" OnClick="UpdateImage" />
</ContentTemplate></asp:UpdatePanel>
</ItemTemplate>
</asp:FormView>



</div>
<div class="body_center_staff" runat="server" ID="MyDiv">
<asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod" TypeName="StaticUtilities"></asp:ObjectDataSource>
<div style="font-weight:bold">
<asp:HiddenField ID="MisId" runat="server" />
<ajaxtk:Accordion ID="Accordion1" CssClass="accordion" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" runat="server">
<Panes>
<ajaxtk:AccordionPane ID="AccordionPane1" ToolTip="Personal Data" runat="server">
<Header>
<asp:Label ID="Label1" runat="server" Text="Personal Data" meta:resourcekey="PdLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="SA_STF_MEMBER_ID" DataSourceID="LinqDataSource1">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
</EmptyDataTemplate>
<ItemTemplate>
<tr><td></td>
<td>
<asp:Label ID="Label23" runat="server" Text="الاسم الاول:" meta:resourcekey="FN"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp; <asp:Label ID="STF_FULL_NAME_ARLabel" runat="server" Text='<%#GetStaffFname(Eval("SA_STF_MEMBER_ID")) %>' /></td>
</tr>
<tr><td></td>
<td>
<asp:Label ID="Label24" runat="server" Text="اسم العائلة:" meta:resourcekey="FUN"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp; <asp:Label ID="STF_FULL_NAME_ENLabel" runat="server" Text='<%# GetStaffFuname(Eval("SA_STF_MEMBER_ID")) %>' />
</td>
</tr>
<tr><td></td>
<td>
<asp:Label ID="Label31" runat="server" Text="التخصص العام:" meta:resourcekey="GS"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp;<asp:Label ID="PG_THESIS_GENERAL_SPEC_IDLabel" runat="server" Text='<%#GetStaffGSPECS( Eval("SA_STF_MEMBER_ID")) %>' />
</td>
</tr>
<tr><td></td>
<td>
<asp:Label ID="Label32" runat="server" Text="التخصص الدقيق:" meta:resourcekey="DS"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp;<asp:Label ID="PG_THESIS_DETAILED_SPEC_IDLabel" runat="server" Text='<%#GetStaffDSPECS (Eval("SA_STF_MEMBER_ID")) %>' />
</td>
</tr>
<tr><td></td>
<td>
<asp:Label ID="Label25" runat="server" Text="الوظيفة الحالية:" meta:resourcekey="CJ"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp; <asp:Label ID="Label44" runat="server" Text='<%# GetCJob(Eval("SA_STF_MEMBER_ID")) %>' />
</td>
</tr>
<tr>
<td>
<asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="addresschecked" Checked='<%# GetAdressPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>' />
</td>
<td>
<asp:Label ID="Label30" runat="server" Visible='<%#checkAdress() %>' Text="العنوان:" meta:resourcekey="Add"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label43" Visible='<%#checkAdress() %>' runat="server" Text='<%# Eval("STF_CURR_ADD") %>' />
</td>
</tr>
<tr><td>
<asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="Emailchecked" Checked='<%# GetEmailPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>' />
</td>
<td>
<asp:Label ID="Label35" runat="server" Visible='<%#checkEmail() %>' Text="البريد الالكتروني:" meta:resourcekey="Em"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label36" Visible='<%#checkEmail() %>' runat="server" Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),2) %>' />
</td>
</tr>
<tr><td>
<asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="Telchecked" Checked='<%# GetTelPublished(URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' Visible='<%#checkUser() %>' />
</td>
<td>
<asp:Label ID="Label37" runat="server" Visible='<%#checkTel() %>' Text="الهاتف المحمول:" meta:resourcekey="Ph"></asp:Label>
</td>
<td>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label38" Visible='<%#checkTel() %>' runat="server" Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),5) %>' />
</td>
</tr>
<tr>
<td colspan="2" style="float:<%=StaticUtilities.FloatLeft%>">
<asp:Button ID="Button5" runat="server" class="btn" Text="Update_Info" Visible='<%#checkUser() %>' OnClick="UpdateInfo" />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table2" runat="server" style="direction:<%=StaticUtilities.Dir%>;width:100%">
<tr id="Tr1" runat="server">
<td id="Td1" runat="server">
<table id="Table1" runat="server" border="0">
<tr id="itemPlaceholder" runat="server">
</tr>
</table>
</td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_STF_MEMBERs">
</asp:LinqDataSource>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane2" ToolTip="Scientific Degree" runat="server">
<Header>
<asp:Label ID="Label2" runat="server" Text="Scientific Degree" meta:resourcekey="sdLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView2" runat="server" DataKeyNames="SA_SC_QUAL_ID" DataSourceID="SciDegreeLinqDataSource">
<EmptyDataTemplate>
<table id="Table5" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="SC_DEG_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime(Eval("SC_DEG_DATE")) )  %>' />
</td>
<td>
<asp:Label ID="GS_COUNTRY_NODE_IDLabel" runat="server" Text='<%# Eval("GS_COUNTRY_NODE.NODE_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="AS_CODE_DEGREE_IDLabel" runat="server" Text='<%# Eval("AS_CODE_DEGREE.DEGREE_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="AS_NODE_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table3" runat="server">
<tr id="Tr2" runat="server">
<td id="Td2" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr3" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td3" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="SciDegreeLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_SC_QUALs">
</asp:LinqDataSource>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane3" ToolTip="Position" runat="server">
<Header>
<asp:Label ID="Label4" runat="server" Text="Position" meta:resourcekey="poLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView3" runat="server" DataKeyNames="SA_EMP_HIERARCHY_ID" DataSourceID="posLinqDataSource">
<EmptyDataTemplate>
<table id="Table5" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="FROM_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("FROM_DATE"))) %>' />
</td>
<td>
<asp:Label ID="TO_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("TO_DATE"))) %>' />
</td>
<td>
<asp:Label ID="SA_CODE_SC_DEG_IDLabel" runat="server" Text='<%# Eval("SA_CODE_SC_DEG.SC_DEG_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table4" runat="server">
<tr id="Tr5" runat="server">
<td id="Td4" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr6" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td5" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="posLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_EMP_HIERARCHies">
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
<table id="Table5" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<table id="Table5" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr9" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td7" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<table id="Table17" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<asp:ListView ID="ListView5" runat="server" DataKeyNames="SA_SUPERVISING_JOBS_ID" DataSourceID="AdminLinqDataSource">
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
</td>
<td>
<asp:Label ID="SA_CODE_SUPERVISE_JOB_IDLabel" runat="server" Text='<%# Eval("SA_CODE_SUPERVISE_JOB.JOB_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
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
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr12" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td9" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="AdminLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_SUPERVISING_JOBs">
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
<table id="Table17" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<asp:ListView ID="ListView6" runat="server" DataKeyNames="SA_STF_PRIZE_ID" DataSourceID="prizeLinqDataSource">
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="PRIZE_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("PRIZE_DATE"))) %>' />
</td>
<td>
<asp:Label ID="SA_CODE_PRIZE_IDLabel" runat="server" Text='<%# Eval("SA_CODE_PRIZE.PRIZE_DESCR") %>' />
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
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr15" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th17" runat="server">PRIZE_DATE</th>
<th id="Th18" runat="server">SA_CODE_PRIZE_ID</th>
</tr>
<tr id="itemPlaceholder" runat="server">
</tr>
</table>
</td>
</tr>
<tr id="Tr16" runat="server">
<td id="Td11" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="prizeLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_STF_PRIZEs">
</asp:LinqDataSource>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane10" ToolTip="Visitor" runat="server">
<Header>
<asp:Label ID="Label11" runat="server" Text="Visitor" meta:resourcekey="visitorLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView12" runat="server" DataKeyNames="SA_PAR_DEL_ID" DataSourceID="visitLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="SA_CODE_ORG_IDLabel" runat="server" Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
</td>
<td>
<asp:Label ID="ACT_START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("ACT_START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="ACT_END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("ACT_END_DATE"))) %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table13" runat="server">
<tr id="Tr32" runat="server">
<td id="Td22" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr33" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td23" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="visitLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_PAR_DELs">
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
<asp:ListView ID="ListView11" runat="server" DataKeyNames="SA_STF_SUBJECT_ID" DataSourceID="teachingLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="ED_CODE_SUBJECT_IDLabel" runat="server" Text='<%# Eval("ED_CODE_SUBJECT.SUBJECT_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table12" runat="server">
<tr id="Tr29" runat="server">
<td id="Td20" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr30" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th35" runat="server">SUBJECT</th>
<th id="Th36" runat="server">FACULTY</th>
</tr>
<tr id="itemPlaceholder" runat="server">
</tr>
</table>
</td>
</tr>
<tr id="Tr31" runat="server">
<td id="Td21" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="teachingLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_STF_SUBJECTs">
</asp:LinqDataSource>
تصميم مقرارات إلكترونية
<br />
<asp:ListView ID="ListView168" runat="server">
<EmptyDataTemplate>
<table id="Table17" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th42" runat="server">LEVEL</th>
<th id="Th43" runat="server">NAME</th>
<th id="Th44" runat="server">SITE</th>
</tr>
<tr runat="server" id="itemPlaceholder"></tr>
</table>
</td>
</tr>
<tr id="Tr40" runat="server">
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
الندوات تعليمية وورش العمل المحلية والدولية التي تم حضورها
<br />
<asp:ListView ID="ListView157" runat="server">
<EmptyDataTemplate>
<table id="Table17" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<%-- <asp:ListView ID="ListView156" runat="server">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>--%>
<asp:ListView ID="ListView18" DataSourceID="LinqDataSource5" DataKeyNames="SA_TRAINING_COURSE_ID" runat="server">
<EmptyDataTemplate>
<table runat="server" style="">
<tr>
<td>No data was returned.</td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="">
<td>
<asp:Label Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime( Eval("START_DATE"))) %>' runat="server" ID="START_DATELabel" /></td>
<td>
<asp:Label Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime(  Eval("END_DATE"))) %>' runat="server" ID="END_DATELabel" /></td>
<td>
<asp:Label Text='<%# Eval("COURSE_COST") %>' runat="server" ID="COURSE_COSTLabel" /></td>
<td>
<asp:Label Text='<%# Eval("COURSE_HRS") %>' runat="server" ID="COURSE_HRSLabel" /></td>
<td>
<asp:Label Text='<%# Eval("TRAINING_PLACE") %>' runat="server" ID="TRAINING_PLACELabel" /></td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table runat="server">
<tr runat="server">
<td runat="server">
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr runat="server" style="">
<th runat="server">START_DATE</th>
<th runat="server">END_DATE</th>
<th runat="server">COURSE_COST</th>
<th runat="server">COURSE_HRS</th>
<th runat="server">TRAINING_PLACE</th>
</tr>
<tr runat="server" id="itemPlaceholder"></tr>
</table>
</td>
</tr>
<tr runat="server">
<td runat="server" style=""></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource5" ContextTypeName="Mis_DAL.MisDataContext" TableName="SA_TRAINING_COURSEs"></asp:LinqDataSource>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane16" ToolTip="Books" runat="server">
<Header>
<asp:Label ID="Label17" runat="server" Text="Books" meta:resourcekey="booksLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView15" runat="server" DataSourceID="LinqDataSource3" DataKeyNames="SA_BOOKS_ID">
<EmptyDataTemplate>
<table id="Table17" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr42" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td29" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<table id="Table19" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr45" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th53" runat="server">PAPER_TITLE</th>
<th id="Th55" runat="server">SUPERVISORS</th>
<th id="Th58" runat="server">DISCUSS_DATE</th>
</tr>
<tr runat="server" id="itemPlaceholder"></tr>
</table>
</td>
</tr>
<tr id="Tr46" runat="server">
<td id="Td31" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
مناقشة الرسائل العلمية
<br />
<asp:ListView ID="ListView17" runat="server">
<EmptyDataTemplate>
<table id="Table19" runat="server" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px">
<tr>
<td>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /></td>
</tr>
</table>
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr45" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th53" runat="server">PAPER_TITLE</th>
<th id="Th55" runat="server">SUPERVISORS</th>
<th id="Th58" runat="server">DISCUSS_DATE</th>
</tr>
<tr runat="server" id="itemPlaceholder"></tr>
</table>
</td>
</tr>
<tr id="Tr46" runat="server">
<td id="Td31" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
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
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label Text='<%# Eval("RESEARCH_TITLE") %>' runat="server" ID="RESEARCH_TITLELabel" /></td>
<td>
<asp:LinkButton ID="linkbutton1" Text="المزيد" CommandArgument='<%# Eval("SA_SC_RESEARCH_ID") %>' meta:resourcekey="more" OnClick="Editor_ImageButton_Click" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"> </asp:LinkButton></td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table15" runat="server" style="direction:ltr;width:100%">
<tr id="Tr38" runat="server">
<td id="Td26" runat="server">
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
<th id="Th42" runat="server">RESEARCH TITLE</th>
<th id="Th51" runat="server">RESEARCH Details</th>
</tr>
<tr runat="server" id="itemPlaceholder"></tr>
</table>
</td>
</tr>
<tr id="Tr40" runat="server">
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:ImageButton ID="Dummy" runat="server" Style="display:none" />
<ajaxtk:ModalPopupExtender ID="Editor_ModalPopupExtender" runat="server" Enabled="true" TargetControlID="Dummy" PopupControlID="Editor_Panel" PopupDragHandleControlID="Editor_HandelPanel" BackgroundCssClass="modalBackground" RepositionMode="None" />
<asp:Panel ID="Editor_Panel" runat="server" Style="display:none" CssClass="modalPopup">
<asp:Panel ID="Editor_HandelPanel" CssClass="Handel_Panel" runat="server">
<div style="float:<%=StaticUtilities.FloatRight%>" class="Handel_Label">
<asp:Localize ID="EditorTitleLocalize" runat="server" Text=""></asp:Localize>
</div>
<div style="float:<%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
<div style="float:<%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
<div style="float:<%=StaticUtilities.FloatRight%>">
<asp:ImageButton ID="MaximizeImageButton" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
<asp:ImageButton ID="RestoreImageButton" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display:none" OnClientClick="maximize_restore(this);return false;" />
</div>
<div style="float:<%=StaticUtilities.FloatLeft%>">
<asp:ImageButton ID="CancelEditorImageButton" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
</div>
</div>
</div>
</asp:Panel>
<asp:DetailsView ID="Editor_DetailsView1" CssClass="Editor_DetailsView" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" GridLines="None" EmptyDataText="No Data" DataKeyNames="SA_SC_RESEARCH_ID" DataSourceID="LinqDataSource4">
<Fields>
</Fields>
<AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
<CommandRowStyle CssClass="Editor_CommandRowStyle" />
<EditRowStyle CssClass="Editor_EditRowStyle" />
<FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
<Fields>
<asp:BoundField DataField="RESEARCH_SUMM_AR" HeaderText="RESEARCH_SUMM_AR" meta:resourcekey="sum" SortExpression="RESEARCH_SUMM_AR"></asp:BoundField>
<asp:BoundField DataField="RESEARCH_TITLE" HeaderText="RESEARCH_TITLE" meta:resourcekey="title" SortExpression="RESEARCH_TITLE"></asp:BoundField>
<asp:BoundField DataField="APPROVAL_DATE" HeaderText="APPROVAL_DATE" meta:resourcekey="appdate" SortExpression="APPROVAL_DATE"></asp:BoundField>
<asp:BoundField DataField="PAGES_NUM" HeaderText="PAGES_NUM" meta:resourcekey="pnum" SortExpression="PAGES_NUM"></asp:BoundField>
</Fields>
<FooterStyle CssClass="Editor_FooterStyle" />
<HeaderStyle CssClass="Editor_HeaderStyle" />
<PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
<RowStyle CssClass="Editor_RowStyle" />
</asp:DetailsView>
<asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource4" ContextTypeName="Mis_DAL.MisDataContext" TableName="SA_SC_RESEARCHes"></asp:LinqDataSource>
</asp:Panel>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane19" ToolTip="Global missions" runat="server">
<Header>
<asp:Label ID="Label20" runat="server" Text="Global missions" meta:resourcekey="outLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView7" runat="server" DataKeyNames="SA_SC_MISSION_ID" DataSourceID="GlobalMissionsLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
</td>
<td>
<asp:Label ID="SA_CODE_SC_TRIP_TYPE_IDLabel" runat="server" Text='<%# Eval("SA_CODE_SC_TRIP_TYPE.SC_TRIP_TYPE_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="SA_CODE_ORG_IDLabel" runat="server" Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table8" runat="server">
<tr id="Tr17" runat="server">
<td id="Td12" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr18" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td13" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="GlobalMissionsLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_SC_MISSIONs">
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
<asp:ListView ID="ListView8" runat="server" DataKeyNames="SA_EXT_EXP_ID" DataSourceID="outmissLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="SA_CODE_EXT_EXP_IDLabel" runat="server" Text='<%# Eval("SA_CODE_EXT_EXP.EXP_TYPE_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="GS_COUNTRY_NODE_IDLabel" runat="server" Text='<%# Eval("GS_COUNTRY_NODE.NODE_DESCR_AR") %>' />
</td>
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="END_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("END_DATE"))) %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table9" runat="server">
<tr id="Tr20" runat="server">
<td id="Td14" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr21" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td15" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="outmissLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_EXT_EXPs">
</asp:LinqDataSource>
البعثات الداخلية
<br />
<asp:ListView ID="ListView9" runat="server" DataKeyNames="SA_INT_DEL_ID" DataSourceID="IntLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="TITLE_ARLabel" runat="server" Text='<%# Eval("TITLE_AR") %>' />
</td>
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="ACT_END_DATELabel" runat="server" Text='<%#StaticUtilities.FormatDate(Convert.ToDateTime( Eval("ACT_END_DATE"))) %>' />
</td>
<td>
<asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table10" runat="server">
<tr id="Tr23" runat="server">
<td id="Td16" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr24" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td17" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="IntLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_INT_DELs">
</asp:LinqDataSource>
بعثات الاشراف المشترك
<br />
<asp:ListView ID="ListView10" runat="server" DataKeyNames="SA_JOINT_SUPERVISION_ID" DataSourceID="CommLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." /><br />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="THESIS_TOPIC_ARLabel" runat="server" Text='<%# Eval("THESIS_TOPIC_AR") %>' />
</td>
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
</td>
<td>
<asp:Label ID="END_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("END_DATE"))) %>' />
</td>
<td>
<asp:Label ID="AS_FACULTY_INFO_IDLabel" runat="server" Text='<%# Eval("AS_FACULTY_INFO.FACULTY_DESCR_AR") %>' />
</td>
</tr>
</ItemTemplate>
<LayoutTemplate>
<table id="Table11" runat="server">
<tr id="Tr26" runat="server">
<td id="Td18" runat="server">
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr27" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td19" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="CommLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_JOINT_SUPERVISIONs">
</asp:LinqDataSource>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane21" ToolTip="Travels" runat="server">
<Header>
<asp:Label ID="Label22" runat="server" Text="Travels" meta:resourcekey="TravelsLabelResource1"></asp:Label>
</Header>
<Content>
<asp:ListView ID="ListView13" runat="server" DataKeyNames="SA_SECONDMENT_ID" DataSourceID="VISITSLinqDataSource">
<EmptyDataTemplate>
<asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
</EmptyDataTemplate>
<ItemTemplate>
<tr style="background-color:#dcdcdc;color:#000">
<td>
<asp:Label ID="SA_CODE_SECONDMENT_TYPELabel" runat="server" Text='<%# Staff_Utility.GET_SEC_TYPE(Eval("SA_STF_MEMBER_ID")) %>' />
</td>
<td>
<asp:Label ID="SA_CODE_ORG_IDLabel" runat="server" Text='<%# Eval("SA_CODE_ORG.ORG_DESCR") %>' />
</td>
<td>
<asp:Label ID="START_DATELabel" runat="server" Text='<%# StaticUtilities.FormatDate(Convert.ToDateTime(Eval("START_DATE"))) %>' />
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
<table id="itemPlaceholderContainer" runat="server" border="1" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif">
<tr id="Tr36" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td25" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
<asp:LinqDataSource ID="VISITSLinqDataSource" runat="server" ContextTypeName="Mis_DAL.MisDataContext" EntityTypeName="" TableName="SA_SECONDMENTs">
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
<tr style="background-color:#dcdcdc;color:#000">
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
<table runat="server" id="itemPlaceholderContainer" style="border-collapse:collapse;border-color:#999;border-style:none;border-width:1px;font-family:Verdana,Arial,Helvetica,sans-serif" border="1">
<tr id="Tr39" runat="server" style="background-color:#dcdcdc;color:#000">
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
<td id="Td27" runat="server" style="text-align:center;background-color:#ccc;font-family:Verdana,Arial,Helvetica,sans-serif;color:#000"></td>
</tr>
</table>
</LayoutTemplate>
</asp:ListView>
</Content>
</ajaxtk:AccordionPane>
<ajaxtk:AccordionPane ID="AccordionPane14" ToolTip="Research Fields" runat="server">
<Header>
<asp:Label ID="Label15" runat="server" Text="Research Fields" meta:resourcekey="ResFLabelResource1"></asp:Label>
</Header>
<Content>
<Table ID="Table1" runat="server">
<tr>
<td style="padding-right:30px">
<ul>
<div runat="server" id="link">
</div>
</ul>
</td>
</tr><tr>
<td>
<asp:Label ID="Label33" runat="server" Text="لتعديل المجالات البحثية برجاء تسجيل الدخول اولا."></asp:Label>
</td>
<td>
<asp:Label ID="ResLabel" Height="150px" Width="150px" runat="server"></asp:Label>
<asp:FormView ID="FormView1" runat="server" align="center" DataSourceID="DummyDataSource">
<ItemTemplate>
<asp:LinkButton Visible='<%#checkuserr() %>' ValidationGroup="InsertValidation" OnClick="UpdateClicked" ID="InsertLinkButton" ToolTip="Update" runat="server" AlternateText="Update" Font-Size="Large" ForeColor="Blue">
<asp:Label ID="Label26" runat="server" Text="Update\Delete" Font-Size="Large" ForeColor="Blue"></asp:Label>
</asp:LinkButton> </ItemTemplate>
</asp:FormView> </td>
</tr>
<tr><td>
<asp:Label ID="Label29" runat="server" ForeColor="Red"></asp:Label></td></tr>
</Table>
<asp:ImageButton ID="Dummy2" runat="server" Style="display:none" />
<ajaxtk:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Enabled="true" TargetControlID="Dummy2" PopupControlID="Panel1" PopupDragHandleControlID="Panel2" BackgroundCssClass="modalBackground" RepositionMode="None" />
<asp:Panel ID="Panel1" runat="server" Style="display:none" CssClass="modalPopup">
<asp:Panel ID="Panel2" CssClass="Handel_Panel" runat="server">
<div style="float:<%=StaticUtilities.FloatRight%>" class="Handel_Label">
<asp:Localize ID="Localize1" runat="server" Text=""></asp:Localize>
</div>
<div style="float:<%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
<div style="float:<%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
<div style="float:<%=StaticUtilities.FloatRight%>">
<asp:ImageButton ID="ImageButton2" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
<asp:ImageButton ID="ImageButton3" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display:none" OnClientClick="maximize_restore(this);return false;" />
</div>
<div style="float:<%=StaticUtilities.FloatLeft%>">
<asp:ImageButton ID="ImageButton4" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
</div>
</div>
</div>
</asp:Panel>
<asp:DetailsView ID="DetailsView1" CssClass="Editor_DetailsView" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" GridLines="None" EmptyDataText="No Data">
<Fields>
<asp:TemplateField HeaderText="Research Fields:">
<InsertItemTemplate>
<asp:TextBox ID="TextBox1" Width="250px" Height="250px" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label28" runat="server" ForeColor="Red"></asp:Label>
</br>
<asp:Label ID="Label27" runat="server" ForeColor="Red" Text="برجاء وضع علامة (,) بين كل مجال من المجالات وعدم زيادة المجالات عن 7  وشكرا"></asp:Label>
</InsertItemTemplate>
</asp:TemplateField>
</Fields>
<FooterTemplate>
<asp:LinkButton ID="LinkButton1" Text="Update" OnClick="UpdateButtonClicked" runat="server"></asp:LinkButton>
&nbsp;&nbsp;
<asp:LinkButton ID="LinkButton2" Text="Delete" OnClick="DeleteButtonClicked" runat="server"></asp:LinkButton>
</FooterTemplate>
<AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
<CommandRowStyle CssClass="Editor_CommandRowStyle" />
<EditRowStyle CssClass="Editor_EditRowStyle" />
<FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
<FooterStyle CssClass="Editor_FooterStyle" />
<HeaderStyle CssClass="Editor_HeaderStyle" />
<PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
<RowStyle CssClass="Editor_RowStyle" />
</asp:DetailsView>
</asp:Panel>
</Content>
</ajaxtk:AccordionPane>




    <ajaxtk:AccordionPane ID="AccordionPane15" ToolTip="SentificResearches" runat="server">
<Header>
<asp:Label ID="Label16" runat="server" Text="قائمة الابحاث العلمية" meta:resourcekey="ResFLabelResource1"></asp:Label>
</Header>
<Content> 
    <asp:Panel ID="pnlContents" runat="server">  
    <table><tr><td> <%--<asp:Image ID="Image1" runat="server"  ImageUrl='<%#URLBuilder.BannerURL(Page)%>' />--%>
        <img src="/Styles/University_Master/images/staff_ar2.png" />
               </td></tr>
        <tr><td> <asp:Button ID="btnPrint" CssClass="btn btn-primary" runat="server" Text="طباعة جدول الابحاث العلمية" OnClientClick = "return PrintPanel();" />
 </td></tr>
        <tr><td>  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataKeyNames="sa_sc_research_id" GridLines="None" Height="100%" Width="100%" PageSize="100">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="RESEARCH_TITLE" ControlStyle-CssClass="row2" HeaderText="عنوان البحث" SortExpression="RESEARCH_TITLE" />
                            <%--<asp:BoundField DataField="RESEARCH_TITLEEN1" ControlStyle-CssClass="row2" HeaderText="عنوان البحث انجليزى" SortExpression="RESEARCH_TITLEEN1" />--%>
                            <asp:BoundField DataField="RESEARCH_SUMM_AR" ControlStyle-CssClass="row2" HeaderText="ملخص البحث" SortExpression="RESEARCH_SUMM_AR" />
                            <%--<asp:BoundField DataField="Exercises" ControlStyle-CssClass="row2" HeaderText="مدة التمارين" SortExpression="Exercises" />
                            <asp:BoundField DataField="Lectures" ControlStyle-CssClass="row2" HeaderText="مدة المحاضرة" SortExpression="Lec"  />
                            <asp:BoundField DataField="NameEn" ControlStyle-CssClass="row2" HeaderText="Course Title" SortExpression="NameEn" />
                            <asp:BoundField DataField="codeEn" ControlStyle-CssClass="row2" HeaderText="Code" SortExpression="codeEn" />--%>
              </Columns>
                        <EditRowStyle BackColor="#4a8abb" />
                        <FooterStyle BackColor="#59c4b2" CssClass="btn3" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#59c4b2" CssClass="col5" Height="40" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" CssClass="row1" Height="40" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" Height="40" CssClass="row1" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView></td></tr>
        <tr><td></td></tr>
    </table>
  
   </asp:Panel>
       
                   <%-- <asp:LinqDataSource ID="LinqDataSource6" runat="server" ContextTypeName="WebApplication1.DataClasses1DataContext"
                        EntityTypeName="" TableName="Cources">
                    </asp:LinqDataSource>--%> 

     <%--   <table id="vvv">
        <tr>
            <td>

                   <asp:ListView ID="ListView19" runat="server" DataKeyNames="ID"     >
        <AlternatingItemTemplate>
            <li style="background-color: #FFFFFF; color: #284775;"> 
             
                              <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
                 ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
            
                </li>
        </AlternatingItemTemplate>   
        <EditItemTemplate>
            <li style="background-color: #999999;"><%--ID:
                 AuthorName:
                <asp:TextBox Text='<%# Bind("AuthorName") %>' runat="server" ID="AuthorNameTextBox" /><br />
                Co_Authors:
                <asp:TextBox Text='<%# Bind("Co_Authors") %>' runat="server" ID="Co_AuthorsTextBox" /><br />
                Title:
                <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBox" /><br />
                Journal:
                <asp:TextBox Text='<%# Bind("Journal") %>' runat="server" ID="JournalTextBox" /><br />
                Volume:
                <asp:TextBox Text='<%# Bind("Volume") %>' runat="server" ID="VolumeTextBox" /><br />
                Number:
                <asp:TextBox Text='<%# Bind("Number") %>' runat="server" ID="NumberTextBox" /><br />
                pageNum:
                <asp:TextBox Text='<%# Bind("pageNum") %>' runat="server" ID="pageNumTextBox" /><br />
                Year:
                <asp:TextBox Text='<%# Bind("Year") %>' runat="server" ID="YearTextBox" /><br />
                Files:
                <asp:TextBox Text='<%# Bind("Files") %>' runat="server" ID="FilesTextBox" /><br />
                       <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" /><asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" /></li>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <li style="">
                   <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>
                 
              <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
              ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
            
         
                <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" /><asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
            </li>
        </InsertItemTemplate>
        <ItemSeparatorTemplate>
            <br />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <li style="background-color: #E0FFFF; color: #333333;">
              
                     <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>
                 
             <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True" />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
              ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
                </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul runat="server" id="itemPlaceholderContainer" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                <li runat="server" id="itemPlaceholder" />
            </ul>
            <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                <asp:DataPager runat="server" ID="DataPager1">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                    </Fields>
                </asp:DataPager>

            </div>

        </LayoutTemplate>
        <SelectedItemTemplate>
            <li style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        
                    <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>
                 
                  <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
                 ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
                
            </li>
        </SelectedItemTemplate>
      
    </asp:ListView>


    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource19" ContextTypeName="Portal_DAL.PortalDataContextDataContext" 
        TableName="Prtl_SecntificResearches" OrderBy="ID desc"></asp:LinqDataSource>

            </td>
        </tr>

    </table>--%>





</Content>
</ajaxtk:AccordionPane>

 
</Panes>
</ajaxtk:Accordion>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
          
</asp:Content>