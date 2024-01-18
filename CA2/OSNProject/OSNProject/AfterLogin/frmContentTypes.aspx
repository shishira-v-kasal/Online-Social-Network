﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="frmContentTypes.aspx.cs" Inherits="OSNProject.AfterLogin.frmContentTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../ThemeBlue.css" rel="Stylesheet" type="text/css" />
 <style type="text/css">
        .style2
        {
            width: 405px;
        }
        .style3
        {
            width: 121px;
        }
    </style>
     <!-- Add jQuery library -->
	<script type="text/javascript" src="../Popup/lib/jquery-1.10.1.min.js"></script>

	<!-- Add mousewheel plugin (this is optional) -->
	<script type="text/javascript" src="../Popup/lib/jquery.mousewheel-3.0.6.pack.js"></script>

	<!-- Add fancyBox main JS and CSS files -->
	<script type="text/javascript" src="../Popup/source/jquery.fancybox.js?v=2.1.5"></script>
	<link rel="stylesheet" type="text/css" href="../Popup/source/jquery.fancybox.css?v=2.1.5" media="screen" />

	<!-- Add Button helper (this is optional) -->
	<link rel="stylesheet" type="text/css" href="../Popup/source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
	<script type="text/javascript" src="../Popup/source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>

	<!-- Add Thumbnail helper (this is optional) -->
	<link rel="stylesheet" type="text/css" href="../Popup/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
	<script type="text/javascript" src="../Popup/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>

	<!-- Add Media helper (this is optional) -->
	<script type="text/javascript" src="../Popup/source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

      <script type="text/javascript">
          $(document).ready(function () {
              /*
              *  Simple image gallery. Uses default settings
              */

              $('.fancybox').fancybox();

              /*
              *  Different effects
              */

              // Change title type, overlay closing speed
              $(".fancybox-effects-a").fancybox({
                  helpers: {
                      title: {
                          type: 'outside'
                      },
                      overlay: {
                          speedOut: 0
                      }
                  }
              });

              // Disable opening and closing animations, change title type
              $(".fancybox-effects-b").fancybox({
                  openEffect: 'none',
                  closeEffect: 'none',

                  helpers: {
                      title: {
                          type: 'over'
                      }
                  }
              });

              // Set custom style, close if clicked, change title type and overlay color
              $(".fancybox-effects-c").fancybox({
                  wrapCSS: 'fancybox-custom',
                  closeClick: true,

                  openEffect: 'none',

                  helpers: {
                      title: {
                          type: 'inside'
                      },
                      overlay: {
                          css: {
                              'background': 'rgba(238,238,238,0.85)'
                          }
                      }
                  }
              });

              // Remove padding, set opening and closing animations, close if clicked and disable overlay
              $(".fancybox-effects-d").fancybox({
                  padding: 0,

                  openEffect: 'elastic',
                  openSpeed: 150,

                  closeEffect: 'elastic',
                  closeSpeed: 150,

                  closeClick: true,

                  helpers: {
                      overlay: null
                  }
              });

              /*
              *  Button helper. Disable animations, hide close button, change title type and content
              */

              $('.fancybox-buttons').fancybox({
                  openEffect: 'none',
                  closeEffect: 'none',

                  prevEffect: 'none',
                  nextEffect: 'none',

                  closeBtn: false,

                  helpers: {
                      title: {
                          type: 'inside'
                      },
                      buttons: {}
                  },

                  afterLoad: function () {
                      this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
                  }
              });


              /*
              *  Thumbnail helper. Disable animations, hide close button, arrows and slide to next gallery item if clicked
              */

              $('.fancybox-thumbs').fancybox({
                  prevEffect: 'none',
                  nextEffect: 'none',

                  closeBtn: false,
                  arrows: false,
                  nextClick: true,

                  helpers: {
                      thumbs: {
                          width: 50,
                          height: 50
                      }
                  }
              });

              /*
              *  Media helper. Group items, disable animations, hide arrows, enable media and button helpers.
              */
              $('.fancybox-media')
				.attr('rel', 'media-gallery')
				.fancybox({
				    openEffect: 'none',
				    closeEffect: 'none',
				    prevEffect: 'none',
				    nextEffect: 'none',

				    arrows: false,
				    helpers: {
				        media: {},
				        buttons: {}
				    }
				});

              /*
              *  Open manually
              */

              $("#fancybox-manual-a").click(function () {
                  $.fancybox.open('1_b.jpg');
              });

              $("#fancybox-manual-b").click(function () {
                  $.fancybox.open({
                      href: 'iframe.html',
                      type: 'iframe',
                      padding: 5
                  });
              });

              $("#fancybox-manual-c").click(function () {
                  $.fancybox.open([
					{
					    href: '1_b.jpg',
					    title: 'My title'
					}, {
					    href: '2_b.jpg',
					    title: '2nd title'
					}, {
					    href: '3_b.jpg'
					}
				], {
				    helpers: {
				        thumbs: {
				            width: 75,
				            height: 50
				        }
				    }
				});
              });


          });
	</script>
	<style type="text/css">
		.fancybox-custom .fancybox-skin {
			box-shadow: 0 0 50px #222;
		}

		</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelContentTypes" runat="server">

    <div class="container">
		<div class="about row">
			<h2>Upload User Area Of Interest !!!</h2>
    
                                       <table style="width: 90%;">
                                           <tr>
                                               <td>
                                                   &nbsp;</td>
                                               <td align="center" class="style9">
                                                   <strong>Add Area of Interest</strong></td>
                                               <td>
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   &nbsp;
                                               </td>
                                               <td>
                                               <fieldset>
                                               <legend>Area of Interest</legend>
                                                   <table align="center" style="width: 90%;">
                                                       <tr>
                                                           <td class="style3">
                                                               &nbsp;</td>
                                                           <td class="style2">
                                                               &nbsp;</td>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="style3">
                                                               <b>Area of Interest</b></td>
                                                           <td class="style2">
                                                               <asp:TextBox ID="txtContentType" runat="server" Width="400px"></asp:TextBox>
                                                           </td>
                                                           <td>
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                   ControlToValidate="txtContentType" CssClass="failureNotification" 
                                                                   ErrorMessage="Enter ContentType" ToolTip="Enter ContentType" 
                                                                   ValidationGroup="content">*</asp:RequiredFieldValidator>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td class="style3">
                                                               &nbsp;</td>
                                                           <td class="style2">
                                                               &nbsp;</td>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="style3">
                                                               &nbsp;</td>
                                                           <td class="style2">
                                                               <asp:Button ID="btnContentType" runat="server" onclick="btnContentType_Click" 
                                                                   Text="Add" ValidationGroup="content" Width="75px" />
                                                           </td>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                       <tr>
                                                           <td class="style3">
                                                               &nbsp;</td>
                                                           <td class="style2">
                                                               &nbsp;</td>
                                                           <td>
                                                               &nbsp;</td>
                                                       </tr>
                                                   </table>
                                                  </fieldset>
                                               </td>
                                               <td>
                                                   &nbsp;
                                               </td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   &nbsp;</td>
                                               <td>
                                                 <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" class="Error">
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <div ID="dvIcon" class="Error">
                                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                                                        CssClass="failureNotification" ToolTip="Enter Fields" 
                                                                        ValidationGroup="content" />
                                                                    <asp:Label ID="lblContentError" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table></td>
                                               <td>
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   &nbsp;
                                               </td>
                                               <td>
                                                  <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                                                        class="Success">
                                                        <tr>
                                                            <td>
                                                                <div ID="dvIcon" class="Success">
                                                                   <asp:Label ID="lblContentSuccess" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                               </td>
                                               <td>
                                                   &nbsp;
                                               </td>
                                           </tr>
                                       </table>

                                       <br />
                                       <table style="width: 98%;">
                                           <tr>
                                               <td align="center" class="style10">
                                                   &nbsp;</td>
                                               <td align="center" class="style10">
                                                   <strong>Existing Area of Interest</strong></td>
                                           </tr>
                                           <tr>
                                               <td align="center">
                                                   &nbsp;</td>
                                               <td align="center">
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   &nbsp;</td>
                                               <td>
                                                   <div style="height:650px; width:auto; overflow:auto">
                                                       <asp:Table ID="tblContentTypes" runat="server">
                                                       </asp:Table>
                                                   </div>
                                               </td>
                                           </tr>
                                       </table>
                                       <br />
                                       </div>
                                       </div>

    </asp:Panel>
</asp:Content>
