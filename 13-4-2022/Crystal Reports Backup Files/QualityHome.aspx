<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QualityHome.aspx.cs" MasterPageFile="~/Masterpages/QualityMaster.Master" Inherits="MnfUniversity_Portals.UI.QualityHome" %>
<%@ Import Namespace="System.Web.UI.Design" %>
<%@ Import Namespace="App_Code" %>
<%@ Import Namespace="Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script src="../../Styles/University_Master/js/jquery.min.js"></script>
    <script src="../../Styles/University_Master/js/bootstrap.min.js"></script>
        <link href="../../Styles/University_Master/css/bootstrap.css" rel="stylesheet" />
    <link href="../../Styles/University_Master/css/font-awesome.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="slideshow" class="bottom-border-shadow">
                <div class="no-padding background-white bottom-border">
                    <div class="row">
                        <!-- Carousel Slideshow -->
                        <div id="carousel-example" class="carousel slide" data-ride="carousel">
                            <!-- Carousel Indicators -->
                            <ol class="carousel-indicators">
                                <li data-target="#carousel-example" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example" data-slide-to="1"></li>
                                <li data-target="#carousel-example" data-slide-to="2"></li>
                                <li data-target="#carousel-example" data-slide-to="3"></li>
                            </ol>
                            <div class="clearfix"></div>
                            <!-- End Carousel Indicators -->
                            <!-- Carousel Images -->
                            <div class="carousel-inner">
                                <div class="item active">
                                    <img src="../../Styles/University_Master/images/static_slider/1.png" />
                                    
                                </div>
                                <div class="item">
                                    <img src="../../Styles/University_Master/images/static_slider/2.png" />
                                </div>
                                <div class="item">
                                    <img src="../../Styles/University_Master/images/static_slider/3.png" />
                                </div>
                                <div class="item">
                                    <img src="../../Styles/University_Master/images/static_slider/4.png" />
                                </div>
                            </div>
                            <!-- End Carousel Images -->
                            <!-- Carousel Controls -->
                            <a class="left carousel-control" href="#carousel-example" data-slide="prev">
                            <i class="fa fa-chevron-circle-left" aria-hidden="true"></i>



                            </a>
                            <a class="right carousel-control" href="#carousel-example" data-slide="next">
                         <i class="fa fa-chevron-circle-right" aria-hidden="true"></i>



                            </a>
                            <!-- End Carousel Controls -->
                        </div>
                        <!-- End Carousel Slideshow -->
                    </div>
                </div>
            </div>

   

    </asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
     <div class="zerogrid">
        <div class="row">
            <div class="col-1-1">
                <%--<div class="slide_img">
                <img src="../../Styles/University_Master/images/slider/slide.gif" />
                    </div>--%>

                <uc:EventSliderControl runat="server" id="EventSliderControl" />
                <div class="shadow"></div>
            </div>


            <div class="col-1-2">


                </div>
            <%--<div class="col-1-4">

                <div class="item-header2">
                    <div class="header2_img">

                        <img src="../../Styles/University_Master/images/link_img.png">

                        <span>روابط هامة</span>
                    </div>
                </div>
                <div class="wrap-col item">
                    <div class="side_linke">
                        <asp:FormView ID="OwnerImageFormView" runat="server" align="center" DataSourceID="DummyDataSource">
                            <ItemTemplate>
                                <a href="http://melc.menofia.edu.eg/">مركز التعليم الإلكترونى</a>
                                <asp:HyperLink ID="HyperLink1" runat="server">أعضاء هيئة التدريس</asp:HyperLink>
                                <a href="http://www.menofia.edu.eg/projects/fldp_new/home.asp">تنمية قدرات أعضاء هيئة التدريس</a>
                                <a href="http://mu.menofia.edu.eg/Library/LibraryHome/<%= StaticUtilities.Currentlanguage(Page) %>">بوابة المكتبة الرقمية</a>
                                <a runat="server" id="link1" href='<%#getLink1url() %>'>مشروعات ICTP</a>
                                <a runat="server" id="link2" href='<%#getLink2url() %>'>مركز توكيدالجودة</a>
                                <a runat="server" id="link3" href='<%#getLink3url() %>'>إستراتيجية الجامعة</a>
                                <a runat="server" id="link4" href='<%#getLink4url() %>'>مشروعات أخرى</a>
                            </ItemTemplate>
                        </asp:FormView>
                        <asp:ObjectDataSource ID="DummyDataSource" runat="server" SelectMethod="DummyDataMethod"
                            TypeName="StaticUtilities"></asp:ObjectDataSource>


                    </div>
                </div>


            </div>--%>

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


            <section class="content-box box-1">
                <div class="row">

                    <uc:NewsViewerControl ID="NewsViewerControl1" TopNewsCounter="8" runat="server" />
	    <asp:Button ID ="Button2" CssClass="login_button" runat="server" OnClick="Button555_Click" meta:resourcekey ="MoreNews"></asp:Button>
			
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server"  ID ="panel1Manager" >
    <div class="zerogrid">
    <%--<section class="content-box box-1" >
                <div class="row" id ="xx" >
                    <div class="pre_bg">
                      <asp:Label ID="Label9" CssClass="pre_st" runat="server" meta:resourcekey ="Mange"></asp:Label> 
                     <div class="col-1-4">
                        <div class="wrap-col item">
                            
                            <div class="div_image">
                          <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/president.jpg" alt="president">
                            </div>
                              
                                <asp:Label ID="Label1" CssClass="h_style" runat="server" meta:resourcekey ="president"></asp:Label> 
                                 <asp:Label ID="Label2" CssClass="p_style" runat="server" meta:resourcekey ="title1"></asp:Label>
                           
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
                          
                                   <asp:Label ID="Label5" CssClass="h_style" runat="server" meta:resourcekey ="gra"></asp:Label> 
                                 <asp:Label ID="Label6" CssClass="p_style" runat="server" meta:resourcekey ="title3"></asp:Label>
                                 </div>
                         </div>
                        </div>
                     <div class="col-1-4">
                        <div class="wrap-col item">
                             <div class="div_image">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../Styles/University_Master/images/community.jpg" alt="community">
                            </div>
                           
                                 <asp:Label ID="Label7" CssClass="h_style" runat="server" meta:resourcekey ="comm"></asp:Label> 
                                 <asp:Label ID="Label8" CssClass="p_style" runat="server" meta:resourcekey ="title4"></asp:Label>
                                 </div>
                         </div>
                        </div>
                 </div>

                    </div>
        </section>--%>
    </div>
</asp:Panel>
</asp:Content>
