using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Select
{
	class Program
	{
		static void Main( string[] args )
		{
			List<string> text = new List<string>();

			var t = text.Select( s => s.ToString() ).Max();
		}
	}
}
