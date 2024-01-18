<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin/Main.Master" AutoEventWireup="true" CodeBehind="frmRegistration.aspx.cs" Inherits="OSNProject.BeforeLogin.frmRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../ThemeBlue.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelRegister" runat="server">
  <div class="container">
		<div class="about row">
			<h2>Registration Form for New Users!!!</h2>
     
       
      <table style="width: 448px;">
            <tr>
                <td align="center" valign="top" 
                    width: "501px;">
                    <fieldset>
                    <legend>Create your Account</legend>
                    <table style="width: 85%;">
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <b>Email ID</b></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtEmailId" runat="server" Font-Size="Small" Width="200px" 
                                    ontextchanged="txtEmailId_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtEmailId" CssClass="failureNotification" 
                                    ErrorMessage="Enter Email Id" Font-Size="Small" ToolTip="Enter Email Id" 
                                    ValidationGroup="registration">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtEmailId" CssClass="failureNotification" 
                                    ErrorMessage="Invalid EmailId" Font-Size="Small" ToolTip="Invalid EmailId" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="registration">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <b>Password</b></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" 
                                    TextMode="Password" Width="200px" MaxLength="10"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtPassword" CssClass="failureNotification" 
                                    ErrorMessage="Enter Password" Font-Size="Small" ToolTip="Enter Password" 
                                    ValidationGroup="registration">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtPassword" CssClass="failureNotification" 
                                    ErrorMessage="Min of 8 Character and Max of 10 Character" 
                                    ToolTip="Min of 8 Character and Max of 10 Character" 
                                    ValidationExpression="^.{8,10}$" ValidationGroup="registration">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <b>Confirm</b></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="200px" 
                                    Font-Size="Small"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtConfirm" ErrorMessage="Enter Password again" ToolTip="field required" 
                                    ValidationGroup="registration" Font-Size="Small" 
                                    CssClass="failureNotification">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txtPassword" ControlToValidate="txtConfirm" 
                                    ErrorMessage="Password Mismatch" ToolTip="mismatch" ValidationGroup="registration" 
                                    Font-Size="Small" CssClass="failureNotification">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 151px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <strong>First Name</strong></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="txtFirstName" CssClass="failureNotification" 
                                    ErrorMessage="Enter FName" ToolTip="Enter FName" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <strong>LastName</strong></td>
                            <td style="text-align: left; width: 151px">
                                <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <strong>Gender</strong></td>
                            <td style="text-align: left; width: 151px">
                                <asp:DropDownList ID="dropdownlistGender" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                    ControlToValidate="dropdownlistGender" CssClass="failureNotification" 
                                    ErrorMessage="Select Gender" Operator="NotEqual" ToolTip="Select Gender" 
                                    ValidationGroup="registration" ValueToCompare="Select">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 127px; font-size: small;">
                                <strong>DateOfBirth</strong></td>
                            <td style="text-align: left; width: 151px">
                           
                                <asp:TextBox ID="txtDOB" runat="server" Width="200px"></asp:TextBox>
                                
                            </td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 127px">
                                &nbsp;</td>
                            <td align="left">
                                <asp:ImageButton ID="imagebtnRegister" runat="server" Height="55px" 
                                    ImageUrl="~/images/registericon.png" Width="180px" 
                                    ValidationGroup="registration" onclick="imagebtnRegister_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 127px">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </fieldset>

                    <br />
                    <span style="color: #FF3300; font-weight: bold; font-size: small;">
                    PLEASE NOTE 
                    DOWN YOUR USER ID FOR FUTURE USE....<br /> </span>
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
                                        ValidationGroup="registration" />
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>

                         </td>
                 </tr>
                 <tr>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         <table ID="tblMessage" border="0" cellpadding="4" cellspacing="4" 
                                                                                class="Success">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div ID="dvIcon" class="Success">
                                                                                           
                                                                                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
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
