<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/CouncilMaster.Master" AutoEventWireup="true" CodeBehind="PublicationList.aspx.cs" Inherits="MnfUniversity_Portals.UI.PublicationList" %>
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
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
     
         <ContentTemplate>
       <table style="width: 200px;font-weight: bold">
    <tr>
    <td><asp:Label ID="Label1" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> <asp:DropDownList AppendDataBoundItems="true" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" ID="FacDropDownList" CssClass="textboxservice2"  runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="BLL.prtl_ThesisUtility">
                            </asp:ObjectDataSource>
                    </td></tr>
         
          <tr>
    <td><asp:Label ID="lblAuthor" runat="server" Text="Title" meta:resourcekey="Title"></asp:Label></td>
                 
       <td> <asp:TextBox ID="txtTitle" CssClass="textboxservice2" runat="server"></asp:TextBox></td>

          </tr>
          <tr>
    <td><asp:Label ID="Label3" runat="server" Text="keywords" meta:resourcekey="keywords"></asp:Label></td>
                 
       <td> <asp:TextBox ID="txtKeywords" CssClass="textboxservice2" runat="server"></asp:TextBox></td>

          </tr>
         
         <tr>
          <td><asp:Label ID="Label9" runat="server" Text="Author Name:" meta:resourcekey="Authorname"></asp:Label></td>
             
                    <td> 
<asp:TextBox ID="txtAuthorName" CssClass="textboxservice2" runat="server"></asp:TextBox>
                                            </td>


      </tr>
         
      <tr><td>
              <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn1" OnClick="SearchButtonClicked" meta:resourcekey="Search"/>
              
           </td></tr>   
         
         
         

     </table><br/>
    
    




    <asp:Label ID="Label2" runat="server"  ></asp:Label><br/><br/><br/>
   
    
    
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="thesesstyle" OnPageIndexChanging="gridview_PageIndexChanging" PageSize="10"  AllowPaging="True" CellPadding="4" BorderWidth="2" BorderColor="#cccccc" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    
                <asp:Label Text='<%# Eval("title") %>' runat="server"   ID="News_dateLabel" />
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Authors">
                <ItemTemplate>
                <asp:Label Text='<%# GetAuthorsByPublicationID(Convert.ToInt32(Eval("id"))) %>' runat="server" ID="authornames" />
                    </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Start Date">
                <ItemTemplate>
                <asp:Label Text='<%# StaticUtilities.FormatDate(DateTime.Parse(Eval("start_date").ToString())) %>' runat="server" ID="Owner_IDLabel" />
                    </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Year">
                <ItemTemplate>
                <asp:Label Text='<%# Eval("year").ToString() %>' runat="server" ID="Label4" />
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Abstract">
                <ItemTemplate>
                <asp:Label Text='<%# Eval("abstract") %>' runat="server" ID="prtl_News_TranslationsLabel" />
                    </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

        <FooterStyle BackColor="#dedddc" Font-Bold="True" Height="30" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" Height="30" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#dedddc" ForeColor="red"></PagerStyle>

        <RowStyle BackColor="#E3EAEB" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc"></RowStyle>

        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
    </asp:GridView>

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
