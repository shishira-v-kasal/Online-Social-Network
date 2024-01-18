<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/UserMasterpage.Master" AutoEventWireup="true" CodeBehind="frmInformationSharing.aspx.cs" Inherits="OSNProject.AfterLogin.frmInformationSharing" %>
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
    <style type="text/css">
        .style1
        {
            height: 123px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="panelInformationSharing" runat="server">

     <div class="container">
		<div class="about row">
			<h2>Information Sharing Module!!!</h2>
    <br />

        <table style="width: 65%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:RadioButton ID="rbtnText" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Text Message" ToolTip="Text" 
                                    oncheckedchanged="rbtnText_CheckedChanged" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtnPhotos" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Photos" ToolTip="Photos" 
                                    oncheckedchanged="rbtnPhotos_CheckedChanged" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtnVideos" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Videos" ToolTip="Videos" 
                                    oncheckedchanged="rbtnVideos_CheckedChanged" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="PanelText" runat="server" Visible="False">
        <fieldset>
        <legend>Text Message</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Title</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtTextTitle" runat="server" Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTextTitle" CssClass="failureNotification" 
                            ErrorMessage="Enter Text Title" ToolTip="Enter Text Title" 
                            ValidationGroup="text"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Message to Share</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtTextDescription" runat="server" Height="120px" TextMode="MultiLine" 
                            Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtTextDescription" CssClass="failureNotification" 
                            ErrorMessage="Enter Text Message" ToolTip="Enter Text Message" 
                            ValidationGroup="text"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnText" runat="server" Text="Share Information" 
                            ValidationGroup="text" Width="150px" onclick="btnText_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelPhotos" runat="server" Visible="False">
        <fieldset>
        <legend>Photos</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Photo Title</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPhotoTitle" runat="server" Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtPhotoTitle" CssClass="failureNotification" 
                            ErrorMessage="Enter Photo Title" ToolTip="Enter Photo Title" 
                            ValidationGroup="photo"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Description</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtPhotoDescription" runat="server" Height="120px" 
                            TextMode="MultiLine" Width="450px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPhotoDescription" CssClass="failureNotification" 
                            ErrorMessage="Enter Photo Description" ToolTip="Enter Photo Description" 
                            ValidationGroup="photo"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Select Number of Photos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="DropDownListPhotoNumber" runat="server" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DropDownListPhotoNumber_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="DropDownListPhotoNumber" CssClass="failureNotification" 
                            ErrorMessage="Select Number Of Photos" Operator="NotEqual" 
                            ToolTip="Select Number Of Photos" ValidationGroup="photo" 
                            ValueToCompare="Select"></asp:CompareValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Upload Photos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnUploadPhotos" runat="server" Text="Upload Photos" 
                            ValidationGroup="photo" Width="150px" onclick="btnUploadPhotos_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelVideos" runat="server" Visible="False">
        <fieldset>
        <legend>Videos</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Video Title</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtVideoTitle" runat="server" Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtVideoTitle" CssClass="failureNotification" 
                            ErrorMessage="Enter Video Title" ToolTip="Enter Video Title" 
                            ValidationGroup="video"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Description</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtVideoDescription" runat="server" Height="120px" 
                            TextMode="MultiLine" Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtVideoDescription" CssClass="failureNotification" 
                            ErrorMessage="Enter Video Description" ToolTip="Enter Video Description" 
                            ValidationGroup="video"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Upload Videos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="SerialNo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="CheckBox1_CheckedChanged" Text='<%# Eval("SerialNo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video URL">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="350px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnUploadVideos" runat="server" Text="Upload Videos" 
                            ValidationGroup="video" Width="150px" onclick="btnUploadVideos_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </fieldset>
        </asp:Panel>
      
        <asp:Panel ID="PanelSharedInformation" runat="server">
            <table style="width: 98%;">
                <tr>
                    <td>
                        <strong><h2>Shared Information</h2></strong></td>
                </tr>
               
                <tr>
                    <td>
                     <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="Table3" runat="server">
                        </asp:Table>
                        </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        </div>
        </div>

    </asp:Panel>


</asp:Content>
