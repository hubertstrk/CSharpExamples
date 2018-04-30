using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DoubleParse
{
	class Program
	{
		static void Main( string[] args )
		{
			double value = double.NaN;
			try
			{
				value = double.Parse( "0.er4", CultureInfo.InvariantCulture );
			}
			catch ( FormatException )
			{ 
			
			}
		}
	}
}
