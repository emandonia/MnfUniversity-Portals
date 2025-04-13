<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.master" AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.StaffHome" CodeBehind="StaffHome.aspx.cs" %>

<%@ Import Namespace="MisBLL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="SA_STF_MEMBER_ID"
        DataSourceID="LinqDataSource1">

        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="الاسم الاول"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="STF_FULL_NAME_ARLabel" runat="server"
                        Text='<%# Eval("STF_NAME_AR") %>' /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label24" runat="server" Text="اسم العائلة"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="STF_FULL_NAME_ENLabel" runat="server"
                        Text='<%# Eval("STF_LNAME_AR") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="تاريخ الميلاد"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="STF_DOBLabel" runat="server" Text='<%# Eval("STF_DOB") %>' /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="الحالة الاجتماعية"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="GS_CODE_MARITAL_STATE_IDLabel" runat="server"
                        Text='<%# Eval("GS_CODE_MARITAL_STATE.STATE_DESCR_AR") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="الجنسية"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="GS_COUNTRY_INFO_IDLabel" runat="server"
                        Text='<%# Eval("GS_COUNTRY_INFO.NATIONALITY_DESCR_AR") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label27" runat="server" Text="الديانة"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="GS_CODE_RELIGION_IDLabel" runat="server"
                        Text='<%# Eval("GS_CODE_RELIGION.RELIGION_DESCR_AR") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label31" runat="server" Text="التخصص العام"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="PG_THESIS_GENERAL_SPEC_IDLabel" runat="server"
                        Text='<%# Eval("PG_THESIS_GENERAL_SPEC.GENERAL_SPEC_DESCR_AR") %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label32" runat="server" Text="التخصص الدقيق"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="PG_THESIS_DETAILED_SPEC_IDLabel" runat="server"
                        Text='<%# Eval("PG_THESIS_DETAILED_SPEC.DETAILED_SPEC_DESC_AR") %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="الوظيفة الحالية"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label44" runat="server"
                        Text='<%# Eval("SA_CODE_JOB_STATUS.JOB_STATUS_DESCR") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="العنوان"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label43" runat="server"
                        Text='<%# Eval("STF_CURR_ADD") %>' />
                </td>
            </tr>

            <%--<tr> <td>
                    <asp:Label ID="Label25" runat="server" Text="الرقم القومي"></asp:Label> </td>
                    <td>
                    <asp:Label ID="STF_NATIONAL_ID_NUMLabel" runat="server"
                        Text='<%# Eval("STF_NATIONAL_ID_NUM") %>' /></td></tr>--%>

            <tr>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="تليفون المنزل"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label34" runat="server"
                        Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),8) %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label35" runat="server" Text="البريد الالكتروني"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label36" runat="server"
                        Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),2) %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label37" runat="server" Text="الهاتف المحمول"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label38" runat="server"
                        Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),5) %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label41" runat="server" Text="الفاكس"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label42" runat="server"
                        Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),4) %>' />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label39" runat="server" Text="الموقع"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label40" runat="server"
                        Text='<%# Staff_Utility.GetSpecDetail(Eval("SA_STF_MEMBER_ID"),9) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">

                <tr id="Tr1" runat="server">

                    <td id="Td1" runat="server">

                        <table id="Table1" runat="server" border="1" class="ListViewLayoutTable">

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
</asp:Content>
 