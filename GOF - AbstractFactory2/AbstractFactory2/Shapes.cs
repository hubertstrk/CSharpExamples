using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory2
{
	public abstract class Shape
	{
		public abstract void Draw();
	}

	public class Circle : Shape
	{
		public static Shape CreateObject()
		{
			return new Circle();
		}

		public override void Draw()
		{
			Console.WriteLine( "Drawing Circle." );
		}
	}

	public class Square : Shape
	{
		public static Shape CreateObject()
		{
			return new Square();
		}

		public override void Draw()
		{
			Console.WriteLine( "Drawing Square." );
		}
	}
}
