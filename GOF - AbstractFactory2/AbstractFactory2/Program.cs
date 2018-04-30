using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory2
{
	class Program
	{
		static void Main( string[] args )
		{
			ShapeFactory fac = new ShapeFactory();
			Shape c = fac.CreateObject( "Circle" );
			c.Draw();

			Shape s = fac.CreateObject( "Square" );
			s.Draw();

			Console.ReadLine();
		}
	}
}
