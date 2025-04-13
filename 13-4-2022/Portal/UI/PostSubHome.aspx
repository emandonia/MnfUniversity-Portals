<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="PostSubHome.aspx.cs" Inherits="MnfUniversity_Portals.UI.PostSubHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
       
       
       <ContentTemplate>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="PG_SUBJECT_ID"
        DataSourceID="LinqDataSource1">
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr>
                <td colspan="2" class="col1"><asp:Label ID="Label6"  runat="server" Text='<%# getsubjectDes(Eval("PG_SUBJECT_ID")) %>' Font-Bold="True" /></td>
            </tr>           
            <tr>
                <td class="col2">
                    <asp:Label ID="Label1" runat="server" Text="كود المادة" meta:resourcekey="SubjectCode"></asp:Label>
                </td>
                <td>
                   &nbsp;&nbsp;&nbsp; <asp:Label ID="lblSubCode" runat="server" Text='<%# Eval("SUBJECT_CODE") %>' /></td>
            </tr>
            <tr>
                <td class="col2">
                    <asp:Label ID="Label2" runat="server" Text="المحتوى العلمى" meta:resourcekey="SubjectDes"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="LblSUBJECT_CONTENTS_AR" runat="server" Text='<%# getsubjectCont(Eval("PG_SUBJECT_ID")) %>' />
                </td>
            </tr>
            <tr>
                <td class="col2">
                    <asp:Label ID="Label3" runat="server" Text="توزيع الدرجات" meta:resourcekey="Degree"></asp:Label>
                </td>
                <td>
                    
                         <tr>
                             <td class="col2"><asp:Label ID="Label4" runat="server" Text="الدرجة العظمى" meta:resourcekey="Max"></asp:Label></td>                       
                             <td>&nbsp;&nbsp;&nbsp;<asp:Label ID="LblMAX_GRADE" runat="server" Text='<%# Eval("MAX_GRADE") %>'></asp:Label></td>
                         </tr>
                          <tr>
                            <td class="col2"><asp:Label ID="Label5" runat="server" Text="الدرجة الصغرى" meta:resourcekey="Min"></asp:Label></td>                       
                             <td>&nbsp;&nbsp;&nbsp;<asp:Label ID="LblMIN_GRADE" runat="server" Text='<%# Eval("MIN_GRADE") %>' ></asp:Label></td>                              
                         </tr>                         
                    
                    
                </td>
            </tr>
          <tr>
                <td class="col2"  style="text-align: center;">
                     <a href='<%# CourseSpecs() %>'  >
                    <asp:Label ID="Label9" runat="server" Text="course SPecs" meta:resourcekey="SpecsFile1"></asp:Label>
                </a> 
                   
                </td>
                 <td >
                    <asp:LinkButton Visible='<%# checkuser() %>' ValidationGroup="InsertValidation" CommandArgument='<%# Eval("PG_SUBJECT_ID") %>' OnClick="InsertCourseSpecsInsertClicked"
                        ID="InsertLinkButton" ToolTip="Insert" runat="server" AlternateText="Insert" Font-Size="Large" ForeColor="Blue">
                        
                        <asp:Label ID="Label7" Visible='<%# checkuser() %>' runat="server" Text="Insert" Font-Size="Large" ForeColor="Blue" ></asp:Label>
                    </asp:LinkButton>
                </td>
               <td >
                    <asp:LinkButton Visible='<%# checkuser() %>' ValidationGroup="InsertValidation" CommandArgument='<%# Eval("PG_SUBJECT_ID") %>' OnClick="DeleteSpecsButtonClicked"
                        ID="LinkButton4" ToolTip="Delete" runat="server" AlternateText="Delete" Font-Size="Large" ForeColor="Blue">
                        
                        <asp:Label ID="Label11" Visible='<%# checkuser() %>' runat="server" Text="Delete" Font-Size="Large" ForeColor="Blue" ></asp:Label>
                    </asp:LinkButton>
                </td>
              
            </tr>
            <tr>
                <td class="col2" style="text-align: center;">
                    <a href='<%# CourseReports() %>'  >
                    <asp:Label ID="Label12" runat="server" Text="course reports" meta:resourcekey="ReportFile1"></asp:Label>
                </a> 
                   
                </td>
                <td >
                    <asp:LinkButton Visible='<%# checkuser() %>' ValidationGroup="InsertValidation" CommandArgument='<%# Eval("PG_SUBJECT_ID") %>'    OnClick="InsertCourseReportInsertClicked"
                        ID="LinkButton1" ToolTip="Insert" runat="server" AlternateText="Insert" Font-Size="Large" ForeColor="Blue">
                        
                        <asp:Label ID="Label8" Visible='<%# checkuser() %>' runat="server" Text="Insert" Font-Size="Large" ForeColor="Blue" ></asp:Label>
                    </asp:LinkButton>
                </td>
                 <td >
                    <asp:LinkButton Visible='<%# checkuser() %>' ValidationGroup="InsertValidation" CommandArgument='<%# Eval("PG_SUBJECT_ID") %>'    OnClick="DeleteReportButtonClicked"
                        ID="LinkButton3" ToolTip="Delete" runat="server" AlternateText="Delete" Font-Size="Large" ForeColor="Blue">
                        
                        <asp:Label ID="Label10" Visible='<%# checkuser() %>' runat="server" Text="Delete" Font-Size="Large" ForeColor="Blue" ></asp:Label>
                    </asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">

                <tr id="Tr1" runat="server">

                    <td id="Td1" runat="server">

                        <table id="Table1" class="stafftable" dir='<%=StaticUtilities.Dir %>' style="font-weight: bold;font-family: Verdana, Arial, Helvetica, sans-serif;" runat="server" border="0" >

                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Mis_DAL.MisDataContext"
        EntityTypeName="" TableName="PG_SUBJECTs">
    </asp:LinqDataSource>
    <br/>
   <asp:ImageButton ID="Dummy" runat="server" Style="display: none" />
<ajaxtk:ModalPopupExtender ID="Editor_ModalPopupExtender" runat="server" Enabled="true"
    TargetControlID="Dummy" PopupControlID="Editor_Panel" PopupDragHandleControlID="Editor_HandelPanel"
     BackgroundCssClass="modalBackground"
    RepositionMode="None" />
            <asp:Panel ID="Editor_Panel" runat="server" Style="display: none" CssClass="modalPopup">
    <asp:Panel ID="Editor_HandelPanel" CssClass="Handel_Panel" runat="server">
        <div style="float: <%=StaticUtilities.FloatRight%>" class="Handel_Label">
            <asp:Localize ID="EditorTitleLocalize" runat="server" Text=""></asp:Localize>
        </div>
        <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
            <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
                <div style="float: <%=StaticUtilities.FloatRight%>">
                    <asp:ImageButton ID="MaximizeImageButton" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
                    <asp:ImageButton ID="RestoreImageButton" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display: none;" OnClientClick="maximize_restore(this);return false;" />
                </div>
                <div style="float: <%=StaticUtilities.FloatLeft%>">
                    <asp:ImageButton ID="CancelEditorImageButton" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    
        <asp:DetailsView ID="Editor_DetailsView1" CssClass="Editor_DetailsView" runat="server"
            AllowPaging="True" AutoGenerateRows="False" CellPadding="4"
            GridLines="None"  EmptyDataText="No Data">
            <Fields>
              
               <asp:TemplateField  Visible="False" HeaderText="Specs File:" meta:resourcekey="SpecsFile" >
                   
                    <InsertItemTemplate>
                      
                        <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" PersistedStoreType="Session"
                     Width="70px"></ajaxtk:AsyncFileUpload>
                        <br/>
                         <asp:LinkButton ID="LinkButton1" Text="Insert" OnClick="InsertSpecsButtonClicked" runat="server" BackColor="#6699FF" Font-Bold="True" Font-Size="15" ForeColor="Black"></asp:LinkButton>
            
            </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Report File:" meta:resourcekey="ReportFile" >
                   
                    <InsertItemTemplate>
                      
                        <ajaxtk:AsyncFileUpload ID="AsyncFileUpload2" runat="server" PersistFile="True" PersistedStoreType="Session"
                     Width="70px"></ajaxtk:AsyncFileUpload>
                        <br/>
                         <asp:LinkButton  ID="LinkButton5" Text="Insert" OnClick="InsertReportButtonClicked" runat="server" BackColor="#6699FF" Font-Bold="True" Font-Size="15" ForeColor="Black"></asp:LinkButton>
            
                    </InsertItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterTemplate>
               

               
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
           <div style="text-align: center;">
           <asp:Label ID="Label13" runat="server" BackColor="#6699FF" Font-Bold="True" Font-Size="20" ForeColor="Black" ></asp:Label>
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
