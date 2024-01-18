<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/UserMasterpage.Master" AutoEventWireup="true" CodeBehind="frmFindFriends.aspx.cs" Inherits="OSNProject.frmFindFriends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panel" runat="server">   
    <div class="container">
		<div class="about row">
			<h2>Find Friends based on Name and EmailId!!!</h2>
     <br />
     <table style="width: 60%;">
         <tr>
             <td class="style2">
                &nbsp;</td>
             <td>
                 <asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" 
                     Text="Namewise" GroupName="a" />
                 <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" 
                     Text="EmailIdwise" GroupName="a" />
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
                     ImageUrl="~/images/search.jpg" onclick="imgbtnSearch_Click" 
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
  
</div>
</div>

 </asp:Panel>
</asp:Content>
