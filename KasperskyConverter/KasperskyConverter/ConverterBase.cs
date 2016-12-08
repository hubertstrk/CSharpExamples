using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasperskyConverter
{
	public abstract class ConverterBase
	{
		protected string[] SplitLine( string line, char delimiter )
		{
			return line.Split( delimiter );
		}

		protected int FindIndexByText( string[] elemnts, string search )
		{
			int index = 0;
			foreach ( var s in elemnts )
			{
				if ( s.Contains( search ) )
					return index;
				index++;
			}
			return -1;
		}
	}
}
