using KasperskyConverter.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskyConverter
{
	public class OrderWebWare
	{
		public string OrderNumber { get; set; }

		public string DeliveryNumber { get; set; }

		public int Amount { get; set; }

		public double Cost { get; set; }

		public string EndCustomerAddress { get; set; }

		public WebWareOrder ToEntity()
		{
			return new WebWareOrder()
			{
				Amount = Amount,
				Cost = Cost,
				DeliveryNumber = DeliveryNumber,
				EndCustomerAddress = EndCustomerAddress,
				OrderNumber = OrderNumber
			};
		}
	}
}
