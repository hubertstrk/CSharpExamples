using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPad
{
	class Program
	{
		static void Main( string[] args )
		{
			StringPad dp = new StringPad();
			dp.Write();
		}
	}

	public class StringPad
	{
		public void Write()
		{
			Console.WriteLine( String.Format( "{0,-20}{1,15}{2,15}", "Sagler", "3556059.789", "5460125.467" ) );
			Console.WriteLine( String.Format( "{0,35}{1,15}", "0.1234", "0.7899" ) );

			Console.WriteLine( String.Format( "{0,-20}{1,15}{2,15}", "Brotmannstrasse", "3556059.789", "5460125.467" ) );
			Console.WriteLine( String.Format( "{0,-20}{1,15}{2,15}", "Hohenbrunn", "3556059.789", "5460125.467" ) );
			Console.ReadLine();
		}
	}
}
