using KasperskyConverter.Database;
using System;

namespace KasperskyConverter
{
	public class OrderKaspersky
	{
		public int Amount { get; set; }

		public double Price { get; set; }

		public string Customer { get; set; }

		public string OrderNumber { get; set; }

		public string PurchaseOrder { get; set; }

		public KasperskyOrder ToEntity()
		{
			return new KasperskyOrder()
			{
				Amount = Amount,
				Customer = Customer,
				OrderNumber = OrderNumber,
				Price = Price,
				PurchaseOrder = PurchaseOrder
			};
		}
	}
}
