using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseVersionNumber
{
	class Program
	{
		static void Main( string[] args )
		{
			Version v = new Version( 1, 2, 3, 4 );
			string s = v.ToString();
		}
	}
}
