<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="LawOpenSubjects.aspx.cs" Inherits="MnfUniversity_Portals.UI.LawOpenSubjects" %>
<%@ Import Namespace="MisBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  
               <asp:ListView ID="ListView1" runat="server" >
                    <LayoutTemplate>
                        <table id="Table1" runat="server">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table id="groupPlaceholderContainer" class="stafftable" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;" >
                                       <tr id="Tr3" runat="server" >

                                                            <th id="Th1" runat="server">
                                                                <asp:Label ID="Label1" runat="server" Text="Subject Code" meta:resourcekey="SubjectCodeLabelResource1"></asp:Label></th>
                                                            <th id="Th2" runat="server"><asp:Label ID="Label2" runat="server" Text="Subject Name" meta:resourcekey="SubjectNameLabelResource1"></asp:Label></th>
                                            <th id="Th4" runat="server"><asp:Label ID="Label5" runat="server" Text="Subject Name" ></asp:Label></th>
                                                            <th id="Th3" runat="server"><asp:Label ID="Label3" runat="server" Text="Year" meta:resourcekey="SubjectYearLabelResource1"></asp:Label></th>
                                                            
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                  
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                       
 <tr > <div style="width: 100%">
                           <td class="col1"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("SUBJECT_CODE")%>'></asp:Label></td>
      
                                            <td class="col2">
                               <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="blue" NavigateUrl='<%#getSubjectUrl(Eval("ED_SUBJECT_ID"))%>'
                                    Text='<%#Eval("SUBJECT_DESCR_AR")%>'></asp:HyperLink>
                        </td>
     <td class="col1"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("SUBJECT_DESCR_EN")%>'></asp:Label></td>
                           <td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%# SubjectUtility.GetSubjectYear(Convert.ToDecimal(Eval("ED_SUBJECT_ID")))%>'></asp:Label></td>
                           
                          </div> </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server">
                                    <asp:Label ID="Label4" runat="server" Text="No Subjects Data Found" meta:resourcekey="NoSubjectFoundLabelResource1" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                  

                 
                </asp:ListView>
       
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
