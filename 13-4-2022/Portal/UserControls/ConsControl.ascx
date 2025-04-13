<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="ConsControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.ConsControl" %>
<%@ Import Namespace="Common" %>

<script src="../js/slider/script-min.js"></script>

<link href="../css/slider/slider_styles.css" rel="stylesheet" />
<script src="../js/slider/script.js"></script>

<asp:ListView ID="NewsListView" runat="server">
    <%-- For a different style for every other element in News , Alternating with a background and the item template with no background--%>
    <ItemTemplate>

       
                
             <asp:HyperLink ID="HyperLink1"    Visible ='<%# getVisible() %>' 
                    NavigateUrl='<%# Eval("ID", "~/ConsDetails.aspx?lang=ar&ID={0}") %>'
                  runat="server" ImageUrl='<%#Eval("Image") %>' >
                   
             </asp:HyperLink>
              
                   <asp:HyperLink ID="HyperLink2"    Visible ='<%# getVisible2() %>' 
                    NavigateUrl='<%# Eval("ID", "~/ConsDetails.aspx?lang=en&ID={0}") %>'
                  runat="server" ImageUrl='<%#Eval("Image") %>' >
                   
             </asp:HyperLink>
             
         
    </ItemTemplate>

    <EmptyDataTemplate>
        <asp:Label ID="NoDataLabel" Text="<%$Resources:Resource, NoDataLabelResource1%>"   runat="server" />
    </EmptyDataTemplate>

    <LayoutTemplate>
        
      
            
                <div id="itemPlaceholderContainer" runat="server">
                    <div runat="server" id="itemPlaceholder" />

            </div>
          
    
    </LayoutTemplate>
</asp:ListView>


<%--OnSelecting="NewsLinqDataSource_Selecting"--%>
<asp:LinqDataSource ID="NewsLinqDataSource"
    runat="server" ContextTypeName="Al_Arabia.DataClasses1DataContext"
    TableName="Eventes" EntityTypeName="" OrderBy="startdate desc">
  <%--  <WhereParameters>
        <asp:RouteParameter Name="prtl_Language" RouteKey="lang" Type="String" />
         
        
    </WhereParameters>--%>

    
</asp:LinqDataSource>