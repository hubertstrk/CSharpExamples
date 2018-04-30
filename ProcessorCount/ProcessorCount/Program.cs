using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessorCount
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.WriteLine( "The number of processors on this computer is {0}.", Environment.ProcessorCount );
			Console.ReadLine();
		}
	}
}
