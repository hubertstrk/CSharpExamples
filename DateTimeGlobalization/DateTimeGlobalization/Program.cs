using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DateTimeGlobalization
{
	class Program
	{
		static void Main( string[] args )
		{
			 DateTime dateTimeRest =  DateTime.Parse( "2012-07-20 11:58:13", CultureInfo.InvariantCulture,
							System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowInnerWhite 
							 | DateTimeStyles.AssumeUniversal );
 
					
		}
	}
}
