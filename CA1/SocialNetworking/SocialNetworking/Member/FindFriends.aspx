﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMasterpage.Master" AutoEventWireup="true" CodeBehind="FindFriends.aspx.cs" Inherits="SocialNetworking.Member.FindFriends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Panel ID="Panel1" runat="server">
   

     <div class="header_02">Find Friends!</div>
    <br />

    <table style="width: 75%;">
         <tr>
             <td class="style2">
                 &nbsp;</td>
             <td>
                 &nbsp<table style="width:100%;">
                     <tr>
                         <td>
                             <asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" 
                                 GroupName="a" Text="Namewise" />
                         </td>
                         <td>
                             <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" 
                                 GroupName="a" Text="EmailIdwise" />
                         </td>
                         <td>
                             &nbsp;</td>
                     </tr>
                 </table>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         
         <tr>
             <td class="style2">
                 <b>Search Users</b>
             </td>
             <td>
                 <asp:TextBox ID="txtSearch" runat="server" Width="400px"></asp:TextBox>
             </td>
             <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="txtSearch" CssClass="failureNotification" 
                     ErrorMessage="Field Required" ToolTip="Field Required" 
                     ValidationGroup="Name">*</asp:RequiredFieldValidator>
             </td>
             <td>
                 <asp:ImageButton ID="imgbtnSearch" runat="server" 
                     ImageUrl="~/img/search.jpg" onclick="imgbtnSearch_Click" 
                     ValidationGroup="Name" />
             </td>
         </tr>
         
         <tr>
             <td class="style2">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         
                       <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                        class="Error" align="center" style="width: 510px">
                        <tr>
                            <td style="text-align: left">
                                <div ID="dvIcon" class="Error">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        CssClass="failureNotification" ToolTip="Enter Fields" 
                                        ValidationGroup="Name" />
                                </div>
                            </td>
                        </tr>
                    </table>
                        
     </table>
      
     <br />
       <table style="width: 98%;">
                  <tr>
                      <td>
                          <asp:Label ID="lblUser" runat="server" Font-Bold="True" 
                              Font-Size="Large"></asp:Label>
                         
                      </td>
                  </tr>
                  <tr>
                      <td >
                          </td>
                  </tr>
                  <tr>
                      <td>
                         <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">

                         <asp:Table ID="tblUsers" runat="server">
                          </asp:Table>
                          </div>
                          </div>
                      </td>
                  </tr>
                  <tr>
                      <td>
                          &nbsp;</td>
                  </tr>
              </table>
   <br />

</asp:Panel>


</asp:Content>
