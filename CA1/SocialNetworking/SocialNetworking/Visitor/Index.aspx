<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SocialNetworking.Visitor.Index" %>


<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Social Networking</title>
<meta name="description" content="">
<meta name="author" content="">

<!-- Favicons
    ================================================== -->
<link rel="shortcut icon" href="../img/favicon.ico" type="image/x-icon">
<link rel="apple-touch-icon" href="../img/apple-touch-icon.png">
<link rel="apple-touch-icon" sizes="72x72" href="../img/apple-touch-icon-72x72.png">
<link rel="apple-touch-icon" sizes="114x114" href="../img/apple-touch-icon-114x114.png">

<!-- Bootstrap -->
<link rel="stylesheet" type="text/css"  href="../css/bootstrap.css">
<link rel="stylesheet" type="text/css" href="../fonts/font-awesome/css/font-awesome.css">

<!-- Stylesheet
    ================================================== -->
<link rel="stylesheet" type="text/css"  href="../css/style.css">
<link rel="stylesheet" type="text/css" href="../css/prettyPhoto.css">
<link href='http://fonts.googleapis.com/css?family=Lato:400,700,900,300' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,800,600,300' rel='stylesheet' type='text/css'>
<script type="text/javascript" src="js/modernizr.custom.js"></script>

<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

 <form id="form1" runat="server">
<!-- Navigation
    ==========================================-->
<nav id="menu" class="navbar navbar-default navbar-fixed-top">
  <div class="container"> 
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
      <a class="navbar-brand" href="#">CLONE ATTACKS</a> </div>
    
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav navbar-right">
        <li><a href="#home" class="page-scroll">Home</a></li>
        <li><a href="#about-section" class="page-scroll">About</a></li>
        <li><a href="#services-section" class="page-scroll">Services</a></li>       
      <li><a href="#works-section" class="page-scroll">Portfolio</a></li> 
        <li><a href="#team-section" class="page-scroll">Team</a></li>  
        <li><a href="#contact-section" class="page-scroll">Contact</a></li>
        
      </ul>
    </div>
    <!-- /.navbar-collapse --> 
  </div>
  <!-- /.container-fluid --> 
</nav>

<!-- Header -->
<header class="text-center" name="home">
  <div class="intro-text">
    <h1>Clone  <span class="color">Attacks</span></h1>
    <p style="text-align:center">Preventing Colluding Identity Clone Attacks in Online Social Networks</p>
    <div class="clearfix"></div>
    <a href="MemberLogin.aspx" class="btn btn-default btn-lg page-scroll">User Login</a> </div>
</header>
<!-- About Section -->
<div id="about-section">
  <div class="container">
    <div class="section-title">
      <h2>About Us</h2>
      <hr>
    </div>
    <div class="space"></div>
    <div class="row">
      <div class="col-md-4">
        <h4>Who We Are</h4>
        <p>As Online Social Networks such as Facebook and Google+ are becoming progressively more embedded in people’s daily lives, personal information becomes easily exposed and abused. Information harvesting, by the operator, malicious users, and third party commercial companies has recently been identify as being a significant security issues.</p>
      </div>
      <div class="col-md-4">
        <h4>What We Do</h4>
        <p>The aim of this paper is to detect if users’ friend request can be considered clones and colluders accounts. An example of ICA occurred with the NATO’s most senior commander, Admiral James Stavridis. It was reported that hackers set up fake Facebook accounts under his name and the hope is that his colleagues, friends, and family will make contact and answer private messages to gain sensitive information about him or themselves. </p>
      </div>
      <div class="col-md-4">
        <h4>Why Choose Us</h4>
        <p>Proposed System contains 2 New Social Networking Applications similar to Facebook and contains the following existing features and new features.</p>
      </div>
    </div>
  </div>
</div>
<!-- Services Section -->
<div id="services-section">
  <div class="container">
    <div class="section-title">
      <h2>Our Services</h2>
      <hr>
    </div>
    <div class="space"></div>
    <div class="row">
      <div class="col-md-3 col-sm-6 service"> <i class="fa fa-desktop"></i>
        <h4>Admin</h4>
        <p>Admin is an owner of application, person to maintain the entire system.</p>
      </div>
      <div class="col-md-3 col-sm-6 service"> <i class="fa fa-gears"></i>
        <h4>Visitor</h4>
        <p>Visitor can access to basic information.</p>
      </div>
      <div class="col-md-3 col-sm-6 service"> <i class="fa fa-pie-chart"></i>
        <h4>Member</h4>
        <p>Member is a person who receives the services from the application.s</p>
      </div>
     
    </div>
    <div class="space"></div>
    
  </div>
</div>
<!-- Portfolio Section -->
<<div id="works-section">
  <div class="container"> <!-- Container -->
    <div class="section-title">
      <h2>Our Portfolio</h2>
      <hr>
      <div class="clearfix"></div>
    </div>
    <div class="categories">
      <ul class="cat">
        <li>
          <ol class="type">
             <li><a href="#" data-filter="*" class="active">All</a></li>
            <li><a href="#" data-filter=".web">ADMIN</a></li>
            <li><a href="#" data-filter=".app">VISITOR</a></li>
            <li><a href="#" data-filter=".branding">MEMBERS</a></li>
          </ol>
        </li>
      </ul>
      <div class="clearfix"></div>
    </div>
    <div class="row">
      <div class="portfolio-items">
        <div class="col-sm-6 col-md-3 col-lg-3 web">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social1.png" rel="prettyPhoto">
              <div class="hover-text">
                <h4>ADMIN</h4>
                <small>Admin</small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social1.png" class="img-responsive" alt="RBI"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 app">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social2.jpg" rel="prettyPhoto">
              <div class="hover-text">
                <h4>VISITOR</h4>
                <small></small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social2.jpg" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 web">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social3.jpg" rel="prettyPhoto">
              <div class="hover-text">
                <h4>ADMIN</h4>
                <small>Admin</small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social3.jpg" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 web">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social4.png" rel="prettyPhoto">
              <div class="hover-text">
                <h4>ADMIN</h4>
                <small>Admin</small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social4.png" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 app">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social5.jpg" rel="prettyPhoto">
              <div class="hover-text">
                <h4>MEMBER</h4>
                <small></small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social5.jpg" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 branding">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social6.jpg" rel="prettyPhoto">
              <div class="hover-text">
                <h4>MEMBER</h4>
                <small>Fake Accounts</small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social6.jpg" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 branding app">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social2.jpg" rel="prettyPhoto">
              <div class="hover-text">
                <h4>MEMBER</h4>
                <small></small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social6.jpg" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3 col-lg-3 web">
          <div class="portfolio-item">
            <div class="hover-bg"> <a href="../img/social1.png" rel="prettyPhoto">
              <div class="hover-text">
                <h4>ADMIN</h4>
                <small>Admin</small>
                <div class="clearfix"></div>
              </div>
              <img src="../img/social1.png" class="img-responsive" alt="Project Title"> </a> </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Team Section -->
<div id="team-section">
  <div class="container">
    <div class="section-title">
      <h2>Meet the Team</h2>
      <hr>
    </div>
   <div id="row">
      <div class="col-md-3 col-sm-6 team">
        <div class="thumbnail"> <img src="../img/team/men%20profile1.png" alt="..." 
                class="team-img">
          <div class="caption">
            <h3>M Chirag Kashyap</h3>
            <p>Student</p>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-6 team">
        <div class="thumbnail"> <img src="../img/team/men%20profile1.png" alt="..." 
                class="team-img">
          <div class="caption">
            <h3>Bharath S</h3>
            <p>Student</p>
          </div>
        </div>
      </div>
      <div class="col-md-3 col-sm-6 team">
        <div class="thumbnail"> <img src="../img/team/women%20profile.jpg" alt="..." 
                class="team-img">
          <div class="caption">
            <h3>Ms.H.J.Jayashree</h3>
            <p>Guide</p>
          </div>
        </div>
      </div>    
    </div>
  </div>
</div>
<!-- Contact Section -->
<div id="contact-section">
  <div class="container">
    <div class="section-title center">
      <h2>Contact Us</h2>
      <hr>
    </div>
    <div class="col-md-4">
      <h4>Contact info</h4>
      <div class="space"></div>
      <p></p>
      <div class="space"></div>
      <p><i class="fa fa-envelope-o"></i>info@company.com</p>
      <div class="space"></div>
      <p><i class="fa fa-phone"></i>+91 9742531426</p>

        <p><i class="fa fa-phone"></i>+91 9066462606</p>

    </div>
   
  </div>
</div>

<div id="social-section">
  <div class="container">
    <div class="social">
      <ul>
        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
        <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
        <li><a href="#"><i class="fa fa-github"></i></a></li>
        <li><a href="#"><i class="fa fa-instagram"></i></a></li>
        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
      </ul>
    </div>
  </div>
</div>
<div id="footer">
  <div class="container">
  <p>Copyright &copy; Social Networking <a href="#" rel="nofollow">Site</a></p>
  </div>
</div>

<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script> 
<script type="text/javascript" src="js/jquery.1.11.1.js"></script> 
<!-- Include all compiled plugins (below), or include individual files as needed --> 
<script type="text/javascript" src="../js/bootstrap.js"></script> 
<script type="text/javascript" src="../js/SmoothScroll.js"></script> 
<script type="text/javascript" src="../js/jquery.prettyPhoto.js"></script> 
<script type="text/javascript" src="../js/jquery.isotope.js"></script> 
<script type="text/javascript" src="../js/jqBootstrapValidation.js"></script> 
<script type="text/javascript" src="../js/contact_me.js"></script> 

<!-- Javascripts
    ================================================== --> 
<script type="text/javascript" src="../js/main.js"></script>

 </form>
</body>
</html>