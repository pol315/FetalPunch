<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MetalGenerator.index" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title id="title" runat="server">Fetal Punch - Find your new band name</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/fetalpunch.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">   
    <header class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <h1 class="brand-heading">Fetal Punch</h1>
                        <p class="intro-text">Looking for a new band? Trying to find a cool name for your own band? Insanely bored?</p>
                        <form runat="server">              
                            <asp:LinkButton class="btn btn-circle" runat="server" OnClick="InsertName">\m/</asp:LinkButton>
                        </form>                                                                        
                    </div>
                </div>
            </div>
        </div>
    </header>

    <section id="about" class="container content-section text-center">                    
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">                                                 
                <h2>Your Hypothetical Band</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4">
                      Band Name:
                </div>
                <div class="col-lg-4">
                      Album Name:
                </div>
                <div class="col-lg-4">
                      Genre:
                </div>                                                                       
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4" id="bandname" runat="server">
                      
                </div>
                <div class="col-lg-4" id="album" runat="server">
                         
                </div>
                <div class="col-lg-4" id="genre" runat="server">
                         
                </div>   
                <br />
                <br />
                <br />                                                                    
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4">
                    Spotify Artist Results:
                </div>                
                <div class="col-lg-4">
                    Spotify Album Results:
                </div>
                <div class="col-lg-4">
                    Spotify Track Results:
                </div>
            </div>
        </div>             
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-4" id="spotify1" runat="server">
                    
                </div>                
                <div class="col-lg-4" id="spotify2" runat="server">
                    
                </div>
                <div class="col-lg-4" id="spotify3" runat="server">
                    
                </div>
            </div>
        </div>                        
    </section>

    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.easing.min.js"></script>
    <script src="js/grayscale.js"></script>

</body>
</html>
