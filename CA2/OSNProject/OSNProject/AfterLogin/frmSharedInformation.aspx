<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/PopupMasterpage.Master" AutoEventWireup="true" CodeBehind="frmSharedInformation.aspx.cs" Inherits="OSNProject.AfterLogin.frmSharedInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="panelSharedInformation" runat="server">

     <div class="header_02">Shared Information!</div>
        <table style="width: 35%;">
            <tr>
                <td>
                  
                <td>
                    <asp:Label ID="lblPostType" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="panelText" runat="server" Visible="False">
        <fieldset>
        <legend>Text</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        <strong>Text Title</strong></td>
                    <td>
                        <asp:Label ID="lblTextTitle" runat="server" Width="450px"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <strong>Description</strong></td>
                    <td>
                        <asp:Label ID="lblTextDescription" runat="server" Width="450px"></asp:Label>
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
        </asp:Panel>
        <br />
        <asp:Panel ID="panelPhotos" runat="server" Visible="False">
        <fieldset>
        <legend>Photos</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel ID="panelVideos" runat="server" Visible="False">
        <fieldset>
        <legend>Videos</legend>
            <table style="width:75%;">
                <tr>
                    <td>
                        <asp:Table ID="Table2" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </fieldset>
        </asp:Panel>
        <br />
    <br />
 
                       
                         

    </asp:Panel>
</asp:Content>
