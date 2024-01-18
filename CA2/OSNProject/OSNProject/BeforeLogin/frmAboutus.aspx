<%@ Page Title="" Language="C#" MasterPageFile="~/BeforeLogin/Main.Master" AutoEventWireup="true" CodeBehind="frmAboutus.aspx.cs" Inherits="OSNProject.frmAboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 352px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelAboutus" runat="server">   
 <div class="container">
		<div class="about row">
			<h2>about us</h2>
    <br />

     <table style="width: 100%;">
         <tr>
             <td align="center" class="style1" valign="top">
                 <asp:Image ID="Image1" runat="server" Height="225px" 
                     ImageUrl="~/images/osn6.gif" Width="325px" />
             </td>
             <td valign="top">
                 <p>
                    The popularity of online social networking sites is getting higher day by day because of the friendliness introduced in the sites and technological advancement. Use of these sites has developed social traditions and behavior in its users. Nowadays, recommendation system has gained its popularity to the researchers’ because of its versatile notion of integrating different research areas. Researchers from psychology, human computer interaction, computer vision, data mining etc. are keeping their attention on this research area. A recommendation system generally interacts with its user in most possible friendly way and recommends doing something in its users favor.
                 </p>
                 <p>
                    Social network sites (SNS’s) have connected millions of users creating the social revolution. Users’ social behavior influences them to connect with others with same mentality. Social networks are constituted because of its user or organizations common interest in some social emerging issues. The popular social networking sites are Facebook, Twitter, MySpace, Orkut, LinkedIn, Google plus etc. which are actually online social networking (OSN) sites. However, the large amount of online users and their diverse and dynamic interests possess great challenges to support recommendation of friends on SNS’s for each of the users. In this paper, we proposed a novel friend recommendation framework (FRF) based on the behavior of users on particular SNS’s. The proposed method is consisted of the following stages: measuring the frequency of the activities done by the users and updating the dataset according to the activities, applying FP-Growth algorithm to classify the user behavior with some criteria, then apply multilayer thresholding for friend recommendation. The proposed framework shows good accuracy for social graphs used as model dataset.</p>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
     </div>
     </div>

   
   <br />

 </asp:Panel>



</asp:Content>
