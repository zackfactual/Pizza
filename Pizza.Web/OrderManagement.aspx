<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="Pizza.Web.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<h3>Orders to Complete:</h3>
    </div>
    	<asp:GridView ID="ordersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="ordersGridView_RowCommand" DataKeyNames="Id" OnRowCreated="ordersGridView_RowCreated">
			<Columns>
				<asp:ButtonField CommandName="Update" HeaderText="Order Status" Text="Click to Complete Order" />
				<asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size"/>
				<asp:BoundField DataField="Crust" HeaderText="Crust" SortExpression="Crust" />
				<asp:BoundField DataField="Sausage" HeaderText="Sausage" SortExpression="Sausage" />
				<asp:BoundField DataField="Pepperoni" HeaderText="Pepperoni" SortExpression="Pepperoni" />
				<asp:BoundField DataField="Onions" HeaderText="Onions" SortExpression="Onions" />
				<asp:BoundField DataField="GreenPeppers" HeaderText="GreenPeppers" SortExpression="GreenPeppers" />
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" Visible="False" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
			SelectCommand="SELECT [Complete], [Size], [Crust], [Sausage], [Pepperoni], [Onions], [GreenPeppers], [Id] FROM [Order] WHERE ([Complete] = 0)"
			UpdateCommand="UPDATE [Order] SET [Complete] = 1 WHERE [Id] = @Id" >
			<UpdateParameters>
				<asp:Parameter Name="Id" />
			</UpdateParameters>
		</asp:SqlDataSource>
		<br />
    </form>
</body>
</html>
