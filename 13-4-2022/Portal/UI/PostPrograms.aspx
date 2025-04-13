<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="PostPrograms.aspx.cs" Inherits="MnfUniversity_Portals.UI.PostPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1"  UpdateMode="Conditional" runat="server">
        
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_OnClick" />
            <ajaxtk:Accordion 
                    ID="Accordion1"
                    CssClass="tab"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent"
                    runat="server" >
                    <Panes>
                        <ajaxtk:AccordionPane ID="AccordionPane1" ToolTip="Diploma" runat="server">
                            <Header>
                                <asp:Label ID="Label1" runat="server" Text="Diploma" meta:resourcekey="PdLabelResource1"></asp:Label>
                            </Header>
                            <Content >
                               
                                  <asp:ListView ID="ListView1" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#DipPorgUrl(Common.URLBuilder.CurrentOwnerAbbr(Page.RouteData).ToString(),Eval("ID").ToString())%>'
                                    Text='<%#Eval("Name")%>'></asp:HyperLink>


                                        </li>

                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <ul runat="server" id="itemPlaceholderContainer">

                                            <li runat="server" id="itemPlaceholder"></li>

                                        </ul>
                                    </LayoutTemplate>
                                </asp:ListView>
                                
                            </Content>
                        </ajaxtk:AccordionPane>
                        <ajaxtk:AccordionPane ID="AccordionPane2" ToolTip="Master" runat="server">
                            <Header>
                                <asp:Label ID="Label2" runat="server" Text="Master" meta:resourcekey="PdLabelResource1"></asp:Label>
                            </Header>
                            <Content >
                               <asp:ListView ID="ListView2" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#MasterPorgUrl(Common.URLBuilder.CurrentOwnerAbbr(Page.RouteData).ToString(),Eval("ID").ToString())%>'
                                    Text='<%#Eval("Name")%>'></asp:HyperLink>


                                        </li>

                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <ul runat="server" id="itemPlaceholderContainer">

                                            <li runat="server" id="itemPlaceholder"></li>

                                        </ul>
                                    </LayoutTemplate>
                                </asp:ListView>
                                  
                                
                            </Content>
                        </ajaxtk:AccordionPane>
                         <ajaxtk:AccordionPane ID="AccordionPane3" ToolTip="Phd" runat="server">
                            <Header>
                                <asp:Label ID="Label3" runat="server" Text="Phd" meta:resourcekey="PdLabelResource1"></asp:Label>
                            </Header>
                            <Content >
                               <asp:ListView ID="ListView3" runat="server">
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="NoData" Text="No data was returned." />
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#PhdPorgUrl(Common.URLBuilder.CurrentOwnerAbbr(Page.RouteData).ToString(),Eval("ID").ToString())%>'
                                    Text='<%#Eval("Name")%>'></asp:HyperLink>


                                        </li>

                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <ul runat="server" id="itemPlaceholderContainer">

                                            <li runat="server" id="itemPlaceholder"></li>

                                        </ul>
                                    </LayoutTemplate>
                                </asp:ListView>
                                  
                                
                            </Content>
                        </ajaxtk:AccordionPane>
                        </Panes>
                </ajaxtk:Accordion>

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
