     <%@ Control AutoEventWireup="True" CodeBehind="ViewControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.ViewControl"
    Language="C#" %>
<div >
    <asp:FormView ID="ViewerFormView" Width="100%" DataKeyNames="Article_ID" runat="server" DataSourceID="ArticleTranslationsDataSource">
        <EmptyDataTemplate>
            <div align="center">
                <asp:Image Style="clear: both;" ID="Image1" ImageUrl='<% #UnderConstructionImageurl%>'
                    AlternateText="Under construction" runat="server" />
                <div align="center">
                    <asp:Label ID="EmptyLabel" runat="server" Text=" This Page is  Under Constructoin" />
                </div>
            </div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="page_content_head">
                 <div id="arrowDiv" class="arrow_1" style="float: <%=floatright%>;" ></div>
                
                  <div id="titleDiv" style="float: <%=floatright%>;margin-top: 20px;">
                    <asp:Label ID="Title_DataLabel" runat="server" Text='<%# Eval("Title") %>' />
                </div>
            </div>
           
           
                        <div id="contentDiv" class="page_content_body" style="float: <%=floatright%>;padding:20px">
                            <asp:Label ID="Translation_DataLabel" runat="server" Text='<%# Decode (Eval("Actual_Content"),(int)Eval("T_id")) %>' />
                        </div>
                    
        </ItemTemplate>
    </asp:FormView>
</div>
<asp:LinqDataSource ID="ArticleTranslationsDataSource" runat="server" ContextTypeName=" Portal_DAL.PortalDataContextDataContext"
    EntityTypeName="" TableName="prtl_Articles_Translations" Where=" prtl_Language.LCID == @LCID &amp;&amp; prtl_Article.Abbr == @abbr &amp;&amp; prtl_Article.Published == True &amp;&amp; prtl_Article.prtl_Owner.Abbr == @Owner">
    <WhereParameters>
        <asp:RouteParameter Name="abbr" RouteKey="ArticleAbbr" Type="String" />
        <asp:RouteParameter Name="LCID" RouteKey="lang" Type="String" />
        <asp:RouteParameter Name="Owner" RouteKey="currentowner" Type="String" />
    </WhereParameters>
</asp:LinqDataSource>
<asp:Label ID="LblErorr" runat="server" Visible="False"></asp:Label>