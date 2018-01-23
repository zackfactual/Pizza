using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pizza.Domain.Exceptions;

namespace Pizza.Web
{
	public partial class Default : System.Web.UI.Page
	{
		// on page load or selection change, build pizza and update total cost
		protected void Page_Load(object sender, EventArgs e)
		{
			UpdateTotal();
		}
		
		protected void sizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}

		protected void crustDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}

		protected void sausageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}

		protected void pepperoniCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}

		protected void onionsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}

		protected void greenPeppersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTotal();
		}
		
		public Domain.Pizza UpdateTotal()
		{
			// create new pizza
			var newPizza = new Domain.Pizza();

			//initialize total cost
			newPizza.Total = 0.0M;

			// price user's selections
			Domain.Size sizeSelection;
			if (Enum.TryParse(sizeDropDownList.SelectedValue, out sizeSelection))
				newPizza.Size = sizeSelection;
			switch (newPizza.Size)
			{
				case Domain.Size.Small:
					newPizza.Total += 12.0M;
					break;
				case Domain.Size.Medium:
					newPizza.Total += 14.0M;
					break;
				case Domain.Size.Large:
					newPizza.Total += 16.0M;
					break;
				default:
					break;
			}

			Domain.Crust crustSelection;
			if (Enum.TryParse(crustDropDownList.SelectedValue, out crustSelection))
				newPizza.Crust = crustSelection;
			switch (newPizza.Crust)
			{
				case Domain.Crust.Regular:
				case Domain.Crust.Thin:
					break;
				case Domain.Crust.Thick:
					newPizza.Total += 2.0M;
					break;
				default:
					break;
			}

			if (sausageCheckBox.Checked)
			{
				newPizza.Sausage = true;
				newPizza.Total += 2.0M;
			}

			if (pepperoniCheckBox.Checked)
			{
				newPizza.Pepperoni = true;
				newPizza.Total += 1.5M;
			}

			if (onionsCheckBox.Checked)
			{
				newPizza.Onions = true;
				newPizza.Total += 1.0M;
			}

			if (greenPeppersCheckBox.Checked)
			{
				newPizza.GreenPeppers = true;
				newPizza.Total += 1.0M;
			}

			// display total cost
			totalCostLabel.Text = String.Format("{0:c}",
				newPizza.Total);

			return newPizza;
		}

		// on button click, inform user of success/failure and save new order
		protected void orderButton_Click(object sender, EventArgs e)
		{
			ValidateDelivery();
		}

		public void ValidateDelivery()
		{
			var error = "";
			try
			{
				// validate required fields and throw custom exceptions where invalid
				if (nameTextBox.Text.Trim().Length == 0)
					throw new NameTextBoxEmptyException();
				else if (addressTextBox.Text.Trim().Length == 0)
					throw new AddressTextBoxEmptyException();
				else if (zipTextBox.Text.Trim().Length == 0)
					throw new ZipTextBoxEmptyException();
				else if (phoneTextBox.Text.Trim().Length == 0)
					throw new PhoneTextBoxEmptyException();
				else if (!cashRadioButton.Checked && !creditRadioButton.Checked)
					throw new NoPaymentMethodSelectedException();
				else
				{
					var orderToFeed = PlaceOrder();
					DTO.OrdersTransfer.SaveOrder(orderToFeed);
					Response.Redirect("Success.aspx");
				}

			}

			// exception messages
			catch (NameTextBoxEmptyException)
			{
				error = "<br /><p style='color:#ff0000'>Would you please input your name?</p><br />";
			}
			catch (AddressTextBoxEmptyException)
			{
				error = "<br /><p style='color:#ff0000'>Would you please input your address?</p><br />";
			}
			catch (ZipTextBoxEmptyException)
			{
				error = "<br /><p style='color:#ff0000'>Would you please input your zip code?</p><br />";
			}
			catch (PhoneTextBoxEmptyException)
			{
				error = "<br /><p style='color:#ff0000'>Would you please input your phone number?</p><br />";
			}
			catch (NoPaymentMethodSelectedException)
			{
				error = "<br /><p style='color:#ff0000'>Would you please select a payment method?</p><br />";
			}
			catch (Exception ex)
			{
				error = "<br /><p style='color:#ff0000'>There was an unexpected error: " + ex.Message + "</p><br />";
			}

			errorLabel.Text = error;
		}

		// create a new delivery
		public Domain.OrdersManager PlaceOrder()
		{
			var newOrder = new Domain.OrdersManager();
			newOrder.Id = Guid.NewGuid();
			newOrder.Pizza = UpdateTotal();
			newOrder.Delivery = new Domain.Delivery();
			newOrder.Delivery.Name = nameTextBox.Text;
			newOrder.Delivery.Address = addressTextBox.Text;
			newOrder.Delivery.Zip = zipTextBox.Text;
			newOrder.Delivery.Phone = phoneTextBox.Text;
			if (cashRadioButton.Checked)
				newOrder.Delivery.PaymentMethod = Domain.PaymentMethod.Cash;
			else if (creditRadioButton.Checked)
				newOrder.Delivery.PaymentMethod = Domain.PaymentMethod.Credit;
			newOrder.Complete = false;
			return newOrder;
		}
	}
}