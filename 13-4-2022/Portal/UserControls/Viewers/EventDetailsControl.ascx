<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventDetailsControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.EventDetailsControl" %>


<div >



    <asp:FormView ID="NewsDetailsFormView" runat="server" DataSourceID="NewsDetailsDataSource">
        <ItemTemplate>
         <%--   <div class="content_111">
                <div style="float: <%= StaticUtilities.FloatRight%>;" id="ArrowDiv" class="arrow1">
                </div>
                <div style="float: <%= StaticUtilities.FloatRight%>;" id="titleDiv">
                </div>
            </div>--%>
           

                    <div style="text-align: <%= StaticUtilities.FloatRight%>;" id="AddressDiv" class="events_address1">
                       <%-- <asp:Label ID="News_SourceLabel" runat="server" Text='<%# Eval("News_Source") %>' />--%>
                        <br /><asp:Label ID="lll1" runat="server" Text="" meta:resourcekey="label1text" /> &nbsp; &nbsp;
                        <asp:Label ID="News_dateLabel" runat="server" Text='<%# StaticUtilities.FormatDate(DateTime.Parse(Eval("prtl_Highlight.Start_Date").ToString())) %>' />
                        <br /><asp:Label ID="Label2" runat="server" Text="" meta:resourcekey="label2text" /> &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text='<%# StaticUtilities.FormatDate(DateTime.Parse(Eval("prtl_Highlight.End_Date").ToString())) %>' />
                    </div>
                    <div>
                        <div style="float: <%= StaticUtilities.FloatLeft%>;" id="ImageDiv" class="event_details">
                          
                            <fz:ImageZoom ID="NewsDetailsImageZoom" ImageAltText="View Image" ImageClass="smallThumbnail"
                                BigImageURL='<%# BigImageURL(Eval("prtl_Highlight.Image")) %>'  SmallImageURL='<%# SmallImageURL(Eval("prtl_Highlight.Image")) %>'
                                ImageTitle="" runat="server" />
                           
                            <div align="center">
                            </div>
                        </div>
                    </div>
                    <div style="float: <%= StaticUtilities.FloatRight%>;" id="ContentDiv" class="events_content_style1">
               <asp:Label runat="server" CssClass="NewsBody" Text='<%# Decode(Eval("Translation_Data")) %>' ID="News_BodyLabel"></asp:Label>
                           
                    </div>
                
                   
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
    EntityTypeName="" TableName="prtl_Translations" Where="  prtl_Highlight.Highlight_Id == @id &amp;&amp; prtl_Language.LCID == @LCID&amp;&amp; prtl_Highlight.Published == True &amp;&amp; prtl_Highlight.prtl_Owner.Abbr == @Owner">
    <WhereParameters>
        <asp:RouteParameter Name="id" RouteKey="id" Type="Int32" />
        <asp:RouteParameter Name="Owner" RouteKey="currentowner" Type="String" />
        <asp:RouteParameter Name="LCID" RouteKey="lang" Type="String" />
    </WhereParameters>
</asp:LinqDataSource>
