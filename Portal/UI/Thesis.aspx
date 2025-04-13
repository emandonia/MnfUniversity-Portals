

<%@ Page  AutoEventWireup="true" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master"  CodeBehind="Thesis.aspx.cs" Inherits="MnfUniversity_Portals.UI.Thesis" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MnfUniversity_Portals.Base_Code" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.Portal_BLL" %>
<%@ Import Namespace="Portal_DAL" %>
<%@MasterType VirtualPath="~/Masterpages/UniversityMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <br />
             <br />
             <br /> 
             <br /><asp:Label runat="server" BackColor="#6699FF" meta:resourcekey="test" Text="برجاء اختيار الكلية ونوع الرسالة ونوع البحث ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>
             <br />
             <br />
             <br />
             <br />
           
           
  <table style="width: 100%;">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> 
                    <asp:DropDownList AppendDataBoundItems="true"   DataSourceID="ObjectDataSource1"  DataTextField="Faculty_Name" DataValueField="OwnerAbbr" ID="DropDownList1" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر  الكلية</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetOwnersFaculties" TypeName="BLL.Prtl_OwnersUtility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    
                    </td>

                   
                </tr>
      <tr>
          
          <td><asp:Label ID="Label9" runat="server" Text="Study Type:" meta:resourcekey="SearchType"></asp:Label></td>
                 
                    <td> <asp:DropDownList ID="DropDownList2" runat="server">
                             
                         <asp:ListItem Value="-1" meta:resourcekey="SearchType"></asp:ListItem>
                         <asp:ListItem Value="False" meta:resourcekey="phd"></asp:ListItem>
                        <asp:ListItem Value="True" meta:resourcekey="master"></asp:ListItem>

                         </asp:DropDownList>

                                            </td>


      </tr>
       <tr>
          
          <td><asp:Label ID="Label11" runat="server" Text="Search Type:" meta:resourcekey="SearchType2"></asp:Label></td>
                 
                    <td>
                         <asp:DropDownList ID="DropDownList3" runat="server" >
                             
                         <asp:ListItem Value="-1" meta:resourcekey="SearchType2"></asp:ListItem>
                        <asp:ListItem Value="True" meta:resourcekey="tam"></asp:ListItem>
                        <asp:ListItem Value="False" meta:resourcekey="lamytm"></asp:ListItem>
                   </asp:DropDownList>
    
             </td>
             

      </tr>
      <tr>
          <td>
              <asp:Button ID="Button1" runat="server" Text="Search" OnClick="SearchButtonClicked" meta:resourcekey="Search"/>
              
           </td>
          
      </tr>
            </table>
         
            
            
            <asp:Label ID="Label10" runat="server" ></asp:Label><br/><br/>

            <asp:ListView ID="ListView2" OnPagePropertiesChanging="ListView2_OnPagePropertiesChanging"  runat="server">
                 
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>

                <ItemTemplate>


                    <div id="resultsDiv">
                        <div class="pageContainer" style="display: block;">

                            <div class="webResult" style="width: 100%; direction: <%=StaticUtilities.Dir%>; text-align: <%=StaticUtilities.Textright%>;">

                                <h2>
                                    <asp:Label ID="Label7"  runat="server" Text="اسم الباحث:"  meta:resourcekey="RN" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#HtmlRemoval.StripTagsRegex(Eval("StudentName").ToString())  %>' runat="server" ID="EngMainResNameLabel" Font-Bold="True" /><br />

                                </h2>
                                <p>

                                    <asp:Label ID="Label12" runat="server" Text="عنوان الرسالة: " meta:resourcekey="Titl" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%# HtmlRemoval.StripTagsRegex(Eval("Address").ToString()) %>' runat="server" ID="AddressLabel" Font-Bold="True" />

                                </p>
                       
                                  <p>   <asp:Label ID="Label13" runat="server" Text="ملخص الرسالة: " meta:resourcekey="sum" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%# HtmlRemoval.StripTagsRegex(Eval("Summary").ToString()) %>' runat="server" ID="Label8" Font-Bold="True" />
                                    </p>
                                    <asp:LinkButton Text="المزيد" CommandArgument='<%# Eval("Prtl_Thesi.ID") %>'  OnClick="Editor_ImageButton_Click"
                                        ID="Editor_LinkButton" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"></asp:LinkButton>
                                   

                                
                                
                            </div>
                        </div>
                    </div>


                </ItemTemplate>
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholderContainer">

                        <div runat="server" id="itemPlaceholder">
                        </div>
                        <asp:DataPager runat="server"  ID="DataPager1"  PagedControlID="ListView2"  PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                     
                    </div>
                </LayoutTemplate>

            </asp:ListView>

            <asp:LinqDataSource runat="server"  EntityTypeName="" ID="LinqDataSource2" ContextTypeName="Portal_DAL.PortalDataContextDataContext" TableName="Prtl_Thesis_Translations" OrderBy="StudentName" >

                <%--<WhereParameters>
                    <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="Prtl_Thesi" DbType="Guid"></asp:ControlParameter>
                </WhereParameters>--%>
            </asp:LinqDataSource>
            
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

        <asp:DetailsView ID="Editor_DetailsView" CssClass="Editor_DetailsView" runat="server"
            AllowPaging="True" AutoGenerateRows="False" CellPadding="4"
            GridLines="None" EmptyDataText="No Data">
            <Fields>
                <asp:TemplateField HeaderText="Faculty:" meta:resourcekey="Faculty" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label2"  Text='<%# Prtl_SCPapersUtility.GetFacName(Eval("Prtl_Thesi.Owner_ID").ToString(),StaticUtilities.Currentlanguage(Page)) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Specialisim:"  meta:resourcekey="Specialisim" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label3" Text='<%# Eval("Specialisim") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Study Type:" meta:resourcekey="StudyType" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label4" Text='<%#Prtl_SCPapersUtility.GetStudyType (Eval("Prtl_Thesi.ID").ToString() )%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisors1:" meta:resourcekey="supervisors1" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label5" Text='<%# Prtl_SCPapersUtility.GetSupervisors1( Eval("Prtl_Thesi.ID").ToString()) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisors2:" meta:resourcekey="supervisors2" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label5" Text='<%# Prtl_SCPapersUtility.GetSupervisors2( Eval("Prtl_Thesi.ID").ToString()) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Researcher Name:" meta:resourcekey="researcher" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label6" Text='<%# Eval("StudentName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Title:" meta:resourcekey="Title" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label6" Text='<%# Eval("Address") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Summery:" meta:resourcekey="Summery" >
                   
                    <ItemTemplate>
                        <asp:Label ID="Label6" Text='<%# Eval("Summary") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Registration Date:"  meta:resourcekey="UnivDate" >
                    <ItemTemplate>
                        <asp:Label ID="Label6" Text='<%#StaticUtilities.FormatDate(Eval("Prtl_Thesi.RegistrationDate").ToString())  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Disscusion Date:" meta:resourcekey="FacDate" >      
                    <ItemTemplate>
                        <asp:Label ID="Label6" Text='<%#StaticUtilities.FormatDate(Eval("Prtl_Thesi.DisscusionDate").ToString()) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File:" meta:resourcekey="File" >      
                    <ItemTemplate>
                         <a href='<%#ThesisFile(Eval("ID")) %>'  >
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Prtl_Thesi.FileName") %>' meta:resourcekey="file"></asp:Label>
                </a>                     </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <AlternatingRowStyle CssClass="Editor_AlternatingRowStyle" />
            <CommandRowStyle CssClass="Editor_CommandRowStyle" />
            <EditRowStyle CssClass="Editor_EditRowStyle" />
            <FieldHeaderStyle CssClass="Editor_FieldHeaderStyle" />
            <FooterStyle CssClass="Editor_FooterStyle" />
            <HeaderStyle CssClass="Editor_HeaderStyle" />
            <PagerStyle CssClass="Editor_PagerStyle" HorizontalAlign="Center" />
            <RowStyle CssClass="Editor_RowStyle" />
        </asp:DetailsView>
    </div>
</asp:Panel>
            

            </ContentTemplate>
    </asp:UpdatePanel>
    

</asp:Content>
