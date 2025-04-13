<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" MasterPageFile="~/Masterpages/UniversityMaster.master" Inherits="MnfUniversity_Portals.UI.Search" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="App_Code" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
            
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
          <div style="overflow: auto; width: 100%;">
    <br/><br/>
    <table style="width: 100%;">
    <tr>
    <td><asp:Label ID="Label4" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </td></tr></table><br/>
    <asp:ListView ID="AbstractListView"  runat="server" 
        InsertItemPosition="FirstItem">
        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                    <asp:LinkButton Visible='<%# checkuser() %>' ValidationGroup="InsertValidation" CommandArgument='<%# Eval("SA_STF_MEMBER_ID") %>' OnClick="FileAbstractEditorControlInsertClicked"
                        ID="InsertLinkButton" ToolTip="Insert" runat="server" AlternateText="Insert">
                       
                        <asp:Label ID="Label1" Visible='<%# checkuser() %>' runat="server" Text="Insert New Abstract"></asp:Label>
                    </asp:LinkButton>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr runat="server" id="ListViewDataRow" align="center">
                
                <td>
                    <asp:Label ID="title_Label" Text='<%# Eval("STF_FULL_NAME_AR") %>' runat="server" />
                </td>
                <td>
                    <asp:Label ID="Label2" Text='<%# Eval("STF_FULL_NAME_EN") %>' runat="server" />
                </td>

                
                <td>
                    <asp:HiddenField runat="server" ID="staffid" Value='<%# Eval("SA_STF_MEMBER_ID") %>'/>
                    <a href='<%# FileAbstractUrl(Eval("SA_STF_MEMBER_ID")) %>'  >
                    <asp:Label ID="Label1" runat="server" Text='<%# FileAbstractUrl(Eval("SA_STF_MEMBER_ID")) %>'></asp:Label>
                </a> 
                </td>

            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                            <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                                
                                <th id="Th3" runat="server">
                                    <asp:Label ID="Label4" runat="server" Text="Staff Arabic Name"></asp:Label>
                                </th>
                                <th id="Th1" runat="server">
                                    <asp:Label ID="Label5" runat="server" Text="Staff English Name"></asp:Label>
                                </th>
                                
                                <th id="Th2" runat="server">
                                    <asp:Label ID="Label3" runat="server" Text="Abstract File"></asp:Label>
                                </th>


                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
               
            </table>
        </LayoutTemplate>
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
             
              <asp:TemplateField  HeaderText="Faculty Name:">
                   <InsertItemTemplate>
                       <asp:DropDownList AppendDataBoundItems="true"  DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="InnerFacDropDownList" runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                   </InsertItemTemplate>
                   
                </asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Researcher Name:" >
                   
                   <InsertItemTemplate>
                     
                       <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" runat="server">
                           <ContentTemplate>
                       <asp:GridView ID="GridView1" OnPageIndexChanging="GridViewPageIndexChanging" runat="server"  AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                           

                           <Columns>

                               <asp:TemplateField HeaderText="Name" InsertVisible="False">

                                   <ItemTemplate>
                                       <asp:RadioButton GroupName="anygroup" ID="RadioButton1" AutoPostBack="True" ToolTip='<%#Eval("SA_STF_MEMBER_ID") %>' Text='<%#Eval("STF_FULL_NAME_AR") %>' OnCheckedChanged="RadioButtonCheckedChanged" runat="server" />
                                   </ItemTemplate>
                               </asp:TemplateField>



                           </Columns>
                           <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                           <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                           <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                           <RowStyle BackColor="#EFF3FB"></RowStyle>

                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                           <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                           <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                           <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                           <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                       </asp:GridView>
                               </ContentTemplate>
                       </asp:UpdatePanel>

                   </InsertItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Abstract File:" >
                   
                    <InsertItemTemplate>
                      
                        <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistedStoreType="Session"
                    PersistFile="True" Width="70px"></ajaxtk:AsyncFileUpload>
                    </InsertItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterTemplate>
                <asp:LinkButton ID="LinkButton1" Text="Insert" OnClick="InsertButtonClicked" runat="server"></asp:LinkButton>
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
            
            
            
            
            

            <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Search:" meta:resourcekey="SearchLabel"></asp:Label></td>
                    
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    
                    <asp:RadioButtonList ID="RadioButtonList1"  runat="server">

                        <asp:ListItem Value="1" Text="Articles" meta:resourcekey="ArticlesLabel"></asp:ListItem>
                        <asp:ListItem Value="2" Text="News" meta:resourcekey="NewsLabel"></asp:ListItem>
                       <%-- <asp:ListItem Value="3" Text="Events" meta:resourcekey="EventsLabel"></asp:ListItem>--%>
                    </asp:RadioButtonList>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" OnClick="SearchButtonClicked" runat="server" Text="Search" meta:resourcekey="SearchButton" /></td>
                   
                </tr>
                
            </table>

            <asp:ListView ID="ListView1" runat="server"  >
               
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="No data was returned." meta:resourcekey="NoDataReturned"></asp:Label></td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <ItemTemplate>
                    <div id="resultsDiv">
                    <div class="pageContainer" style="display: block;">
                     
                           <div class="webResult" style="width: 100%; direction: <%=StaticUtilities.Dir%>; text-align: <%=StaticUtilities.Textright%>;" >               

                                      
                   <h2>
                       <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Title") %>' NavigateUrl='<%#StaticUtilities.GetArticleItemURL(Page,Eval("ID")) %>' runat="server" Font-Underline="True" Font-Size="Medium" Font-Bold="True"></asp:HyperLink>
                            

                   </h2>
                            <p>
                                <asp:Label Text='<%# Eval("Body") %>' runat="server" ID="Actual_ContentLabel" />
                            </p>
                               </div>
                        </div>
                   </div>
                </ItemTemplate>
                <LayoutTemplate>
                    
                                <div runat="server" id="itemPlaceholderContainer" >
                                   
                                    <div runat="server" id="itemPlaceholder">
                                        
                                     
    


                                    </div>
                        
                                </div>
                           
                </LayoutTemplate>

             
            </asp:ListView>

            
         <%--   <asp:Repeater ID="Repeater1"  runat="server" >
    <HeaderTemplate>
   
         <script>
               $('#games').coinslider();
		</script>
</HeaderTemplate>
    <ItemTemplate>
   
    <div id="games">
            <a href="#" > <img src='<%#GetImage( Eval("Image") )%>' width="900px" height="300px"  /> <span>
                 <b></b> <asp:Label ID="Label3" runat="server" Text='<%# Eval("Details") %>'></asp:Label><br />       
          </div>
    
    </ItemTemplate>

</asp:Repeater>--%>
            

           
            <div id="games">
            <a href="#" >  <span>
                 <b></b> <asp:Label ID="Label3" runat="server" Text="test"></asp:Label><br />       
          </div>
 <script type="text/javascript">
     $('#games').coinslider();
		</script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>