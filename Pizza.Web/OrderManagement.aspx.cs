using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza.Web
{
	public partial class OrderManagement : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		// rename gridview cell values for easier user comprehension
		protected void ordersGridView_RowCreated(object sender, GridViewRowEventArgs e)
		{
			formatGridView();
		}

		private void formatGridView()
		{
			foreach (GridViewRow row in ordersGridView.Rows)
			{
				if (row.Cells[1].Text == "0")
					row.Cells[1].Text = "Small";
				else if (row.Cells[1].Text == "1")
					row.Cells[1].Text = "Medium";
				else if (row.Cells[1].Text == "2")
					row.Cells[1].Text = "Large";
				
				if (row.Cells[2].Text == "0")
					row.Cells[2].Text = "Regular";
				else if (row.Cells[2].Text == "1")
					row.Cells[2].Text = "Thin";
				else if (row.Cells[2].Text == "2")
					row.Cells[2].Text = "Thick";

				row.Cells[3].Text = formatBool(row.Cells[3].Text);
				row.Cells[4].Text = formatBool(row.Cells[4].Text);
				row.Cells[5].Text = formatBool(row.Cells[5].Text);
				row.Cells[6].Text = formatBool(row.Cells[6].Text);
			}
		}

		private string formatBool(string boolName)
		{
			if (boolName == "False")
				boolName = "No";
			else if (boolName == "True")
				boolName = "Yes";
			return boolName;
		}

		// on click, set order to complete in database
		protected void ordersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int index = Convert.ToInt32(e.CommandArgument);
			GridViewRow completingRow = ordersGridView.Rows[index];
			string Id = completingRow.Cells[7].ToString();
			SqlDataSource1.Update();
		}
	}
}