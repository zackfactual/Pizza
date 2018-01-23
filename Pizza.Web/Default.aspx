<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pizza.Web.Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gimme Pizza</title>
	<link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
        <form id="form1" runat="server">
    <div class="container">
		<div class="page-header">
			<h1>Gimme Pizza</h1>
			<p class="lead">P - I - Z - Z - A</p>
		</div>

		<div class="form-group">
			<label>Size: </label>
			<asp:DropDownList ID="sizeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="sizeDropDownList_SelectedIndexChanged">
				<asp:ListItem Value="Small">Small (12 inch - $12)</asp:ListItem>
				<asp:ListItem Value="Medium">Medium (14 inch - $14)</asp:ListItem>
				<asp:ListItem Value="Large">Large (16 inch - $16)</asp:ListItem>
			</asp:DropDownList>
		</div>

		<div class="form-group">
			<label>Crust: </label>
			<asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="crustDropDownList_SelectedIndexChanged">
				<asp:ListItem Value="Regular">Regular</asp:ListItem>
				<asp:ListItem Value="Thin">Thin</asp:ListItem>
				<asp:ListItem Value="Thick">Thick (+ $2)</asp:ListItem>
			</asp:DropDownList>
		</div>

		<div class="checkbox">
			<label><asp:CheckBox ID="sausageCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="sausageCheckBox_CheckedChanged" />Sausage (+ $2)</label><br />
			<label><asp:CheckBox ID="pepperoniCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="pepperoniCheckBox_CheckedChanged" />Pepperoni (+ $1.50)</label><br />
			<label><asp:CheckBox ID="onionsCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="onionsCheckBox_CheckedChanged" />Onions (+ $1)</label><br />
			<label><asp:CheckBox ID="greenPeppersCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="greenPeppersCheckBox_CheckedChanged" />Green Peppers (+ $1)</label><br />
		</div>

		<h3>Deliver To:</h3>
		<div class="form-group">
			<label>Name: </label>
			<asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
			<label>Address: </label>
			<asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
			<label>Zip: </label>
			<asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox>
			<label>Phone: </label>
			<asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox>
		</div>

		<h3>Payment:</h3>
		<div class="radio">
			<label>
				<asp:RadioButton ID="cashRadioButton" runat="server" GroupName="paymentMethodGroup" />
				Cash
			</label>
		</div>

		<div class="radio">
			<label>
				<asp:RadioButton ID="creditRadioButton" runat="server" GroupName="paymentMethodGroup" />
				Credit
			</label>
		</div>

		<asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
		
		<asp:Button ID="orderButton" runat="server" Text="Order" CssClass="btn btn-lg btn-primary" OnClick="orderButton_Click" />

		<h3>Total Cost: <asp:Label ID="totalCostLabel" runat="server" Text=""></asp:Label></h3>


    </div>
    	
    </form>

	<script src="Scripts/jquery-3.2.1.min.js"></script>
	<script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
