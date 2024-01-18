<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin/Main.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="OSNProject.BeforeLogin.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../ThemeBlue.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 368px;
            height: 25px;
        }
        .style2
        {
            width: 239px;
            height: 25px;
        }
        .style3
        {
            width: 154px;
            height: 25px;
        }
        .style4
        {
            width: 140px;
            height: 25px;
        }
        .style5
        {
            width: 110px;
        }
        .style6
        {
            width: 110px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelLogin" runat="server">
  <div class="container">
		<div class="about row">
			<h2>Login Form for Registered Users!!!</h2>
    <br />
           
           
            <table style="width: 67%;">
            <tr>
                <td align="center" valign="top">
                    <table style="width:66%; background-image: url('../images/loginbg9.jpg'); height: 290px;" 
                        align="center">
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: center; color: #006699; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:Label ID="lblCookieUserId" runat="server" Font-Bold="True" 
                                    ForeColor="#FFBC23"></asp:Label>
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px; color: #006699;">
                                <b>Email Id</b></td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txtEmailId" runat="server" Width="200px" 
                                    ontextchanged="txtEmailId_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtEmailId" ErrorMessage="Enter EmailId" ToolTip="Enter EmailId" 
                                    ValidationGroup="login" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style6">
                                </td>
                            <td style="text-align: left; color: #006699;" class="style2">
                                <b>Password</b></td>
                            <td style="text-align: left; " class="style3">
                                </td>
                            <td style="text-align: left" class="style4">
                                </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 154px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Enter Password" ToolTip="Enter Password" 
                                    ValidationGroup="login" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 140px; text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/CAUVGTUR.jpg" 
                                    ValidationGroup="login" Height="34px" 
                                    Width="83px" onclick="btnLogin_Click" />
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                <asp:CheckBox ID="checkboxRememberme" runat="server" Font-Bold="True" 
                                    Text="Remember me" ForeColor="#006699" />
                            </td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td style="text-align: left; width: 239px">
                                &nbsp;</td>
                            <td style="width: 154px">
                                &nbsp;</td>
                            <td style="width: 140px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
                <tr>
                    <td align="center" style="width: 510px;" valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                       <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                        class="Error" align="center" style="width: 510px">
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

        <br />
         </div>
         </div>
   

   <br />
   </asp:Panel>
</asp:Content>
