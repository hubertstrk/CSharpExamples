using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Code___Open_Closed_Principle
{
	class Program
	{
		static void Main( string[] args )
		{
		}
	}

	public class Rectangle : IShape
	{
		public double Height { get; set; }
		public double Width { get; set; }

		public double CalculateArea()
		{
			return Height * Width;
		}
	}

	public class AreaCalculator
	{
		public double CalculateArea( IList<Rectangle> rectangles )
		{
			double area = 0.0;
			foreach ( Rectangle r in rectangles )
			{
				area += r.Height * r.Width;
			}
			return area;
		}
	}

	public interface IShape
	{
		double CalculateArea();

		public double test()
		{
			return Math.PI * Math.Pow( 1, 2 );
		}
	}
}
