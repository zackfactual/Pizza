using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
	public class Pizza
	{
		public Size Size { get; set; }
		public Crust Crust { get; set; }
		public bool Sausage { get; set; }
		public bool Pepperoni { get; set; }
		public bool Onions { get; set; }
		public bool GreenPeppers { get; set; }
		public decimal Total { get; set; }
	}

	public enum Size
	{
		Small,
		Medium,
		Large
	}

	public enum Crust
	{
		Regular,
		Thin,
		Thick
	}
}
