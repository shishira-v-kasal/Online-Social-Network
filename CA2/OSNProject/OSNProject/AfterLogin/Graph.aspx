<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="OSNProject.AfterLogin.Graph" %>
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
                        <asp:Button ID="btnGetData" runat="server" onclick="btnGetData_Click" 
                            Text="GetDataset" ValidationGroup="a" />
                    </td>
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
            <br />


		<div style="float:left;width:340px;">
			<div class="box">
				<h3>Chart type</h3>
				<p>
					<asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="False">
					</asp:DropDownList>
				</p>
			</div>

			<div class="box">
				<p>
					<asp:RadioButtonList ID="rblValueCount" runat="server" AutoPostBack="False" Visible="False" 
                        >
						<asp:ListItem Value="10">10 Values</asp:ListItem>
						<asp:ListItem Value="20">20 Values</asp:ListItem>
						<asp:ListItem Value="50">50 Values</asp:ListItem>
						<asp:ListItem Value="100">100 Values</asp:ListItem>
						<asp:ListItem Value="500" Selected="True">500 Values</asp:ListItem>
					</asp:RadioButtonList>
				</p>
			</div>
		</div>

		<div class="box">
			<h3>3D Settings</h3>
			<p>
				<asp:CheckBox ID="cbUse3D" runat="server" AutoPostBack="False" Text="Use 3D Chart" />
			</p>
			<p>
				<asp:RadioButtonList ID="rblInclinationAngle" runat="server" 
                    AutoPostBack="False" Visible="False">
					<asp:ListItem Value="-90">-90°</asp:ListItem>
					<asp:ListItem Value="-50">-50°</asp:ListItem>
					<asp:ListItem Value="-20">-20°</asp:ListItem>
					<asp:ListItem Value="0">0°</asp:ListItem>
					<asp:ListItem Selected="True" Value="20">20°</asp:ListItem>
					<asp:ListItem Value="50">50°</asp:ListItem>
					<asp:ListItem Value="90">90°</asp:ListItem>
				</asp:RadioButtonList>
			</p>
		</div>

        
  <div>
      <table style="width: 100%;">
          <tr>
              <td>
                  &nbsp;<asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" 
                      ValidationGroup="a" Width="125px" />
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  <b> <font color=blue>Dataset Vs Number of Fake Accounts</font></b></td>
          </tr>
          </table>
  
  </div>
		<asp:Chart ID="cTestChart" runat="server" Height="400px" Width="800px" 
            Visible="False">
			<Series>
				<asp:Series Name="Testing">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartArea1">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>

        <br />
		
        </div>

        </div>
</asp:Content>
