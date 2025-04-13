<%@ Page  Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="ReplayComp.aspx.cs" Inherits="MnfUniversity_Portals.UI.ReplayComp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
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
                          
          
                    <asp:Label ID="sentlabel" runat="server" ForeColor="red"  Text=""></asp:Label>
                   
                                                       
            <asp:ListView ID="ListView2" runat="server" DataSourceID="ObjectDataSource1">

                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>' Font-Bold="True"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Mobile") %>' Font-Bold="True"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Email") %>' Font-Bold="True"></asp:Label></td>

                        <td>
                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("CompDate") %>' Font-Bold="True"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Text") %>' Font-Bold="True"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("RepDate") %>' Font-Bold="True"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("Replay") %>' Font-Bold="True"></asp:Label>
                        </td>
<td>
                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("SendToDrDate") %>' Font-Bold="True"></asp:Label>
                        </td>
<td>
                            <asp:Label ID="Label155" runat="server" Text='<%# Eval("DrAnswerDate") %>' Font-Bold="True"></asp:Label>
                        </td>
<td>
                            <asp:Label ID="Label16" runat="server" Text='<%# Eval("DrName") %>' Font-Bold="True"></asp:Label>
                        </td>
<td>
                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("SendToClientDate") %>' Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:HyperLink ID="MoreHyperLink1"
                                runat="server"
                                NavigateUrl='<%# Common.URLBuilder.ComplainItemUrl(Page.RouteData,(int) Eval("Comps_Id")) %>'
                                Text="طباعة"></asp:HyperLink>
                        </td>

                        <td>
                            <asp:LinkButton ID="linkbutton2" Text="تحويل" CommandArgument='<%# Eval("Comps_Id") %>'
                                OnClick="linkbutton2_Click" runat="server" ForeColor="Red" Font-Bold="True"> </asp:LinkButton>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLink1"
                                runat="server"
                                NavigateUrl='<%# Common.URLBuilder.ComplainReplayItemUrl(Page.RouteData,(int) Eval("Comps_Id")) %>'
                                Text="الرد علي صاحب الشكوي"></asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
                <LayoutTemplate>
                    <table id="Table2" runat="server">
                        <tr id="Tr1" runat="server">
                            <td id="Td1" runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                                    <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                                        <td id="Td3" runat="server">
                                            <asp:Label ID="Label5" runat="server" Text="اسم الشاكى"></asp:Label>
                                        </td>
                                        <td id="Td4" runat="server">
                                            <asp:Label ID="Label9" runat="server" Text="المحمول"></asp:Label>
                                        </td>
                                        <td id="Td5" runat="server">
                                            <asp:Label ID="Label10" runat="server" Text="البريد الالكترونى"></asp:Label>
                                        </td>

                                        <td id="Td7" runat="server">
                                            <asp:Label ID="Label16" runat="server" Text="تاريخ الشكوي" meta:resourcekey="complain"></asp:Label>
                                        </td>
                                        <td id="Th1" runat="server">
                                            <asp:Label ID="Label8" runat="server" Text="الشكوى" meta:resourcekey="complain"></asp:Label>
                                        </td>
                                        <td id="Td9" runat="server">
                                            <asp:Label ID="Label19" runat="server" Text="تاريخ الرد" meta:resourcekey="complain"></asp:Label>
                                        </td>
                                        <td id="Th22" runat="server">
                                            <asp:Label ID="Label4" runat="server" Text="الرد" meta:resourcekey="replay0"></asp:Label>
                                        </td>
 <td id="Th12" runat="server">
                                            <asp:Label ID="Label14" runat="server" Text="تاريخ الارسال الي الدكتور" meta:resourcekey="replay0"></asp:Label>
                                        </td>
 <td id="Th13" runat="server">
                                            <asp:Label ID="Label15" runat="server" Text="تاريخ اجابة الدكتور" meta:resourcekey="replay0"></asp:Label>
                                        </td>
 <td id="Th14" runat="server">
                                            <asp:Label ID="Label166" runat="server" Text="اسم الدكتور" meta:resourcekey="replay0"></asp:Label>
                                        </td>
 <td id="Th15" runat="server">
                                            <asp:Label ID="Label177" runat="server" Text="تاريخ الاجابة علي صاحب الشكوي" meta:resourcekey="replay0"></asp:Label>
                                        </td>

                                        <td id="Td8" runat="server">
                                            <asp:Label ID="Label17" runat="server" Text="الطباعة"></asp:Label>
                                        </td>
                                        <td id="Td6" runat="server">
                                            <asp:Label ID="Label11" runat="server" Text="التحويل"></asp:Label>
                                        </td>
                                        <td id="Td10" runat="server">
                                            <asp:Label ID="Label20" runat="server" Text="الرد علي صاحب الشكوي"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                    </table>

                </LayoutTemplate>

            </asp:ListView>

            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetCompByOwnerID" TypeName="MnfUniversity_Portals.BLL.Portal_BLL.Prtl_ComplainUtility">
                <SelectParameters>
                    <asp:SessionParameter SessionField="NewsOwner_ID" DbType="Guid" Name="ownerid"></asp:SessionParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
           <%-- <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" 
             TableName="Prtl_Comp_Comps" Where="Prtl_Complain.Owner_ID == Guid?(@ID)">

            <WhereParameters>
        <asp:SessionParameter SessionField="NewsOwner_ID" Name="ID" DbType="Guid" />
    </WhereParameters>
         </asp:LinqDataSource>--%>
                                                                    </td>
                                                                </tr>
       
                                                               
                                                                
                                                                  
                                                     
            </table>

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
    <div id="EditorDiv">

      <table >
          <tr><td><asp:Label ID="Label2" runat="server" Text="Replay" meta:resourcekey="Replay"></asp:Label></td><td>
              <asp:TextBox ID="TextBox1" Height="199px" Width="396px"  runat="server" TextMode ="MultiLine" ></asp:TextBox></td></tr>
           <tr><td></td><td><asp:Button ID="Button2" runat="server" Text="send" meta:resourcekey="send" OnClick ="Button2_Click"/></td></tr>
                                              
      </table>
        
    </div>
    
</asp:Panel>




            <asp:Panel ID="dddd" runat ="server" >

              <asp:ImageButton ID="Dummy1" runat="server" Style="display: none" />
<ajaxtk:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Enabled="true"
    TargetControlID="Dummy1" PopupControlID="Editor_Panel1" PopupDragHandleControlID="Editor_HandelPanel1"
     BackgroundCssClass="modalBackground"
    RepositionMode="None" />
<asp:Panel ID="Editor_Panel1" runat="server" Style="display: none" CssClass="modalPopup">
    <asp:Panel ID="Editor_HandelPanel1" CssClass="Handel_Panel" runat="server">
        <div style="float: <%=StaticUtilities.FloatRight%>" class="Handel_Label">
            <asp:Localize ID="Localize1" runat="server" Text=""></asp:Localize>
        </div>
        <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
            <div style="float: <%=StaticUtilities.FloatLeft%>" class="Handle_Controlbox">
                <div style="float: <%=StaticUtilities.FloatRight%>">
                    <asp:ImageButton ID="ImageButton2" ImageUrl="~/Styles/UserControlImages/maximize.png" runat="server" OnClientClick="maximize(this);return false;" />
                    <asp:ImageButton ID="ImageButton3" ImageUrl="~/Styles/UserControlImages/restore.png" runat="server" Style="display: none;" OnClientClick="maximize_restore(this);return false;" />
                </div>
                <div style="float: <%=StaticUtilities.FloatLeft%>">
                    <asp:ImageButton ID="ImageButton4" AccessKey="c" ImageUrl="~/Styles/UserControlImages/close.png" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <div id="EditorDiv2">

      <table >

          <%--<tr><td><asp:Label ID="Label13" runat="server" Text="from :" ></asp:Label></td><td>
               <asp:TextBox ID="txtfrom" runat="server" CssClass="textboxservice" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
         --%>
<tr><td><asp:Label ID="Label14" runat="server" Text="Subject :" ></asp:Label></td><td>
               <asp:TextBox ID="txtsub" runat="server" CssClass="textboxservice" ></asp:TextBox>
               

          <tr><td><asp:Label ID="Label12" runat="server" Text="To :" ></asp:Label></td><td>
               <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxservice" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                                                
           <tr><td></td><td><asp:Button ID="Button3" runat="server" Text="send" meta:resourcekey="send" OnClick ="Button3_Click"/></td></tr>
                                              
      </table>
        
    </div>
    
</asp:Panel>




            </asp:Panel>







               </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>