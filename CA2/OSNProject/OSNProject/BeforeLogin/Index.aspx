<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OSNProject.BeforeLogin.Index" %>

<!--A Design by W3layouts
Author: W3layout
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>social networking</title>
<!-- Bootstrap -->
<link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
<meta name="viewport" content="width=device-width, initial-scale=1">
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
 <!--[if lt IE 9]>
     <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
     <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
<!-- start plugins -->
<script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script>
<script type="text/javascript" src="../js/bootstrap.min.js"></script>
<!-- start slider -->
<link href="../css/slider.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="../js/modernizr.custom.28468.js"></script>
<script type="text/javascript" src="../js/jquery.cslider.js"></script>
	<script type="text/javascript">
	    $(function () {

	        $('#da-slider').cslider({
	            autoplay: true,
	            bgincrement: 450
	        });

	    });
		</script>
<!-- Owl Carousel Assets -->
<link href="../css/owl.carousel.css" rel="stylesheet">
<script src="../js/owl.carousel.js"></script>
		<script>
			$(document).ready(function() {

				$("#owl-demo").owlCarousel({
					items : 4,
					lazyLoad : true,
					autoPlay : true,
					navigation : true,
					navigationText : ["", ""],
					rewindNav : false,
					scrollPerPage : false,
					pagination : false,
					paginationNumbers : false,
				});

			});
		</script>
		<!-- //Owl Carousel Assets -->
<!----font-Awesome----->
   	<link rel="stylesheet" href="../fonts/css/font-awesome.min.css">
<!----font-Awesome----->
</head>
<body>
<div class="header_bg">
<div class="container">
	<div class="row header">
		<div class="logo navbar-left">
			<h1><a href="#">CLONE ATTACKS (OSN2)</a></h1>
		</div>
		
		<div class="clearfix"></div>
	</div>
</div>
</div>
<div class="container">
	<div class="row h_menu">
		<nav class="navbar navbar-default navbar-left" role="navigation">
		    <!-- Brand and toggle get grouped for better mobile display -->
		    <div class="navbar-header">
		      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
		        <span class="sr-only">Toggle navigation</span>
		        <span class="icon-bar"></span>
		        <span class="icon-bar"></span>
		        <span class="icon-bar"></span>
		      </button>
		    </div>
		    <!-- Collect the nav links, forms, and other content for toggling -->
		    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
		      <ul class="nav navbar-nav">
               <li><a href="Index.aspx">Home</a></li>
               <li><a href="frmAboutus.aspx">Aboutus</a></li>
               <li><a href="frmContactus.aspx">Contactus</a></li>
              <%-- <li><a href="frmServices.aspx">Services</a></li>  --%>
              <%-- <li><a href="Trendz.aspx">Trendz</a></li> --%>
		       <li><a href="frmRegistration.aspx">Register</a></li>
               <li><a href="frmLogin.aspx">Login</a></li>    
               <li><a href="frmAdminLogin.aspx">Admin Login</a></li> 
              </ul>
		    </div><!-- /.navbar-collapse -->
		    <!-- start soc_icons -->
		</nav>
		
	</div>
</div>

<div class="slider_bg"><!-- start slider -->
	<div class="container">
		<div id="da-slider" class="da-slider text-center">
			<div class="da-slide">
				<h2>networking</h2>
               <p></p>
				<p>Here users can view the notifications send by other users of the website such as friend request, events, friend request approval etc.</p>
				
			</div>
			<div class="da-slide">
				<h2>Clone Attacks</h2>
                  <p></p>
				<p>Administrator is a person who manages content types and keywords.</p>
				
			</div>
			<div class="da-slide">
				<h2>data validation</h2>
                 <p></p>
				<p>Users who get register to the application and make use of application services.</p>
				
			</div>
			<div class="da-slide">
				<h2>Info sharing</h2>
                 <p></p>
				<p>The main objective of the application (OSN) is to share the information. Here website users can share the information such as text messages, pictures and videos with others.</p>
				
			</div>
	   </div>
	</div>
</div><!-- end slider -->


<div class="footer_bg"><!-- start footer -->
	<div class="container">
		<div class="row  footer">
			<div class="copy text-center">
				<p class="link"><span>&#169; All rights reserved | Design by&nbsp;<a href="#"> Company Name</a></span></p>
			</div>
		</div>
	</div>
</div>
</body>
</html>
