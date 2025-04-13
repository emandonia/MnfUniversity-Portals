<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master"
    AutoEventWireup="true" Inherits="MnfUniversity_Portals.UI.Home" CodeBehind="Home.aspx.cs" %>

<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<%--<%@ Register Src="~/UserControls/EventControl.ascx" TagPrefix="uc" TagName="EventControl" %>--%>



<asp:Content ID="Content5" ContentPlaceHolderID="Head" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
<meta name="google-site-verification" content="f8txnOzoaN4qVgO59Q-WozvHziN0pHJqaJjRoZX8wrI" />

     
 
    
      <%--@@@@@@ <script src="../Styles/University_Master/jquery/static_slider/script-min.js"></script>

    <script src="../Styles/University_Master/jquery/static_slider/script.js"></script>
    <link href="../Styles/University_Master/css/static_slider/slider_styles.css" rel="stylesheet" />--%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="EventsPlaceHolder" runat="server">






    <div class="zerogrid">
        <div class="row">
            <div class="col-1-1">
                <%--<div class="slide_img">
                <img src="../../Styles/University_Master/images/slider/slide.gif" />
                    </div>--%>

                <uc:EventSliderControl runat="server" id="EventSliderControl" />
                <div class="shadow"></div>
            </div>
            

        </div>

    </div>
    <%--<hr/>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">

    <%--<a href="http://melc.menofia.edu.eg/"><img onmouseout="this.src='<%=Eportal()%>';" onmouseover="this.src='<%=Eportal_hover() %>'"  title="البوابة الإلكترونية" alt="Eportal" src="<%=Eportal()%>" class="img_left imgshadow"></a>
    <asp:HyperLink ID="HyperLink1" runat="server"><img onmouseout="this.src='<%=Staffportal()%>';" onmouseover="this.src='<%=staffportal_hover() %>'" title="أعضاء هيئة التدريس" alt="staffportal" src="<%=Staffportal()%>" class="img_left imgshadow"></asp:HyperLink>
         <a href="http://www.menofia.edu.eg/projects/fldp_new/home.asp"><img onmouseout="this.src='<%=develpeStaff()%>';"onmouseover="this.src='<%=develpeStaff_hover() %>'" title=" تنمية قدرات أ.هـ التدريس " alt="developestaff" src="<%=develpeStaff()%>" class="img_left imgshadow"></a>
         <a href="http://mu.menofia.edu.eg/Library/LibraryHome/<%= StaticUtilities.Currentlanguage(Page) %>"> <img onmouseout="this.src='<%=Dlibrary()%>';" onmouseover="this.src='<%=Dlibrary_hover() %>'" title="بوابة المكتبة الالكترونية" alt="Dlibrary" src="<%=Dlibrary()%>" class="img_left imgshadow"></a>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
    <%--<asp:FormView ID="OwnerImageFormView" runat="server"    align="center" DataSourceID="DummyDataSource">
    <ItemTemplate >


        
     <a runat="server" ID="link1" href='<%#getLink1url() %>'><img onmouseout="this.src='<%=getimagesource() %>'"   src="<%=getimagesource()%>" class="img_left imgshadow"></a>
     <a runat="server" ID="link2" href='<%#getLink2url() %>'><img onmouseout="this.src='<%=Qgetimage2source()%>';" onmouseover="this.src='<%=Qgetimage2sourceHover()%>'"   src="<%=Qgetimage2source()%>" class="img_left imgshadow"></a>
    
      
     <a runat="server" ID="link3" href='<%#getLink3url() %>'><img onmouseout="this.src='<%=Sgetimage2source()%>';" onmouseover="this.src='<%=Sgetimage2sourceHover()%>'"     src="<%=Sgetimage2source()%>" class="img_left imgshadow"></a>
       
     <a runat="server" ID="link4" href='<%#getLink4url() %>'><img onmouseout="this.src='<%=Ogetimage2source()%>';" onmouseover="this.src='<%=Ogetimage2sourceHover()%>'"  src="<%=Ogetimage2source()%>" class="img_left imgshadow"></a>
     
    
     </ItemTemplate>
</asp:FormView>--%>
    <%-- <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
    TypeName="StaticUtilities"></asp:ObjectDataSource>--%>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="Server">




    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


            <section class="content-box box-1">
                <div class="row">

                    <uc:NewsViewerControl ID="NewsViewerControl1"  runat="server" />
                    <uc:NewsViewerControl ID="NewsViewerControl2" Visible="False"  TopNewsCounter="4" runat="server" />
	    <asp:Button ID ="Button2" CssClass="login_button" runat="server" OnClick="Button555_Click" meta:resourcekey ="MoreNews"></asp:Button>
			<asp:Button ID ="Button1" CssClass="login_button" visible="false" runat="server" Text="test" OnClick="Button1_Click1" ></asp:Button>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server"  ID ="panel1Manager" >
    <div class="zerogrid">
   <%-- <section class="content-box box-1" >
                <div class="row" id ="xx" >
                    <div class="pre_bg">
                     
                          <asp:Label ID="Label9"  CssClass="pre_st" runat="server" meta:resourcekey ="Mange"></asp:Label> 
                       
                     <div class="col-1-4">
                        <div class="wrap-col item">
                            
                            <div class="div_image">
                          <div class="circle-border zoom-in">
                               <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/meawad-home-ar" target="_blank"><img class="img-circle"  src="../Styles/University_Master/images/president.jpg" alt="president"></a>
                            
                               </div>
                                 <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/meawad-home-ar" target="_blank">
                                 <asp:Label ID="Label1" CssClass="h_style" runat="server" meta:resourcekey ="president"></asp:Label> 
                                 <asp:Label ID="Label2" CssClass="p_style" runat="server" meta:resourcekey ="title1"></asp:Label>
                             </a>
                                </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/student.jpg" alt="student">
                            </div>
                           
                                   <asp:Label ID="Label3" CssClass="h_style" runat="server" meta:resourcekey ="stu"></asp:Label> 
                                 <asp:Label ID="Label4" CssClass="p_style" runat="server" meta:resourcekey ="title2"></asp:Label>
                                 </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/graduat.jpg" alt="graduat">
                            </div>
                              <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/kased-home-ar" target="_blank">
                                   <asp:Label ID="Label5" CssClass="h_style" runat="server" meta:resourcekey ="gra"></asp:Label> 
                                 <asp:Label ID="Label6" CssClass="p_style" runat="server" meta:resourcekey ="title3"></asp:Label>
                                </a> 
                                   </div>
                         </div>
                        </div>
                    
                        <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/community.jpg" alt="community">
                            </div>
                           
                                 <asp:Label ID="Label7" CssClass="h_style" runat="server" meta:resourcekey ="comm2"></asp:Label> 
                                 <asp:Label ID="Label8" CssClass="p_style" runat="server" meta:resourcekey ="title4"></asp:Label>
                                 </div>
                         </div>
                        </div>

                 </div>

                    </div>
        </section>--%>
          <section class="content-box box-1" >
                <div class="row" id ="xx" >
                    <div class="pre_bg">
                     
                          <asp:Label ID="Label9"  CssClass="pre_st" runat="server" meta:resourcekey ="Mange"></asp:Label> 
                       
                    <%-- <div class="col-1-4">
                         <div class="wrap-col item">
                            
                            <a href="http://mu.menofia.edu.eg/prof.meawad/" target="_blank"><img class="img-circle"  src="../Styles/University_Master/images/president.jpg" alt="president"></a>--%>
                          <%-- <a href="http://mu.menofia.edu.eg/prof.meawad/" target="_blank">--%>
                             
                           <%-- <div class="div_image">
                          <div class="circle-border zoom-in">
                              <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/meawad-home-ar" target="_blank"><img class="img-circle"  src="../Styles/University_Master/images/president.jpg" alt="president"></a>
                            
                               </div>
                                <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/meawad-home-ar" target="_blank">
                                 <asp:Label ID="Label1" CssClass="h_style" runat="server" meta:resourcekey ="president"></asp:Label> 
                                 <asp:Label ID="Label2" CssClass="p_style" runat="server" meta:resourcekey ="title1"></asp:Label>
                             </a>
                                </div>
                         </div>
                        </div>--%>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/student.jpg" alt="student">
                            </div>
                           
                                   <asp:Label ID="Label3" CssClass="h_style" runat="server" meta:resourcekey ="stu"></asp:Label> 
                                 <asp:Label ID="Label4" CssClass="p_style" runat="server" meta:resourcekey ="title1"></asp:Label>
                                 </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/graduat.jpg" alt="graduat">
                            </div>
                              <a href="http://mu.menofia.edu.eg/scholars/index.php/ar/kased-home-ar" target="_blank">
                                   <asp:Label ID="Label5" CssClass="h_style" runat="server" meta:resourcekey ="gra"></asp:Label> 
                                 <asp:Label ID="Label6" CssClass="p_style" runat="server" meta:resourcekey ="title3"></asp:Label>
                                </a> 
                                   </div>
                         </div>
                        </div>
                          <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/unnamed.jpg" alt="community">
                            </div>
                           
                                 <asp:Label ID="Label7" CssClass="h_style" runat="server" meta:resourcekey ="comm2"></asp:Label> 
                                 <asp:Label ID="Label8" CssClass="p_style" runat="server" meta:resourcekey ="title2"></asp:Label>
                                 </div>
                         </div>
                        </div>

                     <div class="col-1-4">
                        <div class="wrap-col item">
                           <%--  <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/cvphoto.jpg" alt="community" />
                            </div>
                           
                                 <asp:Label ID="Label07" CssClass="h_style" runat="server" meta:resourcekey ="comm44"></asp:Label> 
                                 <asp:Label ID="Label08" CssClass="p_style" runat="server" meta:resourcekey ="title4"></asp:Label>
                                 </div>--%>
                         </div>
                        </div>
                 </div>

                    </div>
        </section>
    </div>
</asp:Panel>
</asp:Content>


<%--<asp:Content ID="Content6" ContentPlaceHolderID="" runat="Server">
<div class="zerogrid">
    <section class="content-box box-1">
                <div class="row">

                    <div class="col-1-4">
                        <div class="wrap-col item">
                            <div class="div_image">
                          <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/president.jpg" alt="president">
                            </div>
                            <h3>أ.د/معوض محمدالخولى</h3>
                            <p>رئيس الجامعة</p>
                                </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/student.jpg" alt="student">
                            </div>
                            <h3>أ.د/عادل السيد صادق مبارك </h3>
                            <p>نائب رئيس الجامعة لشئون التعليم والطلاب</p>
                                 </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/graduat.jpg" alt="graduat">
                            </div>
                            <h3>أ.د/أحمد فرج القاصــد </h3>
                            <p>نائب رئيس الجامعة للدراسات العيا والبحوث </p>
                                 </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/community.jpg" alt="community">
                            </div>
                            <h3>أ.د/عبدالرحمن السيد قرمان</h3>
                            <p>نائب رئيس الجامعة لشئون خدمة المجتمع وتنمية البيئة</p>
                                 </div>
                         </div>
                        </div>


                    </div>
        </section>
    </div>

    </asp:Content>--%>


