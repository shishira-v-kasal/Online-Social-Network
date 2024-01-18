<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin/Main.Master" AutoEventWireup="true" CodeBehind="frmContactus.aspx.cs" Inherits="OSNProject.frmContactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 398px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelContactus" runat="server">   
  <div class="container">
		<div class="about row">
			<h2>contact us</h2>
    <br />
   

     <table style="width: 100%;">
         <tr>
             <td align="center" class="style1" rowspan="2" valign="top">
                
                 <asp:Image ID="Image1" runat="server" Height="300px" 
                     ImageUrl="~/images/osn11.jpg" Width="375px" />
                
             </td>
             <td>
                
                 <p>
                    Contact Person: Anil Kumar
                 </p>
                
             </td>
             <td>
                 
             </td>
         </tr>
         <tr>
             <td>
                 
                 <p>
                 Contact No: 9986565656
                     </p>

                       <p>
                 Email Id: Anil@gmail.com
                     </p>

                       <p>
                 Website Address: FRF.com
                     </p>
                 
             </td>
             <td>
                
             </td>
         </tr>
     </table>

     </div></div>

   <br />

 </asp:Panel>


</asp:Content>
