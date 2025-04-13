<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CVs.aspx.cs" MasterPageFile="~/Masterpages/UniversityMaster.master" Inherits="MnfUniversity_Portals.UI.Cvs" %>




<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
     
         <ContentTemplate>



            
       
<div style="overflow: auto; width: 100%;">
    <br/><br/>
    <table style="width: 100%;">
    <tr>
    <td><asp:Label ID="Label1" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </td></tr></table><br/>
    <asp:ListView ID="AbstractListView"   runat="server" 
        InsertItemPosition="FirstItem">
        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                    <asp:LinkButton Visible='<%#checkuser() %>'  ValidationGroup="InsertValidation"  CommandArgument='<%# Eval("SA_STF_MEMBER_ID") %>' OnClick="FileAbstractEditorControlInsertClicked"
                        ID="InsertLinkButton" ToolTip="Insert" runat="server" AlternateText="Insert" Font-Size="Large" ForeColor="Blue">
                        <%--<asp:Image ID="InsertImage" ImageUrl='<%#InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>--%>
                        <asp:Label ID="Label2"  runat="server" Text="Insert\Delete" Font-Size="Large" ForeColor="Blue" ></asp:Label>
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
                    <asp:Label ID="Label3" Text='<%# Eval("STF_FULL_NAME_EN") %>' runat="server" />
                </td>

                
                <td>
                    
                    <a href='<%# FileAbstractUrl(Eval("SA_STF_MEMBER_ID")) %>'  >
                    <asp:Label ID="Label4" runat="server" Text='<%# FileName(Eval("SA_STF_MEMBER_ID")) %>'></asp:Label>
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
                                    <asp:Label ID="Label5" runat="server" Text="Staff Arabic Name"></asp:Label>
                                </th>
                                <th id="Th1" runat="server">
                                    <asp:Label ID="Label6" runat="server" Text="Staff English Name"></asp:Label>
                                </th>
                                
                                <th id="Th2" runat="server">
                                    <asp:Label ID="Label7" runat="server" Text="Abstract File"></asp:Label>
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
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
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
                       <asp:GridView ID="GridView1" OnPageIndexChanging="GridViewPageIndexChanging" runat="server"  AllowPaging="True" PageSize="20" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                           

                           <Columns>

                               <asp:TemplateField HeaderText="Name" InsertVisible="False">

                                   <ItemTemplate>
                                       <div style="font-weight: bold; font-size: 14px">
                                       <asp:RadioButton GroupName="anygroup" ID="RadioButton1" AutoPostBack="True" ToolTip='<%#Eval("SA_STF_MEMBER_ID") %>' Text='<%#Eval("STF_FULL_NAME_AR") %>' OnCheckedChanged="RadioButtonCheckedChanged" runat="server" />
                                  </div> </ItemTemplate>
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
                      
                        <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" PersistedStoreType="Session"
                     Width="70px"></ajaxtk:AsyncFileUpload>
                    </InsertItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterTemplate>
                <asp:LinkButton ID="LinkButton1" Text="Insert" OnClick="InsertButtonClicked" runat="server"></asp:LinkButton>
             &nbsp;&nbsp;
                 <asp:LinkButton ID="LinkButton2" Text="Delete" OnClick="DeleteAbstractFile" runat="server"></asp:LinkButton>
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
