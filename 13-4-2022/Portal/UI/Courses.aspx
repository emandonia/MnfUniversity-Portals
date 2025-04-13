<%@ Page   Language="C#" MasterPageFile="~/Masterpages/SpecialUnitsMaster.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="MnfUniversity_Portals.Courses" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div>
    <table >
        <tr><td>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext" EntityTypeName="" TableName="Prtl_CourseTypes">
            </asp:LinqDataSource>
            </td><td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="بحث" />
            </td><td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource2" AutoPostBack="true" DataTextField="Type" DataValueField="ID">
                </asp:DropDownList>
            </td><td>
                <asp:Label ID="Label14" runat="server" Text="اختر تصنيف الدورة "></asp:Label>
            </td></tr>
        <tr><td></td><td colspan="3">
           
               <asp:ListView ID="ListView1" runat="server"   DataSourceID ="LinqDataSource1" DataKeyNames ="ID"  
                   OnItemCommand ="ListView1_ItemCommand"  
                    OnSelectedIndexChanged="ListView1_SelectedIndexChanged"
                   OnSelectedIndexChanging ="ListView1_SelectedIndexChanging"
                   OnItemDataBound ="ListView1_ItemDataBound">
                    <LayoutTemplate>
                        <table id="Table1" runat="server">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table id="groupPlaceholderContainer" class="stafftable" 
                                        border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;" >
                                       <tr id="Tr3" runat="server" >

                                                            <th id="Th1" runat="server">
                                                                <asp:Label ID="Label1" runat="server" Text="اسم الدورة"  ></asp:Label></th>
                                                         <th id="Th4" runat="server"><asp:Label ID="Label5" runat="server" Text="عدد الساعات" ></asp:Label></th>
                                                            <th id="Th3" runat="server"><asp:Label ID="Label3" runat="server" Text="التكلفة"  ></asp:Label></th>
                                                           <th id="Th5" runat="server"><asp:Label ID="Label9" runat="server" Text="محتويات الدورة"  ></asp:Label></th>
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

                           <td class="col1">   
                                <asp:HiddenField ID ="hide3" Value ='<%#Eval("ID")%>'  runat ="server" />
                    
                                        <asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"  Text='<%#Eval("CourseName")%>' NavigateUrl='<%#GetUrl(Eval("ID"))%>'   > </asp:HyperLink>
                  <asp:HiddenField ID ="hide2" Value ='<%#Eval("ID")%>'  runat ="server" />
                                      <td class="col1"> <asp:Label ID="Label11" runat="server" Text='<%#Eval("HoureNumber")%>'></asp:Label></td>
           <td class="col1"> <asp:Label ID="Label12" runat="server" Text='<%#Eval("Cost")%>'></asp:Label></td>
      <td class="col1"> <asp:Label ID="Label13" runat="server" Text='<%#Eval("CourseContent")%>'></asp:Label></td>
          
      </td>
     
                                            <td class="col2">
                                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="blue" Text='<%#Eval("CourseName")%>' NavigateUrl=  '<%# GetUrl(Eval("ID"))%>' > </asp:HyperLink>--%>
                             </div> </tr>
                    </ItemTemplate>

                   <SelectedItemTemplate>
      <tr style="background-color: #336699; color: White;">
         <td>
              <asp:HiddenField ID ="HiddenField1" Value ='<%#Eval("ID")%>'  runat ="server" />
                    
    
                           <asp:HiddenField ID ="hide1" Value ='<%#Eval("ID")%>'  runat ="server" />
                                  
         
          <asp:Button ID="Button1" runat="server" Text="Button"  OnClick ="Button1_OnClick"  />
         </td>
             <td class="col1"> <asp:Label ID="Label11" runat="server" Text='<%#Eval("HoureNumber")%>'></asp:Label></td>
           <td class="col1"> <asp:Label ID="Label12" runat="server" Text='<%#Eval("Cost")%>'></asp:Label></td>
      <td class="col1"> <asp:Label ID="Label13" runat="server" Text='<%#Eval("CourseContent")%>'></asp:Label></td>
       
      </tr>
   </SelectedItemTemplate>

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
          
            <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Courses" Where="CourseType == @CourseType">
                <WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="CourseType" Type="Int32"></asp:ControlParameter>
                </WhereParameters>
            </asp:LinqDataSource>
        </td><td></td></tr>
    </table>
<table >
    <tr><td></td><td></td><td></td><td></td><td></td></tr>
     <tr><td></td><td></td><td></td><td></td><td></td></tr>
     <tr><td></td><td></td><td></td><td></td><td></td></tr>
     <tr><td></td><td></td><td></td><td></td><td></td></tr>
     <tr><td></td><td></td><td></td><td></td><td></td></tr>

</table>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>--%>
