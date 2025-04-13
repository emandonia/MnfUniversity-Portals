<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsSearchControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.NewsSearchControl" %>--%>
<%@ Control AutoEventWireup="True" CodeBehind="NewsSearchControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.NewsSearchControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>


<asp:Panel OnLoad="ManageNewsItemPanel_Load" ID="Panel1" runat="server">
    <asp:LinkButton ID="AddNewsItemButton" OnClick="AddNewsItemButton_Click" runat="server">
        <asp:Image ID="Image1" ImageUrl="~/styles/UserControlImages/insert.png" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Add NewsItem" meta:resourcekey="AddNew"></asp:Label>
    </asp:LinkButton>
</asp:Panel>


    <asp:Label ID="lblCounter" runat="server" Text="" meta:resourcekey="Counter"></asp:Label>

<asp:ListView ID="NewsListView" runat="server" AllowPaging="True" PageSize="100"  OnPagePropertiesChanging="NewsListView_OnPagePropertiesChanging" DataSourceID="NewsLinqDataSource" DataKeyNames="id" >
    <EmptyDataTemplate>
        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
            <tr>
                <td>No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    
    <ItemTemplate>
     <div class="Reg">
          <tr class="firstrow" style="background-color: #DCDCDC; color: #000000;">
               
            
                 <td>
                  <asp:Label ID="LblDate" runat="server" Text='<%# getNewsDate(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' />
              </td> 
              <td>
                  <asp:Label ID="News_HeadLabel" runat="server" Text='<%# Eval("News_Head") %>' />
              </td> 
              
              

              <td>
                         <div id="more_news"> <h3  style="float: <%= StaticUtilities.FloatLeft%>">
                            <asp:HyperLink class="btn btn_" ID="MoreHyperLink1"
                                runat="server"  meta:resourcekey="MoreHyperLink1Resource1"
                                NavigateUrl='<%# URLBuilder.UniNewItemUrl(Page.RouteData,(int) Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData),"NewsViewerControl1") %>'
                                Text="المزيد..."></asp:HyperLink></h3></div>
              </td>
              <td>
                  <asp:HyperLink  ID="HyperLink1"
                                runat="server"  
                                NavigateUrl='<%# URLBuilder.UniNewItemUrl(Page.RouteData,(int) Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData),"NewsViewerControl1") %>'
                                Text='<%# URLBuilder.UniNewItemUrl(Page.RouteData,(int) Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData),"NewsViewerControl1") %>'></asp:HyperLink>
                  </td>
          </tr>
         
       </div>
                    
    </ItemTemplate>
    
    
         <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        
                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                            <th id="Th1"   runat="server"  ><asp:Label ID="Label2" runat="server"    meta:resourcekey="LblDate0"></asp:Label></th>
                                           
                                            <th   runat="server"  ><asp:Label ID="LblNewsTitle" runat="server"    meta:resourcekey="LblNewsTitle"></asp:Label></th>
                                             <th><asp:Label ID="LblMore" runat="server" CssClass="btn_reg"    meta:resourcekey="LblMore"></asp:Label></th>
                                            <th><asp:Label ID="Label4" runat="server"   Text="URL"></asp:Label></th>
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder">
                                              </tr>
                                        <tr>
            <td colspan = "3">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="NewsListView" PageSize="100">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
                                    </table>
                                </td>
                               
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000"></td>
                            </tr>
                        </table>
                    </LayoutTemplate>
    
    
</asp:ListView>

<asp:LinqDataSource ID="NewsLinqDataSource" OnSelecting="NewsLinqDataSource_Selecting"  OnDataBinding ="NewsLinqDataSource_OnDataBinding"
     runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EntityTypeName=""  Where="prtl_Language.LCID == @prtl_Language " >
    <WhereParameters>
        <asp:RouteParameter Name="prtl_Language" RouteKey="lang" Type="String" />
         <%--  <asp:RouteParameter Name="Owner" RouteKey="currentowner" Type="String" /> &amp;&amp; prtl_news.prtl_Owner.Abbr == @Owner--%>
        
    </WhereParameters>
    
</asp:LinqDataSource>
<asp:Panel OnLoad="ManageNewsItemPanel_Load" ID="ManageNewsDetailsItemPanel" runat="server">
    <uc:NewsDetailsViewControl OnDetailsView_ItemInserted="InlineNewsDetailsViewControl_ItemAdded" OnDetailsView_ItemUpdated="InlineNewsDetailsViewControl_ItemUpdated"
        ID="InlineNewsDetailsViewControl" runat="server" />
</asp:Panel>

