using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectLists
{
	class Program
	{
		static void Main( string[] args )
		{
			List<int> l1 = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> l2 = new List<int>() { 1, 3, 4 };
			List<int> l3 = new List<int>() { 1, 2, 3, 5 };
			List<int> l4 = new List<int>() { 1 };
			List<List<int>> container = new List<List<int>>() { l1, l2, l3, l4 };

			IEnumerable<int> reference = container.First();
			foreach ( List<int> l in container.Skip(1) )
			{
				reference = reference.Intersect( l );
			}
			List<int> result = reference.ToList();
		}
	}
}
