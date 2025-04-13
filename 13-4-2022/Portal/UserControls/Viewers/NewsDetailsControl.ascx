<%@ Control AutoEventWireup="True" CodeBehind="NewsDetailsControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.NewsDetailsControl"
    Language="C#" %>
<%@ Import Namespace="Common" %>
<div >
    <asp:FormView ID="NewsDetailsFormView" runat="server" DataSourceID="NewsDetailsDataSource">
        <ItemTemplate>



                 <div class="col-1-3">
                        <div id="ImageDiv" class="ImageDetails">
                       
                             <img width="20" height="20" alt='<%#Eval("Img_alt")%>' src='<%# BigImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'/>
                     
                         <%--   <fz:ImageZoom ID="NewsDetailsImageZoom" ImageAltText="View Image" ImageClass="smallThumbnail"
                                BigImageURL='<%# BigImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' SmallImageURL='<%# SmallImageURL(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>'
                                ImageTitle="" runat="server" />--%>
                           
                          
                        </div>
                         </div>

              
           
                    <div class="col-2-4">
                    <div  id="ContentDiv" >
                        
					<div class="NewsDetails">
					<div class="art-content t-center">
                        <div style="float: <%= StaticUtilities.FloatRight%>;" id="titleDiv">
                          <h3> <asp:Label ID="News_HeadLabel" runat="server" Text='<%# Eval("News_Head") %>' /></h3>
                        </div>
                        <div class="NewsPublishDate"  id="AddressDiv">
                         <h2><asp:Label ID="News_SourceLabel" runat="server" Text='<%# Eval("News_Source") %>' /></h2>
                       
                        <h2> <asp:Label ID="News_dateLabel" runat="server" Text='<%# getNewsDate(Eval("News_Id"),URLBuilder.CurrentOwnerAbbr(Page.RouteData)) %>' />
                            </h2>
                       </div>
                       <h4> <asp:Label Text='<%# Decode(Eval("News_Body")) %>' ID="News_BodyLabel"
                            runat="server" /></h4>
                    </div>

								</div>

                    </div></div>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                    <p>
                        &nbsp;
                    </p>
                   
               
           
           
        </ItemTemplate>
    </asp:FormView>
</div>
                   <asp:LinqDataSource ID="NewsDetailsDataSource" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
    EntityTypeName=""  >
   
</asp:LinqDataSource>
