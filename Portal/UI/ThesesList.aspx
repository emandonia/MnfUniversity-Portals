<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/CouncilMaster.Master" AutoEventWireup="true" CodeBehind="ThesesList.aspx.cs" Inherits="MnfUniversity_Portals.UI.ThesesList" %>
<%@ Import Namespace="MnfUniversity_Portals.BLL.MIS_BLL" %>


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
    <td><asp:Label ID="Label1" Style="font-size:20px;" runat="server" Text="Choose Faculty:" meta:resourcekey="Fac"></asp:Label></td>
                 
                    <td> <asp:DropDownList AppendDataBoundItems="true" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" ID="FacDropDownList" CssClass="textboxservice2"  runat="server">
                                <asp:ListItem Value="-1" Text="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="BLL.prtl_ThesisUtility">
                            </asp:ObjectDataSource>
                    </td></tr>
         
          <tr>
    <td><asp:Label ID="lblAuthor" runat="server" Style="font-size:20px;" Text="Title" meta:resourcekey="Title"></asp:Label></td>
                 
       <td> <asp:TextBox ID="txtTitle" CssClass="textboxservice2" runat="server"></asp:TextBox></td>

          </tr>
          <tr>
    <td><asp:Label ID="Label3" Style="font-size:20px;" runat="server" Text="Title" meta:resourcekey="keywords"></asp:Label></td>
                 
       <td> <asp:TextBox ID="txtKeywords" CssClass="textboxservice2" runat="server"></asp:TextBox></td>

          </tr>
         
         <tr>
          <td><asp:Label ID="Label9" runat="server" Text="Study Type:" meta:resourcekey="SearchType"></asp:Label></td>
                 
                    <td> <asp:DropDownList ID="DropDownList2" CssClass="textboxservice2" runat="server">
                             
                         <asp:ListItem Value="-1" meta:resourcekey="SearchType"></asp:ListItem>
                         <asp:ListItem Value="bachelor" ></asp:ListItem>
                        <asp:ListItem Value="master" ></asp:ListItem>
                        <asp:ListItem Value="phd" ></asp:ListItem>
                         </asp:DropDownList>

                                            </td>


      </tr>
         
      <tr><td>
              <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn3" OnClick="SearchButtonClicked" meta:resourcekey="Search"/>
              
           </td></tr>   
         
         
         

     </table><br/>
    
    




    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ></asp:Label><br/><br/><br/>


     <asp:ListView ID="ListView1" OnPagePropertiesChanging="ListView2_OnPagePropertiesChanging" runat="server" >

            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="Label" meta:resourcekey="NoData"></asp:Label></td>
                            
                    </tr>
                </table>
            </EmptyDataTemplate>

            <ItemTemplate>
                     <div id="resultsDiv">
                        <div class="pageContainer" style="display: block;">

                            <div class="webResult" style="width: 100%; direction: <%=StaticUtilities.Dir%>; text-align: <%=StaticUtilities.Textright%>;">

                                <h2>
                                     <asp:Label ID="Label12" runat="server" Text="عنوان الرسالة: " meta:resourcekey="title" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("title") %>' runat="server" ID="AddressLabel" Font-Bold="True" />

                                </h2>
                                 <p>
                                    <asp:Label ID="Label5"  runat="server" Text="الكلية:"  meta:resourcekey="fac" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#GetFacName( Eval("id_research_area")) %>' runat="server" ID="Label6" Font-Bold="True" /><br />

                                   
                                </p>
                                <p>
                                    <asp:Label ID="Label7"  runat="server" Text="الدرجة العلمية:"  meta:resourcekey="SearchType" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("degree") %>' runat="server" ID="EngMainResNameLabel" Font-Bold="True" /><br />

                                   
                                </p>
                                <p>
                                    <asp:Label ID="Label8"  runat="server" Text="تاريخ البداية:"  meta:resourcekey="sdate" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#StaticUtilities.FormatDate(DateTime.Parse(Eval("start_date").ToString())) %>' runat="server" ID="Label9" Font-Bold="True" /><br />

                                   
                                </p>
                                    <p>
                                    <asp:Label ID="Label10"  runat="server" Text="تاريخ المناقشة:"  meta:resourcekey="edate" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#StaticUtilities.FormatDate(DateTime.Parse(Eval("end_date").ToString())) %>' runat="server" ID="Label11" Font-Bold="True" /><br />

                                   
                                </p>
                                <p>
                                    <asp:Label ID="Label2"  runat="server" Text="ملخص الرسالة:"  meta:resourcekey="desc" Font-Bold="True" Font-Size="X-Large"></asp:Label>&nbsp;&nbsp;<asp:Label Text='<%#Eval("description")%>' runat="server" ID="Label3" Font-Bold="True" /><br />

                                   
                                </p>
                               
                       
                                 
                                 
                                
                                
                            </div>
                        </div>
                    </div>


            </ItemTemplate>
            <LayoutTemplate>
                    <div runat="server" id="itemPlaceholderContainer">

                        <div runat="server" id="itemPlaceholder">
                        </div>

                        <asp:DataPager runat="server"  ID="DataPager1"  PagedControlID="ListView1"  PageSize="15">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                <asp:NumericPagerField></asp:NumericPagerField>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                     
                </div>
            </LayoutTemplate>

            </asp:ListView>

    
    
    
    
 

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