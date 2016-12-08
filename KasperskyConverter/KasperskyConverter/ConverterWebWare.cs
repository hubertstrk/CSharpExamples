using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KasperskyConverter
{
	public class ConverterWebWare : ConverterBase, IConverter<OrderWebWare>
	{
		private const char m_Delimter = ';';

		public OrderWebWare[] Convert( string[] lines )
		{
			string[] header = SplitLine( lines.First(), m_Delimter );

			int indexOrderNumber = FindIndexByText( header, "OrderNr" );
			int indexDeliverNumber = FindIndexByText( header, "WE_L Nummer" );
			int indexAmount = FindIndexByText( header, "Menge" );
			int indexCost = FindIndexByText( header, "EK-Preis" );
			int indexEndCustomerAddress = FindIndexByText( header, "Endkundenadresse" );

			CultureInfo deCulture = new CultureInfo( "de" );
			NumberFormatInfo numberFormat = deCulture.NumberFormat;

			IList<OrderWebWare> orders = new List<OrderWebWare>();
			for ( int i = 1; i < lines.Count(); i++ )
			{
				string[] splitted = SplitLine( lines[i], m_Delimter );
				var order = new OrderWebWare()
				{
					OrderNumber = splitted[indexOrderNumber],
					DeliveryNumber = splitted[indexDeliverNumber],
					Amount = int.Parse( splitted[indexAmount], NumberStyles.Integer, numberFormat ),
					Cost = double.Parse( splitted[indexCost], NumberStyles.Number, numberFormat ),
					EndCustomerAddress = splitted[indexEndCustomerAddress]
				};
				orders.Add( order );
			}
			return orders.ToArray();
		}
	}
}
