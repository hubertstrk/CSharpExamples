using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOP
{
	class Program
	{
		static void Main( string[] args )
		{
			// 1	 =>	Ideal		=> This is the highest possible confidence level to be used for applications demanding the highest possible precision at all times.
			// 1-2	 =>	Excellent	=> At this confidence level, positional measurements are considered accurate enough to meet all but the most sensitive applications.
			// 2-5	 =>	Good		=> Represents a level that marks the minimum appropriate for making business decisions. Positional measurements could be used to make reliable in-route navigation suggestions to the user.
			// 5-10	 =>	Moderate	=> Positional measurements could be used for calculations, but the fix quality could still be improved. A more open view of the sky is recommended.
			// 10-20 =>	Fair		=> Represents a low confidence level. Positional measurements should be discarded or used only to indicate a very rough estimate of the current location.
			// >20	 =>	Poor		=> At this level, measurements are inaccurate by as much as 300 meters with a 6 meter accurate device (50 DOP × 6 meters) and should be discarded.

			Console.Title = "DOP Computation Example";
			double[] stp = new double[] { 100, 100 };

			// { p1x, p1y, p2x, p2y, ...  }
			double[] p = new double[] { 100, 161, 100.0000000001, 50/*, 101, 50*/ };

			double[] A = new double[p.Count()];

			for ( int i = 0; i < A.Count(); i = i + 2 )
			{
				double r = Math.Sqrt( Math.Pow( ( stp[0] - p[i] ), 2 ) + Math.Pow( ( stp[1] - p[i+1] ), 2 ) );

				A[i] = ( p[i] - stp[0] ) / r;
				A[i + 1] = ( p[i+1] - stp[1] ) / r;
			}

			double ata11 = 0.0;
			double ata12 = 0.0;
			double ata22 = 0.0;
			for ( int i = 0; i < A.Count(); i = i + 2 )
			{
				ata11 += A[i] * A[i];
				ata12 += A[i] * A[i + 1];
				ata22 += A[i + 1] * A[i + 1];
			}

			double det = ata11 * ata22 - ata12 * ata12;

			double dx_square = ata11 / det;
			double dy_square = ata22 / det;
			double hdop = Math.Sqrt( dx_square + dy_square );

			Console.WriteLine( "DOP: " + hdop );
			Console.ReadLine();
		}
	}
}
