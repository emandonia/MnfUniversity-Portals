<%@ Control AutoEventWireup="True" CodeBehind="NewsViewerControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.NewsViewerControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>

<asp:Panel OnLoad="ManageNewsItemPanel_Load" ID="Panel1" runat="server">
    <asp:LinkButton ID="AddNewsItemButton" OnClick="AddNewsItemButton_Click" runat="server">
        <asp:Image ID="Image1" ImageUrl="~/styles/UserControlImages/insert.png" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Add NewsItem" meta:resourcekey="AddNew"></asp:Label>
    </asp:LinkButton>
</asp:Panel>


<asp:ListView ID="NewsListView" runat="server" DataSourceID="NewsLinqDataSource">
    <%-- For a different style for every other element in News , Alternating with a background and the item template with no background--%>
    <ItemTemplate>
     
         
           <div class="col-1-4">
                        <div class="wrap-col item">	
                 <div class="zoom-container">
               
                      <img width="20" height="20" src='<%# BigImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'/>
                  

                  <%--  <fz:ImageZoom ID="NewsImageZoom" BigImageURL='<%# BigImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                        SmallImageURL='<%# SmallImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' ImageAltText="News Image"
                        ImageClass="smallThumbnail" ImageTitle="" runat="server" />
              --%>
                         </div>
                  <div class="item-content">
                                        <h1 class="NewsTitle">
                            <asp:HyperLink ID="News_HeadLabel"
                                runat="server" NavigateUrl='<%# URLBuilder.UniNewItemUrl(Page.RouteData,(int) Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData),ID) %>'
                                Text='<%# Bind("News_Head") %>'></asp:HyperLink>
                        </h1>
                        <h4 class="NewsPublishDate">
                            <asp:Label ID="lbl" runat="server" meta:resourcekey="lblResource1" Text="Published On :"></asp:Label>
                            <asp:Label ID="News_dateLabel2" runat="server" Text='<%# getNewsDate(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' /></h4>
                        
                      <h1 class="NewsTitle">
                        <asp:Label class="NewsAbbr" ID="News_AbbrLabel2" Text='<%# GetNewsAbbr(Eval("News_Abbr").ToString()) %>' runat="server" />
                      </h1>
                      
                     </div>
                
          <div id="more_news"> <h3  style="float: <%= StaticUtilities.FloatLeft%>">
                            <asp:HyperLink CssClass="btn_more" ID="MoreHyperLink1"
                                runat="server" Text="More..."  meta:resourcekey="MoreNews"
                                NavigateUrl='<%# URLBuilder.UniNewItemUrl(Page.RouteData,(int) Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData),ID) %>'
                              ></asp:HyperLink></h3></div>
                 

                            </div></div>
                            
                            
                           <%-- 
                            <div><asp:Panel Style="width: 100px; border: 1px solid black; border-radius: 20px; background-color: white" OnLoad="ManageNewsItemPanel_Load" ID="ManageNewsItemPanel" runat="server">
                            <asp:HyperLink Style="cursor: pointer;" ID="OpenActionsPanel" runat="server">
                                <asp:Image ID="Image5" ImageUrl="~/styles/UserControlImages/manage.png" runat="server" />
                                <asp:Label ID="Label5" runat="server" meta:resourcekey="ManageAll" Text="Manage All"></asp:Label>
                            </asp:HyperLink>
                            <ajaxtk:PopupControlExtender TargetControlID="OpenActionsPanel" Position="Bottom" PopupControlID="ActionsPanel" ID="ActionsPopupControlExtender" runat="server" Enabled="True" OffsetX="0"></ajaxtk:PopupControlExtender>
                            <asp:Panel ID="ActionsPanel" Style="border: 1px solid black; border-radius: 2px; background-color: white; width: 140px" runat="server">
                                <asp:LinkButton ID="Edit_ImageButton" CommandArgument='<%#Eval("News_Id") %>' OnClick="EditImageButton_Click" runat="server">
                                    <asp:Image ID="Image1" ImageUrl="~/styles/UserControlImages/edit.png" runat="server" />
                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="Edit" Text="Edit"></asp:Label>
                                </asp:LinkButton>

                                <asp:LinkButton ID="Manage_ImageButton" CommandArgument='<%#Eval("News_Id") %>' OnClick="ManageImageButton_Click" runat="server">
                                    <br />
                                    <asp:Image ID="Image3" ImageUrl="~/styles/UserControlImages/language.png" runat="server" />
                                    <asp:Label ID="Label3" runat="server" meta:resourcekey="Manage" Text="Manage"></asp:Label>
                                </asp:LinkButton>

                                <asp:LinkButton Visible='<%#InlineNewsDetailsViewControl.ShowInsertButton %>' ID="InsertTranslation_ImageButton" CommandArgument='<%#Eval("News_Id") %>' OnClick="InsertTranslation_Click" runat="server">
                                    <br />
                                    <asp:Image ID="Image4" ImageUrl="~/styles/UserControlImages/insert.png" runat="server" />
                                    <asp:Label ID="Label4" runat="server" meta:resourcekey="InsertTranslation" Text="Insert Translation"></asp:Label>
                                </asp:LinkButton>

                                <asp:LinkButton ID="DeleteButton" CommandArgument='<%#Eval("News_Id") %>' OnClick="DeleteButton_Click" OnClientClick='return confirm("Are you sure you want to delete this entry?");' runat="server">
                                    <br />
                                    <asp:Image ID="Image2" ImageUrl="~/styles/UserControlImages/delete.png" runat="server" />
                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="Delete" Text="Delete"></asp:Label>
                                </asp:LinkButton>

                                <asp:LinkButton Visible='<%#InlineNewsDetailsViewControl.ShowDeleteButton %>' ID="DeleteTranslationLinkButton" CommandArgument='<%#Eval("id") %>' OnClick="DeleteTranslationLinkButton_Click" OnClientClick='return confirm("Are you sure you want to delete this entry?");' runat="server">
                                    <br />
                                    <asp:Image ID="Image6" ImageUrl="~/styles/UserControlImages/delete.png" runat="server" />
                                    <asp:Label ID="Label6" runat="server" meta:resourcekey="DeleteTrans" Text="Delete Translation"></asp:Label>
                                </asp:LinkButton>
                            </asp:Panel>
                        </asp:Panel>
           </div>--%>
            
         
       
                    
    </ItemTemplate>
    <EmptyDataTemplate>
        <asp:Label ID="NoDataLabel" meta:resourcekey="NoDataLabelResource1" runat="server" Text="No data was returned." />
    </EmptyDataTemplate>
    <LayoutTemplate>
        
          
    
        <div id="itemPlaceholderContainer" runat="server">
            <div runat="server" id="itemPlaceholder" />

        </div>
             
    </LayoutTemplate>
</asp:ListView>

<asp:LinqDataSource ID="NewsLinqDataSource" OnSelecting="NewsLinqDataSource_Selecting"
     runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EntityTypeName=""  Where="prtl_Language.LCID == @prtl_Language" >
    <WhereParameters>
        <asp:RouteParameter Name="prtl_Language" RouteKey="lang" Type="String" />
         
        
    </WhereParameters>
    
</asp:LinqDataSource>
<asp:Panel OnLoad="ManageNewsItemPanel_Load" ID="ManageNewsDetailsItemPanel" runat="server">
    <uc:NewsDetailsViewControl OnDetailsView_ItemInserted="InlineNewsDetailsViewControl_ItemAdded" OnDetailsView_ItemUpdated="InlineNewsDetailsViewControl_ItemUpdated"
        ID="InlineNewsDetailsViewControl" runat="server" />
</asp:Panel>

