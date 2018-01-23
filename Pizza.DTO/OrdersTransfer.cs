using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DTO
{
    public class OrdersTransfer
    {
		public Domain.OrdersManager Order { get; set; }

		public static void SaveOrder(Domain.OrdersManager Order)
		{
			DAL.OrdersRepository.AddOrder(Order);
		}
	}
}
