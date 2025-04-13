<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/CouncilMaster.Master" AutoEventWireup="true" CodeBehind="SearchGrade.aspx.cs" Inherits="MnfUniversity_Portals.UI.SearchGrade" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.Portal_BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
    </style>
    <link href="../../Styles/University_Master/css/grade.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   <asp:UpdatePanel UpdateMode="Conditional" runat="server">
        <ContentTemplate>
      <table   dir="rtl">
             <tr>
                        <td>
                            <asp:Label ID="Label6"  runat="server" Text="Choose Faculty"  meta:resourcekey="fa"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true"  DataTextField ="name" CssClass ="textboxservice2" DataValueField ="ID"   AutoPostBack="true" 
                                  ID="FacDropDownList"  OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>                         
                        
                        </td>
                    </tr>
             <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Choose Department" meta:resourcekey="db"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList" CssClass="textboxservice2" Enabled="false"  
                                  AutoPostBack="true" runat="server"
                                AppendDataBoundItems="true"
                                 >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server"  text ="Name" meta:resourcekey="na"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtName" runat="server" CssClass ="textboxservice2"></asp:TextBox>
                        </td>
                    </tr> 

                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="login_button3" meta:resourcekey="BtnSearch" Text="Search" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
             <asp:GridView ID="GridView1"  Width="100%" Height="100%"  OnPageIndexChanging="GridViewPageIndexChanging" runat="server" DataKeyNames="Id"  AllowPaging="True" PageSize="30" 
                                 CellPadding="4"  GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                           >                           
                           <Columns>
                               <asp:TemplateField HeaderText="nameG"   meta:resourcekey="nameG">
                                   <ItemTemplate>
                                       <div style="font-weight: bold; font-size: 14px">
                                           <asp:Label ID ="name" runat ="server"  
                                    Text='<%#Eval("StuNameA")%>'></asp:Label>
                                    </div> </ItemTemplate>
                               </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Details"  meta:resourcekey="Details" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Details" runat="server" CommandName="Select"   >
                                            <asp:Label ID ="ShowDetails" runat ="server"  meta:resourcekey="ShowDetails" ></asp:Label>

                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"  />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                           </Columns>
                           <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                           <AlternatingRowStyle CssClass ="grid_alternat1"></AlternatingRowStyle>

                           <FooterStyle CssClass="grid_footer1"></FooterStyle>

                           <HeaderStyle  CssClass="grid_header1"></HeaderStyle>

                           <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                           <RowStyle CssClass ="grid1"></RowStyle>

                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                           <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                           <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                           <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                           <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                       </asp:GridView></td>
                    </tr>

                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr><%--OnDataBound="DetailsView1_DataBound"--%>
                        <td colspan="2">
                                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"  
                            GridLines="None" Height="50px"  Visible="False"   OnDataBinding ="DetailsView1_DataBinding"
                            Width="100%" CellPadding="4" ForeColor="#333333" meta:resourcekey="DetailsView1Resource1" DataKeyNames="Id" DataSourceID="LinqDataSource1">
                            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FieldHeaderStyle CssClass="grid_header1"  />
                            <Fields>
                               <%--<asp:TemplateField HeaderText="<%$ Resources:TestResources, StuNameA %>"  >--%>
                                <asp:TemplateField HeaderText ="StuNameA" meta:resourcekey="StuNameA"     >
                                   <ItemTemplate > <asp:Label ID ="StuNameA" runat ="server"   Text='<%#Eval("StuNameA")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                  
                                 <asp:TemplateField HeaderText="StuNameE"  meta:resourcekey="StuNameE"  >
                                   <ItemTemplate > <asp:Label ID ="StuNameE" runat ="server"   Text='<%#Eval("StuNameE")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                
                               
                                
                                   <asp:TemplateField HeaderText="Adress"  meta:resourcekey="Adress"   >
                                   <ItemTemplate > <asp:Label ID ="Adress" runat ="server"   Text='<%#Eval("Adress")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="Tel"  meta:resourcekey="Tel"  >
                                   <ItemTemplate > <asp:Label ID ="Tel" runat ="server"   Text='<%#Eval("Tel")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                
                                  <asp:TemplateField HeaderText="Email"  meta:resourcekey="Email"   >
                                   <ItemTemplate > <asp:Label ID ="Email" runat ="server"  Text='<%#Eval("Email")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                               
                                   <asp:TemplateField HeaderText="faculty"  meta:resourcekey="faculty" >
                                   <ItemTemplate > <asp:Label ID ="faculty" runat ="server"   Text='<%# gradeUtility.gettrans(Convert.ToInt32  (Eval("FacID")),StaticUtilities .Currentlanguage (Page ))%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                 
                                <asp:TemplateField HeaderText="Department"  meta:resourcekey="Department" >
                                   <ItemTemplate > <asp:Label ID ="Department" runat ="server"  Text='<%# gradeUtility.gettrans(Convert.ToInt32  (Eval("DepID")),StaticUtilities .Currentlanguage (Page ))%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                
                             
                                <asp:TemplateField HeaderText="Grade"  meta:resourcekey="Grade"  >
                                   <ItemTemplate > <asp:Label ID ="Grade" runat ="server"  Text='<%#Eval("Grade")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                  
                                
                                    <asp:TemplateField HeaderText="WorkPlace"  meta:resourcekey="WorkPlace"  >
                                   <ItemTemplate > <asp:Label ID ="WorkPlace" runat ="server"   Text='<%#Eval("WorkPlace")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                  
                                   <asp:TemplateField HeaderText="Skills"  meta:resourcekey="Skills" >
                                   <ItemTemplate > <asp:Label ID ="Skills" runat ="server"   Text='<%#Eval("Skills")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                 
                                
                                
                                   <asp:TemplateField HeaderText="mobile"  meta:resourcekey="mobile"  >
                                   <ItemTemplate > <asp:Label ID ="mobile" runat ="server"  Text='<%#Eval("mobile")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="currentJob"  meta:resourcekey="currentJob"  >
                                   <ItemTemplate > <asp:Label ID ="currentJob" runat ="server"   Text='<%#Eval("currentJob")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="course"  meta:resourcekey="course"  >
                                   <ItemTemplate > <asp:Label ID ="course" runat ="server"  Text='<%#Eval("course")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="Year"  meta:resourcekey="Year" >
                                   <ItemTemplate > <asp:Label ID ="Year" runat ="server"   Text='<%#Eval("Year")%>'></asp:Label></ItemTemplate>
                               </asp:TemplateField>
                                 
                            </Fields>
                            <AlternatingRowStyle CssClass="grid_alternat1"  />
                            <PagerStyle BackColor="#2461BF" ForeColor="White"   />
                            <RowStyle CssClass="grid1"  />
                            <FooterStyle  height="35px"  CssClass="grid_footer1"   />
                            <HeaderStyle CssClass="grid_header1" Width ="100px"  />
                        </asp:DetailsView>
                                <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                                     EntityTypeName="" TableName="prtl_Students" Where="Id == @Id">
                                <WhereParameters>
                                <asp:ControlParameter ControlID="GridView1" DbType="Int32"  Name="Id" PropertyName="SelectedValue" />
                            </WhereParameters>
                                
                                </asp:LinqDataSource>
                       </td>
                    </tr>

                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

    </table>


            </ContentTemplate> </asp:UpdatePanel> 
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
