<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="ResFieldsReports.aspx.cs" Inherits="MnfUniversity_Portals.UI.ResFieldsReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>


             <asp:Label ID="Label3" runat="server"  Text="برجاء اختيار الكلية او القسم ." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 500px;">
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label1"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" AutoPostBack="true"   DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList" CssClass="textboxservice2" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="FacDropDownList" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList" CssClass="textboxservice2" Enabled="false" DataTextField="DepName"
                                DataValueField="ID"  runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr> <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn3" ID="Button1" runat="server" Text="Search" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click" />
                        </td></tr>
                    </table><br /><br />

                <asp:Label ID="Label16" runat="server" Font-Bold="true" Font-Size="X-Large" Visible="false"></asp:Label>


                <asp:ListView ID="ListView1" runat="server" OnPagePropertiesChanging="ListView2_OnPagePropertiesChanging">

                  
                   
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>

                 
                    <ItemTemplate>
                        <tr style="">
                            <td class="col5" >
                                <asp:Label Text='<%# Eval("field") %>' runat="server" ID="IDLabel" style="padding-left:15px;"  /></td>
                            <td class="col6">
                                <asp:Label Text='<%# Eval("count") %>' runat="server" ID="Stf_IDLabel" style="padding-left:15px;" /></td>

                           
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table runat="server" id="itemPlaceholderContainer" class="stafftable" style="width: 500px;direction:ltr;font-family: Verdana, Arial, Helvetica, sans-serif;" >
                                        <tr runat="server" style="">
                                            <th runat="server"  ><asp:Label  runat="server" ID="Stf_IDLabel2" meta:resourcekey="resLabelResource1" style="text-align:center;padding-right:150px" /></th>
                                            <th runat="server" ><asp:Label  runat="server" ID="Label4" meta:resourcekey="countLabelResource1" style="text-align:center;padding-right:25px"/></th>

                                            
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="">
                                     <asp:DataPager runat="server"  ID="DataPager1"  PagedControlID="ListView1"  PageSize="50">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

               
                </asp:ListView>




               


                <%-- <table id="stftable" style="font-size:large">
                   <tr>
                    <td style="padding-right:30px;">
                        <td style="padding-right:30px;">
                        <ul style="direction:ltr;font:bold" >
<div runat="server" id="link">
    
</div>

</ul>
         
                            
                       </td>
                    </tr>
                </table>--%>
                    

                   
               
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
