<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/LibraryMaster.Master" AutoEventWireup="true" CodeBehind="Net_Report.aspx.cs" Inherits="MnfUniversity_Portals.UI.Net_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
    
    
     <div style="float: none;" align="center">

        <table style="width: 200px;font-weight: bold">
    <tr><td colspan="2" style="text-align: center">
        نموذج عرض الاعطال بالكليات</td></tr>
        <tr>
            <td >
                <asp:Label ID="Label1" runat="server" meta:resourcekey="Fac" Text="Choose Faculty:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="FacDropDownList" OnSelectedIndexChanged="FacDropDownList_OnSelectedIndexChanged" AutoPostBack="True" runat="server" CssClass="textboxservice2">
                    <asp:ListItem Value="-1">اختر</asp:ListItem>
                    <asp:ListItem Value="22">كلية الحاسبات والمعلومات</asp:ListItem>
                    <asp:ListItem Value="5">كلية الهندسة الإلكترونية</asp:ListItem>
                    <asp:ListItem Value="4">كلية الاداب</asp:ListItem>
                    <asp:ListItem Value="24">كلية العلوم</asp:ListItem>
                    <asp:ListItem Value="23">كلية الهندسة</asp:ListItem>
                    <asp:ListItem Value="25">كلية التجارة</asp:ListItem>
                    <asp:ListItem Value="39">كلية الحقوق</asp:ListItem>
                    <asp:ListItem Value="43">كلية الطب</asp:ListItem>
                    <asp:ListItem Value="42">كلية الاقتصاد المنزلي</asp:ListItem>
                    <asp:ListItem Value="30">كلية التربية</asp:ListItem>
                    <asp:ListItem Value="41">كلية التربية النوعية</asp:ListItem>
                    <asp:ListItem Value="31">كلية التمريض</asp:ListItem>
                    <asp:ListItem Value="40">كلية الزراعة</asp:ListItem>
                    <asp:ListItem Value="38">معهد الكبد </asp:ListItem>
                    <asp:ListItem Value="4659">المستشفيات الجامعية</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FacDropDownList" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <%--<tr>
            <td >
                <asp:Button ID="Button1" runat="server" CssClass="btn1" meta:resourcekey="Search" OnClick="SearchButtonClicked" Text="Search" />
            </td>
        </tr>--%>
    </table>
         <asp:ListView ID="ListView1"   runat="server" DataSourceID="LinqDataSource1">
             
              <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="Date" meta:resourcekey="Date" ></asp:Label></th>
                                            <th id="Th1" runat="server" >
                                                                <asp:Label  ID="Label9" runat="server" Text="Damage" meta:resourcekey="Damage" ></asp:Label></th>
                                            <th id="Th5" runat="server" >
                                                                <asp:Label  ID="Label4" runat="server" Text="More" meta:resourcekey="more" ></asp:Label></th>
                                                            <th id="Th3" runat="server" >
                                                                <asp:Label  ID="Label5" runat="server" Text="Print" meta:resourcekey="print" ></asp:Label></th>
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
                                               
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                        </td>
                           <td class="col2"> <asp:Label ID="Label8" runat="server" Text='<%#Eval("Damage")%>'></asp:Label></td>
                           <td class="col2"> <asp:LinkButton ID="linkbutton1" Text="المزيد" CommandArgument='<%# Eval("ID") %>' meta:resourcekey="more" OnClick="Editor_ImageButton_Click" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"> </asp:LinkButton></td>
                          <%-- <td class="col2">   <asp:HyperLink ID="MoreHyperLink1"
                                runat="server"
                                NavigateUrl='<%# Common.URLBuilder.ReportItemUrl(Page.RouteData,(int) Eval("ID")) %>'
                                Text="طباعة"></asp:HyperLink></td>--%>
                           <td class="col2"> <asp:LinkButton ID="linkbutton2" Text="طباعة" CommandArgument='<%# Eval("ID") %>' meta:resourcekey="more" OnClick="Editor_ImageButton_Click2" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"> </asp:LinkButton></td>

                           
                           </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoDataFound" >No  Data Found
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
             
             
             
             

         </asp:ListView> <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" Select="new (ID,Date, Damage)" TableName="Prtl_Nt_Damage_Reports" Where="Fac_Id == @Fac_Id">
             <WhereParameters>
                 <asp:ControlParameter ControlID="FacDropDownList" PropertyName="SelectedValue" Name="Fac_Id" Type="Int32"></asp:ControlParameter>
             </WhereParameters>
         </asp:LinqDataSource>


 
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
    <asp:DetailsView ID="Editor_DetailsView1" CssClass="Editor_DetailsView" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" GridLines="None" EmptyDataText="No Data" DataSourceID="LinqDataSource2">
        <Fields>
        </Fields>
        <AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
        <CommandRowStyle CssClass="Editor_CommandRowStyle" />
        <EditRowStyle CssClass="Editor_EditRowStyle" />
        <FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
        <Fields>
            <asp:TemplateField HeaderText="Faculty" meta:resourcekey="facc"><ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%#GetFacName(Eval("Fac_Id"))%>' ></asp:Label>
            </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="EngineerName" HeaderText="EngineerName" meta:resourcekey="engn" SortExpression="EngineerName" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" meta:resourcekey="datee" SortExpression="Date" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Informer" HeaderText="Informer" meta:resourcekey="informer" SortExpression="Informer" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Damage" HeaderText="Damage" meta:resourcekey="damagee" SortExpression="Damage" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Fixing" HeaderText="Fixing" ReadOnly="True" meta:resourcekey="fix" SortExpression="Fixing"></asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Notes" ReadOnly="True" meta:resourcekey="notes" SortExpression="Notes"></asp:BoundField>
            
        </Fields>
        <FooterStyle CssClass="Editor_FooterStyle" />
        <HeaderStyle CssClass="Editor_HeaderStyle" />
        <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
        <RowStyle CssClass="Editor_RowStyle" />
    </asp:DetailsView>

    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Portal_DAL.PortalDataContextDataContext" Select="new (EngineerName, Date, Informer, Damage, Fixing, Notes, Fac_Id)" TableName="Prtl_Nt_Damage_Reports"></asp:LinqDataSource>
   </asp:Panel>
 
         
          <asp:ImageButton ID="ImageButton1" runat="server" Style="display:none" />
<ajaxtk:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Enabled="true" TargetControlID="ImageButton1" PopupControlID="Panel1" PopupDragHandleControlID="Panel2" BackgroundCssClass="modalBackground" RepositionMode="None" />
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

     <rsweb:ReportViewer ID="ReportViewer1" Width="600px" Height="500px" runat="server" ShowPrintButton="true" SizeToReportContent="True" DocumentMapCollapsed="True" ZoomPercent="50" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">

               
              </rsweb:ReportViewer>
      </asp:Panel>


     <br/><br/>
         <asp:HyperLink ID="MoreHyperLink1" Visible="False"
                                runat="server"
                                Text=" طباعة تقرير مجمع للكلية"></asp:HyperLink>
        
         </ContentTemplate>
    </asp:UpdatePanel>
      
</asp:Content>
