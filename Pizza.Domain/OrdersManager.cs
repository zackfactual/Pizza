using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
    public class OrdersManager
    {
		public Guid Id { get; set; }
		public Pizza Pizza { get; set; }
		public Delivery Delivery { get; set; }
		public bool Complete { get; set; }
	}
}
