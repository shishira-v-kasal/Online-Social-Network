﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/UserMasterpage.Master" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="OSNProject.frmSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panel" runat="server">   
     <div class="container">
		<div class="about row">
			<h2>Search Module !!!</h2>
    <br />

    <fieldset style="width: 650px">
   <legend>Search</legend>
     <table style="width: 100%;">
         <tr>
             <td class="style2">
                <b>Search based on EmailId</b>
             </td>
             <td>
                 <asp:TextBox ID="txtSearch" runat="server" Width="400px"></asp:TextBox>
             </td>
             <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="txtSearch" CssClass="failureNotification" 
                     ErrorMessage="Enter EmailId" ToolTip="Enter EmailId" ValidationGroup="EmailId">*</asp:RequiredFieldValidator>
             </td>
             <td>
                <asp:ImageButton ID="imgbtnSearch" runat="server" 
                     ImageUrl="~/images/search.jpg" onclick="imgbtnSearch_Click" 
                     ValidationGroup="EmailId" />                
             </td>
         </tr>
         
     </table>
   </fieldset>
   
     <br />
      <br />
     <asp:Panel ID="panelUser" runat="server" Visible="False">

          <table style="width:68%;">
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <strong>Basic Information</strong></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <fieldset style="width: 600px;">
                                <legend>Profile Updation</legend>
                                <table style="width: 98%; font-size: small;">
                                    <tr>
                                        <td>
                                            <table style="width: 98%;">
                                                <tr>
                                                    <td class="style1" rowspan="6" style="text-align: left; " valign="top">
                                                        <table style="width: 84%; height: 180px;">
                                                            <tr>
                                                                <td align="center" valign="top">
                                                                    <asp:Image ID="imgPhoto" runat="server" Height="200px" Width="200px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <b>EMailId</b></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <b>FirstName</b></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <b>LastName</b></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <b>Gender</b></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <strong>DOB</strong></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style3" style="text-align: left; ">
                                                        &nbsp;</td>
                                                    <td class="style2" style="text-align: left; ">
                                                        <b>Registered Date</b></td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblRegisteredDate" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <strong>Educational Information</strong></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        <fieldset>
                        <legend>Education</legend>
                            <table style="width:85%;">
                                <tr>
                                    <td>
                                        <strong>High School</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtHighSchool" runat="server" Height="80px" 
                                            TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>College</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtCollege" runat="server" Height="80px" TextMode="MultiLine" 
                                            Width="400px"></asp:TextBox>
                                    </td>
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
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <strong>Employer Details</strong></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        <fieldset>
                        <legend>Employer</legend>
                            <table style="width:85%;">
                                <tr>
                                    <td>
                                        <strong>Employer</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtEmployer" runat="server" Height="80px" TextMode="MultiLine" 
                                            Width="400px"></asp:TextBox>
                                    </td>
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
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <strong>Contact Details</strong></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        <fieldset>
                        <legend>Contact</legend>
                            <table style="width:85%;">
                                <tr>
                                    <td>
                                        <strong>Address</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" Height="80px" TextMode="MultiLine" 
                                            Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Mobile</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtMobile" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>OtherPhone</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtOtherPhone" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Current City</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtCurrentCity" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>ZipCode</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtZipCode" runat="server" Width="400px"></asp:TextBox>
                                    </td>
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
                                </tr>
                                <tr>
                                    <td>
                                        <strong>HomeTown</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtHomeTown" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <strong>Others</strong></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        <fieldset>
                        <legend>Others</legend>
                            <table style="width: 95%;">
                                <tr>
                                    <td>
                                        <strong>Relationship Status</strong></td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListReplationship" runat="server" Width="400px">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Married</asp:ListItem>
                                            <asp:ListItem>Single</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Languages</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtLanguages" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Religion</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtReligion" runat="server" Width="400px"></asp:TextBox>
                                    </td>
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
                                </tr>
                                <tr>
                                    <td>
                                        <strong>About U</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtAboutU" runat="server" Height="80px" TextMode="MultiLine" 
                                            Width="400px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                       
     </asp:Panel>
                                 
           
                       <br />
</div>
</div>
 </asp:Panel>
</asp:Content>
