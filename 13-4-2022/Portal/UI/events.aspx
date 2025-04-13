<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="MnfUniversity_Portals.events" %>

<%@ Register src="../UserControls/events/events.ascx" tagname="events" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
    <head runat="server">
       <%-- <title>Slicebox - 3D Image Slider</title>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
        <meta name="description" content="Slicebox - 3D Image Slider with Fallback" />
        <meta name="keywords" content="jquery, css3, 3d, webkit, fallback, slider, css3, 3d transforms, slices, rotate, box, automatic" />
		<meta name="author" content="Pedro Botelho for Codrops" />
		
        <link href="Styles/University_Master/css/demo.css" rel="stylesheet" />
        <link href="Styles/University_Master/css/custom.css" rel="stylesheet" />
        <link href="Styles/University_Master/css/slicebox.css" rel="stylesheet" />
		<script src="Styles/University_Master/jquery/jquery.slicebox.js"></script>
        <script src="Styles/University_Master/jquery/modernizr.custom.46884.js"></script>--%>
	</head>

<body>
		<form id="form1" runat="server">
	<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
	        <uc1:events ID="events11" runat="server" />
        </form>
	</body>
</html>
