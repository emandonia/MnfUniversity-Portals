<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileAbstractsViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.FileAbstractsViewer" %>
 



<asp:ListView ID="AbstractsListView" runat="server" >
  
    <EmptyDataTemplate>
         <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" >No Staff Data Found
                                </td>
                            </tr>
                        </table>
    </EmptyDataTemplate>
   
    <ItemTemplate>
        <tr >
            
            <td>
                <asp:Label Text='<%# Eval("StaffName") %>' runat="server" ID="Translation_DataLabel" /></td>
            <td>
                <a href='<%# FileAbstractUrl(Eval("AbstractFile")) %>'  >
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("AbstractFile") %>'></asp:Label>
                </a> 
                <%--<asp:LinkButton ID="LinkButton1" runat="server" Text='<%# FileAbstractUrl(Eval("AbstractFile")) %>' PostBackUrl='<%# FileAbstractUrl(Eval("AbstractFile")) %>'></asp:LinkButton>
               --%>
                 </td>
            
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
         <table id="Table1" runat="server">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" style="border-collapse: collapse; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                           
                                                               
                                                            <th id="Th2" runat="server"><asp:Label ID="Label10" runat="server" Text="StaffName"  ></asp:Label></th>
                                                            <th id="Th3" runat="server"><asp:Label ID="Label11" runat="server" Text="BookOfAbstractFile"  ></asp:Label></th>
                                                            
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
    </LayoutTemplate>
   
</asp:ListView>


<%--<asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="prtl_Translations" Where="Lang_Id == @Lang_Id&amp;&amp;Prtl_StaffAbstractFiles.Published == True &amp;&amp; Prtl_StaffAbstractFiles.prtl_Owner.Abbr == @Owner">
    <WhereParameters>
        <asp:RouteParameter RouteKey="lang" Name="Lang_Id" Type="Int32"/>
        <asp:RouteParameter Name="Owner" RouteKey="currentowner" Type="String" />
    </WhereParameters>
</asp:LinqDataSource>--%>
