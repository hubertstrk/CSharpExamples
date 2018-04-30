using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
	class Program
	{
		static void Main( string[] args )
		{
			// Region and Language: German => 24.03.2015 15:26:02
			// Region and Language: French => 24/03/2015 15:27:43
			Console.WriteLine( DateTime.UtcNow.ToString( CultureInfo.CurrentCulture ) );

			// Region and Language: German => 5600,123
			// Region and Language: English (US) => 5600.123
			double number = 5600.123;
			Console.WriteLine( number.ToString( CultureInfo.CurrentCulture ) );

			// 2015/03/24 15:35:33.626 (always the same since the same format string is used)
			Console.WriteLine( string.Format( CultureInfo.CurrentCulture, "{0:yyyy/MM/dd HH:mm:ss.fff}", DateTime.UtcNow ) );

			Console.ReadLine();
		}
	}
}
