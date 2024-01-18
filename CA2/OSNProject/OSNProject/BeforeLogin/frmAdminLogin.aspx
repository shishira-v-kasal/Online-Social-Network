<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin/Main.Master" AutoEventWireup="true" CodeBehind="frmAdminLogin.aspx.cs" Inherits="OSNProject.BeforeLogin.frmAdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../ThemeBlue.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelAdminLogin" runat="server">
  <div class="container">
		<div class="about row">
			<h2>Admin Login Form!!!</h2>
      <table style="width: 368px; ">
            <tr>
                <td align="center" valign="top" width: "501px;">
                    <fieldset>
                    <legend>Admin Login</legend>
                    <table style="width: 89%;">
                        <tr>
                            <td style="text-align: left; font-size: small;" class="style3">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; font-size: small;" class="style3">
                                <b>Admin Id</b></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtAdminId" runat="server" Font-Size="Small" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtAdminId" ErrorMessage="Enter AdminId" Font-Size="Small" 
                                    ToolTip="Enter AdminId" ValidationGroup="login" 
                                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; font-size: small;" class="style3">
                                <b>Password</b></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtPassword" runat="server" Width="200px" 
                                    Font-Size="Small" TextMode="Password"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Enter Password" ToolTip="Enter Password" 
                                    ValidationGroup="login" Font-Size="Small" 
                                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; font-size: small;" class="style3">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btnLogin" runat="server" Height="35px" Text="Submit" 
                                    ValidationGroup="login" Width="100px" onclick="btnLogin_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style3">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </fieldset>

                    <br />
                                                          
                    </td>
            </tr>
                 <tr>
                     <td>
                           <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                        class="Error">
                        <tr>
                            <td style="text-align: left">
                                <div ID="dvIcon" class="Error">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        CssClass="failureNotification" ToolTip="Enter Fields" 
                                        ValidationGroup="login" />
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table></td>
                 </tr>
        </table>
   </div>
   </div>

   <br />
   </asp:Panel>
</asp:Content>
