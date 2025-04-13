<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="StaffCVs.aspx.cs" Inherits="MnfUniversity_Portals.UI.StaffCVs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
      
        

       
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
         <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
             <ContentTemplate>
            <asp:Label ID="Label3" runat="server" BackColor="#6699FF" Text="برجاء ادخال اسم العضو او الكلية او القسم ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 400px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Enter Staff Name:" meta:resourcekey="NameLabel"></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox  ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="True" DataSourceID="ObjectDataSource1" 
                                DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
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
                            <asp:Label ID="Label2" runat="server" Text="Choose Department:" meta:resourcekey="depLabel"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList" Enabled="false" DataTextField="DepName"
                                DataValueField="ID" AutoPostBack="true" runat="server"
                                AppendDataBoundItems="true"
                                >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>

                        </tr>
                    

                 

                    <tr>
                        <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn" ID="Button1" runat="server" Text="Search" meta:resourcekey="btnSEC" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>

                <asp:ListView ID="CVListView" runat="server"  >
                  
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >
                                              <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="Name" meta:resourcekey="StaffNameLabelResource1" ></asp:Label></th>
                                              <th id="Th3"  runat="server"><asp:Label  ID="Label11" runat="server" Text="Department" meta:resourcekey="StaffDepLabelResource1" ></asp:Label></th>
                                              <th id="Th4"  runat="server"><asp:Label  ID="Label12" runat="server" Text="Faculty" meta:resourcekey="StaffFacLabelResource1" ></asp:Label></th>
                                              <th id="Th5"  runat="server"><asp:Label  ID="Label13" runat="server" Text="CV" meta:resourcekey="StaffCV" ></asp:Label></th>
                                              <th id="Th6"  runat="server"  Visible='<%#checkuser() %>'><asp:Label  ID="Label8" runat="server" Text="Update CV File" meta:resourcekey="updeteCv" Visible='<%#checkuser() %>' ></asp:Label></th>
                                              <th id="Th7"  runat="server"  Visible='<%#checkuser() %>'><asp:Label  ID="Label9" runat="server" Text="Delete CV File" meta:resourcekey="DeleteCV" Visible='<%#checkuser() %>' ></asp:Label></th>
                                       
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
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#StaffUrl(Eval("Abbr").ToString())%>'  Text='<%#Eval("Name")%>'></asp:HyperLink>
                          </td>
                           <td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%#Eval("DepName")%>'></asp:Label></td>
                           <td class="col4"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("FacName")%>'></asp:Label></td>
                          <td class="col4">   
                        
                          <a href='<%# FileCVUrl(Eval("ID")) %>'  >
                          <asp:Label ID="Label4" runat="server" Text='<%# getFileCV(Eval("ID")) %>'></asp:Label></td>
                           <td>
                                 
                       <asp:LinkButton  CommandArgument='<%# Eval("ID") %>' Visible='<%#checkuser() %>' OnClick="FileCVEditorControlInsertClicked"
                        ID="InsertLinkButton" ToolTip="Update" runat="server" AlternateText="Update" Font-Size="Large" ForeColor="Blue">
                        <asp:Label ID="Label2"  runat="server" Text="Update" Visible='<%#checkuser() %>' Font-Size="Large" ForeColor="Blue" ></asp:Label>
                    </asp:LinkButton>         
                          </td>
                           <td>   <asp:LinkButton ID="LinkButton2" Text="Delete" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteCVFile" runat="server" Visible='<%#checkuser() %>'></asp:LinkButton></td>
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
                <asp:TemplateField  HeaderText="Choose File:">
                   <InsertItemTemplate>
                       
                          
                  <asp:UpdatePanel UpdateMode="Always" runat="server">
                           <ContentTemplate>
       
                        <asp:ListBox ID="ListBox1" style="height: 300px;width: 400px" runat="server" ></asp:ListBox>
                                </ContentTemplate>
                       </asp:UpdatePanel>
                 </InsertItemTemplate>
                </asp:TemplateField></Fields>
   <FooterTemplate>
                <asp:LinkButton ID="LinkButton1" Text="Insert" OnClick="InsertButtonClicked" runat="server"></asp:LinkButton>
             &nbsp;&nbsp;
              
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
                    </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>

