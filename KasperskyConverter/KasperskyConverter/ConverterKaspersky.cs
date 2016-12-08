using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskyConverter
{
	public class ConverterKaspersky : ConverterBase, IConverter<OrderKaspersky>
	{
		private const char m_Delimter = ';';
		private const int m_FirstLineIndex = 16;

		public OrderKaspersky[] Convert( string[] lines )
		{
			string[] header = SplitLine( lines[13], m_Delimter );

			int indexOrderNumber = FindIndexByText( header, "Order #" );
			int indexPurchaseOrder = FindIndexByText( header, "Purch.Order" );
			int indexAmount = FindIndexByText( header, "QTY" );
			int indexPrice = FindIndexByText( header, "Amount" );
			int indexCustomer = FindIndexByText( header, "Customer" );

			CultureInfo deCulture = new CultureInfo( "en-US" );
			NumberFormatInfo numberFormat = deCulture.NumberFormat;

			IList<OrderKaspersky> orders = new List<OrderKaspersky>();
			for ( int i = 15; i < lines.Count(); i++ )
			{
				try
				{
					string[] splitted = SplitLine( lines[i], m_Delimter );
					var order = new OrderKaspersky()
					{
						OrderNumber = splitted[indexOrderNumber],
						PurchaseOrder = splitted[indexPurchaseOrder],
						Amount = int.Parse( splitted[indexAmount], NumberStyles.Number, numberFormat ),
						Price = double.Parse( splitted[indexPrice], NumberStyles.AllowThousands | NumberStyles.Number, numberFormat ),
						Customer = splitted[indexCustomer]
					};
					orders.Add( order );
				}
				catch (FormatException)
				{

				}
			}
			return orders.ToArray();
		}
	}
}
