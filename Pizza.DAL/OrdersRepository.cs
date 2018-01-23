using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pizza.DAL
{
    public class OrdersRepository
    {
		public static void AddOrder(Domain.OrdersManager newOrder)
		{
			PizzaEntities db = new PizzaEntities();
			var order = ConvertOrderToEntity(newOrder);
			db.Orders.Add(order);
			db.SaveChanges();
		}

		public static Order ConvertOrderToEntity(Domain.OrdersManager newOrder)
		{
			var order = new Order();

			order.Id = newOrder.Id;
			order.Size = newOrder.Pizza.Size;
			order.Crust = newOrder.Pizza.Crust;
			order.Sausage = newOrder.Pizza.Sausage;
			order.Pepperoni = newOrder.Pizza.Pepperoni;
			order.Onions = newOrder.Pizza.Onions;
			order.GreenPeppers = newOrder.Pizza.GreenPeppers;
			order.Total = newOrder.Pizza.Total;
			order.Name = newOrder.Delivery.Name;
			order.Address = newOrder.Delivery.Address;
			order.Zip = newOrder.Delivery.Zip;
			order.Phone = newOrder.Delivery.Phone;
			order.PaymentMethod = newOrder.Delivery.PaymentMethod;
			order.Complete = newOrder.Complete;

			return order;
		}
	}
}
