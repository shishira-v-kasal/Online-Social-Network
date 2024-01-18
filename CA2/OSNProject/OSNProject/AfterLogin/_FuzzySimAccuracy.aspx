<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="_FuzzySimAccuracy.aspx.cs" Inherits="OSNProject.AfterLogin._FuzzySimAccuracy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />

<div class="container">
		<div class="about row">
			<h2>Clone Attacks!!!</h2>

            <table style="width: 51%;">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtDate1" ErrorMessage="*" ValidationGroup="a">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtDate2" CssClass="validation" ErrorMessage="*" 
                            ValidationGroup="a">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
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
                        <asp:Button ID="btnGetData" runat="server" onclick="btnGetData_Click" 
                            Text="Predict Results" ValidationGroup="a" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>


		    <br />
            <div id="popup">
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            </div>
            <br />
            <asp:Table ID="tableResults" runat="server">
            </asp:Table>
            <br />
		
        </div>

        </div>
</asp:Content>
