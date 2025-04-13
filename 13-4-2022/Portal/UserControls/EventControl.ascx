 <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.EventControl" %>


<%--<script type="text/javascript" src="../../Styles/University_Master/jquery/new_slider/script-min.js"></script>--%>

<script type="text/javascript"  src="../../Styles/University_Master/jquery/new_slider/script.js"></script>

<link href="../../Styles/University_Master/css/New_slider/slider_styles.css" rel="stylesheet" />

<%@ Import Namespace="Common" %>
<asp:ListView ID="NewsListView" runat="server" >
    <%-- For a different style for every other element in News , Alternating with a background and the item template with no background--%>
    <ItemTemplate>

        <div class="slide">

       
        <div class="slideCopy">
            
                    <h1>
                    
                    <asp:Label runat="server" CssClass="NewsBody" Text='<%#  getData(Convert .ToInt32 ( Eval("Highlight_Id"))) %>' ID="News_BodyLabel"></asp:Label>

                         </h1>
            
           </div >
           <div class="more_button"> 
                <%--<asp:HyperLink ID="HyperLink1" runat="server" cssclass="more-link" NavigateUrl='<%# Eval("ID", "~/EventDetails.aspx?lang=ar&ID={0}") %>' Text='<%$Resources:Resource, ReadMore%>'></asp:HyperLink>--%>

        </div>
         
             <img alt="" width="20" height="20" src='<%# URLBuilder.Path(Page, PathType.WebServer,SiteFolders.Events ,Eval("Image") ?? URLBuilder.DefaultImageName) %>'/>
              
        
    </div>
 
         
    </ItemTemplate>

    <EmptyDataTemplate>
        <asp:Label ID="NoDataLabel" Text="No Data"   runat="server" />
    </EmptyDataTemplate>

    <LayoutTemplate>
        
      
            
                <div id="itemPlaceholderContainer" runat="server">
                    <div runat="server" id="itemPlaceholder" />

            </div>
          
    
    </LayoutTemplate>
</asp:ListView>


<asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext"  
    TableName="prtl_Translations" 
    Where="prtl_Language.LCID == @LCID&amp;&amp; prtl_Highlight.Published == True &amp;&amp; prtl_Highlight.prtl_Owner.Abbr == @Owner">
     <WhereParameters>
         
        <asp:RouteParameter Name="Owner" RouteKey="currentowner" Type="String" />
        <asp:RouteParameter Name="LCID" RouteKey="lang" Type="String" />
    </WhereParameters>

</asp:LinqDataSource>