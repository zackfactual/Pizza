using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
	public class Delivery
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}

	public enum PaymentMethod
	{
		Cash,
		Credit
	}
}
